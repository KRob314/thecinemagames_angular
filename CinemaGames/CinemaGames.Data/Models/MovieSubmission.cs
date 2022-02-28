using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaGames.Data.Models
{
    public class MovieSubmission
    {
        public int Id { get; set; } 
        //[Required]
        public int? PlayerId { get; set; }   
        //[Required]
        public int? MatchId { get; set; }
        [Required]
        [MaxLength(200)]
        public string Title { get; set; } = default!;
        [MaxLength(200)]
        public string? Trailer { get; set; } = default!;
        public DateTime Created { get; set; }
        public string ReasonToChoose { get; set; } = default!;
        public string Synopsis { get; set; } = default!;

        [ForeignKey("PlayerId")]
        public virtual Player Player { get; set; } = default!;
        [ForeignKey("MatchId")]
        public virtual Match Match { get; set; } = default!;
    }

    public class MovieSubmissionEditDto
    {
        public int Id { get; set; }
        //[Required]
        public int? PlayerId { get; set; }
        //[Required]
        public int? MatchId { get; set; }
        [Required]
        [MaxLength(200)]
        public string Title { get; set; } = default!;
        [MaxLength(200)]
        public string? Trailer { get; set; } = default!;
        public DateTime Created { get; set; }
        public string ReasonToChoose { get; set; } = default!;
        public string Synopsis { get; set; } = default!;
    }
}
