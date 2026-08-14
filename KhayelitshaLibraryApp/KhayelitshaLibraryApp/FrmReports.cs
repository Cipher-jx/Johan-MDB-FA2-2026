using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

namespace KhayelitshaLibraryApp
{
    public partial class FrmReports : Form
    {
        private readonly string connectionString =
            @"Server=.;Database=KhayelitshaLibraryDB;Trusted_Connection=True;TrustServerCertificate=True;";

        public FrmReports()
        {
            InitializeComponent();

            btnOverdueLoans.Click += btnOverdueLoans_Click;
            btnLoansPerMember.Click += btnLoansPerMember_Click;
            btnAllLoans.Click += btnAllLoans_Click;
        }

        private void btnOverdueLoans_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection =
                    new SqlConnection(connectionString))
                {
                    string query = @"
                        SELECT
                            l.LoanID,
                            m.FullName AS Member,
                            bt.Title AS BookTitle,
                            l.LoanDate,
                            l.DueDate,
                            DATEDIFF(DAY, l.DueDate, CAST(GETDATE() AS DATE))
                                AS DaysOverdue
                        FROM Loan l
                        INNER JOIN Member m
                            ON l.MemberID = m.MemberID
                        INNER JOIN BookCopy bc
                            ON l.CopyID = bc.CopyID
                        INNER JOIN BookTitle bt
                            ON bc.BookTitleID = bt.BookTitleID
                        WHERE l.ReturnDate IS NULL
                          AND l.DueDate < CAST(GETDATE() AS DATE)
                        ORDER BY l.DueDate ASC";

                    SqlDataAdapter adapter =
                        new SqlDataAdapter(query, connection);

                    DataTable table = new DataTable();

                    adapter.Fill(table);

                    dgvReports.DataSource = table;

                    FormatGrid();

                    if (table.Rows.Count == 0)
                    {
                        MessageBox.Show(
                            "There are currently no overdue loans.",
                            "Overdue Loans",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error loading overdue loans: " + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnLoansPerMember_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection =
                    new SqlConnection(connectionString))
                {
                    string query = @"
                        SELECT
                            m.MemberID,
                            m.FullName AS Member,
                            COUNT(l.LoanID) AS TotalLoans
                        FROM Member m
                        LEFT JOIN Loan l
                            ON m.MemberID = l.MemberID
                        GROUP BY
                            m.MemberID,
                            m.FullName
                        ORDER BY TotalLoans DESC, m.FullName ASC";

                    SqlDataAdapter adapter =
                        new SqlDataAdapter(query, connection);

                    DataTable table = new DataTable();

                    adapter.Fill(table);

                    dgvReports.DataSource = table;

                    FormatGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error loading loans per member: " + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnAllLoans_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection =
                    new SqlConnection(connectionString))
                {
                    string query = @"
                        SELECT
                            l.LoanID,
                            m.FullName AS Member,
                            bt.Title AS BookTitle,
                            s.FullName AS Staff,
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
                        ORDER BY l.LoanDate DESC";

                    SqlDataAdapter adapter =
                        new SqlDataAdapter(query, connection);

                    DataTable table = new DataTable();

                    adapter.Fill(table);

                    dgvReports.DataSource = table;

                    FormatGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error loading all loans: " + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void FormatGrid()
        {
            dgvReports.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvReports.AutoSizeRowsMode =
                DataGridViewAutoSizeRowsMode.AllCells;

            dgvReports.ReadOnly = true;

            dgvReports.AllowUserToAddRows = false;

            dgvReports.AllowUserToDeleteRows = false;

            dgvReports.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvReports.MultiSelect = false;
        }
    }
}