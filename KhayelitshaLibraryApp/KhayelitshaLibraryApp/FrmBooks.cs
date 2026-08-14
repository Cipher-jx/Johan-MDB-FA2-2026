using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace KhayelitshaLibraryApp
{
    public partial class FrmBooks : Form
    {
        public FrmBooks()
        {
            InitializeComponent();
            LoadBookTitles();
            LoadBookCopies();
        }

        private void LoadBookTitles()
        {
            try
            {
                using (SqlConnection connection = DatabaseConnection.GetConnection())
                {
                    string query = "SELECT BookTitleID, Title, Author FROM BookTitle";

                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        DataTable table = new DataTable();
                        adapter.Fill(table);

                        dgvBookTitles.DataSource = table;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error loading book titles:\n\n" + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void LoadBookCopies()
        {
            try
            {
                using (SqlConnection connection = DatabaseConnection.GetConnection())
                {
                    string query = @"
                        SELECT 
                            bc.CopyID,
                            bc.BookTitleID,
                            bt.Title,
                            bc.Status
                        FROM BookCopy bc
                        INNER JOIN BookTitle bt
                            ON bc.BookTitleID = bt.BookTitleID";

                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        DataTable table = new DataTable();
                        adapter.Fill(table);

                        dgvBookCopies.DataSource = table;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error loading book copies:\n\n" + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // Add a Book Title
                if (!string.IsNullOrWhiteSpace(txtTitle.Text) &&
                    !string.IsNullOrWhiteSpace(txtAuthor.Text))
                {
                    using (SqlConnection connection = DatabaseConnection.GetConnection())
                    {
                        string query = @"
                            INSERT INTO BookTitle (Title, Author)
                            VALUES (@Title, @Author)";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@Title", txtTitle.Text.Trim());
                            command.Parameters.AddWithValue("@Author", txtAuthor.Text.Trim());

                            connection.Open();
                            command.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show(
                        "Book title added successfully!",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    LoadBookTitles();
                    ClearFields();

                    return;
                }

                // Add a Book Copy
                if (!string.IsNullOrWhiteSpace(txtCopyID.Text) &&
                    cmbBookTitle.SelectedValue != null &&
                    !string.IsNullOrWhiteSpace(cmbStatus.Text))
                {
                    using (SqlConnection connection = DatabaseConnection.GetConnection())
                    {
                        string query = @"
                            INSERT INTO BookCopy (CopyID, BookTitleID, Status)
                            VALUES (@CopyID, @BookTitleID, @Status)";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue(
                                "@CopyID",
                                int.Parse(txtCopyID.Text));

                            command.Parameters.AddWithValue(
                                "@BookTitleID",
                                Convert.ToInt32(cmbBookTitle.SelectedValue));

                            command.Parameters.AddWithValue(
                                "@Status",
                                cmbStatus.Text);

                            connection.Open();
                            command.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show(
                        "Book copy added successfully!",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    LoadBookCopies();
                    ClearFields();

                    return;
                }

                MessageBox.Show(
                    "Please enter the required book information.",
                    "Missing Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error adding record:\n\n" + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(txtBookTitleID.Text) &&
                    !string.IsNullOrWhiteSpace(txtTitle.Text) &&
                    !string.IsNullOrWhiteSpace(txtAuthor.Text))
                {
                    using (SqlConnection connection = DatabaseConnection.GetConnection())
                    {
                        string query = @"
                            UPDATE BookTitle
                            SET Title = @Title,
                                Author = @Author
                            WHERE BookTitleID = @BookTitleID";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue(
                                "@BookTitleID",
                                int.Parse(txtBookTitleID.Text));

                            command.Parameters.AddWithValue(
                                "@Title",
                                txtTitle.Text.Trim());

                            command.Parameters.AddWithValue(
                                "@Author",
                                txtAuthor.Text.Trim());

                            connection.Open();
                            command.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show(
                        "Book title updated successfully!",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    LoadBookTitles();
                    ClearFields();

                    return;
                }

                if (!string.IsNullOrWhiteSpace(txtCopyID.Text) &&
                    cmbBookTitle.SelectedValue != null &&
                    !string.IsNullOrWhiteSpace(cmbStatus.Text))
                {
                    using (SqlConnection connection = DatabaseConnection.GetConnection())
                    {
                        string query = @"
                            UPDATE BookCopy
                            SET BookTitleID = @BookTitleID,
                                Status = @Status
                            WHERE CopyID = @CopyID";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue(
                                "@CopyID",
                                int.Parse(txtCopyID.Text));

                            command.Parameters.AddWithValue(
                                "@BookTitleID",
                                Convert.ToInt32(cmbBookTitle.SelectedValue));

                            command.Parameters.AddWithValue(
                                "@Status",
                                cmbStatus.Text);

                            connection.Open();
                            command.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show(
                        "Book copy updated successfully!",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    LoadBookCopies();
                    ClearFields();

                    return;
                }

                MessageBox.Show(
                    "Please select a record to update.",
                    "Update",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error updating record:\n\n" + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(txtCopyID.Text))
                {
                    DialogResult result = MessageBox.Show(
                        "Are you sure you want to delete this book copy?",
                        "Confirm Delete",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (result != DialogResult.Yes)
                        return;

                    using (SqlConnection connection = DatabaseConnection.GetConnection())
                    {
                        string query =
                            "DELETE FROM BookCopy WHERE CopyID = @CopyID";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue(
                                "@CopyID",
                                int.Parse(txtCopyID.Text));

                            connection.Open();
                            command.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show(
                        "Book copy deleted successfully!",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    LoadBookCopies();
                    ClearFields();

                    return;
                }

                if (!string.IsNullOrWhiteSpace(txtBookTitleID.Text))
                {
                    DialogResult result = MessageBox.Show(
                        "Are you sure you want to delete this book title?",
                        "Confirm Delete",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (result != DialogResult.Yes)
                        return;

                    using (SqlConnection connection = DatabaseConnection.GetConnection())
                    {
                        string query =
                            "DELETE FROM BookTitle WHERE BookTitleID = @BookTitleID";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue(
                                "@BookTitleID",
                                int.Parse(txtBookTitleID.Text));

                            connection.Open();
                            command.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show(
                        "Book title deleted successfully!",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    LoadBookTitles();
                    ClearFields();

                    return;
                }

                MessageBox.Show(
                    "Please select a record to delete.",
                    "Delete",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error deleting record:\n\n" + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            txtBookTitleID.Clear();
            txtTitle.Clear();
            txtAuthor.Clear();
            txtCopyID.Clear();

            cmbBookTitle.SelectedIndex = -1;
            cmbStatus.SelectedIndex = -1;

            dgvBookTitles.ClearSelection();
            dgvBookCopies.ClearSelection();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string searchText = txtTitle.Text.Trim();

                using (SqlConnection connection = DatabaseConnection.GetConnection())
                {
                    string query = @"
                        SELECT BookTitleID, Title, Author
                        FROM BookTitle
                        WHERE Title LIKE @Search
                           OR Author LIKE @Search";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue(
                            "@Search",
                            "%" + searchText + "%");

                        using (SqlDataAdapter adapter =
                               new SqlDataAdapter(command))
                        {
                            DataTable table = new DataTable();
                            adapter.Fill(table);

                            dgvBookTitles.DataSource = table;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error searching books:\n\n" + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void dgvBookTitles_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvBookTitles.Rows[e.RowIndex];

                txtBookTitleID.Text =
                    row.Cells["BookTitleID"].Value?.ToString();

                txtTitle.Text =
                    row.Cells["Title"].Value?.ToString();

                txtAuthor.Text =
                    row.Cells["Author"].Value?.ToString();
            }
        }

        private void dgvBookCopies_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvBookCopies.Rows[e.RowIndex];

                txtCopyID.Text =
                    row.Cells["CopyID"].Value?.ToString();

                if (row.Cells["BookTitleID"].Value != null)
                {
                    cmbBookTitle.SelectedValue =
                        row.Cells["BookTitleID"].Value;
                }

                cmbStatus.Text =
                    row.Cells["Status"].Value?.ToString();
            }
        }
    }
}