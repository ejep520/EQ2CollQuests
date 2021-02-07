using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace EQ2CollQuests
{
    public class CollQuest : IComparable<CollQuest>
    {
        public string QuestName;
        public long DaybreakID;
        public short QuestLvl, ReqAdvLvl;
        public bool ExpertColl;
        public readonly List<long> items = new List<long>();
        /// <summary> This is a do-nothing constructor. Please do not use it. </summary>
        public CollQuest()
        {
            QuestName = string.Empty;
            DaybreakID = 0;
            QuestLvl = 0;
            items.Clear();
            ReqAdvLvl = 0;
            ExpertColl = false;
        }
        /// <summary>This is an active constructor taking the Daybreak ID number.</summary>
        /// <param name="DaybreakID">The unique Daybreak ID number for the new quest.</param>
        /// <exception cref="Exception">If the Daybreak ID returns more than one collection, this will result in an exception.</exception>
        public CollQuest(long DaybreakID)
        {
            XDocument xDocument = Program.GetThisURL(string.Concat(@"collection/?c:show=category,name,",
                @"level,id,reference_list&id=", DaybreakID.ToString()));
            short FoundNum = short.Parse(xDocument.Root.Attribute("returned").Value);
            if (FoundNum > 1)
            {
                throw new Exception($"More than one quest was found with the ID {DaybreakID}.");
            }
            else if (FoundNum == 0)
            {
                throw new Exception($"No quests were found with the ID {DaybreakID}.");
            }
            ParseXmlData(xDocument.Root.Element("collection"));
        }
        private void ParseXmlData(XElement RawColl)
        {
            long TempItemID;
            string TempCat;
            QuestName = RawColl.Attribute("name").Value;
            DaybreakID = long.Parse(RawColl.Attribute("id").Value);
            QuestLvl = short.Parse(RawColl.Attribute("level").Value);
            items.Clear();
            foreach (XElement thisItem in RawColl.Element("reference_list").Elements("reference"))
            {
                TempItemID = long.Parse(thisItem.Attribute("id").Value);
                items.Add(TempItemID);
            }
            TempCat = RawColl.Attribute("category").Value;
            ExpertColl = TempCat.ToLower().Contains("expert");
            if (TempCat.ToLower().StartsWith("chaos"))
                ReqAdvLvl = 110;
            else
                ReqAdvLvl = 0;
        }
        #region IComparable Implementation
        public int CompareTo(CollQuest x)
        {
            if (QuestName != x.QuestName)
                return QuestName.CompareTo(x.QuestName);
            else
                return DaybreakID.CompareTo(x.DaybreakID);
        }
        #endregion
        public override string ToString() { return QuestName; }
    }
}
