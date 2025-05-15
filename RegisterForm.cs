using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Laundry_Management_System
{
    public partial class RegisterForm : Form
    {
        private readonly string connectionString = "Server=localhost;Database=laundry;Uid=root;Pwd=;";
        private LoginForm loginForm;

        public RegisterForm(LoginForm loginForm)
        {
            InitializeComponent();
            this.loginForm = loginForm;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (ValidateInputs())
            {
                RegisterUser();
            }
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("Please enter a username.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Please enter an email address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!IsValidEmail(txtEmail.Text))
            {
                MessageBox.Show("Please enter a valid email address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Please enter a password.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (txtPassword.Text.Length < 6)
            {
                MessageBox.Show("Password must be at least 6 characters long.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Passwords do not match.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void RegisterUser()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    // Check if username already exists
                    string checkUsernameQuery = "SELECT COUNT(*) FROM users WHERE username = @username";
                    using (MySqlCommand checkCmd = new MySqlCommand(checkUsernameQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@username", txtUsername.Text);
                        int count = Convert.ToInt32(checkCmd.ExecuteScalar());
                        if (count > 0)
                        {
                            MessageBox.Show("Username already exists. Please choose a different username.", "Registration Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // Check if email already exists
                    string checkEmailQuery = "SELECT COUNT(*) FROM users WHERE email = @email";
                    using (MySqlCommand checkCmd = new MySqlCommand(checkEmailQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@email", txtEmail.Text);
                        int count = Convert.ToInt32(checkCmd.ExecuteScalar());
                        if (count > 0)
                        {
                            MessageBox.Show("Email already exists. Please use a different email address.", "Registration Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // Insert new user
                    string insertQuery = @"INSERT INTO users (username, password, email, role, created_at) 
                                         VALUES (@username, @password, @email, 'client', NOW())";
                    using (MySqlCommand cmd = new MySqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                        cmd.Parameters.AddWithValue("@password", txtPassword.Text);
                        cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Registration successful! You can now login.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    loginForm.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during registration: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            loginForm.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
} 