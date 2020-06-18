using Kolokwium_nr2.Exceptions;
using Kolokwium_nr2.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kolokwium_nr2.Controllers
{
    [Route("api/championships")]
    [ApiController]
    public class ChampionshipController : ControllerBase
    {
        private readonly IDbChampionshipService _context;

        public ChampionshipController (IDbChampionshipService context)
        {
            _context = context;
        }


        [HttpGet("{id:int}/teams")]
        public IActionResult GetListChampionships(int id)
        {

            try
            {
                var result = _context.TeamsList(id);
                return Ok(result);
            }catch(ChampionshipDoesNotExistsException exc)
            {
                return NotFound(exc.Message);
            }catch(ChampionshipIdCanNotBeNegative exc)
            {
                return BadRequest(exc.Message);
            }
            

        }

    }
}