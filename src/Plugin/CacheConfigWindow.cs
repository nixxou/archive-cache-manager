﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArchiveCacheManager
{
    public partial class CacheConfigWindow : Form
    {
        public CacheConfigWindow()
        {
            InitializeComponent();

            cachePath.Text = Config.CachePath;
            cacheSize.Value = Config.CacheSize;
            minArchiveSize.Value = Config.MinArchiveSize;

            updateEnabledState();
        }

        private void updateEnabledState()
        {
            okButton.Enabled = (cachePath.Text != string.Empty);
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            // TODO
            // More checks for forbidden directories - c:\, c:\windows, c:\program files, etc
            if (PathUtils.ComparePaths(cachePath.Text, PathUtils.GetLaunchBoxRootPath()) ||
                PathUtils.ComparePaths(cachePath.Text, @"C:\") ||
                PathUtils.ComparePaths(cachePath.Text, @"C:\Windows") ||
                PathUtils.ComparePaths(cachePath.Text, @"C:\Program Files") ||
                PathUtils.ComparePaths(cachePath.Text, @"C:\Program Files (x86)"))
            {
                MessageBox.Show(this, string.Format("ERROR! The cache path can not be set to {0}.\r\nPlease change the cache path.", Path.GetFullPath(cachePath.Text)), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            try
            {
                if (!PathUtils.ComparePaths(cachePath.Text, Config.CachePath) &&
                    (Directory.EnumerateFiles(cachePath.Text, "*", SearchOption.AllDirectories).Any() || Directory.EnumerateDirectories(cachePath.Text).Any()))
                {
                    DialogResult result = MessageBox.Show(this, "WARNING! The selected cache path already contains files. These files WILL be deleted when the cache is cleaned. Continue?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.No)
                    {
                        return;
                    }
                }
            }
            catch (DirectoryNotFoundException)
            {
            }

            Config.CachePath = cachePath.Text;
            Config.CacheSize = Convert.ToInt64(cacheSize.Value);
            Config.MinArchiveSize = Convert.ToInt64(minArchiveSize.Value);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cachePath_TextChanged(object sender, EventArgs e)
        {
            updateEnabledState();
        }

        private void cachePathBrowseButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            string browsePath = PathUtils.CachePath(cachePath.Text);

            dialog.SelectedPath = Directory.Exists(browsePath) ? browsePath : PathUtils.GetLaunchBoxRootPath();
            dialog.ShowNewFolderButton = true;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                cachePath.Text = PathUtils.GetRelativePath(PathUtils.GetLaunchBoxRootPath(), dialog.SelectedPath);
            }

            updateEnabledState();
        }
    }
}
