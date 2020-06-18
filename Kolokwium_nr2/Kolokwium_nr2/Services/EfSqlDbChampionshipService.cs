using Kolokwium_nr2.Exceptions;
using Kolokwium_nr2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium_nr2.Services
{
    public class EfSqlDbChampionshipService : IDbChampionshipService
    {

        private readonly ChampionshipContext _context;

        public EfSqlDbChampionshipService(ChampionshipContext context)
        {
            _context = context;
        }

        public IEnumerable<ChampionshipTeam> TeamsList(int id)
        {
            if (id < 0)
            {
                throw new ChampionshipIdCanNotBeNegative("Id can not be negative");
            }

            var championshipList = _context.ChampionshipTeams.Where(m => m.IdChampionship == id).Include(m => m.Team).OrderBy(m => m.Score).ToList();

            if(championshipList == null)
            {
                throw new ChampionshipDoesNotExistsException($"Championship with id={id} does not exist");
            }

            return championshipList;


        }
    }
}
