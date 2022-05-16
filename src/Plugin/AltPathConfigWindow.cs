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
    public partial class AltPathConfigWindow : Form
    {
        public static string altpath = "";
        public AltPathConfigWindow()
        {
            InitializeComponent();
            int i = 1;
            
            foreach (string apath in altpath.Split('|'))
            {

                string[] pathdata = apath.Split('>');
                bool recurse = false;
                if (pathdata.Length > 1 && pathdata[1] == "R") recurse = true;
                switch (i)
                {
                    case 1:
                        altPath_Txt1.Text = pathdata[0];
                        altpathRecurse_chk1.Checked = recurse;
                        break;
                    case 2:
                        altPath_Txt2.Text = pathdata[0];
                        altpathRecurse_chk2.Checked = recurse;
                        break;
                    case 3:
                        altPath_Txt3.Text = pathdata[0];
                        altpathRecurse_chk3.Checked = recurse;
                        break;
                    case 4:
                        altPath_Txt4.Text = pathdata[0];
                        altpathRecurse_chk4.Checked = recurse;
                        break;
                    case 5:
                        altPath_Txt5.Text = pathdata[0];
                        altpathRecurse_chk5.Checked = recurse;
                        break;
                }
                i++;
            }
            
        }

        private void ExploreBtn1_Click(object sender, EventArgs e)
        {
            string currentpath = altPath_Txt1.Text;
            using (var fbd = new FolderBrowserDialog())
            {
                if(!string.IsNullOrWhiteSpace(currentpath) && Directory.Exists(currentpath))
                {
                    fbd.RootFolder = Environment.SpecialFolder.DesktopDirectory;
                    fbd.SelectedPath = currentpath;
                }
                DialogResult result = fbd.ShowDialog();
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath) && Directory.Exists(fbd.SelectedPath))
                {
                    altPath_Txt1.Text = Path.GetFullPath(fbd.SelectedPath);
                }
            }
        }

        private void ExploreBtn2_Click(object sender, EventArgs e)
        {
            string currentpath = altPath_Txt2.Text;
            using (var fbd = new FolderBrowserDialog())
            {
                if (!string.IsNullOrWhiteSpace(currentpath) && Directory.Exists(currentpath))
                {
                    fbd.RootFolder = Environment.SpecialFolder.DesktopDirectory;
                    fbd.SelectedPath = currentpath;
                }
                DialogResult result = fbd.ShowDialog();
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath) && Directory.Exists(fbd.SelectedPath))
                {
                    altPath_Txt2.Text = Path.GetFullPath(fbd.SelectedPath);
                }
            }
        }

        private void ExploreBtn3_Click(object sender, EventArgs e)
        {
            string currentpath = altPath_Txt3.Text;
            using (var fbd = new FolderBrowserDialog())
            {
                if (!string.IsNullOrWhiteSpace(currentpath) && Directory.Exists(currentpath))
                {
                    fbd.RootFolder = Environment.SpecialFolder.DesktopDirectory;
                    fbd.SelectedPath = currentpath;
                }
                DialogResult result = fbd.ShowDialog();
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath) && Directory.Exists(fbd.SelectedPath))
                {
                    altPath_Txt3.Text = Path.GetFullPath(fbd.SelectedPath);
                }
            }
        }

        private void ExploreBtn4_Click(object sender, EventArgs e)
        {
            string currentpath = altPath_Txt4.Text;
            using (var fbd = new FolderBrowserDialog())
            {
                if (!string.IsNullOrWhiteSpace(currentpath) && Directory.Exists(currentpath))
                {
                    fbd.RootFolder = Environment.SpecialFolder.DesktopDirectory;
                    fbd.SelectedPath = currentpath;
                }
                DialogResult result = fbd.ShowDialog();
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath) && Directory.Exists(fbd.SelectedPath))
                {
                    altPath_Txt4.Text = Path.GetFullPath(fbd.SelectedPath);
                }
            }
        }

        private void ExploreBtn5_Click(object sender, EventArgs e)
        {
            string currentpath = altPath_Txt5.Text;
            using (var fbd = new FolderBrowserDialog())
            {
                if (!string.IsNullOrWhiteSpace(currentpath) && Directory.Exists(currentpath))
                {
                    fbd.RootFolder = Environment.SpecialFolder.DesktopDirectory;
                    fbd.SelectedPath = currentpath;
                }
                DialogResult result = fbd.ShowDialog();
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath) && Directory.Exists(fbd.SelectedPath))
                {
                    altPath_Txt5.Text = Path.GetFullPath(fbd.SelectedPath);
                }
            }
        }

        private void ClearBtn1_Click(object sender, EventArgs e)
        {
            altPath_Txt1.Text = "";
        }

        private void ClearBtn2_Click(object sender, EventArgs e)
        {
            altPath_Txt2.Text = "";
        }

        private void ClearBtn3_Click(object sender, EventArgs e)
        {
            altPath_Txt3.Text = "";
        }

        private void ClearBtn4_Click(object sender, EventArgs e)
        {
            altPath_Txt4.Text = "";
        }

        private void ClearBtn5_Click(object sender, EventArgs e)
        {
            altPath_Txt5.Text = "";
        }

        private bool IsValidPath(string path, bool allowRelativePaths = true)
        {
            bool isValid = true;

            try
            {
                string fullPath = Path.GetFullPath(path);

                if (allowRelativePaths)
                {
                    isValid = Path.IsPathRooted(path);
                }
                else
                {
                    string root = Path.GetPathRoot(path);
                    isValid = string.IsNullOrEmpty(root.Trim(new char[] { '\\', '/' })) == false;
                }
            }
            catch (Exception ex)
            {
                isValid = false;
            }

            return isValid;
        }

        private void AltPathConfigWindow_Load(object sender, EventArgs e)
        {

        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            List<string> pathlist = new List<string>();
            string cpath = altPath_Txt1.Text;
            string optionval = ">N";
            if (!String.IsNullOrEmpty(cpath))
            {
                if (IsValidPath(cpath))
                {
                    if (altpathRecurse_chk1.Checked) optionval = ">R";
                    pathlist.Add(cpath+optionval);
                }
                else
                {
                    MessageBox.Show("Invalid path ! " + cpath);
                    return;
                }
            }
            cpath = altPath_Txt2.Text; optionval = ">N";
            if (!String.IsNullOrEmpty(cpath))
            {
                if (IsValidPath(cpath))
                {
                    if (altpathRecurse_chk2.Checked) optionval = ">R";
                    pathlist.Add(cpath + optionval);
                }
                else
                {
                    MessageBox.Show("Invalid path ! " + cpath);
                    return;
                }
            }
            cpath = altPath_Txt3.Text; optionval = ">N";
            if (!String.IsNullOrEmpty(cpath))
            {
                if (IsValidPath(cpath))
                {
                    if (altpathRecurse_chk3.Checked) optionval = ">R";
                    pathlist.Add(cpath + optionval);
                }
                else
                {
                    MessageBox.Show("Invalid path ! " + cpath);
                    return;
                }
            }
            cpath = altPath_Txt4.Text; optionval = ">N";
            if (!String.IsNullOrEmpty(cpath))
            {
                if (IsValidPath(cpath))
                {
                    if (altpathRecurse_chk4.Checked) optionval = ">R";
                    pathlist.Add(cpath + optionval);
                }
                else
                {
                    MessageBox.Show("Invalid path ! " + cpath);
                    return;
                }
            }
            cpath = altPath_Txt5.Text; optionval = ">N";
            if (!String.IsNullOrEmpty(cpath))
            {
                if (IsValidPath(cpath))
                {
                    if (altpathRecurse_chk5.Checked) optionval = ">R";
                    pathlist.Add(cpath + optionval);
                }
                else
                {
                    MessageBox.Show("Invalid path ! " + cpath);
                    return;
                }
            }

            altpath = String.Join("|", pathlist.ToArray());
            
            //Delete cached altpath results
            PathUtils.cache_altpath.Clear();

            this.DialogResult = DialogResult.OK;
            this.Close();

        }
    }
}
