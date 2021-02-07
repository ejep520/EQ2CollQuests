
namespace EQ2CollQuests
{
    partial class AboutForm
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
            this.ProgNameLabel = new System.Windows.Forms.Label();
            this.AuthorLine = new System.Windows.Forms.LinkLabel();
            this.AboutTB = new System.Windows.Forms.TextBox();
            this.AboutOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ProgNameLabel
            // 
            this.ProgNameLabel.AutoSize = true;
            this.ProgNameLabel.Location = new System.Drawing.Point(12, 9);
            this.ProgNameLabel.Name = "ProgNameLabel";
            this.ProgNameLabel.Size = new System.Drawing.Size(118, 13);
            this.ProgNameLabel.TabIndex = 0;
            this.ProgNameLabel.Text = "EQ2 Collections Quests";
            // 
            // AuthorLine
            // 
            this.AuthorLine.AutoSize = true;
            this.AuthorLine.LinkArea = new System.Windows.Forms.LinkArea(11, 11);
            this.AuthorLine.Location = new System.Drawing.Point(12, 22);
            this.AuthorLine.Name = "AuthorLine";
            this.AuthorLine.Size = new System.Drawing.Size(117, 17);
            this.AuthorLine.TabIndex = 1;
            this.AuthorLine.TabStop = true;
            this.AuthorLine.Text = "Written by Erik Jepsen";
            this.AuthorLine.UseCompatibleTextRendering = true;
            this.AuthorLine.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.AuthorLine_LinkClicked);
            // 
            // AboutTB
            // 
            this.AboutTB.Location = new System.Drawing.Point(15, 42);
            this.AboutTB.Multiline = true;
            this.AboutTB.Name = "AboutTB";
            this.AboutTB.ReadOnly = true;
            this.AboutTB.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.AboutTB.Size = new System.Drawing.Size(373, 102);
            this.AboutTB.TabIndex = 2;
            // 
            // AboutOK
            // 
            this.AboutOK.Location = new System.Drawing.Point(313, 150);
            this.AboutOK.Name = "AboutOK";
            this.AboutOK.Size = new System.Drawing.Size(75, 23);
            this.AboutOK.TabIndex = 3;
            this.AboutOK.Text = "OK";
            this.AboutOK.UseVisualStyleBackColor = true;
            this.AboutOK.Click += new System.EventHandler(this.AboutOK_Click);
            // 
            // AboutForm
            // 
            this.AcceptButton = this.AboutOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 178);
            this.Controls.Add(this.AboutOK);
            this.Controls.Add(this.AboutTB);
            this.Controls.Add(this.AuthorLine);
            this.Controls.Add(this.ProgNameLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutForm";
            this.Text = "About";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ProgNameLabel;
        private System.Windows.Forms.LinkLabel AuthorLine;
        private System.Windows.Forms.TextBox AboutTB;
        private System.Windows.Forms.Button AboutOK;
    }
}