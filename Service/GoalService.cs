public class GoalService : IGoalService{
    private readonly IGoalRepository _goalRepository;

    public GoalService(IGoalRepository goalRepository)
    {
        _goalRepository = goalRepository;
    }

    public async Task<List<Goal?>> GetGoals() {
        return await _goalRepository.Get();
    }

    public async Task<Guid> CreteGoal(Goal goal) {
        return await _goalRepository.Create(goal);
    }

    public async Task<Guid> DeleteGoal(Guid id) {
        return await _goalRepository.Delete(id);
    }
}
