using CinemaGames.Data.Models;
using CinemaGames.Data.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CinemaGames.Data.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeasonStandingsController : ControllerBase
    {
        private readonly CinemaGamesDbContext _context;

        public SeasonStandingsController(CinemaGamesDbContext cinemaGamesDbContext)
        {
            _context = cinemaGamesDbContext;
        }


        // GET: api/<SeasonStandingsController>
        [HttpGet]
        public IEnumerable<SeasonStandingViewModel> Get()
        {

            var seasonPlayers = _context.Players;
            int seasonId = _context.Seasons.Where(s => s.IsCurrent).Select(s => s.Id).FirstOrDefault();

            foreach(var player in seasonPlayers)
            {
                int totalPoints = 0;
                var movieSubmissions = _context.MovieSubmissions
                    .Include(ms => ms.Player)
                    .Include(ms => ms.Match).ThenInclude(m => m.Season)
                    .Where(ms => ms.PlayerId == player.Id && ms.Match.Season.IsCurrent);

                foreach(var movieSubmission in movieSubmissions)
                {
                    var movieRatings = _context.MovieRatings
                        .Where(mr => mr.MovieSubmissionId == movieSubmission.Id)
                        .Sum(mr => mr.Rating);

                    totalPoints+= movieRatings;
                }

                var seasonStanding = _context.SeasonStandings.Where(ss => ss.PlayerId == player.Id && ss.SeasonId == seasonId).FirstOrDefault();

                if(seasonStanding != null)
                {
                    var seasonStandings = _context.SeasonStandings.Where(ss => ss.SeasonId == seasonId).OrderBy(ss => ss.Points).ToList();
                    seasonStanding.Points = totalPoints;
                    seasonStanding.Rank = seasonStandings.IndexOf(seasonStanding);
                }
                else
                {
                    _context.SeasonStandings.Add(new SeasonStanding()
                    {
                        PlayerId = player.Id,
                        SeasonId = seasonId,
                        Points = totalPoints,
                        Rank = 1
                    });
                }

            }

            _context.SaveChanges();

            var viewModel = _context.SeasonStandings
                .Include(ss => ss.Season)
                .Include(ss => ss.Player)
                .Where(ss => ss.Season.IsCurrent)
                .Select(ss => new SeasonStandingViewModel()
                {
                    PlayerName = ss.Player.FirstName,
                    Points = ss.Points,
                    Rank = ss.Rank
                }).AsEnumerable();

            return viewModel;
        }

        //// GET api/<SeasonStandingsController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<SeasonStandingsController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<SeasonStandingsController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<SeasonStandingsController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
