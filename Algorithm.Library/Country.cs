using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.Library
{
    public class Country
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ContinentEnum Continent { get; set; }

        // override object.Equals
        public override bool Equals(object obj)
        {
            Country otherCountry = obj as Country;

            if (otherCountry == null)
                return false;

            return (Id == otherCountry.Id)
                && (Name.ToLower() == otherCountry.Name.ToLower())
                && (Continent == otherCountry.Continent);
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return Id.GetHashCode() * 11 
                 + Name.GetHashCode() * 13 
                 + Continent.GetHashCode() * 17;
        }
    }
}
