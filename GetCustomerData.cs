using System;
using System.Data;
using System.IO;

namespace LineChartLegendByGroupWFApp
{
    public class GetCustomerData
    {
        public static DataTable ConvertCSVtoDataTable(string strFilePath)
        {
            DataTable dt = new DataTable();
            using (StreamReader sr = new StreamReader(strFilePath))
            {
                string[] headers = sr.ReadLine().Split(',');
                foreach (string header in headers)
                {
                    // force columns to be specific type if desired for easier sorting
                    dt.Columns.Add(header);
                    try
                    {
                        dt.Columns["Year"].DataType = typeof(int);
                    }
                    catch (Exception)
                    {

                    }
                    
                }
                while (!sr.EndOfStream)
                {
                    string[] rows = sr.ReadLine().Split(',');
                    DataRow dr = dt.NewRow();
                    for (int i = 0; i < headers.Length; i++)
                    {
                        dr[i] = rows[i];
                    }
                    dt.Rows.Add(dr);
                }

            }

            return dt;
        }
    }
}
