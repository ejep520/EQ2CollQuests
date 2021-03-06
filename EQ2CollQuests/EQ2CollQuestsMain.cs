﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace EQ2CollQuests
{
    public partial class EQ2CollQuestsMain : Form
    {
        public struct AdvKeyEntry
        {
            public short Key;
            public string Value;
        }
        public struct ServerEntry
        {
            public short ServerID;
            public string ServerName;
        }
        /// <value>The multiplier on need for items in &quot;Expert&quot; collections.</value>
        internal double ExpertMult
        {
            get => _ExpertMult;
            set
            {
                if (value == _ExpertMult)
                    return;
                else if (value <= 0)
                    return;
                else
                {
                    _ExpertMult = value;
                    dirties[1] = true;
                    StatusStripDirtyIndicator.Text = FloppyString;
                }
            }
        }
        /// <value>
        ///     <list type="bullet">
        ///         <item>
        ///             <term>true</term>
        ///             <description>The program is allowed to go online for info.</description>
        ///         </item>
        ///         <item>
        ///             <term>false</term>
        ///             <description>The program is NOT allowed to go online for info.</description>
        ///         </item>
        ///     </list>
        /// </value>
        internal bool GoOnline
        {
            get { return _GoOnline; }
            set
            {
                if (value == _GoOnline)
                    return;
                else
                {
                    _GoOnline = value;
                    dirties[1] = true;
                    StatusStripDirtyIndicator.Text = FloppyString;
                }
            }
        }
        /// <value>
        ///     <list type="bullet">
        ///         <item>
        ///             <term>true</term>
        ///             <description>Indent XML save files, making them human readable.</description>
        ///         </item>
        ///         <item>
        ///             <term>false</term>
        ///             <description>Do not indent XML files, or include other white space, saving disk space.</description>
        ///         </item>
        ///     </list>
        /// </value>
        internal bool IndentXml
        {
            get { return _IndentXml; }
            set
            {
                if (value == _IndentXml)
                    return;
                else
                {
                    _IndentXml = value;
                    dirties[0] = true;
                    dirties[1] = true;
                    dirties[2] = true;
                    dirties[3] = true;
                    StatusStripDirtyIndicator.Text = FloppyString;
                    SaveChars();
                    SaveItems();
                    SaveSettings();
                    SaveQuests();
                }
            }
        }
        internal bool HideCompletedOnChar
        {
            get => _HideCompletedOnChar;
            set
            {
                if (value == _HideCompletedOnChar)
                    return;
                if (value ^ _HideCompletedOnChar)
                {
                    dirties[1] = true;
                    UpdateDirtiesStatus();
                    _HideCompletedOnChar = value;
                }
            }
        }
        private bool _GoOnline = true, _IndentXml = true, _HideCompletedOnChar = false;
        private double _ExpertMult = 1.5;
        /// <summary>Dirty Flags</summary>
        /// <value>
        ///     <list type="bullet">
        ///         <item>
        ///             <term>0</term>
        ///             <description>Character info dirty flag</description>
        ///         </item>
        ///         <item>
        ///             <term>1</term>
        ///             <description>Settings dirty flag</description>
        ///         </item>
        ///         <item>
        ///             <term>2</term>
        ///             <description>Items info dirty flag</description>
        ///         </item>
        ///         <item>
        ///             <term>3</term>
        ///             <description>Quests info dirty flag</description>
        ///         </item>
        ///     </list>
        /// </value>
        private readonly bool[] dirties = { false, false, false, false };
        private short MaxAdvLvl;
        /// <value>
        ///     <list type="bullet">
        ///         <item>
        ///             <term>0</term>
        ///             <description>Character File</description>
        ///         </item>
        ///         <item>
        ///             <term>1</term>
        ///             <description>Settings File</description>
        ///         </item>
        ///         <item>
        ///             <term>2</term>
        ///             <description>Items File</description>
        ///         </item>
        ///         <item>
        ///             <term>3</term>
        ///             <description>Quests File</description>
        ///         </item>
        ///     </list>
        /// </value>
        private readonly string[] AllBad = { Program.BadChar, Program.BadSetts, Program.BadItems, Program.BadQuest };
        /// <inheritdoc cref="AllBad"/>
        private readonly string[] AllTemp = { Program.TempChar, Program.TempSetts, Program.TempItems, Program.TempQuest };
        /// <inheritdoc cref="AllBad"/>
        private readonly string[] AllDef = { Program.DefChar, Program.DefSetts, Program.DefItems, Program.DefQuest };
        /// <inheritdoc cref="AllBad"/>
        private readonly string[] AllBak = { Program.BakChar, Program.BakSetts, Program.BakItems, Program.BakQuest };
        private readonly string[] UnicodeCheckEx = { char.ConvertFromUtf32(0x2713), char.ConvertFromUtf32(0x1F6AB) };
        private readonly string FloppyString = char.ConvertFromUtf32(0x1F5AA);
        public EQ2CollQuestsMain()
        {
            InitializeComponent();
            bool loadData = true;
            if (!Directory.Exists(Path.GetDirectoryName(Program.DefChar)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(Program.DefChar));
                loadData = false;
            }
            if (!Directory.Exists(Path.GetDirectoryName(Program.DefItems)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(Program.DefItems));
                loadData = false;
            }

            if (loadData)
                LoadData();
            else
            {
                Program.charList.Clear();
                Program.itemList.Clear();
                Program.questList.Clear();
            }
            if ((Program.AdvClasses.Count == 0) && (Program.serverList.Count == 0))
            {
                GetConstants();
                dirties[1] = true;
                UpdateDirtiesStatus();
            }
            else if (Program.AdvClasses.Count == 0)
            {
                GetAdvClasses();
                dirties[1] = true;
                UpdateDirtiesStatus();
            }
            else if (Program.serverList.Count == 0)
            {
                GetServers();
                dirties[1] = true;
                UpdateDirtiesStatus();
            }
            characterPageToolStripMenuItem.Checked = true;
            TabControlStrip1.SelectedTab = CharacterPage;
            UpdateDirtiesStatus();
            UpdChar.Enabled = false;
            DelChar.Enabled = false;
            ItemsEQ2iLink.Links.Clear();
            ItemsEQ2iLink.Links.Add(0, 4);
            ItemsEQ2iLink.Links.Add(7, 4);
            ItemsEQ2iLink.Links[0].Enabled = false;
            ItemsEQ2iLink.Links[1].Enabled = false;
            QuestsLinkLabel.Links.Clear();
            QuestsLinkLabel.Links.Add(0, 4);
            QuestsLinkLabel.Links.Add(7, 4);
            QuestsLinkLabel.Links[0].Enabled = false;
            QuestsLinkLabel.Links[1].Enabled = false;
        }
        ~EQ2CollQuestsMain() { }
        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ = new AboutForm().ShowDialog(this);
        }
        private void AllItemsPresentCheck()
        {
            Cursor.Current = Cursors.WaitCursor;
            List<long> MissingItems = new List<long>();
            ConcurrentBag<QuestItem> FoundItems = new ConcurrentBag<QuestItem>();
            foreach (CollQuest ThisQuest in Program.questList.Values)
            {
                foreach (long ThisItem in ThisQuest.items)
                {
                    if (Program.itemList.ContainsKey(ThisItem))
                        continue;
                    else
                        MissingItems.Add(ThisItem);
                }
            }
            if (Convert.ToBoolean(MissingItems.Count))
            {
                Parallel.ForEach(MissingItems, MissedItem =>
                {
                    try { FoundItems.Add(new QuestItem(MissedItem)); }
                    catch (Exception Err)
                    {
                        BadEnd();
                        throw Err;
                    }
                });
                foreach (QuestItem ThisItem in FoundItems)
                    Program.itemList[ThisItem.DaybreakID] = ThisItem;
                dirties[2] = true;
                StatusStripDirtyIndicator.Text = FloppyString;
            }
            Cursor.Current = Cursors.Default;
            _ = (short)0;
        }
        /// <summary>
        ///     <para>
        ///     Checks for the existence of temporary files and moves them to the &quot;My Documents&quot;
        ///     folder if they exist.
        ///     </para>
        /// </summary>
        public void BadEnd()
        {
            SaveData();
            for (int counter = 0; counter < 4; counter++)
            {
                if (File.Exists(AllTemp[counter]) && (new FileInfo(AllTemp[counter]).Length > 0))
                {
                    if (File.Exists(AllBad[counter]))
                        File.Delete(AllBad[counter]);
                    if (new FileInfo(AllTemp[counter]).Length > 0)
                        File.Move(AllTemp[counter], AllBad[counter]);
                }
                else if (File.Exists(AllTemp[counter]) && (new FileInfo(AllTemp[counter]).Length == 0))
                {
                    File.Delete(AllTemp[counter]);
                }
            }
        }
        private void CharacterPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((TabControlStrip1.SelectedTab == CharacterPage) && characterPageToolStripMenuItem.Checked)
                return;
            TabControlStrip1.SelectedTab = CharacterPage;
        }
        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Control ctrl = ActiveControl;
            if (ctrl != null)
            {
                if (ctrl is TextBox tx)
                {
                    tx.Copy();
                }
                else if (ctrl is ComboBox cb)
                {
                    Clipboard.SetText(cb.SelectedText);
                }
            }

        }
        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Control ctrl = ActiveControl;
            if (ctrl != null)
            {
                if (ctrl is TextBox tx)
                {
                    tx.Cut();
                }
                else if (ctrl is ComboBox cb)
                {
                    int sPos = cb.SelectionStart;
                    string Copied = cb.SelectedText;
                    cb.SelectedText = cb.SelectedText.Replace(Copied, string.Empty);
                    cb.SelectionStart = sPos;
                    Clipboard.SetText(Copied);
                }
            }
        }
        private void EQ2CollQuestsMainClosing(object sender, FormClosingEventArgs e)
        {
            if (dirties[0] || dirties[1] || dirties[2] || dirties[3])
            {
                if (MessageBox.Show("You have unsaved data! Do you want to save before you exit?",
                    "Save Before Exit?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    == DialogResult.Yes)
                {
                    SaveData(true);
                }
            }
            for (int counter = 0; counter < 4; counter++)
            {
                if (File.Exists(AllTemp[counter]))
                    File.Delete(AllTemp[counter]);
            }
        }
        private void EQ2CollQuestsMain_Enter(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(PlayingAsComboBox.Text))
                PlayingAsComboBox.Text = "Playing as...";
            if (Cursor.Current == null)
                Cursor.Current = Cursors.Default;
        }
        private void EQ2CollQuestsMain_MouseEnter(object sender, EventArgs e)
        {
            if (Cursor.Current == null)
                Cursor.Current = Cursors.Default;
        }
        private void EQ2CollQuestsMain_Resize(object sender, EventArgs e)
        {
            TabControlStrip1.Location = new Point(menuStrip1.Left, menuStrip1.Bottom);
            TabControlStrip1.Height = statusStrip1.Top - statusStrip1.Margin.Top - menuStrip1.Bottom - menuStrip1.Margin.Bottom;
        }
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        /// <summary>
        /// Gets the maximum adventure level and dictionary of adventure classes from the
        /// Daybreak Games Census server.
        /// </summary>
        private void GetAdvClasses()
        {
            XDocument ConstDoc = Program.GetThisURL(@"constants/?c:show=maxadventurelevel,adventureclass_list");
            XElement ConstElem = ConstDoc.Root.Element("constants");
            string RawName, ClassName;
            MaxAdvLvl = short.Parse(ConstElem.Attribute("maxadventurelevel").Value);
            foreach (XElement thisClass in ConstElem.Element("adventureclass_list").Elements("adventureclass"))
            {
                RawName = thisClass.Attribute("name").Value;
                ClassName = string.Concat(RawName.Substring(0, 1).ToUpper(), RawName.Substring(1, RawName.Length - 1));
                Program.AdvClasses[short.Parse(thisClass.Attribute("id").Value)] = ClassName;
            }
        }
        private void GetConstants()
        {
            GetAdvClasses();
            GetServers();
        }
        private void GetServers()
        {
            int BigEnufQ = 25;
            XDocument WorldsDoc;
            XElement WorldListElem;
            do
            {
                BigEnufQ *= 2;
                WorldsDoc = Program.GetThisURL(string.Concat(@"world/?c:limit=", BigEnufQ.ToString(), @"&c:show=name,id"));
                WorldListElem = WorldsDoc.Root;
            } while (WorldListElem.Elements("world").ToList().Count == BigEnufQ);
            string WorldName;
            short WorldID;
            foreach (XElement ThisWorld in WorldListElem.Elements("world"))
            {
                WorldID = short.Parse(ThisWorld.Attribute("id").Value);
                WorldName = ThisWorld.Attribute("name").Value;
                Program.serverList[WorldID] = WorldName;
            }
        }
        private void HelpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, Program.HelpMain);
        }
        private void ItemsPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabControlStrip1.SelectedTab = ItemsPage;
        }
        /// <summary>Attempts to load data from &quot;My Documents&quot; and &quot;&lt;user&gt;\appdata\local\EQ2CollQuests&quot;</summary>
        private void LoadData()
        {
            DialogResult ReplaceMissingFile;
            FileStream InStream;
            XmlSerializer xmlSerializer;
            string BoxMessage;
            for (int counter = 0; counter < 4; counter++)
            {
                switch (counter)
                {
                    case 0:
                        BoxMessage = "The character file is missing, but the backup file was found. Load this instead?";
                        break;
                    case 1:
                        BoxMessage = "The settings file is missing, but the backup file was found. Load this instead?";
                        break;
                    case 2:
                        BoxMessage = "The items file is missing, but the backup file was found. Load this instead?";
                        break;
                    default:
                        BoxMessage = "The quests file is missing, but the backup file was found. Load this instead?";
                        break;
                }
                if (File.Exists(AllBak[counter]) && !File.Exists(AllDef[counter]))
                {
                    ReplaceMissingFile = MessageBox.Show(BoxMessage,
                        "Missing Default Characters!",
                        MessageBoxButtons.YesNo);
                    if (ReplaceMissingFile == DialogResult.Yes)
                        File.Move(AllBak[counter], AllDef[counter]);
                    else
                        File.Delete(AllBak[counter]);
                }
            }
            for (int counter = 0; counter < 4; counter++)
            {
                try { InStream = File.OpenRead(AllDef[counter]); }
                catch (FileNotFoundException) { continue; }
                switch (counter)
                {
                    case 0:
                        xmlSerializer = new XmlSerializer(typeof(List<Characters>));
                        List<Characters> InChars = (List<Characters>)xmlSerializer.Deserialize(InStream);
                        InStream.Dispose();
                        foreach (Characters ThisChar in InChars)
                            Program.charList[ThisChar.DaybreakID] = ThisChar;
                        break;
                    case 1:
                        Type[] types = { typeof(double), typeof(bool), typeof(short),
                            typeof(List<AdvKeyEntry>), typeof(List<ServerEntry>) };
                        XmlSerializer[] serializers = XmlSerializer.FromTypes(types);
                        XmlReader xmlReader = XmlReader.Create(InStream);
                        xmlReader.MoveToContent();
                        xmlReader.ReadStartElement("Root");
                        _ExpertMult = (double)serializers[0].Deserialize(xmlReader);
                        _GoOnline = (bool)serializers[1].Deserialize(xmlReader);
                        _IndentXml = (bool)serializers[1].Deserialize(xmlReader);
                        try { _HideCompletedOnChar = (bool)serializers[1].Deserialize(xmlReader); }
                        catch (InvalidOperationException) { dirties[1] = true; }
                        MaxAdvLvl = (short)serializers[2].Deserialize(xmlReader);
                        List<AdvKeyEntry> TempKeys = (List<AdvKeyEntry>)serializers[3].Deserialize(xmlReader);
                        List<ServerEntry> TempServers = (List<ServerEntry>)serializers[4].Deserialize(xmlReader);
                        foreach (AdvKeyEntry thisEntry in TempKeys)
                            Program.AdvClasses[thisEntry.Key] = thisEntry.Value;
                        if (TempServers == null)
                            GetServers();
                        else
                        {
                            foreach (ServerEntry thisEntry in TempServers)
                                Program.serverList[thisEntry.ServerID] = thisEntry.ServerName;
                        }
                        xmlReader.Dispose();
                        InStream.Dispose();
                        break;
                    case 2:
                        xmlSerializer = new XmlSerializer(typeof(List<QuestItem>));
                        List<QuestItem> InItems = (List<QuestItem>)xmlSerializer.Deserialize(InStream);
                        InStream.Dispose();
                        foreach (QuestItem ThisItem in InItems)
                            Program.itemList[ThisItem.DaybreakID] = ThisItem;
                        break;
                    case 3:
                        xmlSerializer = new XmlSerializer(typeof(List<CollQuest>));
                        List<CollQuest> InQuests = (List<CollQuest>)xmlSerializer.Deserialize(InStream);
                        InStream.Dispose();
                        foreach (CollQuest ThisQuest in InQuests)
                            Program.questList[ThisQuest.DaybreakID] = ThisQuest;
                        break;
                    default:
                        break;
                }
            }
            UpdateDirtiesStatus();
            AllItemsPresentCheck();
        }
        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Control ctrl = ActiveControl;
            if (ctrl != null)
            {
                if (ctrl is TextBox tb)
                {
                    tb.Paste();
                }
                else if (ctrl is ComboBox cb)
                {
                    string InText = Clipboard.GetText();
                    int sPos = cb.SelectionStart;
                    if (!string.IsNullOrEmpty(cb.SelectedText))
                        cb.SelectedText = cb.SelectedText.Replace(cb.SelectedText, InText);
                    else
                    {
                        cb.Text = cb.Text.Insert(cb.SelectionStart, InText);
                        cb.SelectionStart = sPos + InText.Length;
                    }
                }
            }
        }
        private void PlayingAsComboBox_Leave(object sender, EventArgs e)
        {
            PlayingAsComboBox.Text = "Playing as...";
        }
        private void PlayingAsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PlayingAsComboBox.SelectedIndex == -1)
                return;
            Playing playing = new Playing((PlayingAsComboBox.SelectedItem as Characters).DaybreakID, ExpertMult);
            PlayingAsComboBox.Text = (PlayingAsComboBox.SelectedItem as Characters).name;
            DialogResult PlayResult = playing.ShowDialog();
            if (PlayResult == DialogResult.OK)
            {
                foreach (KeyValuePair<long, Characters> ThisChar in playing.ServerMates)
                {
                    Program.charList[ThisChar.Key] = ThisChar.Value;
                }
                dirties[0] = true;
                UpdateDirtiesStatus();
            }
            else if (PlayResult == DialogResult.Abort)
            {
                BadEnd();
                throw playing.ReturnedException;
            }
            SaveData();
            playing.Dispose();
            PlayingAsComboBox.SelectedIndex = -1;
            _ = CharListBox.Focus();
            CharListBox.SelectedIndex = -1;
            PlayingAsComboBox.Text = "Playing as...";
        }
        private void QuestsPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabControlStrip1.SelectedTab = QuestsPage;
        }
        private void ReloadFromDiskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult YouSure = MessageBox.Show("Are you sure you want to continue?\nYou will lose all unsaved changes!",
                "Confirm Reload",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);
            if (YouSure != DialogResult.Yes)
                return;
            Program.charList.Clear();
            Program.itemList.Clear();
            Program.questList.Clear();
            LoadData();
            Refresh();
        }
        /// <summary>Writes the list of characters in <see cref="Program.charList"/> to <see cref="Program.TempChar"/>.</summary>
        private void SaveChars()
        {
            FileStream OutStream = File.Create(Program.TempChar);
            XmlWriter xmlWriter = XmlWriter.Create(OutStream, new XmlWriterSettings() { Indent = IndentXml });
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Characters>));
            xmlSerializer.Serialize(xmlWriter, Program.charList.Values.ToList());
            xmlWriter.Flush();
            OutStream.Flush();
            xmlWriter.Dispose();
            OutStream.Dispose();
        }
        /// <summary> Runs all lesser Save methods in no special order.</summary>
        /// <param name="CleanSave">
        ///     <list type="bullet">
        ///         <item>
        ///             <term>true</term>
        ///             <description>After data is saved to temporary files, move those files out to their default locations, then return.</description>
        ///         </item>
        ///         <item>
        ///             <term>false</term>
        ///             <description>After data is saved to temporary files, return to the calling method.</description>
        ///         </item>
        ///     </list>
        /// </param>
        public void SaveData(bool CleanSave = false)
        {
            SaveChars();
            SaveItems();
            SaveQuests();
            SaveSettings();
            if (CleanSave)
            {
                for (int counter = 0; counter < 4; counter++)
                {
                    if (dirties[counter] || (!File.Exists(AllDef[counter])))
                    {
                        if (dirties[counter])
                        {
                            dirties[counter] = false;
                            StatusStripDirtyIndicator.Text = string.Empty;
                        }
                        if (File.Exists(AllBak[counter]))
                            File.Delete(AllBak[counter]);
                        if (File.Exists(AllDef[counter]))
                            File.Move(AllDef[counter], AllBak[counter]);
                        File.Move(AllTemp[counter], AllDef[counter]);
                    }
                    else
                        File.Delete(AllTemp[counter]);
                }
            }
        }
        /// <summary>Writes <see cref="Program.itemList"/> to <see cref="Program.TempItems"/>.</summary>
        private void SaveItems()
        {
            FileStream OutStream = File.Create(Program.TempItems);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<QuestItem>));
            XmlWriter xmlWriter = XmlWriter.Create(OutStream, new XmlWriterSettings() { Indent = IndentXml });
            xmlSerializer.Serialize(xmlWriter, Program.itemList.Values.ToList());
            xmlWriter.Flush();
            xmlWriter.Dispose();
            OutStream.Flush();
            OutStream.Dispose();
        }
        /// <summary>Writes the existing settings to <see cref="Program.TempSetts"/>.</summary>
        private void SaveSettings()
        {
            FileStream OutStream = File.Create(Program.TempSetts);
            XmlWriter xmlWriter = XmlWriter.Create(OutStream, new XmlWriterSettings() { Indent = IndentXml });
            List<AdvKeyEntry> TempKeys = new List<AdvKeyEntry>();
            List<ServerEntry> TempServers = new List<ServerEntry>();
            foreach (KeyValuePair<short, string> thisPair in Program.AdvClasses)
                TempKeys.Add(new AdvKeyEntry() { Key = thisPair.Key, Value = thisPair.Value });
            foreach (KeyValuePair<short, string> thisPair in Program.serverList)
                TempServers.Add(new ServerEntry() { ServerID = thisPair.Key, ServerName = thisPair.Value });
            Type[] SerializeThese = { typeof(double), typeof(bool), typeof(short), typeof(List<AdvKeyEntry>), typeof(List<ServerEntry>) };
            XmlSerializer[] xmlSerializers = XmlSerializer.FromTypes(SerializeThese);
            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("Root");
            xmlSerializers[0].Serialize(xmlWriter, ExpertMult);
            xmlSerializers[1].Serialize(xmlWriter, GoOnline);
            xmlSerializers[1].Serialize(xmlWriter, IndentXml);
            xmlSerializers[1].Serialize(xmlWriter, HideCompletedOnChar);
            xmlSerializers[2].Serialize(xmlWriter, MaxAdvLvl);
            xmlSerializers[3].Serialize(xmlWriter, TempKeys);
            xmlSerializers[4].Serialize(xmlWriter, TempServers);
            xmlWriter.WriteFullEndElement();
            xmlWriter.Flush();
            xmlWriter.Dispose();
            OutStream.Flush();
            OutStream.Dispose();
        }
        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveData(true);
        }
        /// <summary>Writes <see cref="Program.questList"/> to <see cref="Program.TempQuest"/>.</summary>
        private void SaveQuests()
        {
            FileStream OutStream = File.Create(Program.TempQuest);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<CollQuest>));
            XmlWriter xmlWriter = XmlWriter.Create(OutStream, new XmlWriterSettings() { Indent = IndentXml });
            xmlSerializer.Serialize(xmlWriter, Program.questList.Values.ToList());
            xmlWriter.Flush();
            xmlWriter.Dispose();
            OutStream.Flush();
            OutStream.Dispose();
        }
        private void SettingsPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabControlStrip1.SelectedTab = SettingsPage;
        }
        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ToolStripMenuItem[] ToolStripItems = { characterPageToolStripMenuItem, questsPageToolStripMenuItem, itemsPageToolStripMenuItem, settingsPageToolStripMenuItem };
            TabPage[] TabPages = { CharacterPage, QuestsPage, ItemsPage, SettingsPage };
            for (int counter = 0; counter < 4; counter++)
            {
                if (ToolStripItems[counter].Checked && (TabControlStrip1.SelectedTab != TabPages[counter]))
                    ToolStripItems[counter].Checked = false;
                else if (!ToolStripItems[counter].Checked && (TabControlStrip1.SelectedTab == TabPages[counter]))
                    ToolStripItems[counter].Checked = true;
            }
        }
        private void ItemsEQ2iLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Uri TargetLink;
            try { TargetLink = new Uri(e.Link.LinkData.ToString()); }
            catch (UriFormatException) { return; }
            _ = System.Diagnostics.Process.Start(TargetLink.ToString());
        }
        /// <summary> Checks the current state of all dirty flags and sets the status bar accordingly. </summary>
        internal void UpdateDirtiesStatus()
        {
            StatusStripDirtyIndicator.Text = (dirties[0] || dirties[1] || dirties[2] || dirties[3]) ? FloppyString : string.Empty;
        }
        private void PlayingAsComboBox_Paint(object sender, PaintEventArgs e)
        {
            PlayingAsComboBox_Leave(sender, null);
        }
        private void QuestsLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Uri LinkTarget;
            try { LinkTarget = new Uri(e.Link.LinkData.ToString()); }
            catch (UriFormatException) { return; }
            _ = System.Diagnostics.Process.Start(LinkTarget.ToString());
        }
        private void ItemsCopyWPLabelLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Clipboard.SetText(e.Link.LinkData.ToString());
            timer1.Start();
            ItemsCopiedWPLabel.Visible = true;
        }
        private void SettingsExpertMultMTB_TypeValidationCompleted(object sender, TypeValidationEventArgs e)
        {
            if (e.IsValidInput)
            {
                ExpertMult = (double)e.ReturnValue;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            ItemsCopiedWPLabel.Visible = false;
        }
        private void UndoToolStripMenuItem_Click(object sender, EventArgs e) { }
    }
}
