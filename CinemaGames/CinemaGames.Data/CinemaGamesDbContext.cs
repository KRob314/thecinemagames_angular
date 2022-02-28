using CinemaGames.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Numerics;
using System.Reflection.Emit;
using System.Text.RegularExpressions;

namespace CinemaGames.Data
{
    public class CinemaGamesDbContext: DbContext
    {
        public CinemaGamesDbContext(DbContextOptions<CinemaGamesDbContext> options) : base(options)
        {
        }

        public CinemaGamesDbContext() { }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer("Server=(LocalDB)\\v11.0;Database=CinemaGamesAngular;Trusted_Connection=True;MultipleActiveResultSets=true");


        public DbSet<Genre> Genres { get; set; } = default!;
        public DbSet<CinemaGames.Data.Models.Match> Matches { get; set; } = default!;
        public DbSet<MovieRating> MovieRatings { get; set; } = default!;
        public DbSet<MovieSubmission> MovieSubmissions { get; set; } = default!;
        public DbSet<Player> Players { get; set; } = default!;
        public DbSet<Season> Seasons { get; set; } = default!;
        public DbSet<Status> Statuses { get; set; } = default!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }


            base.OnModelCreating(modelBuilder);

            var statusEntity = modelBuilder.Entity<Status>();
            statusEntity.HasKey(p => p.Id);
            statusEntity.Property(p => p.Name).HasMaxLength(25);

            var genreEntity = modelBuilder.Entity<Genre>();
            genreEntity.HasKey(p => p.Id);
            genreEntity.Property(p => p.Name).HasMaxLength(50);
            genreEntity.Property(p => p.Description).HasMaxLength(300);

            var movieRatingEntity = modelBuilder.Entity<MovieRating>();
            movieRatingEntity.HasKey(p => p.Id);
            movieRatingEntity.HasOne(p => p.Player).WithMany().HasForeignKey(p => p.PlayerId).OnDelete(DeleteBehavior.Restrict);
            movieRatingEntity.Property(p => p.PickEm).HasMaxLength(100);

        }
    }
}
