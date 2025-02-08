using GameStore.Api.Entites;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Api.data
{
    public class GamestoreContext(DbContextOptions<GamestoreContext> options) : DbContext(options)
    {
        public DbSet<Game> Games => Set<Game>();
        public DbSet<Genre> Genre => Set<Genre>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>().HasData(
           new Genre { id = 1, name = "Fighting" },
           new Genre { id = 2, name = "Roleplaying" },
           new Genre { id = 3, name = "Sports" },
           new Genre { id = 4, name = "Racing" },
           new Genre { id = 5, name = "Kids and Family" }
       );

        }
    }

}
