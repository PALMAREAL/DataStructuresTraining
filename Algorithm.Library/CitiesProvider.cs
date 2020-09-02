using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Algorithm.Library
{
    public class CitiesProvider : ICitiesProvider
    {
        private readonly Dictionary<Country, List<City>> dict;

        public CitiesProvider()
        {
            dict = new Dictionary<Country, List<City>>();
        }

        public void AddCity(Country country, City city)
        {
            if (country == null || city == null)
                return;

            List<City> cities;

            dict.TryGetValue(country, out cities);

            if (cities != null)
            {
                if (!cities.Contains(city))
                {
                    cities.Add(city);

                    dict[country] = cities;
                }
            }
        }

        public void AddCountry(Country country)
        {
            if (country == null)
                return;

            if (!dict.ContainsKey(country))
                dict.Add(country, new List<City>());
        }

        public bool ContainsCity(Country country, City city)
        {
            if (country == null || city == null)
                return false;

            List<City> cities;

            dict.TryGetValue(country, out cities);

            if (cities == null || !cities.Any())
                return false;

            return cities.Contains(city);
        }

        public bool ContainsCountry(Country country)
        {
            if (country == null)
                return false;

            return dict.ContainsKey(country);
        }

        public IEnumerable<Country> GetAllCountries()
        {
            return dict.Keys.ToList();
        }

        public IEnumerable<Country> GetCountriesByContinent(ContinentEnum continent)
        {
            return GetAllCountries().Where( c => c.Continent == continent);
        }

        public void RemoveCity(Country country, City city)
        {
            if (country == null || city == null)
                return;

            List<City> cities;

            dict.TryGetValue(country, out cities);

            if (cities == null || !cities.Any())
                return;

            cities.Remove(city);

            dict[country] = cities;
        }

        public void RemoveCountry(Country country)
        {
            if (country == null)
                return;

            dict.Remove(country);
        }

        public int TotalCountries()
        {
            return GetAllCountries().Count();
        }

        public int TotalCitiesBy(Country country)
        {
            if (country == null || !dict.ContainsKey(country))
                return 0;

            return dict[country].Count;
        }
    }
}
