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
using System.Threading;
using BrightIdeasSoftware;

namespace ArchiveCacheManager
{


    public partial class ArchiveListWindow : Form
    {
        public string SelectedFile;
        public int EmulatorIndex;
        public bool TagsActive = false;
        public string filter_text = "";
        public bool filter_french = false;
        public bool filter_english = false;
        public bool filter_romhacker = false;


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


            //List<Rom> roms = new List<Rom>();
            Rom.ClearRom();
            int i = 0;
            int selected_index = -1;

            foreach (string fl in fileList)
            {
                string icon_img = "";
                if (fl == priority_file) icon_img = "star_yellow";
                if (fl == selection) icon_img = "star_blue";
                //roms.Add(new Rom(fl.ToString(), sizeList[i], icon_img));
                Rom.AddRom(fl.ToString(), sizeList[i], icon_img);
                if (selection != string.Empty && fl.ToString() == selection) selected_index = i;
                i++;
                    

            }
            this.fastObjectListView1.SetObjects(Rom.GetRoms());
            if (selection != string.Empty && selected_index != -1)
            {
                fastObjectListView1.SelectedIndex = selected_index;
            }
            SelectedFile = string.Empty;
            HideTags();
            //if (Rom.have_french) 
                FilterFrenchToolStripMenuItem1.Visible = true;
            //if (Rom.have_english) 
                FilterEnglishToolStripMenuItem2.Visible = true;
            //if (Rom.have_romhackernet) 
               FilterRHToolStripMenuItem3.Visible = true;

        }

        private void ShowTags()
        {
            this.tag1ColumnF.IsVisible = false;
            this.tag2ColumnF.IsVisible = false;
            this.tag3ColumnF.IsVisible = false;
            this.tag4ColumnF.IsVisible = false;
            this.tag5ColumnF.IsVisible = false;
            this.tag6ColumnF.IsVisible = false;
            this.tag7ColumnF.IsVisible = false;
            this.sizeColumnF.FillsFreeSpace = false;

            bool redraw = false;
            if (Rom.validTagColumns[1])
            {
                redraw = true;
                this.tag1ColumnF.IsVisible = true;
            }
            if (Rom.validTagColumns[2])
            {
                redraw = true;
                this.tag2ColumnF.IsVisible = true;
            }
            if (Rom.validTagColumns[3])
            {
                redraw = true;
                this.tag3ColumnF.IsVisible = true;
            }
            if (Rom.validTagColumns[4])
            {
                redraw = true;
                this.tag4ColumnF.IsVisible = true;
            }
            if (Rom.validTagColumns[5])
            {
                redraw = true;
                this.tag5ColumnF.IsVisible = true;
            }
            if (Rom.validTagColumns[6])
            {
                redraw = true;
                this.tag6ColumnF.IsVisible = true;
            }
            if (Rom.validTagColumns[7])
            {
                redraw = true;
                this.tag7ColumnF.IsVisible = true;
            }
            if (Rom.validTagColumns[8])
            {
                redraw = true;
                this.tag8ColumnF.IsVisible = true;
            }
            if (Rom.validTagColumns[9])
            {
                redraw = true;
                this.tag9ColumnF.IsVisible = true;
            }

            if (redraw)
            {
                this.fastObjectListView1.RebuildColumns();
                this.fastObjectListView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                this.fastObjectListView1.RebuildColumns();
            }
            this.TagsActive = true;
        }

        private void HideTags()
        {
            this.tag1ColumnF.IsVisible = false;
            this.tag2ColumnF.IsVisible = false;
            this.tag3ColumnF.IsVisible = false;
            this.tag4ColumnF.IsVisible = false;
            this.tag5ColumnF.IsVisible = false;
            this.tag6ColumnF.IsVisible = false;
            this.tag7ColumnF.IsVisible = false;
            this.tag8ColumnF.IsVisible = false;
            this.tag9ColumnF.IsVisible = false;
            this.sizeColumnF.FillsFreeSpace = true;
            this.fastObjectListView1.RebuildColumns();
            this.TagsActive = false;
        }



        private void InitializeListView()
        {
            this.titleColumnF.ImageGetter = delegate (object rowObject) {
                Rom s = (Rom)rowObject;
                return s.IconImg;
            };

            this.sizeColumnF.AspectToStringConverter = delegate (object x) {
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
            fastObjectListView1.ItemActivate += new System.EventHandler(this.fastObjectListView1_ItemActivate);
            contextMenuStrip1.Opened += new System.EventHandler(this.contextMenuStrip1_Opened);
            toolStripTextBox1.LostFocus += new System.EventHandler(this.toolStripTextBox1_Leave);
            toolStripTextBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.toolStripTextBox1_CheckEnterKeyPress);

        }

        private void okButton_Click(object sender, EventArgs e)
        {
            SelectedFile = fastObjectListView1.SelectedItem.Text;
            EmulatorIndex = emulatorComboBox.SelectedIndex;
        }



        private void ArchiveListWindow_Load(object sender, EventArgs e)
        {

        }

        private void archiveNameLabel_Click(object sender, EventArgs e)
        {

        }

        private void fastObjectListView1_ItemActivate(object sender, EventArgs e)
        {
            okButton.PerformClick();
            //MessageBox.Show("Activate !");
        }

        private void fastObjectListView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        Control _sourceControl = null;
        private void contextMenuStrip1_Opened(object sender, EventArgs e)
        {
            _sourceControl = contextMenuStrip1.SourceControl;
            //MessageBox.Show(_sourceControl.Name.ToString());
            /*
            if (olvSongs.SelectedIndex > 0) dddToolStripMenuItem.Visible = true;
            else dddToolStripMenuItem.Visible = false;
            */
            if (this.TagsActive)
            {
                
                showTagsToolStripMenuItem.Visible = false;
                hideTagsToolStripMenuItem.Visible = true;
            }
            else
            {
                showTagsToolStripMenuItem.Visible = true;
                hideTagsToolStripMenuItem.Visible = false;
            } 

        }

        /*
        private bool Updatefilter(string input)
        {
            if(input != this.textfilter)
            {
                this.textfilter = input;
                if (this.textfilter.Contains("*"))
                {
                    ModelFilter filter2 = new ModelFilter(delegate (object x) {
                        return ((Rom)x).Match(input);
                    });
                    this.fastObjectListView1.AdditionalFilter = filter2;
                }
                else
                {
                    TextMatchFilter filter1 = TextMatchFilter.Contains(this.fastObjectListView1, this.textfilter);
                    this.fastObjectListView1.AdditionalFilter = filter1;
                }

                return true;
            }
            return false;
        }
        */
        private void Updatefilter()
        {
            List<IModelFilter> filter_list = new List<IModelFilter>();
            if (this.filter_text != "")
            {
                if (this.filter_text.Contains("*") || this.filter_text.Contains("?"))
                {
                    filter_list.Add(new ModelFilter(delegate (object x) {
                        return ((Rom)x).Match(this.filter_text);
                    }));
                }
                else
                {
                    filter_list.Add(TextMatchFilter.Contains(this.fastObjectListView1, this.filter_text));
                }
                toolStripTextBox1.BackColor = Color.Yellow;
            }
            else toolStripTextBox1.BackColor = showTagsToolStripMenuItem.BackColor;

            if (this.filter_french)
            {
                filter_list.Add(new ModelFilter(delegate (object x) {
                    return ((Rom)x).is_french;
                }));
                FilterFrenchToolStripMenuItem1.BackColor = Color.Yellow;
            }
            else FilterFrenchToolStripMenuItem1.BackColor = showTagsToolStripMenuItem.BackColor;

            if (this.filter_english)
            {
                filter_list.Add(new ModelFilter(delegate (object x) {
                    return ((Rom)x).is_english;
                }));
                FilterEnglishToolStripMenuItem2.BackColor = Color.Yellow;
            }
            else FilterEnglishToolStripMenuItem2.BackColor = showTagsToolStripMenuItem.BackColor;

            if (this.filter_romhacker)
            {
                filter_list.Add(new ModelFilter(delegate (object x) {
                    return ((Rom)x).is_romhackernet;
                }));
                FilterRHToolStripMenuItem3.BackColor = Color.Yellow;
            }
            else FilterRHToolStripMenuItem3.BackColor = showTagsToolStripMenuItem.BackColor;

            if (filter_list.Count > 0)
            {
                this.fastObjectListView1.AdditionalFilter = new CompositeAllFilter(filter_list);
                ClearFiltersToolStripMenuItem.Enabled = true;
            }
            else
            {
                this.fastObjectListView1.AdditionalFilter = null;
                ClearFiltersToolStripMenuItem.Enabled = false;
            }


        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }
        private void hideTagsToolStripMenuItem_Click(object sender, EventArgs e)
        {
           this.HideTags();
        }
        
        private void showTagsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ShowTags();
        }
        private void toolStripTextBox1_Leave(object sender, EventArgs e)
        {
            if(toolStripTextBox1.Text != this.filter_text)
            {
                this.filter_text = toolStripTextBox1.Text;
                Updatefilter();
            }
        }
        private void toolStripTextBox1_CheckEnterKeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                // Then Do your Thang
                contextMenuStrip1.Hide();
                if (toolStripTextBox1.Text != this.filter_text)
                {
                    this.filter_text = toolStripTextBox1.Text;
                    Updatefilter();
                }
            }
        }

        private void FilterFrenchToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.filter_french = !this.filter_french;
            Updatefilter();
            //FilterFrenchToolStripMenuItem1.BackColor = Color.Red;
        }

        private void FilterEnglishToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.filter_english = !this.filter_english;
            Updatefilter();
        }

        private void FilterRHToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            this.filter_romhacker = !this.filter_romhacker;
            Updatefilter();
        }

        private void emulatorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ClearFiltersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.filter_english = false;
            this.filter_french = false;
            this.filter_romhacker = false;
            toolStripTextBox1.Text = "";
            this.filter_text = "";
            Updatefilter();
        }
        /*

private void toolStripTextBox1_Click(object sender, EventArgs e)
{

}  */
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
            SetTags();
            SetFiltersVars();
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
        public string Tag8 = "";
        public string Tag9 = "";
        public bool is_french = false;
        public bool is_english = false;
        public bool is_romhackernet = false;


        /*
        public void SetTagsBak()
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
        */

        public void SetFiltersVars()
        {
            string valstr = this.Title.Trim();
            if (valstr.Contains("[T.Fre") || valstr.Contains("[T-Fre") || valstr.Contains("[T+Fre") || valstr.ToUpper().Contains("[FRANCE]") || valstr.ToUpper().Contains("[FR]")){
                this.is_french = true;
                Rom.have_french = true;
            }
            if (valstr.Contains("[T.Eng") || valstr.Contains("[T-Eng") || valstr.Contains("[T+Eng")){
                this.is_english = true;
                Rom.have_english = true;
            }
            if (Regex.Match(valstr, @"\[H\.([^\]]*)-([0-9]+)\]").Success)
            {
                this.is_romhackernet = true;
                Rom.have_romhackernet = true;
            }
        }

        public void SetTags()
        {
            string pattern = @"\[([^[]*)\]";
            RegexOptions options = RegexOptions.Multiline;
            MatchCollection matches = Regex.Matches(this.Title, pattern, options);
            int i = 0;
            int category = -1;
            int is_goodset = -1;
            int target_tag = 6;
            foreach (Match m in matches)
            {
                i++;
                string valtag = m.Value.Trim().ToUpper();
                if (valtag == "[USA]" || valtag == "[EUROPE]" || valtag == "[FRANCE]" || valtag == "[JAPAN]" || valtag == "[AUSTRALIA]" || valtag == "[GERMANY]" || valtag == "[ITALY]")
                {
                    this.Tag1 += m.Value.Trim();
                    validTagColumns[1] = true;
                    continue;
                }

                if (valtag == "[MEGAPACK]" || valtag == "[GRH-MEGAPACK-21]" || valtag == "[SMWH]")
                {
                    category = i + 1;
                    this.Tag2 += m.Value.Trim();
                    validTagColumns[2] = true;
                    continue;
                }
                if (valtag == "[GOODSET]" || valtag == "[N64V]" || valtag == "[RHCOM]" || valtag == "[HTGDB]")
                {
                    if (valtag == "[GOODSET]") is_goodset = i;
                    this.Tag2 += m.Value.Trim();
                    validTagColumns[2] = true;
                    continue;
                }
                if (m.Value.Trim().StartsWith("[H.") || m.Value.Trim().StartsWith("[T.") || m.Value.Trim().StartsWith("[T+") || m.Value.Trim().StartsWith("[T-"))
                {
                    this.Tag3 += m.Value.Trim();
                    validTagColumns[3] = true;
                    continue;
                }
                if (is_goodset > 0 && i > is_goodset && valtag.Contains("HACK"))
                {
                    this.Tag3 += m.Value.Trim();
                    validTagColumns[3] = true;
                    continue;
                }
                if (i == category)
                {
                    this.Tag4 += m.Value.Trim();
                    validTagColumns[4] = true;
                    continue;
                }
                if (valtag.Length<=5)
                {
                    validTagColumns[5] = true;
                    this.Tag5 += m.Value.Trim();
                    continue;
                }
                if(target_tag == 6)
                {
                    validTagColumns[6] = true;
                    this.Tag6 += m.Value.Trim();
                    target_tag++;
                    continue;
                }
                if (target_tag == 7)
                {
                    validTagColumns[7] = true;
                    this.Tag7 += m.Value.Trim();
                    target_tag++;
                    continue;
                }
                if (target_tag == 8)
                {
                    validTagColumns[8] = true;
                    this.Tag8 += m.Value.Trim();
                    target_tag++;
                    continue;
                }
                if (target_tag == 9)
                {
                    validTagColumns[9] = true;
                    this.Tag9 += m.Value.Trim();
                    continue;
                }


            }
        }




        public double GetSizeInMb()
        {
            return ((double)this.SizeInBytes) / (1024.0 * 1024.0);
        }

        public bool Match(string input) {
            return Wildcard.Match(this.Title.ToLower(), input.ToLower().Trim());
        }

        static internal void ClearRom()
        {
            AllRoms.Clear();
            validTagColumns.Clear();
            for (int z = 1; z <= 9; z++)
            {
                validTagColumns[z] = false;
            }
        }
        static internal void AddRom(string title, long sizeInBytes, string iconImg = "")
        {
            AllRoms.Add(new Rom(title, sizeInBytes, iconImg));
        }
        static internal List<Rom> GetRoms()
        {
            return Rom.AllRoms;
        }
        static internal Dictionary<int, bool> GetValidTagColumns()
        {
            return Rom.validTagColumns;
        }
        static public List<Rom> AllRoms = new List<Rom>();
        static public Dictionary<int, bool> validTagColumns = new Dictionary<int, bool>();
        static public bool have_french = false;
        static public bool have_english = false;
        static public bool have_romhackernet = false;


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
