namespace WafGateway.TestClient.AttackProfiles;

public class AttackProfile
{
    public string Name { get; set; } = "";
    public List<string> Paths { get; set; } = new();
    public int DelayMs { get; set; } = 100;
    public int Repeat { get; set; } = 10;
}
