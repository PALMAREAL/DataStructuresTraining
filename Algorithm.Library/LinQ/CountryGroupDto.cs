using System.Collections.Generic;

namespace Algorithm.Library.LinQ
{
    public class CountryGroupDto
    {
        public CountryEnum Country { get; set; }
        public List<PlayerDto> Players { get; set; }
        public Player PlayerTop { get; set; }
        public double AverageElo { get; set; }
    }
}