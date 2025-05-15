using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using MySql.Data.MySqlClient;


namespace Laundry_Management_System
{
    public partial class ReportPrint : Form
    {
        string conns = "server=localhost;port=3306;username=root;password=;database=laundry;";
        public ReportPrint()
        {
            InitializeComponent();
            InitializeFilters();
            ShowCurrentTime();
            LoadReport();
        }
        private void InitializeFilters()
        {
            // Initialize transaction filter combo box
            cmbtransaction.Items.Clear();
            cmbtransaction.Items.Add("All");
            cmbtransaction.Items.Add("Pending");
            cmbtransaction.Items.Add("Complete");
            cmbtransaction.Items.Add("Canceled");
            cmbtransaction.Items.Add("Ready for Pickup");
            cmbtransaction.SelectedIndex = 0;

            // Attach event handler
            cmbtransaction.SelectedIndexChanged += cmbtransaction_SelectedIndexChanged;
        }
        public DataTable GetTable3Data()
        {
            DataTable table3 = new DataTable();

            using (MySqlConnection connection = new MySqlConnection(conns))
            {
                // Select only the columns needed
                string query = "SELECT * FROM scheduling_table";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    connection.Open();
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        adapter.Fill(table3);
                    }
                }
            }
            return table3;
        }
        private void LoadReport()
        {
            // Retrieve data from each table
           
            DataTable table1 = GetTable3Data();

            //data table binding 
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", table1));
        }
        private void ReportPrint_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
            LoadReport("All");

        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
        private void ShowCurrentTime()
        {
            // Display the current time in lbltime
            Timer timer = new Timer { Interval = 1000 }; // Update every second
            timer.Tick += (sender, e) =>
            {
                lbltime.Text = DateTime.Now.ToString("hh:mm:ss tt");
            };
            timer.Start();
        }
        private DataTable GetSchedulingData(string transactionFilter)
        {
            DataTable table = new DataTable();

            using (MySqlConnection connection = new MySqlConnection(conns))
            {
                // Base query
                string query = "SELECT * FROM scheduling_table WHERE 1=1";

                // Add transaction filter if not "All"
                if (transactionFilter != "All")
                {
                    query += " AND transaction = @transaction";
                }

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    // Add parameter for transaction filter
                    if (transactionFilter != "All")
                        command.Parameters.AddWithValue("@transaction", transactionFilter);

                    connection.Open();
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        adapter.Fill(table);
                    }
                }
            }

            return table;
        }
        private void LoadReport(string transactionFilter)
        {
            // Retrieve data based on the selected transaction filter
            DataTable filteredData = GetSchedulingData(transactionFilter);

            // Calculate total amount
            decimal totalAmount = filteredData.AsEnumerable().Sum(row => row.Field<decimal>("totalamount"));

            // Create report parameters
            ReportParameter[] reportParams = new ReportParameter[]
            {
        new ReportParameter("Dateprint", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt")), // Current date and time
        new ReportParameter("Totalamount", totalAmount.ToString("C")) // Total amount formatted as currency
            };

            // Bind data to the RDLC report
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", filteredData));
            reportViewer1.LocalReport.SetParameters(reportParams);
            reportViewer1.RefreshReport();
        }

        private void btnprint_Click(object sender, EventArgs e)
        {
            reportViewer1.PrintDialog();
        }
        private void ApplyFilters()
        {
            string selectedTransaction = cmbtransaction.SelectedItem.ToString();

            // Load the report based on the selected transaction type
            LoadReport(selectedTransaction);
        }

        private void cmbtransaction_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void bntexit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
