using ApiProject.Models;
namespace ApiProject.Services;
public class MessageStore : IMessageStore
{
    private List<MessageEnvelope> _messages;
    private readonly ILogger<MessageStore> _logger;
    public MessageStore(ILogger<MessageStore> logger)
    {
        _messages = new List<MessageEnvelope>();
        _logger = logger;
        
    }
    public MessageEnvelope GetMessage(Guid messageGuid)
    {
        _logger.LogInformation($"Retrieving message with ID: {messageGuid}");
         var message = _messages.FirstOrDefault(m => m.Id == messageGuid);  
        if (message == null)
        {
            _logger.LogWarning($"Message with ID: {messageGuid} not found.");
            return null;
        }
        return message;
    }
    public List<MessageEnvelope> GetMessages()
    {
        _logger.LogInformation("Retrieving all messages from the store.");
        return _messages;
    }
    public int StoreLength()
    {
        _logger.LogInformation("Getting the number of messages in the store.");
        _logger.LogInformation($"Current store length: {_messages.Count}");
        return _messages.Count;
    }
    public bool AddMessage(MessageEnvelope message)
    {
        try
        {
            if (message == null)
            {
                throw new ArgumentNullException(nameof(message), "Message cannot be null.");
            }
            if (message.Id == Guid.Empty)
            {
                throw new ArgumentException("Message must have a valid Id.", nameof(message));
            }
            if (string.IsNullOrWhiteSpace(message.Payload))
            {
                throw new ArgumentException("Message payload cannot be empty.", nameof(message));
            }
             _messages.Add(message);
             _logger.LogInformation($"Message with ID: {message.Id} added to the store.");
            return true;
        }
        catch (Exception ex)
        {
            // Log the exception or handle it as needed.
            _logger.LogError($"Error adding message: {ex.Message}");
            return false;
        }
       
    }
}