using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.Library.LinQ
{
    public class Player
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public char Gender { get; set; }

        public DateTime Birthday { get; set; }

        public double Weight { get; set; }

        public int Elo { get; set; }


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
            throw new NotImplementedException();
            return base.Equals(obj);
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            // TODO: write your implementation of GetHashCode() here
            throw new NotImplementedException();
            return base.GetHashCode();
        }
    }
}
