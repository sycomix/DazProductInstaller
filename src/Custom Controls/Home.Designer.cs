﻿
namespace DAZ_Installer
{
    partial class Home
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.titleLbl = new System.Windows.Forms.Label();
            this.extractBtn = new System.Windows.Forms.Button();
            this.dragHerePanel = new System.Windows.Forms.Panel();
            this.dropText = new System.Windows.Forms.Label();
            this.addMoreFilesBtn = new System.Windows.Forms.Button();
            this.clearListBtn = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.homeListContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addMoreItemsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dragHerePanel.SuspendLayout();
            this.homeListContextMenuStrip.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // titleLbl
            // 
            this.titleLbl.Dock = System.Windows.Forms.DockStyle.Top;
            this.titleLbl.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.titleLbl.Location = new System.Drawing.Point(0, 0);
            this.titleLbl.Name = "titleLbl";
            this.titleLbl.Size = new System.Drawing.Size(542, 55);
            this.titleLbl.TabIndex = 0;
            this.titleLbl.Text = "Daz Product Installer";
            this.titleLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // extractBtn
            // 
            this.extractBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.extractBtn.Location = new System.Drawing.Point(130, 208);
            this.extractBtn.Name = "extractBtn";
            this.extractBtn.Size = new System.Drawing.Size(248, 38);
            this.extractBtn.TabIndex = 2;
            this.extractBtn.Text = "Extract File(s)";
            this.extractBtn.UseVisualStyleBackColor = true;
            this.extractBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // dragHerePanel
            // 
            this.dragHerePanel.AllowDrop = true;
            this.dragHerePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dragHerePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(231)))), ((int)(((byte)(254)))), ((int)(((byte)(232)))));
            this.dragHerePanel.Controls.Add(this.dropText);
            this.dragHerePanel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dragHerePanel.Location = new System.Drawing.Point(18, 55);
            this.dragHerePanel.Name = "dragHerePanel";
            this.dragHerePanel.Size = new System.Drawing.Size(509, 249);
            this.dragHerePanel.TabIndex = 3;
            this.dragHerePanel.Click += new System.EventHandler(this.dragHerePanel_Click);
            this.dragHerePanel.DragDrop += new System.Windows.Forms.DragEventHandler(this.dragHerePanel_DragDrop);
            this.dragHerePanel.DragEnter += new System.Windows.Forms.DragEventHandler(this.dragHerePanel_DragEnter);
            this.dragHerePanel.DragLeave += new System.EventHandler(this.dragHerePanel_DragLeave);
            this.dragHerePanel.MouseEnter += new System.EventHandler(this.dragHerePanel_MouseEnter);
            this.dragHerePanel.MouseLeave += new System.EventHandler(this.dragHerePanel_MouseLeave);
            // 
            // dropText
            // 
            this.dropText.AllowDrop = true;
            this.dropText.BackColor = System.Drawing.Color.Transparent;
            this.dropText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dropText.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dropText.Location = new System.Drawing.Point(0, 0);
            this.dropText.Name = "dropText";
            this.dropText.Size = new System.Drawing.Size(509, 249);
            this.dropText.TabIndex = 0;
            this.dropText.Text = "Click here to select file(s) or drag them here.";
            this.dropText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.dropText.Click += new System.EventHandler(this.dragHerePanel_Click);
            this.dropText.DragDrop += new System.Windows.Forms.DragEventHandler(this.dragHerePanel_DragDrop);
            this.dropText.DragEnter += new System.Windows.Forms.DragEventHandler(this.dragHerePanel_DragEnter);
            this.dropText.DragLeave += new System.EventHandler(this.dragHerePanel_DragLeave);
            this.dropText.MouseEnter += new System.EventHandler(this.dragHerePanel_MouseEnter);
            this.dropText.MouseLeave += new System.EventHandler(this.dragHerePanel_MouseLeave);
            // 
            // addMoreFilesBtn
            // 
            this.addMoreFilesBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.addMoreFilesBtn.Location = new System.Drawing.Point(3, 208);
            this.addMoreFilesBtn.Name = "addMoreFilesBtn";
            this.addMoreFilesBtn.Size = new System.Drawing.Size(121, 38);
            this.addMoreFilesBtn.TabIndex = 4;
            this.addMoreFilesBtn.Text = "Add more files";
            this.addMoreFilesBtn.UseVisualStyleBackColor = true;
            this.addMoreFilesBtn.Click += new System.EventHandler(this.addMoreFilesBtn_Click);
            // 
            // clearListBtn
            // 
            this.clearListBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clearListBtn.Location = new System.Drawing.Point(384, 208);
            this.clearListBtn.Name = "clearListBtn";
            this.clearListBtn.Size = new System.Drawing.Size(122, 38);
            this.clearListBtn.TabIndex = 3;
            this.clearListBtn.Text = "Clear List";
            this.clearListBtn.UseVisualStyleBackColor = true;
            this.clearListBtn.Click += new System.EventHandler(this.clearListBtn_Click);
            // 
            // listView1
            // 
            this.listView1.AllowDrop = true;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.tableLayoutPanel1.SetColumnSpan(this.listView1, 3);
            this.listView1.ContextMenuStrip = this.homeListContextMenuStrip;
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listView1.Location = new System.Drawing.Point(3, 3);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(503, 199);
            this.listView1.TabIndex = 4;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.DragDrop += new System.Windows.Forms.DragEventHandler(this.dragHerePanel_DragDrop);
            this.listView1.DragEnter += new System.Windows.Forms.DragEventHandler(this.listView1_DragEnter);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "a";
            this.columnHeader1.Width = 550;
            // 
            // homeListContextMenuStrip
            // 
            this.homeListContextMenuStrip.DropShadowEnabled = false;
            this.homeListContextMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.homeListContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeToolStripMenuItem,
            this.addMoreItemsToolStripMenuItem});
            this.homeListContextMenuStrip.Name = "homeListContextMenuStrip";
            this.homeListContextMenuStrip.ShowImageMargin = false;
            this.homeListContextMenuStrip.Size = new System.Drawing.Size(144, 48);
            this.homeListContextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.homeListContextMenuStrip_Opening);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.removeToolStripMenuItem.Text = "Remove";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
            // 
            // addMoreItemsToolStripMenuItem
            // 
            this.addMoreItemsToolStripMenuItem.Name = "addMoreItemsToolStripMenuItem";
            this.addMoreItemsToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.addMoreItemsToolStripMenuItem.Text = "Add more items...";
            this.addMoreItemsToolStripMenuItem.Click += new System.EventHandler(this.addMoreItemsToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.AddExtension = false;
            this.openFileDialog1.DefaultExt = "zip";
            this.openFileDialog1.Filter = "RAR files (*.rar)|*.rar|ZIP files (*.zip)|*.zip|7z files (*.7z)|*.7z|7z part file" +
    " base(*.001)|*.001|All files (*.*)|*.*";
            this.openFileDialog1.Multiselect = true;
            this.openFileDialog1.SupportMultiDottedExtensions = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.extractBtn, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.clearListBtn, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.addMoreFilesBtn, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.listView1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(18, 55);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(509, 249);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // Home
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.dragHerePanel);
            this.Controls.Add(this.titleLbl);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Home";
            this.Size = new System.Drawing.Size(542, 344);
            this.Load += new System.EventHandler(this.homePage_Load);
            this.dragHerePanel.ResumeLayout(false);
            this.homeListContextMenuStrip.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label titleLbl;
        private System.Windows.Forms.Button extractBtn;
        private System.Windows.Forms.Panel dragHerePanel;
        private System.Windows.Forms.Label dropText;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        internal System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ContextMenuStrip homeListContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addMoreItemsToolStripMenuItem;
        private System.Windows.Forms.Button addMoreFilesBtn;
        private System.Windows.Forms.Button clearListBtn;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}
