using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaGames.Data.Models
{
    public class Player
    {
        public int Id { get; set; }
        [MaxLength(75)]
        public string? UserId { get; set; } = string.Empty;  
        [MaxLength(50)]
        public string FirstName { get; set; } = string.Empty;
        [MaxLength(75)]
        public string LastName { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        
    }
}
