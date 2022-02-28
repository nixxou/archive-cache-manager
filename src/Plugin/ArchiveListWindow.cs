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

namespace ArchiveCacheManager
{
    public partial class ArchiveListWindow : Form
    {
        public string SelectedFile;
        public dynamic json_hack;
        public bool hack_exist;
        public dynamic json_translation;
        public bool translation_exist;

        public ArchiveListWindow(string archiveName, string[] fileList, string dirpath, string selection = "")
        {
            InitializeComponent();
            this.hack_exist = false;
            string hack_file = dirpath + "\\hacks.json";
            if (File.Exists(hack_file)) {
                this.hack_exist = true;
                this.json_hack = JObject.Parse(File.ReadAllText(hack_file));
                label2.Text = "Found";
                label2.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                label2.Text = "Not Found";
                label2.ForeColor = System.Drawing.Color.Red;
            }

            this.translation_exist = false;
            string translation_file = dirpath + "\\translations.json";
            if (File.Exists(translation_file))
            {
                this.translation_exist = true;
                this.json_translation = JObject.Parse(File.ReadAllText(translation_file));
                label3.Text = "Found";
                label3.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                label3.Text = "Not Found";
                label3.ForeColor = System.Drawing.Color.Red;
            }

            //dynamic stuff = JObject.Parse("{ 'Name': 'Jon Smith', 'Address': { 'City': 'New York', 'State': 'NY' }, 'Age': 42 }");


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
            ///label1.Text = this.json_hack["469"]["patch_name"];
            if (this.hack_exist)
            {
                string pattern = @"\[H.([^\]]*)-([0-9]+)\]";
                Regex rgx = new Regex(pattern);
                Match match = rgx.Match(fileListBox.SelectedItem.ToString());

                if (match.Success)
                {
                    DisplayHtml(format_hack(match.Groups[2].Value));
                    return;
                }
            }
            if(this.translation_exist)
            {
                string pattern = @"\[T.([^\]]*)-([0-9]+)\]";
                Regex rgx = new Regex(pattern);
                Match match = rgx.Match(fileListBox.SelectedItem.ToString());

                if (match.Success)
                {
                    DisplayHtml(format_translation(match.Groups[2].Value));
                    return;
                }


            }

            DisplayHtml("<html><body bgcolor=\"F0F0F0\">No Info</body></html>");


        }

        private void ArchiveListWindow_Load(object sender, EventArgs e)
        {

        }

        private void webBrowser1_LoadCompleted(object sender, NavigationEventArgs e)
        {
           // webBrowser1.
        }

        private string format_translation(string idh)
        {

            string html_data = "<html><head>";
            html_data += @"<style>
<style>
table {
	border-collapse: collapse;
    font-family: Tahoma, Geneva, sans-serif;
	
}
table td {
	padding: 5px;
}
table thead td {
	color: #ffffff;
	font-weight: bold;
	font-size: 11px;
	border: none;
}
table tbody td {
	color: brown;
	
	
}
table tbody tr {
	border: 2px solid red;
}
table h2{
	text-align:center;
}
a:link, a:visited {
  color: brown;
  padding: 8px 8px;
  text-align: center;
  text-decoration: none;
  display: inline-block;
}

a:hover, a:active {

}
.title{
	
}
.val{
	font-weight: bold;
}
</style>";


            html_data += "</head><body bgcolor=\"F0F0F0\"> ";
            html_data += "<table>";
            html_data += "<tr><td colspan=\"4\"><h2><a target=\"_blank\" href=\"" + this.json_translation[idh]["url"] + "\">" + this.json_translation[idh]["patch_name"] + "</a><h2></td></tr>";
            html_data += "<tr><td class=\"title\">Released by</td><td class=\"val\">" + this.json_translation[idh]["released_by"] + "</td>";
            html_data += "<td class=\"title\">Version</td><td class=\"val\">" + this.json_translation[idh]["patch_version"] + "</td></tr>";

            html_data += "<tr><td class=\"title\">Language</td><td class=\"val\">" + this.json_translation[idh]["language"] + "</td>";
            html_data += "<td class=\"title\">Status</td><td class=\"val\">" + this.json_translation[idh]["status"] + "</td></tr>";

            html_data += "<tr><td class=\"title\">Release date</td><td class=\"val\">" + this.json_translation[idh]["release_date"] + "</td>";
            html_data += "<td class=\"title\">Last modified</td><td class=\"val\">" + this.json_translation[idh]["last_modified"] + "</td></tr>";

            html_data += "<tr><td colspan=\"4\">" + this.json_translation[idh]["desc"] + "</td></tr>";
            html_data += "</table></body></html>";

            return html_data;

        }
        private string format_hack(string idh)
        {

            string html_data = "<html><head>";
            html_data += @"<style>
<style>
table {
	border-collapse: collapse;
    font-family: Tahoma, Geneva, sans-serif;
	
}
table td {
	padding: 5px;
}
table thead td {
	color: #ffffff;
	font-weight: bold;
	font-size: 11px;
	border: none;
}
table tbody td {
	color: brown;
	
	
}
table tbody tr {
	border: 2px solid red;
}
table h2{
	text-align:center;
}
a:link, a:visited {
  color: brown;
  padding: 8px 8px;
  text-align: center;
  text-decoration: none;
  display: inline-block;
}

a:hover, a:active {

}
.title{
	
}
.val{
	font-weight: bold;
}
</style>";


            html_data += "</head><body bgcolor=\"F0F0F0\"> ";
            html_data += "<table>";
            html_data += "<tr><td colspan=\"4\"><h2><a target=\"_blank\" href=\"" + this.json_hack[idh]["url"] + "\">" + this.json_hack[idh]["patch_name"] + "</a><h2></td></tr>";
            html_data += "<tr><td class=\"title\">Released by</td><td class=\"val\">" + this.json_hack[idh]["released_by"] + "</td>";
            html_data += "<td class=\"title\">Version</td><td class=\"val\">" + this.json_hack[idh]["patch_version"] + "</td></tr>";

            html_data += "<tr><td class=\"title\">Category</td><td class=\"val\">" + this.json_hack[idh]["category"] + "</td>";
            html_data += "<td class=\"title\">Mods</td><td class=\"val\">" + this.json_hack[idh]["mods"] + "</td></tr>";

            html_data += "<tr><td class=\"title\">Release date</td><td class=\"val\">" + this.json_hack[idh]["hack_release_date"] + "</td>";
            html_data += "<td class=\"title\">Last modified</td><td class=\"val\">" + this.json_hack[idh]["last_modified"] + "</td></tr>";

            html_data += "<tr><td colspan=\"4\">" + this.json_hack[idh]["desc"] + "</td></tr>";
            html_data += "</table></body></html>";

            return html_data;

        }
        private void DisplayHtml(string html)
        {
            webBrowser1.Navigate("about:blank");
            if (webBrowser1.Document != null)
            {
                webBrowser1.Document.Write(string.Empty);
            }
            webBrowser1.DocumentText = html;
        }



        /*
private string TextToHtml(string text)
{
   text = text.Replace("\r\n", "\r");
   text = text.Replace("\n", "\r");
   text = text.Replace("\r", "<br>\r\n");
   text = text.Replace("  ", " &nbsp;");
   return text;
}
*/
    }
}
