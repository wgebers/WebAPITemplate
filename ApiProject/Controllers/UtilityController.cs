using Microsoft.AspNetCore.Mvc;
namespace ApiProject.Controllers;
public class UtilityController : ControllerBase
{
    private readonly ILogger<UtilityController> _logger;
    public UtilityController(ILogger<UtilityController> logger)
    {
        _logger = logger;

    }


    // GET /v1/utility/add/5/10

    [HttpGet("v1/utility/add/{a}/{b}")]
    public int GetSum(int a, int b)
    {
        try
        {
            
            return a + b;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error parsing input parameters for addition.");

            return 0;
        }
    }
}