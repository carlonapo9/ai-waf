using System.Net.Http;
using WafGateway.TestClient.AttackProfiles;

var client = new HttpClient();
string baseUrl = "http://localhost:5181";

var attacks = new[]
{
    AttackLibrary.SqlInjection,
    AttackLibrary.XssAttack,
    AttackLibrary.PathTraversal
};

foreach (var attack in attacks)
{
    Console.WriteLine($"\n=== Running: {attack.Name} ===\n");

    for (int i = 0; i < attack.Repeat; i++)
    {
        foreach (var path in attack.Paths)
        {
            var url = baseUrl + path;

            var response = await client.GetAsync(url);

            Console.WriteLine($"{response.StatusCode} | {path}");

            await Task.Delay(attack.DelayMs);
        }
    }
}

Console.WriteLine("\nAll attack profiles completed.");
