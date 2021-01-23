using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CountryApi.Models
{
    public class FunFact
    {
        public int Id { get; set; }
        public string Fact { get; set; }
        [JsonIgnore] public Country Country { get; set; }

        public FunFact()
        {
            Id = default;
            Fact = default;
            Country = default;
        }
        public FunFact(string fact, Country country)
        {
            Id = default;
            Country = country;
            Fact = fact;
        }
        public FunFact(FunFact funFact)
        {
            Id = funFact.Id;
            Fact = funFact.Fact;
            Country = funFact.Country;
        }
    }
}
