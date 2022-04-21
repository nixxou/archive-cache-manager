using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unbroken.LaunchBox.Plugins;
using Unbroken.LaunchBox.Plugins.Data;

using System.IO;
using BrightIdeasSoftware;
using Newtonsoft.Json.Linq;
using CefSharp;

namespace ArchiveCacheManager
{
    public partial class ArchiveListWindowBigBox : Form //, IBigBoxThemeElementPlugin
    {
        public string SelectedFile;

        public string base_launchbox_dir = "";
        public bool useWebview = false;
        public bool useJsonMeta = true;
        public string HtmlTemplate = "";
        public dynamic JsonData;
        public string metadataFile = "";
        public string metadataFolder = "";
        public string colors_css = "";
        private CefSharp.WinForms.ChromiumWebBrowser chromiumWebBrowser1;

        private (bool foundmeta, string Metadata_file, string Metadata_template, string Metadata_folder) find_metadata(string dirpath, string archiveName)
        {
            string res_Metadata_file = "";
            string res_Metadata_template = "";
            string res_Metadata_htmlfolder = "";

            string Metadata_file = "";
            string Metadata_template = "";
            bool valid_meta = false;

            DirectoryInfo dinfo = new DirectoryInfo(dirpath);
            string Metadata_folder = dinfo.Parent.FullName + "\\metadata\\" + dinfo.Name;
            if (Directory.Exists(Metadata_folder))
            {
                if (Directory.Exists(Metadata_folder + "\\" + archiveName))
                {
                    res_Metadata_htmlfolder = Metadata_folder + "\\" + archiveName;
                    valid_meta = true;
                }
                Metadata_file = Metadata_folder + "\\" + Path.GetFileNameWithoutExtension(archiveName) + ".json";
                if (File.Exists(Metadata_file))
                {
                    Metadata_template = Metadata_folder + "\\template.html";
                    if (File.Exists(Metadata_template))
                    {
                        res_Metadata_file = Metadata_file;
                        res_Metadata_template = Metadata_template;
                        valid_meta = true;
                    }
                    Metadata_template = Metadata_folder + "\\template.BB.html";
                    if (File.Exists(Metadata_template))
                    {
                        res_Metadata_file = Metadata_file;
                        res_Metadata_template = Metadata_template;
                        valid_meta = true;
                    }
                }
                if (valid_meta) return (true, res_Metadata_file, res_Metadata_template, res_Metadata_htmlfolder);
            }
            Metadata_folder = this.base_launchbox_dir + "\\metadata\\" + dinfo.Name;
            if (Directory.Exists(Metadata_folder))
            {
                if (Directory.Exists(Metadata_folder + "\\" + archiveName))
                {
                    res_Metadata_htmlfolder = Metadata_folder + "\\" + archiveName;
                    valid_meta = true;
                }

                Metadata_file = Metadata_folder + "\\" + Path.GetFileNameWithoutExtension(archiveName) + ".json";
                if (File.Exists(Metadata_file))
                {
                    Metadata_template = Metadata_folder + "\\template.html";
                    if (File.Exists(Metadata_template))
                    {
                        res_Metadata_file = Metadata_file;
                        res_Metadata_template = Metadata_template;
                        valid_meta = true;
                    }
                    Metadata_template = Metadata_folder + "\\template.BB.html";
                    if (File.Exists(Metadata_template))
                    {
                        res_Metadata_file = Metadata_file;
                        res_Metadata_template = Metadata_template;
                        valid_meta = true;
                    }
                }
                if (valid_meta) return (true, res_Metadata_file, res_Metadata_template, res_Metadata_htmlfolder);
            }


            return (false, "", "", "");
        }

        void InitializeWebView(string dirpath, string archiveName)
        {
            (bool foundmeta, string Metadata_file, string Metadata_template, string Metadata_htmlfolder) = find_metadata(dirpath, archiveName);
            this.metadataFile = Metadata_file;
            this.metadataFolder = Metadata_htmlfolder;
            this.useWebview = foundmeta;
            this.useJsonMeta = false;

            if (foundmeta)
            {
                this.colors_css = @"
                :root {
                    --DialogAccentColor: " + ColorTranslator.ToHtml(LaunchBoxSettings.DialogAccentColor).ToString() + @";
                    --DialogHighlightColor: " + ColorTranslator.ToHtml(LaunchBoxSettings.DialogHighlightColor).ToString() + @";
                    --DialogBackgroundColor: " + ColorTranslator.ToHtml(LaunchBoxSettings.DialogBackgroundColor).ToString() + @";
                    --DialogBorderColor: " + ColorTranslator.ToHtml(LaunchBoxSettings.DialogBorderColor).ToString() + @";
                    --DialogForegroundColor:" + ColorTranslator.ToHtml(LaunchBoxSettings.DialogForegroundColor).ToString() + @";
                    --backColorContrast1:" + ColorTranslator.ToHtml(UserInterface.backColorContrast1).ToString() + @";
                    --backColorContrast2:" + ColorTranslator.ToHtml(UserInterface.backColorContrast2).ToString() + @";
                }
                ";
            }

            if (foundmeta && Metadata_file != "")
            {
                this.HtmlTemplate = File.ReadAllText(Metadata_template);
                this.JsonData = JObject.Parse(File.ReadAllText(Metadata_file));
                this.useJsonMeta = true;

                if (this.HtmlTemplate.Contains("mySoapMessage"))
                {
                    //Old version of template, dirty edit to add style
                    string old_css_hack = @"
                        <style>
                        " + colors_css + @"
                        .note{
                            background-color:var(--DialogBackgroundColor);
                        }
                        div label{
                            color:var(--DialogForegroundColor);
                            background-color:var(--DialogBackgroundColor);;
    
                        }
                        #myData{
                            background-color: var(--DialogBackgroundColor);    
                        }
                        .tab{
                            background-color: var(--DialogHighlightColor);
                        }
                        h3{
                            color:var(--DialogForegroundColor);
                        }
                        a:link, a:visited {
                          color: var(--DialogForegroundColor);
                        }
                        td{
                            color:var(--DialogForegroundColor);
                        }
                        td.val {
	                        color: var(--DialogForegroundColor);
                        }
                        td.title{
                            color:var(--DialogForegroundColor);
                        }
                        body{
                            background-color: var(--DialogBackgroundColor); 
                        }
                        </style>
                    ";

                    this.HtmlTemplate = this.HtmlTemplate.Replace(@"</head>", old_css_hack + @"</head>");
                    this.HtmlTemplate = this.HtmlTemplate.Replace(@"background: #EEE;", "background: var(--backColorContrast1);");
                    this.HtmlTemplate = this.HtmlTemplate.Replace(@"background: #FFF;", "background: var(--backColorContrast2);");
                }
                else
                {
                    this.HtmlTemplate = this.HtmlTemplate.Replace("[[CSSCOLOR]]", colors_css);
                }
            }

            if (this.useWebview)
            {
                this.chromiumWebBrowser1 = new CefSharp.WinForms.ChromiumWebBrowser();
                this.chromiumWebBrowser1.ActivateBrowserOnCreation = false;
                //this.chromiumWebBrowser1.Visible = false;
                this.chromiumWebBrowser1.Location = fakebrowser_txt.Location;
                this.chromiumWebBrowser1.Name = "chromiumWebBrowser1";
                this.chromiumWebBrowser1.Size = fakebrowser_txt.Size;

                var sett = new CefSharp.BrowserSettings();
                sett.BackgroundColor = ColorToUInt(Color.Black);
                chromiumWebBrowser1.BrowserSettings = sett;

                this.chromiumWebBrowser1.TabIndex = fakebrowser_txt.TabIndex;
                this.Controls.Remove(this.fakebrowser_txt);
                this.Controls.Add(this.chromiumWebBrowser1);

                this.chromiumWebBrowser1.LoadHtml("<html><body bgcolor=\"" + ColorTranslator.ToHtml(UserInterface.backColor) + "\">No Info</body></html>");
            }
            else
            {
                this.Width = this.Width - this.fakebrowser_txt.Width;
            }
        }

        public static uint ColorToUInt(Color color)
        {
            return (uint)((color.A << 24) | (color.R << 16) | (color.G << 8) | (color.B << 0));
        }

        public ArchiveListWindowBigBox(string archiveName, string archiveDir, string[] fileList, string selection = "")
        {


            this.useWebview = false;
            this.useJsonMeta = true;
            this.HtmlTemplate = "";
            this.metadataFile = "";
            this.metadataFolder = "";
            this.colors_css = "";

            //Remove Metadata from listing
            Dictionary<string, int> File_hidden = new Dictionary<string, int>();
            List<string> fileList_All = new List<string>();
            fileList_All = fileList.ToList();
            List<string> metadataList = Utils.SplitExtensions(Config.MetadataExtensions).ToList();
            List<string> fileList_lowpriority = new List<string>();
            foreach (string extension in metadataList)
            {
                foreach (string file in fileList_All)
                {
                    if (Wildcard.Match(file.ToLower(), string.Format("*{0}", extension.ToLower().Trim())))
                    {
                        fileList_lowpriority.Add(file);
                        if (File_hidden.ContainsKey(extension.ToLower().Trim())) File_hidden[extension.ToLower().Trim()] += 1;
                        else File_hidden[extension.ToLower().Trim()] = 1;
                    }
                }
            }
            fileList = fileList_All.Except(fileList_lowpriority).ToArray();


            this.base_launchbox_dir = Directory.GetParent(Path.GetDirectoryName(Application.ExecutablePath)).FullName;
            InitializeComponent();

            if (File_hidden.Count > 0)
            {
                string hidden_str = "";
                int nbh = 0;
                foreach (var fh in File_hidden)
                {
                    hidden_str += fh.Key + ": " + fh.Value.ToString() + " ,";
                    nbh += fh.Value;
                }
                hidden_str = hidden_str.Trim(',');
                hidden_str = hidden_str.Trim();
                if (nbh == 1) hidden_str = "File hidden : " + hidden_str;
                else hidden_str = "Files hidden : " + hidden_str;
                Texture_Label.Text = hidden_str;
            }
            else
            {
                fileListBox.Height += Texture_Label.Height;
                Texture_Label.Visible = false;
            }

            InitializeWebView(archiveDir, archiveName);

            if (LaunchBoxSettings.HideMouseCursor)
            {
                Cursor.Hide();
            }

            archiveNameLabel.Text = archiveName;

            fileListBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            fileListBox.MeasureItem += lst_MeasureItem;
            fileListBox.DrawItem += lst_DrawItem;

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

        private void lst_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            e.ItemHeight = (int)e.Graphics.MeasureString(fileListBox.Items[e.Index].ToString(), fileListBox.Font, fileListBox.Width).Height;
        }

        private void lst_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            
            Graphics g = e.Graphics;
            Brush brush = ((e.State & DrawItemState.Selected) == DrawItemState.Selected) ?
                            new SolidBrush(Color.FromArgb(0x5F, 0x33, 0x99, 0xFF)) : new SolidBrush(e.BackColor);
            g.FillRectangle(brush, e.Bounds);
            e.DrawFocusRectangle();
            e.Graphics.DrawString(fileListBox.Items[e.Index].ToString(), e.Font, new SolidBrush(e.ForeColor), e.Bounds);
        }

        private void FileListBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            /*
            e.DrawBackground();
            Graphics g = e.Graphics;
            Brush brush = ((e.State & DrawItemState.Selected) == DrawItemState.Selected) ?
                            new SolidBrush(Color.FromArgb(0x5F, 0x33, 0x99, 0xFF)) : new SolidBrush(e.BackColor);
            g.FillRectangle(brush, e.Bounds);
            e.Graphics.DrawString("  " + fileListBox.Items[e.Index].ToString(), e.Font,
                        new SolidBrush(e.ForeColor), e.Bounds, StringFormat.GenericDefault);
            //e.DrawFocusRectangle();
            */
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
            if (this.useWebview && fileListBox.SelectedIndex >= 0)
            {
                string selected_file = fileListBox.SelectedItem.ToString();

                if (this.metadataFolder != "" && File.Exists(this.metadataFolder + "\\" + selected_file + ".html"))
                {
                    string html_data = File.ReadAllText(this.metadataFolder + "\\" + selected_file + ".html");
                    this.HtmlTemplate.Replace("[[CSSCOLOR]]", this.colors_css);
                    this.chromiumWebBrowser1.LoadHtml(html_data,true);
                    this.chromiumWebBrowser1.Visible = true;
                    return;
                }

                if (this.useJsonMeta && this.JsonData.ContainsKey(selected_file))
                {
                    string sval = this.JsonData[selected_file].ToString();
                    string html_data = this.HtmlTemplate.Replace("[[JSONDATA]]", sval);
                    this.chromiumWebBrowser1.LoadHtml(html_data,true);
                    //System.IO.File.WriteAllText("test2.html", html_data);
                    this.chromiumWebBrowser1.Visible = true;
                    return;
                }
                this.chromiumWebBrowser1.LoadHtml("<html><body bgcolor=\"" + ColorTranslator.ToHtml(UserInterface.backColor) + "\">No Info</body></html>");
            }
        }




#if false
        public void OnSelectionChanged(FilterType filterType, string filterValue, IPlatform platform, IPlatformCategory category, IPlaylist playlist, IGame game)
        {
            
        }

        public bool OnEnter()
        {
            SelectedFile = fileListBox.SelectedItem.ToString();

            this.DialogResult = DialogResult.OK;
            this.Close();

            return true;
        }

        public bool OnEscape()
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();

            return true;
        }

        public bool OnUp(bool held)
        {
            if (fileListBox.SelectedIndex > 0)
            {
                fileListBox.SelectedIndex--;
            }

            return true;
        }

        public bool OnDown(bool held)
        {
            if (fileListBox.SelectedIndex < fileListBox.Items.Count - 1)
            {
                fileListBox.SelectedIndex++;
            }

            return true;
        }

        public bool OnLeft(bool held)
        {
            return true;
        }

        public bool OnRight(bool held)
        {
            return true;
        }

        public bool OnPageDown()
        {
            return true;
        }

        public bool OnPageUp()
        {
            return true;
        }
#endif
    }
}
