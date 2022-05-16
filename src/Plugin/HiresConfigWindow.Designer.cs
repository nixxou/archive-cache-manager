
namespace ArchiveCacheManager
{
    partial class HiresConfigWindow
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
            this.TexturePathTxt = new System.Windows.Forms.TextBox();
            this.ExploreButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.CloseButton = new System.Windows.Forms.Button();
            this.ClearButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // TexturePathTxt
            // 
            this.TexturePathTxt.Location = new System.Drawing.Point(12, 21);
            this.TexturePathTxt.Name = "TexturePathTxt";
            this.TexturePathTxt.Size = new System.Drawing.Size(549, 20);
            this.TexturePathTxt.TabIndex = 0;
            this.TexturePathTxt.TextChanged += new System.EventHandler(this.TexturePathTxt_TextChanged);
            // 
            // ExploreButton
            // 
            this.ExploreButton.Image = global::ArchiveCacheManager.Resources.folder_horizontal_open;
            this.ExploreButton.Location = new System.Drawing.Point(589, 20);
            this.ExploreButton.Name = "ExploreButton";
            this.ExploreButton.Size = new System.Drawing.Size(99, 21);
            this.ExploreButton.TabIndex = 1;
            this.ExploreButton.Text = "Select Folder";
            this.ExploreButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ExploreButton.UseVisualStyleBackColor = true;
            this.ExploreButton.Click += new System.EventHandler(this.ExploreButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ArchiveCacheManager.Resources.tick;
            this.pictureBox1.Location = new System.Drawing.Point(567, 22);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(16, 19);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // CloseButton
            // 
            this.CloseButton.Image = global::ArchiveCacheManager.Resources.tick;
            this.CloseButton.Location = new System.Drawing.Point(12, 60);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(68, 31);
            this.CloseButton.TabIndex = 3;
            this.CloseButton.Text = "OK";
            this.CloseButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // ClearButton
            // 
            this.ClearButton.Image = global::ArchiveCacheManager.Resources.broom;
            this.ClearButton.Location = new System.Drawing.Point(694, 22);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(99, 19);
            this.ClearButton.TabIndex = 4;
            this.ClearButton.Text = "Clear";
            this.ClearButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Image = global::ArchiveCacheManager.Resources.cross_script;
            this.CancelButton.Location = new System.Drawing.Point(86, 60);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(68, 31);
            this.CancelButton.TabIndex = 5;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.CancelButton.UseVisualStyleBackColor = true;
            // 
            // HiresConfigWindow
            // 
            this.AcceptButton = this.CloseButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 99);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.ExploreButton);
            this.Controls.Add(this.TexturePathTxt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HiresConfigWindow";
            this.Text = "HiresConfigWindow";
            this.Load += new System.EventHandler(this.HiresConfigWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TexturePathTxt;
        private System.Windows.Forms.Button ExploreButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.Button CancelButton;
    }
}