namespace Laundry_Management_System
{
    partial class AdminDashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblAdminName = new System.Windows.Forms.Label();
            this.btnLogout = new Guna.UI2.WinForms.Guna2Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvRecentOrders = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblTotalOrders = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblTotalUsers = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lblTotalServices = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnManageOrders = new Guna.UI2.WinForms.Guna2Button();
            this.btnManageUsers = new Guna.UI2.WinForms.Guna2Button();
            this.btnManageServices = new Guna.UI2.WinForms.Guna2Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecentOrders)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkCyan;
            this.panel1.Controls.Add(this.lblAdminName);
            this.panel1.Controls.Add(this.btnLogout);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1000, 50);
            this.panel1.TabIndex = 0;
            // 
            // lblAdminName
            // 
            this.lblAdminName.AutoSize = true;
            this.lblAdminName.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdminName.ForeColor = System.Drawing.Color.White;
            this.lblAdminName.Location = new System.Drawing.Point(12, 9);
            this.lblAdminName.Name = "lblAdminName";
            this.lblAdminName.Size = new System.Drawing.Size(0, 25);
            this.lblAdminName.TabIndex = 1;
            // 
            // btnLogout
            // 
            this.btnLogout.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLogout.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLogout.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLogout.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLogout.FillColor = System.Drawing.Color.Crimson;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(900, 9);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(88, 32);
            this.btnLogout.TabIndex = 0;
            this.btnLogout.Text = "Logout";
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.dgvRecentOrders);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.btnManageOrders);
            this.panel2.Controls.Add(this.btnManageUsers);
            this.panel2.Controls.Add(this.btnManageServices);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 50);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1000, 550);
            this.panel2.TabIndex = 1;
            // 
            // dgvRecentOrders
            // 
            this.dgvRecentOrders.AllowUserToAddRows = false;
            this.dgvRecentOrders.AllowUserToDeleteRows = false;
            this.dgvRecentOrders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRecentOrders.BackgroundColor = System.Drawing.Color.White;
            this.dgvRecentOrders.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvRecentOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRecentOrders.Location = new System.Drawing.Point(12, 300);
            this.dgvRecentOrders.Name = "dgvRecentOrders";
            this.dgvRecentOrders.ReadOnly = true;
            this.dgvRecentOrders.Size = new System.Drawing.Size(976, 238);
            this.dgvRecentOrders.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 275);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 21);
            this.label4.TabIndex = 6;
            this.label4.Text = "Recent Orders";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.panel3.Controls.Add(this.lblTotalOrders);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Location = new System.Drawing.Point(12, 200);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(300, 100);
            this.panel3.TabIndex = 5;
            // 
            // lblTotalOrders
            // 
            this.lblTotalOrders.AutoSize = true;
            this.lblTotalOrders.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalOrders.ForeColor = System.Drawing.Color.White;
            this.lblTotalOrders.Location = new System.Drawing.Point(12, 40);
            this.lblTotalOrders.Name = "lblTotalOrders";
            this.lblTotalOrders.Size = new System.Drawing.Size(37, 45);
            this.lblTotalOrders.TabIndex = 1;
            this.lblTotalOrders.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 21);
            this.label3.TabIndex = 0;
            this.label3.Text = "Total Orders";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.panel4.Controls.Add(this.lblTotalUsers);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Location = new System.Drawing.Point(350, 200);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(300, 100);
            this.panel4.TabIndex = 4;
            // 
            // lblTotalUsers
            // 
            this.lblTotalUsers.AutoSize = true;
            this.lblTotalUsers.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalUsers.ForeColor = System.Drawing.Color.White;
            this.lblTotalUsers.Location = new System.Drawing.Point(12, 40);
            this.lblTotalUsers.Name = "lblTotalUsers";
            this.lblTotalUsers.Size = new System.Drawing.Size(37, 45);
            this.lblTotalUsers.TabIndex = 1;
            this.lblTotalUsers.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 21);
            this.label2.TabIndex = 0;
            this.label2.Text = "Total Users";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.panel5.Controls.Add(this.lblTotalServices);
            this.panel5.Controls.Add(this.label1);
            this.panel5.Location = new System.Drawing.Point(688, 200);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(300, 100);
            this.panel5.TabIndex = 3;
            // 
            // lblTotalServices
            // 
            this.lblTotalServices.AutoSize = true;
            this.lblTotalServices.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalServices.ForeColor = System.Drawing.Color.White;
            this.lblTotalServices.Location = new System.Drawing.Point(12, 40);
            this.lblTotalServices.Name = "lblTotalServices";
            this.lblTotalServices.Size = new System.Drawing.Size(37, 45);
            this.lblTotalServices.TabIndex = 1;
            this.lblTotalServices.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Total Services";
            // 
            // btnManageOrders
            // 
            this.btnManageOrders.BorderRadius = 5;
            this.btnManageOrders.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnManageOrders.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnManageOrders.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnManageOrders.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnManageOrders.FillColor = System.Drawing.Color.DarkCyan;
            this.btnManageOrders.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnManageOrders.ForeColor = System.Drawing.Color.White;
            this.btnManageOrders.Location = new System.Drawing.Point(350, 100);
            this.btnManageOrders.Name = "btnManageOrders";
            this.btnManageOrders.Size = new System.Drawing.Size(300, 45);
            this.btnManageOrders.TabIndex = 2;
            this.btnManageOrders.Text = "Manage Orders";
            this.btnManageOrders.Click += new System.EventHandler(this.btnManageOrders_Click);
            // 
            // btnManageUsers
            // 
            this.btnManageUsers.BorderRadius = 5;
            this.btnManageUsers.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnManageUsers.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnManageUsers.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnManageUsers.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnManageUsers.FillColor = System.Drawing.Color.DarkCyan;
            this.btnManageUsers.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnManageUsers.ForeColor = System.Drawing.Color.White;
            this.btnManageUsers.Location = new System.Drawing.Point(688, 100);
            this.btnManageUsers.Name = "btnManageUsers";
            this.btnManageUsers.Size = new System.Drawing.Size(300, 45);
            this.btnManageUsers.TabIndex = 1;
            this.btnManageUsers.Text = "Manage Users";
            this.btnManageUsers.Click += new System.EventHandler(this.btnManageUsers_Click);
            // 
            // btnManageServices
            // 
            this.btnManageServices.BorderRadius = 5;
            this.btnManageServices.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnManageServices.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnManageServices.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(141)))));
            this.btnManageServices.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnManageServices.FillColor = System.Drawing.Color.DarkCyan;
            this.btnManageServices.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnManageServices.ForeColor = System.Drawing.Color.White;
            this.btnManageServices.Location = new System.Drawing.Point(12, 100);
            this.btnManageServices.Name = "btnManageServices";
            this.btnManageServices.Size = new System.Drawing.Size(300, 45);
            this.btnManageServices.TabIndex = 0;
            this.btnManageServices.Text = "Manage Services";
            this.btnManageServices.Click += new System.EventHandler(this.btnManageServices_Click);
            // 
            // AdminDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AdminDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin Dashboard";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecentOrders)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblAdminName;
        private Guna.UI2.WinForms.Guna2Button btnLogout;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvRecentOrders;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblTotalOrders;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lblTotalUsers;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label lblTotalServices;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Button btnManageOrders;
        private Guna.UI2.WinForms.Guna2Button btnManageUsers;
        private Guna.UI2.WinForms.Guna2Button btnManageServices;
    }
} 