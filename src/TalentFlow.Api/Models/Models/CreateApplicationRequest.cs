namespace TalentFlow.Api.Models;

public class CreateApplicationRequest
{
    public int JobId { get; set; }
    public string? Notes { get; set; }
}