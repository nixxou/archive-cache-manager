
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
            this.fileListBox = new System.Windows.Forms.ListBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.archiveNameLabel = new System.Windows.Forms.Label();
            this.emulatorComboBox = new System.Windows.Forms.ComboBox();
            this.emulatorComboBoxLabel = new System.Windows.Forms.Label();
            this.objectListView1 = new BrightIdeasSoftware.ObjectListView();
            this.titleColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.sizeColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.tagsColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.objectListView1)).BeginInit();
            this.SuspendLayout();
            // 
            // fileListBox
            // 
            this.fileListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileListBox.FormattingEnabled = true;
            this.fileListBox.ItemHeight = 16;
            this.fileListBox.Location = new System.Drawing.Point(12, 31);
            this.fileListBox.Name = "fileListBox";
            this.fileListBox.Size = new System.Drawing.Size(519, 372);
            this.fileListBox.TabIndex = 0;
            this.fileListBox.SelectedIndexChanged += new System.EventHandler(this.fileListBox_SelectedIndexChanged);
            this.fileListBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.fileListBox_MouseDoubleClick);
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
            this.emulatorComboBox.Location = new System.Drawing.Point(303, 418);
            this.emulatorComboBox.Name = "emulatorComboBox";
            this.emulatorComboBox.Size = new System.Drawing.Size(228, 21);
            this.emulatorComboBox.TabIndex = 5;
            // 
            // emulatorComboBoxLabel
            // 
            this.emulatorComboBoxLabel.AutoSize = true;
            this.emulatorComboBoxLabel.Location = new System.Drawing.Point(246, 421);
            this.emulatorComboBoxLabel.Name = "emulatorComboBoxLabel";
            this.emulatorComboBoxLabel.Size = new System.Drawing.Size(51, 13);
            this.emulatorComboBoxLabel.TabIndex = 6;
            this.emulatorComboBoxLabel.Text = "Emulator:";
            // 
            // objectListView1
            // 
            this.objectListView1.AllColumns.Add(this.titleColumn);
            this.objectListView1.AllColumns.Add(this.sizeColumn);
            this.objectListView1.AllColumns.Add(this.tagsColumn);
            this.objectListView1.CellEditUseWholeCell = false;
            this.objectListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.titleColumn,
            this.sizeColumn,
            this.tagsColumn});
            this.objectListView1.Cursor = System.Windows.Forms.Cursors.Default;
            this.objectListView1.HideSelection = false;
            this.objectListView1.Location = new System.Drawing.Point(547, 31);
            this.objectListView1.Name = "objectListView1";
            this.objectListView1.ShowGroups = false;
            this.objectListView1.Size = new System.Drawing.Size(672, 372);
            this.objectListView1.SmallImageList = this.imageList1;
            this.objectListView1.TabIndex = 0;
            this.objectListView1.UseCompatibleStateImageBehavior = false;
            this.objectListView1.View = System.Windows.Forms.View.Details;
            this.objectListView1.SelectedIndexChanged += new System.EventHandler(this.objectListView1_SelectedIndexChanged);
            // 
            // titleColumn
            // 
            this.titleColumn.AspectName = "Title";
            this.titleColumn.Text = "Title";
            this.titleColumn.Width = 525;
            // 
            // sizeColumn
            // 
            this.sizeColumn.AspectName = "SizeInBytes";
            this.sizeColumn.AspectToStringFormat = "";
            this.sizeColumn.Text = "Size";
            this.sizeColumn.Width = 77;
            // 
            // tagsColumn
            // 
            this.tagsColumn.AspectName = "Tags";
            this.tagsColumn.AspectToStringFormat = "";
            this.tagsColumn.Text = "Tags";
            this.tagsColumn.Width = 199;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "star_blue");
            this.imageList1.Images.SetKeyName(1, "star_yellow");
            // 
            // ArchiveListWindow
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(1231, 453);
            this.Controls.Add(this.objectListView1);
            this.Controls.Add(this.emulatorComboBoxLabel);
            this.Controls.Add(this.emulatorComboBox);
            this.Controls.Add(this.archiveNameLabel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.fileListBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ArchiveListWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Select File";
            this.Load += new System.EventHandler(this.ArchiveListWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.objectListView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox fileListBox;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Label archiveNameLabel;
        private System.Windows.Forms.ComboBox emulatorComboBox;
        private System.Windows.Forms.Label emulatorComboBoxLabel;
        private BrightIdeasSoftware.ObjectListView objectListView1;
        private BrightIdeasSoftware.OLVColumn titleColumn;
        private BrightIdeasSoftware.OLVColumn sizeColumn;
        private BrightIdeasSoftware.OLVColumn tagsColumn;
        private System.Windows.Forms.ImageList imageList1;
    }
}