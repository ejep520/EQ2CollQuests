using System;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;

namespace EQ2CollQuests
{
    public partial class EQ2CollQuestsMain : Form
    {
        private void QuestsAddQuestBtn_Click(object sender, EventArgs e)
        {
            AddQuest NewQuestForm = new AddQuest();
            if (NewQuestForm.ShowDialog() == DialogResult.OK)
            {
                Program.questList.Add(NewQuestForm.NewQuest);
                Program.questList.Sort();
                dirties[3] = true;
                StatusStripDirtyIndicator.Text = FloppyString;
            }
            NewQuestForm.Dispose();
            QuestListBox.Refresh();
        }
        private void QuestsPage_Enter(object sender, EventArgs e)
        {
            QuestItemsTreeView.Nodes.Clear();
            QuestListBox.Items.Clear();
            QuestListBox.Items.AddRange(Program.questList.ToArray());
        }
        private void QuestListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            QuestIntroTextBox.Text = string.Empty;
            QuestItemsTreeView.Nodes.Clear();
            if (QuestListBox.SelectedIndex == -1)
                return;
            if (QuestListBox.SelectedItem is CollQuest cq)
            {
                QuestIntroTextBox.Text = cq.ExpertColl ? $"{cq.QuestName} is a level {cq.QuestLvl} expert collection quest." : $"{cq.QuestName} is a level {cq.QuestLvl} collection quest.";
                foreach (long ThisItem in cq.items)
                {
                    if (Program.itemList.Find(p => p.DaybreakID == ThisItem) == null)
                    {
                        Program.itemList.Add(new QuestItem(ThisItem));
                        dirties[2] = true;
                        StatusStripDirtyIndicator.Text = FloppyString;
                    }
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
        private void QuestsPage_Resize(object sender, EventArgs e)
        {
            QuestsAddQuestBtn.Location = new Point(QuestListSplitContainer.Panel1.Left, QuestListSplitContainer.Panel1.Bottom - QuestsAddQuestBtn.Height);
            QuestsAddQuestBtn.Width = Convert.ToInt32(Math.Round(0.45 * QuestListSplitContainer.Panel1.Width));
            QuestListUpdateBtn.Width = QuestsAddQuestBtn.Width;
            QuestListUpdateBtn.Location = new Point(QuestListSplitContainer.Panel1.Right - QuestListUpdateBtn.Width, QuestsAddQuestBtn.Location.Y);
            QuestListBox.Height = QuestListSplitContainer.Height - QuestsAddQuestBtn.Height;
            QuestItemsTreeView.Height = QuestListSplitContainer.Panel2.Height - QuestIntroTextBox.Height;

        }
        private void QuestListSplitContainer_SplitterMoved(object sender, SplitterEventArgs e)
        {
            QuestsPage_Resize(sender, null);
        }
    }
}