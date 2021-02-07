using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace EQ2CollQuests
{
    public partial class Playing : Form
    {
        private DialogResult FinalResult = DialogResult.Cancel;
        private readonly long PAChosenChar;
        private readonly double ExpertMult;
        public Exception ReturnedException;
        public class ItemsFormat : IComparable<ItemsFormat>
        {
            public string ItemName;
            public int ItemQuant;
            public long ItemID;
            public ItemsFormat()
            {
                ItemName = "Invalid Name";
                ItemQuant = -1;
                ItemID = -1;
            }
            public ItemsFormat(string ItemName, int ItemQuant, long ItemID)
            {
                this.ItemName = ItemName;
                this.ItemQuant = ItemQuant;
                this.ItemID = ItemID;
            }
            public int CompareTo(ItemsFormat other)
            {
                return ItemName.CompareTo(other.ItemName);
            }
            public override string ToString()
            {
                if (ItemQuant == 0)
                    return $"{ItemName} ($$)";
                else
                    return $"{ItemName} ({ItemQuant})";
            }
        }
        public struct WantResults
        {
            public long QuestID;
            public double GreedRate;
        }
        public class ResultsBoxItem
        {
            public readonly long CharID, QuestID;
            public readonly double GreedRate;
            public ResultsBoxItem()
            {
                CharID = 0;
                QuestID = 0;
                GreedRate = 0;
            }
            public ResultsBoxItem(long CharID, long QuestID, double GreedRate)
            {
                this.CharID = CharID;
                this.QuestID = QuestID;
                this.GreedRate = GreedRate;
            }
            public override string ToString()
            {
                return $"{Program.charList[CharID].name} ({GreedRate:P1})";
            }
        }
        public readonly Dictionary<long, Characters> ServerMates = new Dictionary<long, Characters>();
        private ItemsFormat SelectedItem;
        public Playing(long ChosenOne, double ExpertMult)
        {
            InitializeComponent();
            this.ExpertMult = ExpertMult;
            PAChosenChar = ChosenOne;
            Text = $"Playing as {Program.charList[PAChosenChar].name}";
            short ServerID = Program.charList[ChosenOne].ServerID;
            foreach (Characters ThisChar in from Characters ThisChar in Program.charList.Values
                                     where ThisChar.ServerID == ServerID
                                     select ThisChar)
            {
                ServerMates[ThisChar.DaybreakID] = ThisChar;
            }

            CenterToParent();
        }
        private void PAItemList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((PAItemList.SelectedIndex == -1) ||
                ((PAItemList.SelectedIndex == 0) &&
                (PAItemList.SelectedItem is string thisString) &&
                (thisString == "Empty!")))
            {
                SelectedItem = null;
                return;
            }
            const string Surplus = "This item is surplus. It may be sold.";
            PAListBoxResults.Items.Clear();
            long ThisID;
            try { ThisID = (PAItemList.SelectedItem as ItemsFormat).ItemID; }
            catch (NullReferenceException)
            {
                PAListBoxResults.Items.Clear();
                return;
            }
            int ThisQuant = (PAItemList.SelectedItem as ItemsFormat).ItemQuant;
            QuestItem ThisItem = Program.itemList[ThisID];
            if (ThisQuant == 0)
            {
                PAIntroLabel.Text = Surplus;
                return;
            }
            else
            {
                Dictionary<long, WantResults> CharsWants = GetWants(ThisItem);
                if (CharsWants.Count == 0)
                {
                    PAIntroLabel.Text = Surplus;
                    return;
                }
                double biggestWant = CharsWants.Values.Select(p => p.GreedRate).Max();
                List<long> WantingChars = new List<long>();
                foreach (KeyValuePair<long, WantResults> ThisPair in CharsWants)
                {
                    if (ThisPair.Value.GreedRate == biggestWant)
                    {
                        WantingChars.Add(ThisPair.Key);
                    }
                }
                if (WantingChars.Contains(PAChosenChar))
                {
                    PAIntroLabel.Text = $"{Program.charList[PAChosenChar].name} may add {ThisItem.ItemName} to {Program.questList[CharsWants[PAChosenChar].QuestID].QuestName}.";
                }
                else if (WantingChars.Count == 1)
                {
                    PAIntroLabel.Text = $"If possible, please mail {ServerMates[WantingChars[0]].name} {ThisItem.ItemName} for {Program.questList[CharsWants[WantingChars[0]].QuestID].QuestName}.";
                }
                else
                {
                    PAIntroLabel.Text = "Multiple characters have equal want of this item. Please refer below.";
                }
                PAListBoxResults.Items.Clear();
                foreach (KeyValuePair<long, WantResults> keyValuePair in CharsWants)
                {
                    PAListBoxResults.Items.Add(new ResultsBoxItem(keyValuePair.Key, keyValuePair.Value.QuestID, keyValuePair.Value.GreedRate));
                }
                SelectedItem = PAItemList.SelectedItem as ItemsFormat;
                PAListBoxResults.SelectedIndex = -1;
            }
        }
        private Dictionary<long, WantResults> GetWants(QuestItem ThisItem)
        {
            Dictionary<long, WantResults> returnValue = new Dictionary<long, WantResults>(); // This will contain the charIDs as the key and the wantResults as the value.
            Dictionary<long, int> QuestDict = new Dictionary<long, int>(); // Contains each questID (key) that uses this item and the number of items required for those quests (value).
            foreach (CollQuest ThisQuest in Program.questList.Values)
            {
                if (ThisQuest.items.Contains(ThisItem.DaybreakID))
                {
                    QuestDict[ThisQuest.DaybreakID] = ThisQuest.items.Count;
                }
            }
            if (QuestDict.Count < 1)
            {
                FinalResult = DialogResult.Abort;
                ReturnedException = new Exception("No quests exist for the item being sought. This should never happen.");
                Close();
            }
            foreach ((Characters ThisChar, KeyValuePair<long, int> ThisQuest) in from Characters ThisChar in ServerMates.Values
                                                                                 from KeyValuePair<long, int> ThisQuest in QuestDict
                                                                                 select (ThisChar, ThisQuest))
            {
                if ((!returnValue.ContainsKey(ThisChar.DaybreakID)) &&
                    (!ThisChar.CharCollection.ContainsKey(ThisQuest.Key)))
                {
                    returnValue[ThisChar.DaybreakID] = new WantResults()
                    {
                        QuestID = ThisQuest.Key,
                        GreedRate = 0.0
                    };
                }
                else if (!ThisChar.CharCollection.ContainsKey(ThisQuest.Key))
                {
                    continue;  // A want already exists for this character and it is >= 0.
                }
                else if (!returnValue.ContainsKey(ThisChar.DaybreakID))
                {
                    int OldValue = ThisChar.CharCollection[ThisQuest.Key].Count;
                    if (ThisChar.CharCollection[ThisQuest.Key].Contains(ThisItem.DaybreakID) || ThisChar.IsComplete(ThisQuest.Key))
                    {
                        if ((OldValue != ThisChar.CharCollection[ThisQuest.Key].Count) && (FinalResult == DialogResult.Retry))
                        {
                            FinalResult = DialogResult.OK;
                        }
                        continue;
                    }

                    if (Program.questList[ThisQuest.Key].ExpertColl)
                        returnValue[ThisChar.DaybreakID] = new WantResults()
                        {
                            QuestID = ThisQuest.Key,
                            GreedRate = ((double)ThisChar.CharCollection[ThisQuest.Key].Count) / ThisQuest.Value * ExpertMult
                        };
                    else
                        returnValue[ThisChar.DaybreakID] = new WantResults()
                        {
                            QuestID = ThisQuest.Key,
                            GreedRate = ((double)ThisChar.CharCollection[ThisQuest.Key].Count) / ThisQuest.Value
                        };
                }
                else if((QuestDict.Count > 1) && (ThisQuest.Key != QuestDict.Keys.First()))
                {
                    if (ThisChar.CharCollection[ThisQuest.Key].Contains(ThisItem.DaybreakID))
                        continue;
                    double OldVal = returnValue[ThisChar.DaybreakID].GreedRate;
                    double NewVal = ((double)ThisChar.CharCollection[ThisQuest.Key].Count) / ThisQuest.Value;
                    if (Program.questList[ThisQuest.Key].ExpertColl)
                    {
                        NewVal *= ExpertMult;
                    }
                    if (OldVal < NewVal)
                    {
                        returnValue[ThisChar.DaybreakID] = new WantResults()
                        {
                            QuestID = ThisQuest.Key,
                            GreedRate = NewVal
                        };
                    }
                }
            }
            return returnValue;
        }
        private void PAConfirmAdd_Click(object sender, EventArgs e)
        {
            if (PAItemList.SelectedIndex == -1)
            {
                int ConfirmIndex = PAListBoxResults.SelectedIndex;
                PAItemList.SelectedItem = SelectedItem;
                PAListBoxResults.SelectedIndex = ConfirmIndex;
            }
            if (PAListBoxResults.SelectedIndex == -1)
            {
                string ItemName = PAItemList.SelectedItem.ToString();
                _ = MessageBox.Show($"Please select the character getting {ItemName.Substring(0, ItemName.LastIndexOf('('))} and try again.",
                    "No Character Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (PAListBoxResults.SelectedItem is ResultsBoxItem boxItem)
            {
                // int CharIndex = ServerMates.IndexOf(ServerMates.Find(p => p.DaybreakID == boxItem.CharID));
                if (!ServerMates[boxItem.CharID].CharCollection.ContainsKey(boxItem.QuestID))
                    ServerMates[boxItem.CharID].CharCollection[boxItem.QuestID] = new List<long>();
                ServerMates[boxItem.CharID].CharCollection[boxItem.QuestID].Add((PAItemList.SelectedItem as ItemsFormat).ItemID);
                PAItemList.SelectedIndex = -1;
                Confirm_Cull(PAListBoxResults.SelectedItem as ResultsBoxItem);
                PAListBoxResults.Items.Clear();
                PAIntroLabel.Text = string.Empty;
                _ = PAItemList.Focus();
                if (FinalResult == DialogResult.Cancel)
                    FinalResult = DialogResult.OK;
            }
        }
        private void Confirm_Cull(ResultsBoxItem resultsBoxItem)
        {
            List<ItemsFormat> QuestItemFormats = new List<ItemsFormat>();
            List<QuestItem> QuestItemList = new List<QuestItem>();
            //int QuestIndex = Program.questList.IndexOf(Program.questList.Find(p => p.DaybreakID == resultsBoxItem.QuestID));
            int QuestCount, CharCountdown = 0;
            List<long> QuestList = new List<long>();
            foreach (object ThisObject in PAItemList.Items)
            {
                ItemsFormat ThisItem = ThisObject as ItemsFormat;
                if (Program.questList[resultsBoxItem.QuestID].items.Contains(ThisItem.ItemID))
                {
                    QuestItemFormats.Add(ThisItem);
                    QuestItemList.Add(Program.itemList[ThisItem.ItemID]);
                }
            }
            foreach (ItemsFormat itemsFormat in QuestItemFormats)
            {
                PAItemList.Items.Remove(itemsFormat);
            }
            foreach (QuestItem questItem in QuestItemList)
            {
                foreach (CollQuest ThisQuest in Program.questList.Values)
                {
                    if (ThisQuest.items.Contains(questItem.DaybreakID))
                        QuestList.Add(ThisQuest.DaybreakID);
                }
                QuestCount = QuestList.Count * ServerMates.Count;
                foreach (Characters ThisChar in ServerMates.Values)
                {
                    foreach (long ThisQuest in QuestList)
                    {
                        int OldCount = Program.questList[ThisQuest].items.Count;
                        if (ThisChar.IsComplete(ThisQuest) || (ThisChar.CharCollection.ContainsKey(ThisQuest) && ThisChar.CharCollection[ThisQuest].Contains(questItem.DaybreakID)))
                        {
                            CharCountdown++;
                        }
                        if ((OldCount != Program.questList[ThisQuest].items.Count) && (FinalResult == DialogResult.Retry))
                        {
                            FinalResult = DialogResult.OK;
                        }
                    }
                }
                QuestCount -= CharCountdown;
                if (QuestCount < 0)
                {
                    ReturnedException = new Exception($"The characters have collected more {questItem.ItemName} than the number of quests needing it * the number of characters.");
                    FinalResult = DialogResult.Abort;
                    Close();
                }
                _ = PAItemList.Items.Add(new ItemsFormat(questItem.ToString(), QuestCount, questItem.DaybreakID));
                CharCountdown = 0;
                QuestCount = 0;
                QuestList.Clear();
            }

        }
        private void PAResetBtn_Click(object sender, EventArgs e)
        {
            Refresh();
            PAItemList.SelectedIndex = -1;
            PAIntroLabel.Text = string.Empty;
            PAListBoxResults.Items.Clear();
            SelectedItem = null;
            _ = PAItemList.Focus();
        }
        private void Playing_Paint(object sender, PaintEventArgs e)
        {
            Console.WriteLine("Paint Playing Fired.");
            PAIntroLabel.Text = string.Empty;
            PAItemList.Items.Clear();
            int questCount, charCountdown = 0;
            List<long> QuestList = new List<long>();
            foreach (QuestItem questItem in Program.itemList.Values)
            {
                foreach (CollQuest ThisQuest in Program.questList.Values)
                {
                    if (ThisQuest.items.Contains(questItem.DaybreakID))
                        QuestList.Add(ThisQuest.DaybreakID);
                }
                foreach (Characters characters in ServerMates.Values)
                {
                    foreach (long ThisQuest in QuestList)
                    {
                        if (characters.IsComplete(ThisQuest) || (characters.CharCollection.ContainsKey(ThisQuest) && characters.CharCollection[ThisQuest].Contains(questItem.DaybreakID)))
                        {
                            charCountdown++;
                        }
                    }
                }
                questCount = (QuestList.Count * ServerMates.Count) - charCountdown;
                if (questCount < 0)
                {
                    ReturnedException = new Exception($"The characters have collected more {questItem.ItemName} than the number of quests needing it * the number of characters.");
                    FinalResult = DialogResult.Abort;
                    Close();
                }
                _ = PAItemList.Items.Add(new ItemsFormat(questItem.ToString(), questCount, questItem.DaybreakID));
                charCountdown = 0;
                QuestList.Clear();
            }
        }
        private void Playing_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult = FinalResult;
        }
    }
}
