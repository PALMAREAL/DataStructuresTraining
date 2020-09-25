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
            Player otherPlayer = obj as Player;

            if (otherPlayer == null)
                return false;

            return (Name == otherPlayer.Name) &&
                   (Surname == otherPlayer.Surname) &&
                   (Gender == otherPlayer.Gender) &&
                   (Birthday == otherPlayer.Birthday) &&
                   (Weight == otherPlayer.Weight) &&
                   (Elo == otherPlayer.Elo);
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return (Name.GetHashCode() * 11) +
                   (Surname.GetHashCode() * 13) +
                   (Gender.GetHashCode() * 17) +
                   (Birthday.GetHashCode() * 7) +
                   (Weight.GetHashCode() * 19) +
                   (Elo.GetHashCode() * 5);
        }
    }
}
