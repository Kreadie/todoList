using Microsoft.EntityFrameworkCore;

public class GoalRepository : IGoalRepository{
    private readonly GoalDbContext _context;
    public GoalRepository(GoalDbContext context)
    {
        _context = context;
    }

    public async Task<List<Goal?>> Get() {
        var entities = await _context.Goals.FromSql($"SELECT * FROM Goals ORDER BY Date DESC").ToListAsync();

        var goals = entities.Select(t => Goal.Create(t.Id, t.Title, t.Date).goal).ToList();
        return goals;
    }

    public async Task<Guid> Create(Goal goal) {
        var entity = new GoalEntity {Id = goal.Id, Title = goal.Title, Date = goal.Date};
        await _context.Goals.AddAsync(entity); 
        await _context.SaveChangesAsync();

        return entity.Id;
    }

    public async Task<Guid> Delete(Guid id) {
        await _context.Goals.Where(t => t.Id == id).ExecuteDeleteAsync();
        return id;
    }
}
