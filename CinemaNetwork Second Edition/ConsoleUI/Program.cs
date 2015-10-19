namespace ConsoleUI
{
    using Mongo.Controller;
    using Pdf.Controller;
    using RandomGenerators;
    using System;
    using Xml.Controller;
    using XmlReporter.Generators;

    class Program
    {
        static void Main()
        {
            Console.WriteLine("Generate mongo data: 1");
            Console.WriteLine("Send mongo data to SQL: 2");
            Console.WriteLine("Generate and send random movies and generate xml: 3");
            Console.WriteLine("Generate PDF Report: 4");
            Console.WriteLine("Generate XML report: 5");

            var mongoController = new MongoDbController("People", "mongodb://127.0.0.1");
            var xmlController = new XmlRandomDataGenerator(new RandomGenerator(), 10, 20);
            var xmlReportGenerator = new XmlReportGenerator();

            while (true)
            {
                var command = Console.ReadLine();

                if (command == "1")
                {
                    mongoController.GenerateRandomData(20);
                }
                else if (command == "2")
                {
                    mongoController.UploadDataToSql();
                }
                else if (command == "3")
                {
                    xmlController.GenerateRandomData("../../../output.xml");
                }
                else if (command == "4")
                {
                    var pdfController = new PdfController();
                    pdfController.CreatePdf("../../../Pdf_Report.pdf");
                }
                else if (command == "5")
                {
                    xmlReportGenerator.Generate("../../../xmlReport.xml");
                }
            }
        }
    }
}
