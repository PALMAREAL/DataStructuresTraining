using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.Library.LinQ
{
    public class Player
    {
        private string _name;

        public string Name 
        {
            get 
            { 
                return _name; 
            }

            set 
            { 
                _name = (!string.IsNullOrEmpty(value)) 
                    ? value.Trim()
                    : string.Empty; 
            } 
        }

        private string _surname;

        public string Surname
        {
            get
            {
                return _surname;
            }

            set
            {
                _surname = (!string.IsNullOrEmpty(value))
                    ? value.Trim().ToUpper()
                    : string.Empty;
            }
        }

        private char _gender;

        public char Gender
        {
            get
            {
                return _gender;
            }

            set
            {
                _gender = (!char.IsWhiteSpace(value))
                    ? char.ToUpper(value)
                    : ' ';
            }
        }

        public DateTime Birthday { get; set; }

        public double Weight { get; set; }

        public uint Elo { get; set; }


        // override object.Equals
        public override bool Equals(object obj)
        {
            Player otherPlayer = obj as Player;

            if (otherPlayer == null)
                return false;

            return (Name == otherPlayer.Name) &&
                   (Surname == otherPlayer.Surname) &&
                   (Gender == otherPlayer.Gender) &&
                   (Birthday == otherPlayer.Birthday);
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return (Name.GetHashCode() * 11) +
                   (Surname.GetHashCode() * 13) +
                   (Gender.GetHashCode() * 17) +
                   (Birthday.GetHashCode() * 7);
        }
    }
}
