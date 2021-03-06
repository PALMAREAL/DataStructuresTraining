using Algorithm.Library;
using System;
using System.Collections.Generic;
using System.Drawing;
using Xunit;

namespace Algorithm.Test
{
    public class UnitTest1
    {
        [Fact]
        public void ProcessList()
        {
            List<int> input = new List<int>() { -4, 7, 2, 9, -5, 8, 22, 1 };

            int count = 5;

            List<ColoredNumber> expected = new List<ColoredNumber>()
            {
                new ColoredNumber(){Number = 7, Color = Color.Green},
                new ColoredNumber(){Number = 2, Color = Color.Red},
                new ColoredNumber(9,Color.Green),
                new ColoredNumber(8,Color.Red),
                new ColoredNumber(22,Color.Red)
            };
  
            List<ColoredNumber> result = Algorithms.ProcessList(input, count);

            Assert.Equal(expected, result);
        }
    }
}
