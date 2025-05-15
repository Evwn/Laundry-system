using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Laundry_Management_System
{
    public partial class ManageServicesForm : Form
    {
        private readonly string connectionString = "Server=localhost;Database=laundry;Uid=root;Pwd=;";
        private int selectedServiceId = -1;

        public ManageServicesForm()
        {
            InitializeComponent();
            LoadServices();
        }

        private void LoadServices()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT service_id, service_name, description, price FROM services ORDER BY service_name";
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvServices.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading services: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtServiceName.Text) || string.IsNullOrWhiteSpace(txtPrice.Text))
            {
                MessageBox.Show("Please fill in all required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO services (service_name, description, price) VALUES (@name, @desc, @price)";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", txtServiceName.Text);
                        cmd.Parameters.AddWithValue("@desc", txtDescription.Text);
                        cmd.Parameters.AddWithValue("@price", decimal.Parse(txtPrice.Text));
                        cmd.ExecuteNonQuery();
                    }
                }

                ClearFields();
                LoadServices();
                MessageBox.Show("Service added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding service: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedServiceId == -1)
            {
                MessageBox.Show("Please select a service to update.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtServiceName.Text) || string.IsNullOrWhiteSpace(txtPrice.Text))
            {
                MessageBox.Show("Please fill in all required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "UPDATE services SET service_name = @name, description = @desc, price = @price WHERE service_id = @id";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", txtServiceName.Text);
                        cmd.Parameters.AddWithValue("@desc", txtDescription.Text);
                        cmd.Parameters.AddWithValue("@price", decimal.Parse(txtPrice.Text));
                        cmd.Parameters.AddWithValue("@id", selectedServiceId);
                        cmd.ExecuteNonQuery();
                    }
                }

                ClearFields();
                LoadServices();
                MessageBox.Show("Service updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating service: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedServiceId == -1)
            {
                MessageBox.Show("Please select a service to delete.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Are you sure you want to delete this service?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    using (MySqlConnection conn = new MySqlConnection(connectionString))
                    {
                        conn.Open();
                        string query = "DELETE FROM services WHERE service_id = @id";
                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", selectedServiceId);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    ClearFields();
                    LoadServices();
                    MessageBox.Show("Service deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting service: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvServices_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvServices.Rows[e.RowIndex];
                selectedServiceId = Convert.ToInt32(row.Cells["service_id"].Value);
                txtServiceName.Text = row.Cells["service_name"].Value.ToString();
                txtDescription.Text = row.Cells["description"].Value.ToString();
                txtPrice.Text = row.Cells["price"].Value.ToString();
            }
        }

        private void ClearFields()
        {
            selectedServiceId = -1;
            txtServiceName.Clear();
            txtDescription.Clear();
            txtPrice.Clear();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
} 