using Microsoft.EntityFrameworkCore;

namespace CinemaGames.Data.Models
{
    public class SeedData
    {
        public static void SeedDatabase(CinemaGamesDbContext context)
        {
            context.Database.EnsureCreated();
            //context.Database.Migrate();
            RandomData randomData = new RandomData();

            if (context.Players.Count() == 0)
            {
                List<Player> players = new List<Player>();

                for(int i = 0; i < 10; i++)
                {
                   var newPlayer = new Player()
                    {
                        FirstName = randomData.FirstName(),
                        LastName = randomData.LastName(),
                        IsActive = true
                    };

                    players.Add(newPlayer);
                    context.Players.Add(newPlayer);
                }


                context.SaveChanges();
            }

            if(context.Statuses.Count() == 0)
            {
                Status s1 = new Status() { Name = "Open For Movie Submission" };
                Status s2 = new Status() { Name = "Open For Voting" };
                Status s3 = new Status() { Name = "Unavailable" };
                Status s4 = new Status() { Name = "Closed" };

                context.Statuses.Add(s1);
                context.Statuses.Add(s2);   
                context.Statuses.Add(s3);
                context.Statuses.Add(s4);
                context.SaveChanges();
            }

            if(context.Genres.Count() == 0)
            {
                List<Genre> genres = new List<Genre>();

                for(int i = 0; i < 10; i++)
                {
                    var newGenre = new Genre()
                    {
                        Name = randomData.Genre()
                    };

                    genres.Add(newGenre);
                    context.Genres.Add(newGenre);
                }

                context.SaveChanges();
            }


            if(context.Seasons.Count() ==0)
            {
                List<Season> seasons = new List<Season>();

                for(int i = 1; i < 10; i++)
                {
                    var newSeason = new Season()
                    {
                        StartDate = DateTime.Now,
                        EndDate = DateTime.Now.AddDays(60),
                        Name = $"Season {i}",
                        IsCurrent = false
                    };

                    seasons.Add(newSeason);
                    context.Seasons.Add(newSeason);
                }

                context.SaveChanges();
            }

            if(context.Matches.Count() == 0)
            {
                int genreLength = context.Genres.Count();
                List<Match> matches = new List<Match>();

                foreach(var season in context.Seasons)
                {
                    for(int i = 1; i < 5; i++)
                    {
                        var newMatch = new Match()
                        {
                            SeasonId = season.Id,
                            GenreId = context.Genres.ToList()[randomData.Number(0, genreLength)].Id,
                            StatusId = 1,
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(7),
                            IsCurrent = false,
                            Name = $"Week {i}"
                        };

                        matches.Add(newMatch);
                        context.Matches.Add(newMatch);
                    }
                }

                context.SaveChanges();
            }

            if(context.MovieSubmissions.Count() == 0)
            {
                List<MovieSubmission> movieSubmissions = new List<MovieSubmission>();

                foreach(var match in context.Matches)
                {
                    foreach(var player in context.Players)
                    {
                        var newMovieSubmission = new MovieSubmission()
                        {
                            Title = randomData.Movie(),
                            Created = DateTime.Now,
                            MatchId = match.Id,
                            PlayerId = player.Id,
                            ReasonToChoose = randomData.RandonWords(500),
                            Synopsis = randomData.RandonWords(500),
                            Trailer = ""
                        };

                        movieSubmissions.Add(newMovieSubmission);
                        context.MovieSubmissions.Add(newMovieSubmission);
                    }
                }

                context.SaveChanges();
            }

            if(context.MovieRatings.Count() == 0)
            {
                List<MovieRating> movieRatings = new List<MovieRating>();  

                foreach(var movieSubmission in context.MovieSubmissions)
                {
                    foreach(var player in context.Players)
                    {
                        var newMovieRating = new MovieRating()
                        {
                            MovieSubmissionId = movieSubmission.Id,
                            PlayerId = player.Id,
                            Created = DateTime.Now,
                            Rating = randomData.Number(1, 10),
                            ReasonForVote = randomData.RandonWords(500),
                            PickEm = randomData.FirstName()
                        };

                        movieRatings.Add(newMovieRating);
                        context.MovieRatings.Add(newMovieRating);
                    }
                }

                context.SaveChanges();
            }

        }
    }
}
