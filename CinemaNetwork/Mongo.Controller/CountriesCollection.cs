using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoToSql.Entities
{
    public class CountriesCollection
    {
        private List<string> countries;
        private Random randomGenerator = new Random();

        public CountriesCollection()
        {
            this.countries = new List<string>();
            this.countries.Add("Bulgaria");
            this.countries.Add("Germany");
            this.countries.Add("England");
            this.countries.Add("United States");
            this.countries.Add("Italy");
            this.countries.Add("France");
            this.countries.Add("Spain");
            this.countries.Add("Australia");
        }

        public Country GetRandomCountry()
        {
            var index = this.randomGenerator.Next(0, this.countries.Count);
            var countryName = countries[index];
            return new Country(index, countryName);
        }
    }
}
