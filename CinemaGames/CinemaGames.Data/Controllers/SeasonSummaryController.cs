using CinemaGames.Data.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CinemaGames.Data.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeasonSummaryController : ControllerBase
    {
        private readonly CinemaGamesDbContext _context;

        public SeasonSummaryController(CinemaGamesDbContext cinemaGamesDbContext)
        {
            _context = cinemaGamesDbContext;    
        }

        // GET: api/<DashboardController>
        [HttpGet]
        public IEnumerable<PlayerMatchSummary> Get()
        {
            var matches = new List<PlayerMatchSummary>();
            var seasonMatches = _context.Matches
                .Include(m => m.Season)
                .Include(m => m.Status)
                .Include(m => m.Genre)
                .Where(m => m.Season.IsCurrent)
                .OrderByDescending(m => m.StartDate);

            foreach(var match in seasonMatches)
            {
                matches.Add(new PlayerMatchSummary()
                {
                    MatchId = match.Id,
                    SeasonName = match.Season.Name,
                    MatchName = match.Name,
                    GenreName = match.Genre.Name,
                    GenreDescription = match.Genre.Description,
                    MatchPoints = 10,
                    MatchStatus = match.Status.Name,
                    MatchTimeLeft = match.EndDate.Subtract(DateTime.Now).TotalDays > 2 ? 
                        $"{match.EndDate.Subtract(DateTime.Now).TotalDays.ToString("N0")} d" : 
                        $"{match.EndDate.Subtract(DateTime.Now).TotalHours.ToString("N0")} h"
                }) ;              
            }

            return matches;
        }

        // GET api/<DashboardController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

    }
}
