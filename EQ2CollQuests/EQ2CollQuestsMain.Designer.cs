using System;

namespace EQ2CollQuests
{
    partial class EQ2CollQuestsMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reloadFromDiskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.characterPageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.questsPageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.itemsPageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsPageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PlayingAsComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TabControlStrip1 = new System.Windows.Forms.TabControl();
            this.CharacterPage = new System.Windows.Forms.TabPage();
            this.CharListSplitContainer = new System.Windows.Forms.SplitContainer();
            this.DelChar = new System.Windows.Forms.Button();
            this.UpdChar = new System.Windows.Forms.Button();
            this.AddChar = new System.Windows.Forms.Button();
            this.CharListBox = new System.Windows.Forms.ListBox();
            this.CharQuestSplitContainer = new System.Windows.Forms.SplitContainer();
            this.CharQuestListBox = new System.Windows.Forms.ListBox();
            this.CharIntroTxtBox = new System.Windows.Forms.TextBox();
            this.CharQuestItemsCheckListBox = new System.Windows.Forms.CheckedListBox();
            this.QuestsPage = new System.Windows.Forms.TabPage();
            this.QuestListSplitContainer = new System.Windows.Forms.SplitContainer();
            this.QuestListUpdateBtn = new System.Windows.Forms.Button();
            this.QuestsAddQuestBtn = new System.Windows.Forms.Button();
            this.QuestListBox = new System.Windows.Forms.ListBox();
            this.QuestsInnerSplitter = new System.Windows.Forms.SplitContainer();
            this.QuestsLinkLabel = new System.Windows.Forms.LinkLabel();
            this.QuestsDaybreakPanel = new System.Windows.Forms.Panel();
            this.QuestsDaybreakIDTB = new System.Windows.Forms.TextBox();
            this.QuestsDaybreakIDLabel = new System.Windows.Forms.Label();
            this.QuestsReqAdvLvlTB = new System.Windows.Forms.TextBox();
            this.QuestsReqAdvLvlRB = new System.Windows.Forms.RadioButton();
            this.QuestsNoReqAdvLvlRB = new System.Windows.Forms.RadioButton();
            this.QuestsExpertCheckBool = new System.Windows.Forms.CheckBox();
            this.QuestIntroTextBox = new System.Windows.Forms.TextBox();
            this.QuestItemsTreeView = new System.Windows.Forms.TreeView();
            this.ItemsPage = new System.Windows.Forms.TabPage();
            this.ItemsPageSplitContainer1 = new System.Windows.Forms.SplitContainer();
            this.ItemsListBox = new System.Windows.Forms.ListBox();
            this.ItemsCopiedWPLabel = new System.Windows.Forms.Label();
            this.ItemsCopyWPLabelLink = new System.Windows.Forms.LinkLabel();
            this.ItemsEQ2iLink = new System.Windows.Forms.LinkLabel();
            this.ItemsStaticLocPanel = new System.Windows.Forms.Panel();
            this.ItemsCorpseDropBool = new System.Windows.Forms.RadioButton();
            this.ItemsStaticLocZLabel = new System.Windows.Forms.Label();
            this.ItemsStaticLocYLabel = new System.Windows.Forms.Label();
            this.ItemsStaticLocXLabel = new System.Windows.Forms.Label();
            this.ItemsStaticLocZTB = new System.Windows.Forms.TextBox();
            this.ItemsStaticLocYTB = new System.Windows.Forms.TextBox();
            this.ItemsStaticLocXTB = new System.Windows.Forms.TextBox();
            this.ItemsStaticLocZoneTB = new System.Windows.Forms.TextBox();
            this.ItemsStaticLocRB = new System.Windows.Forms.RadioButton();
            this.ItemsNoStaticLocRB = new System.Windows.Forms.RadioButton();
            this.ItemsBoolCLB = new System.Windows.Forms.CheckedListBox();
            this.ItemsItemDaybreakIDLabel = new System.Windows.Forms.Label();
            this.ItemsItemDaybreakIDTB = new System.Windows.Forms.TextBox();
            this.ItemsItemLevelLabel = new System.Windows.Forms.Label();
            this.ItemsItemLevelTB = new System.Windows.Forms.TextBox();
            this.ItemIntro = new System.Windows.Forms.Label();
            this.SettingsPage = new System.Windows.Forms.TabPage();
            this.ExpertMultExplained = new System.Windows.Forms.RichTextBox();
            this.SettingsExpertMultMTBLabel = new System.Windows.Forms.Label();
            this.SettingsExpertMultMTB = new System.Windows.Forms.MaskedTextBox();
            this.SettingsBoolCheckListBox = new System.Windows.Forms.CheckedListBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.StatusStripDirtyIndicator = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.TabControlStrip1.SuspendLayout();
            this.CharacterPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CharListSplitContainer)).BeginInit();
            this.CharListSplitContainer.Panel1.SuspendLayout();
            this.CharListSplitContainer.Panel2.SuspendLayout();
            this.CharListSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CharQuestSplitContainer)).BeginInit();
            this.CharQuestSplitContainer.Panel1.SuspendLayout();
            this.CharQuestSplitContainer.Panel2.SuspendLayout();
            this.CharQuestSplitContainer.SuspendLayout();
            this.QuestsPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.QuestListSplitContainer)).BeginInit();
            this.QuestListSplitContainer.Panel1.SuspendLayout();
            this.QuestListSplitContainer.Panel2.SuspendLayout();
            this.QuestListSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.QuestsInnerSplitter)).BeginInit();
            this.QuestsInnerSplitter.Panel1.SuspendLayout();
            this.QuestsInnerSplitter.Panel2.SuspendLayout();
            this.QuestsInnerSplitter.SuspendLayout();
            this.QuestsDaybreakPanel.SuspendLayout();
            this.ItemsPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ItemsPageSplitContainer1)).BeginInit();
            this.ItemsPageSplitContainer1.Panel1.SuspendLayout();
            this.ItemsPageSplitContainer1.Panel2.SuspendLayout();
            this.ItemsPageSplitContainer1.SuspendLayout();
            this.ItemsStaticLocPanel.SuspendLayout();
            this.SettingsPage.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.PlayingAsComboBox,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 27);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reloadFromDiskToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 23);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // reloadFromDiskToolStripMenuItem
            // 
            this.reloadFromDiskToolStripMenuItem.Name = "reloadFromDiskToolStripMenuItem";
            this.reloadFromDiskToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.reloadFromDiskToolStripMenuItem.Text = "Reload From Disk";
            this.reloadFromDiskToolStripMenuItem.Click += new System.EventHandler(this.ReloadFromDiskToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem,
            this.toolStripSeparator1,
            this.cutToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 23);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.undoToolStripMenuItem.Text = "Undo";
            this.undoToolStripMenuItem.Click += new System.EventHandler(this.UndoToolStripMenuItem_Click);
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.redoToolStripMenuItem.Text = "Redo";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(100, 6);
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.cutToolStripMenuItem.Text = "Cut";
            this.cutToolStripMenuItem.Click += new System.EventHandler(this.CutToolStripMenuItem_Click);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.CopyToolStripMenuItem_Click);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.pasteToolStripMenuItem.Text = "Paste";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.PasteToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.characterPageToolStripMenuItem,
            this.questsPageToolStripMenuItem,
            this.itemsPageToolStripMenuItem,
            this.settingsPageToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 23);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // characterPageToolStripMenuItem
            // 
            this.characterPageToolStripMenuItem.Name = "characterPageToolStripMenuItem";
            this.characterPageToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.characterPageToolStripMenuItem.Text = "Character Page";
            this.characterPageToolStripMenuItem.Click += new System.EventHandler(this.CharacterPageToolStripMenuItem_Click);
            // 
            // questsPageToolStripMenuItem
            // 
            this.questsPageToolStripMenuItem.Name = "questsPageToolStripMenuItem";
            this.questsPageToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.questsPageToolStripMenuItem.Text = "Quests Page";
            this.questsPageToolStripMenuItem.Click += new System.EventHandler(this.QuestsPageToolStripMenuItem_Click);
            // 
            // itemsPageToolStripMenuItem
            // 
            this.itemsPageToolStripMenuItem.Name = "itemsPageToolStripMenuItem";
            this.itemsPageToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.itemsPageToolStripMenuItem.Text = "Items Page";
            this.itemsPageToolStripMenuItem.Click += new System.EventHandler(this.ItemsPageToolStripMenuItem_Click);
            // 
            // settingsPageToolStripMenuItem
            // 
            this.settingsPageToolStripMenuItem.Name = "settingsPageToolStripMenuItem";
            this.settingsPageToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.settingsPageToolStripMenuItem.Text = "Settings Page";
            this.settingsPageToolStripMenuItem.Click += new System.EventHandler(this.SettingsPageToolStripMenuItem_Click);
            // 
            // PlayingAsComboBox
            // 
            this.PlayingAsComboBox.BackColor = System.Drawing.SystemColors.MenuBar;
            this.PlayingAsComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PlayingAsComboBox.Name = "PlayingAsComboBox";
            this.PlayingAsComboBox.Size = new System.Drawing.Size(81, 23);
            this.PlayingAsComboBox.Text = "Playing as...";
            this.PlayingAsComboBox.SelectedIndexChanged += new System.EventHandler(this.PlayingAsComboBox_SelectedIndexChanged);
            this.PlayingAsComboBox.Leave += new System.EventHandler(this.PlayingAsComboBox_Leave);
            this.PlayingAsComboBox.Paint += new System.Windows.Forms.PaintEventHandler(this.PlayingAsComboBox_Paint);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem1,
            this.toolStripSeparator2,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 23);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // helpToolStripMenuItem1
            // 
            this.helpToolStripMenuItem1.Name = "helpToolStripMenuItem1";
            this.helpToolStripMenuItem1.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.helpToolStripMenuItem1.Size = new System.Drawing.Size(118, 22);
            this.helpToolStripMenuItem1.Text = "Help";
            this.helpToolStripMenuItem1.Click += new System.EventHandler(this.HelpToolStripMenuItem1_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(115, 6);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // TabControlStrip1
            // 
            this.TabControlStrip1.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.TabControlStrip1.Controls.Add(this.CharacterPage);
            this.TabControlStrip1.Controls.Add(this.QuestsPage);
            this.TabControlStrip1.Controls.Add(this.ItemsPage);
            this.TabControlStrip1.Controls.Add(this.SettingsPage);
            this.TabControlStrip1.Dock = System.Windows.Forms.DockStyle.Top;
            this.TabControlStrip1.Location = new System.Drawing.Point(0, 27);
            this.TabControlStrip1.Name = "TabControlStrip1";
            this.TabControlStrip1.SelectedIndex = 0;
            this.TabControlStrip1.Size = new System.Drawing.Size(800, 394);
            this.TabControlStrip1.TabIndex = 1;
            this.TabControlStrip1.SelectedIndexChanged += new System.EventHandler(this.TabControl1_SelectedIndexChanged);
            // 
            // CharacterPage
            // 
            this.CharacterPage.Controls.Add(this.CharListSplitContainer);
            this.CharacterPage.Location = new System.Drawing.Point(4, 4);
            this.CharacterPage.Name = "CharacterPage";
            this.CharacterPage.Padding = new System.Windows.Forms.Padding(3);
            this.CharacterPage.Size = new System.Drawing.Size(792, 368);
            this.CharacterPage.TabIndex = 0;
            this.CharacterPage.Text = "Character Page";
            this.CharacterPage.UseVisualStyleBackColor = true;
            this.CharacterPage.Enter += new System.EventHandler(this.CharacterPage_Enter);
            this.CharacterPage.Leave += new System.EventHandler(this.CharacterPage_Leave);
            this.CharacterPage.Resize += new System.EventHandler(this.CharacterPage_Resize);
            // 
            // CharListSplitContainer
            // 
            this.CharListSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CharListSplitContainer.Location = new System.Drawing.Point(3, 3);
            this.CharListSplitContainer.Name = "CharListSplitContainer";
            // 
            // CharListSplitContainer.Panel1
            // 
            this.CharListSplitContainer.Panel1.Controls.Add(this.DelChar);
            this.CharListSplitContainer.Panel1.Controls.Add(this.UpdChar);
            this.CharListSplitContainer.Panel1.Controls.Add(this.AddChar);
            this.CharListSplitContainer.Panel1.Controls.Add(this.CharListBox);
            // 
            // CharListSplitContainer.Panel2
            // 
            this.CharListSplitContainer.Panel2.Controls.Add(this.CharQuestSplitContainer);
            this.CharListSplitContainer.Size = new System.Drawing.Size(786, 362);
            this.CharListSplitContainer.SplitterDistance = 262;
            this.CharListSplitContainer.TabIndex = 0;
            this.CharListSplitContainer.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.CharListSplitContainer_SplitterMoved);
            // 
            // DelChar
            // 
            this.DelChar.Location = new System.Drawing.Point(127, 335);
            this.DelChar.Name = "DelChar";
            this.DelChar.Size = new System.Drawing.Size(68, 21);
            this.DelChar.TabIndex = 3;
            this.DelChar.Text = "Delete";
            this.DelChar.UseVisualStyleBackColor = true;
            // 
            // UpdChar
            // 
            this.UpdChar.Location = new System.Drawing.Point(71, 335);
            this.UpdChar.Name = "UpdChar";
            this.UpdChar.Size = new System.Drawing.Size(50, 22);
            this.UpdChar.TabIndex = 2;
            this.UpdChar.Text = "Update";
            this.UpdChar.UseVisualStyleBackColor = true;
            this.UpdChar.Click += new System.EventHandler(this.UpdChar_Click);
            // 
            // AddChar
            // 
            this.AddChar.Location = new System.Drawing.Point(5, 335);
            this.AddChar.Name = "AddChar";
            this.AddChar.Size = new System.Drawing.Size(60, 21);
            this.AddChar.TabIndex = 1;
            this.AddChar.Text = "Add";
            this.AddChar.UseVisualStyleBackColor = true;
            this.AddChar.Click += new System.EventHandler(this.AddChar_Click);
            this.AddChar.Paint += new System.Windows.Forms.PaintEventHandler(this.AddChar_Paint);
            // 
            // CharListBox
            // 
            this.CharListBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.CharListBox.FormattingEnabled = true;
            this.CharListBox.Location = new System.Drawing.Point(0, 0);
            this.CharListBox.Name = "CharListBox";
            this.CharListBox.Size = new System.Drawing.Size(262, 329);
            this.CharListBox.Sorted = true;
            this.CharListBox.TabIndex = 0;
            this.toolTip1.SetToolTip(this.CharListBox, "This is the list of your characters.");
            this.CharListBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.CharListBox_DrawItem);
            this.CharListBox.SelectedIndexChanged += new System.EventHandler(this.CharListBox_SelectedIndexChanged);
            // 
            // CharQuestSplitContainer
            // 
            this.CharQuestSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CharQuestSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.CharQuestSplitContainer.Name = "CharQuestSplitContainer";
            this.CharQuestSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // CharQuestSplitContainer.Panel1
            // 
            this.CharQuestSplitContainer.Panel1.Controls.Add(this.CharQuestListBox);
            this.CharQuestSplitContainer.Panel1.Controls.Add(this.CharIntroTxtBox);
            // 
            // CharQuestSplitContainer.Panel2
            // 
            this.CharQuestSplitContainer.Panel2.Controls.Add(this.CharQuestItemsCheckListBox);
            this.CharQuestSplitContainer.Size = new System.Drawing.Size(520, 362);
            this.CharQuestSplitContainer.SplitterDistance = 207;
            this.CharQuestSplitContainer.TabIndex = 0;
            this.CharQuestSplitContainer.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.CharQuestSplitContainer_SplitterMoved);
            // 
            // CharQuestListBox
            // 
            this.CharQuestListBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.CharQuestListBox.FormattingEnabled = true;
            this.CharQuestListBox.Location = new System.Drawing.Point(0, 21);
            this.CharQuestListBox.Name = "CharQuestListBox";
            this.CharQuestListBox.Size = new System.Drawing.Size(520, 186);
            this.CharQuestListBox.Sorted = true;
            this.CharQuestListBox.TabIndex = 1;
            this.toolTip1.SetToolTip(this.CharQuestListBox, "This is the list collection quests this character has started.");
            this.CharQuestListBox.SelectedIndexChanged += new System.EventHandler(this.CharQuestListBox_SelectedIndexChanged);
            // 
            // CharIntroTxtBox
            // 
            this.CharIntroTxtBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.CharIntroTxtBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CharIntroTxtBox.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CharIntroTxtBox.Location = new System.Drawing.Point(0, 0);
            this.CharIntroTxtBox.Name = "CharIntroTxtBox";
            this.CharIntroTxtBox.ReadOnly = true;
            this.CharIntroTxtBox.Size = new System.Drawing.Size(520, 19);
            this.CharIntroTxtBox.TabIndex = 0;
            this.CharIntroTxtBox.TabStop = false;
            this.toolTip1.SetToolTip(this.CharIntroTxtBox, "This is info about the selected character.");
            // 
            // CharQuestItemsCheckListBox
            // 
            this.CharQuestItemsCheckListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CharQuestItemsCheckListBox.Enabled = false;
            this.CharQuestItemsCheckListBox.FormattingEnabled = true;
            this.CharQuestItemsCheckListBox.Location = new System.Drawing.Point(0, 0);
            this.CharQuestItemsCheckListBox.Name = "CharQuestItemsCheckListBox";
            this.CharQuestItemsCheckListBox.Size = new System.Drawing.Size(520, 151);
            this.CharQuestItemsCheckListBox.Sorted = true;
            this.CharQuestItemsCheckListBox.TabIndex = 0;
            this.toolTip1.SetToolTip(this.CharQuestItemsCheckListBox, "This is the list of items in the selected quest and whether the selected characte" +
        "r has ");
            // 
            // QuestsPage
            // 
            this.QuestsPage.Controls.Add(this.QuestListSplitContainer);
            this.QuestsPage.Location = new System.Drawing.Point(4, 4);
            this.QuestsPage.Name = "QuestsPage";
            this.QuestsPage.Padding = new System.Windows.Forms.Padding(3);
            this.QuestsPage.Size = new System.Drawing.Size(792, 368);
            this.QuestsPage.TabIndex = 1;
            this.QuestsPage.Text = "Quests Page";
            this.QuestsPage.UseVisualStyleBackColor = true;
            this.QuestsPage.Enter += new System.EventHandler(this.QuestsPage_Enter);
            this.QuestsPage.Leave += new System.EventHandler(this.QuestsPage_Left);
            this.QuestsPage.Resize += new System.EventHandler(this.QuestsPage_Resize);
            // 
            // QuestListSplitContainer
            // 
            this.QuestListSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.QuestListSplitContainer.Location = new System.Drawing.Point(3, 3);
            this.QuestListSplitContainer.Name = "QuestListSplitContainer";
            // 
            // QuestListSplitContainer.Panel1
            // 
            this.QuestListSplitContainer.Panel1.Controls.Add(this.QuestListUpdateBtn);
            this.QuestListSplitContainer.Panel1.Controls.Add(this.QuestsAddQuestBtn);
            this.QuestListSplitContainer.Panel1.Controls.Add(this.QuestListBox);
            // 
            // QuestListSplitContainer.Panel2
            // 
            this.QuestListSplitContainer.Panel2.Controls.Add(this.QuestsInnerSplitter);
            this.QuestListSplitContainer.Size = new System.Drawing.Size(786, 362);
            this.QuestListSplitContainer.SplitterDistance = 181;
            this.QuestListSplitContainer.TabIndex = 0;
            this.QuestListSplitContainer.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.QuestListSplitContainer_SplitterMoved);
            // 
            // QuestListUpdateBtn
            // 
            this.QuestListUpdateBtn.Location = new System.Drawing.Point(92, 366);
            this.QuestListUpdateBtn.Name = "QuestListUpdateBtn";
            this.QuestListUpdateBtn.Size = new System.Drawing.Size(86, 23);
            this.QuestListUpdateBtn.TabIndex = 2;
            this.QuestListUpdateBtn.Text = "Update";
            this.QuestListUpdateBtn.UseVisualStyleBackColor = true;
            // 
            // QuestsAddQuestBtn
            // 
            this.QuestsAddQuestBtn.Location = new System.Drawing.Point(3, 366);
            this.QuestsAddQuestBtn.Name = "QuestsAddQuestBtn";
            this.QuestsAddQuestBtn.Size = new System.Drawing.Size(86, 23);
            this.QuestsAddQuestBtn.TabIndex = 1;
            this.QuestsAddQuestBtn.Text = "Add";
            this.QuestsAddQuestBtn.UseVisualStyleBackColor = true;
            this.QuestsAddQuestBtn.Click += new System.EventHandler(this.QuestsAddQuestBtn_Click);
            // 
            // QuestListBox
            // 
            this.QuestListBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.QuestListBox.FormattingEnabled = true;
            this.QuestListBox.Location = new System.Drawing.Point(0, 0);
            this.QuestListBox.Name = "QuestListBox";
            this.QuestListBox.Size = new System.Drawing.Size(181, 355);
            this.QuestListBox.Sorted = true;
            this.QuestListBox.TabIndex = 0;
            this.QuestListBox.SelectedIndexChanged += new System.EventHandler(this.QuestListBox_SelectedIndexChanged);
            // 
            // QuestsInnerSplitter
            // 
            this.QuestsInnerSplitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.QuestsInnerSplitter.Location = new System.Drawing.Point(0, 0);
            this.QuestsInnerSplitter.Name = "QuestsInnerSplitter";
            this.QuestsInnerSplitter.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // QuestsInnerSplitter.Panel1
            // 
            this.QuestsInnerSplitter.Panel1.Controls.Add(this.QuestsLinkLabel);
            this.QuestsInnerSplitter.Panel1.Controls.Add(this.QuestsDaybreakPanel);
            this.QuestsInnerSplitter.Panel1.Controls.Add(this.QuestsReqAdvLvlTB);
            this.QuestsInnerSplitter.Panel1.Controls.Add(this.QuestsReqAdvLvlRB);
            this.QuestsInnerSplitter.Panel1.Controls.Add(this.QuestsNoReqAdvLvlRB);
            this.QuestsInnerSplitter.Panel1.Controls.Add(this.QuestsExpertCheckBool);
            this.QuestsInnerSplitter.Panel1.Controls.Add(this.QuestIntroTextBox);
            // 
            // QuestsInnerSplitter.Panel2
            // 
            this.QuestsInnerSplitter.Panel2.Controls.Add(this.QuestItemsTreeView);
            this.QuestsInnerSplitter.Size = new System.Drawing.Size(601, 362);
            this.QuestsInnerSplitter.SplitterDistance = 154;
            this.QuestsInnerSplitter.TabIndex = 2;
            // 
            // QuestsLinkLabel
            // 
            this.QuestsLinkLabel.AutoSize = true;
            this.QuestsLinkLabel.Location = new System.Drawing.Point(528, 63);
            this.QuestsLinkLabel.Name = "QuestsLinkLabel";
            this.QuestsLinkLabel.Size = new System.Drawing.Size(68, 13);
            this.QuestsLinkLabel.TabIndex = 8;
            this.QuestsLinkLabel.TabStop = true;
            this.QuestsLinkLabel.Text = "EQ2i   EQ2U";
            this.QuestsLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.QuestsLinkLabel_LinkClicked);
            // 
            // QuestsDaybreakPanel
            // 
            this.QuestsDaybreakPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.QuestsDaybreakPanel.Controls.Add(this.QuestsDaybreakIDTB);
            this.QuestsDaybreakPanel.Controls.Add(this.QuestsDaybreakIDLabel);
            this.QuestsDaybreakPanel.Location = new System.Drawing.Point(355, 26);
            this.QuestsDaybreakPanel.Name = "QuestsDaybreakPanel";
            this.QuestsDaybreakPanel.Size = new System.Drawing.Size(246, 34);
            this.QuestsDaybreakPanel.TabIndex = 7;
            // 
            // QuestsDaybreakIDTB
            // 
            this.QuestsDaybreakIDTB.BackColor = System.Drawing.SystemColors.Control;
            this.QuestsDaybreakIDTB.Location = new System.Drawing.Point(116, 7);
            this.QuestsDaybreakIDTB.Name = "QuestsDaybreakIDTB";
            this.QuestsDaybreakIDTB.ReadOnly = true;
            this.QuestsDaybreakIDTB.Size = new System.Drawing.Size(130, 20);
            this.QuestsDaybreakIDTB.TabIndex = 2;
            this.QuestsDaybreakIDTB.TabStop = false;
            // 
            // QuestsDaybreakIDLabel
            // 
            this.QuestsDaybreakIDLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.QuestsDaybreakIDLabel.AutoSize = true;
            this.QuestsDaybreakIDLabel.Location = new System.Drawing.Point(12, 10);
            this.QuestsDaybreakIDLabel.Name = "QuestsDaybreakIDLabel";
            this.QuestsDaybreakIDLabel.Size = new System.Drawing.Size(98, 13);
            this.QuestsDaybreakIDLabel.TabIndex = 3;
            this.QuestsDaybreakIDLabel.Text = "Quest Daybreak ID";
            // 
            // QuestsReqAdvLvlTB
            // 
            this.QuestsReqAdvLvlTB.Location = new System.Drawing.Point(3, 101);
            this.QuestsReqAdvLvlTB.Name = "QuestsReqAdvLvlTB";
            this.QuestsReqAdvLvlTB.Size = new System.Drawing.Size(87, 20);
            this.QuestsReqAdvLvlTB.TabIndex = 6;
            this.QuestsReqAdvLvlTB.TextChanged += new System.EventHandler(this.QuestsReqAdvLvlTB_TextChanged);
            // 
            // QuestsReqAdvLvlRB
            // 
            this.QuestsReqAdvLvlRB.AutoSize = true;
            this.QuestsReqAdvLvlRB.Location = new System.Drawing.Point(3, 78);
            this.QuestsReqAdvLvlRB.Name = "QuestsReqAdvLvlRB";
            this.QuestsReqAdvLvlRB.Size = new System.Drawing.Size(198, 17);
            this.QuestsReqAdvLvlRB.TabIndex = 5;
            this.QuestsReqAdvLvlRB.TabStop = true;
            this.QuestsReqAdvLvlRB.Text = "Required adventure level to start is...";
            this.QuestsReqAdvLvlRB.UseVisualStyleBackColor = true;
            this.QuestsReqAdvLvlRB.CheckedChanged += new System.EventHandler(this.QuestsReqAdvLvlRB_CheckedChanged);
            // 
            // QuestsNoReqAdvLvlRB
            // 
            this.QuestsNoReqAdvLvlRB.AutoSize = true;
            this.QuestsNoReqAdvLvlRB.Location = new System.Drawing.Point(3, 55);
            this.QuestsNoReqAdvLvlRB.Name = "QuestsNoReqAdvLvlRB";
            this.QuestsNoReqAdvLvlRB.Size = new System.Drawing.Size(156, 17);
            this.QuestsNoReqAdvLvlRB.TabIndex = 4;
            this.QuestsNoReqAdvLvlRB.TabStop = true;
            this.QuestsNoReqAdvLvlRB.Text = "No required adventure level";
            this.QuestsNoReqAdvLvlRB.UseVisualStyleBackColor = true;
            this.QuestsNoReqAdvLvlRB.CheckedChanged += new System.EventHandler(this.QuestsNoReqAdvLvlRB_CheckedChanged);
            // 
            // QuestsExpertCheckBool
            // 
            this.QuestsExpertCheckBool.AutoSize = true;
            this.QuestsExpertCheckBool.Location = new System.Drawing.Point(3, 32);
            this.QuestsExpertCheckBool.Name = "QuestsExpertCheckBool";
            this.QuestsExpertCheckBool.Size = new System.Drawing.Size(87, 17);
            this.QuestsExpertCheckBool.TabIndex = 1;
            this.QuestsExpertCheckBool.Text = "Expert Quest";
            this.QuestsExpertCheckBool.UseVisualStyleBackColor = true;
            this.QuestsExpertCheckBool.CheckedChanged += new System.EventHandler(this.QuestsExpertCheckBool_CheckedChanged);
            // 
            // QuestIntroTextBox
            // 
            this.QuestIntroTextBox.BackColor = System.Drawing.SystemColors.Info;
            this.QuestIntroTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.QuestIntroTextBox.Enabled = false;
            this.QuestIntroTextBox.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QuestIntroTextBox.Location = new System.Drawing.Point(0, 0);
            this.QuestIntroTextBox.Name = "QuestIntroTextBox";
            this.QuestIntroTextBox.Size = new System.Drawing.Size(601, 26);
            this.QuestIntroTextBox.TabIndex = 0;
            this.QuestIntroTextBox.TabStop = false;
            this.QuestIntroTextBox.Text = "This line will introduce the quest.";
            // 
            // QuestItemsTreeView
            // 
            this.QuestItemsTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.QuestItemsTreeView.Location = new System.Drawing.Point(0, 0);
            this.QuestItemsTreeView.Name = "QuestItemsTreeView";
            this.QuestItemsTreeView.Size = new System.Drawing.Size(601, 204);
            this.QuestItemsTreeView.TabIndex = 1;
            // 
            // ItemsPage
            // 
            this.ItemsPage.Controls.Add(this.ItemsPageSplitContainer1);
            this.ItemsPage.Location = new System.Drawing.Point(4, 4);
            this.ItemsPage.Name = "ItemsPage";
            this.ItemsPage.Padding = new System.Windows.Forms.Padding(3);
            this.ItemsPage.Size = new System.Drawing.Size(792, 368);
            this.ItemsPage.TabIndex = 2;
            this.ItemsPage.Text = "Items Page";
            this.ItemsPage.UseVisualStyleBackColor = true;
            this.ItemsPage.Enter += new System.EventHandler(this.ItemsPage_Enter);
            this.ItemsPage.Leave += new System.EventHandler(this.ItemsPage_Leave);
            // 
            // ItemsPageSplitContainer1
            // 
            this.ItemsPageSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ItemsPageSplitContainer1.Location = new System.Drawing.Point(3, 3);
            this.ItemsPageSplitContainer1.Name = "ItemsPageSplitContainer1";
            // 
            // ItemsPageSplitContainer1.Panel1
            // 
            this.ItemsPageSplitContainer1.Panel1.Controls.Add(this.ItemsListBox);
            // 
            // ItemsPageSplitContainer1.Panel2
            // 
            this.ItemsPageSplitContainer1.Panel2.Controls.Add(this.ItemsCopiedWPLabel);
            this.ItemsPageSplitContainer1.Panel2.Controls.Add(this.ItemsCopyWPLabelLink);
            this.ItemsPageSplitContainer1.Panel2.Controls.Add(this.ItemsEQ2iLink);
            this.ItemsPageSplitContainer1.Panel2.Controls.Add(this.ItemsStaticLocPanel);
            this.ItemsPageSplitContainer1.Panel2.Controls.Add(this.ItemsBoolCLB);
            this.ItemsPageSplitContainer1.Panel2.Controls.Add(this.ItemsItemDaybreakIDLabel);
            this.ItemsPageSplitContainer1.Panel2.Controls.Add(this.ItemsItemDaybreakIDTB);
            this.ItemsPageSplitContainer1.Panel2.Controls.Add(this.ItemsItemLevelLabel);
            this.ItemsPageSplitContainer1.Panel2.Controls.Add(this.ItemsItemLevelTB);
            this.ItemsPageSplitContainer1.Panel2.Controls.Add(this.ItemIntro);
            this.ItemsPageSplitContainer1.Size = new System.Drawing.Size(786, 362);
            this.ItemsPageSplitContainer1.SplitterDistance = 262;
            this.ItemsPageSplitContainer1.TabIndex = 0;
            // 
            // ItemsListBox
            // 
            this.ItemsListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ItemsListBox.FormattingEnabled = true;
            this.ItemsListBox.Location = new System.Drawing.Point(0, 0);
            this.ItemsListBox.Name = "ItemsListBox";
            this.ItemsListBox.Size = new System.Drawing.Size(262, 362);
            this.ItemsListBox.Sorted = true;
            this.ItemsListBox.TabIndex = 0;
            this.ItemsListBox.SelectedIndexChanged += new System.EventHandler(this.ItemsListBox_SelectedIndexChanged);
            // 
            // ItemsCopiedWPLabel
            // 
            this.ItemsCopiedWPLabel.AutoSize = true;
            this.ItemsCopiedWPLabel.Location = new System.Drawing.Point(414, 85);
            this.ItemsCopiedWPLabel.Name = "ItemsCopiedWPLabel";
            this.ItemsCopiedWPLabel.Size = new System.Drawing.Size(91, 13);
            this.ItemsCopiedWPLabel.TabIndex = 9;
            this.ItemsCopiedWPLabel.Text = "Waypoint Copied!";
            this.ItemsCopiedWPLabel.Visible = false;
            // 
            // ItemsCopyWPLabelLink
            // 
            this.ItemsCopyWPLabelLink.AutoSize = true;
            this.ItemsCopyWPLabelLink.Location = new System.Drawing.Point(414, 67);
            this.ItemsCopyWPLabelLink.Name = "ItemsCopyWPLabelLink";
            this.ItemsCopyWPLabelLink.Size = new System.Drawing.Size(79, 13);
            this.ItemsCopyWPLabelLink.TabIndex = 8;
            this.ItemsCopyWPLabelLink.TabStop = true;
            this.ItemsCopyWPLabelLink.Text = "Copy Waypoint";
            this.ItemsCopyWPLabelLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ItemsCopyWPLabelLink_LinkClicked);
            // 
            // ItemsEQ2iLink
            // 
            this.ItemsEQ2iLink.AutoSize = true;
            this.ItemsEQ2iLink.LinkArea = new System.Windows.Forms.LinkArea(0, 0);
            this.ItemsEQ2iLink.Location = new System.Drawing.Point(414, 46);
            this.ItemsEQ2iLink.Name = "ItemsEQ2iLink";
            this.ItemsEQ2iLink.Size = new System.Drawing.Size(68, 13);
            this.ItemsEQ2iLink.TabIndex = 7;
            this.ItemsEQ2iLink.Text = "EQ2i   EQ2U";
            this.ItemsEQ2iLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ItemsEQ2iLink_LinkClicked);
            // 
            // ItemsStaticLocPanel
            // 
            this.ItemsStaticLocPanel.Controls.Add(this.ItemsCorpseDropBool);
            this.ItemsStaticLocPanel.Controls.Add(this.ItemsStaticLocZLabel);
            this.ItemsStaticLocPanel.Controls.Add(this.ItemsStaticLocYLabel);
            this.ItemsStaticLocPanel.Controls.Add(this.ItemsStaticLocXLabel);
            this.ItemsStaticLocPanel.Controls.Add(this.ItemsStaticLocZTB);
            this.ItemsStaticLocPanel.Controls.Add(this.ItemsStaticLocYTB);
            this.ItemsStaticLocPanel.Controls.Add(this.ItemsStaticLocXTB);
            this.ItemsStaticLocPanel.Controls.Add(this.ItemsStaticLocZoneTB);
            this.ItemsStaticLocPanel.Controls.Add(this.ItemsStaticLocRB);
            this.ItemsStaticLocPanel.Controls.Add(this.ItemsNoStaticLocRB);
            this.ItemsStaticLocPanel.Location = new System.Drawing.Point(3, 70);
            this.ItemsStaticLocPanel.Name = "ItemsStaticLocPanel";
            this.ItemsStaticLocPanel.Size = new System.Drawing.Size(219, 184);
            this.ItemsStaticLocPanel.TabIndex = 6;
            // 
            // ItemsCorpseDropBool
            // 
            this.ItemsCorpseDropBool.AutoSize = true;
            this.ItemsCorpseDropBool.Location = new System.Drawing.Point(3, 26);
            this.ItemsCorpseDropBool.Name = "ItemsCorpseDropBool";
            this.ItemsCorpseDropBool.Size = new System.Drawing.Size(92, 17);
            this.ItemsCorpseDropBool.TabIndex = 9;
            this.ItemsCorpseDropBool.TabStop = true;
            this.ItemsCorpseDropBool.Text = "Chest loot in...";
            this.ItemsCorpseDropBool.UseVisualStyleBackColor = true;
            this.ItemsCorpseDropBool.CheckedChanged += new System.EventHandler(this.ItemsCorpseDropBool_CheckedChanged);
            this.ItemsCorpseDropBool.Click += new System.EventHandler(this.ItemsCorpseDropBool_Click);
            // 
            // ItemsStaticLocZLabel
            // 
            this.ItemsStaticLocZLabel.AutoSize = true;
            this.ItemsStaticLocZLabel.Location = new System.Drawing.Point(175, 124);
            this.ItemsStaticLocZLabel.Name = "ItemsStaticLocZLabel";
            this.ItemsStaticLocZLabel.Size = new System.Drawing.Size(14, 13);
            this.ItemsStaticLocZLabel.TabIndex = 8;
            this.ItemsStaticLocZLabel.Text = "Z";
            this.ItemsStaticLocZLabel.Click += new System.EventHandler(this.ItemsStaticLocZLabel_Click);
            // 
            // ItemsStaticLocYLabel
            // 
            this.ItemsStaticLocYLabel.AutoSize = true;
            this.ItemsStaticLocYLabel.Location = new System.Drawing.Point(98, 124);
            this.ItemsStaticLocYLabel.Name = "ItemsStaticLocYLabel";
            this.ItemsStaticLocYLabel.Size = new System.Drawing.Size(14, 13);
            this.ItemsStaticLocYLabel.TabIndex = 7;
            this.ItemsStaticLocYLabel.Text = "Y";
            this.ItemsStaticLocYLabel.Click += new System.EventHandler(this.ItemsStaticLocYLabel_Click);
            // 
            // ItemsStaticLocXLabel
            // 
            this.ItemsStaticLocXLabel.AutoSize = true;
            this.ItemsStaticLocXLabel.Location = new System.Drawing.Point(29, 124);
            this.ItemsStaticLocXLabel.Name = "ItemsStaticLocXLabel";
            this.ItemsStaticLocXLabel.Size = new System.Drawing.Size(14, 13);
            this.ItemsStaticLocXLabel.TabIndex = 6;
            this.ItemsStaticLocXLabel.Text = "X";
            this.ItemsStaticLocXLabel.Click += new System.EventHandler(this.ItemsStaticLocXLabel_Click);
            // 
            // ItemsStaticLocZTB
            // 
            this.ItemsStaticLocZTB.Location = new System.Drawing.Point(149, 101);
            this.ItemsStaticLocZTB.Name = "ItemsStaticLocZTB";
            this.ItemsStaticLocZTB.Size = new System.Drawing.Size(67, 20);
            this.ItemsStaticLocZTB.TabIndex = 5;
            this.ItemsStaticLocZTB.TextChanged += new System.EventHandler(this.ItemsStaticLocZTB_TextChanged);
            this.ItemsStaticLocZTB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ItemsStaticLocZTB_KeyPress);
            this.ItemsStaticLocZTB.Leave += new System.EventHandler(this.ItemsStaticLocZTB_Leave);
            // 
            // ItemsStaticLocYTB
            // 
            this.ItemsStaticLocYTB.Location = new System.Drawing.Point(74, 101);
            this.ItemsStaticLocYTB.Name = "ItemsStaticLocYTB";
            this.ItemsStaticLocYTB.Size = new System.Drawing.Size(67, 20);
            this.ItemsStaticLocYTB.TabIndex = 4;
            this.ItemsStaticLocYTB.TextChanged += new System.EventHandler(this.ItemsStaticLocYTB_TextChanged);
            this.ItemsStaticLocYTB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ItemsStaticLocYTB_KeyPress);
            this.ItemsStaticLocYTB.Leave += new System.EventHandler(this.ItemsStaticLocYTB_Leave);
            // 
            // ItemsStaticLocXTB
            // 
            this.ItemsStaticLocXTB.Location = new System.Drawing.Point(3, 101);
            this.ItemsStaticLocXTB.Name = "ItemsStaticLocXTB";
            this.ItemsStaticLocXTB.Size = new System.Drawing.Size(67, 20);
            this.ItemsStaticLocXTB.TabIndex = 3;
            this.ItemsStaticLocXTB.TextChanged += new System.EventHandler(this.ItemsStaticLocXTB_TextChanged);
            this.ItemsStaticLocXTB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ItemsStaticLocXTB_KeyPress);
            this.ItemsStaticLocXTB.Leave += new System.EventHandler(this.ItemsStaticLocXTB_Leave);
            // 
            // ItemsStaticLocZoneTB
            // 
            this.ItemsStaticLocZoneTB.Location = new System.Drawing.Point(3, 72);
            this.ItemsStaticLocZoneTB.Name = "ItemsStaticLocZoneTB";
            this.ItemsStaticLocZoneTB.Size = new System.Drawing.Size(213, 20);
            this.ItemsStaticLocZoneTB.TabIndex = 2;
            this.ItemsStaticLocZoneTB.TextChanged += new System.EventHandler(this.ItemsStaticLocZoneTB_TextChanged);
            this.ItemsStaticLocZoneTB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ItemsStaticLocZoneTB_KeyPress);
            // 
            // ItemsStaticLocRB
            // 
            this.ItemsStaticLocRB.AutoSize = true;
            this.ItemsStaticLocRB.Location = new System.Drawing.Point(3, 49);
            this.ItemsStaticLocRB.Name = "ItemsStaticLocRB";
            this.ItemsStaticLocRB.Size = new System.Drawing.Size(137, 17);
            this.ItemsStaticLocRB.TabIndex = 1;
            this.ItemsStaticLocRB.TabStop = true;
            this.ItemsStaticLocRB.Text = "Fixed Location      Zone";
            this.ItemsStaticLocRB.UseVisualStyleBackColor = true;
            this.ItemsStaticLocRB.CheckedChanged += new System.EventHandler(this.ItemsStaticLocRB_CheckedChanged);
            // 
            // ItemsNoStaticLocRB
            // 
            this.ItemsNoStaticLocRB.AutoSize = true;
            this.ItemsNoStaticLocRB.Location = new System.Drawing.Point(3, 3);
            this.ItemsNoStaticLocRB.Name = "ItemsNoStaticLocRB";
            this.ItemsNoStaticLocRB.Size = new System.Drawing.Size(109, 17);
            this.ItemsNoStaticLocRB.TabIndex = 0;
            this.ItemsNoStaticLocRB.TabStop = true;
            this.ItemsNoStaticLocRB.Text = "Random Location";
            this.ItemsNoStaticLocRB.UseVisualStyleBackColor = true;
            this.ItemsNoStaticLocRB.CheckedChanged += new System.EventHandler(this.ItemsNoStaticLocRB_CheckedChanged);
            this.ItemsNoStaticLocRB.Click += new System.EventHandler(this.ItemsNoStaticLocRB_Click);
            // 
            // ItemsBoolCLB
            // 
            this.ItemsBoolCLB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ItemsBoolCLB.Enabled = false;
            this.ItemsBoolCLB.FormattingEnabled = true;
            this.ItemsBoolCLB.Location = new System.Drawing.Point(2, 49);
            this.ItemsBoolCLB.MultiColumn = true;
            this.ItemsBoolCLB.Name = "ItemsBoolCLB";
            this.ItemsBoolCLB.Size = new System.Drawing.Size(512, 15);
            this.ItemsBoolCLB.TabIndex = 5;
            this.toolTip1.SetToolTip(this.ItemsBoolCLB, "Settings for this item.");
            // 
            // ItemsItemDaybreakIDLabel
            // 
            this.ItemsItemDaybreakIDLabel.AutoSize = true;
            this.ItemsItemDaybreakIDLabel.Location = new System.Drawing.Point(344, 26);
            this.ItemsItemDaybreakIDLabel.Name = "ItemsItemDaybreakIDLabel";
            this.ItemsItemDaybreakIDLabel.Size = new System.Drawing.Size(67, 13);
            this.ItemsItemDaybreakIDLabel.TabIndex = 4;
            this.ItemsItemDaybreakIDLabel.Text = "Daybreak ID";
            this.toolTip1.SetToolTip(this.ItemsItemDaybreakIDLabel, "This is the Daybreak ID number of the item.");
            // 
            // ItemsItemDaybreakIDTB
            // 
            this.ItemsItemDaybreakIDTB.Enabled = false;
            this.ItemsItemDaybreakIDTB.Location = new System.Drawing.Point(417, 23);
            this.ItemsItemDaybreakIDTB.Name = "ItemsItemDaybreakIDTB";
            this.ItemsItemDaybreakIDTB.Size = new System.Drawing.Size(98, 20);
            this.ItemsItemDaybreakIDTB.TabIndex = 3;
            this.toolTip1.SetToolTip(this.ItemsItemDaybreakIDTB, "This is the Daybreak ID number of the item.");
            // 
            // ItemsItemLevelLabel
            // 
            this.ItemsItemLevelLabel.AutoSize = true;
            this.ItemsItemLevelLabel.Location = new System.Drawing.Point(48, 26);
            this.ItemsItemLevelLabel.Name = "ItemsItemLevelLabel";
            this.ItemsItemLevelLabel.Size = new System.Drawing.Size(33, 13);
            this.ItemsItemLevelLabel.TabIndex = 2;
            this.ItemsItemLevelLabel.Text = "Level";
            // 
            // ItemsItemLevelTB
            // 
            this.ItemsItemLevelTB.Enabled = false;
            this.ItemsItemLevelTB.Location = new System.Drawing.Point(2, 23);
            this.ItemsItemLevelTB.Name = "ItemsItemLevelTB";
            this.ItemsItemLevelTB.Size = new System.Drawing.Size(39, 20);
            this.ItemsItemLevelTB.TabIndex = 1;
            this.toolTip1.SetToolTip(this.ItemsItemLevelTB, "The item\'s level.");
            // 
            // ItemIntro
            // 
            this.ItemIntro.BackColor = System.Drawing.SystemColors.Info;
            this.ItemIntro.Dock = System.Windows.Forms.DockStyle.Top;
            this.ItemIntro.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ItemIntro.Location = new System.Drawing.Point(0, 0);
            this.ItemIntro.Name = "ItemIntro";
            this.ItemIntro.Size = new System.Drawing.Size(520, 20);
            this.ItemIntro.TabIndex = 0;
            this.toolTip1.SetToolTip(this.ItemIntro, "This is the item\'s name.");
            // 
            // SettingsPage
            // 
            this.SettingsPage.Controls.Add(this.ExpertMultExplained);
            this.SettingsPage.Controls.Add(this.SettingsExpertMultMTBLabel);
            this.SettingsPage.Controls.Add(this.SettingsExpertMultMTB);
            this.SettingsPage.Controls.Add(this.SettingsBoolCheckListBox);
            this.SettingsPage.Location = new System.Drawing.Point(4, 4);
            this.SettingsPage.Name = "SettingsPage";
            this.SettingsPage.Padding = new System.Windows.Forms.Padding(3);
            this.SettingsPage.Size = new System.Drawing.Size(792, 368);
            this.SettingsPage.TabIndex = 3;
            this.SettingsPage.Text = "Settings Page";
            this.SettingsPage.UseVisualStyleBackColor = true;
            this.SettingsPage.Enter += new System.EventHandler(this.SettingsPage_Enter);
            this.SettingsPage.Leave += new System.EventHandler(this.SettingsPage_Leave);
            this.SettingsPage.Resize += new System.EventHandler(this.SettingsPage_Resize);
            // 
            // ExpertMultExplained
            // 
            this.ExpertMultExplained.BackColor = System.Drawing.SystemColors.Info;
            this.ExpertMultExplained.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ExpertMultExplained.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ExpertMultExplained.Location = new System.Drawing.Point(3, 80);
            this.ExpertMultExplained.Name = "ExpertMultExplained";
            this.ExpertMultExplained.ReadOnly = true;
            this.ExpertMultExplained.Size = new System.Drawing.Size(786, 285);
            this.ExpertMultExplained.TabIndex = 3;
            this.ExpertMultExplained.Text = "";
            // 
            // SettingsExpertMultMTBLabel
            // 
            this.SettingsExpertMultMTBLabel.AutoSize = true;
            this.SettingsExpertMultMTBLabel.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SettingsExpertMultMTBLabel.Location = new System.Drawing.Point(75, 53);
            this.SettingsExpertMultMTBLabel.Name = "SettingsExpertMultMTBLabel";
            this.SettingsExpertMultMTBLabel.Size = new System.Drawing.Size(203, 18);
            this.SettingsExpertMultMTBLabel.TabIndex = 2;
            this.SettingsExpertMultMTBLabel.Text = "Expert Collection Multiplier";
            this.SettingsExpertMultMTBLabel.Click += new System.EventHandler(this.SettingsExpertMultMTBLabel_Click);
            // 
            // SettingsExpertMultMTB
            // 
            this.SettingsExpertMultMTB.Location = new System.Drawing.Point(6, 54);
            this.SettingsExpertMultMTB.Name = "SettingsExpertMultMTB";
            this.SettingsExpertMultMTB.PromptChar = ' ';
            this.SettingsExpertMultMTB.Size = new System.Drawing.Size(63, 20);
            this.SettingsExpertMultMTB.TabIndex = 1;
            this.SettingsExpertMultMTB.ValidatingType = typeof(double);
            this.SettingsExpertMultMTB.TypeValidationCompleted += new System.Windows.Forms.TypeValidationEventHandler(this.SettingsExpertMultMTB_TypeValidationCompleted);
            this.SettingsExpertMultMTB.TextChanged += new System.EventHandler(this.SettingsExpertMultMTB_TextChanged);
            // 
            // SettingsBoolCheckListBox
            // 
            this.SettingsBoolCheckListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SettingsBoolCheckListBox.CheckOnClick = true;
            this.SettingsBoolCheckListBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.SettingsBoolCheckListBox.FormattingEnabled = true;
            this.SettingsBoolCheckListBox.Location = new System.Drawing.Point(3, 3);
            this.SettingsBoolCheckListBox.Name = "SettingsBoolCheckListBox";
            this.SettingsBoolCheckListBox.Size = new System.Drawing.Size(786, 45);
            this.SettingsBoolCheckListBox.TabIndex = 0;
            this.SettingsBoolCheckListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.SettingsBoolCheckListBox_ItemCheck);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusStripDirtyIndicator,
            this.StatusStripProgressBar});
            this.statusStrip1.Location = new System.Drawing.Point(0, 424);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 26);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // StatusStripDirtyIndicator
            // 
            this.StatusStripDirtyIndicator.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusStripDirtyIndicator.ForeColor = System.Drawing.Color.Red;
            this.StatusStripDirtyIndicator.Name = "StatusStripDirtyIndicator";
            this.StatusStripDirtyIndicator.Size = new System.Drawing.Size(109, 21);
            this.StatusStripDirtyIndicator.Text = "Dirty Indicator";
            this.StatusStripDirtyIndicator.ToolTipText = "If this space has a disk in it, you have unsaved data.";
            this.StatusStripDirtyIndicator.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
            // 
            // StatusStripProgressBar
            // 
            this.StatusStripProgressBar.Name = "StatusStripProgressBar";
            this.StatusStripProgressBar.Size = new System.Drawing.Size(100, 20);
            this.StatusStripProgressBar.ToolTipText = "Current Progress";
            this.StatusStripProgressBar.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // EQ2CollQuestsMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.TabControlStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "EQ2CollQuestsMain";
            this.Text = "EQ2 Collection Quests";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EQ2CollQuestsMainClosing);
            this.Enter += new System.EventHandler(this.EQ2CollQuestsMain_Enter);
            this.MouseEnter += new System.EventHandler(this.EQ2CollQuestsMain_MouseEnter);
            this.Resize += new System.EventHandler(this.EQ2CollQuestsMain_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.TabControlStrip1.ResumeLayout(false);
            this.CharacterPage.ResumeLayout(false);
            this.CharListSplitContainer.Panel1.ResumeLayout(false);
            this.CharListSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CharListSplitContainer)).EndInit();
            this.CharListSplitContainer.ResumeLayout(false);
            this.CharQuestSplitContainer.Panel1.ResumeLayout(false);
            this.CharQuestSplitContainer.Panel1.PerformLayout();
            this.CharQuestSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CharQuestSplitContainer)).EndInit();
            this.CharQuestSplitContainer.ResumeLayout(false);
            this.QuestsPage.ResumeLayout(false);
            this.QuestListSplitContainer.Panel1.ResumeLayout(false);
            this.QuestListSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.QuestListSplitContainer)).EndInit();
            this.QuestListSplitContainer.ResumeLayout(false);
            this.QuestsInnerSplitter.Panel1.ResumeLayout(false);
            this.QuestsInnerSplitter.Panel1.PerformLayout();
            this.QuestsInnerSplitter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.QuestsInnerSplitter)).EndInit();
            this.QuestsInnerSplitter.ResumeLayout(false);
            this.QuestsDaybreakPanel.ResumeLayout(false);
            this.QuestsDaybreakPanel.PerformLayout();
            this.ItemsPage.ResumeLayout(false);
            this.ItemsPageSplitContainer1.Panel1.ResumeLayout(false);
            this.ItemsPageSplitContainer1.Panel2.ResumeLayout(false);
            this.ItemsPageSplitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ItemsPageSplitContainer1)).EndInit();
            this.ItemsPageSplitContainer1.ResumeLayout(false);
            this.ItemsStaticLocPanel.ResumeLayout(false);
            this.ItemsStaticLocPanel.PerformLayout();
            this.SettingsPage.ResumeLayout(false);
            this.SettingsPage.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reloadFromDiskToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem characterPageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem questsPageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem itemsPageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsPageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.TabControl TabControlStrip1;
        private System.Windows.Forms.TabPage CharacterPage;
        private System.Windows.Forms.TabPage QuestsPage;
        private System.Windows.Forms.SplitContainer CharListSplitContainer;
        private System.Windows.Forms.Button DelChar;
        private System.Windows.Forms.Button UpdChar;
        private System.Windows.Forms.Button AddChar;
        private System.Windows.Forms.ListBox CharListBox;
        private System.Windows.Forms.TabPage ItemsPage;
        private System.Windows.Forms.TabPage SettingsPage;
        private System.Windows.Forms.SplitContainer CharQuestSplitContainer;
        private System.Windows.Forms.TextBox CharIntroTxtBox;
        private System.Windows.Forms.ListBox CharQuestListBox;
        private System.Windows.Forms.SplitContainer QuestListSplitContainer;
        private System.Windows.Forms.ListBox QuestListBox;
        private System.Windows.Forms.TextBox QuestIntroTextBox;
        private System.Windows.Forms.TreeView QuestItemsTreeView;
        private System.Windows.Forms.CheckedListBox SettingsBoolCheckListBox;
        private System.Windows.Forms.MaskedTextBox SettingsExpertMultMTB;
        private System.Windows.Forms.RichTextBox ExpertMultExplained;
        private System.Windows.Forms.Label SettingsExpertMultMTBLabel;
        private System.Windows.Forms.Button QuestsAddQuestBtn;
        private System.Windows.Forms.Button QuestListUpdateBtn;
        private System.Windows.Forms.CheckedListBox CharQuestItemsCheckListBox;
        private System.Windows.Forms.ToolStripComboBox PlayingAsComboBox;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel StatusStripDirtyIndicator;
        private System.Windows.Forms.ToolStripProgressBar StatusStripProgressBar;
        private System.Windows.Forms.SplitContainer ItemsPageSplitContainer1;
        private System.Windows.Forms.ListBox ItemsListBox;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.Label ItemIntro;
        private System.Windows.Forms.Label ItemsItemLevelLabel;
        private System.Windows.Forms.TextBox ItemsItemLevelTB;
        private System.Windows.Forms.Label ItemsItemDaybreakIDLabel;
        private System.Windows.Forms.TextBox ItemsItemDaybreakIDTB;
        private System.Windows.Forms.CheckedListBox ItemsBoolCLB;
        private System.Windows.Forms.Panel ItemsStaticLocPanel;
        private System.Windows.Forms.RadioButton ItemsStaticLocRB;
        private System.Windows.Forms.RadioButton ItemsNoStaticLocRB;
        private System.Windows.Forms.TextBox ItemsStaticLocZTB;
        private System.Windows.Forms.TextBox ItemsStaticLocYTB;
        private System.Windows.Forms.TextBox ItemsStaticLocXTB;
        private System.Windows.Forms.TextBox ItemsStaticLocZoneTB;
        private System.Windows.Forms.Label ItemsStaticLocXLabel;
        private System.Windows.Forms.Label ItemsStaticLocZLabel;
        private System.Windows.Forms.Label ItemsStaticLocYLabel;
        private System.Windows.Forms.RadioButton ItemsCorpseDropBool;
        private System.Windows.Forms.LinkLabel ItemsEQ2iLink;
        private System.Windows.Forms.SplitContainer QuestsInnerSplitter;
        private System.Windows.Forms.TextBox QuestsReqAdvLvlTB;
        private System.Windows.Forms.RadioButton QuestsReqAdvLvlRB;
        private System.Windows.Forms.RadioButton QuestsNoReqAdvLvlRB;
        private System.Windows.Forms.Label QuestsDaybreakIDLabel;
        private System.Windows.Forms.TextBox QuestsDaybreakIDTB;
        private System.Windows.Forms.CheckBox QuestsExpertCheckBool;
        private System.Windows.Forms.Panel QuestsDaybreakPanel;
        private System.Windows.Forms.LinkLabel QuestsLinkLabel;
        private System.Windows.Forms.Label ItemsCopiedWPLabel;
        private System.Windows.Forms.LinkLabel ItemsCopyWPLabelLink;
        private System.Windows.Forms.Timer timer1;
    }
}

