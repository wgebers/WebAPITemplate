using Microsoft.AspNetCore.Authorization;
using Microsoft.Identity.Web.Resource;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
public class DebugJWTController: ControllerBase
{
    private readonly ILogger<DebugJWTController> _logger;
    private readonly IHttpContextAccessor _httpContextAccessor;
    public DebugJWTController(ILogger<DebugJWTController> logger, IHttpContextAccessor httpContextAccessor)
    {
        _logger = logger;
        _httpContextAccessor = httpContextAccessor;
    }
    [Authorize]
    [HttpGet("v1/debugjwt/claims/")]
    public List<KeyValuePair<string,string>> GetClaims()
    {
        // This is intentionally open to all users to debug the interpreted jwt claims. 
        List<KeyValuePair<string,string>> claims = new List<KeyValuePair<string, string>>();
        foreach (var claim in User.Claims)
        {
            claims.Add(new KeyValuePair<string, string>(claim.Type, claim.Value));
        }
        return claims;
    }
    [Authorize]
    [RequiredScopeOrAppPermission(
    ["Read"],["WebAPI.Read"]
    )]
    [HttpGet("v1/debugjwt/validate-read-scope/")]
    public IActionResult GetReadAuth()
    {
        return Ok();
    }
    [Authorize]
    [RequiredScopeOrAppPermission(
    ["Write"],["WebAPI.ReadWrite"]
    )]
    [HttpGet("v1/debugjwt/validate-write-scope/")]
    public IActionResult GetWriteAuth()
    {
        return Ok();
    }

    [Authorize]
    [RequiredScopeOrAppPermission(
        ["Bad"],["WebAPI.Bad"]
    )]
    [HttpGet("v1/debugjwt/validate-bad-scope/")]
    public IActionResult GetBadAuth()
    {
        // This should always return 403. Used as part of the external test suite to validate app permissions. 
        return Ok();
    }
}