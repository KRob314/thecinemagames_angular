using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaGames.Data.Models
{
    public class MovieRating
    {
        public int Id { get; set; }
        //[Required]
        public int? PlayerId { get; set; }
        //[Required]
        public int MovieSubmissionId { get; set; }  
        public int Rating { get; set; }
        public DateTime Created { get; set; }
        public string ReasonForVote { get; set; } = default!;
        public string PickEm { get; set; } = default!;

        //[ForeignKey("PlayerId")]
        public virtual Player Player { get; set; } = default!;
        //[ForeignKey("MovieSubmissionId")]
        public virtual MovieSubmission MovieSubmission { get; set; } = default!;
    }

    public class MovieRatingEditDto
    {

    }
}
