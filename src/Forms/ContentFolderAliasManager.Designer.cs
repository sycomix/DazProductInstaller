﻿namespace DAZ_Installer.Forms
{
    partial class ContentFolderAliasManager
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.addBtn = new System.Windows.Forms.Button();
            this.contentFoldersComboBox = new System.Windows.Forms.ComboBox();
            this.addAliasTxtBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.noteLbl = new System.Windows.Forms.Label();
            this.aliasListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetToSavedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Aliases:";
            // 
            // addBtn
            // 
            this.addBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addBtn.Location = new System.Drawing.Point(559, 12);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(69, 29);
            this.addBtn.TabIndex = 4;
            this.addBtn.Text = "Add";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // contentFoldersComboBox
            // 
            this.contentFoldersComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.contentFoldersComboBox.FormattingEnabled = true;
            this.contentFoldersComboBox.Location = new System.Drawing.Point(355, 13);
            this.contentFoldersComboBox.Name = "contentFoldersComboBox";
            this.contentFoldersComboBox.Size = new System.Drawing.Size(198, 28);
            this.contentFoldersComboBox.TabIndex = 5;
            // 
            // addAliasTxtBox
            // 
            this.addAliasTxtBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.addAliasTxtBox.Location = new System.Drawing.Point(94, 13);
            this.addAliasTxtBox.MaxLength = 240;
            this.addAliasTxtBox.Name = "addAliasTxtBox";
            this.addAliasTxtBox.Size = new System.Drawing.Size(226, 27);
            this.addAliasTxtBox.TabIndex = 6;
            this.addAliasTxtBox.WordWrap = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Add Alias:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(326, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "to";
            // 
            // noteLbl
            // 
            this.noteLbl.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.noteLbl.AutoSize = true;
            this.noteLbl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.noteLbl.Location = new System.Drawing.Point(35, 207);
            this.noteLbl.Name = "noteLbl";
            this.noteLbl.Size = new System.Drawing.Size(578, 20);
            this.noteLbl.TabIndex = 9;
            this.noteLbl.Text = "Note: You must apply changes in the Settings page in order to save your changes.";
            // 
            // aliasListView
            // 
            this.aliasListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.aliasListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.aliasListView.ContextMenuStrip = this.contextMenuStrip1;
            this.aliasListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.aliasListView.Location = new System.Drawing.Point(12, 76);
            this.aliasListView.Name = "aliasListView";
            this.aliasListView.Size = new System.Drawing.Size(616, 121);
            this.aliasListView.TabIndex = 10;
            this.aliasListView.UseCompatibleStateImageBehavior = false;
            this.aliasListView.View = System.Windows.Forms.View.Details;
            this.aliasListView.Resize += new System.EventHandler(this.aliasListView_Resize);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeToolStripMenuItem,
            this.resetToSavedToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(211, 80);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.removeToolStripMenuItem.Text = "Remove";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
            // 
            // resetToSavedToolStripMenuItem
            // 
            this.resetToSavedToolStripMenuItem.Name = "resetToSavedToolStripMenuItem";
            this.resetToSavedToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.resetToSavedToolStripMenuItem.Text = "Reset to saved";
            this.resetToSavedToolStripMenuItem.Click += new System.EventHandler(this.resetToSavedToolStripMenuItem_Click);
            // 
            // ContentFolderAliasManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 238);
            this.Controls.Add(this.aliasListView);
            this.Controls.Add(this.noteLbl);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.addAliasTxtBox);
            this.Controls.Add(this.contentFoldersComboBox);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.label1);
            this.MinimumSize = new System.Drawing.Size(660, 285);
            this.Name = "ContentFolderAliasManager";
            this.Text = "Content Folder Alias Manager";
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.ComboBox contentFoldersComboBox;
        private System.Windows.Forms.TextBox addAliasTxtBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label noteLbl;
        private System.Windows.Forms.ListView aliasListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetToSavedToolStripMenuItem;
    }
}