using CinemaGames.Data.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CinemaGames.Data.Controllers
{
    [Route("api/[controller]/[action]")]
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
        public IEnumerable<MatchSummaryResultsViewModel> Get()
        {
            var results = new List<MatchSummaryResultsViewModel>();
            var movieRatings = _context.MovieRatings
                .Include(m => m.MovieSubmission).ThenInclude(ms => ms.Match).ThenInclude(ma => ma.Season)
                .Where(m => m.MovieSubmission.Match.Season.IsCurrent)
                .OrderBy(m => m.Rating);

            foreach (var vote in movieRatings)
            {
                results.Add(new MatchSummaryResultsViewModel()
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
        public IEnumerable<MatchSummaryResultsViewModel> GetMatchResults(int id)
        {
            var results = new List<MatchSummaryResultsViewModel>();
            var movieRatings = _context.MovieRatings
                .Include(m => m.MovieSubmission).ThenInclude(ms => ms.Match).ThenInclude(ma => ma.Season).ToList()
                .Where(m => m.MovieSubmission.Match.Id == id)
                .GroupBy(m => m.MovieSubmissionId).ToList();
            Dictionary<int, int> moviePoints = new Dictionary<int, int>();

            foreach (var vote in movieRatings)
            {
                var key = vote.Key;
                var movieResults = vote.ToList();

                moviePoints.Add(movieResults.FirstOrDefault().MovieSubmissionId, movieResults.Sum(m => m.Rating));
            }

           

            foreach (var vote in movieRatings)
            {
                var key = vote.Key;
                var movieResults = vote.ToList();
              
                results.Add(new MatchSummaryResultsViewModel()
                {
                    Movie = movieResults.FirstOrDefault().MovieSubmission.Title,
                    MoviePoints = movieResults.Sum(m => m.Rating),
                    MovieRank = moviePoints.Values.OrderByDescending(m => m).ToList().IndexOf(movieResults.Sum(m => m.Rating)) + 1,
                    WeekName = movieResults.FirstOrDefault().MovieSubmission.Match.Name
                });
            }

            return results.OrderByDescending(r => r.MoviePoints);
        }


        // GET api/<MatchSummaryController>/5
        [HttpGet("{id}")]
        public IEnumerable<MatchSummaryVotesViewModel> GetMatchVotes(int id)
        {
            var results = new List<MatchSummaryVotesViewModel>();
            var movieRatings = _context.MovieRatings
                .Include(m => m.Player)
                .Include(m => m.MovieSubmission).ThenInclude(ms => ms.Match).ThenInclude(ma => ma.Season).ToList()
                .Where(m => m.MovieSubmission.Match.Id == id);


            foreach (var vote in movieRatings)
            {
                results.Add(new MatchSummaryVotesViewModel()
                {
                    Movie = vote.MovieSubmission.Title,
                    MoviePoints = vote.Rating,
                    WeekName = vote.MovieSubmission.Match.Name,
                    PlayerName = vote.Player.FirstName,
                    Reason = vote.ReasonForVote
                });
            }

            return results.Distinct().OrderBy(m => m.Movie).ToList();
        }

    }
}
