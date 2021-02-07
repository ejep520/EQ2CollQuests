namespace EQ2CollQuests
{
    partial class AddCharForm
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
            this.AddCharTabControl = new System.Windows.Forms.TabControl();
            this.AddCharByID = new System.Windows.Forms.TabPage();
            this.AddCharIDResetBtn = new System.Windows.Forms.Button();
            this.AddCharConfirmBtn = new System.Windows.Forms.Button();
            this.AddCharSearchResults = new System.Windows.Forms.ListBox();
            this.AddCharIDMTB = new System.Windows.Forms.MaskedTextBox();
            this.AddCharIDBttn = new System.Windows.Forms.Button();
            this.AddCharByName = new System.Windows.Forms.TabPage();
            this.AddCharNameKeyTB = new System.Windows.Forms.TextBox();
            this.AddCharNameReset = new System.Windows.Forms.Button();
            this.AddCharNameConfirm = new System.Windows.Forms.Button();
            this.AddCharNameSearchRsltsLB = new System.Windows.Forms.ListBox();
            this.AddCharSearchNameBtn = new System.Windows.Forms.Button();
            this.AddCharTabControl.SuspendLayout();
            this.AddCharByID.SuspendLayout();
            this.AddCharByName.SuspendLayout();
            this.SuspendLayout();
            // 
            // AddCharTabControl
            // 
            this.AddCharTabControl.Controls.Add(this.AddCharByID);
            this.AddCharTabControl.Controls.Add(this.AddCharByName);
            this.AddCharTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AddCharTabControl.Location = new System.Drawing.Point(0, 0);
            this.AddCharTabControl.Name = "AddCharTabControl";
            this.AddCharTabControl.SelectedIndex = 0;
            this.AddCharTabControl.Size = new System.Drawing.Size(227, 199);
            this.AddCharTabControl.TabIndex = 0;
            // 
            // AddCharByID
            // 
            this.AddCharByID.Controls.Add(this.AddCharIDResetBtn);
            this.AddCharByID.Controls.Add(this.AddCharConfirmBtn);
            this.AddCharByID.Controls.Add(this.AddCharSearchResults);
            this.AddCharByID.Controls.Add(this.AddCharIDMTB);
            this.AddCharByID.Controls.Add(this.AddCharIDBttn);
            this.AddCharByID.Location = new System.Drawing.Point(4, 22);
            this.AddCharByID.Name = "AddCharByID";
            this.AddCharByID.Padding = new System.Windows.Forms.Padding(3);
            this.AddCharByID.Size = new System.Drawing.Size(219, 173);
            this.AddCharByID.TabIndex = 0;
            this.AddCharByID.Text = "Use ID Number";
            this.AddCharByID.UseVisualStyleBackColor = true;
            // 
            // AddCharIDResetBtn
            // 
            this.AddCharIDResetBtn.Location = new System.Drawing.Point(120, 149);
            this.AddCharIDResetBtn.Name = "AddCharIDResetBtn";
            this.AddCharIDResetBtn.Size = new System.Drawing.Size(81, 21);
            this.AddCharIDResetBtn.TabIndex = 4;
            this.AddCharIDResetBtn.Text = "Reset";
            this.AddCharIDResetBtn.UseVisualStyleBackColor = true;
            this.AddCharIDResetBtn.Click += new System.EventHandler(this.AddCharIDResetBtn_Click);
            // 
            // AddCharConfirmBtn
            // 
            this.AddCharConfirmBtn.Location = new System.Drawing.Point(3, 148);
            this.AddCharConfirmBtn.Name = "AddCharConfirmBtn";
            this.AddCharConfirmBtn.Size = new System.Drawing.Size(111, 22);
            this.AddCharConfirmBtn.TabIndex = 3;
            this.AddCharConfirmBtn.Text = "Confirm";
            this.AddCharConfirmBtn.UseVisualStyleBackColor = true;
            this.AddCharConfirmBtn.Click += new System.EventHandler(this.AddCharConfirmBtn_Click);
            // 
            // AddCharSearchResults
            // 
            this.AddCharSearchResults.FormattingEnabled = true;
            this.AddCharSearchResults.Location = new System.Drawing.Point(3, 60);
            this.AddCharSearchResults.Name = "AddCharSearchResults";
            this.AddCharSearchResults.Size = new System.Drawing.Size(198, 82);
            this.AddCharSearchResults.TabIndex = 2;
            // 
            // AddCharIDMTB
            // 
            this.AddCharIDMTB.Location = new System.Drawing.Point(3, 6);
            this.AddCharIDMTB.Name = "AddCharIDMTB";
            this.AddCharIDMTB.PromptChar = ' ';
            this.AddCharIDMTB.Size = new System.Drawing.Size(111, 20);
            this.AddCharIDMTB.TabIndex = 0;
            this.AddCharIDMTB.ValidatingType = typeof(long);
            this.AddCharIDMTB.TypeValidationCompleted += new System.Windows.Forms.TypeValidationEventHandler(this.AddCharIDMTB_TypeValidationCompleted);
            this.AddCharIDMTB.TextChanged += new System.EventHandler(this.AddCharIDMTB_TextChanged);
            // 
            // AddCharIDBttn
            // 
            this.AddCharIDBttn.Location = new System.Drawing.Point(3, 32);
            this.AddCharIDBttn.Name = "AddCharIDBttn";
            this.AddCharIDBttn.Size = new System.Drawing.Size(111, 22);
            this.AddCharIDBttn.TabIndex = 1;
            this.AddCharIDBttn.Text = "Find Character ID";
            this.AddCharIDBttn.UseVisualStyleBackColor = true;
            this.AddCharIDBttn.Click += new System.EventHandler(this.AddCharIDBttn_Click);
            // 
            // AddCharByName
            // 
            this.AddCharByName.Controls.Add(this.AddCharNameKeyTB);
            this.AddCharByName.Controls.Add(this.AddCharNameReset);
            this.AddCharByName.Controls.Add(this.AddCharNameConfirm);
            this.AddCharByName.Controls.Add(this.AddCharNameSearchRsltsLB);
            this.AddCharByName.Controls.Add(this.AddCharSearchNameBtn);
            this.AddCharByName.Location = new System.Drawing.Point(4, 22);
            this.AddCharByName.Name = "AddCharByName";
            this.AddCharByName.Padding = new System.Windows.Forms.Padding(3);
            this.AddCharByName.Size = new System.Drawing.Size(219, 173);
            this.AddCharByName.TabIndex = 1;
            this.AddCharByName.Text = "Search By Name";
            this.AddCharByName.UseVisualStyleBackColor = true;
            this.AddCharByName.Enter += new System.EventHandler(this.AddCharByName_Enter);
            // 
            // AddCharNameKeyTB
            // 
            this.AddCharNameKeyTB.CausesValidation = false;
            this.AddCharNameKeyTB.Location = new System.Drawing.Point(3, 6);
            this.AddCharNameKeyTB.Name = "AddCharNameKeyTB";
            this.AddCharNameKeyTB.Size = new System.Drawing.Size(110, 20);
            this.AddCharNameKeyTB.TabIndex = 10;
            this.AddCharNameKeyTB.Text = "Character\'s Name";
            this.AddCharNameKeyTB.GotFocus += new System.EventHandler(this.AddCharNameKeyTB_GotFocus);
            this.AddCharNameKeyTB.Leave += new System.EventHandler(this.AddCharNameKeyTB_Leave);
            // 
            // AddCharNameReset
            // 
            this.AddCharNameReset.Location = new System.Drawing.Point(120, 149);
            this.AddCharNameReset.Name = "AddCharNameReset";
            this.AddCharNameReset.Size = new System.Drawing.Size(81, 21);
            this.AddCharNameReset.TabIndex = 9;
            this.AddCharNameReset.Text = "Reset";
            this.AddCharNameReset.UseVisualStyleBackColor = true;
            this.AddCharNameReset.Click += new System.EventHandler(this.AddCharNameReset_Click);
            // 
            // AddCharNameConfirm
            // 
            this.AddCharNameConfirm.Location = new System.Drawing.Point(3, 148);
            this.AddCharNameConfirm.Name = "AddCharNameConfirm";
            this.AddCharNameConfirm.Size = new System.Drawing.Size(111, 22);
            this.AddCharNameConfirm.TabIndex = 8;
            this.AddCharNameConfirm.Text = "Confirm";
            this.AddCharNameConfirm.UseVisualStyleBackColor = true;
            this.AddCharNameConfirm.Click += new System.EventHandler(this.AddCharNameCofirm_Click);
            // 
            // AddCharNameSearchRsltsLB
            // 
            this.AddCharNameSearchRsltsLB.FormattingEnabled = true;
            this.AddCharNameSearchRsltsLB.Location = new System.Drawing.Point(3, 60);
            this.AddCharNameSearchRsltsLB.Name = "AddCharNameSearchRsltsLB";
            this.AddCharNameSearchRsltsLB.Size = new System.Drawing.Size(198, 82);
            this.AddCharNameSearchRsltsLB.Sorted = true;
            this.AddCharNameSearchRsltsLB.TabIndex = 7;
            // 
            // AddCharSearchNameBtn
            // 
            this.AddCharSearchNameBtn.Location = new System.Drawing.Point(3, 32);
            this.AddCharSearchNameBtn.Name = "AddCharSearchNameBtn";
            this.AddCharSearchNameBtn.Size = new System.Drawing.Size(111, 22);
            this.AddCharSearchNameBtn.TabIndex = 6;
            this.AddCharSearchNameBtn.Text = "Search for Name";
            this.AddCharSearchNameBtn.UseVisualStyleBackColor = true;
            this.AddCharSearchNameBtn.Click += new System.EventHandler(this.AddCharSearchNameBtn_Click);
            // 
            // AddCharForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(227, 199);
            this.Controls.Add(this.AddCharTabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddCharForm";
            this.Text = "Add A Character";
            this.AddCharTabControl.ResumeLayout(false);
            this.AddCharByID.ResumeLayout(false);
            this.AddCharByID.PerformLayout();
            this.AddCharByName.ResumeLayout(false);
            this.AddCharByName.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl AddCharTabControl;
        private System.Windows.Forms.TabPage AddCharByID;
        private System.Windows.Forms.TabPage AddCharByName;
        private System.Windows.Forms.Button AddCharIDBttn;
        private System.Windows.Forms.MaskedTextBox AddCharIDMTB;
        private System.Windows.Forms.Button AddCharIDResetBtn;
        private System.Windows.Forms.Button AddCharConfirmBtn;
        private System.Windows.Forms.ListBox AddCharSearchResults;
        private System.Windows.Forms.TextBox AddCharNameKeyTB;
        private System.Windows.Forms.Button AddCharNameReset;
        private System.Windows.Forms.Button AddCharNameConfirm;
        private System.Windows.Forms.ListBox AddCharNameSearchRsltsLB;
        private System.Windows.Forms.Button AddCharSearchNameBtn;
    }
}