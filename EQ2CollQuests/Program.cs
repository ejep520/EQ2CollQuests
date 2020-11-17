using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace EQ2CollQuests
{
    static class Program
    {
        internal const string Foldername = "EQ2CollectionQuests";
        internal static readonly HttpClient httpClient = new HttpClient() { BaseAddress = new Uri(@"http://census.daybreakgames.com/s:ejep520/xml/get/eq2/") };
        internal static readonly List<Characters> charList = new List<Characters>();
        internal static readonly List<CollQuest> questList = new List<CollQuest>();
        internal static readonly List<QuestItem> itemList = new List<QuestItem>();
        internal static readonly string TempChar = Path.GetTempFileName();
        internal static readonly string TempQuest = Path.GetTempFileName();
        internal static readonly string TempItems = Path.GetTempFileName();
        internal static readonly string TempSetts = Path.GetTempFileName();
        internal static readonly string DefChar = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), Foldername, "Characters.xml");
        internal static readonly string DefQuest = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), Foldername, "Quests.xml");
        internal static readonly string DefItems = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), Foldername, "Items.xml");
        internal static readonly string DefSetts = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), Foldername, "Settings.xml");
        internal static readonly string BakChar = string.Concat(DefChar.Substring(0, DefChar.Length - 3), "bak");
        internal static readonly string BakQuest = string.Concat(DefQuest.Substring(0, DefQuest.Length - 3), "bak");
        internal static readonly string BakItems = string.Concat(DefItems.Substring(0, DefItems.Length - 3), "bak");
        internal static readonly string BakSetts = string.Concat(DefSetts.Substring(0, DefSetts.Length - 3), "bak");
        internal static readonly string BadChar = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), Foldername, "Characters.tmp");
        internal static readonly string BadSetts = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), Foldername, "Settings.tmp");
        internal static readonly string BadItems = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), Foldername, "Items.tmp");
        internal static readonly string BadQuest = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), Foldername, "Collections.tmp");
        internal static readonly Dictionary<short, string> AdvClasses = new Dictionary<short, string>();
        /// <summary>The main entry point for the application.</summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new EQ2CollQuestsMain());
            httpClient.Dispose();
        }
        internal static XDocument GetThisURL(string UrlSuffix)
        {
            XDocument ReturnVal;
            int ErrCount = 0;
            Task<string> RawXml = httpClient.GetStringAsync(UrlSuffix);
            RawXml.Wait();
            while (RawXml.IsFaulted && (ErrCount < 3))
            {
                Thread.Sleep(3000);
                ErrCount++;
                RawXml = httpClient.GetStringAsync(UrlSuffix);
                RawXml.Wait();
            }
            if (ErrCount >= 3)
            {
                throw RawXml.Exception.Flatten().InnerException;
            }
            ReturnVal = XDocument.Parse(RawXml.Result);
            return ReturnVal;
        }
    }
}
