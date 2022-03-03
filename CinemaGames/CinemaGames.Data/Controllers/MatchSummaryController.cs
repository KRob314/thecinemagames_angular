using CinemaGames.Data.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CinemaGames.Data.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchSummaryController : ControllerBase
    {
        private readonly CinemaGamesDbContext _context;

        public MatchSummaryController(CinemaGamesDbContext cinemaGamesDbContext)
        {
               _context = cinemaGamesDbContext;
        }

        // GET: api/<MatchSummaryController>
        [HttpGet]
        public IEnumerable<MatchSummaryViewModel> Get()
        {
            var results = new List<MatchSummaryViewModel>();
            var movieRatings = _context.MovieRatings
                .Include(m => m.MovieSubmission)
                .Where(m => m.MovieSubmission.Match.Season.IsCurrent)
                .OrderBy(m => m.Rating);

            foreach (var vote in movieRatings)
            {
                results.Add(new MatchSummaryViewModel()
                {
                    Movie = vote.MovieSubmission.Title,
                    MoviePoints = vote.Rating,
                    MovieRank = 3,
                    Reason = vote.ReasonForVote,
                    WeekName = vote.MovieSubmission.Match.Name
                });
            }

            return results;
        }

        // GET api/<MatchSummaryController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

       
    }
}
