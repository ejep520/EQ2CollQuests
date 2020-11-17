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
        public CollQuest NewQuest;
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
                AddQuestNameResetBtn_Click(sender, e);
                return;
            }
            if (AddQuestNameResultsLB.Items.Count != 0)
                AddQuestNameResultsLB.Items.Clear();
            foreach(XElement thisColl in RawColl.Root.Elements("collection"))
            {
                AddQuestNameResultsLB.Items.Add(new CollQuest(long.Parse(thisColl.Attribute("id").Value)));
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
            if (AddQuestNameResultsLB.SelectedItem is CollQuest thisCQ)
            {
                switch (Program.questList.FindAll(p => p.DaybreakID == thisCQ.DaybreakID).Count)
                {
                    case 0:
                        NewQuest = thisCQ;
                        DialogResult = DialogResult.OK;
                        Close();
                        break;
                    case 1:
                        _ = MessageBox.Show("This quest is already downloaded.",
                            "Already Downloaded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    default:
                        break;
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
            if (!AddQuestIDResultsLB.Visible)
                return;
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
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else if (AddQuestIDResultsLB.SelectedItem is CollQuest thisCQ)
                {
                    NewQuest = thisCQ;
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            if (AddQuestIDResultsLB.Items.Count > 1)
            {
                if (AddQuestIDResultsLB.SelectedItem == null)
                    return;
                if (AddQuestIDResultsLB.SelectedItem is CollQuest thisCQ)
                {
                    NewQuest = thisCQ;
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            return;
        }
    }
}
