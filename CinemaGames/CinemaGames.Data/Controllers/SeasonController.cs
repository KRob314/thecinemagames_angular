using CinemaGames.Data.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CinemaGames.Data.Controllers
{
    [Route("api/[controller]")]
    //[Route("api/[controller]/[action]")]
    [ApiController]
    public class SeasonController : ControllerBase
    {
        private readonly CinemaGamesDbContext _db;

        public SeasonController(CinemaGamesDbContext cinemaGamesDbContext)
        {
            _db = cinemaGamesDbContext;
        }

        // GET: api/<SeasonController>
        [HttpGet(Name = "GetSeasons")]
        public IEnumerable<Season> Get()
        {

            return _db.Seasons.AsEnumerable();
        }

        // GET api/<SeasonController>/5
        [HttpGet("{id}")]
        public Season Get(int id)
        {
            return Get().Where(g => g.Id == id).FirstOrDefault();
        }

        // POST api/<SeasonController>
        [HttpPost(Name = "AddSeason")]
        public void Post([FromBody] Season season)
        {
            season.Id = 0 ;
            _db.Seasons.Add(season);
            _db.SaveChanges();
        }

        // PUT api/<SeasonController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Season season)
        {
            var seasonTemp = _db.Seasons.Find(id);

            if(seasonTemp != null)
            {
                seasonTemp.Name = season.Name;
                seasonTemp.StartDate = season.StartDate;
                seasonTemp.EndDate = season.EndDate;
                seasonTemp.IsCurrent = season.IsCurrent;

                _db.SaveChanges();
            }
        }

        // DELETE api/<SeasonController>/5
        [HttpDelete("{id}")]
        //[HttpDelete(Name = "DeleteSeason")]
        public void Delete(int id)
        {
            var season = _db.Seasons.Find(id);
            if (season != null)
            {
                _db.Seasons.Remove(season);
                _db.SaveChanges();
            }
        }
    }
}
