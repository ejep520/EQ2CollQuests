using System;
using System.Xml.Linq;

namespace EQ2CollQuests
{
    public class QuestItem : IComparable<QuestItem>
    {
        public string ItemName;
        public long DaybreakID;
        public short ItemLvl;
        public bool LoreFlag, NoTradeFlag;
        /// <summary>This is a do-nothing constructor. Plz do not use it.</summary>
        public QuestItem()
        {
            ItemName = string.Empty;
            DaybreakID = 0;
            ItemLvl = 0;
            LoreFlag = false;
            NoTradeFlag = false;
        }
        /// <summary>This is the active constructor. Use this.</summary>
        /// <param name="name">The name of the new item.</param>
        /// <param name="DaybreakID">The Daybreak Identification number.</param>
        /// <param name="ItemLvl">The level of the item.</param>
        /// <param name="LoreFlag">Indicates if the item's LORE flag is set.</param>
        /// <param name="NoTradeFlag">Indicates if the items NOTRADE flag is set.</param>
        public QuestItem(string ItemName, long DaybreakID, short ItemLvl, bool LoreFlag, bool NoTradeFlag, short Quantity = 0)
        {
            this.ItemName = ItemName;
            this.DaybreakID = DaybreakID;
            this.ItemLvl = ItemLvl;
            this.LoreFlag = LoreFlag;
            this.NoTradeFlag = NoTradeFlag;
        }
        public QuestItem(long DaybreakID)
        {
            XDocument xDocument = Program.GetThisURL(string.Concat(@"item/?c:show=displayname,id,itemlevel,",
                @"flags.lore,flags.notrade&id=", DaybreakID.ToString()));
            ParseXml(xDocument.Root.Element("item"));
        }
        /// <summary>This method will parse the XML element for an item into the fields.</summary>
        /// <param name="ItemElem">The &lt;item&gt; element to be parsed.</param>
        private void ParseXml(XElement ItemElem)
        {
            if (ItemElem.Name.ToString() != "item")
                throw new Exception("The wrong element was passed to QuestItem.ParseXml");
            ItemName = ItemElem.Attribute("displayname").Value;
            DaybreakID = long.Parse(ItemElem.Attribute("id").Value);
            ItemLvl = short.Parse(ItemElem.Attribute("itemlevel").Value);
            LoreFlag = ItemElem.Element("flags").Element("lore").Attribute("value").Value == "1";
            NoTradeFlag = ItemElem.Element("flags").Element("notrade").Attribute("value").Value == "1";
        }
        #region IComparable Implementation
        public int CompareTo(QuestItem x)
        {
            if (ItemName != x.ItemName)
                return ItemName.CompareTo(x.ItemName);
            if (DaybreakID != x.DaybreakID)
                return DaybreakID.CompareTo(x.DaybreakID);
            return GetHashCode().CompareTo(x.GetHashCode());
        }
        #endregion
        public override string ToString()
        {
            return ItemName;
        }
    }
}
