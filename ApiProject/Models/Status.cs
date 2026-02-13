public class ServerStatus
{
    public string ServerId { get; set; } = string.Empty;
    public DateTime ServerTime { get; set; } = DateTime.UtcNow; 
    public long UptimeSeconds { get; set; } = 0;
    public long ErrorLogLength { get; set; } = 0;
}