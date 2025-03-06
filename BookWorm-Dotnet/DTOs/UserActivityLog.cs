public class UserActivityLog
{
    public int Id { get; set; }
    public string CustomerEmail { get; set; }  // Store user identifier (Email, Username, or GUID)
    public string Action { get; set; }  // "Login" or "Logout"
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
}
