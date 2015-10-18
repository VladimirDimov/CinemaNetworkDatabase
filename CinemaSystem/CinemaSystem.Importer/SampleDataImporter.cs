using System.Reflection;
using CinemaSystem.Data;

namespace CinemaSystem.Importer
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Reflection;

    public class SampleDataImporter
    {
        private TextWriter textWriter;

        private SampleDataImporter(TextWriter textWriter)
        {
            this.textWriter = textWriter;
        }

        public static  SampleDataImporter Create(TextWriter textWriter)
        {
            return new SampleDataImporter(textWriter);
        }

        /// <summary>
        /// Get the current assembly then get the types => 
        /// where t is assigneble and is not interface nor abstract
        /// </summary>
        public void Import()
        {
            Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(t => typeof (IImporter).IsAssignableFrom(t)
                            && !t.IsInterface)
                .Select(Activator.CreateInstance)
                .OfType<IImporter>()
                .OrderBy(i => i.Order)
                .ToList()
                .ForEach(i =>
                {
                    var db = new CinameEntities();
                    textWriter.WriteLine(i.Message);
                    i.Get(db, this.textWriter);
                });
        }

    }
}
