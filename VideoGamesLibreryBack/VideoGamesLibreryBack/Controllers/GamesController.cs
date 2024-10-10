using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        [HttpGet("ViewGames")]
        public ActionResult<IEnumerable<Games>> Get(string? gameId)
        {
            if (gameId == null) return Ok(_context.Games.ToList());

            return Ok(_context.Games.Where(g => g.GameId == gameId).FirstOrDefault());
        }

        [HttpPost("SaveGame")]
        public async ValueTask<IActionResult> PostGame([FromBody] Games game)
        {
            try
            {
                Games newGame = new();

                newGame.GameName = game.GameName;
                newGame.Quantity = game.Quantity;
                newGame.IsEspecialEdition = game.IsEspecialEdition;
                newGame.IsDigital = game.IsDigital;
                newGame.Company = game.Company;
                newGame.IsPlayed = game.IsPlayed;
                newGame.ConsoleName = game.ConsoleName;
                newGame.IsFinished = game.IsFinished;
                newGame.IsProtected = game.IsProtected;
                newGame.GameId = game.GameId;

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                await _context.Games.AddAsync(newGame);
                await _context.SaveChangesAsync();

                return Ok(await _context.Games.Where(g => g.GameId == newGame.GameId).FirstOrDefaultAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut("UpdateGame/{gameId}")]
        public async ValueTask<IActionResult> PutGame([FromBody] Games game, string gameId)
        {
            try
            {
                Games found = await _context.Games.Where(g => g.GameId == gameId).FirstOrDefaultAsync();
                if (found != null)
                {
                    found.GameId = game.GameId;
                    found.GameName = game.GameName;
                    found.Quantity = game.Quantity;
                    found.IsEspecialEdition = game.IsEspecialEdition;
                    found.IsDigital = game.IsDigital;
                    found.Company = game.Company;
                    found.IsPlayed = game.IsPlayed;
                    found.ConsoleName = game.ConsoleName;
                    found.IsFinished = game.IsFinished;
                    found.IsProtected = game.IsProtected;


                    _context.Games.Update(found);
                    await _context.SaveChangesAsync();
                }
                return Ok(await _context.Games.Where(g => g.GameId == gameId).FirstOrDefaultAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
