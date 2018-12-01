using IdeGames.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdeGames.Data
{
    public class IdeGamesContext : IdentityDbContext<IdeGamesUser>
    {
        public IdeGamesContext()
        {
        }

        public IdeGamesContext(DbContextOptions<IdeGamesContext> options)
            : base(options)
        {
        }

        public DbSet<Game> Games { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<News> News { get; set; }
    }
}