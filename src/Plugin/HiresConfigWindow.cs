using System;
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
    public partial class HiresConfigWindow : Form
    {
        public static string txtpath="";

        public HiresConfigWindow()
        {
            InitializeComponent();
            TexturePathTxt.Text = txtpath;
            TexturePathTxt.Leave += new System.EventHandler(this.TexturePathTxt_Leave);
        }

        private void HiresConfigWindow_Load(object sender, EventArgs e)
        {

        }

        private void ExploreButton_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                string base_dir = Directory.GetParent(Path.GetDirectoryName(Application.ExecutablePath)).FullName;
                base_dir = base_dir + @"\Emulators";
                fbd.RootFolder = Environment.SpecialFolder.DesktopDirectory;
                fbd.SelectedPath = base_dir;

                DialogResult result = fbd.ShowDialog();
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath) && Directory.Exists(fbd.SelectedPath))
                {
                    //TexturePath_txt.Text = fbd.SelectedPath;                    
                    TexturePathTxt.Text = Path.GetFullPath(fbd.SelectedPath);
                }
                checkpath();

            }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            TexturePathTxt.Text = "";
            checkpath();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(TexturePathTxt.Text) || Directory.Exists(TexturePathTxt.Text))
            {
                txtpath = TexturePathTxt.Text;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid Path !");
            }
            
        }

        private void TexturePathTxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void TexturePathTxt_Leave(object sender, System.EventArgs e)
        {
            // Reset the colors and selection of the TextBox after focus is lost.
            checkpath();
        }

        private void checkpath()
        {
            if (Directory.Exists(TexturePathTxt.Text))
            {
                pictureBox1.ImageLocation = "tick";
            }
            else
            {
                pictureBox1.ImageLocation = "cross_script";
            }
        }
    }
}
