using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;
using System.Net.Http.Headers;

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
        /// Confirm if exist a player olther than...
        /// </summary>
        /// <param name="age"></param>
        /// <returns></returns>
        public bool ExistPlayerOlderThan(int age)
        {
            return Data.Any(player => GetAge(player.Birthday) > age);
        }

        private int GetAge(DateTime birthday)
        {
            return DateTime.Now.Year - birthday.Year;
        }

        /// <summary>
        /// Count all femmale players
        /// </summary>
        /// <returns></returns>
        public int CountFemmalePlayers()
        {
            //return Data.Count(player => player.Gender.ToString().ToUpper() == "F");

            return Data.Where(player => player.Gender.ToString().ToUpper() == "F").Count();
        }

        /// <summary>
        /// Confirm if exist a Name in players list.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool ExistPlayerNamed(string name)
        {
            return Data.Any(player =>
                player.Name.Trim().ToLower() == name.Trim().ToLower() ||
                player.Surname.Trim().ToLower() == name.Trim().ToLower());
        }

        /// <summary>
        /// Get the initial position for a player
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public int PlayerPositionInitialList(string name)
        {
            return Data.ToList().FindIndex(player =>
            player.Name.Trim().ToLower() == name.Trim().ToLower() ||
            player.Surname.Trim().ToLower() == name.Trim().ToLower());
        }

        /// <summary>
        /// Get the ranking position
        /// </summary>
        /// <param name="name"></param>
        /// <param name="elo"></param>
        /// <returns></returns>
        public int PlayerRankingPosition(string name, int elo)
        {
            //Seleccionar todos los jugadores por encima del elo de Kasparov
            //Ordenar
            //Devolver la posición de Kasparov en esa lista

            return Data.OrderBy(player => player.Elo).ToList().FindIndex(player =>
            player.Elo == elo);
            //player.Name.Trim().ToLower() == name.Trim().ToLower() ||
            //player.Surname.Trim().ToLower() == name.Trim().ToLower());
        }

        /// <summary>
        /// Calculate Elo average from all players
        /// </summary>
        /// <returns></returns>
        public int PlayersEloAverage()
        {
            return (int)Data.Average(player => player.Elo);
        }

        /// <summary>
        /// Calculate weight from a range off elo
        /// </summary>
        /// <returns></returns>
        //public double CalculateTotalWeight()
        //{
        //    throw new NotImplementedException();
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        //public List<Player> SortAscByBirthday()
        //{
        //    throw new NotImplementedException;
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string EvaluateMenWomenProportion()
        {
            int menPlayers = Data.Where(player => player.Gender.ToString().ToUpper() == "M").Count();
            int womenPlayers = Data.Where(player => player.Gender.ToString().ToUpper() == "F").Count();

            if (menPlayers == womenPlayers)
                return "Equals";

            return menPlayers > womenPlayers ? "Men" : "Women";
        }

        /// <summary>
        /// Get Masculin players with A or J or G as initial character in name.
        /// </summary>
        /// <returns></returns>
        public List<Player> PlayersNameWithConditions()
        {
            return Data.Where(player => player.Gender.ToString().ToUpper() == "M" &&
            (player.Name.StartsWith('A') ||
            player.Name.StartsWith('J') ||
            player.Name.StartsWith('G'))).ToList();
        }

        public List<Player> PlayersSurnamedWithConditions()
        {
            throw new NotImplementedException();
        }
    }
}
