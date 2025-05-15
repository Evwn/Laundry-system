using Microsoft.Reporting.WinForms;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laundry_Management_System
{
    public partial class Reciept : Form
    {
        string connectionString = "server=localhost;port=3306;username=root;password=;database=laundry;";
        public Reciept()
        {
            InitializeComponent();
            LoadReport();
        }
        public DataTable GetTable1Data()
        {
            DataTable table1 = new DataTable();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT * FROM item_table";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    connection.Open();
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        adapter.Fill(table1);
                    }
                }
            }

            return table1;
        }
        public DataTable GetTable2Data()
        {
            DataTable table2 = new DataTable();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                // Select only the columns needed
                string query = "SELECT * FROM reciept_table";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    connection.Open();
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        adapter.Fill(table2);
                    }
                }
            }
            return table2;
        }

        private void LoadReport()
        {
            // Retrieve data from each table
            DataTable table1 = GetTable1Data();
            DataTable table2 = GetTable2Data();

            // Get current DateTime in 12-hour format with AM/PM
            string currentDateTime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt");

            // Create a report parameter to pass the current date-time
            ReportParameter[] reportParams = new ReportParameter[]
            {
        new ReportParameter("datettimenow", currentDateTime)
            };

            // Assign parameters to the report
            reportViewer1.LocalReport.SetParameters(reportParams);

            // Data table binding
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", table1));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet2", table2));

            // Refresh the report
            reportViewer1.RefreshReport();
        }

        private void Reciept_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
        private void MoveItemsToItemDashTable()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    MySqlTransaction transaction = conn.BeginTransaction();
                    string insertQuery = "INSERT INTO itemdash_table (id, itemname, quantity, price) SELECT id, itemname, quantity, price FROM item_table";

                    using (MySqlCommand cmd = new MySqlCommand(insertQuery, conn, transaction))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    // Now delete from item_table
                    string deleteQuery = "DELETE FROM item_table";
                    using (MySqlCommand cmd = new MySqlCommand(deleteQuery, conn, transaction))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    // Commit the transaction if everything went fine
                    transaction.Commit();
                    // Removed the success message box
                    // MessageBox.Show("Items successfully moved and deleted from item_table.");
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("Error moving items: " + ex.Message);
                }
            }
        }
        private void DeleteDataFromReceiptTable()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string deleteQuery = "DELETE FROM reciept_table";

                    using (MySqlCommand cmd = new MySqlCommand(deleteQuery, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    // Removed the success message box
                    // MessageBox.Show("Receipt data successfully cleared.");
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("Error clearing receipt data: " + ex.Message);
                }
            }
        }

        // This will be called when the print is successful (via the PrintPage event)
        private void PrintReceipt()
        {
            try
            {
                // Move the items to itemdash_table and delete from item_table
                MoveItemsToItemDashTable();

                // Move items to scheduling_table and clear receipt data
                MoveItemsToSchedulingTableAndClearReceiptTable();
                DeleteDataFromReceiptTable();

                //MessageBox.Show("Data successfully moved and cleared.");
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error during data processing: " + ex.Message);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintAndClose();
            // Trigger the print process
            PrintReceipt();
            // Close the form after the operation
            this.Close();
        }
        private void PrintAndClose()
        {
            try
            {
                // Clear data from the reciept_table
                DeleteDataFromReceiptTable();

                // Trigger the print dialog
                DialogResult result = reportViewer1.PrintDialog();

                // If printing is successful (user confirms the dialog), close the form
                if (result == DialogResult.OK)
                {
                    //MessageBox.Show("Printing successful. Closing the receipt.");
                    this.Close(); // Close the form
                }
                else
                {
                    MessageBox.Show("Printing was canceled.");
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error occurred during print operation: " + ex.Message);
            }
        }

        private void MoveItemsToSchedulingTableAndClearReceiptTable()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    MySqlTransaction transaction = conn.BeginTransaction();

                    // Insert data into scheduling_table, pulling address from laundry_table
                    string insertQuery = @"
            INSERT INTO scheduling_table (customerno, customername, contactno, address, totalamount, transactiondate, transaction)
            SELECT r.customerid AS customerno, r.customername, r.contactno, l.address, r.totalprice, r.date, 'pending'
            FROM reciept_table r
            JOIN laundry_table l ON r.customerid = l.customerid";

                    using (MySqlCommand cmd = new MySqlCommand(insertQuery, conn, transaction))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    // Delete data from reciept_table
                    string deleteQuery = "DELETE FROM reciept_table";
                    using (MySqlCommand cmd = new MySqlCommand(deleteQuery, conn, transaction))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    // Commit transaction
                    transaction.Commit();
                    // Removed the success message box
                    // MessageBox.Show("Data successfully moved to scheduling_table and deleted from reciept_table.");
                }
                catch (Exception ex)
                {
                   //MessageBox.Show("Error moving data to scheduling_table: " + ex.Message);
                }
            }
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
