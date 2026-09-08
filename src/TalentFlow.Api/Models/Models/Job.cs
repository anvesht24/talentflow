namespace TalentFlow.Api.Models;

public class Job
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Company { get; set; } = string.Empty;
    public string? Location { get; set; }
    public bool IsRemote { get; set; }
    public int? SalaryMin { get; set; }
    public int? SalaryMax { get; set; }
    public string? Url { get; set; }
    public DateTime PostedAt { get; set; }
    public string? Description { get; set; }
}