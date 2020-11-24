using System;
using System.Windows.Forms;

namespace EQ2CollQuests
{
    public partial class EQ2CollQuestsMain : Form
    {
        private readonly string[] ItemsBoolItems = { "Lore Flag", "No Trade Flag" };
        private void ItemsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ItemsBoolCLB.Items.Clear();
            if ((ItemsListBox.SelectedIndex == -1) ||
                (ItemsListBox.SelectedItem is string) ||
                !(ItemsListBox.SelectedItem is QuestItem ChosenItem))
            {
                ItemIntro.Text = string.Empty;
                ItemsItemLevelTB.Text = string.Empty;
                ItemsItemDaybreakIDTB.Text = string.Empty;
                ItemsBoolCLB.Items.Add(ItemsBoolItems[0], CheckState.Indeterminate);
                ItemsBoolCLB.Items.Add(ItemsBoolItems[1], CheckState.Indeterminate);
                return;
            }
            ItemIntro.Text = ChosenItem.ItemName;
            ItemsItemLevelTB.Text = ChosenItem.ItemLvl.ToString();
            ItemsItemDaybreakIDTB.Text = ChosenItem.DaybreakID.ToString();
            ItemsBoolCLB.Items.Add(ItemsBoolItems[0], ChosenItem.LoreFlag);
            ItemsBoolCLB.Items.Add(ItemsBoolItems[1], ChosenItem.NoTradeFlag);
        }
        private void ItemsPage_Enter(object sender, EventArgs e)
        {
            ItemsListBox.Items.Clear();
            ItemsItemLevelTB.Text = string.Empty;
            ItemsBoolCLB.Items.Clear();
            _ = ItemsBoolCLB.Items.Add(ItemsBoolItems[0], CheckState.Indeterminate);
            _ = ItemsBoolCLB.Items.Add(ItemsBoolItems[1], CheckState.Indeterminate);
            ItemIntro.Text = string.Empty;
            ItemsItemLevelTB.Text = string.Empty;
            ItemsItemDaybreakIDTB.Text = string.Empty;
            if (Program.itemList.Count > 0)
            {
                ItemsListBox.Items.AddRange(Program.itemList.ToArray());
                ItemsListBox.Enabled = true;
            }
            else
            {
                ItemsListBox.Items.Add("Empty!");
                ItemsListBox.Enabled = false;
                return;
            }
            ItemIntro.Text = string.Empty;
            ItemsListBox.SelectedIndex = -1;
        }
        private void ItemsPage_Leave(object sender, EventArgs e)
        {
            if (!(sender is TabPage))
                return;
            ItemsListBox.Items.Clear();
            ItemIntro.Text = string.Empty;
            ItemsItemLevelTB.Text = string.Empty;
            ItemsItemDaybreakIDTB.Text = string.Empty;
            ItemsBoolCLB.Items.Clear();
        }
    }
}