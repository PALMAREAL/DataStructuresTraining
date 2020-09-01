using System;
using System.Drawing;

namespace Algorithm.Library
{
    public class ColoredNumber
    {
        public int Number { get; set; }

        public Color Color { get; set; }

        public ColoredNumber()
        {

        }
        
        public ColoredNumber(int number, Color color )
        {
            Number = number;
            Color = color;
        }

        // override object.Equals
        public override bool Equals(object obj)
        {
            // Option 01 Microsoft implementacion by default
            //if (obj == null || GetType() != obj.GetType())
            //{
            //    return false;
            //}

            // TODO: write your implementation of Equals() here
            
            //ColoredNumber otherColoredNumber = (ColoredNumber)obj;

            //return (Color == otherColoredNumber.Color)
            //    && (Number == otherColoredNumber.Number);

            
            // Option 02

            ColoredNumber otherColoredNumber = obj as ColoredNumber;

            if (otherColoredNumber == null) return false;

            return (Color == otherColoredNumber.Color)
                && (Number == otherColoredNumber.Number);
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return Color.GetHashCode() * 17 + Number.GetHashCode() * 13;
        }

        public override string ToString()
        {
            return String.Format("Number:{0} - Type:{1} - Color:{2} ",
               Number.ToString(),
               Number % 2 == 0 ? "Par" : "Impar",
               Color.ToString());
        }
    }
}