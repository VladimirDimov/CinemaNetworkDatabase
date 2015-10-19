using CinemaNetwork.Models;

namespace SqlToExcelExporter
{
    using System;
    using System.Collections.Generic;
    using System.Data.OleDb;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class SqlToExcel
    {
        private string connectionString =
            "Provider=Microsoft.Jet.OleDb.4.0; Data Source=D:../../MySamplefile.xls; Extended Properties=Excel 8.0;";

        public static void WriteDataToExcelFile()
        {
            var connectionString = GetConnectionString();
            using (var oleDbConnection = new OleDbConnection(connectionString))
            {
                oleDbConnection.Open();
                var sheetName = GetSheetName(oleDbConnection);
                var cmd = GetCommand(oleDbConnection, sheetName);

                var queryResult = cmd.ExecuteNonQuery();
                Console.WriteLine("({0} row(s) affected)", queryResult);
            }
        }

        private static string GetConnectionString()
        {

            var props = new Dictionary<string, string>();
            props["Provider"] = "Microsoft.Jet.OLEDB.4.0";
            props["Extended Properties"] = "Excel 8.0";
            props["Data Source"] = "../../MySamplefile.xls";

            var sb = new StringBuilder();
            foreach (var prop in props)
            {
                sb.Append(prop.Key);
                sb.Append('=');
                sb.Append(prop.Value);
                sb.Append(';');
            }

            return sb.ToString();
        }

        private static string GetSheetName(OleDbConnection oleDbConnection)
        {
            var excelSchema = oleDbConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            var dataTable = excelSchema.Rows[0]["TABLE_NAME"].ToString();
            return dataTable;
        }

        private static OleDbCommand GetCommand(OleDbConnection oleDbConnection, string sheetName)
        {
            var countries = new List<string>();

            var db = new CinameNetworkEntities();

            using (db)
            {
                countries = db.Countries
                                .Select(x => x.Name)
                                .ToList();
            } 

            var cmd = new OleDbCommand("INSERT INTO [" + sheetName + "] VALUES (@name, @score)", oleDbConnection);

            for (int i = 0; i < countries.Count; i++)
            {
                cmd.Parameters.AddWithValue("@name", countries[i]);
            }

            return cmd;
        }
    }


}
