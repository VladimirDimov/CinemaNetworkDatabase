using System.Runtime.CompilerServices;

namespace SqlToExcelExporter
{
    using System;
    using System.Collections.Generic;
    using System.Data.OleDb;
    using System.Linq;
    using System.Text;
    using CinemaNetwork.Models;


    public class SqlToExcel
    {
        private string connectionString =
            "Provider=Microsoft.Jet.OleDb.4.0; Data Source=D:../../MySamplefile.xls; Extended Properties=Excel 8.0;";

        public static void WriteDataToExcelFile(IList<string> stringEntities, IList<int> numberEntities )
        {
            var connectionString = GetConnectionString();
            using (var oleDbConnection = new OleDbConnection(connectionString))
            {
                oleDbConnection.Open();

                for (int i = 0; i < stringEntities.Count; i++)
                {
                    var sheetName = GetSheetName(oleDbConnection);
                    var cmd = GetCommand(oleDbConnection, sheetName, stringEntities[i], numberEntities[i]);
                    var queryResult = cmd.ExecuteNonQuery();
                    Console.WriteLine("({0} row(s) affected)", queryResult);
                }
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

        private static OleDbCommand GetCommand(OleDbConnection oleDbConnection, string sheetName, string country, int numberOfMovies)
        {
            var cmd = new OleDbCommand("INSERT INTO [" + sheetName + "] VALUES (@country , @numberOfMovies)", oleDbConnection);

            cmd.Parameters.AddWithValue("@country", country);
            cmd.Parameters.AddWithValue("@numberOfMovies", numberOfMovies);

            return cmd;
        }
    }


}
