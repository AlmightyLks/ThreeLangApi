using System.Collections.Generic;

namespace CountryApi.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public List<FunFact> FunFacts { get; set; }
        public Country()
        {
            Id = default;
            Name = default;
            Code = default;
            FunFacts = new List<FunFact>();
        }
        public Country(string name, string code, List<FunFact> funFacts = null)
        {
            Id = default;
            Name = name;
            Code = code;
            FunFacts = funFacts ?? new List<FunFact>();
        }
        public Country(Country country)
        {
            Id = country.Id;
            Name = country.Name;
            Code = country.Code;
            FunFacts = country.FunFacts;
        }
    }
}
