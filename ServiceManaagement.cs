using Guna.UI2.WinForms;
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
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Security.Cryptography;

namespace Laundry_Management_System
{
    public partial class ServiceManaagement : Form
    {
        MySqlConnection conn;
        MySqlCommand cmd;
        MySqlDataReader dr;
        string conns = "server=localhost;port=3306;username=root;password=;database=laundry;";

        private bool isButtonClicked = false;
        private string id, itemname, quantity, price;
        public ServiceManaagement()
        {
            InitializeComponent();
            conn = new MySqlConnection(conns);
            LoadData();
            CalculateTotalPrice();

            guna2DateTimePicker1.Value = DateTime.Now;

            panelContent.AutoScroll = true;
            guna2VScrollBar1.ValueChanged += guna2VScrollBar1_ValueChanged;

            guna2VScrollBar1.Minimum = 0;
            guna2VScrollBar1.Maximum = panelContent.Height - container.Height;
            guna2VScrollBar1.SmallChange = 10;
            guna2VScrollBar1.LargeChange = 20;
        }
        public string ID
        {
            get { return id; }
            set { id = value; }
        }
        private void ServiceManaagement_Load(object sender, EventArgs e)
        {
            CalculateTotalPrice();
            LoadData();
        }

        private void guna2VScrollBar1_ValueChanged(object sender, EventArgs e)
        {

            panelContent.Top = -guna2VScrollBar1.Value;
        }

        private void roundedPanel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            form.Hide();
            form1.Hide();
            txtitemname.Clear();
            txtquantity.Clear();
            txtprice.Clear();
        }
        private bool ItemExists(string itemName, out int existingQuantity)
        {
            existingQuantity = 0;
            try
            {
                conn.Open();
                cmd = new MySqlCommand("SELECT quantity FROM item_table WHERE itemname = @itemname", conn);
                cmd.Parameters.AddWithValue("@itemname", itemName);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        existingQuantity = reader.GetInt32("quantity");
                        return true; // Item exists
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error checking item existence: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
            return false; // Item does not exist
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate required fields
                if (string.IsNullOrWhiteSpace(txtitemname.Text) ||
                    string.IsNullOrWhiteSpace(txtquantity.Text) ||
                    string.IsNullOrWhiteSpace(txtprice.Text))
                {
                    MessageBox.Show("Warning: Missing field required!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string itemName = txtitemname.Text.Trim();
                if (!int.TryParse(txtquantity.Text, out int quantity) || quantity <= 0)
                {
                    MessageBox.Show("Quantity must be a valid positive number!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!decimal.TryParse(txtprice.Text, out decimal price) || price <= 0)
                {
                    MessageBox.Show("Price must be a valid positive number!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                decimal totalPrice = quantity * price;

                // Check if the item already exists
                if (ItemExists(itemName, out int existingQuantity))
                {
                    // Update existing item's quantity and price (Avoid inserting duplicates)
                    conn.Open();
                    cmd = new MySqlCommand(
                        "UPDATE item_table SET quantity = @quantity, price = @price WHERE itemname = @itemname", conn);
                    cmd.Parameters.AddWithValue("@itemname", itemName);
                    cmd.Parameters.AddWithValue("@quantity", existingQuantity + quantity); // Increase quantity
                    cmd.Parameters.AddWithValue("@price", price);
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show($"Updated item '{itemName}' successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    // Insert new item if it doesn't exist
                    conn.Open();
                    cmd = new MySqlCommand(
                        "INSERT INTO item_table (itemname, quantity, price) VALUES (@itemname, @quantity, @price)", conn);
                    cmd.Parameters.AddWithValue("@itemname", itemName);
                    cmd.Parameters.AddWithValue("@quantity", quantity);
                    cmd.Parameters.AddWithValue("@price", price);
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show($"Added new item '{itemName}' successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        form.Hide();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding item: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
                LoadData();  // Refresh the data
                CalculateTotalPrice(); // Update the total price
            }
        }
        private void btnupdate_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if fields are empty
                if (string.IsNullOrWhiteSpace(txtitemname.Text) ||
                    string.IsNullOrWhiteSpace(txtquantity.Text) ||
                    string.IsNullOrWhiteSpace(txtprice.Text))
                {
                    MessageBox.Show("Warning: Missing field required!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string itemName = txtitemname.Text.Trim();
                if (!int.TryParse(txtquantity.Text, out int quantity) || quantity <= 0)
                {
                    MessageBox.Show("Quantity must be a valid positive number!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!decimal.TryParse(txtprice.Text, out decimal price) || price <= 0)
                {
                    MessageBox.Show("Price must be a valid positive number!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Ensure item exists before updating
                if (ItemExists(itemName, out int existingQuantity))
                {
                    // Update the item quantity and price
                    conn.Open();
                    cmd = new MySqlCommand(
                        "UPDATE item_table SET quantity = @quantity, price = @price WHERE itemname = @itemname", conn);
                    cmd.Parameters.AddWithValue("@itemname", itemName);
                    cmd.Parameters.AddWithValue("@quantity", quantity); // Set to new quantity
                    cmd.Parameters.AddWithValue("@price", price);
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show($"Item '{itemName}' updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Item not found for update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating item: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
                LoadData();  // Refresh the data
                CalculateTotalPrice(); // Update total price if needed
            }
        }
        private void LoadData()
        {
            guna2DataGridView1.Rows.Clear();
            string query = "SELECT id, itemname, quantity, price, (quantity * price) AS totalprice FROM item_table ORDER BY itemname";
            try
            {
                conn.Open();
                cmd = new MySqlCommand(query, conn);
                dr = cmd.ExecuteReader();

                int index = 0;
                while (dr.Read())
                {
                    index++;
                    guna2DataGridView1.Rows.Add(
                        index,
                        dr["id"].ToString(),
                        dr["itemname"].ToString(),
                        dr["quantity"].ToString(),
                        dr["price"].ToString(),
                        dr["totalprice"].ToString()); // Add total price column
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dr?.Close();
                conn.Close();
            }
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = guna2DataGridView1.Columns[e.ColumnIndex].Name;
            
            if (colName == "Delete")
            {
                if (MessageBox.Show("Are you sure you want to delete this Data?", "Delete Data", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    conn.Open();
                    cmd = new MySqlCommand($"delete from item_table where id = '{id}'", conn);
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        conn.Close();
                        MessageBox.Show("Data deleted successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CalculateTotalPrice();
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Something went wrong! Try again later!", "Form", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
        private void guna2DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            int i = guna2DataGridView1.CurrentRow.Index;
            id = guna2DataGridView1[1, i].Value.ToString();
            itemname = guna2DataGridView1[2, i].Value.ToString();
            quantity = guna2DataGridView1[3, i].Value.ToString();
            price = guna2DataGridView1[4, i].Value.ToString();
        }
        private void HandleItemButtonClick(string itemName, decimal price)
        {
            int existingQuantity = 1;
            bool itemAlreadyExists = ItemExists(itemName, out existingQuantity);

            txtquantity.Text = itemAlreadyExists ? existingQuantity.ToString() : "1";

            txtitemname.Text = itemName;
            txtprice.Text = price.ToString();

            decimal totalPrice = existingQuantity * price;
            txtTotalPrice.Text = totalPrice.ToString();

            btnadd.Enabled = !itemAlreadyExists; 
            btnupdate.Enabled = itemAlreadyExists;  

            // Show form
            form.Show();

            // Refresh UI elements
            txtitemname.Refresh();
            txtquantity.Refresh();
            txtprice.Refresh();
            txtTotalPrice.Refresh();
        }
        private void UpdateTotalPrice()
        {
            if (int.TryParse(txtquantity.Text, out int quantity) && decimal.TryParse(txtprice.Text, out decimal pricePerItem))
            {
                decimal totalPrice = quantity * pricePerItem;
                txtTotalPrice.Text = totalPrice.ToString("0.00");
            }
            else
            {
                txtTotalPrice.Text = "0.00";
            }
        }

        private void Poloshirts_Click(object sender, EventArgs e)
        {
            HandleItemButtonClick("Polo Shirts", 90);
        }

        private void btntowel_Click(object sender, EventArgs e)
        {
            HandleItemButtonClick("Towel", 40);
        }

        private void txtquantity_TextChange(object sender, EventArgs e)
        {
            UpdateTotalPrice();
        }

        private void Jeans_Click(object sender, EventArgs e)
        {
            HandleItemButtonClick("Jeans", 70);
        }

        private void btnuniform_Click(object sender, EventArgs e)
        {
            HandleItemButtonClick("Uniform", 150);
        }

        private void btncarpet_Click(object sender, EventArgs e)
        {
            HandleItemButtonClick("Carpet", 300);
        }

        private void btnblazer_Click(object sender, EventArgs e)
        {
            HandleItemButtonClick("Blazer", 120);
        }

        private void btndress_Click(object sender, EventArgs e)
        {
            HandleItemButtonClick("Dress", 250);
        }

        private void btnformal_Click(object sender, EventArgs e)
        {
            HandleItemButtonClick("Formal", 250);
        }

        private void btnpants_Click(object sender, EventArgs e)
        {
            HandleItemButtonClick("Pants", 60);
        }

        private void btnshorts_Click(object sender, EventArgs e)
        {
            HandleItemButtonClick("Shorts", 250);
        }

        private void btnbedsheet_Click(object sender, EventArgs e)
        {
            HandleItemButtonClick("Beds Sheet", 80);
        }

        private void btnpillow_Click(object sender, EventArgs e)
        {
            HandleItemButtonClick("Pillow", 50);
        }
        private void btnshirt_Click(object sender, EventArgs e)
        {
            HandleItemButtonClick("T Shirt", 70);
        }
        private void btncolords_Click(object sender, EventArgs e)
        {
            HandleItemButtonClick("Colords", 150);
        }

        private void btnwhite_Click(object sender, EventArgs e)
        {
            HandleItemButtonClick("Whites", 200);
        }

        private void btncomplete_Click(object sender, EventArgs e)
        {
            form1.Show();
            CalculateTotalPrice();

        }

        private void txtreciept_Click(object sender, EventArgs e)
        {
            try
            {
                // Step 1: Validate fields
                if (string.IsNullOrWhiteSpace(txtcid.Text) || string.IsNullOrWhiteSpace(txtcname.Text) ||
                    string.IsNullOrWhiteSpace(txtcno.Text) || string.IsNullOrWhiteSpace(txttprice.Text) ||
                    string.IsNullOrWhiteSpace(txtpayment.Text))
                {
                    MessageBox.Show("Please fill in all fields.");
                    return;
                }

                // Step 2: Validate payment and total price
                if (decimal.TryParse(txttprice.Text, out decimal totalPrice) && decimal.TryParse(txtpayment.Text, out decimal payment))
                {
                    if (payment < totalPrice)
                    {
                        MessageBox.Show("Payment is less than total price. Please enter a valid payment amount.");
                        return;
                    }

                    decimal change = payment - totalPrice;
                    txtchange.Text = change.ToString("0.00");

                    // Fetch customer address from the database
                    string addressQuery = "SELECT address FROM laundry_table WHERE customerid = @customerid";
                    string customerAddress = string.Empty;
                    using (MySqlConnection conn = new MySqlConnection(conns))
                    {
                        MySqlCommand cmd = new MySqlCommand(addressQuery, conn);
                        cmd.Parameters.AddWithValue("@customerid", txtcid.Text);

                        try
                        {
                            conn.Open();
                            customerAddress = cmd.ExecuteScalar()?.ToString();

                            if (string.IsNullOrWhiteSpace(customerAddress))
                            {
                                MessageBox.Show("Customer address not found in the database.");
                                return;
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error fetching address: " + ex.Message);
                            return;
                        }
                    }

                    using (MySqlConnection conn = new MySqlConnection(conns))
                    {
                        conn.Open();

                        // Step 3: Transfer all data from item_table to itemdash_table
                        string transferQuery = "INSERT INTO itemdash_table SELECT * FROM item_table";
                        using (MySqlCommand transferCmd = new MySqlCommand(transferQuery, conn))
                        {
                            transferCmd.ExecuteNonQuery();
                        }

                        // Removed Step 4: No longer deleting data from item_table

                        // Step 5: Insert the receipt into reciept_table
                        string insertQuery = "INSERT INTO reciept_table (customerid, customername, contactno, totalprice, payment, changes, date) " +
                                              "VALUES (@customerid, @customername, @contactno, @totalprice, @payment, @changes, @date)";
                        using (MySqlCommand cmd = new MySqlCommand(insertQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@customerid", txtcid.Text);
                            cmd.Parameters.AddWithValue("@customername", txtcname.Text);
                            cmd.Parameters.AddWithValue("@contactno", txtcno.Text);
                            cmd.Parameters.AddWithValue("@totalprice", txttprice.Text);
                            cmd.Parameters.AddWithValue("@payment", txtpayment.Text);
                            cmd.Parameters.AddWithValue("@changes", change);
                            cmd.Parameters.AddWithValue("@date", guna2DateTimePicker1.Value.Date);
                            cmd.ExecuteNonQuery();
                        }

                        // Step 6: Save receipt details into scheduling_table
                        string schedulingQuery = "INSERT INTO scheduling_table (customerno, customername, contactno, address, totalamount, transactiondate, transaction) " +
                                                 "VALUES (@customerno, @customername, @contactno, @address, @totalamount, @transactiondate, @transaction)";
                        using (MySqlCommand schedulingCmd = new MySqlCommand(schedulingQuery, conn))
                        {
                            schedulingCmd.Parameters.AddWithValue("@customerno", txtcid.Text);
                            schedulingCmd.Parameters.AddWithValue("@customername", txtcname.Text);
                            schedulingCmd.Parameters.AddWithValue("@contactno", txtcno.Text);
                            schedulingCmd.Parameters.AddWithValue("@address", customerAddress); // Address fetched above
                            schedulingCmd.Parameters.AddWithValue("@totalamount", txttprice.Text);
                            schedulingCmd.Parameters.AddWithValue("@transactiondate", guna2DateTimePicker1.Value.Date);
                            schedulingCmd.Parameters.AddWithValue("@transaction", "pending");
                            schedulingCmd.ExecuteNonQuery();
                        }

                        // Step 7: Show success message
                        //MessageBox.Show("Receipt has been successfully stored, and items have been transferred to itemdash_table.");

                        // Step 8: Optionally, clear fields or perform other UI updates as necessary
                        LoadData(); // Refresh the UI or data grid
                        form1.Hide(); // Hide the form if needed
                        Reciept r = new Reciept();
                        r.Show(); // Open the receipt form (if applicable)
                    }
                }
                else
                {
                    MessageBox.Show("Invalid values for payment or total price. Please check your inputs.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred: " + ex.Message);
            }
        }


        private void txtchange_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtsearch.Text))
            {
                txtcid.Clear();
                txtcname.Clear();
                txtcno.Clear();
            }
            else
            {
                SearchCustomer(txtsearch.Text);
            }
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtsearch.Text))
            {
                txtcid.Clear();
                txtcname.Clear();
                txtcno.Clear();
            }
            else
            {
                // Pass the search text (could be name or ID)
                SearchCustomer(txtsearch.Text);
            }
        }

        private void SearchCustomer(string searchValue)
        {
            try
            {
                // Adjust the query to allow searching by either customer name or ID
                string query = "SELECT customerid, customername, contactno FROM laundry_table " +
                               "WHERE customerid LIKE @searchValue OR customername LIKE @searchValue LIMIT 1";
                conn.Open();
                cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@searchValue", "%" + searchValue + "%");

                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    txtcid.Text = dr["customerid"].ToString();
                    txtcname.Text = dr["customername"].ToString();
                    txtcno.Text = dr["contactno"].ToString();
                }
                else
                {
                    // Clear fields if no matching record is found
                    txtcid.Clear();
                    txtcname.Clear();
                    txtcno.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error searching for customer: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dr?.Close();
                conn.Close();
            }
        }

        private void CalculateTotalPrice()
        {
            decimal totalPrice = 0;

            try
            {
                conn.Open();
                string query = "SELECT SUM(quantity * price) AS price FROM item_table";
                cmd = new MySqlCommand(query, conn);
                object result = cmd.ExecuteScalar();

                if (result != DBNull.Value)
                {
                    totalPrice = Convert.ToDecimal(result);
                }

                txttprice.Text = totalPrice.ToString("0.00");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error calculating total price: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                // Step 1: Clear data from the item_table in the database
                string clearQuery = "DELETE FROM item_table";  // Adjust table name as needed

                using (MySqlConnection conn = new MySqlConnection(conns))
                {
                    MySqlCommand cmd = new MySqlCommand(clearQuery, conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                // Step 2: Clear data from the DataGridView
                guna2DataGridView1.DataSource = null;
                guna2DataGridView1.Rows.Clear();  // Optionally, clear rows from the grid if the DataSource is not null

                MessageBox.Show("All data has been cleared from the database and DataGrid.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while clearing data: " + ex.Message);
            }
        }

    }
}




