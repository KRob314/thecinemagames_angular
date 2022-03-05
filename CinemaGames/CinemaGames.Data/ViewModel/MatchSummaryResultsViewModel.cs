namespace CinemaGames.Data.ViewModel
{
    public class MatchSummaryResultsViewModel
    {
        public string WeekName { get; set; } = default!;
        public int MovieRank { get; set; } = default!;
        public int MoviePoints { get; set; } = default!;
        public string Movie { get; set; } = default!;

        public string Reason { get; set; } = default!;  
    }
}
