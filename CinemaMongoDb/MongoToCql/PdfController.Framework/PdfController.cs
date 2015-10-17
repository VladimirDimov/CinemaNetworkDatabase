namespace PdfController.Framework
{
    using iTextSharp.text;
    using iTextSharp.text.pdf;
    using PersonEntities;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class PdfController
    {
        public void createPdf(String filename)
        {
            using (FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.None))
            using (Document doc = new Document(PageSize.A4, 36, 72, 108, 180))
            {
                PdfWriter writer = PdfWriter.GetInstance(doc, fs);

                doc.Open();

                var reportCollection = this.GroupPersonByBirthYear();

                doc.Add(new Paragraph(1,"People Report"));

                foreach (var group in reportCollection)
                {
                    doc.Add(new Paragraph(" "));
                    doc.Add(new Paragraph("Year: " + group.Key));

                    foreach (var person in group)
                    {
                        doc.Add(new Paragraph(person.Name));
                    }
                }
                
                doc.Close();
            }
        }

        private IEnumerable<IGrouping<int, PersonView>> GroupPersonByBirthYear()
        {
            using (var dbContext = new CinameNetworkEntities())
            {
                var people = dbContext.Person.Select(x => new PersonView()
                {
                    Name = x.FirstName + " " + x.LastName,
                    BirthYear = x.BirthYear
                }).ToList<PersonView>();

                IEnumerable<IGrouping<int, PersonView>> groupedByYear = people.GroupBy(x => x.BirthYear);

                return groupedByYear;
            }
        }
    }
}
