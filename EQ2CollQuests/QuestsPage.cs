using System;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;

namespace EQ2CollQuests
{
    public partial class EQ2CollQuestsMain : Form
    {
        private void QuestListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            QuestIntroTextBox.Text = string.Empty;
            QuestItemsTreeView.Nodes.Clear();
            QuestsLinkLabel.Links[0].LinkData = null;
            QuestsLinkLabel.Links[0].Enabled = false;
            QuestsLinkLabel.Links[1].LinkData = null;
            QuestsLinkLabel.Links[1].Enabled = false;
            if ((QuestListBox.SelectedIndex == -1) ||
                (!(QuestListBox.SelectedItem is CollQuest cq)))
            {
                return;
            }
            QuestIntroTextBox.Text = cq.ExpertColl ? $"{cq.QuestName} is a level {cq.QuestLvl} expert collection quest." : $"{cq.QuestName} is a level {cq.QuestLvl} collection quest.";
            foreach (long ThisItem in cq.items)
            {
                if (!Program.itemList.ContainsKey(ThisItem))
                {
                    try { Program.itemList[ThisItem] = new QuestItem(ThisItem); }
                    catch (Exception Err)
                    {
                        BadEnd();
                        throw Err;
                    }
                    dirties[2] = true;
                    StatusStripDirtyIndicator.Text = FloppyString;
                }
                TreeNode[] ItemChars = { };
                foreach (Characters thisChar in Program.charList.Values)
                {
                    int OldCount = 0;
                    if (thisChar.CharCollection.ContainsKey(cq.DaybreakID))
                    {
                        OldCount = thisChar.CharCollection[cq.DaybreakID].Count;
                    }
                    if (thisChar.IsComplete(cq.DaybreakID))
                    {
                        if (OldCount != thisChar.CharCollection[cq.DaybreakID].Count)
                        {
                            dirties[0] = true;
                            UpdateDirtiesStatus();
                        }
                        ItemChars = ItemChars.Append(new TreeNode($"{UnicodeCheckEx[0]} {thisChar} has collected this item.")).ToArray();
                    }
                    else if (!thisChar.CharCollection.ContainsKey(cq.DaybreakID))
                        ItemChars = ItemChars.Append(new TreeNode($"{UnicodeCheckEx[1]} {thisChar} has not collected this item.")).ToArray();
                    else if (!thisChar.CharCollection[cq.DaybreakID].Contains(ThisItem))
                        ItemChars = ItemChars.Append(new TreeNode($"{UnicodeCheckEx[1]} {thisChar} has not collected this item.")).ToArray();
                    else
                        ItemChars = ItemChars.Append(new TreeNode($"{UnicodeCheckEx[0]} {thisChar} has collected this item.")).ToArray();
                }
                _ = QuestItemsTreeView.Nodes.Add(
                    new TreeNode(Program.itemList[ThisItem].ItemName,
                    ItemChars));
            }
            QuestsExpertCheckBool.Checked = cq.ExpertColl;
            QuestsDaybreakIDTB.Text = cq.DaybreakID.ToString();
            bool ReqAdvLvl = Convert.ToBoolean(cq.ReqAdvLvl);
            QuestsNoReqAdvLvlRB.Checked = !ReqAdvLvl;
            QuestsReqAdvLvlRB.Checked = ReqAdvLvl;
            QuestsReqAdvLvlTB.Enabled = ReqAdvLvl;
            QuestsReqAdvLvlTB.Text = ReqAdvLvl ? cq.ReqAdvLvl.ToString() : string.Empty;
            QuestsLinkLabel.Links[0].LinkData = string.Concat(@"https://eq2.fandom.com/wiki/", cq.QuestName.Replace(' ', '_'));
            QuestsLinkLabel.Links[0].Enabled = true;
            QuestsLinkLabel.Links[1].LinkData = string.Concat(@"https://u.eq2wire.com/collection/detail/", cq.DaybreakID.ToString());
            QuestsLinkLabel.Links[1].Enabled = true;
        }
        private void QuestListSplitContainer_SplitterMoved(object sender, SplitterEventArgs e)
        {
            QuestsPage_Resize(sender, null);
        }
        private void QuestsAddQuestBtn_Click(object sender, EventArgs e)
        {
            AddQuest NewQuestForm = new AddQuest();
            DialogResult NewQuestResult = NewQuestForm.ShowDialog();
            if (NewQuestResult == DialogResult.OK)
            {
                Program.questList[NewQuestForm.NewQuest.DaybreakID] = NewQuestForm.NewQuest;
                _ = QuestListBox.Items.Add(NewQuestForm.NewQuest);
                AllItemsPresentCheck();
                dirties[3] = true;
                StatusStripDirtyIndicator.Text = FloppyString;
            }
            else if (NewQuestResult == DialogResult.Abort)
            {
                BadEnd();
                throw NewQuestForm.ReturnedException;
            }
            NewQuestForm.Dispose();
            QuestListBox.Refresh();
        }
        private void QuestsPage_Enter(object sender, EventArgs e)
        {
            QuestItemsTreeView.Nodes.Clear();
            QuestListBox.Items.Clear();
            QuestListBox.Items.AddRange(Program.questList.Values.ToArray());
            QuestsNoReqAdvLvlRB.Checked = false;
            QuestsReqAdvLvlRB.Checked = false;
            QuestsReqAdvLvlTB.Text = string.Empty;
            QuestsDaybreakIDTB.Text = string.Empty;
            QuestIntroTextBox.Text = string.Empty;
            QuestsPage_Resize(sender, e);
        }
        private void QuestsPage_Resize(object sender, EventArgs e)
        {
            QuestsAddQuestBtn.Location = new Point(QuestListSplitContainer.Panel1.Left, QuestListSplitContainer.Panel1.Bottom - QuestsAddQuestBtn.Height);
            QuestsAddQuestBtn.Width = Convert.ToInt32(Math.Round(0.49 * QuestListSplitContainer.Panel1.Width));
            QuestListUpdateBtn.Width = QuestsAddQuestBtn.Width;
            QuestListUpdateBtn.Location = new Point(QuestListSplitContainer.Panel1.Right - QuestListUpdateBtn.Width, QuestsAddQuestBtn.Location.Y);
            QuestListBox.Height = QuestListSplitContainer.Height - QuestsAddQuestBtn.Height;
        }
        private void QuestsPage_Left(object sender, EventArgs e)
        {
            if (!(ActiveControl is TabPage))
                return;
            QuestListBox.Items.Clear();
            QuestIntroTextBox.Text = string.Empty;
            QuestItemsTreeView.Nodes.Clear();
        }
        private void QuestsExpertCheckBool_CheckedChanged(object sender, EventArgs e)
        {
            if ((!(QuestListBox.SelectedItem is CollQuest TempQuest)) ||
                (TempQuest.ExpertColl == QuestsExpertCheckBool.Checked))
                return;
            Program.questList[TempQuest.DaybreakID].ExpertColl = QuestsExpertCheckBool.Checked;
            (QuestListBox.SelectedItem as CollQuest).ExpertColl = QuestsExpertCheckBool.Checked;
            QuestIntroTextBox.Text = QuestsExpertCheckBool.Checked ?
                $"{TempQuest.QuestName} is a level {TempQuest.QuestLvl} expert collection quest." :
                $"{TempQuest.QuestName} is a level {TempQuest.QuestLvl} collection quest.";
            dirties[3] = true;
            UpdateDirtiesStatus();
        }
        private void QuestsNoReqAdvLvlRB_CheckedChanged(object sender, EventArgs e)
        {
            if (QuestsNoReqAdvLvlRB.Checked && QuestsReqAdvLvlRB.Checked)
            {
                QuestsReqAdvLvlRB.Checked = false;
            }
        }
        private void QuestsReqAdvLvlRB_CheckedChanged(object sender, EventArgs e)
        {
            if (QuestsReqAdvLvlRB.Checked)
            {
                if (QuestsNoReqAdvLvlRB.Checked)
                {
                    QuestsNoReqAdvLvlRB.Checked = false;
                }
                if ((QuestListBox.SelectedItem as CollQuest).ReqAdvLvl > 0)
                {
                    QuestsReqAdvLvlTB.Text = (QuestListBox.SelectedItem as CollQuest).ReqAdvLvl.ToString();
                }
                else
                {
                    QuestsReqAdvLvlTB.Text = string.Empty;
                }
            }
            else
            {
                QuestsReqAdvLvlTB.Text = string.Empty;
            }
            QuestsReqAdvLvlTB.Enabled = QuestsReqAdvLvlRB.Checked;
        }
        private void QuestsReqAdvLvlTB_TextChanged(object sender, EventArgs e)
        {
            if (!(QuestListBox.SelectedItem is CollQuest TempQuest))
                return;
            if (string.IsNullOrEmpty(QuestsReqAdvLvlTB.Text) &&
                QuestsNoReqAdvLvlRB.Checked &&
                (TempQuest.ReqAdvLvl != 0))
            {
                Program.questList[TempQuest.DaybreakID].ReqAdvLvl = 0;
                (QuestListBox.SelectedItem as CollQuest).ReqAdvLvl = 0;
                dirties[3] = true;
                UpdateDirtiesStatus();
                return;
            }
            else if (string.IsNullOrEmpty(QuestsReqAdvLvlTB.Text) &&
                QuestsNoReqAdvLvlRB.Checked &&
                (TempQuest.ReqAdvLvl == 0))
            {
                return;
            }
            if (!short.TryParse(QuestsReqAdvLvlTB.Text, out short NewReqLvl) ||
                (NewReqLvl == TempQuest.ReqAdvLvl))
                return;
            Program.questList[TempQuest.DaybreakID].ReqAdvLvl = NewReqLvl;
            (QuestListBox.SelectedItem as CollQuest).ReqAdvLvl = NewReqLvl;
            dirties[3] = true;
            UpdateDirtiesStatus();
        }
    }
}