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
        /// The even numbers are red, the odd nubers are green
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
                    result.Add(new ColoredNumber(item, Color.Red));

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
        /// Example operator ??
        /// </summary>
        /// <param name="coloredNumber"></param>
        /// <returns></returns>
        public static ColoredNumber NullableValue(ColoredNumber coloredNumber)
        {
            return coloredNumber ?? new ColoredNumber(7, Color.Green);
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="myQueue"></param>
        /// <returns></returns>
        public static int CountQueue(Queue<int> queue)
        {
            if (queue == null)
                throw new ArgumentException("The queue it's null");

            int count = 0;

            while (queue.Any())
            {
                queue.Dequeue();
                count++;
            }

            return count;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="city"></param>
        /// <param name="cities"></param>
        /// <returns></returns>
        public static bool LastCityIs(string city, Stack<string> cities)
        {
            if (cities == null)
                throw new ArgumentException("The cities are invalid");

            if (string.IsNullOrEmpty(city)
                || !cities.Any())
                return false;

            string currentCity = string.Empty;

            while (cities.Any())
                currentCity = cities.Pop();

            return city == currentCity;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="array"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int[] DisplaceArray(int[] array, int n)
        {
            if (array == null
                || !array.Any()
                || n < 0)
                throw new ArgumentException("The inputs must be valid");

            if (n >= array.Length
                && n % array.Length == 0)
                return array;

            int[] result = array;

            for (int i = 0; i < n; i++)
                result = DisplaceArray(result);

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="array"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int[] DisplaceArrayRef(int[] array, int n)
        {
            if (array == null
                || !array.Any()
                || n < 0)
                throw new ArgumentException("The inputs must be valid");

            if (n >= array.Length
                && n % array.Length == 0)
                return array;

            for (int i = 0; i < n; i++)
                DisplaceArrayRef(ref array);

            return array;
        }

        /// <summary>
        /// Displace array 1 positions 
        /// </summary>
        /// <param name="array"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        private static int[] DisplaceArray(int[] array)
        {
            int length = array.Length;

            int[] result = new int[length];

            for (int i = 0; i < length; i++)
            {
                result[i] = (i == 0)
                    ? array[length - 1]
                    : array[i - 1];
            }

            return result;
        }

        /// <summary>
        /// Displace array 1 positions 
        /// </summary>
        /// <param name="array"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        private static void DisplaceArrayRef(ref int[] array)
        {
            int length = array.Length;

            int[] result = new int[length];

            for (int i = 0; i < length; i++)
            {
                result[i] = (i == 0)
                    ? array[length - 1]
                    : array[i - 1];
            }

             array = result ;
        }

        public static int[] DisplaceArrayOpt(int[] array, int k)
        {
            var length = array.Length;

            k = (k > length)
                ? k % length
                : k;

            var result = new int[length];

            for (int i = 0; i < length; i++)
            {
                var index = (i < k)
                    ? length - k + i
                    : i - k;

                result[i] = array[index];
            }

            return result;
        }
    }
}