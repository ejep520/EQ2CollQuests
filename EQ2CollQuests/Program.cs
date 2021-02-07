using EQ2CollQuests.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
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
        internal static readonly Dictionary<long, Characters> charList = new Dictionary<long, Characters>();
        internal static readonly Dictionary<long, CollQuest> questList = new Dictionary<long, CollQuest>();
        internal static readonly Dictionary<long, QuestItem> itemList = new Dictionary<long, QuestItem>();
        internal static readonly Dictionary<short, string> serverList = new Dictionary<short, string>();
        internal static readonly Dictionary<short, string> AdvClasses = new Dictionary<short, string>();
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
        internal static readonly string BadChar = string.Concat(DefChar.Substring(0,DefChar.Length - 3), "tmp");
        internal static readonly string BadSetts = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), Foldername, "Settings.tmp");
        internal static readonly string BadItems = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), Foldername, "Items.tmp");
        internal static readonly string BadQuest = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), Foldername, "Collections.tmp");
        internal static readonly string HelpMain = Path.Combine(Path.GetTempPath(), "EQ2CollQuests.html");
        internal static readonly string HelpChar = Path.Combine(Path.GetTempPath(), "CharacterPage.html");
        internal static readonly string HelpItems = Path.Combine(Path.GetTempPath(), "ItemsPage.html");
        internal static readonly string HelpQuest = Path.Combine(Path.GetTempPath(), "QuestsPage.html");
        internal static readonly string HelpSetts = Path.Combine(Path.GetTempPath(), "SettingsPage.html");
        /// <summary>The main entry point for the application.</summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            LoadHelp();
            Application.Run(new EQ2CollQuestsMain());
            httpClient.Dispose();
            DisposeHelp();
        }
        /// <summary> This method takes in a search of some sort for the RESTful API at http://census.daybreakgames.com and returns an XDocument with the results.</summary>
        /// <param name="UrlSuffix">The census account, game, output type and action (get) are pre-specified. The details of the search are not. Those details are provided here.</param>
        /// <returns>An <see cref="XDocument"/> containing the results of the search made against the Daybreak Census RESTful API. </returns>
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
        /// <summary>This method copies the help files out of the program and into user-controlled temporary storage.</summary>
        private static void LoadHelp()
        {
            string[] AllHelpFiles = { HelpMain, HelpChar, HelpItems, HelpQuest, HelpSetts };
            string[] AllHelpRes = { Resources.EQ2CollQuests, Resources.CharacterPage, Resources.ItemsPage, Resources.QuestsPage, Resources.SettingsPage };
            FileStream OutStream;
            for (int counter = 0; counter < 5; counter++)
            {
                OutStream = File.Create(AllHelpFiles[counter]);
                OutStream.Write(Encoding.UTF8.GetBytes(AllHelpRes[counter]), 0, AllHelpRes[counter].Length);
                OutStream.Flush();
                OutStream.Dispose();
            }
        }
        /// <summary>This method deletes the help files out of user-controlled temporary storage.</summary>
        private static void DisposeHelp()
        {
            string[] AllHelp = { HelpMain, HelpChar, HelpItems, HelpQuest, HelpSetts };
            for (int counter = 0; counter < 5; counter++)
            {
                if (File.Exists(AllHelp[counter]))
                    File.Delete(AllHelp[counter]);
            }
        }
    }
}
