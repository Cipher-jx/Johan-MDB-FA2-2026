namespace KhayelitshaLibraryApp
{
    partial class FrmMembers
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
            label1 = new Label();
            label2 = new Label();
            txtMemberID = new TextBox();
            txtFullName = new TextBox();
            txtAddress = new TextBox();
            lblAddress = new Label();
            lblPhone = new Label();
            txtPhone = new TextBox();
            lblJoinDate = new Label();
            dtpJoinDate = new DateTimePicker();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnClear = new Button();
            btnSearch = new Button();
            dgvMembers = new DataGridView();
            txtSearch = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvMembers).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 21);
            label1.Name = "label1";
            label1.Size = new Size(84, 20);
            label1.TabIndex = 0;
            label1.Text = "Member ID";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(329, 17);
            label2.Name = "label2";
            label2.Size = new Size(76, 20);
            label2.TabIndex = 1;
            label2.Text = "Full Name";
            // 
            // txtMemberID
            // 
            txtMemberID.Location = new Point(102, 18);
            txtMemberID.Name = "txtMemberID";
            txtMemberID.Size = new Size(198, 27);
            txtMemberID.TabIndex = 2;
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(411, 12);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(198, 27);
            txtFullName.TabIndex = 3;
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(102, 96);
            txtAddress.Multiline = true;
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(198, 34);
            txtAddress.TabIndex = 4;
            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.Location = new Point(12, 106);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(62, 20);
            lblAddress.TabIndex = 5;
            lblAddress.Text = "Address";
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Location = new Point(329, 106);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(50, 20);
            lblPhone.TabIndex = 6;
            lblPhone.Text = "Phone";
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(411, 103);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(198, 27);
            txtPhone.TabIndex = 7;
            // 
            // lblJoinDate
            // 
            lblJoinDate.AutoSize = true;
            lblJoinDate.Location = new Point(12, 184);
            lblJoinDate.Name = "lblJoinDate";
            lblJoinDate.Size = new Size(71, 20);
            lblJoinDate.TabIndex = 8;
            lblJoinDate.Text = "Join Date";
            // 
            // dtpJoinDate
            // 
            dtpJoinDate.Location = new Point(89, 179);
            dtpJoinDate.Name = "dtpJoinDate";
            dtpJoinDate.Size = new Size(250, 27);
            dtpJoinDate.TabIndex = 9;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(43, 258);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(137, 51);
            btnAdd.TabIndex = 10;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(186, 258);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(137, 51);
            btnUpdate.TabIndex = 11;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(329, 258);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(137, 51);
            btnDelete.TabIndex = 12;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(472, 258);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(137, 51);
            btnClear.TabIndex = 13;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(615, 258);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(137, 51);
            btnSearch.TabIndex = 14;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // dgvMembers
            // 
            dgvMembers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMembers.Location = new Point(95, 334);
            dgvMembers.Name = "dgvMembers";
            dgvMembers.RowHeadersWidth = 51;
            dgvMembers.Size = new Size(674, 232);
            dgvMembers.TabIndex = 15;
            dgvMembers.CellClick += dgvMembers_CellClick;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(758, 272);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(168, 27);
            txtSearch.TabIndex = 16;
            // 
            // FrmMembers
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(982, 603);
            Controls.Add(txtSearch);
            Controls.Add(dgvMembers);
            Controls.Add(btnSearch);
            Controls.Add(btnClear);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnAdd);
            Controls.Add(dtpJoinDate);
            Controls.Add(lblJoinDate);
            Controls.Add(txtPhone);
            Controls.Add(lblPhone);
            Controls.Add(lblAddress);
            Controls.Add(txtAddress);
            Controls.Add(txtFullName);
            Controls.Add(txtMemberID);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FrmMembers";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Member Management";
            ((System.ComponentModel.ISupportInitialize)dgvMembers).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtMemberID;
        private TextBox txtFullName;
        private TextBox txtAddress;
        private Label lblAddress;
        private Label lblPhone;
        private TextBox txtPhone;
        private Label lblJoinDate;
        private DateTimePicker dtpJoinDate;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnClear;
        private Button btnSearch;
        private DataGridView dgvMembers;
        private TextBox txtSearch;
    }
}