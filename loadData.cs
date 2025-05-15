using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laundry_Management_System
{
    internal class loadData
    {
        string connectionString = "server=localhost;port=3306;username=root;password=;database=laundry;";
        public int clientCount()
        {
            int eventCount = 0;
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM laundry_table";
                    MySqlCommand command = new MySqlCommand(query, connection);

                    eventCount = Convert.ToInt32(command.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            return eventCount;
        }
        public decimal GetTotalAmount()
        {
            decimal totalAmount = 0;
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT SUM(totalamount) FROM scheduling_table";  // Sum of all amounts
                    MySqlCommand command = new MySqlCommand(query, connection);

                    object result = command.ExecuteScalar();
                    if (result != DBNull.Value)
                    {
                        totalAmount = Convert.ToDecimal(result);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            return totalAmount;
        }
        public int transactionCount()
        {
            int eventCount = 0;
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM scheduling_table";
                    MySqlCommand command = new MySqlCommand(query, connection);

                    eventCount = Convert.ToInt32(command.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            return eventCount;
        }
    }
}
