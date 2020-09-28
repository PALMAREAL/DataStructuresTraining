using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Text;

namespace Algorithm.Library.LinQ
{
    public class TupleComparerByNameAndElo : IEqualityComparer<Tuple<string, int>>
    {
        public bool Equals([AllowNull] Tuple<string, int> x, [AllowNull] Tuple<string, int> y)
        {
            return x.Item1.Equals(y.Item1, StringComparison.OrdinalIgnoreCase) && 
                   x.Item2 == y.Item2;
        }

        public int GetHashCode([DisallowNull] Tuple<string, int> obj)
        {
            return obj.Item1.GetHashCode() * 11 + obj.Item2.GetHashCode() * 13;
        }
    }
}

