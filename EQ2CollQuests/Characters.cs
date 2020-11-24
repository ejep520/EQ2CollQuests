using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace EQ2CollQuests
{
    public class Characters:IComparable<Characters>, IXmlSerializable, IDisposable
    {
        public struct KeyEntry
        {
            public long Key;
            public List<long> Item;
        }
        [XmlIgnore] public readonly Dictionary<long, List<long>> CharCollection = new Dictionary<long, List<long>>();
        public string name;
        public short AdvLvl, AdvClass;
        public long TimePlayed, DaybreakID;
        public Characters()
        {
            name = string.Empty;
            AdvLvl = -1;
            TimePlayed = -1;
            DaybreakID = -1;
        }
        public Characters(XElement CharElem, XElement CharMiscElem)
        {
            ParseXChar(CharElem, CharMiscElem);
        }
        public Characters(long CharID)
        {
            XDocument XCharDoc = Program.GetThisURL(string.Concat(@"character/?c:show=displayname,",
                @"type.level,type.ts_level,type.classid,playedtime,id&id=", CharID.ToString()));
            XDocument XCharMiscDoc = Program.GetThisURL(string.Concat(@"character_misc/?c:show=collection_list&id=",
                CharID.ToString()));
            ParseXChar(XCharDoc.Root.Element("character"), XCharMiscDoc.Root.Element("character_misc"));
        }
        private void ParseXChar(XElement CharElement, XElement CharMiscElement)
        {
            long TempCollID;
            XElement TypeElement = CharElement.Element("type");
            name = CharElement.Attribute("displayname").Value.Split(' ')[0];
            AdvLvl = short.Parse(TypeElement.Attribute("level").Value);
            AdvClass = short.Parse(TypeElement.Attribute("classid").Value);
            TimePlayed = long.Parse(CharElement.Attribute("playedtime").Value);
            DaybreakID = long.Parse(CharElement.Attribute("id").Value);
            foreach (XElement thisColl in CharMiscElement.Element("collection_list").Elements("collection"))
            {
                TempCollID = long.Parse(thisColl.Attribute("crc").Value);
                if (CharCollection.ContainsKey(TempCollID))
                    throw new Exception($"{name} has more than one instance of collection quest number {TempCollID}.");
                else
                    CharCollection[TempCollID] = new List<long>();
                foreach (XElement thisItem in thisColl.Element("item_list").Elements("item"))
                    CharCollection[TempCollID].Add(long.Parse(thisItem.Attribute("crc").Value));
            }
        }
        public int CompareTo(Characters x)
        {
            if (name != x.name)
                return name.CompareTo(x.name);
            if (AdvLvl != x.AdvLvl)
                return AdvLvl.CompareTo(x.AdvLvl);
            return TimePlayed.CompareTo(x.TimePlayed);
        }
        #region IXmlSerializeable Implementation
        public XmlSchema GetSchema() { return null; }
        public void ReadXml(XmlReader reader)
        {
            List<KeyEntry> keyEntries;
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<KeyEntry>));
            _ = reader.MoveToContent();
            reader.ReadStartElement("Characters");
            name = reader.GetAttribute("name");
            AdvLvl = short.Parse(reader.GetAttribute("AdvLvl"));
            AdvClass = short.Parse(reader.GetAttribute("AdvClass"));
            TimePlayed = long.Parse(reader.GetAttribute("TimePlayed"));
            DaybreakID = long.Parse(reader.GetAttribute("DaybreakID"));
            reader.ReadStartElement("Character");
            keyEntries = (List<KeyEntry>)xmlSerializer.Deserialize(reader);
            foreach(KeyEntry keyEntry in keyEntries)
            {
                if (!CharCollection.ContainsKey(keyEntry.Key))
                    CharCollection[keyEntry.Key] = new List<long>();
                CharCollection[keyEntry.Key].AddRange(keyEntry.Item);
            }
            keyEntries.Clear();
            reader.ReadEndElement();
            reader.ReadEndElement();
        }
        public void WriteXml(XmlWriter writer)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<KeyEntry>));
            List<KeyEntry> keyEntries = new List<KeyEntry>();
            foreach (KeyValuePair<long, List<long>> thisColl in CharCollection)
            {
                keyEntries.Add(new KeyEntry()
                {
                    Key = thisColl.Key,
                    Item = thisColl.Value
                });
            }
            writer.WriteStartElement("Character");
            writer.WriteAttributeString("name", name);
            writer.WriteAttributeString("AdvLvl", AdvLvl.ToString());
            writer.WriteAttributeString("AdvClass", AdvClass.ToString());
            writer.WriteAttributeString("TimePlayed", TimePlayed.ToString());
            writer.WriteAttributeString("DaybreakID", DaybreakID.ToString());
            xmlSerializer.Serialize(writer, keyEntries);
            writer.WriteFullEndElement();
            keyEntries.Clear();
        }
        #endregion
        public override string ToString()
        {
            return name;
        }
        public void Dispose()
        {
            name = string.Empty;
            AdvLvl = 0;
            AdvClass = 0;
            TimePlayed = 0;
            DaybreakID = 0;
            foreach (List<long> thisList in CharCollection.Values)
            {
                thisList.Clear();
            }
            CharCollection.Clear();
        }
    }
}
