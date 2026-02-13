using ApiProject.Models;

namespace ApiProject.Services;

public interface IMessageStore
{
    // Retrieve a specific message by its Guid.
    MessageEnvelope GetMessage(Guid messageGuid);
    // Retrieve all messages in the store.
    // NB. This method does not implement pagination or filtering, so it should be used with caution in a production environment.
    List<MessageEnvelope> GetMessages();
    // Get the number of messages currently stored.
    int StoreLength();
    // Add a new message to the store.
    bool AddMessage(MessageEnvelope message);
}