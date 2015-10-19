namespace Json.Contorller
{
    using System.IO;
    using System.Linq;

    public static class DirectoryCreator
    {
        public static void CreateDirectoryIfUnexistant(string directory)
        {
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }

        public static string AddExtention(string directory, string extention)
        {
            var segments = directory.Split('\\');
            if (segments[segments.Count() - 1] != extention)
            {
                directory += "\\" + extention;
            }
            return directory;
        }
    }
}
