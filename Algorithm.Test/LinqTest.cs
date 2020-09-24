using Algorithm.Library;
using Algorithm.Library.LinQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Algorithm.Test
{
    public class LinqTest
    {
        private Linq Query { get; set; }

        public LinqTest()
        {
            var data = new List<Player>
            {
                new Player
                {
                    Name = "Anatoly",
                    Surname = "Karpov",
                    Gender = 'M',
                    Birthday = new DateTime(1951,2,14),
                    Weight = 81.4,
                    Elo = 2617
                },
                new Player
                { 
                    Name = "Judith", 
                    Surname = "Polgar", 
                    Gender = 'F', 
                    Birthday = new DateTime(1976,2,11), 
                    Weight = 70.7, 
                    Elo = 2646
                },
                new Player
                { 
                    Name = "Garry", 
                    Surname = "Kasparov", 
                    Gender = 'm', 
                    Birthday = new DateTime(1963,7,4), 
                    Weight = 64.2, 
                    Elo = 2812
                },
                new Player
                { 
                    Name = "Hou", 
                    Surname = "Yifan", 
                    Gender = 'f', 
                    Birthday = new DateTime(1994,8,23), 
                    Weight = 50.0, 
                    Elo = 2658
                },
                new Player
                { 
                    Name = "  MaGnus", 
                    Surname = "Carlsen", 
                    Gender = 'M', 
                    Birthday = new DateTime(1990,6,28), 
                    Weight = 67.9, 
                    Elo = 2863
                }
            };

            Query = new Linq(data);
        }

        //1
        [Fact]
        public void Exist_Player_Older_Than()
        {
            bool result = Query.ExistPlayerOlderThan(80);

            Assert.False(result);
        }

        //2
        [Fact]
        public void Count_Femmale_Players()
        {
            int result = Query.CountFemmalePlayers();

            Assert.Equal(2, result);
        }

        //3
        [Fact]
        public void Exist_Player_Named()
        {
            bool result = Query.ExistPlayerNamed("Magnus");

            Assert.True(result);
        }

        //4
        [Fact]
        public void Player_Position_Initial_List()
        {
            int result = Query.PlayerPositionInitialList("Kasparov");

            Assert.Equal(2, result);
        }

        //5
        [Fact]
        public void Player_Ranking_Position()
        {
            int result = Query.PlayerRankingPosition("Kasparov", 2812);

            Assert.Equal(2, result);
        }

        //6
        [Fact]
        public void Players_Elo_Average()
        {
            int result = Query.PlayersEloAverage();

            Assert.Equal(2719, result);
        }

        //7
        //[Fact]
        //public void Calculate_Total_Weight()
        //{
        //    double result = Query.CalculateTotalWeight();

        //    Assert.Equal(202.1, result);
        //}

        //8 
        //[Fact]
        //public void Surname_And_Elo_SortAsc_ByBirthday()
        //{
        //    List<Player> result = Query.SortAscByBirthday();

        //    List<Player> expected = new List<Player>() 
        //    { 
        //        new Player(){Surname = "Yifan", Elo = 2658},
        //        new Player(){Surname = "Carlsen", Elo = 2863 },
        //        new Player(){Surname = "Polgar", Elo = 2646 },
        //        new Player(){Surname = "Garry", Elo = 2812 },
        //        new Player(){Surname = "Karpov", Elo = 2617 }
        //    };

        //    Assert.Equal(expected, result);
        //}

        //9
        [Fact]
        public void Evaluate_Men_Women_Proportion()
        {
            string result = Query.EvaluateMenWomenProportion();

            Assert.Equal("Men",result);
        }

        //10
        [Fact]
        public void Get_Players_With_Named_Conditions()
        {
            List<Player> result = Query.PlayersNameWithConditions();

            List<Player> expected = new List<Player>()
            {
                new Player(){Name = "Anatoly"},
                new Player(){Name = "Garry"}
            };

            Assert.Equal(expected, result);
        }

        //11
        [Fact]
        public void Get_Players_With_Surnamed_Conditions()
        {
            List<Player> result = Query.PlayersSurnamedWithConditions();

            List<Player> expected = new List<Player>()
            {
                new Player(){Surname = "Karpov"},
                new Player(){Surname = "Polgar"},
                new Player(){Surname = "Kasparov"}
            };

            Assert.Equal(expected, result);
        }
    }
}