using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Laundry_Management_System
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Password.PasswordChar = '*';
            RoundedPanel roundedPanel = new RoundedPanel
            {
                Size = new Size(200, 200), 
                Location = new Point(50, 50),
                BackColor = Color.LightBlue
            };
            this.Controls.Add(roundedPanel);
        }
        private void btncomplete_Click(object sender, EventArgs e)
        {
            string username = "123";
            string password = "123";

            if (Username.Text == username && Password.Text == password)
            {

                this.Hide();
                DashBoard d = new DashBoard();
                d.Show();
            }
            else
            {
                MessageBox.Show("The username or password is  incorrect.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
          
        }

        private void showpassword_CheckedChanged(object sender, EventArgs e)
        {
            if (showpassword.Checked)
            {
                // Show the password (clear the masking)
                Password.PasswordChar = '\0'; // No masking
            }
            else
            {
                // Hide the password (mask with *)
                Password.PasswordChar = '*'; // Masking character
            }
        }

        private void bntexit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
