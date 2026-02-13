using Microsoft.Extensions.Logging;
using ApiProject.Controllers;
namespace WebAPITests;
public class UtilityControllerTests
{
    [Fact]
    public void TestUtilityControllerGetSum()
    {
        int a = 1;
        int b = 2;
        ILogger<UtilityController> logger = new Logger<UtilityController>(new LoggerFactory());
        UtilityController controller = new UtilityController(logger);
        int result = controller.GetSum(a,b);
        Assert.Equal(3, result);
    }
}