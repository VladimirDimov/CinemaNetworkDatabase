namespace PdfController.Framework
{
    class PersonView
    {
        public PersonView()
        {

        }

        public PersonView(string name, int birthYear)
        {
            this.Name = name;
            this.BirthYear = birthYear;
        }

        public string Name { get; set; }

        public int BirthYear { get; set; }
    }
}
