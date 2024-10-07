public interface IGoalService {
    Task<List<Goal?>> GetGoals() ;
    Task<Guid> CreteGoal(Goal goal);
    Task<Guid> DeleteGoal(Guid id);
}