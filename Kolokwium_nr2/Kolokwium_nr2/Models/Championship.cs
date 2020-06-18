using System.Collections.Generic;

namespace Kolokwium_nr2.Models
{
    public class Championship
    {

        public int IdChampionship { get; set; }
        public int OfficialName { get; set; }
        public int Year { get; set; }


        public ICollection<ChampionshipTeam> ChampionshipTeams { get; set; }


    }
}
