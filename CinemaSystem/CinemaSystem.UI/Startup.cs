namespace CinemaSystem.UI
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using CinemaSystem.Importer;

    public class Startup
    {
        public static void Main()
        {
            SampleDataImporter.Create(Console.Out).Import();
        }
    }
}
