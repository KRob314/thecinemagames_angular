using CinemaGames.Data.Models;
using CinemaGames.Data.ViewModel;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CinemaGames.Data.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieSubmissionController : ControllerBase
    {
        private readonly CinemaGamesDbContext _db;

        public MovieSubmissionController(CinemaGamesDbContext cinemaGamesDbContext)
        {
            _db = cinemaGamesDbContext;
        }

        // GET: api/<MovieSubmissionController>
        [HttpGet(Name = "GetMovieSubmissions")]
        public IEnumerable<MovieSubmissionViewModel> Get()
        {

            return _db.MovieSubmissions.Select(ms => new MovieSubmissionViewModel()
            {
                Id = ms.Id,
                PlayerId = ms.PlayerId,
                Player = ms.Player,
                MatchId = ms.MatchId,
                Match = new MatchViewModel()
                {
                    Id = ms.Match.Id,
                    Name = ms.Match.Name,
                    FullName = $"{ms.Match.Season.Name} - {ms.Match.Name}"
                },
                Title = ms.Title,
                ReasonToChoose = ms.ReasonToChoose,
                Synopsis = ms.Synopsis,
                Trailer = ms.Trailer
            }).AsEnumerable();
        }

        // GET api/<MovieSubmissionController>/5
        [HttpGet("{id}")]
        public MovieSubmissionViewModel Get(int id)
        {
            return Get().Where(g => g.Id == id).FirstOrDefault();
        }

        // POST api/<MovieSubmissionController>
        [HttpPost(Name = "AddMovieSubmission")]
        //[ValidateAntiForgeryToken]
        public void Post([FromBody] MovieSubmissionEditDto vm)
        {
            var movieSubmission = new MovieSubmission()
            {
                Created = DateTime.Now,
                MatchId = vm.MatchId,
                PlayerId = vm.PlayerId,
                ReasonToChoose = vm.ReasonToChoose,
                Synopsis = vm.Synopsis,
                Title = vm.Title,
                Trailer = vm.Trailer
            };

            _db.MovieSubmissions.Add(movieSubmission);
            _db.SaveChanges();
        }

        // PUT api/<MovieSubmissionController>/5
        [HttpPut("{id}")]
        [ValidateAntiForgeryToken]
        public void Put(int id, [FromBody] MovieSubmissionEditDto movieSubmission)
        {
            var movieSubmissionTemp = _db.MovieSubmissions.Find(id);

            if (movieSubmissionTemp != null)
            {
                movieSubmissionTemp.Title = movieSubmission.Title;

                _db.SaveChanges();
            }
        }

        // DELETE api/<MovieSubmissionController>/5
        [HttpDelete("{id}")]
        [ValidateAntiForgeryToken]
        //[HttpDelete(Name = "DeleteMovieSubmission")]
        public void Delete(int id)
        {
            var movieSubmission = _db.MovieSubmissions.Find(id);
            if (movieSubmission != null)
            {
                _db.MovieSubmissions.Remove(movieSubmission);
                _db.SaveChanges();
            }
        }
    }
}
