namespace CinemaGames.Data.ViewModel
{
    public class PlayerMatchSummary
    {
        public string SeasonName { get; set; } = default!;
        public string MatchName { get; set; } = default!;
        public string GenreName { get; set; } = default!;
        public string MatchStatus { get; set; } = default!;
        public int MatchPoints { get; set; } = default!;    
        public string MatchTimeLeft { get; set; } = default!;   
    }
}
