using Kolokwium_nr2.DTOs.Requests;
using Kolokwium_nr2.Exceptions;
using Kolokwium_nr2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kolokwium_nr2.Services
{
    public class EfSqlDbChampionshipService : IDbChampionshipService
    {

        private readonly ChampionshipContext _context;

        public EfSqlDbChampionshipService(ChampionshipContext context)
        {
            _context = context;
        }

        public void AddPlayerToTeams(AddPlayerToTeamRequest request, int id)
        {
            var yearPlayer = DateTime.Now.Year - request.BirthDate.Year;
            var maxAgeOfTeam = _context.Teams.Where(m => m.IdTeam == id).Select(m => m.MaxAge).FirstOrDefault();

            if (yearPlayer>maxAgeOfTeam)
            {
                throw new PlayerIsToOldException("Player is too old for this team");
            }

            var player = _context.Players.Where(m => m.FirstName == request.FirstName && m.LastName == request.LastName
            && m.DateOfBirth == request.BirthDate).FirstOrDefault();

            if (player == null)
            {
                throw new PlayerNotexistsException("Player not exitst");
            }

            var isPlayerInTeam = _context.PlayerTeams.Count(m => m.IdPlayer == player.IdPlayer);

            if (isPlayerInTeam !=0)
            {
                throw new PlayerIsAlreadyInTeamException("Player is already in team");
            }

            var teamPlayer = new PlayerTeam
            {
                IdPlayer = player.IdPlayer,
                IdTeam = id, 
                NumOnShirt = request.NumOnShirt,
                Comment = request.Comment
            };


            _context.Attach(teamPlayer);
            _context.Add(teamPlayer);
            _context.SaveChangesAsync();

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
