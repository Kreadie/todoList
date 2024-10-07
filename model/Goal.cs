using System.Text.Json.Serialization;

public class Goal {
    public Guid Id {get;set;}
    public string Title {get;set;} = string.Empty;
    public bool Status {get;set;} = false;
    public DateTime Date {get;set;}

    [JsonConstructor]
    private Goal(Guid id, string title, DateTime date)
    {
        Id = id;
        Title = title;     
	Date = date;
    }

    public static (Goal? goal, string error) Create(Guid id, string title, DateTime date) {
        string error = string.Empty;
        
        if(string.IsNullOrEmpty(title)) {
            error = "Goal name is not set";
            return (null, error);
        }

        Goal g = new Goal(id, title, date);
        return (g, error);
    }
    
}
