using CinemaGames.Data.Models;
using CinemaGames.Data.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CinemaGames.Data.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieRatingController : Controller
    {
        private readonly CinemaGamesDbContext _db;

        public MovieRatingController(CinemaGamesDbContext cinemaGamesDbContext)
        {
            _db = cinemaGamesDbContext; 
        }


        // GET: api/<MovieRatingController>
        [HttpGet(Name = "GetMovieRatings")]
        public IEnumerable<MovieRating> Get()
        {

            return _db.MovieRatings.AsEnumerable();
        }

        // GET api/<MovieRatingController>/5
        [HttpGet("{id}")]
        public MovieRating Get(int id)
        {
            return Get().Where(g => g.Id == id).FirstOrDefault();
        }

        // POST api/<MovieRatingController>
        [HttpPost(Name = "AddMovieRating")]
        [ValidateAntiForgeryToken]
        public void Post([FromBody] MovieRating movieSubmission)
        {
            movieSubmission.Id = 0;
            _db.MovieRatings.Add(movieSubmission);
            _db.SaveChanges();
        }

        // PUT api/<MovieRatingController>/5
        [HttpPut("{id}")]
        [ValidateAntiForgeryToken]
        public void Put(int id, [FromBody] MovieRatingEditDto movieSubmission)
        {
            var movieSubmissionTemp = _db.MovieRatings.Find(id);

            //if (movieSubmissionTemp != null)
            //{
            //    movieSubmissionTemp.Title = movieSubmission.Title;

            //    _db.SaveChanges();
            //}
        }

        // DELETE api/<MovieRatingController>/5
        [HttpDelete("{id}")]
        [ValidateAntiForgeryToken]
        //[HttpDelete(Name = "DeleteMovieRating")]
        public void Delete(int id)
        {
            var movieSubmission = _db.MovieRatings.Find(id);
            if (movieSubmission != null)
            {
                _db.MovieRatings.Remove(movieSubmission);
                _db.SaveChanges();
            }
        }
    }
}
