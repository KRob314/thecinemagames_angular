using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaGames.Data.Models
{
    public class Season
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime StartDate { get; set; } 
        public DateTime EndDate { get; set; }   
        public bool IsCurrent { get; set; } 
    }

}
