using CinemaGames.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CinemaGames.Data.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : Controller
    {
        private readonly CinemaGamesDbContext _db;

        public PlayerController(CinemaGamesDbContext cinemaGamesDbContext)
        {
            _db = cinemaGamesDbContext;
        }


        // GET: api/<PlayerController>
        [HttpGet(Name = "GetPlayers")]
        public IEnumerable<Player> Get()
        {

            return _db.Players.AsEnumerable();
        }

        // GET api/<PlayerController>/5
        [HttpGet("{id}")]
        public Player Get(int id)
        {
            return Get().Where(g => g.Id == id).FirstOrDefault();
        }

        // POST api/<PlayerController>
        [HttpPost(Name = "AddPlayer")]
        [ValidateAntiForgeryToken]
        public void Post([FromBody] Player movieSubmission)
        {
            movieSubmission.Id = 0;
            _db.Players.Add(movieSubmission);
            _db.SaveChanges();
        }

        // PUT api/<PlayerController>/5
        [HttpPut("{id}")]
        [ValidateAntiForgeryToken]
        public void Put(int id, [FromBody] Player movieSubmission)
        {
            var movieSubmissionTemp = _db.Players.Find(id);

            //if (movieSubmissionTemp != null)
            //{
            //    movieSubmissionTemp.Title = movieSubmission.Title;

            //    _db.SaveChanges();
            //}
        }

        // DELETE api/<PlayerController>/5
        [HttpDelete("{id}")]
        [ValidateAntiForgeryToken]
        //[HttpDelete(Name = "DeletePlayer")]
        public void Delete(int id)
        {
            var movieSubmission = _db.Players.Find(id);
            if (movieSubmission != null)
            {
                _db.Players.Remove(movieSubmission);
                _db.SaveChanges();
            }
        }
    }
}
