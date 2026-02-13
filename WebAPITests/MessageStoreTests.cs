using ApiProject.Services;
using ApiProject.Models;
using Microsoft.Extensions.Logging;
namespace WebAPITests;
public class MessageStoreTests
{
    [Fact]
    public void TestStoreContructor()
    {
        ILogger<MessageStore> logger = new Logger<MessageStore>(new LoggerFactory());
        IMessageStore messageStore = new MessageStore(logger);
        Assert.NotNull(messageStore);
    }
    [Fact]
    public void TestMessageStoreAddMessage()
    {
        ILogger<MessageStore> logger = new Logger<MessageStore>(new LoggerFactory());
        IMessageStore messageStore = new MessageStore(logger);
        MessageEnvelope testMessage = new MessageEnvelope
        {
            Id = Guid.NewGuid(),
            Payload = "Test message",
            Created = DateTime.UtcNow
        };
        messageStore.AddMessage(testMessage);
        var messages = messageStore.GetMessages();
        Assert.Contains(testMessage, messages);
    }
}