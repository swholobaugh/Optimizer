using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using ExcelDataReader;
using System.Security.Cryptography;

namespace Optimizer
{
    class Program
    {

        public static System.Data.DataSet dataSet = new DataSet();

        static void Main(string[] args)
        {
            //File paths: @"c:\Users\swhol\source\repos\Optimizer\EURUSD_QQEVelocity.xlsx"

            string path1 = @"c:\Users\swhol\source\repos\Optimizer\EURUSD.xlsx";
            string path2 = @"c:\Users\swhol\source\repos\Optimizer\EURGBP.xlsx";
            string path3 = @"c:\Users\swhol\source\repos\Optimizer\AUDCAD.xlsx";
            string path4 = @"c:\Users\swhol\source\repos\Optimizer\AUDNZD.xlsx";
            string path5 = @"c:\Users\swhol\source\repos\Optimizer\CHFJPY.xlsx";
            string path6 = @"c:\Users\swhol\source\repos\Optimizer\USDJPY.xlsx";
            string path7 = @"c:\Users\swhol\source\repos\Optimizer\EURJPY.xlsx";
            string path8 = @"c:\Users\swhol\source\repos\Optimizer\AUDUSD.xlsx";
            string path9 = @"c:\Users\swhol\source\repos\Optimizer\GBPUSD.xlsx";
            string path10 = @"c:\Users\swhol\source\repos\Optimizer\AUDCHF.xlsx";
            string path11 = @"c:\Users\swhol\source\repos\Optimizer\AUDJPY.xlsx";
            string path12 = @"c:\Users\swhol\source\repos\Optimizer\CADCHF.xlsx";
            string path13 = @"c:\Users\swhol\source\repos\Optimizer\EURAUD.xlsx";
            string path14 = @"c:\Users\swhol\source\repos\Optimizer\EURCAD.xlsx";
            string path15 = @"c:\Users\swhol\source\repos\Optimizer\EURCHF.xlsx";
            string path16 = @"c:\Users\swhol\source\repos\Optimizer\GBPAUD.xlsx";
            string path17 = @"c:\Users\swhol\source\repos\Optimizer\GBPCAD.xlsx";
            string path18 = @"c:\Users\swhol\source\repos\Optimizer\GBPCHF.xlsx";
            string path19 = @"c:\Users\swhol\source\repos\Optimizer\GBPJPY.xlsx";
            string path20 = @"c:\Users\swhol\source\repos\Optimizer\USDCAD.xlsx";
            string path21 = @"c:\Users\swhol\source\repos\Optimizer\USDCHF.xlsx";
            string path22 = @"c:\Users\swhol\source\repos\Optimizer\CADJPY.xlsx";
            string path23 = @"c:\Users\swhol\source\repos\Optimizer\EURNZD.xlsx";
            string path24 = @"c:\Users\swhol\source\repos\Optimizer\GBPNZD.xlsx";
            string path25 = @"c:\Users\swhol\source\repos\Optimizer\NZDCAD.xlsx";
            string path26 = @"c:\Users\swhol\source\repos\Optimizer\NZDCHF.xlsx";
            string path27 = @"c:\Users\swhol\source\repos\Optimizer\NZDJPY.xlsx";
            string path28 = @"c:\Users\swhol\source\repos\Optimizer\NZDUSD.xlsx";


            CreateDataTable("EURUSD", 3, path1);
            CreateDataTable("EURGBP", 3, path2);
            CreateDataTable("AUDCAD", 3, path3);
            CreateDataTable("AUDNZD", 3, path4);
            CreateDataTable("CHFJPY", 3, path5);
            CreateDataTable("USDJPY", 3, path6);
            CreateDataTable("EURJPY", 3, path7);
            CreateDataTable("AUDUSD", 3, path8);
            CreateDataTable("GBPUSD", 3, path9);
            CreateDataTable("AUDCHF", 3, path10);
            CreateDataTable("AUDJPY", 3, path11);
            CreateDataTable("CADCHF", 3, path12);
            CreateDataTable("EURAUD", 3, path13);
            CreateDataTable("EURCAD", 3, path14);
            CreateDataTable("EURCHF", 3, path15);
            CreateDataTable("GBPAUD", 3, path16);
            CreateDataTable("GBPCAD", 3, path17);
            CreateDataTable("GBPCHF", 3, path18);
            CreateDataTable("GBPJPY", 3, path19);
            CreateDataTable("USDCAD", 3, path20);
            CreateDataTable("USDCHF", 3, path21);
            CreateDataTable("CADJPY", 3, path22);
            CreateDataTable("EURNZD", 3, path23);
            CreateDataTable("GBPNZD", 3, path24);
            CreateDataTable("NZDCAD", 3, path25);
            CreateDataTable("NZDCHF", 3, path26);
            CreateDataTable("NZDJPY", 3, path27);
            CreateDataTable("NZDUSD", 3, path28);



            QueryDataSet();
        }

        public static void CreateDataTable(string tableName, int input, string fPath)
        {
            
            System.Data.DataTable table = new DataTable(tableName);

            DataColumn column;
            DataRow row;

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "Primary Key";
            column.ReadOnly = true;
            column.Unique = true;
            table.Columns.Add(column);

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


            if (input > 4)
            {
                for (int x = 0; x < input; x++)
                {
                    column = new DataColumn();
                    column.DataType = System.Type.GetType("System.Double");
                    column.ColumnName = $"{input + 4}";
                    column.ReadOnly = true;
                    column.Unique = true;
                    table.Columns.Add(column);
                }
            }

            dataSet.Tables.Add(table);

            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            using (var stream = File.Open(fPath, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {

                    for (int x = 0; x < reader.RowCount; x++)
                    {
                        reader.Read();

                        row = table.NewRow();
                        row["Primary Key"] = x;
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


        public static void QueryDataSet()
        {

            DataTable eurusd = dataSet.Tables["EURUSD"];
            DataTable eurgbp = dataSet.Tables["EURGBP"];
            DataTable audcad = dataSet.Tables["AUDCAD"];
            DataTable audnzd = dataSet.Tables["AUDNZD"];
            DataTable chfjpy = dataSet.Tables["CHFJPY"];
            DataTable usdjpy = dataSet.Tables["USDJPY"];
            DataTable eurjpy = dataSet.Tables["EURJPY"];
            DataTable audusd = dataSet.Tables["AUDUSD"];
            DataTable gbpusd = dataSet.Tables["GBPUSD"];
            DataTable audchf = dataSet.Tables["AUDCHF"];
            DataTable audjpy = dataSet.Tables["AUDJPY"];
            DataTable cadchf = dataSet.Tables["CADCHF"];
            DataTable euraud = dataSet.Tables["EURAUD"];
            DataTable eurcad = dataSet.Tables["EURCAD"];
            DataTable eurchf = dataSet.Tables["EURCHF"];
            DataTable gbpaud = dataSet.Tables["GBPAUD"];
            DataTable gbpcad = dataSet.Tables["GBPCAD"];
            DataTable gbpchf = dataSet.Tables["GBPCHF"];
            DataTable gbpjpy = dataSet.Tables["GBPJPY"];
            DataTable usdcad = dataSet.Tables["USDCAD"];
            DataTable usdchf = dataSet.Tables["USDCHF"];
            DataTable cadjpy = dataSet.Tables["CADJPY"];
            DataTable eurnzd = dataSet.Tables["EURNZD"];
            DataTable gbpnzd = dataSet.Tables["GBPNZD"];
            DataTable nzdcad = dataSet.Tables["NZDCAD"];
            DataTable nzdchf = dataSet.Tables["NZDCHF"];
            DataTable nzdjpy = dataSet.Tables["NZDJPY"];
            DataTable nzdusd = dataSet.Tables["NZDUSD"];


            DataTable resultsTable = new DataTable("Results Table");
            DataColumn column;
            DataRow row;

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "Primary Key";
            column.Unique = true;
            column.AutoIncrement = true;
            column.AutoIncrementSeed = 0;
            column.AutoIncrementStep = 1;
            resultsTable.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Pass";
            column.Unique = true;
            resultsTable.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Double");
            column.ColumnName = "Total Profit";
            resultsTable.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Double");
            column.ColumnName = "Avg Win %";
            resultsTable.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "Total Trades";
            resultsTable.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Double");
            column.ColumnName = "Avg DD %";
            resultsTable.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Double");
            column.ColumnName = "Profit Var";
            resultsTable.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Double");
            column.ColumnName = "Win % Var";
            resultsTable.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Trade String";
            resultsTable.Columns.Add(column);

            var query = from eu in eurusd.AsEnumerable()
                        join eg in eurgbp.AsEnumerable() on eu.Field<Int32>("Primary Key") equals eg.Field<Int32>("Primary Key")
                        join ac in audcad.AsEnumerable() on eg.Field<Int32>("Primary Key") equals ac.Field<Int32>("Primary Key")
                        join an in audnzd.AsEnumerable() on ac.Field<Int32>("Primary Key") equals an.Field<Int32>("Primary Key")
                        join cj in chfjpy.AsEnumerable() on an.Field<Int32>("Primary Key") equals cj.Field<Int32>("Primary Key")
                        join uj in usdjpy.AsEnumerable() on cj.Field<Int32>("Primary Key") equals uj.Field<Int32>("Primary Key")
                        join ej in eurjpy.AsEnumerable() on uj.Field<Int32>("Primary Key") equals ej.Field<Int32>("Primary Key")
                        join au in audusd.AsEnumerable() on ej.Field<Int32>("Primary Key") equals au.Field<Int32>("Primary Key")
                        join gu in gbpusd.AsEnumerable() on au.Field<Int32>("Primary Key") equals gu.Field<Int32>("Primary Key")
                        join ach in audchf.AsEnumerable() on gu.Field<Int32>("Primary Key") equals ach.Field<Int32>("Primary Key")
                        join aj in audjpy.AsEnumerable() on ach.Field<Int32>("Primary Key") equals aj.Field<Int32>("Primary Key")
                        join cc in cadchf.AsEnumerable() on aj.Field<Int32>("Primary Key") equals cc.Field<Int32>("Primary Key")
                        join ea in euraud.AsEnumerable() on cc.Field<Int32>("Primary Key") equals ea.Field<Int32>("Primary Key")
                        join ec in eurcad.AsEnumerable() on ea.Field<Int32>("Primary Key") equals ec.Field<Int32>("Primary Key")
                        join ech in eurchf.AsEnumerable() on ec.Field<Int32>("Primary Key") equals ech.Field<Int32>("Primary Key")
                        join ga in gbpaud.AsEnumerable() on ech.Field<Int32>("Primary Key") equals ga.Field<Int32>("Primary Key")
                        join gc in gbpcad.AsEnumerable() on ga.Field<Int32>("Primary Key") equals gc.Field<Int32>("Primary Key")
                        join gch in gbpchf.AsEnumerable() on gc.Field<Int32>("Primary Key") equals gch.Field<Int32>("Primary Key")
                        join gj in gbpjpy.AsEnumerable() on gch.Field<Int32>("Primary Key") equals gj.Field<Int32>("Primary Key")
                        join uc in usdcad.AsEnumerable() on gj.Field<Int32>("Primary Key") equals uc.Field<Int32>("Primary Key")
                        join uch in usdchf.AsEnumerable() on uc.Field<Int32>("Primary Key") equals uch.Field<Int32>("Primary Key")
                        join caj in cadjpy.AsEnumerable() on uch.Field<Int32>("Primary Key") equals caj.Field<Int32>("Primary Key")
                        join en in eurnzd.AsEnumerable() on caj.Field<Int32>("Primary Key") equals en.Field<Int32>("Primary Key")
                        join gn in gbpnzd.AsEnumerable() on en.Field<Int32>("Primary Key") equals gn.Field<Int32>("Primary Key")
                        join nc in nzdcad.AsEnumerable() on gn.Field<Int32>("Primary Key") equals nc.Field<Int32>("Primary Key")
                        join nch in nzdchf.AsEnumerable() on nc.Field<Int32>("Primary Key") equals nch.Field<Int32>("Primary Key")
                        join nj in nzdjpy.AsEnumerable() on nch.Field<Int32>("Primary Key") equals nj.Field<Int32>("Primary Key")
                        join nu in nzdusd.AsEnumerable() on nj.Field<Int32>("Primary Key") equals nu.Field<Int32>("Primary Key")
                        select $"{eu.Field<Int32>("Primary Key")}";
            
            foreach (var item in query)
            { 
                int index = int.Parse(item);
                string pass = index.ToString();

                double totalProfit = eurusd.Rows[index].Field<Double>("Profit")
                    + eurgbp.Rows[index].Field<Double>("Profit")
                    + audnzd.Rows[index].Field<Double>("Profit")
                    + audcad.Rows[index].Field<Double>("Profit")
                    + chfjpy.Rows[index].Field<Double>("Profit")
                    + usdjpy.Rows[index].Field<Double>("Profit")
                    + eurjpy.Rows[index].Field<Double>("Profit")
                    + audusd.Rows[index].Field<Double>("Profit")
                    + gbpusd.Rows[index].Field<Double>("Profit")
                    + audchf.Rows[index].Field<Double>("Profit")
                    + audjpy.Rows[index].Field<Double>("Profit")
                    + cadchf.Rows[index].Field<Double>("Profit")
                    + euraud.Rows[index].Field<Double>("Profit")
                    + eurcad.Rows[index].Field<Double>("Profit")
                    + eurchf.Rows[index].Field<Double>("Profit")
                    + gbpaud.Rows[index].Field<Double>("Profit")
                    + gbpcad.Rows[index].Field<Double>("Profit")
                    + gbpchf.Rows[index].Field<Double>("Profit")
                    + gbpjpy.Rows[index].Field<Double>("Profit")
                    + usdcad.Rows[index].Field<Double>("Profit")
                    + usdchf.Rows[index].Field<Double>("Profit") 
                    + cadjpy.Rows[index].Field<Double>("Profit")
                    + eurnzd.Rows[index].Field<Double>("Profit")
                    + gbpnzd.Rows[index].Field<Double>("Profit")
                    + nzdcad.Rows[index].Field<Double>("Profit")
                    + nzdchf.Rows[index].Field<Double>("Profit")
                    + nzdjpy.Rows[index].Field<Double>("Profit")
                    + nzdusd.Rows[index].Field<Double>("Profit");

                double avgProfit = ((eurusd.Rows[index].Field<Double>("Profit")
                    + eurgbp.Rows[index].Field<Double>("Profit")
                    + audnzd.Rows[index].Field<Double>("Profit")
                    + audcad.Rows[index].Field<Double>("Profit")
                    + chfjpy.Rows[index].Field<Double>("Profit")
                    + usdjpy.Rows[index].Field<Double>("Profit")
                    + eurjpy.Rows[index].Field<Double>("Profit")
                    + audusd.Rows[index].Field<Double>("Profit")
                    + gbpusd.Rows[index].Field<Double>("Profit")
                    + audchf.Rows[index].Field<Double>("Profit")
                    + audjpy.Rows[index].Field<Double>("Profit")
                    + cadchf.Rows[index].Field<Double>("Profit")
                    + euraud.Rows[index].Field<Double>("Profit")
                    + eurcad.Rows[index].Field<Double>("Profit")
                    + eurchf.Rows[index].Field<Double>("Profit")
                    + gbpaud.Rows[index].Field<Double>("Profit")
                    + gbpcad.Rows[index].Field<Double>("Profit")
                    + gbpchf.Rows[index].Field<Double>("Profit")
                    + gbpjpy.Rows[index].Field<Double>("Profit")
                    + usdcad.Rows[index].Field<Double>("Profit")
                    + usdchf.Rows[index].Field<Double>("Profit")
                    + cadjpy.Rows[index].Field<Double>("Profit")
                    + eurnzd.Rows[index].Field<Double>("Profit")
                    + gbpnzd.Rows[index].Field<Double>("Profit")
                    + nzdcad.Rows[index].Field<Double>("Profit")
                    + nzdchf.Rows[index].Field<Double>("Profit")
                    + nzdjpy.Rows[index].Field<Double>("Profit")
                    + nzdusd.Rows[index].Field<Double>("Profit")) / 28);

                double avgWinPercent = ((eurusd.Rows[index].Field<Double>("OnTesterResult")
                    + eurgbp.Rows[index].Field<Double>("OnTesterResult")
                    + audnzd.Rows[index].Field<Double>("OnTesterResult")
                    + audcad.Rows[index].Field<Double>("OnTesterResult")
                    + chfjpy.Rows[index].Field<Double>("OnTesterResult")
                    + usdjpy.Rows[index].Field<Double>("OnTesterResult")
                    + eurjpy.Rows[index].Field<Double>("OnTesterResult")
                    + audusd.Rows[index].Field<Double>("OnTesterResult")
                    + gbpusd.Rows[index].Field<Double>("OnTesterResult")
                    + audchf.Rows[index].Field<Double>("OnTesterResult")
                    + audjpy.Rows[index].Field<Double>("OnTesterResult")
                    + cadchf.Rows[index].Field<Double>("OnTesterResult")
                    + euraud.Rows[index].Field<Double>("OnTesterResult")
                    + eurcad.Rows[index].Field<Double>("OnTesterResult")
                    + eurchf.Rows[index].Field<Double>("OnTesterResult")
                    + gbpaud.Rows[index].Field<Double>("OnTesterResult")
                    + gbpcad.Rows[index].Field<Double>("OnTesterResult")
                    + gbpchf.Rows[index].Field<Double>("OnTesterResult")
                    + gbpjpy.Rows[index].Field<Double>("OnTesterResult")
                    + usdcad.Rows[index].Field<Double>("OnTesterResult")
                    + usdchf.Rows[index].Field<Double>("OnTesterResult")
                    + cadjpy.Rows[index].Field<Double>("OnTesterResult")
                    + eurnzd.Rows[index].Field<Double>("OnTesterResult")
                    + gbpnzd.Rows[index].Field<Double>("OnTesterResult")
                    + nzdcad.Rows[index].Field<Double>("OnTesterResult")
                    + nzdchf.Rows[index].Field<Double>("OnTesterResult")
                    + nzdjpy.Rows[index].Field<Double>("OnTesterResult")
                    + nzdusd.Rows[index].Field<Double>("OnTesterResult")) / 28);

                double avgDDPct = ((eurusd.Rows[index].Field<Double>("Drawdown %")
                    + eurgbp.Rows[index].Field<Double>("Drawdown %")
                    + audnzd.Rows[index].Field<Double>("Drawdown %")
                    + audcad.Rows[index].Field<Double>("Drawdown %")
                    + chfjpy.Rows[index].Field<Double>("Drawdown %")
                    + usdjpy.Rows[index].Field<Double>("Drawdown %")
                    + eurjpy.Rows[index].Field<Double>("Drawdown %")
                    + audusd.Rows[index].Field<Double>("Drawdown %")
                    + gbpusd.Rows[index].Field<Double>("Drawdown %")
                    + audchf.Rows[index].Field<Double>("Drawdown %")
                    + audjpy.Rows[index].Field<Double>("Drawdown %")
                    + cadchf.Rows[index].Field<Double>("Drawdown %")
                    + euraud.Rows[index].Field<Double>("Drawdown %")
                    + eurcad.Rows[index].Field<Double>("Drawdown %")
                    + eurchf.Rows[index].Field<Double>("Drawdown %")
                    + gbpaud.Rows[index].Field<Double>("Drawdown %")
                    + gbpcad.Rows[index].Field<Double>("Drawdown %")
                    + gbpchf.Rows[index].Field<Double>("Drawdown %")
                    + gbpjpy.Rows[index].Field<Double>("Drawdown %")
                    + usdcad.Rows[index].Field<Double>("Drawdown %")
                    + usdchf.Rows[index].Field<Double>("Drawdown %")
                    + cadjpy.Rows[index].Field<Double>("Drawdown %")
                    + eurnzd.Rows[index].Field<Double>("Drawdown %")
                    + gbpnzd.Rows[index].Field<Double>("Drawdown %")
                    + nzdcad.Rows[index].Field<Double>("Drawdown %")
                    + nzdchf.Rows[index].Field<Double>("Drawdown %")
                    + nzdjpy.Rows[index].Field<Double>("Drawdown %")
                    + nzdusd.Rows[index].Field<Double>("Drawdown %")) / 28);

                int totalTrades = eurusd.Rows[index].Field<Int32>("Total Trades")
                    + eurgbp.Rows[index].Field<Int32>("Total Trades")
                    + audnzd.Rows[index].Field<Int32>("Total Trades")
                    + audcad.Rows[index].Field<Int32>("Total Trades")
                    + chfjpy.Rows[index].Field<Int32>("Total Trades")
                    + usdjpy.Rows[index].Field<Int32>("Total Trades")
                    + eurjpy.Rows[index].Field<Int32>("Total Trades")
                    + audusd.Rows[index].Field<Int32>("Total Trades")
                    + gbpusd.Rows[index].Field<Int32>("Total Trades")
                    + audchf.Rows[index].Field<Int32>("Total Trades")
                    + audjpy.Rows[index].Field<Int32>("Total Trades")
                    + cadchf.Rows[index].Field<Int32>("Total Trades")
                    + euraud.Rows[index].Field<Int32>("Total Trades")
                    + eurcad.Rows[index].Field<Int32>("Total Trades")
                    + eurchf.Rows[index].Field<Int32>("Total Trades")
                    + gbpaud.Rows[index].Field<Int32>("Total Trades")
                    + gbpcad.Rows[index].Field<Int32>("Total Trades")
                    + gbpchf.Rows[index].Field<Int32>("Total Trades")
                    + gbpjpy.Rows[index].Field<Int32>("Total Trades")
                    + usdcad.Rows[index].Field<Int32>("Total Trades")
                    + usdchf.Rows[index].Field<Int32>("Total Trades")
                    + cadjpy.Rows[index].Field<Int32>("Total Trades")
                    + eurnzd.Rows[index].Field<Int32>("Total Trades")
                    + gbpnzd.Rows[index].Field<Int32>("Total Trades")
                    + nzdcad.Rows[index].Field<Int32>("Total Trades")
                    + nzdchf.Rows[index].Field<Int32>("Total Trades")
                    + nzdjpy.Rows[index].Field<Int32>("Total Trades")
                    + nzdusd.Rows[index].Field<Int32>("Total Trades");

                double minProfit = 100000;
                double maxProfit = 0;

                double eurusdProfit = eurusd.Rows[index].Field<Double>("Profit");
                double eurgbpProfit = eurgbp.Rows[index].Field<Double>("Profit");
                double audnzdProfit = audnzd.Rows[index].Field<Double>("Profit");
                double audcadProfit = audcad.Rows[index].Field<Double>("Profit");
                double chfjpyProfit = chfjpy.Rows[index].Field<Double>("Profit");
                double usdjpyProfit = usdjpy.Rows[index].Field<Double>("Profit");
                double eurjpyProfit = eurjpy.Rows[index].Field<Double>("Profit");
                double audusdProfit = audusd.Rows[index].Field<Double>("Profit");
                double gbpusdProfit = gbpusd.Rows[index].Field<Double>("Profit");
                double audchfProfit = audchf.Rows[index].Field<Double>("Profit");
                double audjpyProfit = audjpy.Rows[index].Field<Double>("Profit");
                double cadchfProfit = cadchf.Rows[index].Field<Double>("Profit");
                double euraudProfit = euraud.Rows[index].Field<Double>("Profit");
                double eurcadProfit = eurcad.Rows[index].Field<Double>("Profit");
                double eurchfProfit = eurchf.Rows[index].Field<Double>("Profit");
                double gbpaudProfit = gbpaud.Rows[index].Field<Double>("Profit");
                double gbpcadProfit = gbpcad.Rows[index].Field<Double>("Profit");
                double gbpchfProfit = gbpchf.Rows[index].Field<Double>("Profit");
                double gbpjpyProfit = gbpjpy.Rows[index].Field<Double>("Profit");
                double usdcadProfit = usdcad.Rows[index].Field<Double>("Profit");
                double usdchfProfit = usdchf.Rows[index].Field<Double>("Profit");
                double cadjpyProfit = cadjpy.Rows[index].Field<Double>("Profit");
                double eurnzdProfit = eurnzd.Rows[index].Field<Double>("Profit");
                double gbpnzdProfit = gbpnzd.Rows[index].Field<Double>("Profit");
                double nzdcadProfit = nzdcad.Rows[index].Field<Double>("Profit");
                double nzdchfProfit = nzdchf.Rows[index].Field<Double>("Profit");
                double nzdjpyProfit = nzdjpy.Rows[index].Field<Double>("Profit");
                double nzdusdProfit = nzdusd.Rows[index].Field<Double>("Profit");

                double[] profitArray = { eurusdProfit, eurgbpProfit, audnzdProfit, audcadProfit, chfjpyProfit,
                                         usdjpyProfit, eurjpyProfit, audusdProfit, gbpusdProfit, audchfProfit,
                                         audjpyProfit, cadchfProfit, euraudProfit, eurcadProfit, eurchfProfit,
                                         gbpaudProfit, gbpcadProfit, gbpchfProfit, gbpjpyProfit, usdcadProfit,
                                         usdchfProfit, cadjpyProfit, eurnzdProfit, gbpnzdProfit, nzdcadProfit,
                                         nzdchfProfit, nzdjpyProfit, nzdusdProfit };

                for (int y = 0; y < 28; y++)
                {
                    if (profitArray[y] <= minProfit)
                    {
                        minProfit = profitArray[y];
                    }

                    if (profitArray[y] >= maxProfit)
                    {
                        maxProfit = profitArray[y];
                    }
                }

                double profitVariance = maxProfit - minProfit;

                double minWinPct = 100;
                double maxWinPct = 0;

                double eurusdWinPct = eurusd.Rows[index].Field<Double>("OnTesterResult");
                double eurgbpWinPct = eurgbp.Rows[index].Field<Double>("OnTesterResult");
                double audnzdWinPct = audnzd.Rows[index].Field<Double>("OnTesterResult");
                double audcadWinPct = audcad.Rows[index].Field<Double>("OnTesterResult");
                double chfjpyWinPct = chfjpy.Rows[index].Field<Double>("OnTesterResult");
                double usdjpyWinPct = usdjpy.Rows[index].Field<Double>("OnTesterResult");
                double eurjpyWinPct = eurjpy.Rows[index].Field<Double>("OnTesterResult");
                double audusdWinPct = audusd.Rows[index].Field<Double>("OnTesterResult");
                double gbpusdWinPct = gbpusd.Rows[index].Field<Double>("OnTesterResult");
                double audchfWinPct = audchf.Rows[index].Field<Double>("OnTesterResult");
                double audjpyWinPct = audjpy.Rows[index].Field<Double>("OnTesterResult");
                double cadchfWinPct = cadchf.Rows[index].Field<Double>("OnTesterResult");
                double euraudWinPct = euraud.Rows[index].Field<Double>("OnTesterResult");
                double eurcadWinPct = eurcad.Rows[index].Field<Double>("OnTesterResult");
                double eurchfWinPct = eurchf.Rows[index].Field<Double>("OnTesterResult");
                double gbpaudWinPct = gbpaud.Rows[index].Field<Double>("OnTesterResult");
                double gbpcadWinPct = gbpcad.Rows[index].Field<Double>("OnTesterResult");
                double gbpchfWinPct = gbpchf.Rows[index].Field<Double>("OnTesterResult");
                double gbpjpyWinPct = gbpjpy.Rows[index].Field<Double>("OnTesterResult");
                double usdcadWinPct = usdcad.Rows[index].Field<Double>("OnTesterResult");
                double usdchfWinPct = usdchf.Rows[index].Field<Double>("OnTesterResult");
                double cadjpyWinPct = cadjpy.Rows[index].Field<Double>("OnTesterResult");
                double eurnzdWinPct = eurnzd.Rows[index].Field<Double>("OnTesterResult");
                double gbpnzdWinPct = gbpnzd.Rows[index].Field<Double>("OnTesterResult");
                double nzdcadWinPct = nzdcad.Rows[index].Field<Double>("OnTesterResult");
                double nzdchfWinPct = nzdchf.Rows[index].Field<Double>("OnTesterResult");
                double nzdjpyWinPct = nzdjpy.Rows[index].Field<Double>("OnTesterResult");
                double nzdusdWinPct = nzdusd.Rows[index].Field<Double>("OnTesterResult");

                double[] winPctArray = { eurusdWinPct, eurgbpWinPct, audnzdWinPct, audcadWinPct, chfjpyWinPct, 
                                         usdjpyWinPct, eurjpyWinPct, audusdWinPct, gbpusdWinPct, audchfWinPct,
                                         audjpyWinPct, cadchfWinPct, euraudWinPct, eurcadWinPct, eurchfWinPct,
                                         gbpaudWinPct, gbpcadWinPct, gbpchfWinPct, gbpjpyWinPct, usdcadWinPct,
                                         usdchfWinPct, cadjpyWinPct, eurnzdWinPct, gbpnzdWinPct, nzdcadWinPct,
                                         nzdchfWinPct, nzdjpyWinPct, nzdusdWinPct };



                for (int y = 0; y < 28; y++)
                {
                    if (winPctArray[y] <= minWinPct)
                    {
                        minWinPct = winPctArray[y];
                    }

                    if (winPctArray[y] >= maxWinPct)
                    {
                        maxWinPct = winPctArray[y];
                    }

                }

                double winPctVariance = maxWinPct - minWinPct;

                string tradeString = //$"Total Trades: { eurusd.Rows[index].Field<Int32>("Total Trades") + eurgbp.Rows[index].Field<Int32>("Total Trades") + audcad.Rows[index].Field<Int32>("Total Trades") + audnzd.Rows[index].Field<Int32>("Total Trades") + chfjpy.Rows[index].Field<Int32>("Total Trades")}"
                $"EURUSD: {eurusdProfit:C2} EURGBP: {eurgbpProfit:C2} AUDNZD: {audnzdProfit:C2} AUDCAD: {audcadProfit:C2} CHFJPY: {chfjpyProfit:C2} ProfitVar: {profitVariance:C2}\n"
                + $"EURUSD: {eurusdWinPct:F2}% EURGBP: {eurgbpWinPct:F2}% AUDNZD: {audnzdWinPct:F2}% AUDCAD: {audcadWinPct:F2}% CHFJPY: {chfjpyWinPct:F2}% Win%Var: {winPctVariance:F2}%";

                row = resultsTable.NewRow();
                row["Pass"] = pass;
                row["Total Profit"] = totalProfit;
                row["Avg Win %"] = avgWinPercent;
                row["Total Trades"] = totalTrades;
                row["Avg DD %"] = avgDDPct;
                row["Profit Var"] = profitVariance;
                row["Win % Var"] = winPctVariance;
                row["Trade String"] = tradeString;

                resultsTable.Rows.Add(row);
            }
            dataSet.Tables.Add(resultsTable);

            queryResultsTable();
        }

        public static void queryResultsTable()
        {

            DataTable resultsTable = dataSet.Tables["Results Table"];

            var query = from result in resultsTable.AsEnumerable()
                        //where (result.Field<double>("Avg Win %") > 50) && (result.Field<double>("Total Profit") > 0)
                        where result.Field<double>("Total Profit") > 0
                        //orderby result.Field<double>("Avg Win %") descending
                        orderby result.Field<double>("Total Profit") descending
                        select result.Field<string>("Pass");

            foreach(var item in query)
            {
                int i = int.Parse(item);
                Console.WriteLine($"Pass: {resultsTable.Rows[i].Field<string>("Pass")} "
                                + $"Total Profit: {resultsTable.Rows[i].Field<double>("Total Profit"):C2} "
                                + $"Avg Win%: {resultsTable.Rows[i].Field<double>("Avg Win %"):F2}% "
                                + $"Total Trades: {resultsTable.Rows[i].Field<Int32>("Total Trades")} "
                                + $"Avg DD%: {resultsTable.Rows[i].Field<double>("Avg DD %"):F2}% "
                                + $"ProfitVar: {resultsTable.Rows[i].Field<double>("Profit Var"):C2} "
                                + $"Win%Var: {resultsTable.Rows[i].Field<double>("Win % Var"):F2} ");
                Console.WriteLine($"{resultsTable.Rows[i].Field<string>("Trade String")}\n");
            }

        }

    }
}
