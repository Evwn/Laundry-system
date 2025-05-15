using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Laundry_Management_System
{
    public partial class AdminDashboard : Form
    {
        private string connectionString = "Server=localhost;Database=laundry;Uid=root;Pwd=;";
        private string adminUsername;

        public AdminDashboard(string username)
        {
            InitializeComponent();
            adminUsername = username;
            lblAdminName.Text = $"Welcome, {adminUsername}";
            LoadDashboardData();
        }

        private void LoadDashboardData()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    // Load total services
                    using (MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM services", conn))
                    {
                        object result = cmd.ExecuteScalar();
                        lblTotalServices.Text = result != null ? result.ToString() : "0";
                    }

                    // Load total users (excluding admin)
                    using (MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM users WHERE role = 'client'", conn))
                    {
                        object result = cmd.ExecuteScalar();
                        lblTotalUsers.Text = result != null ? result.ToString() : "0";
                    }

                    // Load total orders
                    using (MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM orders", conn))
                    {
                        object result = cmd.ExecuteScalar();
                        lblTotalOrders.Text = result != null ? result.ToString() : "0";
                    }

                    // Load recent orders
                    using (MySqlCommand cmd = new MySqlCommand(@"
                        SELECT o.order_id, u.username, s.service_name, o.order_date, 
                        o.status, o.total_amount, o.pickup_date, o.delivery_date
                        FROM orders o
                        JOIN users u ON o.user_id = u.id
                        JOIN services s ON o.service_id = s.service_id
                        ORDER BY o.order_date DESC
                        LIMIT 10", conn))
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            dgvRecentOrders.DataSource = dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading dashboard data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnManageServices_Click(object sender, EventArgs e)
        {
            try
            {
                using (ManageServicesForm manageServicesForm = new ManageServicesForm())
                {
                    manageServicesForm.ShowDialog();
                    LoadDashboardData(); // Refresh data after closing the form
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening Manage Services form: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnManageOrders_Click(object sender, EventArgs e)
        {
            try
            {
                using (ManageOrdersForm manageOrdersForm = new ManageOrdersForm())
                {
                    manageOrdersForm.ShowDialog();
                    LoadDashboardData(); // Refresh data after closing the form
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening Manage Orders form: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnManageUsers_Click(object sender, EventArgs e)
        {
            try
            {
                using (ManageUsersForm manageUsersForm = new ManageUsersForm())
                {
                    manageUsersForm.ShowDialog();
                    LoadDashboardData(); // Refresh data after closing the form
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening Manage Users form: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to logout?", "Confirm Logout", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Hide();
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
            }
        }

        private void AdminDashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (MessageBox.Show("Are you sure you want to exit?", "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    e.Cancel = true;
                }
                else
                {
                    Application.Exit();
                }
            }
        }
    }
} 