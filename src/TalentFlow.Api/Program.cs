using Microsoft.EntityFrameworkCore;
using TalentFlow.Api.Data;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<TalentFlowDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TalentFlowDb")));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();
app.MapGet("/api/jobs", async (TalentFlowDbContext db) =>
    await db.Jobs.ToListAsync());
app.MapGet("/api/applications", async (TalentFlowDbContext db) =>
    await db.Applications.Include(a => a.Job).ToListAsync());
app.MapPut("/api/applications/{id}/stage", async (int id, string stage, TalentFlowDbContext db) =>
{
    var application = await db.Applications.FindAsync(id);
    if (application is null)
        return Results.NotFound();

    application.Stage = stage;
    //await db.SaveChangesAsync();

    return Results.Ok(application);
});

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
