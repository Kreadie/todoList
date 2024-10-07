using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
string connectionString = builder.Configuration.GetConnectionString("SqlServerConnection")!;

builder.Services.AddDbContext<GoalDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddScoped<IGoalService, GoalService>();
builder.Services.AddScoped<IGoalRepository, GoalRepository>();

var app = builder.Build();
app.UseDefaultFiles();
app.UseStaticFiles();
app.MapGet("/", (HttpContext context) => context.Response.Redirect("/html"));
 
app.MapGet("/task-load", async (HttpContext context, IGoalService service) => {
    var goals = await service.GetGoals();
    await context.Response.WriteAsJsonAsync(goals);
});

app.MapPost("/task-add", async (Goal goal, HttpContext context, IGoalService service) => {
    (Goal? g, string error) = Goal.Create(Guid.NewGuid(), goal.Title, DateTime.Now);
    if(!string.IsNullOrEmpty(error)) {
        context.Response.StatusCode = 400;
        return Guid.Empty;
    }

    var taskId = await service.CreteGoal(g);
    return taskId;
});
app.MapDelete("/task-delete/{id:guid}", async(Guid id, HttpContext context, IGoalService service) => {
    await service.DeleteGoal(id); 
});

app.Run();
