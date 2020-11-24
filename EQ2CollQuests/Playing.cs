using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EQ2CollQuests
{
    public partial class Playing : Form
    {
        private readonly long PAChosenChar;
        private readonly double ExpertMult;
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
                return $"{Program.charList.Find(p => p.DaybreakID == CharID).name} ({GreedRate.ToString("P1")})";
            }
        }
        public Playing(long ChosenOne, double ExpertMult)
        {
            InitializeComponent();
            this.ExpertMult = ExpertMult;
            PAChosenChar = ChosenOne;
            Text = $"Playing as {Program.charList.Find(p => p.DaybreakID == PAChosenChar).name}";
        }
        private void PAItemList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((PAItemList.SelectedIndex == -1) ||
                ((PAItemList.SelectedIndex == 0) &&
                (PAItemList.SelectedItem is string thisString) &&
                (thisString == "Empty!")))
            {
                return;
            }
            const string Surplus = "This item is surplus. It may be sold.";
            long ThisID;
            try { ThisID = (PAItemList.SelectedItem as ItemsFormat).ItemID; }
            catch (NullReferenceException)
            {
                // Do nothing, clear Panel 2 and return.
                return;
            }
            int ThisQuant = (PAItemList.SelectedItem as ItemsFormat).ItemQuant;
            QuestItem ThisItem = Program.itemList.Find(p => p.DaybreakID == ThisID);
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
                    PAIntroLabel.Text = $"{Program.charList.Find(p => p.DaybreakID == PAChosenChar).name} may add {ThisItem.ItemName} to {Program.questList.Find(p => p.DaybreakID == CharsWants[PAChosenChar].QuestID).QuestName}.";
                }
                else if (WantingChars.Count == 1)
                {
                    PAIntroLabel.Text = $"If possible, please mail {Program.charList.Find(p => p.DaybreakID == WantingChars[0]).name} {ThisItem.ItemName} for {Program.questList.Find(p => p.DaybreakID == CharsWants[WantingChars[0]].QuestID).QuestName}.";
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
                PAListBoxResults.SelectedIndex = -1;
            }
        }
        private Dictionary<long, WantResults> GetWants(QuestItem ThisItem)
        {
            Dictionary<long, WantResults> returnValue = new Dictionary<long, WantResults>();
            Dictionary<long, int> QuestDict = new Dictionary<long, int>();
            foreach (CollQuest ThisQuest in from CollQuest ThisQuest in Program.questList
                                            where ThisQuest.items.Contains(ThisItem.DaybreakID)
                                            select ThisQuest)
            {
                QuestDict[ThisQuest.DaybreakID] = ThisQuest.items.Count;
            }
            if (QuestDict.Count < 1)
            {
                throw new Exception("No quests exist for the item being sought. This should never happen.");
            }
            foreach ((Characters ThisChar, KeyValuePair<long, int> ThisQuest) in from Characters ThisChar in Program.charList
                                                                                 from KeyValuePair<long, int> ThisQuest in QuestDict
                                                                                 select (ThisChar, ThisQuest))
            {
                if ((!returnValue.ContainsKey(ThisChar.DaybreakID)) &&
                    (!ThisChar.CharCollection.ContainsKey(ThisQuest.Key)))
                {
                    returnValue[ThisChar.DaybreakID] = new WantResults() { QuestID = ThisQuest.Key, GreedRate = 0.0 };
                }
                else if (!ThisChar.CharCollection.ContainsKey(ThisQuest.Key))
                {
                    continue;  // A want already exists for this character and it is >= 0.
                }
                else if (!returnValue.ContainsKey(ThisChar.DaybreakID))
                {
                    if (ThisChar.CharCollection[ThisQuest.Key].Contains(ThisItem.DaybreakID))
                        continue;
                    if (Program.questList.Find(p => p.DaybreakID == ThisQuest.Key).ExpertColl)
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
                    double OldVal = returnValue[ThisChar.DaybreakID].GreedRate;
                    double NewVal = ((double)ThisChar.CharCollection[ThisQuest.Key].Count) / ThisQuest.Value;
                    if (Program.questList.Find(p => p.DaybreakID == ThisQuest.Key).ExpertColl)
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
            if (PAListBoxResults.SelectedIndex == -1)
                return;
            if (PAListBoxResults.SelectedItem is ResultsBoxItem boxItem)
            {
                if (!Program.charList.Find(p => p.DaybreakID == boxItem.CharID).CharCollection.ContainsKey(boxItem.QuestID))
                    Program.charList.Find(p => p.DaybreakID == boxItem.CharID).CharCollection[boxItem.QuestID] = new List<long>();
                Program.charList.Find(p => p.DaybreakID == boxItem.CharID).CharCollection[boxItem.QuestID].Add((PAItemList.SelectedItem as ItemsFormat).ItemID);
                Refresh();
                PAItemList.SelectedIndex = -1;
                PAIntroLabel.Text = string.Empty;
                PAListBoxResults.Items.Clear();
                _ = PAItemList.Focus();
                DialogResult = DialogResult.OK;
            }
        }

        private void PAResetBtn_Click(object sender, EventArgs e)
        {
            Refresh();
            PAItemList.SelectedIndex = -1;
            PAIntroLabel.Text = string.Empty;
            PAListBoxResults.Items.Clear();
            _ = PAItemList.Focus();
        }
        private void Playing_Paint(object sender, PaintEventArgs e)
        {
            PAIntroLabel.Text = string.Empty;
            int charCountdown = 0, questCount;
            foreach (QuestItem questItem in Program.itemList)
            {
                questCount = Program.questList.FindAll(p => p.items.Contains(questItem.DaybreakID)).Count * Program.charList.Count;
                foreach (Characters characters in Program.charList)
                {
                    foreach (List<long> ThisList in characters.CharCollection.Values)
                    {
                        if (ThisList.Contains(questItem.DaybreakID))
                        {
                            charCountdown++;
                        }
                    }
                }
                questCount -= charCountdown;
                if (questCount < 0)
                    throw new Exception($"The characters have collected more {questItem.ItemName} than the number of quests needing it * the number of characters.");
                _ = PAItemList.Items.Add(new ItemsFormat(questItem.ItemName, questCount, questItem.DaybreakID));
                charCountdown = 0;
            }
        }
    }
}
