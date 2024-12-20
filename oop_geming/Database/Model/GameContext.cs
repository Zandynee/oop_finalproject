using Microsoft.EntityFrameworkCore;

public class GameContext : DbContext{
  public DbSet<Enemy> Enemies { get; set; }
  public DbSet<Player> Players { get; set; }
  public DbSet<Leaderboard> Leaderboards { get; set; }

  public GameContext(){
	Database.EnsureCreated();
  }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
	optionsBuilder.UseSqlite("Data Source=game.db");
  }
}
