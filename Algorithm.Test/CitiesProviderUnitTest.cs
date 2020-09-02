using Algorithm.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Algorithm.Test
{
    public class CitiesProviderUnitTest
    {
        [Fact]
        public void DictionaryManagement()
        {
            CitiesProvider cp = new CitiesProvider();

            var cuba = new Country() { Id = 1, Name = "Cuba", Continent = ContinentEnum.America };

            var usa = new Country() { Id = 2, Name = "USA", Continent = ContinentEnum.America };

            cp.AddCountry(cuba);

            cp.AddCountry(usa);

            Assert.Equal(2, cp.TotalCountries());

            cp.RemoveCountry(cuba);

            Assert.Equal(1, cp.TotalCountries());

            Assert.True(cp.ContainsCountry(usa));

            var miami = new City() { Id = 1, Name = "Miami" };

            var newYork = new City() { Id = 2, Name = "New York" };

            var boston = new City() { Id = 3, Name = "Boston" };

            cp.AddCity(usa, miami);

            cp.AddCity(usa, newYork);

            cp.AddCity(usa, boston);

            Assert.Equal(3, cp.TotalCitiesBy(usa));

            cp.RemoveCity(usa, boston);

            Assert.Equal(2, cp.TotalCitiesBy(usa));

            Assert.False(cp.ContainsCity(usa, boston));

            var congo = new Country() { Id = 3, Name = "Congo", Continent = ContinentEnum.Africa };

            cp.AddCountry(congo);

            Assert.True( 1 == cp.GetCountriesByContinent(ContinentEnum.Africa).Count());

            Assert.True( 1 == cp.GetCountriesByContinent(ContinentEnum.America).Count());

            var countryExpected = new Country() { Id = 2, Name = "Usa", Continent = ContinentEnum.America };

            Assert.Contains(countryExpected, cp.GetCountriesByContinent(ContinentEnum.America));
        }
    }
}
