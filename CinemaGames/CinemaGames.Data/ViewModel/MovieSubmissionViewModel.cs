using CinemaGames.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CinemaGames.Data.ViewModel
{
    public class MovieSubmissionViewModel
    {
        public int Id { get; set; }
        public int? PlayerId { get; set; }
        public int? MatchId { get; set; }
        public string Title { get; set; } = default!;
        public string? Trailer { get; set; } = default!;
        public string? ReasonToChoose { get; set; } = default!;
        public string? Synopsis { get; set; } = default!;

        public virtual Player Player { get; set; } = default!;
        public MatchViewModel Match { get; set; } = default!;
    }
}
