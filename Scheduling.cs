using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laundry_Management_System
{
    public partial class Scheduling : Form
    {
        MySqlConnection conn;
        string conns = "server=localhost;port=3306;username=root;password=;database=laundry;";
        private string id, customerno, customername, contactno, address, totalamount, transactiondate, transaction;

        private void btnrdp_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string query = "UPDATE scheduling_table SET transaction = 'Ready for Pickup' WHERE id = @id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                transaction = "Ready for Pickup"; // Update local transaction status
                MessageBox.Show("The laundry is now ready for pickup!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SendNotification("Laundry is ready for pickup");

                LoadSchedulingData(); // Reload the data to reflect changes
                SetButtonStates(transaction); // Update button states based on the new status
                formtransaction.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }
        private void InitializeTransactionFilter()
        {
            // Populate ComboBox with transaction statuses
            cmbtransaction.Items.Clear();
            cmbtransaction.Items.Add("All");
            cmbtransaction.Items.Add("Complete");
            cmbtransaction.Items.Add("Canceled");
            cmbtransaction.Items.Add("Ready for Pickup");
            cmbtransaction.Items.Add("Pending"); // Add Pending status

            // Set default selected value to "All"
            cmbtransaction.SelectedIndex = 0;

            // Attach the event handler for selection changes
            cmbtransaction.SelectedIndexChanged += cmbtransaction_SelectedIndexChanged;
        }

        private void btntrancomplete_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string query = "UPDATE scheduling_table SET transaction = 'Complete' WHERE id = @id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                transaction = "Complete"; // Update local transaction status
                MessageBox.Show("Transaction marked as complete.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SendNotification("Transaction Complete");

                LoadSchedulingData(); // Reload the data to reflect changes
                SetButtonStates(transaction); // Update button states based on the new status
                formtransaction.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }

        private void btntrancancel_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string query = "UPDATE scheduling_table SET transaction = 'Canceled' WHERE id = @id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Transaction has been canceled.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SendNotification("Transaction Canceled");

                LoadSchedulingData(); // Reload the data to reflect changes
                SetButtonStates("Canceled"); // Update button states based on the new status
                formtransaction.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }
        private void SendNotification(string message)
        {
            // This sends a message to the user's system tray
            var notification = new System.Windows.Forms.NotifyIcon
            {
                Icon = SystemIcons.Information,
                Visible = true
            };
            notification.ShowBalloonTip(3000, "Laundry Management System", message, ToolTipIcon.Info);
        }
        private void btnformhide_Click(object sender, EventArgs e)
        {
            formtransaction.Hide();
            SetButtonStates(transaction); // Refresh button states
        }

        private void Scheduling_Load(object sender, EventArgs e)
        {
            LoadSchedulingData();
            InitializeTransactionFilter();
            SetButtonStates(transaction);
        }

        private void searchcustomer_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = searchcustomer.Text.Trim();
            LoadSchedulingData(searchTerm);  // Pass the search term to filter the records
        }

        private void cmbtransaction_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedTransaction = cmbtransaction.SelectedItem.ToString();

            if (selectedTransaction == "All")
            {
                // Load all records if "All" is selected
                LoadSchedulingData();
            }
            else
            {
                // Load filtered data based on selected transaction status
                LoadSchedulingDataByTransaction(selectedTransaction);
            }
        }
        private void LoadSchedulingDataByTransaction(string transactionStatus)
        {
            int i = 0;
            guna2DataGridView1.Rows.Clear();

            using (MySqlConnection conn = new MySqlConnection(conns))
            {
                string query = "";

                // Modify the query to include the "Pending" status
                if (transactionStatus == "Pending")
                {
                    query = "SELECT * FROM scheduling_table WHERE transaction = 'Pending' ORDER BY id";
                }
                else
                {
                    query = "SELECT * FROM scheduling_table WHERE transaction = @transaction ORDER BY id";
                }

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    if (transactionStatus != "Pending")
                    {
                        cmd.Parameters.AddWithValue("@transaction", transactionStatus);
                    }

                    conn.Open();
                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            i += 1;
                            guna2DataGridView1.Rows.Add(
                                i,
                                dr["id"].ToString(),
                                dr["customerno"].ToString(),
                                dr["customername"].ToString(),
                                dr["contactno"].ToString(),
                                dr["address"].ToString(),
                                dr["totalamount"].ToString(),
                                dr["transactiondate"],
                                dr["transaction"].ToString()
                            );

                            // Update local transaction status
                            transaction = dr["transaction"].ToString();
                            SetButtonStates(transaction);
                        }
                    }
                }
            }
        }

        private void btnprint_Click(object sender, EventArgs e)
        {
            ReportPrint r = new ReportPrint(); 
            r.Show();
        }

        private void Scheduling_Shown(object sender, EventArgs e)
        {
            SetButtonStates(transaction);
        }

        public string ID
        {
            get { return id; }
            set { id = value; }
        }
        public Scheduling()
        {
            InitializeComponent();
            conn = new MySqlConnection(conns);
            guna2DateTimePicker1.Value = DateTime.Now;
            SetButtonStates(transaction);
        }
        public void LoadSchedulingData(string searchTerm = "")
        {
            int i = 0;
            guna2DataGridView1.Rows.Clear();

            using (MySqlConnection conn = new MySqlConnection(conns))
            {
                // Modify the query to filter records based on the search term
                string query = "SELECT * FROM scheduling_table WHERE customername LIKE @searchTerm OR customerno LIKE @searchTerm ORDER BY id";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    // Use parameters to prevent SQL injection
                    cmd.Parameters.AddWithValue("@searchTerm", "%" + searchTerm + "%");

                    conn.Open();
                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            i += 1;
                            guna2DataGridView1.Rows.Add(
                                i,
                                dr["id"].ToString(),
                                dr["customerno"].ToString(),
                                dr["customername"].ToString(),
                                dr["contactno"].ToString(),
                                dr["address"].ToString(),
                                dr["totalamount"].ToString(),
                                dr["transactiondate"],
                                dr["transaction"].ToString()
                            );

                            // Set the current transaction status after loading data
                            transaction = dr["transaction"].ToString();
                            SetButtonStates(transaction); // Ensure button states are updated with the transaction status
                        }
                    }
                }
            }
        }
        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = guna2DataGridView1.Columns[e.ColumnIndex].Name;

            if (colName == "Edit")
            {
                // Enable the Ready for Pickup button and populate the form with data
                btnrdp.Enabled = true;
                txtcustomerid.Text = customerno;
                txtcustomername.Text = customername;
                txtno.Text = contactno;
                txtaddress.Text = address;
                txtdate.Text = transactiondate;
                txttotalamount.Text = totalamount;
                txttransaction.Text = transaction;
                formtransaction.Show();

                // Refresh button states after selecting a row
                SetButtonStates(transaction);
            }
            else if (colName == "Delete")
            {
                // Get the ID of the selected row for deletion
                int rowIndex = e.RowIndex;
                string selectedId = guna2DataGridView1[1, rowIndex].Value.ToString(); // Assuming the ID is in the second column (index 1)

                // Ask for confirmation before deleting the record
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this record?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        // Establish connection and delete the record from the database
                        using (MySqlConnection conn = new MySqlConnection(conns))
                        {
                            string query = "DELETE FROM scheduling_table WHERE id = @id";
                            MySqlCommand cmd = new MySqlCommand(query, conn);
                            cmd.Parameters.AddWithValue("@id", selectedId);

                            conn.Open();
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Record deleted successfully.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Reload the data to reflect the deletion
                            LoadSchedulingData();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }


        private void guna2DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            int i = guna2DataGridView1.CurrentRow.Index;
            id = guna2DataGridView1[1, i].Value.ToString();
            customerno = guna2DataGridView1[2, i].Value.ToString();
            customername = guna2DataGridView1[3, i].Value.ToString();
            contactno = guna2DataGridView1[4, i].Value.ToString();
            address = guna2DataGridView1[5, i].Value.ToString();
            totalamount = guna2DataGridView1[6, i].Value.ToString();
            transactiondate = guna2DataGridView1[7, i].Value.ToString();
            transaction = guna2DataGridView1[8, i].Value.ToString();

            SetButtonStates(transaction); // Adjust b
        }
        private void SetButtonStates(string transactionStatus)
        {
            if (transactionStatus == "Complete" || transactionStatus == "Canceled")
            {
                // Disable all buttons if the transaction is complete or canceled
                btnrdp.Enabled = false;
                btntrancomplete.Enabled = false;
                btntrancancel.Enabled = false;
            }
            else if (transactionStatus == "Ready for Pickup")
            {
                // Disable 'Ready for Pickup' button and enable 'Complete' and 'Cancel' buttons
                btnrdp.Enabled = false;
                btntrancomplete.Enabled = true;
                btntrancancel.Enabled = true;
            }
            else
            {
                // Enable all buttons for 'Pending' or any other status
                btnrdp.Enabled = true;
                btntrancomplete.Enabled = true;
                btntrancancel.Enabled = true;
            }
        }

    }
}
