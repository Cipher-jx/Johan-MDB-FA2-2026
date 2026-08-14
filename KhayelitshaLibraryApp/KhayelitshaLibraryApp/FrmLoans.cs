using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace KhayelitshaLibraryApp
{
    public partial class FrmLoans : Form
    {
        private readonly string connectionString =
            @"Server=.;Database=KhayelitshaLibraryDB;Trusted_Connection=True;TrustServerCertificate=True;";

        public FrmLoans()
        {
            InitializeComponent();

            btnIssueBook.Click += btnIssueBook_Click;
            btnReturnBook.Click += btnReturnBook_Click;
            dgvLoans.CellClick += dgvLoans_CellClick;

            LoadMembers();
            LoadBookCopies();
            LoadStaff();
            LoadLoans();

            dtpLoanDate.Value = DateTime.Today;
            dtpDueDate.Value = DateTime.Today.AddDays(14);
        }

        private void LoadMembers()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT MemberID, FullName FROM Member ORDER BY FullName";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable table = new DataTable();

                    adapter.Fill(table);

                    cmbMember.DataSource = table;
                    cmbMember.DisplayMember = "FullName";
                    cmbMember.ValueMember = "MemberID";
                    cmbMember.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error loading members: " + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void LoadBookCopies()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = @"
                        SELECT 
                            bc.CopyID,
                            bt.Title
                        FROM BookCopy bc
                        INNER JOIN BookTitle bt
                            ON bc.BookTitleID = bt.BookTitleID
                        WHERE bc.Status = 'Available'
                        ORDER BY bt.Title, bc.CopyID";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable table = new DataTable();

                    adapter.Fill(table);

                    table.Columns.Add("DisplayText", typeof(string));

                    foreach (DataRow row in table.Rows)
                    {
                        row["DisplayText"] =
                            "Copy " + row["CopyID"].ToString() +
                            " - " + row["Title"].ToString();
                    }

                    cmbBookCopy.DataSource = table;
                    cmbBookCopy.DisplayMember = "DisplayText";
                    cmbBookCopy.ValueMember = "CopyID";
                    cmbBookCopy.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error loading book copies: " + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void LoadStaff()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT StaffID, FullName FROM Staff ORDER BY FullName";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable table = new DataTable();

                    adapter.Fill(table);

                    cmbStaff.DataSource = table;
                    cmbStaff.DisplayMember = "FullName";
                    cmbStaff.ValueMember = "StaffID";
                    cmbStaff.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error loading staff: " + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void LoadLoans()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = @"
                        SELECT
                            l.LoanID,
                            l.MemberID,
                            m.FullName AS MemberName,
                            l.CopyID,
                            bt.Title AS BookTitle,
                            l.StaffID,
                            s.FullName AS StaffName,
                            l.LoanDate,
                            l.DueDate,
                            l.ReturnDate
                        FROM Loan l
                        INNER JOIN Member m
                            ON l.MemberID = m.MemberID
                        INNER JOIN BookCopy bc
                            ON l.CopyID = bc.CopyID
                        INNER JOIN BookTitle bt
                            ON bc.BookTitleID = bt.BookTitleID
                        INNER JOIN Staff s
                            ON l.StaffID = s.StaffID
                        ORDER BY l.LoanID DESC";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable table = new DataTable();

                    adapter.Fill(table);

                    dgvLoans.DataSource = table;

                    if (dgvLoans.Columns.Contains("MemberID"))
                        dgvLoans.Columns["MemberID"].Visible = false;

                    if (dgvLoans.Columns.Contains("StaffID"))
                        dgvLoans.Columns["StaffID"].Visible = false;

                    if (dgvLoans.Columns.Contains("CopyID"))
                        dgvLoans.Columns["CopyID"].HeaderText = "Copy ID";

                    if (dgvLoans.Columns.Contains("LoanID"))
                        dgvLoans.Columns["LoanID"].HeaderText = "Loan ID";

                    if (dgvLoans.Columns.Contains("MemberName"))
                        dgvLoans.Columns["MemberName"].HeaderText = "Member";

                    if (dgvLoans.Columns.Contains("BookTitle"))
                        dgvLoans.Columns["BookTitle"].HeaderText = "Book";

                    if (dgvLoans.Columns.Contains("StaffName"))
                        dgvLoans.Columns["StaffName"].HeaderText = "Staff";

                    if (dgvLoans.Columns.Contains("LoanDate"))
                        dgvLoans.Columns["LoanDate"].HeaderText = "Loan Date";

                    if (dgvLoans.Columns.Contains("DueDate"))
                        dgvLoans.Columns["DueDate"].HeaderText = "Due Date";

                    if (dgvLoans.Columns.Contains("ReturnDate"))
                        dgvLoans.Columns["ReturnDate"].HeaderText = "Return Date";

                    dgvLoans.AutoSizeColumnsMode =
                        DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error loading loans: " + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnIssueBook_Click(object sender, EventArgs e)
        {
            if (cmbMember.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Please select a member.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (cmbBookCopy.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Please select an available book copy.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (cmbStaff.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Please select a staff member.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (dtpDueDate.Value.Date < dtpLoanDate.Value.Date)
            {
                MessageBox.Show(
                    "The due date cannot be before the loan date.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            int memberID = Convert.ToInt32(cmbMember.SelectedValue);
            int copyID = Convert.ToInt32(cmbBookCopy.SelectedValue);
            int staffID = Convert.ToInt32(cmbStaff.SelectedValue);

            DateTime loanDate = dtpLoanDate.Value.Date;
            DateTime dueDate = dtpDueDate.Value.Date;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlTransaction transaction =
                        connection.BeginTransaction();

                    try
                    {
                        // Check that the copy is still available
                        string checkQuery = @"
                            SELECT Status
                            FROM BookCopy
                            WHERE CopyID = @CopyID";

                        using (SqlCommand checkCommand =
                            new SqlCommand(checkQuery, connection, transaction))
                        {
                            checkCommand.Parameters.AddWithValue("@CopyID", copyID);

                            object result = checkCommand.ExecuteScalar();

                            if (result == null)
                            {
                                MessageBox.Show(
                                    "The selected book copy does not exist.",
                                    "Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);

                                transaction.Rollback();
                                return;
                            }

                            if (result.ToString() != "Available")
                            {
                                MessageBox.Show(
                                    "This book copy is no longer available.",
                                    "Unavailable",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);

                                transaction.Rollback();
                                LoadBookCopies();
                                return;
                            }
                        }

                        // Insert the loan
                        string insertLoanQuery = @"
                            INSERT INTO Loan
                            (
                                MemberID,
                                CopyID,
                                StaffID,
                                LoanDate,
                                DueDate,
                                ReturnDate
                            )
                            VALUES
                            (
                                @MemberID,
                                @CopyID,
                                @StaffID,
                                @LoanDate,
                                @DueDate,
                                NULL
                            )";

                        using (SqlCommand command =
                            new SqlCommand(insertLoanQuery, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@MemberID", memberID);
                            command.Parameters.AddWithValue("@CopyID", copyID);
                            command.Parameters.AddWithValue("@StaffID", staffID);
                            command.Parameters.AddWithValue("@LoanDate", loanDate);
                            command.Parameters.AddWithValue("@DueDate", dueDate);

                            command.ExecuteNonQuery();
                        }

                        // Change copy status to On Loan
                        string updateCopyQuery = @"
                            UPDATE BookCopy
                            SET Status = 'On Loan'
                            WHERE CopyID = @CopyID";

                        using (SqlCommand command =
                            new SqlCommand(updateCopyQuery, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@CopyID", copyID);

                            command.ExecuteNonQuery();
                        }

                        transaction.Commit();

                        MessageBox.Show(
                            "Book issued successfully.",
                            "Success",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                        LoadLoans();
                        LoadBookCopies();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error issuing book: " + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void dgvLoans_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow row = dgvLoans.Rows[e.RowIndex];

            if (row.Cells["MemberID"].Value != null)
            {
                cmbMember.SelectedValue =
                    Convert.ToInt32(row.Cells["MemberID"].Value);
            }

            if (row.Cells["StaffID"].Value != null)
            {
                cmbStaff.SelectedValue =
                    Convert.ToInt32(row.Cells["StaffID"].Value);
            }

            if (row.Cells["CopyID"].Value != null)
            {
                int copyID = Convert.ToInt32(row.Cells["CopyID"].Value);

                // The copy may not appear in the available-copy ComboBox
                // because it could currently be On Loan.
                SelectBookCopy(copyID);
            }

            if (row.Cells["LoanDate"].Value != null)
            {
                dtpLoanDate.Value =
                    Convert.ToDateTime(row.Cells["LoanDate"].Value);
            }

            if (row.Cells["DueDate"].Value != null)
            {
                dtpDueDate.Value =
                    Convert.ToDateTime(row.Cells["DueDate"].Value);
            }
        }

        private void SelectBookCopy(int copyID)
        {
            try
            {
                // First check if the copy is already in the ComboBox
                cmbBookCopy.SelectedValue = copyID;

                if (cmbBookCopy.SelectedIndex != -1)
                    return;

                // If it isn't available, temporarily load that copy
                // so the selected loan can still be displayed.
                using (SqlConnection connection =
                    new SqlConnection(connectionString))
                {
                    string query = @"
                        SELECT
                            bc.CopyID,
                            bt.Title
                        FROM BookCopy bc
                        INNER JOIN BookTitle bt
                            ON bc.BookTitleID = bt.BookTitleID
                        WHERE bc.CopyID = @CopyID";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    adapter.SelectCommand.Parameters.AddWithValue(
                        "@CopyID", copyID);

                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    if (table.Rows.Count > 0)
                    {
                        table.Columns.Add(
                            "DisplayText",
                            typeof(string));

                        foreach (DataRow row in table.Rows)
                        {
                            row["DisplayText"] =
                                "Copy " + row["CopyID"].ToString() +
                                " - " + row["Title"].ToString();
                        }

                        cmbBookCopy.DataSource = table;
                        cmbBookCopy.DisplayMember = "DisplayText";
                        cmbBookCopy.ValueMember = "CopyID";
                        cmbBookCopy.SelectedValue = copyID;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error selecting book copy: " + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnReturnBook_Click(object sender, EventArgs e)
        {
            if (dgvLoans.CurrentRow == null)
            {
                MessageBox.Show(
                    "Please select a loan to return.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow row = dgvLoans.CurrentRow;

            int loanID = Convert.ToInt32(row.Cells["LoanID"].Value);
            int copyID = Convert.ToInt32(row.Cells["CopyID"].Value);

            if (row.Cells["ReturnDate"].Value != null &&
                row.Cells["ReturnDate"].Value != DBNull.Value)
            {
                MessageBox.Show(
                    "This book has already been returned.",
                    "Already Returned",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure you want to return this book?",
                "Confirm Return",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlTransaction transaction =
                        connection.BeginTransaction();

                    try
                    {
                        // Set ReturnDate
                        string returnLoanQuery = @"
                            UPDATE Loan
                            SET ReturnDate = @ReturnDate
                            WHERE LoanID = @LoanID";

                        using (SqlCommand command =
                            new SqlCommand(returnLoanQuery, connection, transaction))
                        {
                            command.Parameters.AddWithValue(
                                "@ReturnDate",
                                DateTime.Today);

                            command.Parameters.AddWithValue(
                                "@LoanID",
                                loanID);

                            command.ExecuteNonQuery();
                        }

                        // Make the physical copy available again
                        string updateCopyQuery = @"
                            UPDATE BookCopy
                            SET Status = 'Available'
                            WHERE CopyID = @CopyID";

                        using (SqlCommand command =
                            new SqlCommand(updateCopyQuery, connection, transaction))
                        {
                            command.Parameters.AddWithValue(
                                "@CopyID",
                                copyID);

                            command.ExecuteNonQuery();
                        }

                        transaction.Commit();

                        MessageBox.Show(
                            "Book returned successfully.",
                            "Success",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                        LoadLoans();
                        LoadBookCopies();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error returning book: " + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}