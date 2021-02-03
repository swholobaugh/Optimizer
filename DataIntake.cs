using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using ExcelDataReader;

namespace Optimizer
{
    class DataIntake
    {
        private System.Data.DataSet dataSet;

        public void CreateDataTable(string tableName, int input, string fPath)
        {
            //string fPath = @"c:\Users\swhol\source\repos\Optimizer\EURUSD_QQEVelocity.xlsx"; //will use filePath
            System.Data.DataTable table = new DataTable(tableName);

            DataColumn column;
            DataRow row;

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Pass";
            column.ReadOnly = true;
            column.Unique = true;
            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Double");
            column.ColumnName = "Profit";
            column.ReadOnly = true;
            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "Total Trades";
            column.ReadOnly = true;
            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Double");
            column.ColumnName = "Profit Factor";
            column.ReadOnly = true;
            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Double");
            column.ColumnName = "Expected Payoff";
            column.ReadOnly = true;
            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Double");
            column.ColumnName = "Drawdown $";
            column.ReadOnly = true;
            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Double");
            column.ColumnName = "Drawdown %";
            column.ReadOnly = true;
            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Double");
            column.ColumnName = "OnTesterResult";
            column.ReadOnly = true;
            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Input 1";
            column.ReadOnly = true;
            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Input 2";
            column.ReadOnly = true;
            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Input 3";
            column.ReadOnly = true;
            table.Columns.Add(column);


            if(input > 4)
            {
                for(int x = 0; x < input; x++)
                {
                    column = new DataColumn();
                    column.DataType = System.Type.GetType("System.Double");
                    column.ColumnName = $"{input + 4}";
                    column.ReadOnly = true;
                    column.Unique = true;
                    table.Columns.Add(column);
                }
            }

            dataSet = new DataSet();
            dataSet.Tables.Add(table);

            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            using(var stream = File.Open(fPath, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {

                    for(int x = 0; x < reader.RowCount; x++)
                    {
                        reader.Read();
                        
                        row = table.NewRow();
                        row["Pass"] = reader.GetValue(0);
                        row["Profit"] = reader.GetValue(1);
                        row["Total Trades"] = reader.GetValue(2);
                        row["Profit Factor"] = reader.GetValue(3);
                        row["Expected Payoff"] = reader.GetValue(4);
                        row["Drawdown $"] = reader.GetValue(5);
                        row["Drawdown %"] = reader.GetValue(6);
                        row["OnTesterResult"] = reader.GetValue(7);
                        row["Input 1"] = reader.GetValue(8).ToString();
                        row["Input 2"] = reader.GetValue(9).ToString();
                        row["Input 3"] = reader.GetValue(10).ToString();

                        table.Rows.Add(row);

                    }   
                }
            }            
        }


        public void QueryDataSet() {

            DataTable eurusd = dataSet.Tables["CHF/JPY"];

            //DataTable eurgbp = dataSet.Tables["EUR/GBP"].Copy();
            //DataTable audcad = dataSet.Tables["AUD/CAD"].Copy();
            //DataTable audnzd = dataSet.Tables["AUD/NZD"].Copy();
            //DataTable chfjpy = dataSet.Tables["CHF/JPY"].Copy();


            var query = from data in eurusd.AsEnumerable()
                        orderby data.Field<Double>("Profit") descending
                        select data.Field<Double>("Profit");
                        
            /*
            var query = from eu in eurusd.AsEnumerable()
                        join eg in eurgbp.AsEnumerable() on eu.Field<Int32>("Pass") equals eg.Field<Int32>("Pass")
                        join ac in audcad.AsEnumerable() on eg.Field<Int32>("Pass") equals ac.Field<Int32>("Pass")
                        join an in audnzd.AsEnumerable() on ac.Field<Int32>("Pass") equals an.Field<Int32>("Pass")
                        join cj in chfjpy.AsEnumerable() on an.Field<Int32>("Pass") equals cj.Field<Int32>("Pass")
                        orderby eu.Field<Double>("Profit")
                        select eu.Field<Int32>("Pass");
                        */


            foreach(var item in query) {
                Console.WriteLine(item.ToString());
            }

        }

    }
}
