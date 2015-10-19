namespace ExcelImporterConsole.Controller
{
    public class ImporterEntryPoint
    {
        static void Main()
        {
            System.Console.WriteLine("Importing started:");
            ExcelImporter.ImportTowns("towns.xls");
            System.Console.WriteLine("Imported completed successfully!");
        }
    }
}
