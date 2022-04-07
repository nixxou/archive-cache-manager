
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
            ((System.ComponentModel.ISupportInitialize)(this.fastObjectListView1)).BeginInit();
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
            this.tag7ColumnF});
            this.fastObjectListView1.FullRowSelect = true;
            this.fastObjectListView1.HideSelection = false;
            this.fastObjectListView1.Location = new System.Drawing.Point(12, 33);
            this.fastObjectListView1.Name = "fastObjectListView1";
            this.fastObjectListView1.ShowGroups = false;
            this.fastObjectListView1.Size = new System.Drawing.Size(667, 372);
            this.fastObjectListView1.SmallImageList = this.imageList1;
            this.fastObjectListView1.TabIndex = 7;
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
            this.sizeColumnF.MinimumWidth = 50;
            this.sizeColumnF.Text = "Size";
            this.sizeColumnF.Width = 80;
            // 
            // tag1ColumnF
            // 
            this.tag1ColumnF.AspectName = "Tag1";
            this.tag1ColumnF.Text = "Tag1";
            this.tag1ColumnF.Width = 25;
            // 
            // tag2ColumnF
            // 
            this.tag2ColumnF.AspectName = "Tag2";
            this.tag2ColumnF.Text = "Tag2";
            this.tag2ColumnF.Width = 25;
            // 
            // tag3ColumnF
            // 
            this.tag3ColumnF.AspectName = "Tag3";
            this.tag3ColumnF.Text = "Tag3";
            this.tag3ColumnF.Width = 25;
            // 
            // tag4ColumnF
            // 
            this.tag4ColumnF.AspectName = "Tag4";
            this.tag4ColumnF.Text = "Tag4";
            this.tag4ColumnF.Width = 25;
            // 
            // tag5ColumnF
            // 
            this.tag5ColumnF.AspectName = "Tag5";
            this.tag5ColumnF.Text = "Tag5";
            this.tag5ColumnF.Width = 25;
            // 
            // tag6ColumnF
            // 
            this.tag6ColumnF.AspectName = "Tag6";
            this.tag6ColumnF.Text = "Tag6";
            this.tag6ColumnF.Width = 25;
            // 
            // tag7ColumnF
            // 
            this.tag7ColumnF.AspectName = "Tag7";
            this.tag7ColumnF.Text = "Tag7";
            this.tag7ColumnF.Width = 25;
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
    }
}