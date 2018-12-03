using IdeGames.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdeGames.Data
{
    public class IdeGamesContext : IdentityDbContext<IdeGamesUser>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLExpress;Database=IdeGames;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        public IdeGamesContext(DbContextOptions<IdeGamesContext> options)
            : base(options)
        {
        }

        public IdeGamesContext()
        {
        }

        public DbSet<Game> Games { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<News> News { get; set; }
    }
}