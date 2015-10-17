namespace Application
{
    using PersonEntities;
    using System;
    using PdfController.Framework;

    public class Program
    {
        public static void Main()
        {
            var controller = new PersonEntitiesController();

            //while (true)
            //{
            //    Console.Write("Enter command: ");
            //    var command = Console.ReadLine();
            //    controller.ExecuteCommand(command);
            //}

            var pdfController = new PdfController();
            pdfController.createPdf("../../../test.pdf");
        }
    }
}
