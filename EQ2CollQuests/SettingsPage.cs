using EQ2CollQuests.Properties;
using System;
using System.Windows.Forms;

namespace EQ2CollQuests
{
    public partial class EQ2CollQuestsMain:Form
    {
        private readonly string[] SettingsBoolCLBItems =
            { "Go Online?",
            "Indent XML?",
            "Hide Completed Quests on Character Page?"};
        private void SettingsPage_Enter(object sender, EventArgs e)
        {
            SettingsBoolCheckListBox.Items.Clear();
            SettingsBoolCheckListBox.Items.Add(SettingsBoolCLBItems[0], GoOnline);
            SettingsBoolCheckListBox.Items.Add(SettingsBoolCLBItems[1], IndentXml);
            SettingsBoolCheckListBox.Items.Add(SettingsBoolCLBItems[2], HideCompletedOnChar);
            SettingsExpertMultMTB.Text = ExpertMult.ToString("0#.000");
            ExpertMultExplained.Rtf = Resources.ExpertMultExpl;
        }
        private void SettingsPage_Leave(object sender, EventArgs e)
        {
            if (!(ActiveControl is TabPage))
                return;
            SettingsBoolCheckListBox.Items.Clear();
            SettingsExpertMultMTB.Text = string.Empty;
            ExpertMultExplained.Rtf = string.Empty;
        }
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
            
        }
        private void SettingsBoolCheckListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            switch (e.Index)
            {
                case 0:
                    if (e.NewValue == CheckState.Checked)
                        GoOnline = true;
                    else if (e.NewValue == CheckState.Unchecked)
                        GoOnline = false;
                    break;
                case 1:
                    if (e.NewValue == CheckState.Checked)
                        IndentXml = true;
                    else if (e.NewValue == CheckState.Unchecked)
                        IndentXml = false;
                    break;
                case 2:
                    if (e.NewValue == CheckState.Checked)
                        HideCompletedOnChar = true;
                    else if (e.NewValue == CheckState.Unchecked)
                        HideCompletedOnChar = false;
                    break;
                default:
                    break;
            }
        }
    }
}