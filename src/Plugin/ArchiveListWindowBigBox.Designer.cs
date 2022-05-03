
namespace ArchiveCacheManager
{
    partial class ArchiveListWindowBigBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ArchiveListWindowBigBox));
            this.fileListBox = new System.Windows.Forms.ListBox();
            this.archiveNameLabel = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.fakebrowser_txt = new System.Windows.Forms.TextBox();
            this.Texture_Label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // fileListBox
            // 
            this.fileListBox.BackColor = System.Drawing.Color.Black;
            this.fileListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.fileListBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.fileListBox.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileListBox.ForeColor = System.Drawing.Color.White;
            this.fileListBox.FormattingEnabled = true;
            this.fileListBox.IntegralHeight = false;
            this.fileListBox.ItemHeight = 44;
            this.fileListBox.Location = new System.Drawing.Point(3, 65);
            this.fileListBox.Margin = new System.Windows.Forms.Padding(0);
            this.fileListBox.Name = "fileListBox";
            this.fileListBox.Size = new System.Drawing.Size(794, 542);
            this.fileListBox.TabIndex = 0;
            this.fileListBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.FileListBox_DrawItem);
            this.fileListBox.SelectedIndexChanged += new System.EventHandler(this.fileListBox_SelectedIndexChanged);
            this.fileListBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.fileListBox_MouseDoubleClick);
            // 
            // archiveNameLabel
            // 
            this.archiveNameLabel.BackColor = System.Drawing.Color.Black;
            this.archiveNameLabel.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.archiveNameLabel.ForeColor = System.Drawing.Color.White;
            this.archiveNameLabel.Location = new System.Drawing.Point(3, 3);
            this.archiveNameLabel.Margin = new System.Windows.Forms.Padding(0);
            this.archiveNameLabel.Name = "archiveNameLabel";
            this.archiveNameLabel.Size = new System.Drawing.Size(794, 62);
            this.archiveNameLabel.TabIndex = 4;
            this.archiveNameLabel.Text = "Game.zip";
            this.archiveNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Image = global::ArchiveCacheManager.Resources.tick;
            this.okButton.Location = new System.Drawing.Point(39, 231);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 5;
            this.okButton.Text = "Play!";
            this.okButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.okButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Image = global::ArchiveCacheManager.Resources.cross_script;
            this.cancelButton.Location = new System.Drawing.Point(120, 231);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 6;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cancelButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // fakebrowser_txt
            // 
            this.fakebrowser_txt.Location = new System.Drawing.Point(800, 3);
            this.fakebrowser_txt.Multiline = true;
            this.fakebrowser_txt.Name = "fakebrowser_txt";
            this.fakebrowser_txt.Size = new System.Drawing.Size(422, 666);
            this.fakebrowser_txt.TabIndex = 7;
            this.fakebrowser_txt.Visible = false;
            // 
            // Texture_Label
            // 
            this.Texture_Label.BackColor = System.Drawing.Color.Black;
            this.Texture_Label.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Texture_Label.ForeColor = System.Drawing.Color.White;
            this.Texture_Label.Location = new System.Drawing.Point(3, 607);
            this.Texture_Label.Margin = new System.Windows.Forms.Padding(0);
            this.Texture_Label.Name = "Texture_Label";
            this.Texture_Label.Size = new System.Drawing.Size(794, 62);
            this.Texture_Label.TabIndex = 8;
            this.Texture_Label.Text = "3 Hi Res Textures files available !";
            this.Texture_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ArchiveListWindowBigBox
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(1225, 669);
            this.Controls.Add(this.Texture_Label);
            this.Controls.Add(this.fakebrowser_txt);
            this.Controls.Add(this.fileListBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.archiveNameLabel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ArchiveListWindowBigBox";
            this.Opacity = 0.92D;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Select File";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox fileListBox;
        private System.Windows.Forms.Label archiveNameLabel;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.TextBox fakebrowser_txt;
        private System.Windows.Forms.Label Texture_Label;
    }
}