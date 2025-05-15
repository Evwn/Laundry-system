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
using System.Windows.Forms.DataVisualization.Charting;

namespace Laundry_Management_System
{
    public partial class DashBoardContent : Form
    {
        string connectionString = "server=localhost;port=3306;username=root;password=;database=laundry;";

        public DashBoardContent()
        {
            InitializeComponent();
            LoadDoughnutChartData();
            loadDash();
        }

        private void mainpanel_Paint(object sender, PaintEventArgs e)
        {

        }
        private void LoadDoughnutChartData()
        {
            // Create a new series for the Doughnut chart
            var series = new Series
            {
                Name = "Doughnut Series",
                ChartType = SeriesChartType.Doughnut, // Set chart type to Doughnut
                BorderWidth = 2, // Add border to the slices
                BorderColor = Color.White // White border color for better contrast
            };

            // Query the database for the data in itemdash_table
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    // Adjusted query to group by itemname and sum the quantities
                    string query = "SELECT itemname, SUM(quantity) as total_quantity FROM itemdash_table GROUP BY itemname";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string itemName = reader["itemname"].ToString();
                            int quantity = Convert.ToInt32(reader["total_quantity"]);

                            // Add data points for each item in the chart
                            series.Points.AddXY(itemName, quantity);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading data for chart: " + ex.Message);
                }
            }

            // Clear any previous data in the chart and add the new series
            chart1.Series.Clear();
            chart1.Series.Add(series);

            // Customize the chart appearance
            chart1.Titles.Clear();
            chart1.Titles.Add("Item Distribution"); // Add title for the chart
            chart1.Titles[0].Font = new Font("Arial", 14, FontStyle.Bold); // Set font for the title
            chart1.Titles[0].ForeColor = Color.Navy; // Set title color
            chart1.Legends.Clear();
            chart1.Legends.Add("Legend"); // Add legend
            chart1.Legends[0].Font = new Font("Arial", 10, FontStyle.Italic); // Customize legend font
            chart1.Legends[0].ForeColor = Color.Gray; // Set legend color

            // Enable data labels and customize them
            series.IsValueShownAsLabel = true;
            series.LabelForeColor = Color.Black; // Set label text color to black
            series.LabelBackColor = Color.Transparent; // Set label background to transparent
            series.LabelBorderColor = Color.White; // Set label border color
            series.LabelBorderWidth = 1; // Add a small border around the labels

            // Customize the label format to display the quantity value
            series.LabelFormat = "#,##0"; // Display as a whole number (e.g., 1000 instead of 1000.0)

            // Customize the chart area
            chart1.ChartAreas[0].AxisX.Title = "";
            chart1.ChartAreas[0].AxisY.Title = "";
            chart1.ChartAreas[0].AxisX.LabelStyle.Enabled = false;
            chart1.ChartAreas[0].AxisY.LabelStyle.Enabled = false;

            // Set the starting angle of the doughnut chart for better aesthetics
            chart1.ChartAreas[0].Area3DStyle.Inclination = 10; // Tilt for a 3D effect
            chart1.ChartAreas[0].Area3DStyle.Rotation = 45; // Rotate for a more dynamic view

            // Enable 3D effect for a more dynamic look
            chart1.ChartAreas[0].Area3DStyle.Enable3D = true;

            // Set custom colors for each slice dynamically (optional)
            Random rand = new Random();
            for (int i = 0; i < series.Points.Count; i++)
            {
                // Generate random colors for each slice
                series.Points[i].Color = Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256));
            }

            // Set chart background color with gradient
            chart1.ChartAreas[0].BackColor = Color.LightGray; // Set the primary background color
            chart1.ChartAreas[0].BackSecondaryColor = Color.White; // Set the secondary background color
            chart1.ChartAreas[0].BackGradientStyle = GradientStyle.HorizontalCenter;
            // Apply a gradient background
        }

        public void loadDash()
        {
            loadData l = new loadData();
            int clients = l.clientCount();
            lbl1.Text = $" {clients}";

            loadData d = new loadData();
            decimal totalAmount = d.GetTotalAmount();
           lbl2.Text = $" {totalAmount}";

            loadData t = new loadData();
            decimal transaction = t.transactionCount();
            lbl3.Text = $" {transaction}";

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
