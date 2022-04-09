﻿
namespace ArchiveCacheManager
{
    partial class ArchiveListWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ArchiveListWindow));
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.archiveNameLabel = new System.Windows.Forms.Label();
            this.emulatorComboBox = new System.Windows.Forms.ComboBox();
            this.emulatorComboBoxLabel = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.fastObjectListView1 = new BrightIdeasSoftware.FastObjectListView();
            this.titleColumnF = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.sizeColumnF = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.tag1ColumnF = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.tag2ColumnF = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.tag3ColumnF = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.tag4ColumnF = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.tag5ColumnF = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.tag6ColumnF = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.tag7ColumnF = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.tag8ColumnF = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.tag9ColumnF = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MenuItem_showTags = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_hideTags = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuItem_labelFilterText = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_textBoxFilter = new System.Windows.Forms.ToolStripTextBox();
            this.MenuItem_filterFrench = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_filterEnglish = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_filterRH = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_clearFilters = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuItem_saveCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_loadSaveState0 = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_loadSaveState1 = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_loadSaveState2 = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_loadSaveState3 = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_loadSaveState4 = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_loadSaveState5 = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_loadSaveState6 = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_loadSaveState7 = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_loadSaveState8 = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_loadSaveState9 = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_pasteCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_pasteSaveState0 = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_pasteSaveState1 = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_pasteSaveState2 = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_pasteSaveState3 = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_pasteSaveState4 = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_pasteSaveState5 = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_pasteSaveState6 = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_pasteSaveState7 = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_pasteSaveState8 = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_pasteSaveState9 = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.fastObjectListView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Image = global::ArchiveCacheManager.Resources.cross_script;
            this.cancelButton.Location = new System.Drawing.Point(93, 418);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cancelButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Image = global::ArchiveCacheManager.Resources.tick;
            this.okButton.Location = new System.Drawing.Point(12, 418);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 1;
            this.okButton.Text = "Play!";
            this.okButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.okButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // archiveNameLabel
            // 
            this.archiveNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.archiveNameLabel.Location = new System.Drawing.Point(9, 9);
            this.archiveNameLabel.Name = "archiveNameLabel";
            this.archiveNameLabel.Size = new System.Drawing.Size(522, 21);
            this.archiveNameLabel.TabIndex = 4;
            this.archiveNameLabel.Text = "Game.zip";
            this.archiveNameLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.archiveNameLabel.Click += new System.EventHandler(this.archiveNameLabel_Click);
            // 
            // emulatorComboBox
            // 
            this.emulatorComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.emulatorComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.emulatorComboBox.FormattingEnabled = true;
            this.emulatorComboBox.Location = new System.Drawing.Point(451, 418);
            this.emulatorComboBox.Name = "emulatorComboBox";
            this.emulatorComboBox.Size = new System.Drawing.Size(228, 21);
            this.emulatorComboBox.TabIndex = 5;
            this.emulatorComboBox.SelectedIndexChanged += new System.EventHandler(this.emulatorComboBox_SelectedIndexChanged);
            // 
            // emulatorComboBoxLabel
            // 
            this.emulatorComboBoxLabel.AutoSize = true;
            this.emulatorComboBoxLabel.Location = new System.Drawing.Point(394, 423);
            this.emulatorComboBoxLabel.Name = "emulatorComboBoxLabel";
            this.emulatorComboBoxLabel.Size = new System.Drawing.Size(51, 13);
            this.emulatorComboBoxLabel.TabIndex = 6;
            this.emulatorComboBoxLabel.Text = "Emulator:";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "star_blue");
            this.imageList1.Images.SetKeyName(1, "star_yellow");
            // 
            // fastObjectListView1
            // 
            this.fastObjectListView1.Activation = System.Windows.Forms.ItemActivation.TwoClick;
            this.fastObjectListView1.AllColumns.Add(this.titleColumnF);
            this.fastObjectListView1.AllColumns.Add(this.sizeColumnF);
            this.fastObjectListView1.AllColumns.Add(this.tag1ColumnF);
            this.fastObjectListView1.AllColumns.Add(this.tag2ColumnF);
            this.fastObjectListView1.AllColumns.Add(this.tag3ColumnF);
            this.fastObjectListView1.AllColumns.Add(this.tag4ColumnF);
            this.fastObjectListView1.AllColumns.Add(this.tag5ColumnF);
            this.fastObjectListView1.AllColumns.Add(this.tag6ColumnF);
            this.fastObjectListView1.AllColumns.Add(this.tag7ColumnF);
            this.fastObjectListView1.AllColumns.Add(this.tag8ColumnF);
            this.fastObjectListView1.AllColumns.Add(this.tag9ColumnF);
            this.fastObjectListView1.CellEditUseWholeCell = false;
            this.fastObjectListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.titleColumnF,
            this.sizeColumnF,
            this.tag1ColumnF,
            this.tag2ColumnF,
            this.tag3ColumnF,
            this.tag4ColumnF,
            this.tag5ColumnF,
            this.tag6ColumnF,
            this.tag7ColumnF,
            this.tag8ColumnF,
            this.tag9ColumnF});
            this.fastObjectListView1.ContextMenuStrip = this.contextMenuStrip1;
            this.fastObjectListView1.Cursor = System.Windows.Forms.Cursors.Default;
            this.fastObjectListView1.FullRowSelect = true;
            this.fastObjectListView1.HideSelection = false;
            this.fastObjectListView1.Location = new System.Drawing.Point(12, 33);
            this.fastObjectListView1.Name = "fastObjectListView1";
            this.fastObjectListView1.ShowGroups = false;
            this.fastObjectListView1.Size = new System.Drawing.Size(667, 372);
            this.fastObjectListView1.SmallImageList = this.imageList1;
            this.fastObjectListView1.TabIndex = 0;
            this.fastObjectListView1.UseCompatibleStateImageBehavior = false;
            this.fastObjectListView1.UseFilterIndicator = true;
            this.fastObjectListView1.UseFiltering = true;
            this.fastObjectListView1.View = System.Windows.Forms.View.Details;
            this.fastObjectListView1.VirtualMode = true;
            this.fastObjectListView1.SelectedIndexChanged += new System.EventHandler(this.fastObjectListView1_SelectedIndexChanged);
            // 
            // titleColumnF
            // 
            this.titleColumnF.AspectName = "Title";
            this.titleColumnF.MinimumWidth = 200;
            this.titleColumnF.Text = "Title";
            this.titleColumnF.Width = 590;
            // 
            // sizeColumnF
            // 
            this.sizeColumnF.AspectName = "SizeInBytes";
            this.sizeColumnF.FillsFreeSpace = true;
            this.sizeColumnF.MinimumWidth = 50;
            this.sizeColumnF.Text = "Size";
            this.sizeColumnF.Width = 80;
            // 
            // tag1ColumnF
            // 
            this.tag1ColumnF.AspectName = "Tag1";
            this.tag1ColumnF.Text = "Region";
            // 
            // tag2ColumnF
            // 
            this.tag2ColumnF.AspectName = "Tag2";
            this.tag2ColumnF.Text = "Collection";
            // 
            // tag3ColumnF
            // 
            this.tag3ColumnF.AspectName = "Tag3";
            this.tag3ColumnF.Text = "Hack & Trad";
            this.tag3ColumnF.Width = 120;
            // 
            // tag4ColumnF
            // 
            this.tag4ColumnF.AspectName = "Tag4";
            this.tag4ColumnF.Text = "Category";
            this.tag4ColumnF.Width = 80;
            // 
            // tag5ColumnF
            // 
            this.tag5ColumnF.AspectName = "Tag5";
            this.tag5ColumnF.Text = "Small tags";
            // 
            // tag6ColumnF
            // 
            this.tag6ColumnF.AspectName = "Tag6";
            this.tag6ColumnF.Text = "Other tag 1";
            this.tag6ColumnF.Width = 25;
            // 
            // tag7ColumnF
            // 
            this.tag7ColumnF.AspectName = "Tag7";
            this.tag7ColumnF.Text = "Other tag 2";
            this.tag7ColumnF.Width = 25;
            // 
            // tag8ColumnF
            // 
            this.tag8ColumnF.AspectName = "Tag8";
            this.tag8ColumnF.Text = "Other tag 3";
            // 
            // tag9ColumnF
            // 
            this.tag9ColumnF.AspectName = "Tag9";
            this.tag9ColumnF.Text = "Other tag 4";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem_showTags,
            this.MenuItem_hideTags,
            this.toolStripSeparator1,
            this.MenuItem_labelFilterText,
            this.MenuItem_textBoxFilter,
            this.MenuItem_filterFrench,
            this.MenuItem_filterEnglish,
            this.MenuItem_filterRH,
            this.MenuItem_clearFilters,
            this.toolStripSeparator2,
            this.MenuItem_saveCopy,
            this.MenuItem_pasteCopy});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(184, 261);
            // 
            // MenuItem_showTags
            // 
            this.MenuItem_showTags.Name = "MenuItem_showTags";
            this.MenuItem_showTags.Size = new System.Drawing.Size(183, 22);
            this.MenuItem_showTags.Text = "Show Tags";
            this.MenuItem_showTags.Click += new System.EventHandler(this.MenuItem_showTags_Click);
            // 
            // MenuItem_hideTags
            // 
            this.MenuItem_hideTags.Name = "MenuItem_hideTags";
            this.MenuItem_hideTags.Size = new System.Drawing.Size(183, 22);
            this.MenuItem_hideTags.Text = "Hide Tags";
            this.MenuItem_hideTags.Click += new System.EventHandler(this.MenuItem_hideTags_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(180, 6);
            // 
            // MenuItem_labelFilterText
            // 
            this.MenuItem_labelFilterText.Enabled = false;
            this.MenuItem_labelFilterText.Name = "MenuItem_labelFilterText";
            this.MenuItem_labelFilterText.Size = new System.Drawing.Size(183, 22);
            this.MenuItem_labelFilterText.Text = "↓↓↓Filter Text ↓↓↓";
            // 
            // MenuItem_textBoxFilter
            // 
            this.MenuItem_textBoxFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MenuItem_textBoxFilter.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MenuItem_textBoxFilter.Name = "MenuItem_textBoxFilter";
            this.MenuItem_textBoxFilter.Size = new System.Drawing.Size(100, 23);
            this.MenuItem_textBoxFilter.Click += new System.EventHandler(this.MenuItem_textBoxFilter_Click);
            // 
            // MenuItem_filterFrench
            // 
            this.MenuItem_filterFrench.Name = "MenuItem_filterFrench";
            this.MenuItem_filterFrench.Size = new System.Drawing.Size(183, 22);
            this.MenuItem_filterFrench.Text = "Filter French";
            this.MenuItem_filterFrench.Visible = false;
            this.MenuItem_filterFrench.Click += new System.EventHandler(this.MenuItem_filterFrench_Click);
            // 
            // MenuItem_filterEnglish
            // 
            this.MenuItem_filterEnglish.Name = "MenuItem_filterEnglish";
            this.MenuItem_filterEnglish.Size = new System.Drawing.Size(183, 22);
            this.MenuItem_filterEnglish.Text = "Filter Eng Trad";
            this.MenuItem_filterEnglish.Visible = false;
            this.MenuItem_filterEnglish.Click += new System.EventHandler(this.MenuItem_filterEnglish_Click);
            // 
            // MenuItem_filterRH
            // 
            this.MenuItem_filterRH.Name = "MenuItem_filterRH";
            this.MenuItem_filterRH.Size = new System.Drawing.Size(183, 22);
            this.MenuItem_filterRH.Text = "Filter Romhacker.net";
            this.MenuItem_filterRH.Visible = false;
            this.MenuItem_filterRH.Click += new System.EventHandler(this.MenuItem_filterRH_Click);
            // 
            // MenuItem_clearFilters
            // 
            this.MenuItem_clearFilters.Enabled = false;
            this.MenuItem_clearFilters.Name = "MenuItem_clearFilters";
            this.MenuItem_clearFilters.Size = new System.Drawing.Size(183, 22);
            this.MenuItem_clearFilters.Text = "Clear Filters !";
            this.MenuItem_clearFilters.Click += new System.EventHandler(this.MenuItem_clearFilters_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(180, 6);
            // 
            // MenuItem_saveCopy
            // 
            this.MenuItem_saveCopy.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem_loadSaveState0,
            this.MenuItem_loadSaveState1,
            this.MenuItem_loadSaveState2,
            this.MenuItem_loadSaveState3,
            this.MenuItem_loadSaveState4,
            this.MenuItem_loadSaveState5,
            this.MenuItem_loadSaveState6,
            this.MenuItem_loadSaveState7,
            this.MenuItem_loadSaveState8,
            this.MenuItem_loadSaveState9});
            this.MenuItem_saveCopy.Name = "MenuItem_saveCopy";
            this.MenuItem_saveCopy.Size = new System.Drawing.Size(183, 22);
            this.MenuItem_saveCopy.Text = "Copy SaveState";
            this.MenuItem_saveCopy.Click += new System.EventHandler(this.LoadSaveStateToolStripMenuItem_Click);
            // 
            // MenuItem_loadSaveState0
            // 
            this.MenuItem_loadSaveState0.Name = "MenuItem_loadSaveState0";
            this.MenuItem_loadSaveState0.Size = new System.Drawing.Size(180, 22);
            this.MenuItem_loadSaveState0.Text = "Slot 0";
            this.MenuItem_loadSaveState0.Click += new System.EventHandler(this.MenuItem_loadSaveState_Click);
            // 
            // MenuItem_loadSaveState1
            // 
            this.MenuItem_loadSaveState1.Name = "MenuItem_loadSaveState1";
            this.MenuItem_loadSaveState1.Size = new System.Drawing.Size(180, 22);
            this.MenuItem_loadSaveState1.Text = "Slot 1";
            this.MenuItem_loadSaveState1.Click += new System.EventHandler(this.MenuItem_loadSaveState_Click);
            // 
            // MenuItem_loadSaveState2
            // 
            this.MenuItem_loadSaveState2.Name = "MenuItem_loadSaveState2";
            this.MenuItem_loadSaveState2.Size = new System.Drawing.Size(180, 22);
            this.MenuItem_loadSaveState2.Text = "Slot 2";
            this.MenuItem_loadSaveState2.Click += new System.EventHandler(this.MenuItem_loadSaveState_Click);
            // 
            // MenuItem_loadSaveState3
            // 
            this.MenuItem_loadSaveState3.Name = "MenuItem_loadSaveState3";
            this.MenuItem_loadSaveState3.Size = new System.Drawing.Size(180, 22);
            this.MenuItem_loadSaveState3.Text = "Slot 3";
            this.MenuItem_loadSaveState3.Click += new System.EventHandler(this.MenuItem_loadSaveState_Click);
            // 
            // MenuItem_loadSaveState4
            // 
            this.MenuItem_loadSaveState4.Name = "MenuItem_loadSaveState4";
            this.MenuItem_loadSaveState4.Size = new System.Drawing.Size(180, 22);
            this.MenuItem_loadSaveState4.Text = "Slot 4";
            this.MenuItem_loadSaveState4.Click += new System.EventHandler(this.MenuItem_loadSaveState_Click);
            // 
            // MenuItem_loadSaveState5
            // 
            this.MenuItem_loadSaveState5.Name = "MenuItem_loadSaveState5";
            this.MenuItem_loadSaveState5.Size = new System.Drawing.Size(180, 22);
            this.MenuItem_loadSaveState5.Text = "Slot 5";
            this.MenuItem_loadSaveState5.Click += new System.EventHandler(this.MenuItem_loadSaveState_Click);
            // 
            // MenuItem_loadSaveState6
            // 
            this.MenuItem_loadSaveState6.Name = "MenuItem_loadSaveState6";
            this.MenuItem_loadSaveState6.Size = new System.Drawing.Size(180, 22);
            this.MenuItem_loadSaveState6.Text = "Slot 6";
            this.MenuItem_loadSaveState6.Click += new System.EventHandler(this.MenuItem_loadSaveState_Click);
            // 
            // MenuItem_loadSaveState7
            // 
            this.MenuItem_loadSaveState7.Name = "MenuItem_loadSaveState7";
            this.MenuItem_loadSaveState7.Size = new System.Drawing.Size(180, 22);
            this.MenuItem_loadSaveState7.Text = "Slot 7";
            this.MenuItem_loadSaveState7.Click += new System.EventHandler(this.MenuItem_loadSaveState_Click);
            // 
            // MenuItem_loadSaveState8
            // 
            this.MenuItem_loadSaveState8.Name = "MenuItem_loadSaveState8";
            this.MenuItem_loadSaveState8.Size = new System.Drawing.Size(180, 22);
            this.MenuItem_loadSaveState8.Text = "Slot 8";
            this.MenuItem_loadSaveState8.Click += new System.EventHandler(this.MenuItem_loadSaveState_Click);
            // 
            // MenuItem_loadSaveState9
            // 
            this.MenuItem_loadSaveState9.Name = "MenuItem_loadSaveState9";
            this.MenuItem_loadSaveState9.Size = new System.Drawing.Size(180, 22);
            this.MenuItem_loadSaveState9.Text = "Slot 9";
            this.MenuItem_loadSaveState9.Click += new System.EventHandler(this.MenuItem_loadSaveState_Click);
            // 
            // MenuItem_pasteCopy
            // 
            this.MenuItem_pasteCopy.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem_pasteSaveState0,
            this.MenuItem_pasteSaveState1,
            this.MenuItem_pasteSaveState2,
            this.MenuItem_pasteSaveState3,
            this.MenuItem_pasteSaveState4,
            this.MenuItem_pasteSaveState5,
            this.MenuItem_pasteSaveState6,
            this.MenuItem_pasteSaveState7,
            this.MenuItem_pasteSaveState8,
            this.MenuItem_pasteSaveState9});
            this.MenuItem_pasteCopy.Name = "MenuItem_pasteCopy";
            this.MenuItem_pasteCopy.Size = new System.Drawing.Size(183, 22);
            this.MenuItem_pasteCopy.Text = "Paste SaveState";
            // 
            // MenuItem_pasteSaveState0
            // 
            this.MenuItem_pasteSaveState0.Name = "MenuItem_pasteSaveState0";
            this.MenuItem_pasteSaveState0.Size = new System.Drawing.Size(180, 22);
            this.MenuItem_pasteSaveState0.Text = "Slot 0";
            this.MenuItem_pasteSaveState0.Click += new System.EventHandler(this.MenuItem_pasteSaveState_Click);
            // 
            // MenuItem_pasteSaveState1
            // 
            this.MenuItem_pasteSaveState1.Name = "MenuItem_pasteSaveState1";
            this.MenuItem_pasteSaveState1.Size = new System.Drawing.Size(180, 22);
            this.MenuItem_pasteSaveState1.Text = "Slot 1";
            this.MenuItem_pasteSaveState1.Click += new System.EventHandler(this.MenuItem_pasteSaveState_Click);
            // 
            // MenuItem_pasteSaveState2
            // 
            this.MenuItem_pasteSaveState2.Name = "MenuItem_pasteSaveState2";
            this.MenuItem_pasteSaveState2.Size = new System.Drawing.Size(180, 22);
            this.MenuItem_pasteSaveState2.Text = "Slot 2";
            this.MenuItem_pasteSaveState2.Click += new System.EventHandler(this.MenuItem_pasteSaveState_Click);
            // 
            // MenuItem_pasteSaveState3
            // 
            this.MenuItem_pasteSaveState3.Name = "MenuItem_pasteSaveState3";
            this.MenuItem_pasteSaveState3.Size = new System.Drawing.Size(180, 22);
            this.MenuItem_pasteSaveState3.Text = "Slot 3";
            this.MenuItem_pasteSaveState3.Click += new System.EventHandler(this.MenuItem_pasteSaveState_Click);
            // 
            // MenuItem_pasteSaveState4
            // 
            this.MenuItem_pasteSaveState4.Name = "MenuItem_pasteSaveState4";
            this.MenuItem_pasteSaveState4.Size = new System.Drawing.Size(180, 22);
            this.MenuItem_pasteSaveState4.Text = "Slot 4";
            this.MenuItem_pasteSaveState4.Click += new System.EventHandler(this.MenuItem_pasteSaveState_Click);
            // 
            // MenuItem_pasteSaveState5
            // 
            this.MenuItem_pasteSaveState5.Name = "MenuItem_pasteSaveState5";
            this.MenuItem_pasteSaveState5.Size = new System.Drawing.Size(180, 22);
            this.MenuItem_pasteSaveState5.Text = "Slot 5";
            this.MenuItem_pasteSaveState5.Click += new System.EventHandler(this.MenuItem_pasteSaveState_Click);
            // 
            // MenuItem_pasteSaveState6
            // 
            this.MenuItem_pasteSaveState6.Name = "MenuItem_pasteSaveState6";
            this.MenuItem_pasteSaveState6.Size = new System.Drawing.Size(180, 22);
            this.MenuItem_pasteSaveState6.Text = "Slot 6";
            this.MenuItem_pasteSaveState6.Click += new System.EventHandler(this.MenuItem_pasteSaveState_Click);
            // 
            // MenuItem_pasteSaveState7
            // 
            this.MenuItem_pasteSaveState7.Name = "MenuItem_pasteSaveState7";
            this.MenuItem_pasteSaveState7.Size = new System.Drawing.Size(180, 22);
            this.MenuItem_pasteSaveState7.Text = "Slot 7";
            this.MenuItem_pasteSaveState7.Click += new System.EventHandler(this.MenuItem_pasteSaveState_Click);
            // 
            // MenuItem_pasteSaveState8
            // 
            this.MenuItem_pasteSaveState8.Name = "MenuItem_pasteSaveState8";
            this.MenuItem_pasteSaveState8.Size = new System.Drawing.Size(180, 22);
            this.MenuItem_pasteSaveState8.Text = "Slot 8";
            this.MenuItem_pasteSaveState8.Click += new System.EventHandler(this.MenuItem_pasteSaveState_Click);
            // 
            // MenuItem_pasteSaveState9
            // 
            this.MenuItem_pasteSaveState9.Name = "MenuItem_pasteSaveState9";
            this.MenuItem_pasteSaveState9.Size = new System.Drawing.Size(180, 22);
            this.MenuItem_pasteSaveState9.Text = "Slot 9";
            this.MenuItem_pasteSaveState9.Click += new System.EventHandler(this.MenuItem_pasteSaveState_Click);
            // 
            // ArchiveListWindow
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(692, 453);
            this.Controls.Add(this.fastObjectListView1);
            this.Controls.Add(this.emulatorComboBoxLabel);
            this.Controls.Add(this.emulatorComboBox);
            this.Controls.Add(this.archiveNameLabel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ArchiveListWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Select File";
            this.Load += new System.EventHandler(this.ArchiveListWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fastObjectListView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.contextMenuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Label archiveNameLabel;
        private System.Windows.Forms.ComboBox emulatorComboBox;
        private System.Windows.Forms.Label emulatorComboBoxLabel;
        private System.Windows.Forms.ImageList imageList1;
        private BrightIdeasSoftware.FastObjectListView fastObjectListView1;
        private BrightIdeasSoftware.OLVColumn titleColumnF;
        private BrightIdeasSoftware.OLVColumn sizeColumnF;
        private BrightIdeasSoftware.OLVColumn tag1ColumnF;
        private BrightIdeasSoftware.OLVColumn tag2ColumnF;
        private BrightIdeasSoftware.OLVColumn tag3ColumnF;
        private BrightIdeasSoftware.OLVColumn tag4ColumnF;
        private BrightIdeasSoftware.OLVColumn tag5ColumnF;
        private BrightIdeasSoftware.OLVColumn tag6ColumnF;
        private BrightIdeasSoftware.OLVColumn tag7ColumnF;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_showTags;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_hideTags;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_labelFilterText;
        private System.Windows.Forms.ToolStripTextBox MenuItem_textBoxFilter;
        private BrightIdeasSoftware.OLVColumn tag8ColumnF;
        private BrightIdeasSoftware.OLVColumn tag9ColumnF;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_filterFrench;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_filterEnglish;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_filterRH;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_clearFilters;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_saveCopy;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_loadSaveState1;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_loadSaveState2;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_loadSaveState3;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_loadSaveState4;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_loadSaveState5;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_loadSaveState6;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_loadSaveState7;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_loadSaveState8;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_loadSaveState9;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_loadSaveState0;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_pasteCopy;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_pasteSaveState0;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_pasteSaveState1;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_pasteSaveState2;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_pasteSaveState3;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_pasteSaveState4;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_pasteSaveState5;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_pasteSaveState6;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_pasteSaveState7;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_pasteSaveState8;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_pasteSaveState9;
    }
}