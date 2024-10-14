public class GoalEntity {
    public Guid Id {get;set;}
    public string Title {get;set;} = string.Empty;
    public bool Status {get;set;} = false;
    public DateTime Date {get;set;}
}
