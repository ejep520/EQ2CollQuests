using System;
using System.Windows.Forms;
using System.Xml.Linq;

namespace EQ2CollQuests
{
    public partial class AddCharForm : Form
    {
        private const string CharName = "Character's Name";
        public Characters NewChar;
        public AddCharForm()
        {
            InitializeComponent();
            AddCharConfirmBtn.Enabled = false;
        }
        private void AddCharIDMTB_TypeValidationCompleted(object sender, TypeValidationEventArgs e)
        {
            bool isValidOut = long.TryParse(AddCharIDMTB.Text, out _);
            AddCharIDBttn.Enabled = isValidOut;
        }
        private void AddCharIDBttn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(AddCharIDMTB.Text))
                return;
            long InputtedLong;
            try { InputtedLong = long.Parse(AddCharIDMTB.Text); }
            catch (ArgumentNullException) { return; }
            if (InputtedLong < 1)
                return;
            string searchSuffix = string.Concat(@"character/?c:show=displayname,type&id=", AddCharIDMTB.Text);
            XDocument CharCheck = Program.GetThisURL(searchSuffix);
            if (CharCheck.Root.Attribute("returned").Value != "1")
                return;
            AddCharSearchResults.Items.Clear();
            _ = AddCharSearchResults.Items.Add(new Characters(InputtedLong));
            AddCharConfirmBtn.Enabled = true;
            _ = AddCharConfirmBtn.Focus();
        }
        private void AddCharIDResetBtn_Click(object sender, EventArgs e)
        {
            AddCharSearchResults.Items.Clear();
            AddCharIDMTB.Text = string.Empty;
            AddCharConfirmBtn.Enabled = false;
            _ = AddCharIDMTB.Focus();
        }
        private void AddCharConfirmBtn_Click(object sender, EventArgs e)
        {
            if (AddCharSearchResults.SelectedItem == null)
                return;
            if (AddCharSearchResults.SelectedItem is Characters NewChar)
            {
                this.NewChar = NewChar;
                DialogResult = DialogResult.OK;
                Close();
            }
        }
        private void AddCharByName_Enter(object sender, EventArgs e)
        {
            AddCharNameKeyTB.Text = CharName;
            AddCharNameSearchRsltsLB.Items.Clear();
            AddCharNameConfirm.Enabled = false;
            AddCharNameReset.Enabled = true;
            _ = AddCharByName.Focus();
        }
        private void AddCharNameKeyTB_GotFocus(object sender, EventArgs e)
        {
            if (AddCharNameKeyTB.Text == CharName)
                AddCharNameKeyTB.Text = string.Empty;
        }
        private void AddCharSearchNameBtn_Click(object sender, EventArgs e)
        {
            XDocument CharFinder = Program.GetThisURL(string.Concat(@"character/?c:show=returned,displayname,id&displayname=^", AddCharNameKeyTB.Text));
            AddCharNameConfirm.Enabled = false;
            foreach (XElement thisChar in CharFinder.Root.Elements("character"))
            {
                AddCharNameSearchRsltsLB.Items.Add(new AddCharResult(thisChar.Attribute("displayname").Value, long.Parse(thisChar.Attribute("id").Value)));
            }
            if (AddCharNameSearchRsltsLB.Items.Count == 0)
            {
                AddCharNameKeyTB.Text = string.Empty;
                _ = AddCharNameKeyTB.Focus();
                _ = MessageBox.Show("No characters were found with that name.\nRemember, capitolization and spelling count!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                AddCharNameSearchRsltsLB.SelectedIndex = 0;
                AddCharNameConfirm.Enabled = true;
                _ = AddCharNameConfirm.Focus();
            }
        }
        internal class AddCharResult
        {
            public string displayName;
            public long DaybreakID;
            public AddCharResult() { }
            public AddCharResult(string displayName, long DaybreakID)
            {
                this.displayName = displayName;
                this.DaybreakID = DaybreakID;
            }
            public override string ToString()
            {
                return displayName;
            }
        }

        private void AddCharNameReset_Click(object sender, EventArgs e)
        {
            AddCharNameKeyTB.Text = string.Empty;
            AddCharNameSearchRsltsLB.Items.Clear();
            _ = AddCharNameKeyTB.Focus();
        }

        private void AddCharNameCofirm_Click(object sender, EventArgs e)
        {
            if (AddCharNameSearchRsltsLB.SelectedItem == null)
                return;
            if (AddCharNameSearchRsltsLB.SelectedItem is Characters NewChar)
            {
                this.NewChar = NewChar;
                DialogResult = DialogResult.OK;
                Close();
            }

        }

        private void AddCharNameKeyTB_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(AddCharNameKeyTB.Text))
            {
                AddCharNameKeyTB.Text = CharName;
            }
        }
    }
}
