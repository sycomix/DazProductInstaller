﻿// This code is licensed under the Keep It Free License V1.
// You may find a full copy of this license at root project directory\LICENSE
using System;
using System.IO;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;
using DAZ_Installer.DP;

namespace DAZ_Installer
{
    /// <summary>
    /// The Library class is responsible for the loading, adding & removing LibraryItems. It is also responsible for controlling the LibraryPanel and effectively managing image resources. It also controls search interactions. 
    /// </summary>
    public partial class Library : UserControl
    {
        public static Library self;
        protected static Image arrowRight;
        protected static Image arrowDown;
        protected static Image noImageFound;
        protected static Size lastClientSize;
        protected const byte maxImagesLoad = byte.MaxValue;
        protected const byte maxListSize = 25;
        protected byte maxImageFit;
        protected List<LibraryItem> libraryItems { get => libraryPanel1.LibraryItems; }
        protected List<LibraryItem> searchItems { get => libraryPanel1.SearchItems; set => libraryPanel1.SearchItems = value; }
        protected DPProductRecord[] ProductRecords { get; set; } = new DPProductRecord[0];
        private DPProductRecord[] SearchRecords { get; set; } = new DPProductRecord[0];
        
        protected bool mainImagesLoaded = false;

        internal DPSortMethod SearchSortMethod = DPSortMethod.Date;

        protected bool SearchMode
        {
            get => searchMode;
            set => libraryPanel1.SearchMode = searchMode = value;
        }
        private bool searchMode;
        private uint lastSearchID = 1;
        // Quick Library Info 
        public Library()
        {
            InitializeComponent();
            self = this;  
        }

        // Called only when visible. Can be loaded but but visible.
        private void Library_Load(object sender, EventArgs e)
        {

            libraryPanel1.CurrentPage = 1;
            Task.Run(LoadLibraryItemImages)
                .ContinueWith(t => LoadLibraryItems());
            libraryPanel1.AddPageChangeListener(UpdatePage);
            DPDatabase.ProductRecordAdded += OnAddedProductRecord;
            DPDatabase.ProductRecordRemoved += OnRemovedProductRecord;
            DPDatabase.ProductRecordModified += OnModifiedProductRecord;
        }

        // Called on a different thread.
        public void LoadLibraryItemImages()
        {
            thumbnails.Images.Add(Properties.Resources.NoImageFound);

            noImageFound = thumbnails.Images[0];
            mainImagesLoaded = true;
            DPCommon.WriteToLog("Loaded images.");

        }

        private void LoadLibraryItems()
        {
            if (Program.IsRunByIDE && !IsHandleCreated) return;
            DPDatabase.GetProductRecordsQ(DPSortMethod.None, (uint) libraryPanel1.CurrentPage, 25, 0, OnLibraryQueryUpdate);

            // Invoke or BeginInvoke cannot be called on a control until the window handle has been created.'
            DPCommon.WriteToLog("Loaded library items.");

        }

        /// <summary>
        ///  Clears the current page library items or search items and handles removing image references.
        /// </summary>
        private void ClearPageContents()
        {
            libraryPanel1.EditMode = true;
            if (searchMode)
            {
                foreach (var lb in libraryPanel1.LibraryItems)
                {
                    if (lb == null || lb.ProductRecord == null) continue;

                    lb.Image = null;
                    RemoveReferenceImage(Path.GetFileName(lb.ProductRecord.ThumbnailPath));
                    lb.Dispose();
                }
                libraryPanel1.LibraryItems.Clear();
            } else
            {
                if (searchItems == null)
                {
                    libraryPanel1.EditMode = false;
                    return;
                }
                foreach (var lb in libraryPanel1.SearchItems)
                {
                    if (lb == null || lb.ProductRecord == null) continue;

                    lb.Image = null;
                    RemoveReferenceImage(Path.GetFileName(lb.ProductRecord.ThumbnailPath));
                    lb.Dispose();
                }
                libraryPanel1.SearchItems.Clear();
            }
            libraryPanel1.EditMode = false;
        }

        internal LibraryItem AddNewSearchItem(DPProductRecord record)
        {
            if (InvokeRequired) 
                return (LibraryItem)Invoke(new Func<DPProductRecord, LibraryItem>(AddNewSearchItem), record);

            var searchItem = new LibraryItem();
            searchItem.TitleText = record.ProductName;
            searchItem.Tags = record.Tags;
            searchItem.Dock = DockStyle.Top;
            searchItem.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            searchItems.Add(searchItem);

            return searchItem;
        }

        internal LibraryItem AddNewLibraryItem(DPProductRecord record)
        {
            if (InvokeRequired)
            {
                return (LibraryItem)Invoke(new Func<DPProductRecord, LibraryItem>(AddNewLibraryItem), record);
            }
            var lb = new LibraryItem();
            lb.TitleText = record.ProductName;
            lb.Tags = record.Tags;
            lb.Dock = DockStyle.Top;
            lb.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            lb.Image = noImageFound;

            if (libraryItems.Count != libraryItems.Capacity) libraryItems.Add(lb);
            return lb;
        }

        public LibraryItem AddNewLibraryItem(string title, string[] tags, string[] folders)
        {
            if (InvokeRequired)
            {
                return (LibraryItem)Invoke(new Func<string, string[], string[], LibraryItem>(AddNewLibraryItem), title, tags, folders);
            }
            var lb = new LibraryItem();
            lb.TitleText = title;
            lb.Tags = tags;
            //lb.Folders = folders;
            lb.Dock = DockStyle.Top;
            lb.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            lb.Image = noImageFound;

            if (libraryItems.Count != libraryItems.Capacity) libraryItems.Add(lb);
            
            return lb;
        }

        public Image AddReferenceImage(string filePath)
        {
            if (filePath == null) return noImageFound;
            // Key = FileName
            var fileName = Path.GetFileName(filePath);
            if (thumbnails.Images.ContainsKey(fileName))
            {
                var i = thumbnails.Images.IndexOfKey(fileName);
                return thumbnails.Images[i];
            } else
            {
                // 125, 119
                var icon = Image.FromFile(filePath);
                thumbnails.Images.Add(icon);
                // Get the last index.
                var i = thumbnails.Images.Count - 1;
                thumbnails.Images.SetKeyName(i, fileName);
                return thumbnails.Images[i];
            }
        }

        public void RemoveReferenceImage(string imageName)
        {
            if (thumbnails.Images.ContainsKey(imageName))
            {
                thumbnails.Images.RemoveByKey(imageName);
                thumbnails.Images.Keys.Remove(imageName);
            }
        }

        // Used whenever a change has been made
        // 
        
        // Try page update
        internal void TryPageUpdate()
        {
            if (InvokeRequired)
            {
                Invoke(TryPageUpdate);
                return;
            }
            try
            {
                ClearPageContents();
                ClearLibraryItems();
                ClearSearchItems();
                if (searchMode) AddSearchItems();
                else AddLibraryItems();
                // TO DO : Check if we need to move to the left page.
                // Example - There are no library items on current page (invalid page) and no pages above it.
                UpdatePageCount();
                if (InvokeRequired) Invoke(libraryPanel1.UpdateMainContent);
                else libraryPanel1.UpdateMainContent();
            } catch { }
        }
        public void ForcePageUpdate()
        {
            if (InvokeRequired) {Invoke(ForcePageUpdate); return; }
            DPCommon.WriteToLog("force page update called.");
            ClearPageContents();
            ClearSearchItems();
            ClearLibraryItems();
            AddLibraryItems();
            // TO DO : Check if we need to move to the left page.
            // Example - There are no library items on current page (invalid page) and no pages above it.
            UpdatePageCount();
            libraryPanel1.UpdateMainContent();
            
        }

        // Used for handling page events.
        // TODO: Potential previous page == the same dispite mode.
        public void UpdatePage(uint page) {
            DPCommon.WriteToLog("page update called.");
            // if (page == libraryPanel1.PreviousPage) return;
            
            if (!searchMode) {
                DPDatabase.GetProductRecordsQ(DPSortMethod.None, page, 25, callback: OnLibraryQueryUpdate);
            } else {
                TryPageUpdate();
            }
        }

        private void UpdatePageCount()
        {
            uint pageCount = searchMode ?
                (uint)Math.Ceiling(SearchRecords.Length / 25f) :
                (uint)Math.Ceiling(DPDatabase.ProductRecordCount / 25f);

            if (pageCount != libraryPanel1.PageCount) libraryPanel1.PageCount = pageCount;
        }

        private void AddLibraryItems()
        {
            DPCommon.WriteToLog("Add library items.");
            libraryPanel1.EditMode = true;
            // Loop while i is less than records count and count is less than 25.
            for (var i = 0; i < ProductRecords.Length; i++)
            {
                var record = ProductRecords[i];
                var lb = AddNewLibraryItem(record);
                lb.ProductRecord = record;

                lb.Image = File.Exists(record.ThumbnailPath) ? AddReferenceImage(record.ThumbnailPath) 
                                                            : noImageFound;

            }
            libraryPanel1.EditMode = false;
        }

        private void AddSearchItems()
        {
            DPCommon.WriteToLog("Add search items.");
            libraryPanel1.EditMode = true;
            // Loop while i is less than records count and count is less than 25.
            var startIndex = (libraryPanel1.CurrentPage - 1) * 25;
            var count = 0;
            for (var i = startIndex; i < SearchRecords.Length && count < 25; i++, count++) {
                var record = SearchRecords[i];
                var lb = AddNewSearchItem(record);
                lb.ProductRecord = record;
                
                lb.Image = File.Exists(record.ThumbnailPath) ? AddReferenceImage(record.ThumbnailPath) 
                                                            : noImageFound;
            }
            libraryPanel1.EditMode = false;
        }
        

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
            Forms.DatabaseView databaseView = new Forms.DatabaseView();
            databaseView.ShowDialog();
        }

        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            // Switch modes if search box is empty & we were in search mode previously.
            if (searchBox.Text.Length == 0 && searchMode) SwitchModes(false);
        }

        private void searchBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (searchBox.Text.Length != 0) {
                    lastSearchID = (uint) Random.Shared.Next(1,int.MaxValue);
                    DPDatabase.SearchQ(searchBox.Text, DPSortMethod.Relevance, callback: OnSearchUpdate);
                }
            }
        }

        private void SwitchModes(bool toSearch)
        {
            SearchMode = toSearch;
            TryPageUpdate();
        }

        private void OnSearchUpdate(DPProductRecord[] searchResults)
        {
            SearchRecords = searchResults;
            if (!searchMode) SwitchModes(true);
            else TryPageUpdate();
        }

        private void OnLibraryQueryUpdate(DPProductRecord[] productRecords)
        {
            ProductRecords = productRecords;
            if (!searchMode) TryPageUpdate();
        }

        private void OnAddedProductRecord(DPProductRecord record, uint recordID)
        {
            DPCommon.WriteToLog($"A product has been added! {record.ProductName}");
            // First, check to see if it is in range of the current page.
            // If it is, then we need to update that page.
            if (recordID <= (libraryPanel1.CurrentPage) * 25 && recordID > (libraryPanel1.CurrentPage - 1) * 25)
            {
                var newProductRecords = new DPProductRecord[ProductRecords.Length + 1];
                ProductRecords.CopyTo(newProductRecords, 0);
                ProductRecords = newProductRecords;
                ProductRecords[ProductRecords.Length -1] = record;
                TryPageUpdate();
            }
            
            // Otherwise, we may need to change the page count and current page.
            if ((uint)Math.Ceiling((DPDatabase.ProductRecordCount + 1) / 25f) != libraryPanel1.PageCount)
            {
                libraryPanel1.NudgePageCount(libraryPanel1.PageCount + 1);
                // Now we need to update the current page.
                // If the ID is higher than the current page range, then we don't do anything.
                // Otherwise, we need to move the current page up one.
                if (recordID < libraryPanel1.CurrentPage * 25)
                    libraryPanel1.NudgeCurrentPage(libraryPanel1.CurrentPage + 1);
            }
        }

        private void OnRemovedProductRecord(uint ID)
        {
            for (var i = 0; i < ProductRecords.Length; i++)
            {
                // DO NOT FAST DELETE SWAP, ORDER MUST BE MAINTAINED!
                if (ProductRecords[i].ID == ID)
                {
                    var records = new DPProductRecord[ProductRecords.Length - 1];
                    Array.ConstrainedCopy(ProductRecords, 0, records, 0, i);
                    Array.ConstrainedCopy(ProductRecords, i + 1, records, i, records.Length - i);
                    var lb = libraryPanel1.LibraryItems.Find(l => l.ProductRecord == ProductRecords[i]);
                    if (lb != null) DisableLibraryItem(lb);
                    ProductRecords = records;
                    break;
                }
            }
            if (!searchMode) goto UPDATE;
            for (var i = 0; i < SearchRecords.Length; i++)
            {
                // DO NOT FAST DELETE SWAP, ORDER MUST BE MAINTAINED!
                if (SearchRecords[i].ID == ID)
                {
                    var records = new DPProductRecord[SearchRecords.Length - 1];
                    Array.ConstrainedCopy(SearchRecords, 0, records, 0, i);
                    Array.ConstrainedCopy(SearchRecords, i + 1, records, i, records.Length - i);
                    var lb = libraryPanel1.LibraryItems.Find(l => l.ProductRecord == SearchRecords[i]);
                    if (lb != null) DisableLibraryItem(lb);
                    SearchRecords = records;
                    break;
                }
            }
            UPDATE:
            TryPageUpdate();
        }

        private void OnModifiedProductRecord(DPProductRecord updatedRecord, uint oldID) {
            if (searchMode)
            {
                var index = Array.FindIndex(SearchRecords, r => r.ID == oldID);
                if (index == -1) return;
                var lb = libraryPanel1.LibraryItems.Find(l => l.ProductRecord == SearchRecords[index]);
                if (lb is null) return;
                UpdateLibraryItem(lb, updatedRecord);
                SearchRecords[index] = updatedRecord;
            } else
            {
                var index = Array.FindIndex(ProductRecords, r => r.ID == oldID);
                if (index == -1) return;
                var lb = libraryPanel1.LibraryItems.Find(l => l.ProductRecord == ProductRecords[index]);
                if (lb is null) return;
                UpdateLibraryItem(lb, updatedRecord);
                ProductRecords[index] = updatedRecord;
            }
        }

        public void ClearLibraryItems() => libraryItems.Clear();
        public void ClearSearchItems() => searchItems.Clear();

        private void UpdateLibraryItem(LibraryItem lb, DPProductRecord record)
        {
            if (InvokeRequired)
            {
                Invoke(UpdateLibraryItem, lb, record);
                return;
            }
            libraryPanel1.EditMode = true; 
            lb.TitleText = record.ProductName;
            lb.Tags = record.Tags;
            lb.ProductRecord = record;
            lb.Image = File.Exists(record.ThumbnailPath) ? AddReferenceImage(record.ThumbnailPath)
                                                        : noImageFound;
            libraryPanel1.EditMode = false;
        }

        private void DisableLibraryItem(LibraryItem lb)
        {
            if (InvokeRequired)
            {
                Invoke(DisableLibraryItem, lb);
                return;
            }
            lb.Enabled = lb.Visible = false;
        }
    }
}
