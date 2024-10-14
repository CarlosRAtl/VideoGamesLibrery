using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VideoGamesLibreryBack.DbSet;
using VideoGamesLibreryBack.ModelDB;

namespace VideoGamesLibreryBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesConsolesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public GamesConsolesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("GamesConsoles")]
        public ActionResult<IEnumerable<GameConsole>> Get(string? consoleId)
        {
            try
            {
                if (consoleId == null) return Ok(_context.GameConsoles.ToList());
                return Ok(_context.GameConsoles.Where(gc => gc.ConsoleId == consoleId).FirstOrDefault());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost("SaveGameConsole")]
        public async ValueTask<IActionResult> PostGame([FromBody] GameConsole gameConsole)
        {
            try
            {
                GameConsole newGameConsole = new();

                newGameConsole.NameConsole = gameConsole.NameConsole;
                newGameConsole.Quantity = gameConsole.Quantity;
                newGameConsole.IsEspecialEdition = gameConsole.IsEspecialEdition;
                newGameConsole.IsPortable = gameConsole.IsPortable;
                newGameConsole.Company = gameConsole.Company;
                newGameConsole.IsNew = gameConsole.IsNew;
                newGameConsole.IsOpen = gameConsole.IsOpen;
                newGameConsole.IsComplete = gameConsole.IsComplete;
                newGameConsole.IsProtected = gameConsole.IsProtected;
                newGameConsole.ConsoleId = gameConsole.ConsoleId;
                newGameConsole.Description = gameConsole.Description;

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                await _context.GameConsoles.AddAsync(newGameConsole);
                await _context.SaveChangesAsync();

                return Ok(await _context.GameConsoles.Where(g => g.ConsoleId == newGameConsole.ConsoleId).FirstOrDefaultAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut("UpdateGameConsole/{consoleId}")]
        public async ValueTask<IActionResult> PutGame([FromBody] GameConsole gameConsole, string consoleId)
        {
            try
            {
                GameConsole found = await _context.GameConsoles.Where(g => g.ConsoleId == consoleId).FirstOrDefaultAsync();
                if (found != null)
                {
                    found.ConsoleId = gameConsole.ConsoleId;
                    found.NameConsole = gameConsole.NameConsole;
                    found.Quantity = gameConsole.Quantity;
                    found.IsEspecialEdition = gameConsole.IsEspecialEdition;
                    found.IsComplete = gameConsole.IsComplete;
                    found.Company = gameConsole.Company;
                    found.IsNew = gameConsole.IsNew;
                    found.IsOpen = gameConsole.IsOpen;
                    found.Description = gameConsole.Description;
                    found.IsProtected = gameConsole.IsProtected;
                    found.IsPortable = gameConsole.IsPortable;


                    _context.GameConsoles.Update(found);
                    await _context.SaveChangesAsync();
                    return Ok(await _context.GameConsoles.Where(g => g.ConsoleId == consoleId).FirstOrDefaultAsync());
                }

                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
