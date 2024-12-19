using Microsoft.EntityFrameworkCore;

public class GameContext : DbContext{
  public DbSet<Character> Characters { get; set; }
  public DbSet<Enemy> Enemies { get; set; }

  public GameContext(){
	Database.EnsureCreated();
  }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
	optionsBuilder.UseSqlite("Data Source=game.db");
  }
}
