// This code is licensed under the Keep It Free License V1.
// You may find a full copy of this license at root project directory\LICENSE
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.IO.Compression;
using System.Windows.Forms;
using IOPath = System.IO.Path;
using DAZ_Installer.Utilities;
using System.Threading.Tasks;
using System.Threading;

namespace DAZ_Installer.DP {
    // Notes: 
    // Directories are listed with "l -slt" with the D attribute. Files are with the A attribute.
    // Attributes: R - Read-only, H - Hidden, S - System, A - Archive (file), D - Directory
    // Note for NTFS - N - Normal is not stored on disk, is dynamically generated by OS.
    // For more info: https://jpsoft.com/help/attrswitch.htm - Attribute Switches section
    // In the event where there is no more room, 7z will stop extracting even if there is more to
    // extract.
    internal class DP7zArchive : DPAbstractArchive
    {
        private bool _hasEncryptedFiles = false;
        private bool _hasEncryptedHeader = false;
        private Process _process = null;
        private bool _processHasStarted = false;
        private string _arcPassword = string.Empty;

        // Peek phase variables.
        private bool _peekErrored = false;
        private bool _peekFinished = false;

        // Extract phase variables.
        private bool _extractErrored = false;
        private bool _extractFinished = false;

        private bool _seekingFiles = false;

        private Entity _lastEntity = new Entity{ };

        private struct Entity
        {
            internal string Path;
            internal bool isDirectory;

            internal bool IsEmpty => Path == null;
        }

        internal DP7zArchive(string _path,  bool innerArchive = false, string? relativePathBase = null) : base(_path, innerArchive, relativePathBase) {}

        // It's best for 7z to extract everything to the temp directory.
        internal override void Extract()
        {
            mode = Mode.Extract;
            if (_processHasStarted && (!_process?.HasExited ?? false)) _process.Kill();

            // Setup the process to extract ALL files to the temp folder.
            var tempFolder = IOPath.Combine(DPProcessor.TempLocation, IOPath.GetFileNameWithoutExtension(Path));
            try
            {
                Directory.CreateDirectory(tempFolder);
            } catch { }
            foreach (var file in Contents)
            {
                file.ExtractedPath = IOPath.Combine(tempFolder, file.Path);
            }
            _process = Setup7ZProcess();
            _process.StartInfo.ArgumentList.Add("-o" + tempFolder);
            StartProcess();
            ProgressCombo?.UpdateText($"Extracting to temp from archive {IOPath.GetFileName(Path)}...");
            if (!SpinWait.SpinUntil(() => _extractFinished, 60 * 1000))
            {
                DPCommon.WriteToLog($"Extract timeout exceeded for {ExtractedPath}.");
            }
            
            
        }
        #region Override Methods

        internal override void Peek()
        {
            mode = Mode.Peek;
            _process = Setup7ZProcess();
            StartProcess();
            if (ProgressCombo == null) ProgressCombo = new DPProgressCombo();
            ProgressCombo.ChangeProgressBarStyle(true);
            ProgressCombo.UpdateText($"Seeking files in archive {IOPath.GetFileName(Path)}...");
            if (!SpinWait.SpinUntil(() => _peekFinished, 60 * 1000))
            {
                DPCommon.WriteToLog($"Peek timeout exceeded for {IOPath.GetFileName(Path)}.");
            }
        }

        internal override void ReadContentFiles()
        {
            foreach (var file in DazFiles)
            {
                // Skip if the file wasn't extracted at all or if it was extracted to temp.
                if (!file.WasExtracted || (file.WasExtracted && file.ExtractedPath != file.TargetPath)) continue;
                try
                {
                    using (var stream = new FileStream(file.ExtractedPath, FileMode.Open))
                    {
                        if (stream.ReadByte() == 0x1F && stream.ReadByte() == 0x8B)
                        {
                            // It is gzipped compressed.
                            stream.Seek(0, SeekOrigin.Begin);
                            using (var gstream = new GZipStream(stream, CompressionMode.Decompress))
                            {
                                using (var streamReader = new StreamReader(gstream, Encoding.UTF8, true))
                                {
                                    file.ReadContents(streamReader);
                                }
                            }
                        }
                        else
                        {
                            // It is normal text.
                            stream.Seek(0, SeekOrigin.Begin);
                            using (var streamReader = new StreamReader(stream, Encoding.UTF8, true))
                            {
                                file.ReadContents(streamReader);
                            }
                        }
                    }

                }
                catch { }
            }
        }

        internal override void ReadMetaFiles()
        {
            foreach (var file in DSXFiles)
            {
                if (file.WasExtracted)
                    file.CheckContents();
            }
        }

        internal override void ReleaseArchiveHandles()
        {
            _process?.Dispose();
        }
        #endregion
        private bool StartProcess()
        {
            try
            {
                _process.Start();
                _processHasStarted = true;
                _process.BeginOutputReadLine();
                _process.BeginErrorReadLine();
                _process.StandardInput.WriteLineAsync(_arcPassword);
            } catch { return false; }
            return true;
        }
        
        /// <summary>
        /// Creates a new 7z process object depending on the current mode.
        /// If the current mode is Peek, then it will tell 7z to list contents.
        /// Otherwise, it will tell 7z to extract contents.
        /// </summary>
        /// <returns>A 7z process.</returns>
        private Process Setup7ZProcess() {
            _process?.Dispose();
            Process process = new Process();
            process.StartInfo.FileName = "7za.exe";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.CreateNoWindow = true;
            process.EnableRaisingEvents = true;
            process.OutputDataReceived += Handle7zOutput;
            process.ErrorDataReceived += Handle7zErrors;

            if (mode == Mode.Peek)
                process.StartInfo.ArgumentList.Add("l");
            else
                process.StartInfo.ArgumentList.Add("x");
            process.StartInfo.ArgumentList.Add("-aoa"); // Overwrite existing files w/o prompt.
            process.StartInfo.ArgumentList.Add("-slt"); // Show technical information.
            //process.StartInfo.ArgumentList.Add("-bb1"); // Show names of processed files in log.

            if (IsInnerArchive)
                process.StartInfo.ArgumentList.Add(ExtractedPath);
            else
                process.StartInfo.ArgumentList.Add(Path);
            return process;
        }

        private void Handle7zErrors(object _, DataReceivedEventArgs e)
        {
            if (e.Data is null) return;
            ReadOnlySpan<char> msg = e.Data;
            if (msg.Contains("Can not open encrypted archive. Wrong password?"))
            {
                MessageBox.Show($"Unfortunately, {IOPath.GetFileName(Path)} is encrypted and we " +
                    "currently do not support encryption yet for 7z files.", "Unsupported encrypted archive", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            DPCommon.WriteToLog($"Handle 7z errors called! Msg: {e.Data}");
        }

        /// <summary>
        /// Handles the appropriate action when receiving data from StandardOutput.
        /// </summary>
        private void Handle7zOutput(object _, DataReceivedEventArgs e)
        {
            DPCommon.WriteToLog($"Handle 7z output called! Msg: {e.Data}");
            if (e.Data == null || _hasEncryptedFiles)
            {
                if (mode == Mode.Peek) _peekFinished = true;
                else _extractFinished = true;
                if (_hasEncryptedFiles)
                {
                    MessageBox.Show($"Unfortunately, {IOPath.GetFileName(Path)} is encrypted and we " +
                    "currently do not support encryption yet for 7z files.", "Unsupported encrypted archive", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _process.OutputDataReceived -= Handle7zOutput;
                    _process.ErrorDataReceived -= Handle7zErrors;
                }
                return;
            }
            ReadOnlySpan<char> msg = e.Data;
            if (mode == Mode.Peek)
            {
                if (msg.StartsWith("----------")) _seekingFiles = true;
                if (!_seekingFiles) return;

                if (msg.StartsWith("Path"))
                {
                    if (!_lastEntity.IsEmpty) FinalizeEntity();
                    _lastEntity = new Entity { Path = msg.Slice(7).ToString() };
                }
                else if (msg.StartsWith("Size"))
                {
                    ulong.TryParse(msg.Slice(7), out ulong size);
                    TrueArchiveSize += size;
                }
                else if (msg.StartsWith("Attributes"))
                {
                    var attributes = msg.Slice("Attributes = ".Length);
                    _lastEntity.isDirectory = attributes.Contains("D");
                }
                else if (msg.StartsWith("Encrypted"))
                    _hasEncryptedFiles = msg.Contains("+");
                else if (msg.Contains("Errors:"))
                    _peekErrored = true;
            } else
            {
                // Only check if everything really did extract if 
                var ok = msg.StartsWith("Everything is Ok");
                var errors = msg.Contains("Errors");
                if (!ok && !errors) return;
                _extractErrored = errors;
                ValidateFilesExtraction();
                // Now retarget and move files from temp to it's apporpriate destination.
                ProgressCombo?.UpdateText($"Moving files from archive {IOPath.GetFileName(Path)}...");
                foreach (var file in Contents)
                {
                    if (!file.WasExtracted) continue;
                    var fileInfo = new FileInfo(file.ExtractedPath);
                    try
                    {
                        fileInfo.MoveTo(file.TargetPath, true);
                        file.ExtractedPath = file.TargetPath;
                        file.WasExtracted = true;
                    } catch (Exception ex) 
                    {
                        DPCommon.WriteToLog($"Failed to move {file.Path} to {file.ExtractedPath}. REASON: {ex}");
                    }
                }
                _extractFinished = true;
            }
        }

        private void ValidateFilesExtraction()
        {
            foreach (var file in Contents)
            {
                FileInfo fileInfo = new FileInfo(file.ExtractedPath);
                file.WasExtracted = fileInfo.Exists;
            }
        }

        private void FinalizeEntity()
        {
            if (_lastEntity.isDirectory)
                _ = new DPFolder(_lastEntity.Path, null);
            else
            {
                var ext = GetExtension(_lastEntity.Path);
                if (DPFile.ValidImportExtension(ext))
                {
                    var newArchive = CreateNewArchive(_lastEntity.Path, true, RelativePath);
                    newArchive.ParentArchive = this;
                }
                else
                {
                    var newFile = DPFile.CreateNewFile(_lastEntity.Path, null);
                    newFile.AssociatedArchive = this;
                }
            }
        }
    }
}