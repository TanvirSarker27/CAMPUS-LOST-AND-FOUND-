namespace CAMPUS_LOST_AND_FOUND
{
    partial class ClaimItem
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
            this.btnViewReports = new System.Windows.Forms.Button();
            this.btnSubmitClaim = new System.Windows.Forms.Button();
            this.ClmLocationTextBox = new System.Windows.Forms.TextBox();
            this.lblLocation = new System.Windows.Forms.Label();
            this.ClmDescriptionRichTextBox = new System.Windows.Forms.RichTextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.ClmContactTextBox = new System.Windows.Forms.TextBox();
            this.lblContact = new System.Windows.Forms.Label();
            this.ItemIdTextBox = new System.Windows.Forms.TextBox();
            this.lblItemId = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnViewReports
            // 
            this.btnViewReports.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.btnViewReports.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnViewReports.FlatAppearance.BorderSize = 0;
            this.btnViewReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewReports.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewReports.ForeColor = System.Drawing.Color.White;
            this.btnViewReports.Location = new System.Drawing.Point(640, 606);
            this.btnViewReports.Name = "btnViewReports";
            this.btnViewReports.Size = new System.Drawing.Size(400, 40);
            this.btnViewReports.TabIndex = 21;
            this.btnViewReports.Text = "View Reports";
            this.btnViewReports.UseVisualStyleBackColor = false;
            this.btnViewReports.Click += new System.EventHandler(this.btnViewReports_Click);
            // 
            // btnSubmitClaim
            // 
            this.btnSubmitClaim.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(197)))), ((int)(((byte)(94)))));
            this.btnSubmitClaim.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSubmitClaim.FlatAppearance.BorderSize = 0;
            this.btnSubmitClaim.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmitClaim.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmitClaim.ForeColor = System.Drawing.Color.White;
            this.btnSubmitClaim.Location = new System.Drawing.Point(198, 606);
            this.btnSubmitClaim.Name = "btnSubmitClaim";
            this.btnSubmitClaim.Size = new System.Drawing.Size(400, 40);
            this.btnSubmitClaim.TabIndex = 20;
            this.btnSubmitClaim.Text = "Submit Claim";
            this.btnSubmitClaim.UseVisualStyleBackColor = false;
            this.btnSubmitClaim.Click += new System.EventHandler(this.btnSubmitClaim_Click);
            // 
            // ClmLocationTextBox
            // 
            this.ClmLocationTextBox.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClmLocationTextBox.Location = new System.Drawing.Point(197, 546);
            this.ClmLocationTextBox.Name = "ClmLocationTextBox";
            this.ClmLocationTextBox.Size = new System.Drawing.Size(843, 34);
            this.ClmLocationTextBox.TabIndex = 19;
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocation.Location = new System.Drawing.Point(193, 513);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(209, 30);
            this.lblLocation.TabIndex = 18;
            this.lblLocation.Text = "Last Known Location";
            // 
            // ClmDescriptionRichTextBox
            // 
            this.ClmDescriptionRichTextBox.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClmDescriptionRichTextBox.Location = new System.Drawing.Point(197, 410);
            this.ClmDescriptionRichTextBox.Name = "ClmDescriptionRichTextBox";
            this.ClmDescriptionRichTextBox.Size = new System.Drawing.Size(843, 100);
            this.ClmDescriptionRichTextBox.TabIndex = 17;
            this.ClmDescriptionRichTextBox.Text = "";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.Location = new System.Drawing.Point(193, 368);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(847, 30);
            this.lblDescription.TabIndex = 16;
            this.lblDescription.Text = "Please describe the item you are claiming, including any unique or identifying fe" +
    "atures.";
            // 
            // ClmContactTextBox
            // 
            this.ClmContactTextBox.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClmContactTextBox.Location = new System.Drawing.Point(197, 331);
            this.ClmContactTextBox.Name = "ClmContactTextBox";
            this.ClmContactTextBox.Size = new System.Drawing.Size(843, 34);
            this.ClmContactTextBox.TabIndex = 15;
            // 
            // lblContact
            // 
            this.lblContact.AutoSize = true;
            this.lblContact.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContact.Location = new System.Drawing.Point(193, 298);
            this.lblContact.Name = "lblContact";
            this.lblContact.Size = new System.Drawing.Size(136, 30);
            this.lblContact.TabIndex = 14;
            this.lblContact.Text = "Your Contact";
            // 
            // ItemIdTextBox
            // 
            this.ItemIdTextBox.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ItemIdTextBox.Location = new System.Drawing.Point(197, 261);
            this.ItemIdTextBox.Name = "ItemIdTextBox";
            this.ItemIdTextBox.Size = new System.Drawing.Size(843, 34);
            this.ItemIdTextBox.TabIndex = 13;
            // 
            // lblItemId
            // 
            this.lblItemId.AutoSize = true;
            this.lblItemId.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemId.Location = new System.Drawing.Point(193, 228);
            this.lblItemId.Name = "lblItemId";
            this.lblItemId.Size = new System.Drawing.Size(84, 30);
            this.lblItemId.TabIndex = 12;
            this.lblItemId.Text = "Item ID";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblTitle.Location = new System.Drawing.Point(412, 145);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(323, 54);
            this.lblTitle.TabIndex = 11;
            this.lblTitle.Text = "Claim Your Item";
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(104)))), ((int)(((byte)(168)))));
            this.pnlHeader.Controls.Add(this.label1);
            this.pnlHeader.Controls.Add(this.label2);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1228, 120);
            this.pnlHeader.TabIndex = 29;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(235)))), ((int)(((byte)(250)))));
            this.label1.Location = new System.Drawing.Point(345, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(488, 20);
            this.label1.TabIndex = 29;
            this.label1.Text = "Campus Lost & Found Find What You Lost, Return What You Found.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Palatino Linotype", 23.77358F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(308, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(553, 64);
            this.label2.TabIndex = 21;
            this.label2.Text = "Campus Lost and Found";
            // 
            // ClaimItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1228, 694);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.btnViewReports);
            this.Controls.Add(this.btnSubmitClaim);
            this.Controls.Add(this.ClmLocationTextBox);
            this.Controls.Add(this.lblLocation);
            this.Controls.Add(this.ClmDescriptionRichTextBox);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.ClmContactTextBox);
            this.Controls.Add(this.lblContact);
            this.Controls.Add(this.ItemIdTextBox);
            this.Controls.Add(this.lblItemId);
            this.Controls.Add(this.lblTitle);
            this.Name = "ClaimItem";
            this.Text = "Campus Lost & Found - Claim Item";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnViewReports;
        private System.Windows.Forms.Button btnSubmitClaim;
        private System.Windows.Forms.TextBox ClmLocationTextBox;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.RichTextBox ClmDescriptionRichTextBox;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox ClmContactTextBox;
        private System.Windows.Forms.Label lblContact;
        private System.Windows.Forms.TextBox ItemIdTextBox;
        private System.Windows.Forms.Label lblItemId;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}