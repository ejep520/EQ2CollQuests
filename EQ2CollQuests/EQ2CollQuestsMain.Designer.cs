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
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TabControlStrip = new System.Windows.Forms.TabControl();
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
            this.QuestItemsTreeView = new System.Windows.Forms.TreeView();
            this.QuestIntroTextBox = new System.Windows.Forms.TextBox();
            this.ItemsPage = new System.Windows.Forms.TabPage();
            this.SettingsPage = new System.Windows.Forms.TabPage();
            this.ExpertMultExplained = new System.Windows.Forms.RichTextBox();
            this.SettingsExpertMultMTBLabel = new System.Windows.Forms.Label();
            this.SettingsExpertMultMTB = new System.Windows.Forms.MaskedTextBox();
            this.SettingsBoolCheckListBox = new System.Windows.Forms.CheckedListBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.StatusStripDirtyIndicator = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.menuStrip1.SuspendLayout();
            this.TabControlStrip.SuspendLayout();
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
            // 
            // itemsPageToolStripMenuItem
            // 
            this.itemsPageToolStripMenuItem.Name = "itemsPageToolStripMenuItem";
            this.itemsPageToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.itemsPageToolStripMenuItem.Text = "Items Page";
            // 
            // settingsPageToolStripMenuItem
            // 
            this.settingsPageToolStripMenuItem.Name = "settingsPageToolStripMenuItem";
            this.settingsPageToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.settingsPageToolStripMenuItem.Text = "Settings Page";
            // 
            // PlayingAsComboBox
            // 
            this.PlayingAsComboBox.BackColor = System.Drawing.SystemColors.MenuBar;
            this.PlayingAsComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PlayingAsComboBox.Name = "PlayingAsComboBox";
            this.PlayingAsComboBox.Size = new System.Drawing.Size(81, 23);
            this.PlayingAsComboBox.Text = "Playing as...";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 23);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // TabControlStrip
            // 
            this.TabControlStrip.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.TabControlStrip.Controls.Add(this.CharacterPage);
            this.TabControlStrip.Controls.Add(this.QuestsPage);
            this.TabControlStrip.Controls.Add(this.ItemsPage);
            this.TabControlStrip.Controls.Add(this.SettingsPage);
            this.TabControlStrip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControlStrip.Location = new System.Drawing.Point(0, 27);
            this.TabControlStrip.Name = "TabControlStrip";
            this.TabControlStrip.SelectedIndex = 0;
            this.TabControlStrip.Size = new System.Drawing.Size(800, 423);
            this.TabControlStrip.TabIndex = 1;
            this.TabControlStrip.SelectedIndexChanged += new System.EventHandler(this.TabControl1_SelectedIndexChanged);
            // 
            // CharacterPage
            // 
            this.CharacterPage.Controls.Add(this.CharListSplitContainer);
            this.CharacterPage.Location = new System.Drawing.Point(4, 4);
            this.CharacterPage.Name = "CharacterPage";
            this.CharacterPage.Padding = new System.Windows.Forms.Padding(3);
            this.CharacterPage.Size = new System.Drawing.Size(792, 397);
            this.CharacterPage.TabIndex = 0;
            this.CharacterPage.Text = "Character Page";
            this.CharacterPage.UseVisualStyleBackColor = true;
            this.CharacterPage.Enter += new System.EventHandler(this.CharacterPage_Enter);
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
            this.CharListSplitContainer.Size = new System.Drawing.Size(786, 391);
            this.CharListSplitContainer.SplitterDistance = 262;
            this.CharListSplitContainer.TabIndex = 0;
            this.CharListSplitContainer.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.CharListSplitContainer_SplitterMoved);
            // 
            // DelChar
            // 
            this.DelChar.Location = new System.Drawing.Point(127, 369);
            this.DelChar.Name = "DelChar";
            this.DelChar.Size = new System.Drawing.Size(68, 21);
            this.DelChar.TabIndex = 3;
            this.DelChar.Text = "Delete";
            this.DelChar.UseVisualStyleBackColor = true;
            // 
            // UpdChar
            // 
            this.UpdChar.Location = new System.Drawing.Point(71, 369);
            this.UpdChar.Name = "UpdChar";
            this.UpdChar.Size = new System.Drawing.Size(50, 22);
            this.UpdChar.TabIndex = 2;
            this.UpdChar.Text = "Update";
            this.UpdChar.UseVisualStyleBackColor = true;
            this.UpdChar.Click += new System.EventHandler(this.UpdChar_Click);
            this.UpdChar.Paint += new System.Windows.Forms.PaintEventHandler(this.UpdChar_Paint);
            // 
            // AddChar
            // 
            this.AddChar.Location = new System.Drawing.Point(5, 370);
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
            this.CharListBox.Size = new System.Drawing.Size(262, 355);
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
            this.CharQuestSplitContainer.Size = new System.Drawing.Size(520, 391);
            this.CharQuestSplitContainer.SplitterDistance = 224;
            this.CharQuestSplitContainer.TabIndex = 0;
            // 
            // CharQuestListBox
            // 
            this.CharQuestListBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.CharQuestListBox.FormattingEnabled = true;
            this.CharQuestListBox.Location = new System.Drawing.Point(0, 25);
            this.CharQuestListBox.Name = "CharQuestListBox";
            this.CharQuestListBox.Size = new System.Drawing.Size(520, 199);
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
            this.CharQuestItemsCheckListBox.Size = new System.Drawing.Size(520, 163);
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
            this.QuestsPage.Size = new System.Drawing.Size(792, 397);
            this.QuestsPage.TabIndex = 1;
            this.QuestsPage.Text = "Quests Page";
            this.QuestsPage.UseVisualStyleBackColor = true;
            this.QuestsPage.Enter += new System.EventHandler(this.QuestsPage_Enter);
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
            this.QuestListSplitContainer.Panel2.Controls.Add(this.QuestItemsTreeView);
            this.QuestListSplitContainer.Panel2.Controls.Add(this.QuestIntroTextBox);
            this.QuestListSplitContainer.Size = new System.Drawing.Size(786, 391);
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
            // QuestItemsTreeView
            // 
            this.QuestItemsTreeView.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.QuestItemsTreeView.Location = new System.Drawing.Point(0, 23);
            this.QuestItemsTreeView.Name = "QuestItemsTreeView";
            this.QuestItemsTreeView.Size = new System.Drawing.Size(601, 368);
            this.QuestItemsTreeView.TabIndex = 1;
            // 
            // QuestIntroTextBox
            // 
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
            // ItemsPage
            // 
            this.ItemsPage.Location = new System.Drawing.Point(4, 4);
            this.ItemsPage.Name = "ItemsPage";
            this.ItemsPage.Padding = new System.Windows.Forms.Padding(3);
            this.ItemsPage.Size = new System.Drawing.Size(792, 397);
            this.ItemsPage.TabIndex = 2;
            this.ItemsPage.Text = "Items Page";
            this.ItemsPage.UseVisualStyleBackColor = true;
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
            this.SettingsPage.Size = new System.Drawing.Size(792, 397);
            this.SettingsPage.TabIndex = 3;
            this.SettingsPage.Text = "Settings Page";
            this.SettingsPage.UseVisualStyleBackColor = true;
            this.SettingsPage.Enter += new System.EventHandler(this.SettingsPage_Enter);
            // 
            // ExpertMultExplained
            // 
            this.ExpertMultExplained.BackColor = System.Drawing.SystemColors.Info;
            this.ExpertMultExplained.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ExpertMultExplained.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ExpertMultExplained.Location = new System.Drawing.Point(3, 66);
            this.ExpertMultExplained.Name = "ExpertMultExplained";
            this.ExpertMultExplained.ReadOnly = true;
            this.ExpertMultExplained.Size = new System.Drawing.Size(786, 328);
            this.ExpertMultExplained.TabIndex = 3;
            this.ExpertMultExplained.Text = "";
            // 
            // SettingsExpertMultMTBLabel
            // 
            this.SettingsExpertMultMTBLabel.AutoSize = true;
            this.SettingsExpertMultMTBLabel.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SettingsExpertMultMTBLabel.Location = new System.Drawing.Point(75, 42);
            this.SettingsExpertMultMTBLabel.Name = "SettingsExpertMultMTBLabel";
            this.SettingsExpertMultMTBLabel.Size = new System.Drawing.Size(203, 18);
            this.SettingsExpertMultMTBLabel.TabIndex = 2;
            this.SettingsExpertMultMTBLabel.Text = "Expert Collection Multiplier";
            // 
            // SettingsExpertMultMTB
            // 
            this.SettingsExpertMultMTB.Location = new System.Drawing.Point(6, 43);
            this.SettingsExpertMultMTB.Mask = "90.099";
            this.SettingsExpertMultMTB.Name = "SettingsExpertMultMTB";
            this.SettingsExpertMultMTB.PromptChar = ' ';
            this.SettingsExpertMultMTB.Size = new System.Drawing.Size(63, 20);
            this.SettingsExpertMultMTB.TabIndex = 1;
            // 
            // SettingsBoolCheckListBox
            // 
            this.SettingsBoolCheckListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SettingsBoolCheckListBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.SettingsBoolCheckListBox.FormattingEnabled = true;
            this.SettingsBoolCheckListBox.Location = new System.Drawing.Point(3, 3);
            this.SettingsBoolCheckListBox.Name = "SettingsBoolCheckListBox";
            this.SettingsBoolCheckListBox.Size = new System.Drawing.Size(786, 30);
            this.SettingsBoolCheckListBox.TabIndex = 0;
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
            // 
            // StatusStripProgressBar
            // 
            this.StatusStripProgressBar.Name = "StatusStripProgressBar";
            this.StatusStripProgressBar.Size = new System.Drawing.Size(100, 20);
            this.StatusStripProgressBar.ToolTipText = "Current Progress";
            this.StatusStripProgressBar.Visible = false;
            // 
            // EQ2CollQuestsMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.TabControlStrip);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "EQ2CollQuestsMain";
            this.Text = "EQ2 Collection Quests";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EQ2CollQuestsMainClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.TabControlStrip.ResumeLayout(false);
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
            this.QuestListSplitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.QuestListSplitContainer)).EndInit();
            this.QuestListSplitContainer.ResumeLayout(false);
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
        private System.Windows.Forms.TabControl TabControlStrip;
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
    }
}

