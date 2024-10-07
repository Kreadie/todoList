public interface IGoalRepository {
    Task<List<Goal?>> Get();

    Task<Guid> Create(Goal goal); 

    Task<Guid> Delete(Guid id);
}