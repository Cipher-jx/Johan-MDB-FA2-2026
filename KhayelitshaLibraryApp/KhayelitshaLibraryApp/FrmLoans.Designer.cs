namespace KhayelitshaLibraryApp
{
    partial class FrmLoans
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
            lblMember = new Label();
            lblBookCopy = new Label();
            lblStaff = new Label();
            cmbMember = new ComboBox();
            cmbBookCopy = new ComboBox();
            cmbStaff = new ComboBox();
            lblLoanDate = new Label();
            lblDueDate = new Label();
            dtpLoanDate = new DateTimePicker();
            dtpDueDate = new DateTimePicker();
            btnIssueBook = new Button();
            btnReturnBook = new Button();
            dgvLoans = new DataGridView();
            lblLoans = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvLoans).BeginInit();
            SuspendLayout();
            // 
            // lblMember
            // 
            lblMember.AutoSize = true;
            lblMember.Location = new Point(35, 31);
            lblMember.Name = "lblMember";
            lblMember.Size = new Size(65, 20);
            lblMember.TabIndex = 0;
            lblMember.Text = "Member";
            // 
            // lblBookCopy
            // 
            lblBookCopy.AutoSize = true;
            lblBookCopy.Location = new Point(35, 81);
            lblBookCopy.Name = "lblBookCopy";
            lblBookCopy.Size = new Size(81, 20);
            lblBookCopy.TabIndex = 1;
            lblBookCopy.Text = "Book Copy";
            // 
            // lblStaff
            // 
            lblStaff.AutoSize = true;
            lblStaff.Location = new Point(35, 132);
            lblStaff.Name = "lblStaff";
            lblStaff.Size = new Size(100, 20);
            lblStaff.TabIndex = 2;
            lblStaff.Text = "Staff Member";
            // 
            // cmbMember
            // 
            cmbMember.FormattingEnabled = true;
            cmbMember.Location = new Point(141, 23);
            cmbMember.Name = "cmbMember";
            cmbMember.Size = new Size(151, 28);
            cmbMember.TabIndex = 3;
            // 
            // cmbBookCopy
            // 
            cmbBookCopy.FormattingEnabled = true;
            cmbBookCopy.Location = new Point(141, 73);
            cmbBookCopy.Name = "cmbBookCopy";
            cmbBookCopy.Size = new Size(151, 28);
            cmbBookCopy.TabIndex = 4;
            // 
            // cmbStaff
            // 
            cmbStaff.FormattingEnabled = true;
            cmbStaff.Location = new Point(141, 124);
            cmbStaff.Name = "cmbStaff";
            cmbStaff.Size = new Size(151, 28);
            cmbStaff.TabIndex = 5;
            // 
            // lblLoanDate
            // 
            lblLoanDate.AutoSize = true;
            lblLoanDate.Location = new Point(448, 23);
            lblLoanDate.Name = "lblLoanDate";
            lblLoanDate.Size = new Size(77, 20);
            lblLoanDate.TabIndex = 6;
            lblLoanDate.Text = "Loan Date";
            // 
            // lblDueDate
            // 
            lblDueDate.AutoSize = true;
            lblDueDate.Location = new Point(453, 102);
            lblDueDate.Name = "lblDueDate";
            lblDueDate.Size = new Size(72, 20);
            lblDueDate.TabIndex = 7;
            lblDueDate.Text = "Due Date";
            // 
            // dtpLoanDate
            // 
            dtpLoanDate.Location = new Point(531, 16);
            dtpLoanDate.Name = "dtpLoanDate";
            dtpLoanDate.Size = new Size(250, 27);
            dtpLoanDate.TabIndex = 8;
            // 
            // dtpDueDate
            // 
            dtpDueDate.Location = new Point(531, 95);
            dtpDueDate.Name = "dtpDueDate";
            dtpDueDate.Size = new Size(250, 27);
            dtpDueDate.TabIndex = 9;
            // 
            // btnIssueBook
            // 
            btnIssueBook.Location = new Point(2, 237);
            btnIssueBook.Name = "btnIssueBook";
            btnIssueBook.Size = new Size(148, 94);
            btnIssueBook.TabIndex = 10;
            btnIssueBook.Text = "Issue Book";
            btnIssueBook.UseVisualStyleBackColor = true;
            // 
            // btnReturnBook
            // 
            btnReturnBook.Location = new Point(212, 237);
            btnReturnBook.Name = "btnReturnBook";
            btnReturnBook.Size = new Size(148, 94);
            btnReturnBook.TabIndex = 11;
            btnReturnBook.Text = "Return Book";
            btnReturnBook.UseVisualStyleBackColor = true;
            // 
            // dgvLoans
            // 
            dgvLoans.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLoans.Location = new Point(411, 216);
            dgvLoans.Name = "dgvLoans";
            dgvLoans.RowHeadersWidth = 51;
            dgvLoans.Size = new Size(541, 333);
            dgvLoans.TabIndex = 12;
            // 
            // lblLoans
            // 
            lblLoans.AutoSize = true;
            lblLoans.Location = new Point(586, 193);
            lblLoans.Name = "lblLoans";
            lblLoans.Size = new Size(195, 20);
            lblLoans.TabIndex = 13;
            lblLoans.Text = "Current and Historical Loans";
            // 
            // FrmLoans
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(982, 603);
            Controls.Add(lblLoans);
            Controls.Add(dgvLoans);
            Controls.Add(btnReturnBook);
            Controls.Add(btnIssueBook);
            Controls.Add(dtpDueDate);
            Controls.Add(dtpLoanDate);
            Controls.Add(lblDueDate);
            Controls.Add(lblLoanDate);
            Controls.Add(cmbStaff);
            Controls.Add(cmbBookCopy);
            Controls.Add(cmbMember);
            Controls.Add(lblStaff);
            Controls.Add(lblBookCopy);
            Controls.Add(lblMember);
            Name = "FrmLoans";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Loans and Returns";
            ((System.ComponentModel.ISupportInitialize)dgvLoans).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblMember;
        private Label lblBookCopy;
        private Label lblStaff;
        private ComboBox cmbMember;
        private ComboBox cmbBookCopy;
        private ComboBox cmbStaff;
        private Label lblLoanDate;
        private Label lblDueDate;
        private DateTimePicker dtpLoanDate;
        private DateTimePicker dtpDueDate;
        private Button btnIssueBook;
        private Button btnReturnBook;
        private DataGridView dgvLoans;
        private Label lblLoans;
    }
}