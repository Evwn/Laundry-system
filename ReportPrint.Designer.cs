namespace Laundry_Management_System
{
    partial class ReportPrint
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportPrint));
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dataSet1 = new Laundry_Management_System.DataSet1();
            this.dataSet1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataTable3BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataTable1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnprint = new Guna.UI2.WinForms.Guna2Button();
            this.cmbtransaction = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lbltime = new System.Windows.Forms.Label();
            this.radioWeekly = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.radioMonthly = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.bntexit = new Bunifu.UI.WinForms.BunifuImageButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable3BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataTable1BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Laundry_Management_System.Report2.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(28, 87);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1028, 652);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "DataSet1";
            this.dataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataSet1BindingSource
            // 
            this.dataSet1BindingSource.DataSource = this.dataSet1;
            this.dataSet1BindingSource.Position = 0;
            // 
            // dataTable3BindingSource
            // 
            this.dataTable3BindingSource.DataMember = "DataTable3";
            this.dataTable3BindingSource.DataSource = this.dataSet1;
            // 
            // DataTable1BindingSource
            // 
            this.DataTable1BindingSource.DataMember = "DataTable1";
            this.DataTable1BindingSource.DataSource = this.dataSet1;
            // 
            // btnprint
            // 
            this.btnprint.BackColor = System.Drawing.Color.Transparent;
            this.btnprint.BorderRadius = 20;
            this.btnprint.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnprint.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnprint.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnprint.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnprint.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnprint.Font = new System.Drawing.Font("Segoe UI Black", 9F, System.Drawing.FontStyle.Bold);
            this.btnprint.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnprint.Location = new System.Drawing.Point(900, 42);
            this.btnprint.Name = "btnprint";
            this.btnprint.Size = new System.Drawing.Size(161, 39);
            this.btnprint.TabIndex = 13;
            this.btnprint.Text = "PRINT";
            this.btnprint.Click += new System.EventHandler(this.btnprint_Click);
            // 
            // cmbtransaction
            // 
            this.cmbtransaction.BackColor = System.Drawing.Color.Transparent;
            this.cmbtransaction.BorderRadius = 15;
            this.cmbtransaction.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbtransaction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbtransaction.FillColor = System.Drawing.Color.LightSeaGreen;
            this.cmbtransaction.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbtransaction.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbtransaction.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbtransaction.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbtransaction.ItemHeight = 30;
            this.cmbtransaction.Location = new System.Drawing.Point(754, 43);
            this.cmbtransaction.Name = "cmbtransaction";
            this.cmbtransaction.Size = new System.Drawing.Size(140, 36);
            this.cmbtransaction.TabIndex = 14;
            this.cmbtransaction.SelectedIndexChanged += new System.EventHandler(this.cmbtransaction_SelectedIndexChanged);
            // 
            // lbltime
            // 
            this.lbltime.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbltime.AutoSize = true;
            this.lbltime.BackColor = System.Drawing.Color.Transparent;
            this.lbltime.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltime.ForeColor = System.Drawing.Color.Teal;
            this.lbltime.Location = new System.Drawing.Point(540, 49);
            this.lbltime.Name = "lbltime";
            this.lbltime.Size = new System.Drawing.Size(171, 32);
            this.lbltime.TabIndex = 15;
            this.lbltime.Text = "12:00:00 am";
            // 
            // radioWeekly
            // 
            this.radioWeekly.BackColor = System.Drawing.Color.Transparent;
            this.radioWeekly.BorderRadius = 15;
            this.radioWeekly.Checked = true;
            this.radioWeekly.FillColor = System.Drawing.Color.DarkCyan;
            this.radioWeekly.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.radioWeekly.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.radioWeekly.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.radioWeekly.Location = new System.Drawing.Point(28, 43);
            this.radioWeekly.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.radioWeekly.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.radioWeekly.Name = "radioWeekly";
            this.radioWeekly.Size = new System.Drawing.Size(232, 38);
            this.radioWeekly.TabIndex = 16;
            this.radioWeekly.Value = new System.DateTime(2024, 11, 3, 3, 33, 14, 279);
            // 
            // radioMonthly
            // 
            this.radioMonthly.BackColor = System.Drawing.Color.Transparent;
            this.radioMonthly.BorderRadius = 15;
            this.radioMonthly.Checked = true;
            this.radioMonthly.FillColor = System.Drawing.Color.DarkCyan;
            this.radioMonthly.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.radioMonthly.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.radioMonthly.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.radioMonthly.Location = new System.Drawing.Point(271, 43);
            this.radioMonthly.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.radioMonthly.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.radioMonthly.Name = "radioMonthly";
            this.radioMonthly.Size = new System.Drawing.Size(232, 38);
            this.radioMonthly.TabIndex = 16;
            this.radioMonthly.Value = new System.DateTime(2024, 11, 3, 3, 33, 14, 279);
            // 
            // bntexit
            // 
            this.bntexit.ActiveImage = null;
            this.bntexit.AllowAnimations = true;
            this.bntexit.AllowBuffering = false;
            this.bntexit.AllowToggling = false;
            this.bntexit.AllowZooming = true;
            this.bntexit.AllowZoomingOnFocus = false;
            this.bntexit.BackColor = System.Drawing.Color.Transparent;
            this.bntexit.DialogResult = System.Windows.Forms.DialogResult.None;
            this.bntexit.ErrorImage = ((System.Drawing.Image)(resources.GetObject("bntexit.ErrorImage")));
            this.bntexit.FadeWhenInactive = false;
            this.bntexit.Flip = Bunifu.UI.WinForms.BunifuImageButton.FlipOrientation.Normal;
            this.bntexit.Image = ((System.Drawing.Image)(resources.GetObject("bntexit.Image")));
            this.bntexit.ImageActive = null;
            this.bntexit.ImageLocation = null;
            this.bntexit.ImageMargin = 10;
            this.bntexit.ImageSize = new System.Drawing.Size(31, 29);
            this.bntexit.ImageZoomSize = new System.Drawing.Size(41, 39);
            this.bntexit.InitialImage = ((System.Drawing.Image)(resources.GetObject("bntexit.InitialImage")));
            this.bntexit.Location = new System.Drawing.Point(1020, -3);
            this.bntexit.Name = "bntexit";
            this.bntexit.Rotation = 0;
            this.bntexit.ShowActiveImage = true;
            this.bntexit.ShowCursorChanges = true;
            this.bntexit.ShowImageBorders = true;
            this.bntexit.ShowSizeMarkers = false;
            this.bntexit.Size = new System.Drawing.Size(41, 39);
            this.bntexit.TabIndex = 17;
            this.bntexit.ToolTipText = "";
            this.bntexit.WaitOnLoad = false;
            this.bntexit.Zoom = 10;
            this.bntexit.ZoomSpeed = 10;
            this.bntexit.Click += new System.EventHandler(this.bntexit_Click);
            // 
            // ReportPrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1073, 751);
            this.Controls.Add(this.bntexit);
            this.Controls.Add(this.radioMonthly);
            this.Controls.Add(this.radioWeekly);
            this.Controls.Add(this.lbltime);
            this.Controls.Add(this.cmbtransaction);
            this.Controls.Add(this.btnprint);
            this.Controls.Add(this.reportViewer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ReportPrint";
            this.Text = "ReportPrint";
            this.Load += new System.EventHandler(this.ReportPrint_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable3BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataTable1BindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource dataTable3BindingSource;
        private DataSet1 dataSet1;
        private System.Windows.Forms.BindingSource dataSet1BindingSource;
        private System.Windows.Forms.BindingSource DataTable1BindingSource;
        private Guna.UI2.WinForms.Guna2Button btnprint;
        private Guna.UI2.WinForms.Guna2ComboBox cmbtransaction;
        private System.Windows.Forms.Label lbltime;
        private Guna.UI2.WinForms.Guna2DateTimePicker radioWeekly;
        private Guna.UI2.WinForms.Guna2DateTimePicker radioMonthly;
        private Bunifu.UI.WinForms.BunifuImageButton bntexit;
    }
}