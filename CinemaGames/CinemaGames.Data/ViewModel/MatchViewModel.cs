using CinemaGames.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace CinemaGames.Data.ViewModel
{
    public class MatchViewModel
    {
        public int Id { get; set; }
        [Required]
        public int SeasonId { get; set; }
        [Required]
        public int GenreId { get; set; }
        [Required]
        public int StatusId { get; set; }
        [Required]
        public string Name { get; set; } = default!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsCurrent { get; set; }

        public string FullName { get; set;  }

        public Season Season { get; set; } = default!;
        public Genre Genre { get; set; } = default!;
        public Status Status { get; set; } = default!;
    }
}
