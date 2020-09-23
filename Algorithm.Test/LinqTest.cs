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
                new Player{ Name = "Judith", Surname = "Polgar", Gender = 'F', Birthday = new DateTime(1976,2,11), Weight = 70.7, Elo = 2646},
                new Player{ Name = "Garry", Surname = "Kasparov", Gender = 'm', Birthday = new DateTime(1963,7,4), Weight = 64.2, Elo = 2812},
                new Player{ Name = "Hou", Surname = "Yifan", Gender = 'f', Birthday = new DateTime(1994,8,23), Weight = 50.0, Elo = 2658},
                new Player{ Name = "  MaGnus", Surname = "Carlsen", Gender = 'M', Birthday = new DateTime(1990,6,28), Weight = 67.9, Elo = 2863}
            };

            Query = new Linq(data);
        }

        [Fact]
        public void Exist_Player_Older_Than()
        {
            bool result = Query.ExistPlayerOlderThan(80);

            Assert.False(result);
        }

        [Fact]
        public void Count_Femmale_Players()
        {
            int result = Query.CountFemmalePlayers();

            Assert.Equal(2, result);
        }

        [Fact]
        public void Exist_Player_Named()
        {
            bool result = Query.ExistPlayerNamed("Magnus");

            Assert.True(result);
        }
    }
}