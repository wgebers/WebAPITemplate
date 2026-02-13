
using ApiProject.Models;
namespace WebAPITests;
public class MessageEnvelopeTests
{
// baseline model constructor tests
    // Ensure the message object is created and initialized correctly. 
    [Fact]
    public void TestMessageEnvelope()
    {
        MessageEnvelope testEnvelope = new MessageEnvelope();
        Assert.False(testEnvelope.Encrypted);
        Assert.Null(testEnvelope.From);
        Assert.Null(testEnvelope.To);
        Assert.Null(testEnvelope.Payload);
        Assert.True(testEnvelope.Id == Guid.Empty);
    }
}