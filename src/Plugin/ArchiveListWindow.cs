using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace ArchiveCacheManager
{


    public partial class ArchiveListWindow : Form
    {
        public string SelectedFile;
        public int EmulatorIndex;

        public ArchiveListWindow(string archiveName, string[] fileList, long[] sizeList, string plateform, string emulator, string[] emulatorList, string selection = "")
        {
            InitializeComponent();
            InitializeListView();

            archiveNameLabel.Text = archiveName;

            emulatorComboBox.Items.Clear();
            if (emulatorList.Count() > 0)
            {
                emulatorComboBox.Items.AddRange(emulatorList);
                emulatorComboBox.SelectedIndex = 0;
                EmulatorIndex = emulatorComboBox.SelectedIndex;
                emulatorComboBox.Enabled = true;
            }
            else
            {
                emulatorComboBox.Enabled = false;
            }

            Dictionary<string, string> FnP = Config.FilenamePriority;

            string priority_file = "";
            List<string> prioritySections = new List<string>();
            prioritySections.Add(string.Format(@"{0} \ {1}", emulator, plateform));
            prioritySections.Add(@"All \ All");
            foreach (var prioritySection in prioritySections)
            {
                try
                {
                    string[] extensionPriority = Config.FilenamePriority[prioritySection].Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                    // Search the extensions in priority order
                    foreach (string extension in extensionPriority)
                    {

                        foreach (string fl in fileList)
                        {
                            if (Wildcard.Match(fl.ToLower(),string.Format("*{0}", extension.ToLower().Trim())))
                            {
                                priority_file = fl;
                                break;
                            }
                        }
                    }
                }
                catch (KeyNotFoundException)
                {

                }
                if (priority_file != "") break;
            }


            //objectListView1.Clear();
            int i = 0;
            int selected_index = -1;
            foreach(string fl in fileList)
            {
                string icon_img = "";
                if (fl == priority_file) icon_img = "star_yellow";
                if(fl == selection) icon_img = "star_blue";
                Rom.AddRom(fl.ToString(), sizeList[i], icon_img);
                if (selection != string.Empty && fl.ToString() == selection) selected_index = i;
                i++;
                
            }
            this.objectListView1.SetObjects(Rom.AllRoms);
            if (selection != string.Empty && selected_index != -1)
            {

                objectListView1.SelectedIndex = selected_index;
            }
            // Check that setting the selected item above actually worked. If not, set it to the first item.
            if (objectListView1.SelectedItems.Count == 0)
            {
                objectListView1.SelectedIndex = 0;
            }
            SelectedFile = string.Empty;
            this.objectListView1.AutoResizeColumn(2, ColumnHeaderAutoResizeStyle.ColumnContent);
            this.objectListView1.AutoResizeColumn(3, ColumnHeaderAutoResizeStyle.ColumnContent);
            this.objectListView1.AutoResizeColumn(4, ColumnHeaderAutoResizeStyle.ColumnContent);
            this.objectListView1.AutoResizeColumn(5, ColumnHeaderAutoResizeStyle.ColumnContent);
            this.objectListView1.AutoResizeColumn(6, ColumnHeaderAutoResizeStyle.ColumnContent);
            this.objectListView1.AutoResizeColumn(7, ColumnHeaderAutoResizeStyle.ColumnContent);
            this.objectListView1.AutoResizeColumn(8, ColumnHeaderAutoResizeStyle.ColumnContent);
            //this.objectListView1.GetColumn(4)..AllColumns["colRating"].



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

        private void InitializeListView()
        {
            this.titleColumn.ImageGetter = delegate (object rowObject) {
                Rom s = (Rom)rowObject;
                return s.IconImg;
            };

            this.sizeColumn.AspectToStringConverter = delegate (object x) {
                long size = (long)x;
                int[] limits = new int[] { 1024 * 1024 * 1024, 1024 * 1024, 1024 };
                string[] units = new string[] { "GB", "MB", "KB" };

                for (int i = 0; i < limits.Length; i++)
                {
                    if (size >= limits[i])
                        return String.Format("{0:#,##0.##} " + units[i], ((double)size / limits[i]));
                }

                return String.Format("{0} bytes", size); ;
            };
            objectListView1.ItemActivate += new System.EventHandler(this.objectListView1_ItemActivate);

        }

        private void okButton_Click(object sender, EventArgs e)
        {
            SelectedFile = objectListView1.SelectedItem.Text;
            EmulatorIndex = emulatorComboBox.SelectedIndex;
        }

        private void fileListBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            okButton.PerformClick();
        }

        private void fileListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ArchiveListWindow_Load(object sender, EventArgs e)
        {

        }

        private void archiveNameLabel_Click(object sender, EventArgs e)
        {

        }

        private void objectListView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(objectListView1.SelectedIndex.ToString());
        }

        private void objectListView1_ItemActivate(object sender, EventArgs e)
        {
            okButton.PerformClick();
            //MessageBox.Show("Activate !");
        }

        public async void updatetags()
        {

        }
    }


    public class Rom
    {
        public Rom()
        {
        }

        public Rom(string title, long sizeInBytes, string iconImg = "")
        {
            this.Title = title;
            this.SizeInBytes = sizeInBytes;
            this.IconImg = iconImg;

        }

        public string Title;
        public long SizeInBytes;
        public string IconImg;
        public string Tag1 = "";
        public string Tag2 = "";
        public string Tag3 = "";
        public string Tag4 = "";
        public string Tag5 = "";
        public string Tag6 = "";
        public string Tag7 = "";

        public void SetTags()
        {
            string pattern = @"\[([^[]*)\]";
            RegexOptions options = RegexOptions.Multiline;
            MatchCollection matches = Regex.Matches(this.Title, pattern, options);


            int i = 0;
            int index_interesting_tag = -1;
            foreach (Match m in matches)
            {
                i++;
                string valtag = m.Value.Trim().ToUpper();
                if (valtag == "[GOODSET]" || valtag == "[N64V]" || valtag == "[RHCOM]" || valtag == "[HTGDB]" || valtag == "[MEGAPACK]")
                {
                    index_interesting_tag = i;
                    break;
                }
            }
            i = 0;

            int target_tag = 1;
            bool hackset = false;
            foreach (Match m in matches)
            {
                string valtag = m.Value.Trim();
                i++;
                if (target_tag == 2)
                {
                    if (valtag.Length <= 4 || (valtag.ToLower().StartsWith("[rev ") && valtag.Length == 6) || valtag.ToLower() == "[virtual console]") target_tag = 1;
                    if (i < index_interesting_tag) target_tag = 1;
                }
                if (target_tag <= 3 && (valtag.StartsWith("[H.") || valtag.StartsWith("[T.") || valtag.StartsWith("[T+") || valtag.StartsWith("[T-")))
                {
                    target_tag = 3;
                    hackset = true;
                }
                if (target_tag == 4 && hackset)
                {
                    target_tag = 3;
                    hackset = false;
                }
                else if (target_tag == 3 && valtag.StartsWith("[H.") == false && valtag.StartsWith("[T.") == false && valtag.StartsWith("[T+") == false && valtag.StartsWith("[T-") == false) target_tag = 4;
                if (target_tag > 4 && valtag.Length <= 4) target_tag--;

                switch (target_tag)
                {
                    case 1:
                        this.Tag1 += valtag;
                        break;
                    case 2:
                        this.Tag2 += valtag;
                        break;
                    case 3:
                        this.Tag3 += valtag;
                        break;
                    case 4:
                        this.Tag4 += valtag;
                        break;
                    case 5:
                        this.Tag5 += valtag;
                        break;
                    case 6:
                        this.Tag6 += valtag;
                        break;
                    case 7:
                        this.Tag7 += valtag;
                        break;
                }
                target_tag++;
            }
        }

        public double GetSizeInMb()
        {
            return ((double)this.SizeInBytes) / (1024.0 * 1024.0);
        }


        static public void AddRom(string title, long sizeInBytes, string iconImg = "")
        {
            Rom.AllRoms.Add(new Rom(title, sizeInBytes, iconImg));
        }
        static internal List<Rom> GetRoms()
        {
            return Rom.AllRoms;
        }

        static public List<Rom> AllRoms = new List<Rom>();
    }

    public class Wildcard
    {
        private readonly string _pattern;

        public Wildcard(string pattern)
        {
            _pattern = pattern;
        }

        public static bool Match(string value, string pattern)
        {
            int start = -1;
            int end = -1;
            return Match(value, pattern, ref start, ref end);
        }

        public static bool Match(string value, string pattern, char[] toLowerTable)
        {
            int start = -1;
            int end = -1;
            return Match(value, pattern, ref start, ref end, toLowerTable);
        }

        public static bool Match(string value, string pattern, ref int start, ref int end)
        {
            return new Wildcard(pattern).IsMatch(value, ref start, ref end);
        }

        public static bool Match(string value, string pattern, ref int start, ref int end, char[] toLowerTable)
        {
            return new Wildcard(pattern).IsMatch(value, ref start, ref end, toLowerTable);
        }

        public bool IsMatch(string str)
        {
            int start = -1;
            int end = -1;
            return IsMatch(str, ref start, ref end);
        }

        public bool IsMatch(string str, char[] toLowerTable)
        {
            int start = -1;
            int end = -1;
            return IsMatch(str, ref start, ref end, toLowerTable);
        }

        public bool IsMatch(string str, ref int start, ref int end)
        {
            if (_pattern.Length == 0) return false;
            int pindex = 0;
            int sindex = 0;
            int pattern_len = _pattern.Length;
            int str_len = str.Length;
            start = -1;
            while (true)
            {
                bool star = false;
                if (_pattern[pindex] == '*')
                {
                    star = true;
                    do
                    {
                        pindex++;
                    }
                    while (pindex < pattern_len && _pattern[pindex] == '*');
                }
                end = sindex;
                int i;
                while (true)
                {
                    int si = 0;
                    bool breakLoops = false;
                    for (i = 0; pindex + i < pattern_len && _pattern[pindex + i] != '*'; i++)
                    {
                        si = sindex + i;
                        if (si == str_len)
                        {
                            return false;
                        }
                        if (str[si] == _pattern[pindex + i])
                        {
                            continue;
                        }
                        if (si == str_len)
                        {
                            return false;
                        }
                        if (_pattern[pindex + i] == '?' && str[si] != '.')
                        {
                            continue;
                        }
                        breakLoops = true;
                        break;
                    }
                    if (breakLoops)
                    {
                        if (!star)
                        {
                            return false;
                        }
                        sindex++;
                        if (si == str_len)
                        {
                            return false;
                        }
                    }
                    else
                    {
                        if (start == -1)
                        {
                            start = sindex;
                        }
                        if (pindex + i < pattern_len && _pattern[pindex + i] == '*')
                        {
                            break;
                        }
                        if (sindex + i == str_len)
                        {
                            if (end <= start)
                            {
                                end = str_len;
                            }
                            return true;
                        }
                        if (i != 0 && _pattern[pindex + i - 1] == '*')
                        {
                            return true;
                        }
                        if (!star)
                        {
                            return false;
                        }
                        sindex++;
                    }
                }
                sindex += i;
                pindex += i;
                if (start == -1)
                {
                    start = sindex;
                }
            }
        }

        public bool IsMatch(string str, ref int start, ref int end, char[] toLowerTable)
        {
            if (_pattern.Length == 0) return false;

            int pindex = 0;
            int sindex = 0;
            int pattern_len = _pattern.Length;
            int str_len = str.Length;
            start = -1;
            while (true)
            {
                bool star = false;
                if (_pattern[pindex] == '*')
                {
                    star = true;
                    do
                    {
                        pindex++;
                    }
                    while (pindex < pattern_len && _pattern[pindex] == '*');
                }
                end = sindex;
                int i;
                while (true)
                {
                    int si = 0;
                    bool breakLoops = false;

                    for (i = 0; pindex + i < pattern_len && _pattern[pindex + i] != '*'; i++)
                    {
                        si = sindex + i;
                        if (si == str_len)
                        {
                            return false;
                        }
                        char c = toLowerTable[str[si]];
                        if (c == _pattern[pindex + i])
                        {
                            continue;
                        }
                        if (si == str_len)
                        {
                            return false;
                        }
                        if (_pattern[pindex + i] == '?' && c != '.')
                        {
                            continue;
                        }
                        breakLoops = true;
                        break;
                    }
                    if (breakLoops)
                    {
                        if (!star)
                        {
                            return false;
                        }
                        sindex++;
                        if (si == str_len)
                        {
                            return false;
                        }
                    }
                    else
                    {
                        if (start == -1)
                        {
                            start = sindex;
                        }
                        if (pindex + i < pattern_len && _pattern[pindex + i] == '*')
                        {
                            break;
                        }
                        if (sindex + i == str_len)
                        {
                            if (end <= start)
                            {
                                end = str_len;
                            }
                            return true;
                        }
                        if (i != 0 && _pattern[pindex + i - 1] == '*')
                        {
                            return true;
                        }
                        if (!star)
                        {
                            return false;
                        }
                        sindex++;
                        continue;
                    }
                }
                sindex += i;
                pindex += i;
                if (start == -1)
                {
                    start = sindex;
                }
            }
        }
    }
}
