using Kolokwium_nr2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium_nr2.Services
{
    public interface IDbChampionshipService { 
    
        public IEnumerable<ChampionshipTeam> TeamsList(int id);

    }
}
