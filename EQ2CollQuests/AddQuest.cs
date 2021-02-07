using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace EQ2CollQuests
{
    public partial class AddQuest : Form
    {
        private DialogResult FinalResult = DialogResult.Retry;
        public CollQuest NewQuest;
        public Exception ReturnedException;
        internal class NamedResults
        {
            public long DaybreakID;
            public string QuestName;
            public string QuestCategory;
            /// <summary> This is a do-nothing constructor. Please don't use it.</summary>
            public NamedResults()
            {
                DaybreakID = 0;
                QuestName = string.Empty;
                QuestCategory = string.Empty;
            }
            public NamedResults(long DaybreakID, string QuestName, string QuestCategory)
            {
                this.DaybreakID = DaybreakID;
                this.QuestName = QuestName;
                this.QuestCategory = QuestCategory;
            }
            public override string ToString()
            {
                if (string.IsNullOrEmpty(QuestCategory))
                    return QuestName;
                else
                    return $"{QuestName} ({QuestCategory})";
            }
        }
        public AddQuest()
        {
            InitializeComponent();
        }
        private void AddQuestNameResetBtn_Click(object sender, EventArgs e)
        {
            AddQuestNameTB.Text = string.Empty;
            AddQuestNameResultsLB.Items.Clear();
            AddQuestNameResultsLB.Visible = false;
            AddQuestNameConfirmBtn.Visible = false;
            _ = AddQuestNameTB.Focus();
        }
        private void AddQuestNameSearchBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(AddQuestNameTB.Text))
                return;
            string SearchURL = string.Concat(@"collection/?c:limit=30&c:show=category,name,level,id,reference_list&name=^", AddQuestNameTB.Text);
            XDocument RawColl = Program.GetThisURL(SearchURL);
            if (!short.TryParse(RawColl.Root.Attribute("returned").Value, out short FoundQuests))
                return;
            if (FoundQuests == 0)
            {
                _ = MessageBox.Show("No quests were found. Please try again.",
                    "No Quests Found", MessageBoxButtons.OK);
                AddQuestNameResetBtn.PerformClick();
                return;
            }
            if (AddQuestNameResultsLB.Items.Count != 0)
                AddQuestNameResultsLB.Items.Clear();
            foreach(XElement thisColl in RawColl.Root.Elements("collection"))
            {
                AddQuestNameResultsLB.Items.Add(new NamedResults(long.Parse(thisColl.Attribute("id").Value),
                    thisColl.Attribute("name").Value, thisColl.Attribute("category").Value));
            }
            AddQuestNameResultsLB.Visible = true;
            AddQuestNameConfirmBtn.Visible = true;
            AddQuestNameConfirmBtn.Enabled = true;
        }
        private void AddQuestNameConfirmBtn_Click(object sender, EventArgs e)
        {
            if (AddQuestNameResultsLB.Items.Count == 0)
                return;
            if (AddQuestNameResultsLB.SelectedItems.Count > 1)
                return;
            if (AddQuestNameResultsLB.SelectedItem is NamedResults thisCQ)
            {
                if (Program.questList.ContainsKey(thisCQ.DaybreakID))
                {
                    _ = MessageBox.Show("This quest is already downloaded.",
                        "Already Downloaded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    try { NewQuest = new CollQuest(thisCQ.DaybreakID); }
                    catch (Exception Err)
                    {
                        ReturnedException = Err;
                        DialogResult = DialogResult.Abort;
                        Close();
                        return;
                    }
                    FinalResult = DialogResult.OK;
                    Close();
                }
            }
        }
        private void AddQuestIDResetBtn_Click(object sender, EventArgs e)
        {
            AddQuestIDMTB.Text = string.Empty;
            AddQuestIDResultsLB.Items.Clear();
            AddQuestIDResultsLB.Visible = false;
            AddQuestIDConfirmAdd.Visible = false;
            _ = AddQuestIDMTB.Focus();
        }
        private void AddQuestIDConfirmAdd_Click(object sender, EventArgs e)
        {
            if (AddQuestIDResultsLB.Items.Count == 0)
                return;
            if (AddQuestIDResultsLB.Items.Count == 1)
            {
                if ((AddQuestIDResultsLB.SelectedItem == null) && (AddQuestIDResultsLB.Items[0] is CollQuest unselCQ))
                {
                    DialogResult AddUnselected = MessageBox.Show($"Do you want to add the quest \"{unselCQ.QuestName}\"?",
                        "Add Unselected Quest", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (AddUnselected != DialogResult.Yes)
                        return;
                    NewQuest = unselCQ;
                    FinalResult = DialogResult.OK;
                    Close();
                    return;
                }
                else if (AddQuestIDResultsLB.SelectedItem is CollQuest thisCQ)
                {
                    NewQuest = thisCQ;
                    FinalResult = DialogResult.OK;
                    Close();
                    return;
                }
            }
            if (AddQuestIDResultsLB.Items.Count > 1)
            {
                if (AddQuestIDResultsLB.SelectedItem == null)
                    return;
                if (AddQuestIDResultsLB.SelectedItem is CollQuest thisCQ)
                {
                    NewQuest = thisCQ;
                    FinalResult = DialogResult.OK;
                    Close();
                }
            }
        }
        private void AddQuestIDSearch_Click(object sender, EventArgs e)
        {
            CollQuest TempQuest;
            if (string.IsNullOrWhiteSpace(AddQuestIDMTB.Text))
                return;
            if (!long.TryParse(AddQuestIDMTB.Text, out long NewDaybreakID))
                return;
            string SearchURL = string.Concat(@"collection/?c:limit=30&c:show=category,name,level,id,reference_list&name=^", NewDaybreakID.ToString());
            XDocument RawQuest = Program.GetThisURL(SearchURL);
            switch (short.Parse(RawQuest.Root.Attribute("returned").Value))
            {
                case 0:
                    _ = MessageBox.Show($"No quests were found with the ID {NewDaybreakID}. Please try again.",
                        "No Quests Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    AddQuestIDResetBtn.PerformClick();
                    return;
                case 1:
                    try { TempQuest = new CollQuest(NewDaybreakID); }
                    catch (Exception Err)
                    {
                        ReturnedException = Err;
                        FinalResult = DialogResult.Abort;
                        Close();
                        return;
                    }
                    break;
                default:
                    _ = MessageBox.Show($"Too many quests were found for the ID {NewDaybreakID} to be unique. Please try again.",
                        "Too Many Quests Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    AddQuestIDResetBtn.PerformClick();
                    return;
            }
            if (AddQuestIDResultsLB.Items.Count > 0)
                AddQuestIDResultsLB.Items.Clear();
            _ = AddQuestIDResultsLB.Items.Add(TempQuest);
            _ = AddQuestIDResultsLB.Focus();
            AddQuestIDResultsLB.SelectedIndex = 0;
        }
        private void AddQuest_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult = FinalResult;
        }
        private void AddQuestIDMTB_TypeValidationCompleted(object sender, TypeValidationEventArgs e)
        {
            AddQuestIDSearch.Enabled = e.IsValidInput;
            AddQuestIDSearch.Refresh();
        }

        private void AddQuestIDMTB_TextChanged(object sender, EventArgs e)
        {
            _ = AddQuestIDMTB.ValidateText();
        }
    }
}
