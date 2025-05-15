using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Laundry_Management_System
{
    public partial class DashBoard : Form
    {
        public DashBoard()
        {
            InitializeComponent();
            LoadDash();

            Timer timer = new Timer();
            timer.Interval = 1000;  
            timer.Tick += Timer_Tick;
            timer.Start();
        }
        public void LoadDash()
        {
            DashBoardContent d = new DashBoardContent();
            LoadForm(d);
        }
        public void LoadForm(Form form)
        {

            if (this.mainpanel.Controls.Count > 0)
                this.mainpanel.Controls.Clear();


            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            this.mainpanel.Controls.Add(form);
            form.Show();
        }
        private void DashBoard_Load(object sender, EventArgs e)
        {
            DashBoardContent d1 = new DashBoardContent();
            LoadForm(d1);
        }
        

        private void dashbord_Click(object sender, EventArgs e)
        {
            DashBoardContent d1 = new DashBoardContent();
            LoadForm(d1);
        }  
        private void btnCustomer_Click(object sender, EventArgs e)
        {
            CustomerManagement c = new CustomerManagement();
            LoadForm(c);
        }

        private void btnservice_Click(object sender, EventArgs e)
        {
            ServiceManaagement s = new ServiceManaagement();
            LoadForm(s);
        }

        private void btnsched_Click(object sender, EventArgs e)
        {
            Scheduling scheduling = new Scheduling();
            LoadForm(scheduling);
        }

        private void btnhome1_Click(object sender, EventArgs e)
        {
            DashBoardContent d1 = new DashBoardContent();
            LoadForm(d1);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            DashBoardContent d1 = new DashBoardContent();
            LoadForm(d1);
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            // Update the label with the current time
            lbltime.Text = DateTime.Now.ToString("hh:mm:ss tt");  // Format the time (e.g., 12:45:30 PM)
        }

        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuImageButton6_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnlogout_Click(object sender, EventArgs e)
        {
            LoginForm l = new LoginForm();
            l.Show();
            this.Dispose();
        }
    }
}

