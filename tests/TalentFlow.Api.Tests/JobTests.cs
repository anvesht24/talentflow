using Xunit;
using TalentFlow.Api.Models;

public class JobTests
{
    [Fact]
    public void NewJob_DefaultsIsRemoteToFalse()
    {
        var job = new Job { Title = "Test", Company = "Test Co" };

        Assert.False(job.IsRemote);
    }
}