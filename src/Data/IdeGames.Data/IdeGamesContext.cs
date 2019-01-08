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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<UserGroup>().ToTable("UsersGroups");
        }

        public IdeGamesContext(DbContextOptions<IdeGamesContext> options)
            : base(options)
        {
        }

        public IdeGamesContext()
        {
        }

        public DbSet<Game> Games { get; set; }

        public DbSet<News> News { get; set; }

        public DbSet<Item> Items { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Group> Groups { get; set; }

        public DbSet<Message> Messages { get; set; }

        public DbSet<UserGroup> UsersGroups { get; set; }
    }
}