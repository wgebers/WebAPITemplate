namespace ApiProject.Models;

// General wrapper around XML/JSON payload
// If marked encrypted, it is assumed the receiver knows how to process the message
public class MessageEnvelope {
	public MessageEnvelope()
	{
		Id = new Guid();
		Created	 = DateTime.Now;
		Status = 0;
		Encrypted = false;
		

	}

	public Guid Id {get;set;}
	public DateTime Created {get;set;}
	public MessageStatus Status {get;set;}
	public string From {get;set;}
	public string To {get;set;}
	public string Payload {get;set;}
	public bool Encrypted {get;set;}
}

public enum MessageStatus :ushort
{
	Unknown = 0,
	Initialized = 1,
	Ready = 2,
	Sent = 3

}