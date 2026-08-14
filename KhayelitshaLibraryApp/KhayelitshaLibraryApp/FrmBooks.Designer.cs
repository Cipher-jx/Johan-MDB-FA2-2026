namespace KhayelitshaLibraryApp
{
    partial class FrmBooks
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
            lblBookTitleID = new Label();
            lblTitle = new Label();
            lblAuthor = new Label();
            txtBookTitleID = new TextBox();
            txtTitle = new TextBox();
            txtAuthor = new TextBox();
            txtCopyID = new TextBox();
            lblCopyID = new Label();
            lblBookTitle = new Label();
            lblStatus = new Label();
            cmbBookTitle = new ComboBox();
            cmbStatus = new ComboBox();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnClear = new Button();
            btnSearch = new Button();
            dgvBookTitles = new DataGridView();
            dgvBookCopies = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvBookTitles).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvBookCopies).BeginInit();
            SuspendLayout();
            // 
            // lblBookTitleID
            // 
            lblBookTitleID.AutoSize = true;
            lblBookTitleID.Location = new Point(12, 19);
            lblBookTitleID.Name = "lblBookTitleID";
            lblBookTitleID.Size = new Size(95, 20);
            lblBookTitleID.TabIndex = 0;
            lblBookTitleID.Text = "Book Title ID";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(69, 58);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(38, 20);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Title";
            // 
            // lblAuthor
            // 
            lblAuthor.AutoSize = true;
            lblAuthor.Location = new Point(53, 99);
            lblAuthor.Name = "lblAuthor";
            lblAuthor.Size = new Size(54, 20);
            lblAuthor.TabIndex = 2;
            lblAuthor.Text = "Author";
            // 
            // txtBookTitleID
            // 
            txtBookTitleID.Location = new Point(113, 12);
            txtBookTitleID.Name = "txtBookTitleID";
            txtBookTitleID.Size = new Size(151, 27);
            txtBookTitleID.TabIndex = 3;
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(113, 51);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(151, 27);
            txtTitle.TabIndex = 4;
            // 
            // txtAuthor
            // 
            txtAuthor.Location = new Point(113, 92);
            txtAuthor.Name = "txtAuthor";
            txtAuthor.Size = new Size(151, 27);
            txtAuthor.TabIndex = 5;
            // 
            // txtCopyID
            // 
            txtCopyID.Location = new Point(113, 135);
            txtCopyID.Name = "txtCopyID";
            txtCopyID.Size = new Size(151, 27);
            txtCopyID.TabIndex = 6;
            // 
            // lblCopyID
            // 
            lblCopyID.AutoSize = true;
            lblCopyID.Location = new Point(45, 142);
            lblCopyID.Name = "lblCopyID";
            lblCopyID.Size = new Size(62, 20);
            lblCopyID.TabIndex = 7;
            lblCopyID.Text = "Copy ID";
            // 
            // lblBookTitle
            // 
            lblBookTitle.AutoSize = true;
            lblBookTitle.Location = new Point(31, 183);
            lblBookTitle.Name = "lblBookTitle";
            lblBookTitle.Size = new Size(76, 20);
            lblBookTitle.TabIndex = 8;
            lblBookTitle.Text = "Book Title";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(58, 228);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(49, 20);
            lblStatus.TabIndex = 9;
            lblStatus.Text = "Status";
            // 
            // cmbBookTitle
            // 
            cmbBookTitle.FormattingEnabled = true;
            cmbBookTitle.Location = new Point(113, 175);
            cmbBookTitle.Name = "cmbBookTitle";
            cmbBookTitle.Size = new Size(151, 28);
            cmbBookTitle.TabIndex = 10;
            // 
            // cmbStatus
            // 
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Location = new Point(113, 220);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(151, 28);
            cmbStatus.TabIndex = 11;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(17, 370);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(163, 64);
            btnAdd.TabIndex = 12;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(186, 370);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(163, 64);
            btnUpdate.TabIndex = 13;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(355, 370);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(163, 64);
            btnDelete.TabIndex = 14;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(524, 370);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(163, 64);
            btnClear.TabIndex = 15;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(693, 370);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(163, 64);
            btnSearch.TabIndex = 16;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // dgvBookTitles
            // 
            dgvBookTitles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBookTitles.Location = new Point(355, 32);
            dgvBookTitles.Name = "dgvBookTitles";
            dgvBookTitles.RowHeadersWidth = 51;
            dgvBookTitles.Size = new Size(431, 320);
            dgvBookTitles.TabIndex = 17;
            // 
            // dgvBookCopies
            // 
            dgvBookCopies.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBookCopies.Location = new Point(792, 32);
            dgvBookCopies.Name = "dgvBookCopies";
            dgvBookCopies.RowHeadersWidth = 51;
            dgvBookCopies.Size = new Size(534, 320);
            dgvBookCopies.TabIndex = 18;
            dgvBookCopies.Tag = "";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(524, 9);
            label1.Name = "label1";
            label1.Size = new Size(82, 20);
            label1.TabIndex = 19;
            label1.Text = "Book Titles";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(986, 9);
            label2.Name = "label2";
            label2.Size = new Size(148, 20);
            label2.TabIndex = 20;
            label2.Text = "Physical Book Copies";
            // 
            // FrmBooks
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1338, 446);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dgvBookCopies);
            Controls.Add(dgvBookTitles);
            Controls.Add(btnSearch);
            Controls.Add(btnClear);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnAdd);
            Controls.Add(cmbStatus);
            Controls.Add(cmbBookTitle);
            Controls.Add(lblStatus);
            Controls.Add(lblBookTitle);
            Controls.Add(lblCopyID);
            Controls.Add(txtCopyID);
            Controls.Add(txtAuthor);
            Controls.Add(txtTitle);
            Controls.Add(txtBookTitleID);
            Controls.Add(lblAuthor);
            Controls.Add(lblTitle);
            Controls.Add(lblBookTitleID);
            Name = "FrmBooks";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Book Management";
            ((System.ComponentModel.ISupportInitialize)dgvBookTitles).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvBookCopies).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblBookTitleID;
        private Label lblTitle;
        private Label lblAuthor;
        private TextBox txtBookTitleID;
        private TextBox txtTitle;
        private TextBox txtAuthor;
        private TextBox txtCopyID;
        private Label lblCopyID;
        private Label lblBookTitle;
        private Label lblStatus;
        private ComboBox cmbBookTitle;
        private ComboBox cmbStatus;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnClear;
        private Button btnSearch;
        private DataGridView dgvBookTitles;
        private DataGridView dgvBookCopies;
        private Label label1;
        private Label label2;
    }
}