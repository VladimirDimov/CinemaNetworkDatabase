namespace ExcelImporterConsole.Controller
{
    using System.Data;
    using System.Data.OleDb;
    using System.Linq;
    using CinemaNetwork.Models;

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


            currentDb.Database.ExecuteSqlCommand("delete from Towns");

            foreach (var town in DtSet.Tables[0].AsEnumerable())
            {
                currentDb.Towns.Add(new Town { Name = town[0].ToString() });
                System.Console.Write("-");
            }

            System.Console.WriteLine();

            currentDb.SaveChanges();

            MyConnection.Close();

        }
    }
}
