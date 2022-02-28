using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaGames.Data.Models
{
    public class Match
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

        public Season Season { get; set; } = default!;
        public Genre Genre { get; set; } = default!;
        public Status Status { get; set; } = default!;

    }

    public class MatchEditDto
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
    }
}
