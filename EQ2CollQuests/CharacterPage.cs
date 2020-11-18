using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EQ2CollQuests
{
    public partial class EQ2CollQuestsMain : Form
    {
        private void AddChar_Click(object sender, EventArgs e)
        {
            AddCharForm NewCharForm = new AddCharForm();
            if (NewCharForm.ShowDialog() == DialogResult.OK)
            {
                Program.charList.Add(NewCharForm.NewChar);
                Program.charList.Sort();
                CharGetAllQuests(NewCharForm.NewChar);
                dirties[0] = true;
                StatusStripDirtyIndicator.Text = FloppyString;
            }
            NewCharForm.Dispose();
            CharListBox_DrawItem(sender, null);
        }
        private void AddChar_Paint(object sender, PaintEventArgs e)
        {
            if (!AddChar.Enabled)
                AddChar.Enabled = true;
        }
        private void CharacterPage_Resize(object sender, EventArgs e)
        {
            AddChar.Location = new Point(CharListSplitContainer.Panel1.Left, CharListSplitContainer.Panel1.Bottom - AddChar.Height);
            AddChar.Width = Convert.ToInt32(Math.Round(CharListSplitContainer.Panel1.Width * 0.3, 0));
            DelChar.Width = AddChar.Width;
            DelChar.Location = new Point(CharListSplitContainer.Panel1.Right - DelChar.Width, CharListSplitContainer.Panel1.Bottom - DelChar.Height);
            UpdChar.Width = AddChar.Width;
            UpdChar.Location = new Point(AddChar.Right + Convert.ToInt32(Math.Round(CharListSplitContainer.Panel1.Width * 0.05, 0)), AddChar.Location.Y);
            CharListBox.Height = CharListSplitContainer.Panel1.Height - AddChar.Height;
            CharQuestSplitContainer.SplitterDistance = Convert.ToInt32(Math.Round(0.5 * CharQuestSplitContainer.Height));
            CharQuestListBox.Height = CharQuestSplitContainer.Panel1.Height - CharIntroTxtBox.Height;
        }
        private void CharacterPage_Enter(object sender, EventArgs e)
        {
            CharacterPage_Resize(sender, e);
            CharListBox_DrawItem(sender, null);
            CharListBox.SelectedIndex = -1;
            CharIntroTxtBox.Text = string.Empty;
            CharQuestItemsCheckListBox.Items.Clear();
        }
        private void CharGetAllQuests(Characters thisChar)
        {
            int oldQuestCount = Program.questList.Count, oldItemCount = Program.itemList.Count;
            ConcurrentBag<QuestItem> newItems;
            Cursor.Current = Cursors.WaitCursor;
            StatusStripProgressBar.Maximum = thisChar.CharCollection.Count;
            StatusStripProgressBar.Value = 0;
            StatusStripProgressBar.Visible = true;
            foreach (long thisColl in thisChar.CharCollection.Keys)
            {
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
                StatusStripProgressBar.Value++;
            }
            Cursor.Current = Cursors.Default;
            StatusStripProgressBar.Visible = false;
            Program.questList.Sort();
            Program.itemList.Sort();
            CharQuestListBox.Refresh();
            dirties[2] = (oldItemCount != Program.itemList.Count) || dirties[2];
            dirties[3] = (oldQuestCount != Program.questList.Count) || dirties[3];
            if (dirties[2] || dirties[3])
                StatusStripDirtyIndicator.Text = FloppyString;
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
            if (CharListBox.SelectedIndex == -1)
                return;
            if (CharListBox.SelectedItem is string)
            {
                CharIntroTxtBox.Text = string.Empty;
                return;
            }
            Characters thisChar = CharListBox.SelectedItem as Characters;
            CharIntroTxtBox.Text = $"{thisChar.name} is a {thisChar.AdvLvl} {Program.AdvClasses[thisChar.AdvClass]}";
            DialogResult GetAllQuests = DialogResult.Retry;
            foreach (long thisColl in thisChar.CharCollection.Keys)
            {
                switch (Program.questList.FindAll(p => p.DaybreakID == thisColl).Count)
                {
                    case 0:
                        if (GetAllQuests == DialogResult.Retry)
                        {
                            GetAllQuests = MessageBox.Show($"{thisChar.name} has one or more missing quests.\nWould you like to download the missing quests now?",
                                "Missing Quests", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        }
                        if (GetAllQuests == DialogResult.Yes)
                        {
                            CharGetAllQuests(thisChar);
                            CharQuestListBox.Items.Add(Program.questList.Find(p => p.DaybreakID == thisColl));
                        }
                        break;
                    case 1:
                        CharQuestListBox.Items.Add(Program.questList.Find(p => p.DaybreakID == thisColl));
                        break;
                    default:
                        throw new Exception("More than one quest was found with a \"unique\" identifier. This should never happen.");
                }
            }
            CharQuestListBox.Refresh();
            CharQuestListBox.SelectedIndex = -1;
        }
        private void CharListSplitContainer_SplitterMoved(object sender, SplitterEventArgs e)
        {
            CharacterPage_Resize(sender, null);
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
                    Program.itemList.Sort();
                    dirties[2] = true;
                    StatusStripDirtyIndicator.Text = FloppyString;
                }
                CharQuestItemsCheckListBox.Items.Add(thisItem, thisChar.CharCollection[thisQuest.DaybreakID].Contains(thisItemID));
            }
            CharQuestItemsCheckListBox.Refresh();
        }
        private void UpdChar_Click(object sender, EventArgs e)
        {
            if (CharListBox.SelectedIndex == -1)
                return;
            if (CharListBox.SelectedItem is Characters thisChar)
            {
                Characters newChar = new Characters(thisChar.DaybreakID);
                int CharLoc = Program.charList.FindIndex(p => p.DaybreakID == thisChar.DaybreakID);
                if (newChar.TimePlayed == Program.charList[CharLoc].TimePlayed)
                    return;
                Program.charList[CharLoc] = newChar;
                bool MissingQuests = false;
                foreach (long thisQuest in newChar.CharCollection.Keys)
                {
                    MissingQuests = (Program.questList.FindAll(p => p.DaybreakID == thisQuest).ToList().Count == 1) || MissingQuests;
                }
                if (MissingQuests)
                {
                    DialogResult GetAllQuests = MessageBox.Show($"{newChar.name} has one or more quests we haven't downloaded yet.\nDo you want to get them now?",
                        "Missing Quests", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (GetAllQuests != DialogResult.Yes)
                        return;
                    CharGetAllQuests(newChar);
                    Refresh();
                }
            }
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