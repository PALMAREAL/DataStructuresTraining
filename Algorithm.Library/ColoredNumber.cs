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
            //       
            // See the full list of guidelines at
            //   http://go.microsoft.com/fwlink/?LinkID=85237  
            // and also the guidance for operator== at
            //   http://go.microsoft.com/fwlink/?LinkId=85238
            //

            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            // TODO: write your implementation of Equals() here
            throw new System.NotImplementedException();
            return base.Equals(obj);
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            // TODO: write your implementation of GetHashCode() here
            throw new System.NotImplementedException();
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }

    }
}