using ApiProject.Models;
namespace WebAPITests;
public class ServerStatusTests
{
    [Fact]
    public void TestConstructor()
    {
        var status = new ServerStatus();
        Assert.NotNull(status);
        Assert.Equal(string.Empty, status.ServerId);
        Assert.True((DateTime.UtcNow - status.ServerTime).TotalSeconds < 1);
        Assert.Equal(0, status.UptimeSeconds);
        Assert.Equal(0, status.ErrorLogLength);
    }
}