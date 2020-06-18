using Kolokwium_nr2.DTOs.Requests;
using Kolokwium_nr2.Exceptions;
using Kolokwium_nr2.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kolokwium_nr2.Controllers
{
    [Route("api/teams")]
    [ApiController]
    public class TeamController : ControllerBase
    {

        private readonly IDbChampionshipService _context;

        public TeamController(IDbChampionshipService context)
        {
            _context = context;
        }


        [HttpGet("{id:int}/players")]
        public IActionResult SetPlayerIntoTeam(AddPlayerToTeamRequest request, int id)
        {

            try
            {
                _context.AddPlayerToTeams(request, id);
                return NoContent();
            }catch(PlayerIsAlreadyInTeamException exc)
            {
                return BadRequest(exc.Message);
            }catch(PlayerIsToOldException exc)
            {
                return BadRequest(exc.Message);
            }
            catch (PlayerNotexistsException exc)
            {
                return NotFound(exc.Message);
            }
           

        }

    }
}