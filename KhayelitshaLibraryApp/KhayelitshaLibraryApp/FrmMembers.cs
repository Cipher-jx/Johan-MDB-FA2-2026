using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace KhayelitshaLibraryApp
{
    public partial class FrmMembers : Form
    {
        public FrmMembers()
        {
            InitializeComponent();
            LoadMembers();
        }

        private void LoadMembers()
        {
            try
            {
                using (SqlConnection connection = DatabaseConnection.GetConnection())
                {
                    string query = "SELECT MemberID, FullName, Address, Phone, JoinDate FROM Member";

                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        DataTable table = new DataTable();
                        adapter.Fill(table);

                        dgvMembers.DataSource = table;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error loading members:\n\n" + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = DatabaseConnection.GetConnection())
                {
                    string query = @"
                        INSERT INTO Member (FullName, Address, Phone, JoinDate)
                        VALUES (@FullName, @Address, @Phone, @JoinDate)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@FullName", txtFullName.Text);
                        command.Parameters.AddWithValue("@Address", txtAddress.Text);
                        command.Parameters.AddWithValue("@Phone", txtPhone.Text);
                        command.Parameters.AddWithValue("@JoinDate", dtpJoinDate.Value);

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show(
                    "Member added successfully!",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LoadMembers();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error adding member:\n\n" + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void dgvMembers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvMembers.Rows[e.RowIndex];

                txtMemberID.Text = row.Cells["MemberID"].Value?.ToString();
                txtFullName.Text = row.Cells["FullName"].Value?.ToString();
                txtAddress.Text = row.Cells["Address"].Value?.ToString();
                txtPhone.Text = row.Cells["Phone"].Value?.ToString();

                if (row.Cells["JoinDate"].Value != null)
                {
                    dtpJoinDate.Value = Convert.ToDateTime(
                        row.Cells["JoinDate"].Value);
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = DatabaseConnection.GetConnection())
                {
                    string query = @"
                        UPDATE Member
                        SET FullName = @FullName,
                            Address = @Address,
                            Phone = @Phone,
                            JoinDate = @JoinDate
                        WHERE MemberID = @MemberID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue(
                            "@MemberID",
                            int.Parse(txtMemberID.Text));

                        command.Parameters.AddWithValue(
                            "@FullName",
                            txtFullName.Text);

                        command.Parameters.AddWithValue(
                            "@Address",
                            txtAddress.Text);

                        command.Parameters.AddWithValue(
                            "@Phone",
                            txtPhone.Text);

                        command.Parameters.AddWithValue(
                            "@JoinDate",
                            dtpJoinDate.Value);

                        connection.Open();

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show(
                                "Member updated successfully!",
                                "Success",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                            LoadMembers();
                        }
                        else
                        {
                            MessageBox.Show(
                                "Member could not be found.",
                                "Update Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error updating member:\n\n" + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtMemberID.Text))
                {
                    MessageBox.Show(
                        "Please select a member to delete.",
                        "Delete Member",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                DialogResult result = MessageBox.Show(
                    "Are you sure you want to delete this member?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result != DialogResult.Yes)
                {
                    return;
                }

                using (SqlConnection connection = DatabaseConnection.GetConnection())
                {
                    string query = "DELETE FROM Member WHERE MemberID = @MemberID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue(
                            "@MemberID",
                            int.Parse(txtMemberID.Text));

                        connection.Open();

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show(
                                "Member deleted successfully!",
                                "Success",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                            LoadMembers();

                            txtMemberID.Clear();
                            txtFullName.Clear();
                            txtAddress.Clear();
                            txtPhone.Clear();
                            dtpJoinDate.Value = DateTime.Now;
                        }
                        else
                        {
                            MessageBox.Show(
                                "Member could not be found.",
                                "Delete Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error deleting member:\n\n" + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtMemberID.Clear();
            txtFullName.Clear();
            txtAddress.Clear();
            txtPhone.Clear();

            dtpJoinDate.Value = DateTime.Now;

            dgvMembers.ClearSelection();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = DatabaseConnection.GetConnection())
                {
                    string query = @"
                SELECT MemberID, FullName, Address, Phone, JoinDate
                FROM Member
                WHERE FullName LIKE @Search";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue(
                            "@Search",
                            "%" + txtSearch.Text.Trim() + "%");

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable table = new DataTable();
                            adapter.Fill(table);

                            dgvMembers.DataSource = table;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error searching members:\n\n" + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}