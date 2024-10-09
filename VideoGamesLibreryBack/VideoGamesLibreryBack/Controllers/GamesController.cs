using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VideoGamesLibreryBack.DbSet;
using VideoGamesLibreryBack.ModelDB;

namespace VideoGamesLibreryBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public GamesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Games>> Get()
        {
            return Ok(_context.Games.ToList());
        }
    }
}
