using System.Collections.Generic;

namespace Kolokwium_nr2.Models
{
    public class Team
    {
        public int IdTeam { get; set; }
        public string TeamName { get; set; }
        public int MaxAge { get; set; }

        public ICollection<PlayerTeam> PlayerTeams { get; set; }
        public ICollection<ChampionshipTeam> ChampionshipTeams { get; set; }


    }
}
