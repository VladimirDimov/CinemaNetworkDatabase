namespace ExcelImporterConsole.Controller
{
    using System.Data;
    using System.Data.OleDb;
    using System.Linq;
    using CinemaNetwork.Models;
    using System.Collections.Generic;

    public class ExcelImporter
    {
        public static void ImportTowns(string filePath)
        {
            var currentDb = new CinameNetworkEntities();

            string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" + filePath + "';" +
                         "Extended Properties=\"Excel 8.0;HDR=NO;IMEX=1\";";
            OleDbConnection MyConnection = new OleDbConnection(connectionString);
            DataSet DtSet;
            OleDbDataAdapter MyCommand;
            MyCommand = new OleDbDataAdapter("select * from [Towns$]", MyConnection);
            MyCommand.TableMappings.Add("Table", "TestTable");
            DtSet = new DataSet();
            MyCommand.Fill(DtSet);

            var recordsCounter = 0;

            System.Console.WriteLine("Importing records from Excel file to database table: ");
            System.Console.WriteLine("------------------------");

            foreach (var town in DtSet.Tables[0].AsEnumerable())
            {
                if (!currentDb.Towns.Select(t => t.Name).ToList().Contains(town[0]))
                {
                    currentDb.Towns.Add(new Town { Name = town[0].ToString() });
                    System.Console.WriteLine("Record added...");
                    recordsCounter++;
                }

                else
                {
                    System.Console.WriteLine("Record found in the table.. continue");
                }
            }

            System.Console.WriteLine("------------------------");
            System.Console.WriteLine("All records added successfully!");
            System.Console.WriteLine("Number of added records: {0}", recordsCounter);

            currentDb.SaveChanges();

            MyConnection.Close();

        }
    }
}
