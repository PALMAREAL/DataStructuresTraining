using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Text;

namespace Algorithm.Library.LinQ
{
    public class TupleComparerBySurnameAndGender : IEqualityComparer<Tuple<string, string>>
    {
        public bool Equals([AllowNull] Tuple<string, string> x, [AllowNull] Tuple<string, string> y)
        {
            return x.Item1.Equals(y.Item1, StringComparison.OrdinalIgnoreCase) && 
                   x.Item2.Equals(y.Item2, StringComparison.OrdinalIgnoreCase);
        }

        public int GetHashCode([DisallowNull] Tuple<string, string> obj)
        {
            return obj.Item1.GetHashCode() * 11 + obj.Item2.GetHashCode() * 13;
        }
    }
}
