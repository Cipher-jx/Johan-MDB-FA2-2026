namespace KhayelitshaLibraryApp
{
    partial class FrmReports
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
            btnOverdueLoans = new Button();
            btnLoansPerMember = new Button();
            btnAllLoans = new Button();
            dgvReports = new DataGridView();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvReports).BeginInit();
            SuspendLayout();
            // 
            // btnOverdueLoans
            // 
            btnOverdueLoans.Location = new Point(22, 31);
            btnOverdueLoans.Name = "btnOverdueLoans";
            btnOverdueLoans.Size = new Size(188, 91);
            btnOverdueLoans.TabIndex = 0;
            btnOverdueLoans.Text = "Overdue Loans";
            btnOverdueLoans.UseVisualStyleBackColor = true;
            // 
            // btnLoansPerMember
            // 
            btnLoansPerMember.Location = new Point(22, 128);
            btnLoansPerMember.Name = "btnLoansPerMember";
            btnLoansPerMember.Size = new Size(188, 91);
            btnLoansPerMember.TabIndex = 1;
            btnLoansPerMember.Text = "Loans Per Member";
            btnLoansPerMember.UseVisualStyleBackColor = true;
            // 
            // btnAllLoans
            // 
            btnAllLoans.Location = new Point(22, 225);
            btnAllLoans.Name = "btnAllLoans";
            btnAllLoans.Size = new Size(188, 91);
            btnAllLoans.TabIndex = 2;
            btnAllLoans.Text = "All Loans";
            btnAllLoans.UseVisualStyleBackColor = true;
            // 
            // dgvReports
            // 
            dgvReports.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReports.Location = new Point(327, 31);
            dgvReports.Name = "dgvReports";
            dgvReports.RowHeadersWidth = 51;
            dgvReports.Size = new Size(699, 300);
            dgvReports.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(618, 9);
            label1.Name = "label1";
            label1.Size = new Size(104, 20);
            label1.TabIndex = 4;
            label1.Text = "Report Results";
            // 
            // FrmReports
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1038, 368);
            Controls.Add(label1);
            Controls.Add(dgvReports);
            Controls.Add(btnAllLoans);
            Controls.Add(btnLoansPerMember);
            Controls.Add(btnOverdueLoans);
            Name = "FrmReports";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Library Reports";
            ((System.ComponentModel.ISupportInitialize)dgvReports).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnOverdueLoans;
        private Button btnLoansPerMember;
        private Button btnAllLoans;
        private DataGridView dgvReports;
        private Label label1;
    }
}