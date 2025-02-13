﻿// This code is licensed under the Keep It Free License V1.
// You may find a full copy of this license at root project directory\LICENSE

using DAZ_Installer.DP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAZ_Installer
{
    public partial class MainForm : Form
    {
        public static Color initialSidePanelColor;
        public static Color darkerSidePanelColor = Color.FromArgb(50, Color.FromKnownColor(KnownColor.ForestGreen));
        public static MainForm activeForm;

        internal static UserControl[] userControls = new UserControl[4];
        internal static UserControl visiblePage = null;

        public MainForm()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            activeForm = this;
            InitalizePages();
        }

        private void InitalizePages()
        {
            visiblePage = homePage1;

            userControls[0] = homePage1;
            userControls[1] = extractControl1;
            userControls[2] = library1;
            userControls[3] = settings1;

            foreach (var control in userControls)
            {
                if (control == visiblePage) continue;
                control.Visible = false;
                control.Enabled = false;
            }
        }

        internal static void SwitchPage(UserControl switchTo)
        {
            if (switchTo == visiblePage) return;
            switchTo.BringToFront();
            switchTo.Enabled = true;
            switchTo.Visible = true;

            visiblePage.Enabled = false;
            visiblePage.Visible = false;

            visiblePage = switchTo;
        }

        public void SwitchToExtractPage()
        {
            extractControl1.BringToFront();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            initialSidePanelColor = tableLayoutPanel1.BackColor;
        }

        private void sidePanelButtonMouseEnter(object sender, EventArgs e)
        {
            Label button = (Label)sender;
            button.BackColor = darkerSidePanelColor;
        }

        private void sidePanelButtonMouseExit(object sender, EventArgs e)
        {
            Label button = (Label)sender;
            button.BackColor = initialSidePanelColor;
        }

        private void extractLbl_Click(object sender, EventArgs e)
        {
            SwitchPage(extractControl1);
        }

        private void homeLabel_Click(object sender, EventArgs e)
        {
            SwitchPage(homePage1);
        }

        private void libraryLbl_Click(object sender, EventArgs e)
        {

            if (library1 != visiblePage)
            {
                SwitchPage(library1);
                //library1.TryPageUpdate();
            }
        }

        private void settingsLbl_Click(object sender, EventArgs e)
        {
            SwitchPage(settings1);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DPGlobal.HandleAppClosing(e);
        }

        internal string? ShowMissingVolumePrompt(string msg, string filter, string ext, string? defaultLocation) {
            var result = MessageBox.Show(msg, "Missing volumes", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes) {
                return ShowFileDialog(filter, ext, defaultLocation);
            }
            return null;

        }

        public string? ShowFileDialog(string filter, string defaultExt, string defaultLocation = null)
        {
            if (InvokeRequired)
            {
                return (string) Invoke(ShowFileDialog,filter, defaultExt, defaultLocation);
            }
            openFileDialog.Filter = filter;
            openFileDialog.DefaultExt = defaultExt;
            if (defaultLocation != null)
            {
                openFileDialog.InitialDirectory = defaultLocation;
            }
            var result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                return openFileDialog.FileName;
            }
            return null;
        }


    }
}
