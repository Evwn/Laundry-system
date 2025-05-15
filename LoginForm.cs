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
    public partial class LoginForm : Form
    {
        private readonly string connectionString = "Server=localhost;Database=laundry;Uid=root;Pwd=;";
        
        public LoginForm()
        {
            InitializeComponent();
            CreateDatabaseTables();
        }

        private void CreateDatabaseTables()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    // Create users table
                    string createUsersTable = @"
                        CREATE TABLE IF NOT EXISTS users (
                            id INT AUTO_INCREMENT PRIMARY KEY,
                            username VARCHAR(50) NOT NULL UNIQUE,
                            password VARCHAR(255) NOT NULL,
                            email VARCHAR(100) NOT NULL UNIQUE,
                            role ENUM('admin', 'client') NOT NULL DEFAULT 'client',
                            created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
                        )";

                    // Create services table
                    string createServicesTable = @"
                        CREATE TABLE IF NOT EXISTS services (
                            service_id INT AUTO_INCREMENT PRIMARY KEY,
                            service_name VARCHAR(100) NOT NULL,
                            description TEXT,
                            price DECIMAL(10,2) NOT NULL,
                            created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
                        )";

                    // Create orders table
                    string createOrdersTable = @"
                        CREATE TABLE IF NOT EXISTS orders (
                            order_id INT AUTO_INCREMENT PRIMARY KEY,
                            user_id INT NOT NULL,
                            service_id INT NOT NULL,
                            order_date TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
                            status ENUM('Pending', 'Processing', 'Ready for Pickup', 'Completed', 'Cancelled') NOT NULL DEFAULT 'Pending',
                            total_amount DECIMAL(10,2) NOT NULL,
                            pickup_date DATETIME NOT NULL,
                            delivery_date DATETIME NOT NULL,
                            FOREIGN KEY (user_id) REFERENCES users(id),
                            FOREIGN KEY (service_id) REFERENCES services(service_id)
                        )";

                    using (MySqlCommand cmd = new MySqlCommand(createUsersTable, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    using (MySqlCommand cmd = new MySqlCommand(createServicesTable, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    using (MySqlCommand cmd = new MySqlCommand(createOrdersTable, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    // Insert default admin user if not exists
                    string checkAdminQuery = "SELECT COUNT(*) FROM users WHERE username = 'admin'";
                    using (MySqlCommand cmd = new MySqlCommand(checkAdminQuery, conn))
                    {
                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        if (count == 0)
                        {
                            string insertAdminQuery = @"INSERT INTO users (username, password, email, role) 
                                                      VALUES ('admin', 'admin123', 'admin@laundry.com', 'admin')";
                            using (MySqlCommand insertCmd = new MySqlCommand(insertAdminQuery, conn))
                            {
                                insertCmd.ExecuteNonQuery();
                            }
                        }
                    }

                    // Insert sample services if not exists
                    string checkServicesQuery = "SELECT COUNT(*) FROM services";
                    using (MySqlCommand cmd = new MySqlCommand(checkServicesQuery, conn))
                    {
                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        if (count == 0)
                        {
                            string[] services = {
                                "('Wash & Fold', 'Regular laundry service with folding', 5.00)",
                                "('Dry Cleaning', 'Professional dry cleaning service', 10.00)",
                                "('Ironing', 'Professional ironing service', 3.00)",
                                "('Express Service', 'Same day laundry service', 15.00)"
                            };

                            foreach (string service in services)
                            {
                                string insertServiceQuery = $"INSERT INTO services (service_name, description, price) VALUES {service}";
                                using (MySqlCommand insertCmd = new MySqlCommand(insertServiceQuery, conn))
                                {
                                    insertCmd.ExecuteNonQuery();
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating database tables: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            txtUsername.KeyDown += Username_KeyDown;
            txtPassword.KeyDown += Password_KeyDown;
            txtPassword.PasswordChar = '●';
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (ValidateInputs())
            {
                AuthenticateUser();
            }
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("Please enter your username.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Please enter your password.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void AuthenticateUser()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT id, username, role FROM users WHERE username = @username AND password = @password";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                        cmd.Parameters.AddWithValue("@password", txtPassword.Text);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string userId = reader["id"].ToString();
                                string username = reader["username"].ToString();
                                string role = reader["role"].ToString();

                                if (role == "admin")
                                {
                                    AdminDashboard adminDashboard = new AdminDashboard(username);
                                    this.Hide();
                                    adminDashboard.Show();
                                }
                                else
                                {
                                    ClientDashboard clientDashboard = new ClientDashboard(userId, username);
                                    this.Hide();
                                    clientDashboard.Show();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Invalid username or password.", "Authentication Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during authentication: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Username_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPassword.Focus(); // Move focus to password field
            }
        }

        private void Password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(sender, e); // Call the login button click event to perform login
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm(this);
            this.Hide();
            registerForm.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
