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
                Dictionary<string, string> genreAndDescriptions = new Dictionary<string, string>();
                genreAndDescriptions.Add("Drame", "Stories composed in verse or prose, usually for theatrical performance, where conflicts and emotion are expressed through dialogue and action.");
                genreAndDescriptions.Add("Fable", "Narration demonstrating a useful truth, especially in which animals speak as humans; legendary, supernatural tale.");
                genreAndDescriptions.Add("Fairy Tale", "Story about fairies or other magical creatures, usually for children.");
                genreAndDescriptions.Add("Fantasy", "Fiction with strange or other worldly settings or characters; fiction which invites suspension of reality.");
                genreAndDescriptions.Add("Fiction", "Narrative literary works whose content is produced by the imagination and is not necessarily based on fact.");
                genreAndDescriptions.Add("Fiction in Verse", "Full-length novels with plot, subplot(s), theme(s), major and minor characters, in which the narrative is presented in (usually blank) verse form.");
                genreAndDescriptions.Add("Folklore", "The songs, stories, myths, and proverbs of a people or folk as handed down by word of mouth.");
                genreAndDescriptions.Add("Historical Fiction", "Story with fictional characters and events in a historical setting.");
                genreAndDescriptions.Add("Horror", "Fiction in which events evoke a feeling of dread in both the characters and the reader.");
                genreAndDescriptions.Add("Humor", "Fiction full of fun, fancy, and excitement, meant to entertain; but can be contained in all genres");
                genreAndDescriptions.Add("Legend", "Story, sometimes of a national or folk hero, which has a basis in fact but also includes imaginative material.");
                genreAndDescriptions.Add("Mystery", "Fiction dealing with the solution of a crime or the unraveling of secrets");
                genreAndDescriptions.Add("Mythology", "Legend or traditional narrative, often based in part on historical events, that reveals human behavior and natural phenomena by its symbolism; often pertaining to the actions of the gods.");
                genreAndDescriptions.Add("Poetry", "Verse and rhythmic writing with imagery that creates emotional responses.");
                genreAndDescriptions.Add("Realistic Fiction", "Story that can actually happen and is true to life.");
                genreAndDescriptions.Add("Science Fiction", "Story based on impact of actual, imagined, or potential science, usually set in the future or on other planets.");
                genreAndDescriptions.Add("Short Story", "Fiction of such brevity that it supports no subplots.");

                foreach(var genre in genreAndDescriptions)
                {
                    var newGenre = new Genre()
                    {
                        Name = genre.Key,
                        Description = genre.Value
                    };

                    genres.Add(newGenre);
                    context.Genres.Add(newGenre);
                }

                context.SaveChanges();
            }


            if(context.Seasons.Count() ==0)
            {
                List<Season> seasons = new List<Season>();
                int index = 10;

                for(int i = 1; i < 10; i++)
                {
                    var sDate = DateTime.Now.AddDays((30 * index * -1));
                    var eDate = sDate.AddDays(30);
                    var newSeason = new Season()
                    {
                        StartDate = sDate,
                        EndDate = eDate,
                        Name = $"Season {i}",
                        IsCurrent = false
                    };

                    seasons.Add(newSeason);
                    context.Seasons.Add(newSeason);
                    index -= 1;
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
                        var sDate = season.StartDate;
                        var eDate = sDate.AddDays(7 * i);
                        var newMatch = new Match()
                        {
                            SeasonId = season.Id,
                            GenreId = context.Genres.ToList()[randomData.Number(0, genreLength)].Id,
                            StatusId = 4,
                            StartDate = sDate,
                            EndDate = eDate,
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
