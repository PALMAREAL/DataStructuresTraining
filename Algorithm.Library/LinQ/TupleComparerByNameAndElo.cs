using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Text;

namespace Algorithm.Library.LinQ
{
    public class TupleComparerByNameAndColor : IEqualityComparer<Tuple<string, Color>>
    {
        public bool Equals([AllowNull] Tuple<string, Color> x, [AllowNull] Tuple<string, Color> y)
        {
            return x.Item1.Equals(y.Item1, StringComparison.OrdinalIgnoreCase) && 
                   x.Item2.Equals(y.Item2);
        }

        public int GetHashCode([DisallowNull] Tuple<string, Color> obj)
        {
            return obj.Item1.GetHashCode() * 11 + obj.Item2.GetHashCode() * 13;
        }
    }
}
