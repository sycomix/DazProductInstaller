﻿namespace DAZ_Installer.Forms
{
    partial class DatabaseView
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
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.dataGrid = new System.Windows.Forms.DataGridView();
            this.tableLbl = new System.Windows.Forms.Label();
            this.tableNames = new System.Windows.Forms.ComboBox();
            this.changeTableBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGrid
            // 
            this.dataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid.Location = new System.Drawing.Point(0, 37);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.ReadOnly = true;
            this.dataGrid.RowHeadersWidth = 51;
            this.dataGrid.RowTemplate.Height = 29;
            this.dataGrid.Size = new System.Drawing.Size(800, 413);
            this.dataGrid.TabIndex = 0;
            // 
            // tableLbl
            // 
            this.tableLbl.Location = new System.Drawing.Point(0, 6);
            this.tableLbl.Name = "tableLbl";
            this.tableLbl.Size = new System.Drawing.Size(60, 25);
            this.tableLbl.TabIndex = 0;
            this.tableLbl.Text = "Table: ";
            this.tableLbl.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tableNames
            // 
            this.tableNames.FormattingEnabled = true;
            this.tableNames.Location = new System.Drawing.Point(66, 3);
            this.tableNames.Name = "tableNames";
            this.tableNames.Size = new System.Drawing.Size(550, 28);
            this.tableNames.TabIndex = 1;
            // 
            // changeTableBtn
            // 
            this.changeTableBtn.Location = new System.Drawing.Point(622, 3);
            this.changeTableBtn.Name = "changeTableBtn";
            this.changeTableBtn.Size = new System.Drawing.Size(166, 28);
            this.changeTableBtn.TabIndex = 2;
            this.changeTableBtn.Text = "Change Table";
            this.changeTableBtn.UseVisualStyleBackColor = true;
            this.changeTableBtn.Click += new System.EventHandler(this.changeTableBtn_Click);
            // 
            // DatabaseView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.changeTableBtn);
            this.Controls.Add(this.tableLbl);
            this.Controls.Add(this.tableNames);
            this.Controls.Add(this.dataGrid);
            this.Name = "DatabaseView";
            this.Text = "Database Viewer";
            this.Load += new System.EventHandler(this.DatabaseView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGrid;
        internal System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Label tableLbl;
        private System.Windows.Forms.ComboBox tableNames;
        private System.Windows.Forms.Button changeTableBtn;
    }
}