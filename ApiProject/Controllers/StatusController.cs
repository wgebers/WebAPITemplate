using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
namespace ApiProject.Controllers;
public class ServerStatusController : ControllerBase
{
    private readonly ILogger<ServerStatusController> _logger;
    public ServerStatusController(ILogger<ServerStatusController> logger)
    {
        _logger = logger;
    }
    // We want to be able to serve the server status at the endpoint /serverstatus. 
    // The status should include the server time, uptime in seconds, and the length of the error log.
    [Authorize]
    [HttpGet("v1/serverstatus")]
    public ServerStatus GetStatus()
    {
        _logger.LogInformation("Received request for server status.");
        return new ServerStatus();
    }
}