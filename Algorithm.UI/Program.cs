using Algorithm.Library;
using System;
using System.Collections.Generic;

namespace Algorithm.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            //Algorithm 01
            var input = new List<int>() { -4, 7, 2, 9, -5, 8, 22, 1 };

            var result = Algorithms.ProcessList(input, 5);

            foreach (var item in result)
                Console.WriteLine(item);
            
        }
    }
}
