using Microsoft.EntityFrameworkCore;
using TalentFlow.Api.Models;

namespace TalentFlow.Api.Data;

public class TalentFlowDbContext : DbContext
{
    public TalentFlowDbContext(DbContextOptions<TalentFlowDbContext> options)
        : base(options)
    {
    }

    public DbSet<Job> Jobs => Set<Job>();
}