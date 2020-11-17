using EQ2CollQuests.Properties;
using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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
        /// <value>The multiplier on need for items in &quot;Expert&quot; collections.</value>
        private double ExpertMult
        {
            get { return _ExpertMult; }
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
        private bool GoOnline
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
        private bool IndentXml
        {
            get { return _IndentXml; }
            set
            {
                if (value == _IndentXml)
                    return;
                else
                {
                    _IndentXml = value;
                    dirties[1] = true;
                    SaveChars();
                    SaveItems();
                    SaveSettings();
                    SaveQuests();
                }
            }
        }
        private bool _GoOnline = true, _IndentXml = true;
        private double _ExpertMult = 1.0;


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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0044:Add readonly modifier", Justification = "Flags need to be able to be set.")]
        private bool[] dirties = { false, false, false, false };
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
            if (Program.AdvClasses.Count == 0)
            {
                GetConstants();
                dirties[1] = true;
            }
            characterPageToolStripMenuItem.Checked = true;
            TabControlStrip.SelectedTab = CharacterPage;
            CharListBox.Items.Clear();
            CharListBox.Enabled = true;
            if (Program.charList.Count == 0)
            {
                CharListBox.Items.Add("Empty!");
                CharListBox.Enabled = false;
            }
            else
            {
                foreach (Characters thisChar in Program.charList)
                {
                    CharListBox.Items.Add(thisChar);
                }
            }
        }
        ~EQ2CollQuestsMain() { }
        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ = MessageBox.Show("EQ2 Collections Manager\nWritten by Erik Jepsen <erik@jepster.com>\n2020-10-25",
                "About",
                MessageBoxButtons.OK);
        }
        private void AddChar_Click(object sender, EventArgs e)
        {
            AddCharForm NewCharForm = new AddCharForm();
            if (NewCharForm.ShowDialog() == DialogResult.OK)
            {
                Program.charList.Add(NewCharForm.NewChar);
                Program.charList.Sort();
                dirties[0] = true;
            }
            NewCharForm.Dispose();
            CharListBox_DrawItem(sender, null);
        }
        private void AddChar_Paint(object sender, PaintEventArgs e)
        {
            if (!AddChar.Enabled)
                AddChar.Enabled = true;
        }
        /// <summary>
        ///     <para>
        ///     Checks for the existence of temporary files and moves them to the &quot;My Documents&quot;
        ///     folder if they exist.
        ///     </para>
        /// </summary>
        public void BadEnd()
        {
            for (int counter = 0; counter < 4; counter++)
            {
                if (File.Exists(AllTemp[counter]))
                {
                    if (File.Exists(AllBad[counter]))
                        File.Delete(AllBad[counter]);
                    File.Move(AllTemp[counter], AllBad[counter]);
                }
            }
        }
        private void CharacterPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((TabControlStrip.SelectedTab == CharacterPage) && characterPageToolStripMenuItem.Checked)
                return;
            TabControlStrip.SelectedTab = CharacterPage;
        }
        private void CharIntroTxtBox_Validating(object sender, CancelEventArgs e)
        {
            CharIntroTxtBox.Text = string.Empty;
            if (CharListBox.SelectedItem is Characters TempChar)
            {
                CharIntroTxtBox.Text = string.Concat($"{TempChar.name} is a level {TempChar.AdvLvl} ",
                    Program.AdvClasses[TempChar.AdvClass]);
            }
        }
        private void CharListBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            CharListBox.Items.Clear();
            CharListBox.Enabled = true;
            if (Program.charList.Count == 0)
            {
                CharListBox.Items.Add("Empty!");
                CharListBox.Enabled = false;
            }
            else
            {
                foreach (Characters thisChar in Program.charList)
                {
                    CharListBox.Items.Add(thisChar);
                }
            }
        }
        private void CharListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            CharQuestItemsCheckListBox.Items.Clear();
            CharQuestListBox.Items.Clear();
            switch (CharListBox.SelectedIndex)
            {
                case -1:
                    CharIntroTxtBox.Text = string.Empty;
                    break;
                default:
                    if (CharListBox.SelectedItem is string)
                    {
                        CharIntroTxtBox.Text = string.Empty;
                    }
                    else if (CharListBox.SelectedItem is Characters thisChar)
                    {
                        CharIntroTxtBox.Text = $"{thisChar.name} is a {thisChar.AdvLvl} {Program.AdvClasses[thisChar.AdvClass]}";
                        foreach (long thisColl in thisChar.CharCollection.Keys)
                        {
                            List<CollQuest> FoundQuests;
                            try { FoundQuests = Program.questList.FindAll(p => p.DaybreakID == thisColl); }
                            catch (NullReferenceException) { continue; }
                            if (FoundQuests.Count == 1)
                            {
                                CharQuestListBox.Items.Add(FoundQuests[0]);
                            }
                        }
                    }
                    if (CharQuestListBox.Items.Count > 0)
                    {
                        CharQuestListBox.Refresh();
                        CharQuestListBox.SelectedIndex = -1;
                    }
                    else if (CharListBox.SelectedItem is Characters thisChar)
                    {
                        if (thisChar.CharCollection.Count > 0)
                        {
                            DialogResult GetQuests = MessageBox.Show($"{thisChar.name} has quests that have not been downloaded. Get them now?",
                                "Get Missing Quests?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (GetQuests != DialogResult.Yes)
                                return;
                            int counter = 0, oldQuestCount = Program.questList.Count, oldItemCount = Program.itemList.Count;
                            ConcurrentBag<QuestItem> newItems;
                            Cursor.Current = Cursors.WaitCursor;
                            GetAllProgressBar.Maximum = thisChar.CharCollection.Count;
                            GetAllProgressBar.Value = 0;
                            GetAllProgressBar.Visible = true;
                            foreach(long thisColl in thisChar.CharCollection.Keys)
                            {
                                counter++;
                                newItems = new ConcurrentBag<QuestItem>();
                                if (Program.questList.FindAll(p => p.DaybreakID == thisColl).Count == 0)
                                {
                                    CollQuest TempQuest = new CollQuest(thisColl);
                                    Program.questList.Add(TempQuest);
                                    _ = Parallel.ForEach(TempQuest.items, thisItem =>
                                    {
                                        if (Program.itemList.FindAll(q => q.DaybreakID == thisItem).Count == 0)
                                        {
                                            if (newItems.Select(r => r.DaybreakID == thisItem).ToList().Count == 0)
                                                newItems.Add(new QuestItem(thisItem));
                                        }
                                    });
                                }
                                Program.itemList.AddRange(newItems);
                                GetAllProgressBar.Value = counter;
                                if (counter % 100 == 0)
                                    Console.WriteLine($"{counter} Quests processed.");
                            }
                            Cursor.Current = Cursors.Default;
                            GetAllProgressBar.Visible = false;
                            Program.questList.Sort();
                            Program.itemList.Sort();
                            CharQuestListBox.Refresh();
                            dirties[2] = oldItemCount == Program.itemList.Count;
                            dirties[3] = oldQuestCount == Program.questList.Count;
                        }
                    }
                    break;
            }
        }
        private void CharQuestListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            CharQuestItemsCheckListBox.Items.Clear();
            if (CharQuestListBox.SelectedIndex == -1)
            {
                CharQuestItemsCheckListBox.Refresh();
                return;
            }
            if ((CharQuestListBox.SelectedIndex == 0) && (CharQuestListBox.SelectedItem is string))
            {
                CharQuestItemsCheckListBox.Refresh();
                return;
            }
            CollQuest thisQuest = (CollQuest)CharQuestListBox.SelectedItem;
            Characters thisChar = (Characters)CharListBox.SelectedItem;
            foreach (long thisItemID in thisQuest.items)
            {
                QuestItem thisItem = Program.itemList.Find(p => p.DaybreakID == thisItemID);
                if (thisItem == null)
                {
                    thisItem = new QuestItem(thisItemID);
                    Program.itemList.Add(thisItem);
                }
                CharQuestItemsCheckListBox.Items.Add(thisItem, thisChar.CharCollection[thisQuest.DaybreakID].Contains(thisItemID));
            }
            CharQuestItemsCheckListBox.Refresh();
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
            BadEnd();
        }
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        /// <summary>
        /// Gets the maximum adventure level and dictionary of adventure classes from the
        /// Daybreak Games Census server.
        /// </summary>
        private void GetConstants()
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
        /// <summary>
        /// Attempts to load data from &quot;My Documents&quot; and
        /// &quot;&lt;user&gt;\appdata\local\EQ2CollQuests&quot;
        /// </summary>
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
                        Program.charList.AddRange(InChars);
                        InStream.Dispose();
                        break;
                    case 1:
                        Type[] types = { typeof(double), typeof(bool), typeof(short),
                            typeof(List<AdvKeyEntry>) };
                        XmlSerializer[] serializers = XmlSerializer.FromTypes(types);
                        XmlReader xmlReader = XmlReader.Create(InStream);
                        xmlReader.MoveToContent();
                        xmlReader.ReadStartElement("Root");
                        ExpertMult = (double)serializers[0].Deserialize(xmlReader);
                        GoOnline = (bool)serializers[1].Deserialize(xmlReader);
                        IndentXml = (bool)serializers[1].Deserialize(xmlReader);
                        MaxAdvLvl = (short)serializers[2].Deserialize(xmlReader);
                        List<AdvKeyEntry> TempKeys = (List<AdvKeyEntry>)serializers[3].Deserialize(xmlReader);
                        foreach (AdvKeyEntry thisEntry in TempKeys)
                            Program.AdvClasses[thisEntry.Key] = thisEntry.Value;
                        xmlReader.Dispose();
                        InStream.Dispose();
                        break;
                    case 2:
                        xmlSerializer = new XmlSerializer(typeof(List<QuestItem>));
                        Program.itemList.AddRange((List<QuestItem>)xmlSerializer.Deserialize(InStream));
                        InStream.Dispose();
                        break;
                    case 3:
                        xmlSerializer = new XmlSerializer(typeof(List<CollQuest>));
                        Program.questList.AddRange((List<CollQuest>)xmlSerializer.Deserialize(InStream));
                        InStream.Dispose();
                        break;
                    default:
                        break;
                }
            }
            dirties[1] = false;
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
        private void QuestItemsTreeView_VisibleChanged(object sender, EventArgs e) { }
        private void QuestsAddQuestBtn_Click(object sender, EventArgs e)
        {
            AddQuest NewQuestForm = new AddQuest();
            if (NewQuestForm.ShowDialog() == DialogResult.OK)
            {
                Program.questList.Add(NewQuestForm.NewQuest);
                Program.questList.Sort();
                dirties[3] = true;
            }
            NewQuestForm.Dispose();
            QuestListBox.Refresh();
        }
        private void QuestsPage_Enter(object sender, EventArgs e)
        {
            QuestItemsTreeView.Nodes.Clear();
            QuestListBox.Items.Clear();
            QuestListBox.Items.AddRange(Program.questList.ToArray());
            if (QuestListBox.SelectedItem is CollQuest cq)
            {
                foreach (long ThisItem in cq.items)
                {
                    TreeNode[] ItemChars = { };
                    foreach (Characters thisChar in Program.charList)
                    {
                        if (!thisChar.CharCollection.ContainsKey(cq.DaybreakID))
                            ItemChars = ItemChars.Append(new TreeNode($"{UnicodeCheckEx[1]} {thisChar} has not collected this item.")).ToArray();
                        else if (!thisChar.CharCollection[cq.DaybreakID].Contains(ThisItem))
                            ItemChars = ItemChars.Append(new TreeNode($"{UnicodeCheckEx[1]} {thisChar} has not collected this item.")).ToArray();
                        else
                            ItemChars = ItemChars.Append(new TreeNode($"{UnicodeCheckEx[0]} {thisChar} has collected this item.")).ToArray();
                    }
                    _ = QuestItemsTreeView.Nodes.Add(
                        new TreeNode(Program.itemList.Find(p => p.DaybreakID == ThisItem).ItemName,
                        ItemChars));
                }
            }
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
        public void SaveChars()
        {
            FileStream OutStream = File.Create(Program.TempChar);
            XmlWriter xmlWriter = XmlWriter.Create(OutStream, new XmlWriterSettings() { Indent = IndentXml });
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Characters>));
            xmlSerializer.Serialize(xmlWriter, Program.charList);
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
        public void SaveItems()
        {
            FileStream OutStream = File.Create(Program.TempItems);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<QuestItem>));
            XmlWriter xmlWriter = XmlWriter.Create(OutStream, new XmlWriterSettings() { Indent = IndentXml });
            xmlSerializer.Serialize(xmlWriter, Program.itemList);
            xmlWriter.Flush();
            xmlWriter.Dispose();
            OutStream.Flush();
            OutStream.Dispose();
        }
        /// <summary>Writes the existing settings to <see cref="Program.TempSetts"/>.</summary>
        public void SaveSettings()
        {
            FileStream OutStream = File.Create(Program.TempSetts);
            XmlWriter xmlWriter = XmlWriter.Create(OutStream, new XmlWriterSettings() { Indent = IndentXml });
            List<AdvKeyEntry> TempKeys = new List<AdvKeyEntry>();
            foreach (KeyValuePair<short, string> thisPair in Program.AdvClasses)
                TempKeys.Add(new AdvKeyEntry() { Key = thisPair.Key, Value = thisPair.Value });
            Type[] SerializeThese = { typeof(double), typeof(bool), typeof(short), typeof(List<AdvKeyEntry>) };
            XmlSerializer[] xmlSerializers = XmlSerializer.FromTypes(SerializeThese);
            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("Root");
            xmlSerializers[0].Serialize(xmlWriter, ExpertMult);
            xmlSerializers[1].Serialize(xmlWriter, GoOnline);
            xmlSerializers[1].Serialize(xmlWriter, IndentXml);
            xmlSerializers[2].Serialize(xmlWriter, MaxAdvLvl);
            xmlSerializers[3].Serialize(xmlWriter, TempKeys);
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
        public void SaveQuests()
        {
            FileStream OutStream = File.Create(Program.TempQuest);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<CollQuest>));
            XmlWriter xmlWriter = XmlWriter.Create(OutStream, new XmlWriterSettings() { Indent = IndentXml });
            xmlSerializer.Serialize(xmlWriter, Program.questList);
            xmlWriter.Flush();
            xmlWriter.Dispose();
            OutStream.Flush();
            OutStream.Dispose();
        }
        private void SettingsPage_Enter(object sender, EventArgs e)
        {
            SettingsBoolCheckListBox.Items.Clear();
            SettingsBoolCheckListBox.Items.Add("Go Online?", GoOnline);
            SettingsBoolCheckListBox.Items.Add("Indent XML?", IndentXml);
            SettingsExpertMultMTB.Text = ExpertMult.ToString("0#.000");
        }
        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ToolStripMenuItem[] ToolStripItems = { characterPageToolStripMenuItem, questsPageToolStripMenuItem, itemsPageToolStripMenuItem, settingsPageToolStripMenuItem };
            TabPage[] TabPages = { CharacterPage, QuestsPage, ItemsPage, SettingsPage };
            for (int counter = 0; counter < 4; counter++)
            {
                if (ToolStripItems[counter].Checked && (TabControlStrip.SelectedTab != TabPages[counter]))
                    ToolStripItems[counter].Checked = false;
                else if (!ToolStripItems[counter].Checked && (TabControlStrip.SelectedTab == TabPages[counter]))
                    ToolStripItems[counter].Checked = true;
            }
        }
        private void UndoToolStripMenuItem_Click(object sender, EventArgs e) { }
        private void QuestListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            QuestIntroTextBox.Text = string.Empty;
            QuestItemsTreeView.Nodes.Clear();
            if (QuestListBox.SelectedIndex == -1)
                return;
        }
        private void UpdChar_Paint(object sender, PaintEventArgs e)
        {
            if (CharListBox.SelectedItem == null)
            {
                UpdChar.Enabled = false;
                DelChar.Enabled = false;
            }
            else
            {
                UpdChar.Enabled = CharListBox.SelectedItem.GetType() == typeof(Characters);
                DelChar.Enabled = CharListBox.SelectedItem.GetType() == typeof(Characters);
            }
        }
    }
}
