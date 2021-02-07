
namespace EQ2CollQuests
{
    partial class Playing
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
            this.PAItemList = new System.Windows.Forms.ComboBox();
            this.PASplitContainer = new System.Windows.Forms.SplitContainer();
            this.PAResetBtn = new System.Windows.Forms.Button();
            this.PAConfirmAdd = new System.Windows.Forms.Button();
            this.PAListBoxResults = new System.Windows.Forms.ListBox();
            this.PAIntroLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PASplitContainer)).BeginInit();
            this.PASplitContainer.Panel1.SuspendLayout();
            this.PASplitContainer.Panel2.SuspendLayout();
            this.PASplitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // PAItemList
            // 
            this.PAItemList.Dock = System.Windows.Forms.DockStyle.Top;
            this.PAItemList.FormattingEnabled = true;
            this.PAItemList.Location = new System.Drawing.Point(0, 0);
            this.PAItemList.Name = "PAItemList";
            this.PAItemList.Size = new System.Drawing.Size(266, 21);
            this.PAItemList.Sorted = true;
            this.PAItemList.TabIndex = 0;
            this.PAItemList.SelectedIndexChanged += new System.EventHandler(this.PAItemList_SelectedIndexChanged);
            // 
            // PASplitContainer
            // 
            this.PASplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PASplitContainer.Location = new System.Drawing.Point(0, 0);
            this.PASplitContainer.Name = "PASplitContainer";
            // 
            // PASplitContainer.Panel1
            // 
            this.PASplitContainer.Panel1.Controls.Add(this.PAItemList);
            // 
            // PASplitContainer.Panel2
            // 
            this.PASplitContainer.Panel2.Controls.Add(this.PAResetBtn);
            this.PASplitContainer.Panel2.Controls.Add(this.PAConfirmAdd);
            this.PASplitContainer.Panel2.Controls.Add(this.PAListBoxResults);
            this.PASplitContainer.Panel2.Controls.Add(this.PAIntroLabel);
            this.PASplitContainer.Size = new System.Drawing.Size(800, 450);
            this.PASplitContainer.SplitterDistance = 266;
            this.PASplitContainer.TabIndex = 1;
            // 
            // PAResetBtn
            // 
            this.PAResetBtn.Location = new System.Drawing.Point(377, 409);
            this.PAResetBtn.Name = "PAResetBtn";
            this.PAResetBtn.Size = new System.Drawing.Size(141, 38);
            this.PAResetBtn.TabIndex = 3;
            this.PAResetBtn.Text = "Reset";
            this.PAResetBtn.UseVisualStyleBackColor = true;
            this.PAResetBtn.Click += new System.EventHandler(this.PAResetBtn_Click);
            // 
            // PAConfirmAdd
            // 
            this.PAConfirmAdd.Location = new System.Drawing.Point(3, 408);
            this.PAConfirmAdd.Name = "PAConfirmAdd";
            this.PAConfirmAdd.Size = new System.Drawing.Size(113, 39);
            this.PAConfirmAdd.TabIndex = 2;
            this.PAConfirmAdd.Text = "Confirm";
            this.PAConfirmAdd.UseVisualStyleBackColor = true;
            this.PAConfirmAdd.Click += new System.EventHandler(this.PAConfirmAdd_Click);
            // 
            // PAListBoxResults
            // 
            this.PAListBoxResults.FormattingEnabled = true;
            this.PAListBoxResults.Location = new System.Drawing.Point(0, 21);
            this.PAListBoxResults.Name = "PAListBoxResults";
            this.PAListBoxResults.Size = new System.Drawing.Size(530, 381);
            this.PAListBoxResults.TabIndex = 1;
            // 
            // PAIntroLabel
            // 
            this.PAIntroLabel.AutoSize = true;
            this.PAIntroLabel.BackColor = System.Drawing.SystemColors.Info;
            this.PAIntroLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.PAIntroLabel.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PAIntroLabel.Location = new System.Drawing.Point(0, 0);
            this.PAIntroLabel.Name = "PAIntroLabel";
            this.PAIntroLabel.Size = new System.Drawing.Size(158, 18);
            this.PAIntroLabel.TabIndex = 0;
            this.PAIntroLabel.Text = "Playing As Intro Line";
            // 
            // Playing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.PASplitContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Playing";
            this.Text = "Playing as";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Playing_FormClosing);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Playing_Paint);
            this.PASplitContainer.Panel1.ResumeLayout(false);
            this.PASplitContainer.Panel2.ResumeLayout(false);
            this.PASplitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PASplitContainer)).EndInit();
            this.PASplitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox PAItemList;
        private System.Windows.Forms.SplitContainer PASplitContainer;
        private System.Windows.Forms.Label PAIntroLabel;
        private System.Windows.Forms.ListBox PAListBoxResults;
        private System.Windows.Forms.Button PAResetBtn;
        private System.Windows.Forms.Button PAConfirmAdd;
    }
}