using Kolokwium_nr2.DTOs.Requests;
using Kolokwium_nr2.Models;
using System.Collections.Generic;

namespace Kolokwium_nr2.Services
{
    public interface IDbChampionshipService { 
    
        public IEnumerable<ChampionshipTeam> TeamsList(int id);

        public void AddPlayerToTeams(AddPlayerToTeamRequest request, int id);

    }
}
