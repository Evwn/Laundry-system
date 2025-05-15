namespace Laundry_Management_System
{
    partial class DashBoard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DashBoard));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnsched = new Guna.UI2.WinForms.Guna2Button();
            this.btnservice = new Guna.UI2.WinForms.Guna2Button();
            this.btnDashboard = new Guna.UI2.WinForms.Guna2Button();
            this.btnCustomer = new Guna.UI2.WinForms.Guna2Button();
            this.btnhome1 = new Bunifu.UI.WinForms.BunifuImageButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbltime = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.bunifuImageButton6 = new Bunifu.UI.WinForms.BunifuImageButton();
            this.bunifuImageButton4 = new Bunifu.UI.WinForms.BunifuImageButton();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.mainpanel = new System.Windows.Forms.Panel();
            this.btnlogout = new Guna.UI2.WinForms.Guna2Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Teal;
            this.panel1.Controls.Add(this.btnlogout);
            this.panel1.Controls.Add(this.btnsched);
            this.panel1.Controls.Add(this.btnservice);
            this.panel1.Controls.Add(this.btnDashboard);
            this.panel1.Controls.Add(this.btnCustomer);
            this.panel1.Controls.Add(this.btnhome1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(215, 666);
            this.panel1.TabIndex = 0;
            // 
            // btnsched
            // 
            this.btnsched.Animated = true;
            this.btnsched.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btnsched.BorderColor = System.Drawing.Color.White;
            this.btnsched.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnsched.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnsched.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnsched.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnsched.FillColor = System.Drawing.Color.Teal;
            this.btnsched.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnsched.ForeColor = System.Drawing.Color.White;
            this.btnsched.HoverState.BorderColor = System.Drawing.Color.PaleTurquoise;
            this.btnsched.HoverState.FillColor = System.Drawing.Color.PaleTurquoise;
            this.btnsched.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnsched.HoverState.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image1")));
            this.btnsched.Image = ((System.Drawing.Image)(resources.GetObject("btnsched.Image")));
            this.btnsched.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnsched.ImageOffset = new System.Drawing.Point(-4, 0);
            this.btnsched.ImageSize = new System.Drawing.Size(25, 25);
            this.btnsched.Location = new System.Drawing.Point(14, 335);
            this.btnsched.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnsched.Name = "btnsched";
            this.btnsched.Size = new System.Drawing.Size(194, 58);
            this.btnsched.TabIndex = 17;
            this.btnsched.Text = "Reports";
            this.btnsched.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnsched.TextOffset = new System.Drawing.Point(-5, 0);
            this.btnsched.Click += new System.EventHandler(this.btnsched_Click);
            // 
            // btnservice
            // 
            this.btnservice.Animated = true;
            this.btnservice.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btnservice.BorderColor = System.Drawing.Color.White;
            this.btnservice.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnservice.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnservice.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnservice.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnservice.FillColor = System.Drawing.Color.Teal;
            this.btnservice.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnservice.ForeColor = System.Drawing.Color.White;
            this.btnservice.HoverState.BorderColor = System.Drawing.Color.PaleTurquoise;
            this.btnservice.HoverState.FillColor = System.Drawing.Color.PaleTurquoise;
            this.btnservice.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnservice.HoverState.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image2")));
            this.btnservice.Image = ((System.Drawing.Image)(resources.GetObject("btnservice.Image")));
            this.btnservice.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnservice.ImageOffset = new System.Drawing.Point(1, 0);
            this.btnservice.Location = new System.Drawing.Point(6, 266);
            this.btnservice.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnservice.Name = "btnservice";
            this.btnservice.Size = new System.Drawing.Size(194, 58);
            this.btnservice.TabIndex = 17;
            this.btnservice.Text = "Service Management";
            this.btnservice.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnservice.TextOffset = new System.Drawing.Point(1, 0);
            this.btnservice.Click += new System.EventHandler(this.btnservice_Click);
            // 
            // btnDashboard
            // 
            this.btnDashboard.Animated = true;
            this.btnDashboard.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btnDashboard.BorderColor = System.Drawing.Color.White;
            this.btnDashboard.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDashboard.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDashboard.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDashboard.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDashboard.FillColor = System.Drawing.Color.Teal;
            this.btnDashboard.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnDashboard.ForeColor = System.Drawing.Color.White;
            this.btnDashboard.HoverState.BorderColor = System.Drawing.Color.PaleTurquoise;
            this.btnDashboard.HoverState.FillColor = System.Drawing.Color.PaleTurquoise;
            this.btnDashboard.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnDashboard.HoverState.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image3")));
            this.btnDashboard.Image = ((System.Drawing.Image)(resources.GetObject("btnDashboard.Image")));
            this.btnDashboard.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnDashboard.ImageOffset = new System.Drawing.Point(1, 0);
            this.btnDashboard.Location = new System.Drawing.Point(10, 139);
            this.btnDashboard.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Size = new System.Drawing.Size(194, 58);
            this.btnDashboard.TabIndex = 17;
            this.btnDashboard.Text = "DashBoard";
            this.btnDashboard.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnDashboard.TextOffset = new System.Drawing.Point(1, 0);
            this.btnDashboard.Click += new System.EventHandler(this.dashbord_Click);
            // 
            // btnCustomer
            // 
            this.btnCustomer.Animated = true;
            this.btnCustomer.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btnCustomer.BorderColor = System.Drawing.Color.White;
            this.btnCustomer.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCustomer.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCustomer.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCustomer.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCustomer.FillColor = System.Drawing.Color.Teal;
            this.btnCustomer.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnCustomer.ForeColor = System.Drawing.Color.White;
            this.btnCustomer.HoverState.BorderColor = System.Drawing.Color.PaleTurquoise;
            this.btnCustomer.HoverState.FillColor = System.Drawing.Color.PaleTurquoise;
            this.btnCustomer.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnCustomer.HoverState.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image4")));
            this.btnCustomer.Image = ((System.Drawing.Image)(resources.GetObject("btnCustomer.Image")));
            this.btnCustomer.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnCustomer.ImageOffset = new System.Drawing.Point(1, 0);
            this.btnCustomer.Location = new System.Drawing.Point(6, 201);
            this.btnCustomer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCustomer.Name = "btnCustomer";
            this.btnCustomer.Size = new System.Drawing.Size(194, 58);
            this.btnCustomer.TabIndex = 17;
            this.btnCustomer.Text = "Customer Directory";
            this.btnCustomer.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnCustomer.TextOffset = new System.Drawing.Point(1, 0);
            this.btnCustomer.Click += new System.EventHandler(this.btnCustomer_Click);
            // 
            // btnhome1
            // 
            this.btnhome1.ActiveImage = null;
            this.btnhome1.AllowAnimations = true;
            this.btnhome1.AllowBuffering = false;
            this.btnhome1.AllowToggling = false;
            this.btnhome1.AllowZooming = true;
            this.btnhome1.AllowZoomingOnFocus = false;
            this.btnhome1.BackColor = System.Drawing.Color.Teal;
            this.btnhome1.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnhome1.ErrorImage = ((System.Drawing.Image)(resources.GetObject("btnhome1.ErrorImage")));
            this.btnhome1.FadeWhenInactive = false;
            this.btnhome1.Flip = Bunifu.UI.WinForms.BunifuImageButton.FlipOrientation.Normal;
            this.btnhome1.Image = ((System.Drawing.Image)(resources.GetObject("btnhome1.Image")));
            this.btnhome1.ImageActive = null;
            this.btnhome1.ImageLocation = null;
            this.btnhome1.ImageMargin = 5;
            this.btnhome1.ImageSize = new System.Drawing.Size(200, 181);
            this.btnhome1.ImageZoomSize = new System.Drawing.Size(205, 186);
            this.btnhome1.InitialImage = ((System.Drawing.Image)(resources.GetObject("btnhome1.InitialImage")));
            this.btnhome1.Location = new System.Drawing.Point(-2, -22);
            this.btnhome1.Name = "btnhome1";
            this.btnhome1.Rotation = 0;
            this.btnhome1.ShowActiveImage = true;
            this.btnhome1.ShowCursorChanges = true;
            this.btnhome1.ShowImageBorders = true;
            this.btnhome1.ShowSizeMarkers = false;
            this.btnhome1.Size = new System.Drawing.Size(205, 186);
            this.btnhome1.TabIndex = 4;
            this.btnhome1.ToolTipText = "";
            this.btnhome1.WaitOnLoad = false;
            this.btnhome1.Zoom = 5;
            this.btnhome1.ZoomSpeed = 10;
            this.btnhome1.Click += new System.EventHandler(this.btnhome1_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DarkCyan;
            this.panel2.Controls.Add(this.lbltime);
            this.panel2.Controls.Add(this.label18);
            this.panel2.Controls.Add(this.bunifuImageButton6);
            this.panel2.Controls.Add(this.bunifuImageButton4);
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(215, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1053, 100);
            this.panel2.TabIndex = 1;
            // 
            // lbltime
            // 
            this.lbltime.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbltime.AutoSize = true;
            this.lbltime.BackColor = System.Drawing.Color.Transparent;
            this.lbltime.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltime.ForeColor = System.Drawing.Color.White;
            this.lbltime.Location = new System.Drawing.Point(3, 63);
            this.lbltime.Name = "lbltime";
            this.lbltime.Size = new System.Drawing.Size(171, 32);
            this.lbltime.TabIndex = 4;
            this.lbltime.Text = "12:00:00 am";
            // 
            // label18
            // 
            this.label18.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.Transparent;
            this.label18.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.White;
            this.label18.Location = new System.Drawing.Point(424, 23);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(255, 19);
            this.label18.TabIndex = 3;
            this.label18.Text = "LAUNDRY MANAGEMENT SYSTEM";
            // 
            // bunifuImageButton6
            // 
            this.bunifuImageButton6.ActiveImage = null;
            this.bunifuImageButton6.AllowAnimations = true;
            this.bunifuImageButton6.AllowBuffering = false;
            this.bunifuImageButton6.AllowToggling = false;
            this.bunifuImageButton6.AllowZooming = true;
            this.bunifuImageButton6.AllowZoomingOnFocus = false;
            this.bunifuImageButton6.BackColor = System.Drawing.Color.Transparent;
            this.bunifuImageButton6.DialogResult = System.Windows.Forms.DialogResult.None;
            this.bunifuImageButton6.ErrorImage = ((System.Drawing.Image)(resources.GetObject("bunifuImageButton6.ErrorImage")));
            this.bunifuImageButton6.FadeWhenInactive = false;
            this.bunifuImageButton6.Flip = Bunifu.UI.WinForms.BunifuImageButton.FlipOrientation.Normal;
            this.bunifuImageButton6.Image = ((System.Drawing.Image)(resources.GetObject("bunifuImageButton6.Image")));
            this.bunifuImageButton6.ImageActive = null;
            this.bunifuImageButton6.ImageLocation = null;
            this.bunifuImageButton6.ImageMargin = 10;
            this.bunifuImageButton6.ImageSize = new System.Drawing.Size(31, 29);
            this.bunifuImageButton6.ImageZoomSize = new System.Drawing.Size(41, 39);
            this.bunifuImageButton6.InitialImage = ((System.Drawing.Image)(resources.GetObject("bunifuImageButton6.InitialImage")));
            this.bunifuImageButton6.Location = new System.Drawing.Point(966, 3);
            this.bunifuImageButton6.Name = "bunifuImageButton6";
            this.bunifuImageButton6.Rotation = 0;
            this.bunifuImageButton6.ShowActiveImage = true;
            this.bunifuImageButton6.ShowCursorChanges = true;
            this.bunifuImageButton6.ShowImageBorders = true;
            this.bunifuImageButton6.ShowSizeMarkers = false;
            this.bunifuImageButton6.Size = new System.Drawing.Size(41, 39);
            this.bunifuImageButton6.TabIndex = 1;
            this.bunifuImageButton6.ToolTipText = "";
            this.bunifuImageButton6.WaitOnLoad = false;
            this.bunifuImageButton6.Zoom = 10;
            this.bunifuImageButton6.ZoomSpeed = 10;
            this.bunifuImageButton6.Click += new System.EventHandler(this.bunifuImageButton6_Click);
            // 
            // bunifuImageButton4
            // 
            this.bunifuImageButton4.ActiveImage = null;
            this.bunifuImageButton4.AllowAnimations = true;
            this.bunifuImageButton4.AllowBuffering = false;
            this.bunifuImageButton4.AllowToggling = false;
            this.bunifuImageButton4.AllowZooming = true;
            this.bunifuImageButton4.AllowZoomingOnFocus = false;
            this.bunifuImageButton4.BackColor = System.Drawing.Color.Transparent;
            this.bunifuImageButton4.DialogResult = System.Windows.Forms.DialogResult.None;
            this.bunifuImageButton4.ErrorImage = ((System.Drawing.Image)(resources.GetObject("bunifuImageButton4.ErrorImage")));
            this.bunifuImageButton4.FadeWhenInactive = false;
            this.bunifuImageButton4.Flip = Bunifu.UI.WinForms.BunifuImageButton.FlipOrientation.Normal;
            this.bunifuImageButton4.Image = ((System.Drawing.Image)(resources.GetObject("bunifuImageButton4.Image")));
            this.bunifuImageButton4.ImageActive = null;
            this.bunifuImageButton4.ImageLocation = null;
            this.bunifuImageButton4.ImageMargin = 10;
            this.bunifuImageButton4.ImageSize = new System.Drawing.Size(31, 29);
            this.bunifuImageButton4.ImageZoomSize = new System.Drawing.Size(41, 39);
            this.bunifuImageButton4.InitialImage = ((System.Drawing.Image)(resources.GetObject("bunifuImageButton4.InitialImage")));
            this.bunifuImageButton4.Location = new System.Drawing.Point(1009, 3);
            this.bunifuImageButton4.Name = "bunifuImageButton4";
            this.bunifuImageButton4.Rotation = 0;
            this.bunifuImageButton4.ShowActiveImage = true;
            this.bunifuImageButton4.ShowCursorChanges = true;
            this.bunifuImageButton4.ShowImageBorders = true;
            this.bunifuImageButton4.ShowSizeMarkers = false;
            this.bunifuImageButton4.Size = new System.Drawing.Size(41, 39);
            this.bunifuImageButton4.TabIndex = 1;
            this.bunifuImageButton4.ToolTipText = "";
            this.bunifuImageButton4.WaitOnLoad = false;
            this.bunifuImageButton4.Zoom = 10;
            this.bunifuImageButton4.ZoomSpeed = 10;
            this.bunifuImageButton4.Click += new System.EventHandler(this.bunifuImageButton4_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(14, 23);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(89, 39);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // mainpanel
            // 
            this.mainpanel.Location = new System.Drawing.Point(215, 101);
            this.mainpanel.Name = "mainpanel";
            this.mainpanel.Size = new System.Drawing.Size(1053, 562);
            this.mainpanel.TabIndex = 4;
            // 
            // btnlogout
            // 
            this.btnlogout.Animated = true;
            this.btnlogout.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btnlogout.BorderColor = System.Drawing.Color.White;
            this.btnlogout.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnlogout.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnlogout.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnlogout.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnlogout.FillColor = System.Drawing.Color.Teal;
            this.btnlogout.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnlogout.ForeColor = System.Drawing.Color.White;
            this.btnlogout.HoverState.BorderColor = System.Drawing.Color.PaleTurquoise;
            this.btnlogout.HoverState.FillColor = System.Drawing.Color.PaleTurquoise;
            this.btnlogout.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnlogout.HoverState.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            this.btnlogout.Image = ((System.Drawing.Image)(resources.GetObject("btnlogout.Image")));
            this.btnlogout.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnlogout.ImageOffset = new System.Drawing.Point(-13, 0);
            this.btnlogout.ImageSize = new System.Drawing.Size(35, 35);
            this.btnlogout.Location = new System.Drawing.Point(16, 399);
            this.btnlogout.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnlogout.Name = "btnlogout";
            this.btnlogout.Size = new System.Drawing.Size(194, 58);
            this.btnlogout.TabIndex = 17;
            this.btnlogout.Text = "Logout";
            this.btnlogout.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnlogout.TextOffset = new System.Drawing.Point(-15, 0);
            this.btnlogout.Click += new System.EventHandler(this.btnlogout_Click);
            // 
            // DashBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1268, 666);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.mainpanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DashBoard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DashBoard";
            this.Load += new System.EventHandler(this.DashBoard_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private Guna.UI2.WinForms.Guna2Button btnCustomer;
        private System.Windows.Forms.PictureBox pictureBox2;
        private Guna.UI2.WinForms.Guna2Button btnservice;
        private System.Windows.Forms.Panel mainpanel;
        private Bunifu.UI.WinForms.BunifuImageButton bunifuImageButton4;
        private Bunifu.UI.WinForms.BunifuImageButton bunifuImageButton6;
        private System.Windows.Forms.Label label18;
        private Guna.UI2.WinForms.Guna2Button btnsched;
        private Guna.UI2.WinForms.Guna2Button btnDashboard;
        private Bunifu.UI.WinForms.BunifuImageButton btnhome1;
        private System.Windows.Forms.Label lbltime;
        private Guna.UI2.WinForms.Guna2Button btnlogout;
    }
}