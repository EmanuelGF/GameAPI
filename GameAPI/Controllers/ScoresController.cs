using GameAPI.Data;
using GameAPI.DTO;
using GameAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GameAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScoresController : ControllerBase
    {
        private readonly Context _context;

        public ScoresController(Context context)
        {
            _context = context;
        }

        // GET: api/GetTopTenScores
        [HttpGet("GetTopTenScores")]
        public async Task<ActionResult<IEnumerable<Score>>> GetTopTenScores()
        {
            return await _context.Scores.OrderByDescending(s => s.PlayerScore).Take(10).ToListAsync();
        }

        // POST: api/PostScores
        [HttpPost("PostScore")]
        public async Task<ActionResult> PostScore([FromBody] ScoreDTO scoreDto)
        {
            try
            {
                var score = new Score
                {
                    Id = Guid.NewGuid(),
                    PlayerName = scoreDto.PlayerName,
                    PlayerScore = scoreDto.PlayerScore
                };

                _context.Scores.Add(score);
                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("Something whent wrong!!");
            }

        }
    }
}
