namespace OnlineMovies.BL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class OnlineMoviesDB : DbContext
    {
        public OnlineMoviesDB()
            : base("name=OnlineMoviesDBContext")
        {
            Configuration.LazyLoadingEnabled = false;
        }

        public virtual DbSet<Movie_Reviews> Movie_Reviews { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie_Reviews>()
                .Property(e => e.ReviewerName)
                .IsUnicode(false);

            modelBuilder.Entity<Movie>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Movie>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Movie>()
                .HasMany(e => e.Movie_Reviews)
                .WithRequired(e => e.Movie)
                .HasForeignKey(e => e.MovieId)
                .WillCascadeOnDelete(false);
        }
    }
}
