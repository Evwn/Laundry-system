using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Laundry_Management_System
{
    public partial class CustomerManagement : Form
    {
        MySqlConnection conn;
        MySqlCommand cmd;
        MySqlDataReader dr;
        string conns = "server=localhost;port=3306;username=root;password=;database=laundry;";
        private string id, cid, cname, cno, email, caddress, rdate;
        public CustomerManagement()
        {
            InitializeComponent();
            conn = new MySqlConnection(conns);
        }
        public string ID
        {
            get { return id; }
            set { id = value; }
        }

        private void btnregister_Click(object sender, EventArgs e)
        {
            btnupdate.Enabled = false;
            form.Show();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            form.Hide();
        }

        private void CustomerManagement_Load(object sender, EventArgs e)
        {
            LoadData();
            guna2DateTimePicker1.Value = DateTime.Now;
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            string searchValue = txtsearch.Text.Trim();

            // Prepare the query to search the database
            string query = "SELECT id, customerid, customername, contactno, email, address, date " +
                           "FROM laundry_table " +
                           "WHERE customerid LIKE @searchValue OR " +
                           "customername LIKE @searchValue OR " +
                           "contactno LIKE @searchValue " +
                           "ORDER BY customerid";

            guna2DataGridView1.Rows.Clear(); // Clear the DataGridView before reloading

            try
            {
                conn.Open();
                cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@searchValue", "%" + searchValue + "%");
                dr = cmd.ExecuteReader();

                int i = 0;
                while (dr.Read())
                {
                    i++;
                    guna2DataGridView1.Rows.Add(
                        i,
                        dr["id"].ToString(),
                        dr["customerid"].ToString(),
                        dr["customername"].ToString(),
                        dr["contactno"].ToString(),
                        dr["email"].ToString(),
                        dr["address"].ToString(),
                        dr["date"]
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error searching data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dr?.Close();
                conn.Close();
            }
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            try
            {
                string Dates = txtdate.Value.ToString("yy-MM-dd");
                if ((txtcustomerid.Text == string.Empty) || (txtcustomername.Text == string.Empty) || (txtno.Text == string.Empty) || (txtemail.Text == string.Empty) || (txtaddress.Text == string.Empty) || (txtdate.Text == string.Empty))
                {
                    MessageBox.Show("Warning: Missing field required!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                conn.Open();
                cmd = new MySqlCommand("INSERT INTO laundry_table(customerid,customername,contactno,email,address,date) VALUES('" + txtcustomerid.Text + "','" + txtcustomername.Text + "','" + txtno.Text + "','" + txtemail.Text + "','" + txtaddress.Text + "','" + Dates + "')", conn);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    conn.Close();
                    MessageBox.Show("Data successfully saved!", "Form", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                    ClearForm();
                    form.Hide();
                }
                else
                {
                    MessageBox.Show("Checked the data you enter!", "Form", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show("Warning: " + ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            try
            {
                string Dates = txtdate.Value.ToString("yyyy-MM-dd");
                if ((txtcustomerid.Text == string.Empty) || (txtcustomername.Text == string.Empty) || (txtno.Text == string.Empty) || (txtemail.Text == string.Empty) || (txtaddress.Text == string.Empty) || (txtdate.Text == string.Empty))
                {
                    MessageBox.Show("Warning: Missing field required!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                conn.Open();
                cmd = new MySqlCommand("Update laundry_table set customerid='" + txtcustomerid.Text + "',customername='" + txtcustomername.Text + "',contactno='" + txtno.Text + "',email='" + txtemail.Text + "',address='" + txtaddress.Text + "',date ='" + Dates + "' where id = '" + ID + "'", conn);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    conn.Close();
                    MessageBox.Show("Data updated successfully!", "Form", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();
                    LoadData();
                    form.Hide();
                }
                else
                {
                    MessageBox.Show("Something went wrong! Try again later!", "Form", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show("Warning: " + ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = guna2DataGridView1.Columns[e.ColumnIndex].Name;
            if (colName == "Edit")
            {
                btnadd.Enabled = false;
                btnupdate.Enabled = true;
                txtcustomerid.Text = cid;
                txtcustomername.Text = cname;
                txtno.Text = cno;
                txtemail.Text = email;
                txtaddress.Text = caddress;
                txtdate.Text = rdate;
                form.Show();
                
            }
            else if (colName == "Delete")
            {
                if (MessageBox.Show("Are you sure you want to delete this Data?", "Delete Data", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    conn.Open();
                    cmd = new MySqlCommand($"delete from laundry_table where id = '{id}'", conn);
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        conn.Close();
                        MessageBox.Show("Data deleted successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            cid = guna2DataGridView1[2, i].Value.ToString();
            cname = guna2DataGridView1[3, i].Value.ToString();
            cno = guna2DataGridView1[4, i].Value.ToString();
            email = guna2DataGridView1[5, i].Value.ToString();
            caddress = guna2DataGridView1[6, i].Value.ToString();
            rdate = guna2DataGridView1[7, i].Value.ToString();
        }
        public void LoadData()
        {
            guna2DataGridView1.Rows.Clear();
            string query = "SELECT id, customerid, customername, contactno, email, address, date FROM laundry_table ORDER BY customerid";

            try
            {
                conn.Open();
                cmd = new MySqlCommand(query, conn);
                dr = cmd.ExecuteReader();

                int i = 0;
                while (dr.Read())
                {
                    i++;
                    guna2DataGridView1.Rows.Add(
                        i,
                        dr["id"].ToString(),
                        dr["customerid"].ToString(),
                        dr["customername"].ToString(),
                        dr["contactno"].ToString(),
                        dr["email"].ToString(),
                        dr["address"].ToString(),
                        dr["date"]
                    );
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

        private void ClearForm()
        {
            txtcustomerid.Clear();
            txtcustomername.Clear();
            txtno.Clear();
            txtemail.Text = string.Empty;
            txtaddress.Text = string.Empty;
            txtdate.Value = DateTime.Now;

            btnadd.Enabled = true;
            btnupdate.Enabled = false;
        }
    }
}
