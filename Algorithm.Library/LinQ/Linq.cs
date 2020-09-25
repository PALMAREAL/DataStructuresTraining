using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;
using System.Net.Http.Headers;
using System.Globalization;

namespace Algorithm.Library.LinQ
{
    public class Linq
    {
        private IEnumerable<Player> Data { get; set; }

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
            //return Data.Count(player => player.Gender.ToString().ToUpper() == "F");

            return Data.Where(player => player.Gender.ToString().ToUpper() == "F").Count();
        }

        /// <summary>
        /// 3. Confirm if exist a Name in players list.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool ExistPlayerNamed(string name)
        {
            if (name == null)
                throw new ArgumentException("The name must be valid");

            return Data.Any(player =>
                player.Name.Trim().ToLower() == name.Trim().ToLower() ||
                player.Surname.Trim().ToLower() == name.Trim().ToLower());
        }

        /// <summary>
        ///4. Get the initial position for a player
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public int PlayerPositionInitialList(string name)
        {
            if (name == null)
                throw new ArgumentException("The name must be valid");

            return Data.ToList().FindIndex(player =>
            player.Name.Trim().ToLower() == name.Trim().ToLower() ||
            player.Surname.Trim().ToLower() == name.Trim().ToLower()) + 1;
        }

        /// <summary>
        /// 5. Get the ranking position from name
        /// </summary>
        /// <param name="name"></param>>
        /// <returns></returns>
        public int PlayerRankingPosition(string name)
        {
            if (name == null)
                throw new ArgumentException("The name must be valid");

            //Option 01
            return Data.OrderByDescending(player => player.Elo).ToList().FindIndex(player =>
            player.Name.Trim().ToLower() == name.Trim().ToLower() ||
            player.Surname.Trim().ToLower() == name.Trim().ToLower()) + 1;

            //Option 02 a partir del elo 
            //return Data.Where(player => player.Elo >= elo).ToList().Count();
        }

        /// <summary>
        ///6. Calculate Elo average from all players
        /// </summary>
        /// <returns></returns>
        public int PlayersEloAverage()
        {
            return (int)Data.Average(player => player.Elo);
        }

        /// <summary>
        /// 7. Calculate weight from a range off elo
        /// </summary>
        /// <returns></returns>
        public double TotalWeightFromEloRange(int initialElo, int lastElo)
        {
            return (double)(decimal) Data.Where(player => 
            player.Elo > initialElo &&
            player.Elo < lastElo).Sum(player => player.Weight);
        }

        ///// <summary>
        ///// 8.Return Surname and ELO in Ascendent sort by birthday
        ///// </summary>
        ///// <returns></returns>
        //public List<Player> SurnameAndEloSortAscByBirthday()
        //{
        //    var x = Data.OrderBy(player => player.Birthday.Year).Select(player => player.Surname);
        //}

        /// <summary>
        /// 9. Return 'Men' 'Women' or 'Equal' depending of proportion.
        /// </summary>
        /// <returns></returns>
        public string EvaluateMenWomenProportion()
        {
            int menPlayers = Data.Count(player => player.Gender.ToString().ToUpper() == "M");
            int womenPlayers = Data.Count(player => player.Gender.ToString().ToUpper() == "F");

            if (menPlayers == womenPlayers)
                return "Equals";

            return menPlayers > womenPlayers ? "Men" : "Women";
        }

        /// <summary>
        /// 10. Get male players with A or J or G as initial character in name.
        /// </summary>
        /// <returns></returns>
        public List<Player> MalesNamesWithFirstChar()
        {
            return Data.Where(player => player.Gender.ToString().ToUpper() == "M" &&
            (player.Name.StartsWith('A') ||
            player.Name.StartsWith('J') ||
            player.Name.StartsWith('G'))).ToList();
        }

        /// <summary>
        /// 11. Return Players containing char 'a' and 'o' in Surname
        /// </summary>
        /// <returns></returns>
        public List<Player> PlayersSurnamedContains(char first, char second)
        {
            return Data.Where(player => player.Surname.Contains(first) &&
            player.Surname.Contains(second)).ToList();
        }

        /// <summary>
        /// 12. Return Players containing 'a' and 'o' in Surname in this order.
        /// </summary>
        /// <returns></returns>
        public List<Player> PlayersSurnamedContainsInThisOrder(char first, char second)
        {
            return Data.Where(player =>
            player.Surname.Contains(first) &&
            player.Surname.Contains(second) &&
            (player.Surname.Contains(first).ToString().IndexOf(first) < player.Surname.Contains(second).ToString().IndexOf(second))).ToList();
        }

        /*
        /// <summary>
        /// 13.
        /// </summary>
        /// <param name="minWeight"></param>
        /// <param name="maxWeight"></param>
        /// <returns></returns>
        public List<Player> NameAndBirthYear(double minWeight, double maxWeight)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 14.
        /// </summary>
        /// <returns></returns>
        public List<ColoredName> NameAndColor()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 15.
        /// </summary>
        /// <param name="elo"></param>
        /// <returns></returns>
        public List<Player> SurnameAndGender(int elo)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 16.
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public List<Player> NameAndElo(DateTime dateTime)
        {
            throw new NotImplementedException();
        }



        /// <summary>
        /// 17.
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public List<Player> FullNameAndBirthdayDescSortByRanking(int number)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 18.
        /// </summary>
        /// <returns></returns>
        public List<Player> PlayersGroupByGenderAndDescSortElo()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 19.
        /// </summary>
        /// <param name="minWeight"></param>
        /// <param name="maxWeight"></param>
        /// <returns></returns>
        public List<Player> PlayersExceptWeights(double minWeight, double maxWeight)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 20.
        /// </summary>
        /// <returns></returns>
        public List<Player> PlayersWithEvenElo()
        {
            throw new NotImplementedException();
        }
      */
    }
}
