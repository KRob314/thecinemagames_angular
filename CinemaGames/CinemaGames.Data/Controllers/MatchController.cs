using CinemaGames.Data.Models;
using Microsoft.AspNetCore.Mvc;
using CinemaGames.Data.ViewModel;
using Microsoft.AspNetCore.Cors;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CinemaGames.Data.Controllers
{
    //[EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class MatchController : ControllerBase
    {
        private readonly CinemaGamesDbContext _db;

        public MatchController(CinemaGamesDbContext cinemaGamesDbContext)
        {
            _db = cinemaGamesDbContext;
        }

        // GET: api/<MatchController>
        [HttpGet(Name = "GetMatchs")]
        public IEnumerable<SeasonViewModel> Get()
        {

            return _db.Matches.Select(m => new SeasonViewModel()
            {
                Id = m.Id,
                Name = m.Name,
                SeasonId = m.SeasonId,
                GenreId = m.GenreId,
                StatusId = m.StatusId,
                StartDate = m.StartDate,
                EndDate = m.EndDate,
                IsCurrent = m.IsCurrent,
                Season = m.Season,
                Genre = m.Genre,
                Status = m.Status,
                FullName = $"{m.Season.Name} - {m.Name}"
            }).OrderBy(s => s.StartDate).AsEnumerable();

            //return _db.Matches.AsEnumerable();
        }

        // GET api/<MatchController>/5
        [HttpGet("{id}")]
        public SeasonViewModel Get(int id)
        {
            return Get().Where(g => g.Id == id).FirstOrDefault();
        }

        // POST api/<MatchController>
        [HttpPost(Name = "AddMatch")]
        public void Post([FromBody] MatchEditDto vm)
        {
            Match match = new Match()
            {
                Name = vm.Name,
                StartDate = vm.StartDate,
                EndDate = vm.EndDate,
                GenreId = vm.GenreId,
                SeasonId = vm.SeasonId,
                StatusId = vm.StatusId,
                IsCurrent = vm.IsCurrent
            };
      
            _db.Matches.Add(match);
            _db.SaveChanges();
        }

        // PUT api/<MatchController>/5

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] MatchEditDto match)
        {
            var matchTemp = _db.Matches.Find(id);

            if (matchTemp != null)
            {
                matchTemp.Name = match.Name;
                matchTemp.GenreId = match.GenreId;
                matchTemp.SeasonId = match.SeasonId;
                matchTemp.StatusId = match.StatusId;
                matchTemp.IsCurrent = match.IsCurrent;
                matchTemp.StartDate = match.StartDate;
                matchTemp.EndDate = match.EndDate;

                _db.SaveChanges();
            }
        }

        // DELETE api/<MatchController>/5
        [HttpDelete("{id}")]
        //[HttpDelete(Name = "DeleteMatch")]
        public void Delete(int id)
        {
            var season = _db.Matches.Find(id);
            if (season != null)
            {
                _db.Matches.Remove(season);
                _db.SaveChanges();
            }
        }
    }
}
