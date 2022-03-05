using System.ComponentModel.DataAnnotations;

namespace CinemaGames.Data.Models
{
    public class Genre
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; } = default!;
        [MaxLength(500)]
        public string? Description { get; set; } 
    }
}
