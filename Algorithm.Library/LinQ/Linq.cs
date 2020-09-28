using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;
using System.Net.Http.Headers;
using System.Globalization;
using System.Drawing;

namespace Algorithm.Library.LinQ
{
    public class Linq
    {
        public IEnumerable<Player> Data { get; set; }

        public Linq(IEnumerable<Player> data)
        {
            Data = data;
        }


        /// <summary>
        /// 1. Confirm if exist a player olther than...
        /// </summary>
        /// <param name="age"></param>
        /// <returns></returns>
        public bool ExistPlayerOlderThan(int age)
        {
            if (age <= 0)
                throw new ArgumentException("The age must be valid");

            return Data.Any(player => GetAge(player.Birthday) > age);
        }

        private int GetAge(DateTime birthday)
        {
            if (birthday == null)
                throw new ArgumentException("The birthday must be valid");

            int age = DateTime.Today.Year - birthday.Year;

            // No es exacto
            if (birthday.Month > DateTime.Now.Month)
                --age;

            return age;
        }

        /// <summary>
        /// 2. Count all femmale players
        /// </summary>
        /// <returns></returns>
        public int CountFemmalePlayers()
        {
            //return Data.Count(player => player.Gender == 'F');

            return Data.Where(player => player.Gender == 'F').Count();
        }

        /// <summary>
        /// 3. Confirm if exist a Name in players list.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool ExistPlayerNamed(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("The name must be valid");

            return Data.Any(player =>
                player.Name.Equals(name, StringComparison.OrdinalIgnoreCase) || 
                player.Surname.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        ///4. Get the initial position for a player
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public int PlayerPositionInitialList(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("The name must be valid");

            return Data.Select((player, i) =>
                new
                {
                    Item = player,
                    Index = i
                })
                .Where(x => x.Item.Name.Equals(name, StringComparison.OrdinalIgnoreCase) || 
                            x.Item.Surname.Equals(name, StringComparison.OrdinalIgnoreCase))
                .FirstOrDefault().Index + 1;
        }

        /// <summary>
        /// 5. Get the ranking position from name
        /// </summary>
        /// <param name="name"></param>>
        /// <returns></returns>
        public int PlayerRankingPosition(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("The name must be valid");

            return Data.OrderByDescending(player => player.Elo)
                .Select((player, index) =>
                new
                {
                    player.Name, 
                    player.Surname,
                    index
                })
                .Where(x => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase) || 
                            x.Surname.Equals(name, StringComparison.OrdinalIgnoreCase))
                .FirstOrDefault().index + 1;
                }

        /// <summary>
        ///6. Calculate Elo average from all players
        /// </summary>
        /// <returns></returns>
        public double PlayersEloAverage()
        {
            return Data.Average(player => player.Elo);
        }

        /// <summary>
        /// 7. Calculate weight from a range off elo
        /// </summary>
        /// <returns></returns>
        public double TotalWeightFromEloRange(uint initialElo, uint lastElo)
        {
            if (initialElo > lastElo)
                throw new ArgumentException("The lasElo must be bigger than initialElo");

            return Data.Where(player => player.Elo >= initialElo && player.Elo <= lastElo)
               .Sum(player => player.Weight);
        }

        /// <summary>
        /// 8.Return Surname and ELO in Ascendent sort by birthday
        /// </summary>
        /// <returns></returns>
        public List<Tuple<string, int>> SurnameAndEloSortAscByBirthday()
        {
            return Data.OrderBy(player => player.Birthday.Year)
                .Select(player => Tuple.Create(player.Surname, player.Elo))
                .ToList();
        }

        /// <summary>
        /// 9. Return 'Men' 'Women' or 'Equal' depending of proportion.
        /// </summary>
        /// <returns></returns>
        public string EvaluateMenWomenProportion()
        {
            int menPlayers = Data.Count(player => player.Gender == 'M');
            int womenPlayers = Data.Count(player => player.Gender == 'F');

            return GetStrMaxGender(menPlayers, womenPlayers);
        }

        private string GetStrMaxGender(int menPlayers, int womenPlayers) =>
            menPlayers.CompareTo(womenPlayers) switch
            {
                1  => "Men",
                -1 => "Woman",
                _  => "Draw"
            };

        /// <summary>
        /// 10. Get male players with A or J or G as initial character in name.
        /// </summary>
        /// <returns></returns>
        public List<Player> MalesNamesWithFirstChar()
        {
            return Data.Where(player => player.Gender.ToString().Equals("M", StringComparison.OrdinalIgnoreCase) &&
                                        (player.Name.StartsWith("A", StringComparison.OrdinalIgnoreCase) ||
                                        player.Name.StartsWith("J", StringComparison.OrdinalIgnoreCase) ||
                                        player.Name.StartsWith("G", StringComparison.OrdinalIgnoreCase)))
                .ToList();
        }

        /// <summary>
        /// 11. Return Players containing char 'a' and 'o' in Surname
        /// </summary>
        /// <returns></returns>
        public List<Player> PlayersSurnamedContains(char first, char second)
        {
            return Data.Where(player => player.Surname.Contains(first, StringComparison.OrdinalIgnoreCase) &&
                                        player.Surname.Contains(second, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }


        /// <summary>
        /// 12. Return Players containing 'a' and 'o' in Surname in this order.
        /// </summary>
        /// <returns></returns>
        public List<Player> PlayersSurnamedContainsInThisOrder(char first, char second)
        {
            return Data.Where(player =>
                player.Surname.Contains(first, StringComparison.OrdinalIgnoreCase) &&
                player.Surname.Contains(second, StringComparison.OrdinalIgnoreCase))
                .Where(player => player.Surname.IndexOf(first, StringComparison.OrdinalIgnoreCase) < 
                                 player.Surname.IndexOf(second, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        /// <summary>
        /// 13.
        /// </summary>
        /// <param name="minWeight"></param> 
        /// <param name="maxWeight"></param>
        /// <returns></returns>
        public List<Tuple<string, int>> NameAndBirthYear(double minWeight, double maxWeight)
        {
            return Data.Where(player => player.Weight >= minWeight && player.Weight <= maxWeight)
                       .Select(player => Tuple.Create(player.Name, player.Birthday.Year))
                       .ToList();
        }


        /// <summary>
        /// 14.
        /// </summary>
        /// <returns></returns>
        public List<Tuple<string, Color>> NameAndColor()
        {
            return Data.OrderBy(player => player.Weight)
                       .Select(player => Tuple.Create(player.Name, GetColor(player.Weight)))
                       .ToList();
        }


        private Color GetColor(double weight) =>
                        weight switch
                        {
                             var x when x > 80 => Color.Red,
                             var x when x > 65 => Color.Yellow,
                             _ => Color.Green
                        };

        /// <summary>
        /// 15. 
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public List<Tuple<string, Color>> NameAndColorTop(int count)
        {
            if (count <= 0)
                throw new ArgumentException("The count must be non negative");

            return Data.OrderBy(player => player.Weight)
                       .Select(player => Tuple.Create(player.Name, GetColor(player.Weight)))
                       .Take(count)
                       .ToList();
        }

        /// <summary>
        /// 16. Get Surname and Gender from Elo and return format
        /// </summary>
        /// <param name="elo"></param>
        /// <returns></returns>
        public List<Tuple<string, string>> SurnameAndGenderOverElo(int elo)
        {
            if (elo <= 0)
                throw new ArgumentException("The elo must be non negative");

            return Data.Where(player => player.Elo > elo)
                       .Select(player => Tuple.Create(player.Surname, GetStrGender(player.Gender)))
                       .ToList();
        }

        private string GetStrGender(char gender) =>
                              gender switch
                              {
                                  'F' => "Female",
                                  'M' => "Male",
                                  'f' => "Female",
                                  'm' => "Male",
                                   _  => string.Empty
                              };

        /// <summary>
        ///  17. Get Name and Elo from player born after some date
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public List<Tuple<string, int>> NameAndEloPlayersBornAfter(DateTime dateTime)
        {
           return Data.Where(player => player.Birthday >= dateTime)
                 .Select(player => Tuple.Create(player.Name, player.Elo))
                 .ToList();
        }

        /// <summary>
        /// 18. Get Name-Surname and Birthday Sort Desc by Ranking
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public List<Tuple<string, DateTime>> FullNameAndBirthdayDescSortByRanking(int count)
        {
            var x = Data.OrderByDescending(player => player.Elo)
                .Take(count)
                .Select(player => Tuple.Create(GetFullName(player.Name, player.Surname), player.Birthday.Date))
                .ToList();

            return x;
        }

        private string GetFullName(string name, string surname)
        {
           return string.Format("{0}-{1}", name, surname);
        }
    }
}
