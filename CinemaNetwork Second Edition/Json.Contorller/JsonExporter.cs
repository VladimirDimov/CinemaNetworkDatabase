namespace Json.Contorller
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Newtonsoft.Json;


    public class JsonExporter : Exporter
    {
        private const string successfullCreationOfReports = "Reports created successfully!";
        private const string successfullSaveOfReports = "Reports saved successfully!";


        //public void Export()
        //{
        //    using (var db = new CinameNetworkEntities())
        //    {
        //        foreach (var item in db.Movies)
        //        {
        //            Console.WriteLine("MoveID: " + item.MovieId + ", Title: " + item.Title + ", Actors: " + item.Actors);
        //        }
        //    }
        //}
        public JsonExporter()
        {
            this.reportsEntries = new List<string>();
            this.fileExtention = ".json";
            this.folderExtention = "Json-Reports";
        }

        public override string CreateReportEntry<T>(T item)
        {
            try
            {
                this.objectType = item.GetType().ToString().Split('.')[1];
                this.reportsEntries.Add((JsonConvert.SerializeObject(item, Formatting.Indented,
                    new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects })));

                return Messages.successfullCreationOfReports;
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        public override string SaveReport(string path)
        {
            path = DirectoryCreator.AddExtention(path, this.folderExtention);
            try
            {
                DirectoryCreator.CreateDirectoryIfNonExist(path);
                foreach (var reportEntry in this.reportsEntries)
                {
                    var fileName = this.reportsEntries.IndexOf(reportEntry) + 1 + this.fileExtention;
                    using (
                        var jsonReportFile = new StreamWriter(string.Format("{0}\\{1}", path, fileName), true))
                    {
                        jsonReportFile.Write(reportEntry);
                    }
                }
                return Messages.successfullSaveOfReports;
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
    }
}


