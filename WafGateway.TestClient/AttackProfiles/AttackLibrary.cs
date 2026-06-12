namespace WafGateway.TestClient.AttackProfiles;

public static class AttackLibrary
{
    public static AttackProfile SqlInjection = new()
    {
        Name = "SQL Injection Wave",
        DelayMs = 120,
        Repeat = 20,
        Paths = new()
        {
            "/login?user=admin'--",
            "/search?q=1' OR 1=1",
            "/product?id=1 UNION SELECT",
            "/api/data?id=0; DROP TABLE users"
        }
    };

    public static AttackProfile XssAttack = new()
    {
        Name = "XSS Burst",
        DelayMs = 100,
        Repeat = 15,
        Paths = new()
        {
            "/page?name=<script>alert(1)</script>",
            "/comment?text=<img src=x onerror=alert(1)>",
            "/search?q=<svg onload=alert(1)>"
        }
    };

    public static AttackProfile PathTraversal = new()
    {
        Name = "Path Traversal Scan",
        DelayMs = 80,
        Repeat = 15,
        Paths = new()
        {
            "/../../etc/passwd",
            "/../../../windows/system32",
            "/file?path=../../config"
        }
    };
}
