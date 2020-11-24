using EQ2CollQuests.Properties;
using System;
using System.Windows.Forms;

namespace EQ2CollQuests
{
    public partial class EQ2CollQuestsMain:Form
    {
        private readonly string[] SettingsBoolCLBItems =
            { "Go Online?",
            "Indent XML?" };
        private void SettingsPage_Enter(object sender, EventArgs e)
        {
            SettingsBoolCheckListBox.Items.Clear();
            SettingsBoolCheckListBox.Items.Add(SettingsBoolCLBItems[0], GoOnline);
            SettingsBoolCheckListBox.Items.Add(SettingsBoolCLBItems[1], IndentXml);
            SettingsExpertMultMTB.Text = ExpertMult.ToString("0#.000");
            ExpertMultExplained.Rtf = Resources.ExpertMultExpl;
        }
        private void SettingsPage_Leave(object sender, EventArgs e) { }
        private void SettingsPage_Resize(object sender, EventArgs e)
        {
            ExpertMultExplained.Height = SettingsPage.Height - SettingsExpertMultMTB.Bottom - SettingsExpertMultMTB.Margin.Bottom;
        }
        private void SettingsExpertMultMTBLabel_Click(object sender, EventArgs e)
        {
            _ = SettingsExpertMultMTB.Focus();
        }
        private void SettingsExpertMultMTB_TextChanged(object sender, EventArgs e)
        {
            if (!double.TryParse(SettingsExpertMultMTB.Text, out double NewExpVal))
                return;
            ExpertMult = NewExpVal;
        }
        private void SettingsBoolCheckListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.Index == 0)
            {
                if (e.NewValue == CheckState.Checked)
                    GoOnline = true;
                else if (e.NewValue == CheckState.Unchecked)
                    GoOnline = false;
            }
            else if (e.Index == 1)
            {
                if (e.NewValue == CheckState.Checked)
                    IndentXml = true;
                else if (e.NewValue == CheckState.Unchecked)
                    IndentXml = false;
            }
        }
    }
}