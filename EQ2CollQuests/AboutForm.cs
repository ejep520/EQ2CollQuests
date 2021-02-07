using System;
using System.Windows.Forms;

namespace EQ2CollQuests
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
            AuthorLine.Links[0].LinkData = @"mailto:erik@jepster.com?subject=EQ2%20Collection%20Quests";
            AboutTB.Text = string.Concat("Information for geeks and freaks\r\n",
                $"Number of known servers: {Program.serverList.Count}\r\n",
                $"Number of known classes: {Program.AdvClasses.Count}\r\n",
                $"Number of known characters: {Program.charList.Count:N0}\r\n",
                $"Number of known collection quests: {Program.questList.Count:N0}\r\n",
                $"Number of known collectable items: {Program.itemList.Count:N0}\r\n\r\n",
                "In the event of a crash, please email the information shown here, your .xml files, steps you can take to reliably recreate the crash (if any). KTHXBAI.");
            CenterToParent();
        }

        private void AuthorLine_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _ = System.Diagnostics.Process.Start(e.Link.LinkData.ToString());
        }

        private void AboutOK_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
