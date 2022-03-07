using System.ComponentModel.DataAnnotations;

namespace CinemaGames.Data.Models
{
    public class SeasonStanding
    {
        public int Id { get; set; } = default!;
        [Required]
        public int PlayerId { get; set; } = default!;
        [Required]
        public int SeasonId { get; set; } = default!;
        public int Points { get; set; } = default!;
        public int Rank { get; set; } = default!;   

        public virtual Player Player { get; set; }
        public virtual Season Season { get; set; }  
    }
}
