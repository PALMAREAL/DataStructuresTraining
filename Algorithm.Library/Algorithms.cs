using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Algorithm.Library
{
    public class Algorithms
    {
        /// <summary>
        /// Take the N first positive value from input list
        /// The the even numbers are red, the odd nubers are green
        /// </summary>
        /// <param name="input"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static List<ColoredNumber> ProcessList(List<int> input, int count)
        {
            if (input == null 
                || !input.Any()
                || count <= 0
                || input.Count < count)
                throw new ArgumentException("The inputs must be valid");

            List<ColoredNumber> result = new List<ColoredNumber>();

            //Option 01
            foreach (var item in input)
            {
                if (item < 0)
                    continue;

                if (item % 2 == 0)
                    result.Add(new ColoredNumber(item,Color.Red));

                else
                    result.Add(new ColoredNumber(item, Color.Green));

                if (result.Count == count)
                    break;
            }

            // Option 02 PRO
            //foreach (var item in input)
            //{
            //    if (item < 0)
            //        continue;

            //    var color = (item % 2 == 0)
            //            ? Color.Red
            //            : Color.Green;

            //    result.Add(new ColoredNumber(color, item));

            //    if (result.Count == count)
            //        break;
            //}

            
            // Option 03
            var i = 0;

            while (result.Count < count)
            {
                if (input[i] > 0)
                {
                    var color = (input[i] % 2 == 0)
                         ? Color.Red
                         : Color.Green;

                    result.Add(new ColoredNumber(input[i], color));
                }

                i++;
            }

            return result;
        }

        /// <summary>
        /// Displace array n positions 
        /// </summary>
        /// <param name="baseArray"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int[] DisplaceArray(int[] baseArray, int n)
        {
            if (baseArray == null
                || !baseArray.Any()
                || n < 0)
                throw new ArgumentException("The inputs must be valid");

            if (n >= baseArray.Length
                && n % baseArray.Length == 0)
                return baseArray;

            int[] result = new int[baseArray.Length];

            return result;
        }
    }
}