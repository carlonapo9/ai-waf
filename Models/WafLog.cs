namespace WafGateway.Models;

public class WafLog
{
    public int Id { get; set; }
    public string? Ip { get; set; }
    public string? Path { get; set; }
    public string? Method { get; set; }
    public int StatusCode { get; set; }
    public DateTime Timestamp { get; set; }
}
