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
using System.Threading;
using BrightIdeasSoftware;



namespace ArchiveCacheManager
{


    public partial class ArchiveListWindow : Form
    {
        public string SelectedFile;
        public int EmulatorIndex;
        public bool TagsActive = false; //Show extra tags columns

        //Additionals filters
        public string filter_text = "";
        public bool filter_french = false;
        public bool filter_english = false;
        public bool filter_romhacker = false;

        //For the copy/Paste savestate of retroarch
        public string base_launchbox_dir = "";
        public string buffer_savestatefile = "";
        public string ArchiveDir = "";
        public string ArchiveName = "";


        //Some parameters where added :
        //archiveDir : The directory of the 7z file
        //sizeList : The size of each file, with the same index as fileList
        //plateform : I need that for determining the "prefered" rom to show a little yellow star
        public ArchiveListWindow(string archiveName, string archiveDir, string[] fileList, long[] sizeList, string plateform, string emulator, string[] emulatorList, string selection = "")
        {
            //We clear the rom class static variable, it must be done first !
            Rom.ClearRom();


            //We fill the directory variables for the save/load savestate
            this.base_launchbox_dir = Directory.GetParent(Path.GetDirectoryName(Application.ExecutablePath)).FullName;
            string retroarch_savedir = this.base_launchbox_dir + "\\Emulators\\RetroArch\\saves";
            string retroarch_savestatedir = this.base_launchbox_dir + "\\Emulators\\RetroArch\\states";
            if (Directory.Exists(retroarch_savedir)) Rom.retroarch_savedir = retroarch_savedir;
            if (Directory.Exists(retroarch_savestatedir)) Rom.retroarch_savestatedir = retroarch_savestatedir;
            this.ArchiveDir = archiveDir;
            this.ArchiveName = archiveName;



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

            //We search the priority file if any :
            string priority_file = "";
            List<string> prioritySections = new List<string>();
            prioritySections.Add(Config.EmulatorPlatformKey(emulator, plateform));
            prioritySections.Add(Config.EmulatorPlatformKey("All", "All"));

            foreach (var prioritySection in prioritySections)
            {
                try
                {
                    string[] extensionPriority = Config.GetFilenamePriority(prioritySection).Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                    // Search the extensions in priority order
                    foreach (string extension in extensionPriority)
                    {
                        foreach (string fl in fileList)
                        {
                            if (Wildcard.Match(fl.ToLower(), string.Format("*{0}", extension.ToLower().Trim())))
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

            //fill the Rom List (a static list within the Rom class) with Roms.

            int i = 0;
            int selected_index = -1;
            foreach (string fl in fileList)
            {
                string icon_img = "";
                if (fl == priority_file) icon_img = "star_yellow";
                if (fl == selection) icon_img = "star_blue";
                Rom.AddRom(fl.ToString(), sizeList[i], icon_img);
                if (selection != string.Empty && fl.ToString() == selection) selected_index = i;
                i++;
            }

            //And set the fastObjectListView1 to use that list
            this.fastObjectListView1.SetObjects(Rom.GetRoms());
            if (selection != string.Empty && selected_index != -1)
            {
                fastObjectListView1.SelectedIndex = selected_index;
            }
            SelectedFile = string.Empty;

            //By default, we hide extra tags
            HideTags();

            //Some option of additional fiters on context menu appears only if there is at least one match
            if (Rom.have_french) MenuItem_filterFrench.Visible = true;
            else MenuItem_filterFrench.Visible = false;

            if (Rom.have_english) MenuItem_filterEnglish.Visible = true;
            else MenuItem_filterEnglish.Visible = false;

            if (Rom.have_romhackernet) MenuItem_filterRH.Visible = true;
            else MenuItem_filterRH.Visible = false;

        }


        //Show the extra tags columns, only show it if there is at least one match
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

            //We redraw to set columns size to fit the contents
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
            //Delegate to show the star image before the Title text
            this.titleColumnF.ImageGetter = delegate (object rowObject) {
                Rom s = (Rom)rowObject;
                return s.IconImg;
            };

            //Delegate to show the size in human readable form, but still keep it internaly as bytes (usefull for sorting)
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
            //To register the double click or enter in the list
            fastObjectListView1.ItemActivate += new System.EventHandler(this.fastObjectListView1_ItemActivate);
            //To execute this function before loading the context menu, usefull to hide some option if no rom is selected
            contextMenuStrip1.Opened += new System.EventHandler(this.contextMenuStrip1_Opened);
            //For the search textbox filter, to validate a new filter text, since there is no "ok" button
            MenuItem_textBoxFilter.LostFocus += new System.EventHandler(this.MenuItem_textBoxFilter_Leave);
            MenuItem_textBoxFilter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MenuItem_textBoxFilter_CheckEnterKeyPress);

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
        }

        private void fastObjectListView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //Executed before the context menu open
        Control _sourceControl = null;
        private void contextMenuStrip1_Opened(object sender, EventArgs e)
        {
            _sourceControl = contextMenuStrip1.SourceControl;

            //If tags columns are active, only show the option to hide them, and the other way around if not
            if (this.TagsActive)
            {
                MenuItem_showTags.Visible = false;
                MenuItem_hideTags.Visible = true;
            }
            else
            {
                MenuItem_showTags.Visible = true;
                MenuItem_hideTags.Visible = false;
            }

            //If a file is selected, some additional features : Copy/paste savestate and extractTo
            if (fastObjectListView1.SelectedIndex >= 0)
            {
                MenuItem_saveCopy.Visible = true;
                MenuItem_pasteCopy.Visible = true;
                MenuItem_extractTo.Visible = true;

                Rom myrom = (Rom)this.fastObjectListView1.SelectedObject;
                //We load the save state, i do that here instead of doing globaly on form load to avoid useless and costly file lookup
                var liste_savestate = myrom.loadSave();
                if (liste_savestate.Count > 0)
                {
                    MenuItem_saveCopy.Enabled = true;
                    MenuItem_saveCopy.Text = string.Format("Copy SaveState ({0})", liste_savestate.Count);
                }
                else
                {
                    MenuItem_saveCopy.Enabled = false;
                    MenuItem_saveCopy.Text = "Copy SaveState";
                }
                MenuItem_loadSaveState0.Enabled = false;
                MenuItem_loadSaveState1.Enabled = false;
                MenuItem_loadSaveState2.Enabled = false;
                MenuItem_loadSaveState3.Enabled = false;
                MenuItem_loadSaveState4.Enabled = false;
                MenuItem_loadSaveState5.Enabled = false;
                MenuItem_loadSaveState6.Enabled = false;
                MenuItem_loadSaveState7.Enabled = false;
                MenuItem_loadSaveState8.Enabled = false;
                MenuItem_loadSaveState9.Enabled = false;
                foreach (var savestate in liste_savestate)
                {
                    switch (savestate.Key)
                    {
                        case 0:
                            MenuItem_loadSaveState0.Enabled = true;
                            break;
                        case 1:
                            MenuItem_loadSaveState1.Enabled = true;
                            break;
                        case 2:
                            MenuItem_loadSaveState2.Enabled = true;
                            break;
                        case 3:
                            MenuItem_loadSaveState3.Enabled = true;
                            break;
                        case 4:
                            MenuItem_loadSaveState4.Enabled = true;
                            break;
                        case 5:
                            MenuItem_loadSaveState5.Enabled = true;
                            break;
                        case 6:
                            MenuItem_loadSaveState6.Enabled = true;
                            break;
                        case 7:
                            MenuItem_loadSaveState7.Enabled = true;
                            break;
                        case 8:
                            MenuItem_loadSaveState8.Enabled = true;
                            break;
                        case 9:
                            MenuItem_loadSaveState9.Enabled = true;
                            break;
                    }
                }

                if (this.buffer_savestatefile != "")
                {
                    MenuItem_pasteCopy.Enabled = true;
                    MenuItem_pasteSaveState0.Text = "Slot 0 <empty>";
                    MenuItem_pasteSaveState1.Text = "Slot 1 <empty>";
                    MenuItem_pasteSaveState2.Text = "Slot 2 <empty>";
                    MenuItem_pasteSaveState3.Text = "Slot 3 <empty>";
                    MenuItem_pasteSaveState4.Text = "Slot 4 <empty>";
                    MenuItem_pasteSaveState5.Text = "Slot 5 <empty>";
                    MenuItem_pasteSaveState6.Text = "Slot 6 <empty>";
                    MenuItem_pasteSaveState7.Text = "Slot 7 <empty>";
                    MenuItem_pasteSaveState8.Text = "Slot 8 <empty>";
                    MenuItem_pasteSaveState9.Text = "Slot 9 <empty>";

                    MenuItem_pasteSaveState0.BackColor = MenuItem_showTags.BackColor;
                    MenuItem_pasteSaveState1.BackColor = MenuItem_showTags.BackColor;
                    MenuItem_pasteSaveState2.BackColor = MenuItem_showTags.BackColor;
                    MenuItem_pasteSaveState3.BackColor = MenuItem_showTags.BackColor;
                    MenuItem_pasteSaveState4.BackColor = MenuItem_showTags.BackColor;
                    MenuItem_pasteSaveState5.BackColor = MenuItem_showTags.BackColor;
                    MenuItem_pasteSaveState6.BackColor = MenuItem_showTags.BackColor;
                    MenuItem_pasteSaveState7.BackColor = MenuItem_showTags.BackColor;
                    MenuItem_pasteSaveState8.BackColor = MenuItem_showTags.BackColor;
                    MenuItem_pasteSaveState9.BackColor = MenuItem_showTags.BackColor;

                    foreach (var savestate in liste_savestate)
                    {
                        switch (savestate.Key)
                        {
                            case 0:
                                MenuItem_pasteSaveState0.Text = "Slot 0";
                                MenuItem_pasteSaveState0.BackColor = Color.Red;
                                break;
                            case 1:
                                MenuItem_pasteSaveState1.Text = "Slot 1";
                                MenuItem_pasteSaveState1.BackColor = Color.Red;
                                break;
                            case 2:
                                MenuItem_pasteSaveState2.Text = "Slot 2";
                                MenuItem_pasteSaveState2.BackColor = Color.Red;
                                break;
                            case 3:
                                MenuItem_pasteSaveState3.Text = "Slot 3";
                                MenuItem_pasteSaveState3.BackColor = Color.Red;
                                break;
                            case 4:
                                MenuItem_pasteSaveState4.Text = "Slot 4";
                                MenuItem_pasteSaveState4.BackColor = Color.Red;
                                break;
                            case 5:
                                MenuItem_pasteSaveState5.Text = "Slot 5";
                                MenuItem_pasteSaveState5.BackColor = Color.Red;
                                break;
                            case 6:
                                MenuItem_pasteSaveState6.Text = "Slot 6";
                                MenuItem_pasteSaveState6.BackColor = Color.Red;
                                break;
                            case 7:
                                MenuItem_pasteSaveState7.Text = "Slot 7";
                                MenuItem_pasteSaveState7.BackColor = Color.Red;
                                break;
                            case 8:
                                MenuItem_pasteSaveState8.Text = "Slot 8";
                                MenuItem_pasteSaveState8.BackColor = Color.Red;
                                break;
                            case 9:
                                MenuItem_pasteSaveState9.Text = "Slot 9";
                                MenuItem_pasteSaveState9.BackColor = Color.Red;
                                break;
                        }
                    }

                }
                else
                {
                    MenuItem_pasteCopy.Enabled = false;
                }

                if (Zip.SupportedType(myrom.Title))
                {
                    MenuItem_extractTo.Visible = true;
                }

            }
            else
            {
                MenuItem_saveCopy.Visible = false;
                MenuItem_pasteCopy.Visible = false;
                MenuItem_extractTo.Visible = false;
            }


        }

        //The 10 MenuItem_loadSaveState point to the same function, we use the last character to determine the slot
        private void MenuItem_loadSaveState_Click(object sender, EventArgs e)
        {
            var MenuItem = (System.Windows.Forms.ToolStripMenuItem)sender;
            string lastCharacter = MenuItem.Name.ToString().Substring(MenuItem.Name.ToString().Length - 1);
            int slot = Int32.Parse(lastCharacter);
            var selected_rom = (Rom)fastObjectListView1.SelectedObject;
            this.buffer_savestatefile = selected_rom.loadSave(false)[slot];
        }

        private void MenuItem_pasteSaveState_Click(object sender, EventArgs e)
        {
            var MenuItem = (System.Windows.Forms.ToolStripMenuItem)sender;
            string lastCharacter = MenuItem.Name.ToString().Substring(MenuItem.Name.ToString().Length - 1);
            int slot = Int32.Parse(lastCharacter);
            var selected_rom = (Rom)fastObjectListView1.SelectedObject;
            string state_str = ".state";
            if (slot > 0) state_str = state_str + slot.ToString();
            string out_savestatefile = Path.GetDirectoryName(this.buffer_savestatefile) + "\\" + selected_rom.TitleWithoutExt + state_str;
            if (File.Exists(out_savestatefile))
            {
                File.Delete(out_savestatefile);
            }
            File.Copy(this.buffer_savestatefile, out_savestatefile);
            this.buffer_savestatefile = "";
            selected_rom.loadSave(true);
        }

        //Function to update filters, we use addionals filters to be able to use it alongside the filter option from right click on a menu header.
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
                MenuItem_textBoxFilter.BackColor = Color.Yellow;
            }
            else MenuItem_textBoxFilter.BackColor = MenuItem_showTags.BackColor;

            if (this.filter_french)
            {
                filter_list.Add(new ModelFilter(delegate (object x) {
                    return ((Rom)x).is_french;
                }));
                MenuItem_filterFrench.BackColor = Color.Yellow;
            }
            else MenuItem_filterFrench.BackColor = MenuItem_showTags.BackColor;

            if (this.filter_english)
            {
                filter_list.Add(new ModelFilter(delegate (object x) {
                    return ((Rom)x).is_english;
                }));
                MenuItem_filterEnglish.BackColor = Color.Yellow;
            }
            else MenuItem_filterEnglish.BackColor = MenuItem_showTags.BackColor;

            if (this.filter_romhacker)
            {
                filter_list.Add(new ModelFilter(delegate (object x) {
                    return ((Rom)x).is_romhackernet;
                }));
                MenuItem_filterRH.BackColor = Color.Yellow;
            }
            else MenuItem_filterRH.BackColor = MenuItem_showTags.BackColor;

            if (filter_list.Count > 0)
            {
                this.fastObjectListView1.AdditionalFilter = new CompositeAllFilter(filter_list);
                MenuItem_clearFilters.Enabled = true;
            }
            else
            {
                this.fastObjectListView1.AdditionalFilter = null;
                MenuItem_clearFilters.Enabled = false;
            }


        }

        private void MenuItem_textBoxFilter_Click(object sender, EventArgs e)
        {

        }
        private void MenuItem_hideTags_Click(object sender, EventArgs e)
        {
            this.HideTags();
        }

        private void MenuItem_showTags_Click(object sender, EventArgs e)
        {
            this.ShowTags();
        }
        private void MenuItem_textBoxFilter_Leave(object sender, EventArgs e)
        {
            if (MenuItem_textBoxFilter.Text != this.filter_text)
            {
                this.filter_text = MenuItem_textBoxFilter.Text;
                Updatefilter();
            }
        }
        private void MenuItem_textBoxFilter_CheckEnterKeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                // Then Do your Thang
                contextMenuStrip1.Hide();
                if (MenuItem_textBoxFilter.Text != this.filter_text)
                {
                    this.filter_text = MenuItem_textBoxFilter.Text;
                    Updatefilter();
                }
            }
        }

        private void MenuItem_filterFrench_Click(object sender, EventArgs e)
        {
            this.filter_french = !this.filter_french;
            Updatefilter();
        }

        private void MenuItem_filterEnglish_Click(object sender, EventArgs e)
        {
            this.filter_english = !this.filter_english;
            Updatefilter();
        }

        private void MenuItem_filterRH_Click(object sender, EventArgs e)
        {
            this.filter_romhacker = !this.filter_romhacker;
            Updatefilter();
        }

        private void emulatorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void MenuItem_clearFilters_Click(object sender, EventArgs e)
        {
            this.filter_english = false;
            this.filter_french = false;
            this.filter_romhacker = false;
            MenuItem_textBoxFilter.Text = "";
            this.filter_text = "";
            Updatefilter();
        }


        private void MenuItem_extractTo_Click(object sender, EventArgs e)
        {
            if (fastObjectListView1.SelectedIndex >= 0)
            {
                Rom myrom = (Rom)this.fastObjectListView1.SelectedObject;
                saveFileDialog_extractTo.Filter = "Rom|*" + Path.GetExtension(myrom.Title);
                saveFileDialog_extractTo.Title = "Save Rom";
                saveFileDialog_extractTo.FileName = myrom.Title;
                saveFileDialog_extractTo.ShowDialog();
            }
        }

        private void saveFileDialog_extractTo_FileOk(object sender, CancelEventArgs e)
        {
            if (fastObjectListView1.SelectedIndex >= 0)
            {
                Rom myrom = (Rom)this.fastObjectListView1.SelectedObject;
                string[] includelist = new string[1];
                includelist[0] = myrom.Title;

                string dir_out = Path.GetDirectoryName(saveFileDialog_extractTo.FileName);
                string file_out = Path.GetFileName(saveFileDialog_extractTo.FileName);
                string temp_out = dir_out + "\\" + myrom.Title;

                if (file_out == myrom.Title)
                {
                    if (File.Exists(saveFileDialog_extractTo.FileName))
                    {
                        File.Delete(saveFileDialog_extractTo.FileName);
                    }
                    new ArchiveCacheManager.Zip().Extract(this.ArchiveDir + "\\" + this.ArchiveName, dir_out, includelist, null);
                }
                else
                {
                    //Ok, so to extract and rename a file with a single command line, maybe something like this would be better :   7z e my-compressed-file.7z -so readme.txt > new-filename.txt
                    //But i don't want to bother and just use the Zip class, so i will use Rename & Move
                    if (File.Exists(saveFileDialog_extractTo.FileName))
                    {
                        File.Delete(saveFileDialog_extractTo.FileName);
                    }

                    //If the temp file already exist, we rename it, and we will restore it after
                    string restore_file = "";
                    if (File.Exists(temp_out))
                    {
                        int i = 0;
                        restore_file = temp_out + ".bak" + i.ToString();
                        while (File.Exists(restore_file))
                        {
                            i++;
                            restore_file = temp_out + ".bak" + i.ToString();
                        }
                        File.Move(temp_out, restore_file);
                    }

                    new ArchiveCacheManager.Zip().Extract(this.ArchiveDir + "\\" + this.ArchiveName, dir_out, includelist, null);
                    File.Move(temp_out, saveFileDialog_extractTo.FileName);

                    if (restore_file != "")
                    {
                        File.Move(restore_file, temp_out);
                    }

                }
                MessageBox.Show("Done !");
            }
        }
    }

}
