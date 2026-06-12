using Microsoft.EntityFrameworkCore;
using WafGateway.Models;

namespace WafGateway.Data;

public class WafDbContext : DbContext
{
    public WafDbContext(DbContextOptions<WafDbContext> options) : base(options) { }

    public DbSet<WafLog> Logs => Set<WafLog>();
}
