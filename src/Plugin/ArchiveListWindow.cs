using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Windows.Navigation;
using System.Text.RegularExpressions;
using CefSharp;


namespace ArchiveCacheManager
{
    public partial class ArchiveListWindow : Form
    {
        public string SelectedFile;

        public bool useDepreciatedSystem = false;
        public bool useNewSystem = false;
        public string HtmlTemplate = "";
        public dynamic JsonData;

        public ArchiveListWindow(string archiveName, string[] fileList, string dirpath, string selection = "")
        {
            InitializeComponent();

            DirectoryInfo dinfo = new DirectoryInfo(dirpath);
            string Metadata_folder = dinfo.Parent.FullName + "\\metadata\\" + dinfo.Name;
            FileInfo finfo = new FileInfo(dinfo.FullName + "\\" + archiveName);
            string Metadata_file = Metadata_folder + "\\" + Path.GetFileNameWithoutExtension(archiveName) + ".json";
            string Metadata_template = Metadata_folder + "\\template.html";
            if (File.Exists(Metadata_file) && File.Exists(Metadata_template))
            {
                this.useNewSystem = true;
                this.HtmlTemplate = File.ReadAllText(Metadata_template);
                this.JsonData = JObject.Parse(File.ReadAllText(Metadata_file));
            }
            else
            {
                this.Width = 1005;
                //chromiumWebBrowser1.Visible = false;
            }

        archiveNameLabel.Text = archiveName;

            fileListBox.Items.Clear();
            fileListBox.Items.AddRange(fileList);
            if (selection != string.Empty)
            {
                fileListBox.SelectedItem = selection;
            }
            // Check that setting the selected item above actually worked. If not, set it to the first item.
            if (fileListBox.SelectedItems.Count == 0)
            {
                fileListBox.SelectedIndex = 0;
            }
            SelectedFile = string.Empty;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            SelectedFile = fileListBox.SelectedItem.ToString();
        }

        private void fileListBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            okButton.PerformClick();
        }

        private void fileListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.useNewSystem)
            {
                //New System
                if (this.JsonData.ContainsKey(fileListBox.SelectedItem.ToString()))
                {
                    string sval = this.JsonData[fileListBox.SelectedItem.ToString()].ToString();
                    string html_data = this.HtmlTemplate.Replace("[[JSONDATA]]", sval);
                    //chromiumWebBrowser1.LoadHtml(html_data);
                    return;
                }
                //chromiumWebBrowser1.LoadHtml("<html><body bgcolor=\"F0F0F0\">No Info</body></html>");
            }
        }
    }
}
