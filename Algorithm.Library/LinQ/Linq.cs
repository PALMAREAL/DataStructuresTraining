using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Linq;

namespace Algorithm.Library.LinQ
{
    public class Linq
    {
        private IEnumerable<Player> Data { get; set; }

        public Linq(IEnumerable<Player> data)
        {
            Data = data;
        }

        public bool ExistPlayerOlderThan(int age)
        {
            return Data.Any(player => GetAge(player.Birthday) > age);
        }

        private int GetAge(DateTime birthday)
        {
            return DateTime.Now.Year - birthday.Year;
        }

        public int CountFemmalePlayers()
        {
            //return Data.Count(player => player.Gender.ToString().ToUpper() == "F");

            return Data.Where(player => player.Gender.ToString().ToUpper() == "F").Count();
        }

        public bool ExistPlayerNamed(string name)
        {
            return Data.Any(player => 
                player.Name.Trim().ToLower() == name.Trim().ToLower() ||
                player.Surname.Trim().ToLower() == name.Trim().ToLower());
        }
    }
}
