using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Laundry_Management_System
{
    public partial class ManageOrdersForm : Form
    {
        private readonly string connectionString = "Server=localhost;Database=laundry;Uid=root;Pwd=;";
        private int selectedOrderId = -1;

        public ManageOrdersForm()
        {
            InitializeComponent();
            LoadOrders();
            LoadServices();
        }

        private void LoadOrders()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"SELECT o.order_id, u.username, s.service_name, o.total_amount, 
                                   o.pickup_date, o.delivery_date, o.status
                                   FROM orders o
                                   JOIN users u ON o.user_id = u.id
                                   JOIN services s ON o.service_id = s.service_id
                                   ORDER BY o.pickup_date DESC";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            dgvOrders.DataSource = dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading orders: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadServices()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT service_id, service_name, price FROM services";
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        cmbService.DataSource = dt;
                        cmbService.DisplayMember = "service_name";
                        cmbService.ValueMember = "service_id";
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
            if (ValidateInputs())
            {
                AddOrder();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an order to update.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "UPDATE orders SET status = @status WHERE order_id = @orderId";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        string status = cmbStatus.Text;
                        // Map the display status to database enum values
                        switch (status)
                        {
                            case "Pending":
                                status = "pending";
                                break;
                            case "Processing":
                                status = "processing";
                                break;
                            case "Ready for Pickup":
                                status = "ready";
                                break;
                            case "Completed":
                                status = "completed";
                                break;
                            case "Cancelled":
                                status = "cancelled";
                                break;
                        }

                        cmd.Parameters.AddWithValue("@status", status);
                        cmd.Parameters.AddWithValue("@orderId", dgvOrders.SelectedRows[0].Cells["order_id"].Value);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Order status updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadOrders();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating order: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedOrderId == -1)
            {
                MessageBox.Show("Please select an order to delete.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Are you sure you want to delete this order?", "Confirm Delete", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DeleteOrder();
            }
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("Please enter a username.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cmbService.SelectedValue == null)
            {
                MessageBox.Show("Please select a service.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTotalAmount.Text))
            {
                MessageBox.Show("Please enter the total amount.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!decimal.TryParse(txtTotalAmount.Text, out _))
            {
                MessageBox.Show("Please enter a valid amount.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cmbStatus.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a status.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void AddOrder()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    // Get user ID from username
                    string userQuery = "SELECT id FROM users WHERE username = @username";
                    int userId;
                    using (MySqlCommand userCmd = new MySqlCommand(userQuery, conn))
                    {
                        userCmd.Parameters.AddWithValue("@username", txtUsername.Text);
                        object result = userCmd.ExecuteScalar();
                        if (result == null)
                        {
                            MessageBox.Show("User not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        userId = Convert.ToInt32(result);
                    }

                    string insertQuery = @"INSERT INTO orders (user_id, service_id, order_date, status, 
                                         total_amount, pickup_date, delivery_date) 
                                         VALUES (@userId, @serviceId, @orderDate, @status, 
                                         @totalAmount, @pickupDate, @deliveryDate)";
                    using (MySqlCommand cmd = new MySqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@userId", userId);
                        cmd.Parameters.AddWithValue("@serviceId", cmbService.SelectedValue);
                        cmd.Parameters.AddWithValue("@orderDate", DateTime.Now);
                        cmd.Parameters.AddWithValue("@status", cmbStatus.Text);
                        cmd.Parameters.AddWithValue("@totalAmount", decimal.Parse(txtTotalAmount.Text));
                        cmd.Parameters.AddWithValue("@pickupDate", dtpPickupDate.Value);
                        cmd.Parameters.AddWithValue("@deliveryDate", dtpDeliveryDate.Value);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Order added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearInputs();
                    LoadOrders();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding order: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteOrder()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string deleteQuery = "DELETE FROM orders WHERE order_id = @orderId";
                    using (MySqlCommand cmd = new MySqlCommand(deleteQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@orderId", selectedOrderId);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Order deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearInputs();
                    LoadOrders();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting order: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvOrders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvOrders.Rows[e.RowIndex];
                selectedOrderId = Convert.ToInt32(row.Cells["order_id"].Value);
                txtUsername.Text = row.Cells["username"].Value.ToString();
                cmbService.Text = row.Cells["service_name"].Value.ToString();
                cmbStatus.Text = row.Cells["status"].Value.ToString();
                txtTotalAmount.Text = row.Cells["total_amount"].Value.ToString();
                dtpPickupDate.Value = Convert.ToDateTime(row.Cells["pickup_date"].Value);
                dtpDeliveryDate.Value = Convert.ToDateTime(row.Cells["delivery_date"].Value);
            }
        }

        private void ClearInputs()
        {
            selectedOrderId = -1;
            txtUsername.Clear();
            cmbService.SelectedIndex = -1;
            cmbStatus.SelectedIndex = -1;
            txtTotalAmount.Clear();
            dtpPickupDate.Value = DateTime.Now;
            dtpDeliveryDate.Value = DateTime.Now.AddDays(1);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
} 