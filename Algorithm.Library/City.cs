using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.Library
{
    public class City
    {
        public int Id { get; set; }

        public string Name { get; set; }

        // override object.Equals
        public override bool Equals(object obj)
        {
            City otherCity = obj as City;

            if (otherCity == null)
                return false;

            return (Id == otherCity.Id) && (Name == otherCity.Name);
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return (Id.GetHashCode() * 11) + (Name.GetHashCode() * 13);
        }
    }
}
