using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Laundry_Management_System
{
    public partial class ClientDashboard : Form
    {
        private string userId;
        private string username;
        string connectionString = "server=localhost;port=3306;username=root;password=;database=laundry;";

        public ClientDashboard(string userId, string username)
        {
            InitializeComponent();
            this.userId = userId;
            this.username = username;
            LoadClientInfo();
        }

        private void LoadClientInfo()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM users WHERE id = @userId";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@userId", userId);
                    
                    MySqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        lblUsername.Text = dr["username"].ToString();
                        lblEmail.Text = dr["email"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading client info: " + ex.Message);
            }
        }

        private void btnNewOrder_Click(object sender, EventArgs e)
        {
            using (var orderForm = new ClientOrderForm(userId, username))
            {
                orderForm.ShowDialog();
                LoadOrders(); // Refresh orders after closing the form
            }
        }

        private void LoadOrders()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"SELECT o.order_id, s.service_name, o.order_date, 
                                   o.status, o.total_amount, o.pickup_date, o.delivery_date
                                   FROM orders o
                                   JOIN services s ON o.service_id = s.service_id
                                   WHERE o.user_id = @userId
                                   ORDER BY o.order_date DESC";
                    
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@userId", userId);
                    
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    
                    dgvOrders.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading orders: " + ex.Message);
            }
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            using (var profileForm = new ClientProfileForm(userId, username))
            {
                profileForm.ShowDialog();
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Close();
        }

        private void ClientDashboard_Load(object sender, EventArgs e)
        {
            LoadOrders();
        }
    }
} 