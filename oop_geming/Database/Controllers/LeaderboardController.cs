using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace LeaderboardAPI.Controllers {
  [ApiController]
  public class LeaderboardController : ControllerBase {
    private readonly GameContext _context;

    public LeaderboardController(GameContext context)
    {
        _context = context;
    }

    public async Task<ActionResult<IEnumerable<Leaderboard>>> GetLeaderboard()
    {
        return await _context.Leaderboards.ToListAsync();
    }

    public async Task<ActionResult<Leaderboard>> GetLeaderboard(int id)
    {
        var leaderboard = await _context.Leaderboards.FindAsync(id);

        if (leaderboard == null)
        {
            return NotFound();
        }

        return leaderboard;
    }

    public async Task<IActionResult> PutLeaderboard(int id, Leaderboard leaderboard)
    {
        if (id != leaderboard.Id)
        {
            return BadRequest();
        }

        _context.Entry(leaderboard).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!LeaderboardExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    public async Task<ActionResult<Leaderboard>> PostLeaderboard(Leaderboard leaderboard)
    {
        _context.Leaderboards.Add(leaderboard);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetLeaderboard", new { id = leaderboard.Id }, leaderboard);
    }

    public async Task<ActionResult<Leaderboard>> DeleteLeaderboard(int id)
    {
        var leaderboard = await _context.Leaderboards.FindAsync(id);
        if (leaderboard == null)
        {
            return NotFound();
        }

        _context.Leaderboards.Remove(leaderboard);
        await _context.SaveChangesAsync();

        return leaderboard;
    }

    private bool LeaderboardExists(int id){
      return _context.Leaderboards.Any(e => e.Id == id);
    }
  }
}