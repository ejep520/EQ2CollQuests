
namespace EQ2CollQuests
{
    partial class AddQuest
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.AddQuestIDPage = new System.Windows.Forms.TabPage();
            this.AddQuestIDConfirmAdd = new System.Windows.Forms.Button();
            this.AddQuestIDResultsLB = new System.Windows.Forms.ListBox();
            this.AddQuestIDResetBtn = new System.Windows.Forms.Button();
            this.AddQuestIDSearch = new System.Windows.Forms.Button();
            this.AddQuestIDMTB = new System.Windows.Forms.MaskedTextBox();
            this.AddQuestByNamePage = new System.Windows.Forms.TabPage();
            this.AddQuestNameConfirmBtn = new System.Windows.Forms.Button();
            this.AddQuestNameResultsLB = new System.Windows.Forms.ListBox();
            this.AddQuestNameResetBtn = new System.Windows.Forms.Button();
            this.AddQuestNameSearchBtn = new System.Windows.Forms.Button();
            this.AddQuestNameTB = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.AddQuestIDPage.SuspendLayout();
            this.AddQuestByNamePage.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.AddQuestIDPage);
            this.tabControl1.Controls.Add(this.AddQuestByNamePage);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(336, 231);
            this.tabControl1.TabIndex = 0;
            // 
            // AddQuestIDPage
            // 
            this.AddQuestIDPage.Controls.Add(this.AddQuestIDConfirmAdd);
            this.AddQuestIDPage.Controls.Add(this.AddQuestIDResultsLB);
            this.AddQuestIDPage.Controls.Add(this.AddQuestIDResetBtn);
            this.AddQuestIDPage.Controls.Add(this.AddQuestIDSearch);
            this.AddQuestIDPage.Controls.Add(this.AddQuestIDMTB);
            this.AddQuestIDPage.Location = new System.Drawing.Point(4, 22);
            this.AddQuestIDPage.Name = "AddQuestIDPage";
            this.AddQuestIDPage.Padding = new System.Windows.Forms.Padding(3);
            this.AddQuestIDPage.Size = new System.Drawing.Size(328, 205);
            this.AddQuestIDPage.TabIndex = 0;
            this.AddQuestIDPage.Text = "Daybreak ID";
            this.AddQuestIDPage.ToolTipText = "Add a quest using the Daybreak ID number";
            // 
            // AddQuestIDConfirmAdd
            // 
            this.AddQuestIDConfirmAdd.Location = new System.Drawing.Point(5, 176);
            this.AddQuestIDConfirmAdd.Name = "AddQuestIDConfirmAdd";
            this.AddQuestIDConfirmAdd.Size = new System.Drawing.Size(317, 26);
            this.AddQuestIDConfirmAdd.TabIndex = 4;
            this.AddQuestIDConfirmAdd.Text = "Add Quest";
            this.AddQuestIDConfirmAdd.UseVisualStyleBackColor = true;
            this.AddQuestIDConfirmAdd.Click += new System.EventHandler(this.AddQuestIDConfirmAdd_Click);
            // 
            // AddQuestIDResultsLB
            // 
            this.AddQuestIDResultsLB.FormattingEnabled = true;
            this.AddQuestIDResultsLB.Location = new System.Drawing.Point(5, 62);
            this.AddQuestIDResultsLB.Name = "AddQuestIDResultsLB";
            this.AddQuestIDResultsLB.Size = new System.Drawing.Size(317, 108);
            this.AddQuestIDResultsLB.TabIndex = 3;
            // 
            // AddQuestIDResetBtn
            // 
            this.AddQuestIDResetBtn.Location = new System.Drawing.Point(92, 31);
            this.AddQuestIDResetBtn.Name = "AddQuestIDResetBtn";
            this.AddQuestIDResetBtn.Size = new System.Drawing.Size(81, 21);
            this.AddQuestIDResetBtn.TabIndex = 2;
            this.AddQuestIDResetBtn.Text = "Reset";
            this.AddQuestIDResetBtn.UseVisualStyleBackColor = true;
            this.AddQuestIDResetBtn.Click += new System.EventHandler(this.AddQuestIDResetBtn_Click);
            // 
            // AddQuestIDSearch
            // 
            this.AddQuestIDSearch.Location = new System.Drawing.Point(5, 31);
            this.AddQuestIDSearch.Name = "AddQuestIDSearch";
            this.AddQuestIDSearch.Size = new System.Drawing.Size(81, 21);
            this.AddQuestIDSearch.TabIndex = 1;
            this.AddQuestIDSearch.Text = "Find";
            this.AddQuestIDSearch.UseVisualStyleBackColor = true;
            this.AddQuestIDSearch.Click += new System.EventHandler(this.AddQuestIDSearch_Click);
            // 
            // AddQuestIDMTB
            // 
            this.AddQuestIDMTB.Location = new System.Drawing.Point(5, 5);
            this.AddQuestIDMTB.Name = "AddQuestIDMTB";
            this.AddQuestIDMTB.PromptChar = ' ';
            this.AddQuestIDMTB.Size = new System.Drawing.Size(168, 20);
            this.AddQuestIDMTB.TabIndex = 0;
            this.AddQuestIDMTB.ValidatingType = typeof(long);
            this.AddQuestIDMTB.TypeValidationCompleted += new System.Windows.Forms.TypeValidationEventHandler(this.AddQuestIDMTB_TypeValidationCompleted);
            this.AddQuestIDMTB.TextChanged += new System.EventHandler(this.AddQuestIDMTB_TextChanged);
            // 
            // AddQuestByNamePage
            // 
            this.AddQuestByNamePage.Controls.Add(this.AddQuestNameConfirmBtn);
            this.AddQuestByNamePage.Controls.Add(this.AddQuestNameResultsLB);
            this.AddQuestByNamePage.Controls.Add(this.AddQuestNameResetBtn);
            this.AddQuestByNamePage.Controls.Add(this.AddQuestNameSearchBtn);
            this.AddQuestByNamePage.Controls.Add(this.AddQuestNameTB);
            this.AddQuestByNamePage.Location = new System.Drawing.Point(4, 22);
            this.AddQuestByNamePage.Name = "AddQuestByNamePage";
            this.AddQuestByNamePage.Padding = new System.Windows.Forms.Padding(3);
            this.AddQuestByNamePage.Size = new System.Drawing.Size(328, 205);
            this.AddQuestByNamePage.TabIndex = 1;
            this.AddQuestByNamePage.Text = "Quest Name";
            this.AddQuestByNamePage.ToolTipText = "Add a quest using the quest\'s name";
            // 
            // AddQuestNameConfirmBtn
            // 
            this.AddQuestNameConfirmBtn.Location = new System.Drawing.Point(5, 176);
            this.AddQuestNameConfirmBtn.Name = "AddQuestNameConfirmBtn";
            this.AddQuestNameConfirmBtn.Size = new System.Drawing.Size(317, 26);
            this.AddQuestNameConfirmBtn.TabIndex = 4;
            this.AddQuestNameConfirmBtn.Text = "Add Quest";
            this.AddQuestNameConfirmBtn.UseVisualStyleBackColor = true;
            this.AddQuestNameConfirmBtn.Visible = false;
            this.AddQuestNameConfirmBtn.Click += new System.EventHandler(this.AddQuestNameConfirmBtn_Click);
            // 
            // AddQuestNameResultsLB
            // 
            this.AddQuestNameResultsLB.FormattingEnabled = true;
            this.AddQuestNameResultsLB.Location = new System.Drawing.Point(5, 62);
            this.AddQuestNameResultsLB.Name = "AddQuestNameResultsLB";
            this.AddQuestNameResultsLB.Size = new System.Drawing.Size(317, 108);
            this.AddQuestNameResultsLB.TabIndex = 3;
            this.AddQuestNameResultsLB.Visible = false;
            // 
            // AddQuestNameResetBtn
            // 
            this.AddQuestNameResetBtn.Location = new System.Drawing.Point(92, 31);
            this.AddQuestNameResetBtn.Name = "AddQuestNameResetBtn";
            this.AddQuestNameResetBtn.Size = new System.Drawing.Size(81, 21);
            this.AddQuestNameResetBtn.TabIndex = 2;
            this.AddQuestNameResetBtn.Text = "Reset";
            this.AddQuestNameResetBtn.UseVisualStyleBackColor = true;
            this.AddQuestNameResetBtn.Click += new System.EventHandler(this.AddQuestNameResetBtn_Click);
            // 
            // AddQuestNameSearchBtn
            // 
            this.AddQuestNameSearchBtn.Location = new System.Drawing.Point(5, 31);
            this.AddQuestNameSearchBtn.Name = "AddQuestNameSearchBtn";
            this.AddQuestNameSearchBtn.Size = new System.Drawing.Size(81, 21);
            this.AddQuestNameSearchBtn.TabIndex = 1;
            this.AddQuestNameSearchBtn.Text = "Find";
            this.AddQuestNameSearchBtn.UseVisualStyleBackColor = true;
            this.AddQuestNameSearchBtn.Click += new System.EventHandler(this.AddQuestNameSearchBtn_Click);
            // 
            // AddQuestNameTB
            // 
            this.AddQuestNameTB.Location = new System.Drawing.Point(5, 5);
            this.AddQuestNameTB.Name = "AddQuestNameTB";
            this.AddQuestNameTB.Size = new System.Drawing.Size(168, 20);
            this.AddQuestNameTB.TabIndex = 0;
            // 
            // AddQuest
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 231);
            this.Controls.Add(this.tabControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddQuest";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add a Quest";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddQuest_FormClosing);
            this.tabControl1.ResumeLayout(false);
            this.AddQuestIDPage.ResumeLayout(false);
            this.AddQuestIDPage.PerformLayout();
            this.AddQuestByNamePage.ResumeLayout(false);
            this.AddQuestByNamePage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage AddQuestIDPage;
        private System.Windows.Forms.TabPage AddQuestByNamePage;
        private System.Windows.Forms.Button AddQuestNameConfirmBtn;
        private System.Windows.Forms.ListBox AddQuestNameResultsLB;
        private System.Windows.Forms.Button AddQuestNameResetBtn;
        private System.Windows.Forms.Button AddQuestNameSearchBtn;
        private System.Windows.Forms.TextBox AddQuestNameTB;
        private System.Windows.Forms.MaskedTextBox AddQuestIDMTB;
        private System.Windows.Forms.Button AddQuestIDSearch;
        private System.Windows.Forms.Button AddQuestIDResetBtn;
        private System.Windows.Forms.Button AddQuestIDConfirmAdd;
        private System.Windows.Forms.ListBox AddQuestIDResultsLB;
    }
}