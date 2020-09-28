using Algorithm.Library;
using Algorithm.Library.LinQ;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

        public Player PlayerAt(int index) =>
            Query.Data.ElementAt(index);

        //1
        [Fact]
        public void Exist_Player_Older_Than()
        {
            bool result = Query.ExistPlayerOlderThan(25);

            Assert.True(result);
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
            bool result = Query.ExistPlayerNamed("Carlsen");

            Assert.True(result);
        }

        //4
        [Fact]
        public void Player_Position_Initial_List()
        {
            int result = Query.PlayerPositionInitialList("Kasparov");

            Assert.Equal(3, result);
        }

        //5
        [Fact]
        public void Player_Ranking_Position()
        {
            int result = Query.PlayerRankingPosition("Kasparov");

            Assert.Equal(2, result);
        }

        //6
        [Fact]
        public void Players_Elo_Average()
        {
            double result = Query.PlayersEloAverage();

            Assert.Equal(2719, Math.Round(result));
        }

        //7
        [Fact]
        public void Total_Weight_From_Elo_Range()
        {
            double result = Query.TotalWeightFromEloRange(2600, 2699);

            Assert.Equal(202.1, Math.Round(result, 1));
        }
 
        //8 
        [Fact]
        public void Surname_And_Elo_SortAsc_ByBirthday()
        {
            List<Tuple<string,int>> result = Query.SurnameAndEloSortAscByBirthday();

            List<Tuple<string, int>> expected = new List<Tuple<string, int>>()
            {
                Tuple.Create("KARPOV", 2617),
                Tuple.Create("KASPAROV", 2812),
                Tuple.Create("POLGAR", 2646),
                Tuple.Create("CARLSEN", 2863),
                Tuple.Create("YIFAN", 2658)
            };

            Assert.Equal(expected, result, new TupleComparerByNameAndElo());
        }

        //9
        [Fact]
        public void Evaluate_Men_Women_Proportion()
        {
            string result = Query.EvaluateMenWomenProportion();

            Assert.Equal("Men", result);
        }

        //10
        [Fact]
        public void Males_Players_With_Name_First_Char()
        {
            List<Player> result = Query.MalesNamesWithFirstChar();

            List<Player> expected = new List<Player>()
            {
               PlayerAt(0),
                ((List<Player>)Query.Data)[2]
            };

            Assert.Equal(expected, result);
        }
        
        //11
        [Fact]
        public void Players_Surnamed_Contains()
        {
            List<Player> result = Query.PlayersSurnamedContains('a', 'o');

            List<Player> expected = new List<Player>()
            {
                PlayerAt(0),
                PlayerAt(1),
                PlayerAt(2),
            };

            Assert.Equal(expected, result);
        }
        
        //12
        [Fact]
        public void Players_Surnamed_Contains_In_ThisOrder()
        {
            List<Player> result = Query.PlayersSurnamedContainsInThisOrder('a', 'o');

            List<Player> expected = new List<Player>()
            {
                PlayerAt(0),
                PlayerAt(2),
            };

            Assert.Equal(expected, result);
        }
        
        //13 
        [Fact]
        public void Name_And_BirthYear_From_WeightCondition()
        {
            List<Tuple<string,int>> result = Query.NameAndBirthYear(69, 82);

            List<Tuple<string,int>> expected = new List<Tuple<string,int>>() 
            {
                Tuple.Create("Anatoly", 1951),
                Tuple.Create("Judith", 1976)
            };

            Assert.Equal(expected, result);
        }

        //14
        [Fact]
        public void Name_And_Color_From_WeightSortAsc()
        {
            List<Tuple<string,Color>> result = Query.NameAndColor();

            List<Tuple<string, Color>> expected = new List<Tuple<string, Color>>()
            {
                Tuple.Create("Hou", Color.Green),
                Tuple.Create("Garry", Color.Green),
                Tuple.Create("Magnus", Color.Yellow),
                Tuple.Create("Judith", Color.Yellow),
                Tuple.Create("Anatoly", Color.Red)  
            };

            Assert.Equal(expected, result, new TupleComparerByNameAndColor());
        }

        //15
        [Fact]
        public void TopN_Name_And_Color_From_WeightSortAsc()
        {
            List<Tuple<string, Color>> result = Query.NameAndColorTop(3);

            List<Tuple<string, Color>> expected = new List<Tuple<string, Color>>()
            {
                Tuple.Create("Hou", Color.Green),
                Tuple.Create("Garry", Color.Green),
                Tuple.Create("Magnus", Color.Yellow)
            };

            Assert.Equal(expected, result, new TupleComparerByNameAndColor());
        }

        //16
        [Fact]
        public void Surname_And_Gender_Over_Elo()
        {
            List<Tuple<string, string>> result = Query.SurnameAndGenderOverElo(2650);

            List<Tuple<string, string>> expected = new List<Tuple<string, string>>()
            {
                Tuple.Create("Kasparov", "Male"),
                Tuple.Create("Yifan", "Female"),
                Tuple.Create("Carlsen", "Male")
            };

            Assert.Equal(expected, result, new TupleComparerBySurnameAndGender());
        }

        //17
        [Fact]
        public void Name_And_Elo_Players_Born_After()
        {
            List<Tuple<string, int>> result = Query.NameAndEloPlayersBornAfter(new DateTime (1990,1,1));

            List<Tuple<string, int>> expected = new List<Tuple<string, int>>()
            {
                Tuple.Create("Hou", 2658),
                Tuple.Create("Magnus", 2863)
            };

            Assert.Equal(expected, result, new TupleComparerByNameAndElo());
        }

        //18
        [Fact]
        public void Name_Surname_Birthday_SortDesc_By_Ranking()
        {
            List<Tuple<string, DateTime>> result = Query.FullNameAndBirthdayDescSortByRanking(2);

            List<Tuple<string, DateTime>> expected = new List<Tuple<string, DateTime>>()
            {
                Tuple.Create("Magnus-Carlsen", new DateTime(1990,6,28)),
                Tuple.Create("Garry-Kasparov", new DateTime(1963,7,4))
            };

            Assert.Equal(expected, result, new TupleComparerByNameAndBirthday());
        }

        /*
        //19
        [Fact]
        public void Players_GroupBy_Gender_And_DescSortElo()
        {
            List<Player> result = Query.PlayersGroupByGenderAndDescSortElo();

            List<Player> expected = new List<Player>()
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
                    Name = "Garry",
                    Surname = "Kasparov",
                    Gender = 'm',
                    Birthday = new DateTime(1963,7,4),
                    Weight = 64.2,
                    Elo = 2812
                },
                new Player
                {
                    Name = "  MaGnus",
                    Surname = "Carlsen",
                    Gender = 'M',
                    Birthday = new DateTime(1990,6,28),
                    Weight = 67.9,
                    Elo = 2863
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
                    Name = "Hou",
                    Surname = "Yifan",
                    Gender = 'f',
                    Birthday = new DateTime(1994,8,23),
                    Weight = 50.0,
                    Elo = 2658
                }
            };

            Assert.Equal(expected, result);
        }

        //19
        [Fact]
        public void Players_Except_MaxWeight_And_MinWeight()
        {
            List<Player> result = Query.PlayersExceptWeights(81.4, 50.0);

            List<Player> expected = new List<Player>()
            {
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
                    Name = "  MaGnus",
                    Surname = "Carlsen",
                    Gender = 'M',
                    Birthday = new DateTime(1990,6,28),
                    Weight = 67.9,
                    Elo = 2863
                },
                new Player
                {
                    Name = "Judith",
                    Surname = "Polgar",
                    Gender = 'F',
                    Birthday = new DateTime(1976,2,11),
                    Weight = 70.7,
                    Elo = 2646
                }
            };

            Assert.Equal(expected, result);
        }

        //20
        [Fact]
        public void Players_With_EvenElo()
        {
            List<Player> result = Query.PlayersWithEvenElo();

            List<Player> expected = new List<Player>()
            {
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
                }
            };

            Assert.Equal(expected, result);
        }
        */
    }
}


