using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;

namespace Laundry_Management_System
{
    public partial class ClientOrderForm : Form
    {
        private readonly string connectionString = "Server=localhost;Database=laundry;Uid=root;Pwd=;";
        private readonly string userId;
        private readonly string username;

        public ClientOrderForm(string userId, string username)
        {
            InitializeComponent();
            this.userId = userId;
            this.username = username;
            LoadServices();
        }

        private void LoadServices()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT service_id, service_name, price FROM services";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            cmbService.DataSource = dt;
                            cmbService.DisplayMember = "service_name";
                            cmbService.ValueMember = "service_id";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading services: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (ValidateInputs())
            {
                SubmitOrder();
            }
        }

        private bool ValidateInputs()
        {
            if (cmbService.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a service.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtQuantity.Text) || !int.TryParse(txtQuantity.Text, out int quantity) || quantity <= 0)
            {
                MessageBox.Show("Please enter a valid quantity.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (dtpPickup.Value.Date < DateTime.Now.Date)
            {
                MessageBox.Show("Pickup date cannot be in the past.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (dtpDelivery.Value.Date <= dtpPickup.Value.Date)
            {
                MessageBox.Show("Delivery date must be after pickup date.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void SubmitOrder()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"INSERT INTO orders (user_id, service_id, total_amount, 
                                   pickup_date, delivery_date, status) 
                                   VALUES (@userId, @serviceId, @totalAmount, 
                                   @pickupDate, @deliveryDate, 'Pending')";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        int serviceId = Convert.ToInt32(cmbService.SelectedValue);
                        int quantity = Convert.ToInt32(txtQuantity.Text);
                        decimal totalAmount = GetServicePrice(serviceId) * quantity;

                        cmd.Parameters.AddWithValue("@userId", userId);
                        cmd.Parameters.AddWithValue("@serviceId", serviceId);
                        cmd.Parameters.AddWithValue("@totalAmount", totalAmount);
                        cmd.Parameters.AddWithValue("@pickupDate", dtpPickup.Value);
                        cmd.Parameters.AddWithValue("@deliveryDate", dtpDelivery.Value);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Order submitted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error submitting order: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private decimal GetServicePrice(int serviceId)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT price FROM services WHERE service_id = @serviceId";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@serviceId", serviceId);
                        return Convert.ToDecimal(cmd.ExecuteScalar());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error getting service price: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
} 