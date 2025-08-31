using CybersecDomain.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CybersecDomain.context;

public class CyberSecDbContext : DbContext
{
    public CyberSecDbContext(DbContextOptions options) : base(options)
    {
    }

    public virtual DbSet<Logo> Logos { get; set; }
    public virtual DbSet<Profile> Profiles { get; set; }
    public virtual DbSet<KeySkill> KeySkills { get; set; }
    public virtual DbSet<Knowledge> Knowledge { get; set; }
    public virtual DbSet<Deliverable> Deliverable { get; set; }
    public virtual DbSet<MainTask> MainTasks { get; set; }
    public virtual DbSet<AlternativeTitle> AlternativeTitles { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory()))
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();
            
            var connectionString = config.GetConnectionString("CybersecDatabase");
            
            optionsBuilder.UseMySql(connectionString, 
                new MySqlServerVersion(new Version(8, 0, 21)),
                mysqlOptions => mysqlOptions.EnableRetryOnFailure(
                    maxRetryCount: 5,       
                    maxRetryDelay: TimeSpan.FromSeconds(10),
                    errorNumbersToAdd: null));
        }
    }
}