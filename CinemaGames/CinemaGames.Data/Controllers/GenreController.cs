using CinemaGames.Data.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CinemaGames.Data.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    //[ApiController]
    //    [Route("[controller]")]
    public class GenreController : ControllerBase
    {

        private readonly CinemaGamesDbContext _db;

        public GenreController(CinemaGamesDbContext cinemaGamesDbContext)
        {
            _db = cinemaGamesDbContext;
        }
        //List<Genre> genres = new List<Genre>()
        //    {
        //        new Genre() { Id = 1, Name = "Comedy"},
        //         new Genre() { Id = 2, Name = "Action"},
        //          new Genre() { Id = 3, Name = "Thriller"}
        //    };

        // GET: api/<GenreController>
        [HttpGet(Name = "GetGenres")]
        public IEnumerable<Genre> Get()
        {

            return _db.Genres.AsEnumerable();
        }

        // GET api/<GenreController>/5
        [HttpGet("{id}")]
        public Genre Get(int id)
        {
            return Get().Where(g => g.Id == id).FirstOrDefault();
        }

        // POST api/<GenreController>
        [EnableCors]
        [HttpPost(Name = "AddGenre")]
        public void Post([FromBody] Genre genre)
        {
            _db.Genres.Add(genre);
            _db.SaveChanges();
        }

        // PUT api/<GenreController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Genre genre)
        {
            var genreTemp = _db.Genres.Find(genre.Id);
            if(genreTemp != null)
            {
                genreTemp.Name = genre.Name;
                genreTemp.Description = genre.Description;

                _db.SaveChanges();
            }

        }

        // DELETE api/<GenreController>/5
        [HttpDelete("{id}")]
        [HttpPost(Name = "DeleteGenre")]
        public void Delete(int id)
        {
            var genre = _db.Genres.Find(id);
            if(genre != null)
            {
                _db.Genres.Remove(genre);
                _db.SaveChanges();
            }
        }
    }
}
