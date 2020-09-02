using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Algorithm.Library
{
    public interface ICitiesProvider
    {
        void AddCountry(Country country);

        void AddCity(Country country, City city);

        void RemoveCountry(Country country);

        void RemoveCity(Country country, City city);

        IEnumerable<Country> GetAllCountries();

        IEnumerable<Country> GetCountriesByContinent(ContinentEnum continent);

        bool ContainsCountry(Country country);

        bool ContainsCity(Country country, City city);

        int TotalCountries();

        int TotalCitiesBy(Country country);
    }
}
