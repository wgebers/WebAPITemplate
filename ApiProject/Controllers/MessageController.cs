using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using ApiProject.Models;
using ApiProject.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Identity.Web.Resource;

public class MessageController : ControllerBase
{
    private readonly ILogger<MessageController> _logger;
    private readonly IMessageStore _messageStore;
    public MessageController(ILogger<MessageController> logger,IMessageStore messageStore)
    {
        _messageStore = messageStore;
        _logger = logger;
    }
    [Authorize]
    [HttpGet("v1/message")]
    [RequiredScopeOrAppPermission(
    ["Read"],["Read"]
    )]
    public MessageEnvelope GetMessage(Guid messageGuid)
    {   
        // We will implement service injection to serve this data from an underlying data store. 
        return _messageStore.GetMessage(messageGuid);
    }
    [Authorize]
    [HttpPost("v1/message")]
    [RequiredScopeOrAppPermission(
    ["Write"],["Write"]
    )]
    public IActionResult PostMessage([FromBody] MessageEnvelope message)
    {
        if (message == null)
        {
            _logger.LogWarning("Received null message in POST request.");
            return BadRequest("Message cannot be null.");
        }
        if (message.Id == Guid.Empty)
        {
            _logger.LogWarning("Received message with empty ID in POST request.");
            return BadRequest("Message must have a valid Id.");
        }
        if (string.IsNullOrWhiteSpace(message.Payload))
        {
            _logger.LogWarning("Received message with empty payload in POST request.");
            return BadRequest("Message payload cannot be empty.");
        }
        var success = _messageStore.AddMessage(message);
        if (success)
        {
            return Ok();
        }
        else
        {
            return StatusCode(500, "Failed to store the message.");
        }
    } 
    [Authorize]
    [HttpGet("v1/messages")]
    [RequiredScopeOrAppPermission(
    ["Read"],["Read"]
    )]    public List<MessageEnvelope> GetMessages()
    {
        return _messageStore.GetMessages();
    }   
}