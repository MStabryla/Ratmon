namespace Ratmon.Models;

using Ratmon;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

public class RatmonDbContext : IdentityDbContext<IdentityUser,IdentityRole,string>
{
    private string _SqlLiteFolderPath = System.IO.Path.Combine(Environment.CurrentDirectory, "db");
    public string DbPath { get; }

    public RatmonDbContext(IOptions<MainConfig> config)
    {
        DbPath = Path.Join(_SqlLiteFolderPath, config.Value.DbPath ?? "database.db");
    }

    public DbSet<Mouse2> Mouse2Set { get; set; }
    public DbSet<Mouse2B> Mouse2BSet { get; set; }
    public DbSet<MouseCombo> MouseComboSet { get; set; }
    public DbSet<Mas2> Mas2Set { get; set; }

    public DbSet<Mouse2_Config> Mouse2_Config { get; set; }
    public DbSet<Mouse2B_Config> Mouse2B_Config { get; set; }
    public DbSet<MouseCombo_Config> MouseCombo_Config { get; set; }
    public DbSet<Mas2_Config> Mas2_Config { get; set; }

    private static IdentityRole[] _identityRoles = [
        new() { Name = "User", Id = "480b1f22-de49-48fe-bdf3-6a3e96874bcb"},
        new() { Name = "Admin", Id = "68df6475-5ea9-4f40-881d-2a2e70153f3b"},
    ];

    private static IdentityUser[] _users = [
        //password = Matthew_zaq1@WSX
        new() { UserName = "Matthew", NormalizedUserName = "matthew", Email ="Matthew", NormalizedEmail="matthew", Id = "06fe2a37-21cf-4945-8fc6-22bf93faa3ea"},
        //password = John_zaq1@WSX
        new() { UserName = "John", NormalizedUserName = "john", Email = "John", NormalizedEmail="john", Id = "ab608d43-0dcf-4d14-b926-b7fc30afc510"}
    ];
    
    private static IdentityUserRole<string>[] _identityUserRoles = [
        new() {
            UserId = "06fe2a37-21cf-4945-8fc6-22bf93faa3ea",
            RoleId = "480b1f22-de49-48fe-bdf3-6a3e96874bcb"
        },
        new() {
            UserId = "ab608d43-0dcf-4d14-b926-b7fc30afc510",
            RoleId = "68df6475-5ea9-4f40-881d-2a2e70153f3b"
        },
    ];

    protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite($"Data Source={DbPath}").UseSeeding((context, _) =>
    {
        var passwordHasher = new PasswordHasher<IdentityUser>();

        if (context.Set<IdentityRole>().Count() < 1)
            context.Set<IdentityRole>().AddRange(_identityRoles);
        if (context.Set<IdentityUser>().Count() < 1)
        {
            var newUsers = _users.ToList();
            newUsers.ForEach(x =>
            {
                x.PasswordHash = passwordHasher.HashPassword(x, x.UserName + "_zaq1@WSX");
            });
            context.Set<IdentityUser>().AddRange(newUsers);
        }
        if (context.Set<IdentityUserRole<string>>().Count() < 1)
            context.Set<IdentityUserRole<string>>().AddRange(_identityUserRoles);
        context.SaveChanges();


        // context.Set<IdentityRole>().AddRange(_identityRoles);
        // context.Set<IdentityUser>().AddRange(_users);
        // context.Set<IdentityUserRole<string>>().AddRange(_identityUserRoles);
        // context.SaveChanges();
    });

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

    }

}
