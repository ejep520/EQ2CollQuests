using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace EQ2CollQuests
{
    public partial class EQ2CollQuestsMain : Form
    {
        private readonly string[] ItemsBoolItems = { "Lore Flag", "No Trade Flag" };
        private void ItemsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool OldDirties = dirties[2];
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
                ItemsEQ2iLink.Links[0].Enabled = false;
                ItemsEQ2iLink.Links[1].Enabled = false;
                ItemsCopyWPLabelLink.Enabled = false;
                ItemsCopiedWPLabel.Visible = false;
                return;
            }
            if (!ItemsStaticLocPanel.Enabled)
                ItemsStaticLocPanel.Enabled = true;
            ItemIntro.Text = ChosenItem.ItemName;
            ItemsItemLevelTB.Text = ChosenItem.ItemLvl.ToString();
            ItemsItemDaybreakIDTB.Text = ChosenItem.DaybreakID.ToString();
            ItemsBoolCLB.Items.Add(ItemsBoolItems[0], ChosenItem.LoreFlag);
            ItemsBoolCLB.Items.Add(ItemsBoolItems[1], ChosenItem.NoTradeFlag);
            switch (ChosenItem.StaticLoc)
            {
                case QuestItem.ItemsStaticLocValues.ZoneSpec:
                    ItemsCorpseDropBool.Checked = true;
                    break;
                case QuestItem.ItemsStaticLocValues.FixedLoc:
                    ItemsStaticLocRB.Checked = true;
                    break;
                default:
                    ItemsNoStaticLocRB.Checked = true;
                    break;
            }
            ItemsStaticLocZoneTB.Enabled = Convert.ToBoolean(ChosenItem.StaticLoc & QuestItem.ItemsStaticLocValues.ZoneSpec); // /waypoint -1156, -9, 418
            ItemsStaticLocXTB.Enabled = Convert.ToBoolean(ChosenItem.StaticLoc & QuestItem.ItemsStaticLocValues.LocSpec);
            ItemsStaticLocYTB.Enabled = Convert.ToBoolean(ChosenItem.StaticLoc & QuestItem.ItemsStaticLocValues.LocSpec);
            ItemsStaticLocZTB.Enabled = Convert.ToBoolean(ChosenItem.StaticLoc & QuestItem.ItemsStaticLocValues.LocSpec);
            ItemsStaticLocXTB.Text = Convert.ToBoolean(ChosenItem.StaticLoc & QuestItem.ItemsStaticLocValues.LocSpec) ? ChosenItem.LocX.ToString() : string.Empty;
            ItemsStaticLocYTB.Text = Convert.ToBoolean(ChosenItem.StaticLoc & QuestItem.ItemsStaticLocValues.LocSpec) ? ChosenItem.LocY.ToString() : string.Empty;
            ItemsStaticLocZTB.Text = Convert.ToBoolean(ChosenItem.StaticLoc & QuestItem.ItemsStaticLocValues.LocSpec) ? ChosenItem.LocZ.ToString() : string.Empty;
            ItemsStaticLocZoneTB.Text = Convert.ToBoolean(ChosenItem.StaticLoc & QuestItem.ItemsStaticLocValues.ZoneSpec) ? ChosenItem.ZoneName : string.Empty;
            ItemsEQ2iLink.Links[0].LinkData = string.Concat(@"https://eq2.fandom.com/wiki/", ChosenItem.ItemName.Replace(' ', '_'));
            ItemsEQ2iLink.Links[1].LinkData = string.Concat(@"https://u.eq2wire.com/item/index/", ChosenItem.DaybreakID.ToString());
            ItemsCopyWPLabelLink.Links[0].LinkData = Convert.ToBoolean(ChosenItem.StaticLoc & QuestItem.ItemsStaticLocValues.LocSpec) ?
                string.Concat(@"/waypoint ", ChosenItem.LocX.ToString(), ", ", ChosenItem.LocY.ToString(), ", ", ChosenItem.LocZ.ToString()) :
                string.Empty;
            ItemsEQ2iLink.Links[0].Enabled = true;
            ItemsEQ2iLink.Links[1].Enabled = true;
            ItemsCopyWPLabelLink.Links[0].Enabled = Convert.ToBoolean(ChosenItem.StaticLoc & QuestItem.ItemsStaticLocValues.LocSpec);
            dirties[2] = false || OldDirties;
            UpdateDirtiesStatus();
        }
        private void ItemsNoStaticLocRB_CheckedChanged(object sender, EventArgs e)
        {
            TextBox[] AllStaticLocTB = { ItemsStaticLocZoneTB, ItemsStaticLocXTB, ItemsStaticLocYTB, ItemsStaticLocZTB };
            if ((ItemsListBox.SelectedIndex == -1) || (!(ItemsListBox.SelectedItem is QuestItem ThisItem)))
                return;
            if (ItemsNoStaticLocRB.Checked && (Program.itemList[ThisItem.DaybreakID].StaticLoc != 0))
            {
                dirties[2] = true;
                StatusStripDirtyIndicator.Text = FloppyString;
                Program.itemList[ThisItem.DaybreakID].StaticLoc = 0;
                (ItemsListBox.SelectedItem as QuestItem).StaticLoc = 0;
                ItemsListBox.Refresh();
            }
            else if (ItemsCorpseDropBool.Checked && (Program.itemList[ThisItem.DaybreakID].StaticLoc != QuestItem.ItemsStaticLocValues.ZoneSpec))
            {
                dirties[2] = true;
                StatusStripDirtyIndicator.Text = FloppyString;
                Program.itemList[ThisItem.DaybreakID].StaticLoc = QuestItem.ItemsStaticLocValues.ZoneSpec;
                (ItemsListBox.SelectedItem as QuestItem).StaticLoc = QuestItem.ItemsStaticLocValues.ZoneSpec;
                ItemsListBox.Refresh();
            }
            else if (ItemsStaticLocRB.Checked && (Program.itemList[ThisItem.DaybreakID].StaticLoc != QuestItem.ItemsStaticLocValues.FixedLoc))
            {
                dirties[2] = true;
                StatusStripDirtyIndicator.Text = FloppyString;
                Program.itemList[ThisItem.DaybreakID].StaticLoc = QuestItem.ItemsStaticLocValues.FixedLoc;
                (ItemsListBox.SelectedItem as QuestItem).StaticLoc = QuestItem.ItemsStaticLocValues.FixedLoc;
                ItemsListBox.Refresh();
            }
            if (ItemsNoStaticLocRB.Checked)
            {
                if (ItemsStaticLocRB.Checked)
                {
                    ItemsStaticLocRB.Checked = false;
                }
                if (ItemsCorpseDropBool.Checked)
                {
                    ItemsCorpseDropBool.Checked = false;
                }
                for (int counter = 0; counter < 4; counter++)
                {
                    AllStaticLocTB[counter].Enabled = false;
                    AllStaticLocTB[counter].Text = string.Empty;
                }
            }
        }
        private void ItemsNoStaticLocRB_Click(object sender, EventArgs e)
        {
            ItemsNoStaticLocRB.Checked = true;
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
                ItemsListBox.Items.AddRange(Program.itemList.Values.ToArray());
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
            ItemsStaticLocPanel.Enabled = false;
            ItemsStaticLocXTB.Text = string.Empty;
            ItemsStaticLocYTB.Text = string.Empty;
            ItemsStaticLocZTB.Text = string.Empty;
            ItemsStaticLocZoneTB.Text = string.Empty;
            ItemsNoStaticLocRB.Checked = false;
            ItemsStaticLocRB.Checked = false;
            ItemsEQ2iLink.Links[0].Enabled = false;
            ItemsEQ2iLink.Links[1].Enabled = false;
            ItemsCopyWPLabelLink.Links[0].Enabled = false;
            ItemsCopyWPLabelLink.Links[0].LinkData = null;
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
        private void ItemsStaticLocRB_CheckedChanged(object sender, EventArgs e)
        {
            TextBox[] AllStaticLocTB = { ItemsStaticLocZoneTB, ItemsStaticLocXTB, ItemsStaticLocYTB, ItemsStaticLocZTB };
            if (ItemsStaticLocRB.Checked)
            {
                if (ItemsNoStaticLocRB.Checked)
                {
                    ItemsNoStaticLocRB.Checked = false;
                }
                if (ItemsCorpseDropBool.Checked)
                {
                    ItemsCorpseDropBool.Checked = false;
                }
                for (int counter = 0; counter < 4; counter++)
                {
                    AllStaticLocTB[counter].Enabled = true;
                }
            }
        }
        private void ItemsStaticLocXLabel_Click(object sender, EventArgs e)
        {
            _ = ItemsStaticLocXTB.Focus();
        }
        private void ItemsStaticLocXTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                _ = ItemsStaticLocYTB.Focus();
        }
        private void ItemsStaticLocXTB_TextChanged(object sender, EventArgs e)
        {
            if ((ItemsListBox.SelectedIndex == -1) ||
                (ItemsListBox.SelectedItem is string))
                return;
            if ((ItemsListBox.SelectedItem is QuestItem ThisItem) &&
                double.TryParse(ItemsStaticLocXTB.Text, out double NewX))
            {
                Program.itemList[ThisItem.DaybreakID].LocX = NewX;
                ThisItem.LocX = NewX;
                ItemsCopyWPLabelLink.Links[0].LinkData =
                    string.Concat(@"/waypoint ", ThisItem.LocX.ToString(), ", ", ThisItem.LocY.ToString(), ", ", ThisItem.LocZ.ToString());
            }
        }
        private void ItemsStaticLocXTB_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ItemsStaticLocXTB.Text) && ItemsStaticLocRB.Checked)
                ItemsStaticLocXTB.Text = "0.0";
            else if (!double.TryParse(ItemsStaticLocXTB.Text, out _) && (ItemsStaticLocXTB.BackColor == SystemColors.Window))
                ItemsStaticLocXTB.BackColor = Color.Red;
            else if (double.TryParse(ItemsStaticLocXTB.Text, out _) && (ItemsStaticLocXTB.BackColor == Color.Red))
                ItemsStaticLocXTB.BackColor = SystemColors.Window;
        }
        private void ItemsStaticLocYLabel_Click(object sender, EventArgs e)
        {
            _ = ItemsStaticLocYTB.Focus();
        }
        private void ItemsStaticLocYTB_TextChanged(object sender, EventArgs e)
        {
            if ((ItemsListBox.SelectedIndex == -1) ||
                (ItemsListBox.SelectedItem is string))
                return;
            if ((ItemsListBox.SelectedItem is QuestItem ThisItem) &&
                double.TryParse(ItemsStaticLocYTB.Text, out double NewY))
            {
                Program.itemList[ThisItem.DaybreakID].LocY = NewY;
                ThisItem.LocY = NewY;
                ItemsCopyWPLabelLink.Links[0].LinkData =
                    string.Concat(@"/waypoint ", ThisItem.LocX.ToString(), ", ", ThisItem.LocY.ToString(), ", ", ThisItem.LocZ.ToString());
            }
        }
        private void ItemsStaticLocYTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                _ = ItemsStaticLocZTB.Focus();
        }
        private void ItemsStaticLocYTB_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ItemsStaticLocYTB.Text) && ItemsStaticLocRB.Checked)
                ItemsStaticLocYTB.Text = "0.0";
            else if (!double.TryParse(ItemsStaticLocYTB.Text, out _) && (ItemsStaticLocYTB.BackColor == SystemColors.Window))
                ItemsStaticLocYTB.BackColor = Color.Red;
            else if (double.TryParse(ItemsStaticLocYTB.Text, out _) && (ItemsStaticLocYTB.BackColor == Color.Red))
                ItemsStaticLocYTB.BackColor = SystemColors.Window;
        }
        private void ItemsStaticLocZLabel_Click(object sender, EventArgs e)
        {
            _ = ItemsStaticLocZoneTB.Focus();
        }
        private void ItemsStaticLocZoneTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                _ = ItemsStaticLocXTB.Focus();
            }
        }
        private void ItemsStaticLocZoneTB_TextChanged(object sender, EventArgs e)
        {
            if ((ItemsListBox.SelectedIndex == -1) ||
                (ItemsListBox.SelectedItem is string))
                return;
            if (!(ItemsListBox.SelectedItem is QuestItem ThisItem))
                return;
            Program.itemList[ThisItem.DaybreakID].ZoneName = ItemsStaticLocZoneTB.Text;
            ThisItem.ZoneName = ItemsStaticLocZoneTB.Text;
            if (!dirties[2])
            {
                dirties[2] = true;
                UpdateDirtiesStatus();
            }
        }
        private void ItemsStaticLocZTB_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ItemsStaticLocZTB.Text) && ItemsStaticLocRB.Checked)
                ItemsStaticLocZTB.Text = "0.0";
            else if (!double.TryParse(ItemsStaticLocZTB.Text, out _) && (ItemsStaticLocZTB.BackColor == SystemColors.Window))
                ItemsStaticLocZTB.BackColor = Color.Red;
            else if (double.TryParse(ItemsStaticLocZTB.Text, out _) && (ItemsStaticLocZTB.BackColor == Color.Red))
                ItemsStaticLocZTB.BackColor = SystemColors.Window;
        }
        private void ItemsStaticLocZTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                _ = ItemsListBox.Focus();
        }
        private void ItemsStaticLocZTB_TextChanged(object sender, EventArgs e)
        {
            if ((ItemsListBox.SelectedIndex == -1) ||
                (ItemsListBox.SelectedItem is string))
                return;
            if ((ItemsListBox.SelectedItem is QuestItem ThisItem) &&
                 double.TryParse(ItemsStaticLocZTB.Text, out double NewZ))
            {
                Program.itemList[ThisItem.DaybreakID].LocZ = NewZ;
                ThisItem.LocZ = NewZ;
                ItemsCopyWPLabelLink.Links[0].LinkData =
                    string.Concat(@"/waypoint ", ThisItem.LocX.ToString(), ", ", ThisItem.LocY.ToString(), ", ", ThisItem.LocZ.ToString());
            }
        }
        private void ItemsCorpseDropBool_Click(object sender, EventArgs e)
        {
            ItemsCorpseDropBool.Checked = true;
        }
        private void ItemsCorpseDropBool_CheckedChanged(object sender, EventArgs e)
        {
            TextBox[] AllStaticLocTB = { ItemsStaticLocZoneTB, ItemsStaticLocXTB, ItemsStaticLocYTB, ItemsStaticLocZTB };
            if (ItemsCorpseDropBool.Checked)
            {
                if (ItemsNoStaticLocRB.Checked)
                {
                    ItemsNoStaticLocRB.Checked = false;
                }
                if (ItemsStaticLocRB.Checked)
                {
                    ItemsStaticLocRB.Checked = false;
                }
                for (int counter = 0; counter < 4; counter++)
                {
                    AllStaticLocTB[counter].Text = (counter > 0) ? string.Empty : AllStaticLocTB[counter].Text;
                    AllStaticLocTB[counter].Enabled = counter == 0;
                }
            }
        }
    }
}