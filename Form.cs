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

namespace LineChartLegendByGroupWFApp
{
    // Great Tutorial resource: https://www.youtube.com/watch?v=rZ9QzUMOQJs
    public partial class Form : System.Windows.Forms.Form
    {
        public Form()
        {
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            var filePath = @"C:\Users\sicel\Desktop\Csharp\LineChartLegendByGroupWFApp\customer_registration.csv";

            var customerDataTable = GetCustomerData.ConvertCSVtoDataTable(filePath);



            var dv = new DataView(customerDataTable);
            //dv.Sort = "Year ASC";
            dataGridView.DataSource = dv;
            // Make columns autofill the grid
            dataGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            // Display data in chart

            //chart.DataSource = dv;
            //chart.Series["Series1"].XValueMember = "Registration Type";
            //chart.Series["Series1"].YValueMembers = "Total";
            //chart.Titles.Add("Customer Registration Data");

            chart.DataBindCrossTable(dv, "Registration Type", "Year", "Total",
                "");

            // This code allows you to change the chart type
            foreach (Series cs in chart.Series)
            {
                cs.ChartType = SeriesChartType.Line;
                cs.BorderWidth = 5;

            }
        }
    }
}
