using BemCase.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection.Emit;

namespace BemCase.Persistence.Contexts;
public class BemCaseDbContext : IdentityDbContext<AppUser, AppRole, int>
{
    protected IConfiguration Configuration { get; set; }
    public DbSet<HealthCheckUrl> HealthCheckUrls { get; set; }

    public BemCaseDbContext(DbContextOptions<BemCaseDbContext> dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
    {
        Configuration = configuration;
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<HealthCheckUrl>(x =>
        {
            x.HasKey(x => x.Id);
            x.ToTable("HealthCheckUrls");
        });
        builder.Entity<AppUser>(x =>
        {
            x.ToTable("AppUsers").HasKey(c => c.Id);
        });
        builder.Entity<AppRole>(x =>
        {
            x.ToTable("AppRoles").HasKey(c => c.Id);
        });
    }
}
