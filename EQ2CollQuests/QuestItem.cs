using System;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace EQ2CollQuests
{
    public class QuestItem : IComparable<QuestItem>
    {
        public enum ItemsStaticLocValues
        {
            RandomLoc = 0,
            ZoneSpec = 1,
            LocSpec = 2,
            FixedLoc = ItemsStaticLocValues.ZoneSpec | ItemsStaticLocValues.LocSpec
        }
        public string ItemName;
        public long DaybreakID;
        public short ItemLvl;
        public bool LoreFlag, NoTradeFlag;
        [XmlIgnore] private double? _LocX, _LocY, _LocZ;
        [XmlIgnore] private ItemsStaticLocValues _StaticLoc;
        [XmlIgnore] private string _ZoneName = string.Empty;
        /// <value>
        ///     <list type="bullet">
        ///         <item>
        ///             <term>0</term>
        ///             <description>Loc and Zone disabled</description>
        ///         </item>
        ///         <item>
        ///             <term>1</term>
        ///             <description>Zone enabled</description>
        ///         </item>
        ///         <item>
        ///             <term>2</term>
        ///             <description>Loc enabled</description>
        ///         </item>
        ///         <item>
        ///             <term>3</term>
        ///             <description>Loc and Zone enabled</description>
        ///         </item>
        ///     </list>
        /// </value>
        public ItemsStaticLocValues StaticLoc
        {
            get { return _StaticLoc; }
            set
            {
                if (value == _StaticLoc)
                    return;
                switch (value)
                {
                    case ItemsStaticLocValues.RandomLoc:
                        ZoneName = string.Empty;
                        LocX = null;
                        LocY = null;
                        LocZ = null;
                        break;
                    case ItemsStaticLocValues.ZoneSpec:
                        LocX = null;
                        LocY = null;
                        LocZ = null;
                        break;
                    case ItemsStaticLocValues.LocSpec:
                        ZoneName = string.Empty;
                        break;
                }
                _StaticLoc = value;
            }
        }
        public double? LocX
        {
            get { return _LocX; }
            set { _LocX = Convert.ToBoolean(StaticLoc & ItemsStaticLocValues.LocSpec) ? value : null; }
        }
        public double? LocY
        {
            get { return _LocY; }
            set { _LocY = Convert.ToBoolean(StaticLoc & ItemsStaticLocValues.LocSpec) ? value : null; }
        }
        public double? LocZ
        {
            get { return _LocZ; }
            set { _LocZ = Convert.ToBoolean(StaticLoc & ItemsStaticLocValues.LocSpec) ? value : null; }
        }
        public string ZoneName
        {
            get { return _ZoneName; }
            set { _ZoneName = Convert.ToBoolean(StaticLoc & ItemsStaticLocValues.ZoneSpec) ? value : string.Empty; }
        }
        /// <summary>This is a do-nothing constructor. Please do not use it.</summary>
        public QuestItem()
        {
            ItemName = string.Empty;
            DaybreakID = 0;
            ItemLvl = 0;
            LoreFlag = false;
            NoTradeFlag = false;
            StaticLoc = 0;
        }
        /// <summary>This is the active constructor. Use this.</summary>
        /// <param name="name">The name of the new item.</param>
        /// <param name="DaybreakID">The Daybreak Identification number.</param>
        /// <param name="ItemLvl">The level of the item.</param>
        /// <param name="LoreFlag">Indicates if the item's LORE flag is set.</param>
        /// <param name="NoTradeFlag">Indicates if the items NOTRADE flag is set.</param>
        public QuestItem(string ItemName, long DaybreakID, short ItemLvl, bool LoreFlag, bool NoTradeFlag)
        {
            this.ItemName = ItemName;
            this.DaybreakID = DaybreakID;
            this.ItemLvl = ItemLvl;
            this.LoreFlag = LoreFlag;
            this.NoTradeFlag = NoTradeFlag;
        }
        /// <summary> Constructor for a new quest item. </summary>
        /// <param name="DaybreakID">The unique Daybreak ID number of the item being added.</param>
        /// <exception cref="Exception">If the wrong XML element is passed by this code, supporting code will throw an Exception.</exception>
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
            if (Convert.ToBoolean(StaticLoc))
                return $"{ItemName}*";
            else
                return ItemName;
        }
        
    }
}
