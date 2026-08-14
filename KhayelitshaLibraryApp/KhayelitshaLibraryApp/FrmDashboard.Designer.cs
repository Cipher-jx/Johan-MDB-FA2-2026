namespace KhayelitshaLibraryApp
{
    partial class FrmDashboard
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblTitle = new Label();
            btnMembers = new Button();
            btnBooks = new Button();
            btnLoans = new Button();
            btnReports = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 20F);
            lblTitle.Location = new Point(184, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(480, 46);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Khayelitsha Community Library";
            // 
            // btnMembers
            // 
            btnMembers.Location = new Point(164, 184);
            btnMembers.Name = "btnMembers";
            btnMembers.Size = new Size(196, 71);
            btnMembers.TabIndex = 3;
            btnMembers.Text = "Members";
            btnMembers.UseVisualStyleBackColor = true;
            btnMembers.Click += btnMembers_Click;
            // 
            // btnBooks
            // 
            btnBooks.Location = new Point(509, 184);
            btnBooks.Name = "btnBooks";
            btnBooks.Size = new Size(196, 71);
            btnBooks.TabIndex = 4;
            btnBooks.Text = "Books";
            btnBooks.UseVisualStyleBackColor = true;
            btnBooks.Click += btnBooks_Click;
            // 
            // btnLoans
            // 
            btnLoans.Location = new Point(164, 305);
            btnLoans.Name = "btnLoans";
            btnLoans.Size = new Size(196, 71);
            btnLoans.TabIndex = 5;
            btnLoans.Text = "Loans / Returns";
            btnLoans.UseVisualStyleBackColor = true;
            btnLoans.Click += btnLoans_Click;
            // 
            // btnReports
            // 
            btnReports.Location = new Point(509, 305);
            btnReports.Name = "btnReports";
            btnReports.Size = new Size(196, 71);
            btnReports.TabIndex = 6;
            btnReports.Text = "Reports";
            btnReports.UseVisualStyleBackColor = true;
            btnReports.Click += btnReports_Click;
            // 
            // FrmDashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(882, 553);
            Controls.Add(btnReports);
            Controls.Add(btnLoans);
            Controls.Add(btnBooks);
            Controls.Add(btnMembers);
            Controls.Add(lblTitle);
            Name = "FrmDashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Khayelitsha Community Library";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Button btnMembers;
        private Button btnBooks;
        private Button btnLoans;
        private Button btnReports;
    }
}
