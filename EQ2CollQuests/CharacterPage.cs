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
            DialogResult AddCharResult = NewCharForm.ShowDialog();
            if (AddCharResult == DialogResult.OK)
            {
                CharGetAllQuests(NewCharForm.NewChar);
                foreach (long QuestID in NewCharForm.NewChar.CharCollection.Keys)
                {
                    _ = NewCharForm.NewChar.IsComplete(QuestID);
                }
                Program.charList[NewCharForm.NewChar.DaybreakID] = NewCharForm.NewChar;
                _ = CharListBox.Items.Add(NewCharForm.NewChar);
                _ = PlayingAsComboBox.Items.Add(NewCharForm.NewChar);
                dirties[0] = true;
                StatusStripDirtyIndicator.Text = FloppyString;
            }
            else if (AddCharResult == DialogResult.Abort)
            {
                BadEnd();
                throw NewCharForm.ReturnedException;
            }
            NewCharForm.Dispose();
            AllItemsPresentCheck();
            CharListBox_DrawItem(sender, null);
        }
        private void AddChar_Paint(object sender, PaintEventArgs e)
        {
            if (!AddChar.Enabled)
                AddChar.Enabled = true;
        }
        private void CharacterPage_Enter(object sender, EventArgs e)
        {
            CharacterPage_Resize(sender, e);
            CharListBox_DrawItem(sender, null);
            CharListBox.SelectedIndex = -1;
            CharIntroTxtBox.Text = string.Empty;
            CharQuestItemsCheckListBox.Items.Clear();
            CharQuestListBox.Items.Clear();
            _ = CharListBox.Focus();
        }
        private void CharacterPage_Leave(object sender, EventArgs e)
        {
            if (!(ActiveControl is TabPage))
                return;
            CharListBox.Items.Clear();
            CharQuestListBox.Items.Clear();
            CharQuestItemsCheckListBox.Items.Clear();
            CharIntroTxtBox.Text = string.Empty;
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
        }
        /// <summary>Downloads all of the quests <paramref name="thisChar"/> has started it hasn't already been.</summary>
        /// <param name="thisChar">The character being examined.</param>
        private void CharGetAllQuests(Characters thisChar)
        {
            int oldQuestCount = Program.questList.Count, oldItemCount = Program.itemList.Count;
            Cursor.Current = Cursors.WaitCursor;
            List<long> NewItemsList = new List<long>();
            ConcurrentBag<QuestItem> NewItemsBag = new ConcurrentBag<QuestItem>();
            StatusStripProgressBar.Maximum = thisChar.CharCollection.Count;
            StatusStripProgressBar.Value = 0;
            StatusStripProgressBar.Visible = true;
            foreach (long thisColl in thisChar.CharCollection.Keys)
            {
                if (!Program.questList.ContainsKey(thisColl))
                {
                    CollQuest TempQuest;
                    try { TempQuest = new CollQuest(thisColl); }
                    catch (Exception Err)
                    {
                        BadEnd();
                        throw Err;
                    }
                    Program.questList[TempQuest.DaybreakID] = TempQuest;
                    _ = Parallel.ForEach(TempQuest.items, thisItem =>
                    {
                        QuestItem TempItem;
                        if (!Program.itemList.ContainsKey(thisItem))
                        {
                            try { TempItem = new QuestItem(thisItem); }
                            catch (Exception Err)
                            {
                                BadEnd();
                                throw Err;
                            }
                            if (!NewItemsBag.Contains(TempItem))
                                NewItemsBag.Add(TempItem);
                        }
                    });
                }
                StatusStripProgressBar.Value++;
            }
            if (NewItemsBag.Count > 0)
            {
                foreach (QuestItem ThisItem in NewItemsBag)
                    Program.itemList[ThisItem.DaybreakID] = ThisItem;
            }
            Cursor.Current = Cursors.Default;
            StatusStripProgressBar.Visible = false;
            CharQuestListBox.Refresh();
            dirties[2] = (oldItemCount != Program.itemList.Count) || dirties[2];
            dirties[3] = (oldQuestCount != Program.questList.Count) || dirties[3];
            if (dirties[2] || dirties[3])
                StatusStripDirtyIndicator.Text = FloppyString;
        }
        private void CharListBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            CharListBox.Items.Clear();
            PlayingAsComboBox.Items.Clear();
            CharListBox.Enabled = true;
            PlayingAsComboBox.Enabled = true;
            if (Program.charList.Count == 0)
            {
                CharListBox.Items.Add("Empty!");
                CharListBox.Enabled = false;
            }
            else
            {
                CharListBox.Items.AddRange(Program.charList.Values.ToArray());
                PlayingAsComboBox.Items.AddRange(Program.charList.Values.ToArray());
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
            int OldItemCount;
            foreach (long thisColl in thisChar.CharCollection.Keys)
            {
                OldItemCount = thisChar.CharCollection[thisColl].Count;
                if (thisChar.IsComplete(thisColl) && HideCompletedOnChar)
                {
                    if (OldItemCount != thisChar.CharCollection[thisColl].Count)
                    {
                        dirties[0] = true;
                        UpdateDirtiesStatus();
                    }
                    continue;
                }
                else if (OldItemCount != thisChar.CharCollection[thisColl].Count)
                {
                    dirties[0] = true;
                    UpdateDirtiesStatus();
                }
                if ((!Program.questList.ContainsKey(thisColl)) && (GetAllQuests == DialogResult.Retry))
                {
                    GetAllQuests = MessageBox.Show($"{thisChar.name} has one or more missing quests.\nWould you like to download the missing quests now?",
                        "Missing Quests", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                }
                if (!Program.questList.ContainsKey(thisColl) && (GetAllQuests == DialogResult.Yes))
                {
                    CharGetAllQuests(thisChar);
                    CharQuestListBox.Items.Add(Program.questList[thisColl]);
                }
                else if (Program.questList.ContainsKey(thisColl))
                    CharQuestListBox.Items.Add(Program.questList[thisColl]);
            }
            CharQuestListBox.Refresh();
            if (CharListBox.SelectedIndex == -1)
            {
                UpdChar.Enabled = false;
                DelChar.Enabled = false;
            }
            else
            {
                UpdChar.Enabled = thisChar.GetType() == typeof(Characters);
                DelChar.Enabled = thisChar.GetType() == typeof(Characters);
            }
            UpdChar.Refresh();
            DelChar.Refresh();
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
            int OldCount = 0;
            if (thisChar == null)
            {
                CharQuestListBox.Items.Clear();
                _ = CharListBox.Focus();
                return;
            }
            if (thisChar.CharCollection.ContainsKey(thisQuest.DaybreakID))
            {
                OldCount = thisChar.CharCollection[thisQuest.DaybreakID].Count;
            }
            if (thisChar.CharCollection.ContainsKey(thisQuest.DaybreakID) && (OldCount != thisChar.CharCollection[thisQuest.DaybreakID].Count))
            {
                dirties[0] = true;
                UpdateDirtiesStatus();
            }
            foreach (long thisItemID in thisQuest.items)
            {
                QuestItem thisItem = Program.itemList[thisItemID];
                if (thisItem == null)
                {
                    try { thisItem = new QuestItem(thisItemID); }
                    catch (Exception Err)
                    {
                        BadEnd();
                        throw Err;
                    }
                    Program.itemList[thisItem.DaybreakID] = thisItem;
                    dirties[2] = true;
                    StatusStripDirtyIndicator.Text = FloppyString;
                }
                if (thisChar.IsComplete(thisQuest.DaybreakID))
                {
                    _ = CharQuestItemsCheckListBox.Items.Add(thisItem, true);
                }
                else
                {
                    _ = CharQuestItemsCheckListBox.Items.Add(thisItem, thisChar.CharCollection[thisQuest.DaybreakID].Contains(thisItemID));
                }
            }
            CharQuestItemsCheckListBox.Refresh();
        }
        private void CharQuestSplitContainer_SplitterMoved(object sender, SplitterEventArgs e)
        {
            CharQuestListBox.Location = new Point(CharIntroTxtBox.Left, CharIntroTxtBox.Bottom);
            CharQuestListBox.Height = CharQuestSplitContainer.Panel1.Height - CharIntroTxtBox.Height;
            CharQuestItemsCheckListBox.Height = CharQuestSplitContainer.Panel2.Height;
        }
        private void UpdChar_Click(object sender, EventArgs e)
        {
            if (CharListBox.SelectedIndex == -1)
            {
                if (CharQuestListBox.Items.Count > 0)
                {
                    CharQuestListBox.Items.Clear();
                }
                return;
            }

            if (CharListBox.SelectedItem is Characters thisChar)
            {
                Characters newChar;
                try { newChar = new Characters(thisChar.DaybreakID); }
                catch (Exception Err)
                {
                    BadEnd();
                    throw Err;
                }
                if (newChar.TimePlayed == Program.charList[thisChar.DaybreakID].TimePlayed)
                    return;
                Program.charList[thisChar.DaybreakID] = newChar;
                bool MissingQuests = false;
                foreach (long thisQuest in newChar.CharCollection.Keys)
                {
                    MissingQuests = (!Program.questList.ContainsKey(thisQuest)) || MissingQuests;
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
    }
}