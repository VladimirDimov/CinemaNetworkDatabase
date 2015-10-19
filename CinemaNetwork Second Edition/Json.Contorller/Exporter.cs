namespace Json.Contorller
{
    using System.Collections.Generic;
    public abstract class Exporter
    {
        protected string fileExtention;

        protected string folderExtention;

        protected string objectType;
        protected List<string> reportsEntries;

        public abstract string CreateReportEntry<T>(T item);

        public abstract string SaveReport(string path);
    }
}
