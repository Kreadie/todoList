using Microsoft.EntityFrameworkCore;

public class GoalDbContext : DbContext {
    public DbSet<GoalEntity> Goals {get;set;}

    public GoalDbContext(DbContextOptions<GoalDbContext> options) : base(options) {
        Database.EnsureCreated();    
    }
}
