namespace TalentFlow.Api.Models;
public class Application
{
    public int Id { get; set;}
    public int JobId { get; set;}
    public Job? Job { get; set;}
    public string Stage { get; set;}="Applied";
    public DateTime AppliedAt { get; set;}= DateTime.UtcNow;
    public string? Notes { get; set;}
}