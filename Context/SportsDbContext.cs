using Microsoft.EntityFrameworkCore;
using Sports.MVC.Context.Entities.Concrete;

namespace Sports.MVC.Context
{
    public class SportsDbContext : DbContext
    {
        public SportsDbContext(DbContextOptions contextOptions ) : base( contextOptions ) { }
                
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<PlayerTeam> PlayerTeams { get; set; }
        public DbSet<BranchTeam> BranchTeams { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<GameInfo> GameInfos { get; set; }
        


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>().HasOne(g => g.HomeTeam).WithMany(t => t.HomeMatches).HasForeignKey(g => g.HomeTeamId);
            modelBuilder.Entity<Game>() .HasOne(m => m.AwayTeam) .WithMany(t => t.AwayMatches) .HasForeignKey(m => m.AwayTeamId);
            base.OnModelCreating(modelBuilder);}
        }
}
