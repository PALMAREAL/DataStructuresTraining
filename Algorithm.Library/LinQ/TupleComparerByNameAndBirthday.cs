using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Text;

namespace Algorithm.Library.LinQ
{
    public class TupleComparerByNameAndBirthday : IEqualityComparer<Tuple<string, DateTime>>
    {
        public bool Equals([AllowNull] Tuple<string, DateTime> x, [AllowNull] Tuple<string, DateTime> y)
        {
            return x.Item1.Equals(y.Item1, StringComparison.OrdinalIgnoreCase) && 
                   x.Item2 == y.Item2;
        }

        public int GetHashCode([DisallowNull] Tuple<string, DateTime> obj)
        {
            return obj.Item1.GetHashCode() * 11 + obj.Item2.GetHashCode() * 13;
        }
    }
}

