namespace ExcelImporterConsole.Controller
{
    public class ImporterEntryPoint
    {
        static void Main()
        {
            ExcelImporter.ImportTowns("towns.xls");
        }
    }
}
