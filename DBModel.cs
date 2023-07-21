namespace API;

using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

public class MyDBContext : DbContext
{
    public DbSet<UserInfo> UserInfo { get; set; }

    public DbSet<UserAmount> UserAmount { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        const string connString = @"Host=localhost;Username=postgres;Password=postgres;Database=test01";
        optionsBuilder
            .UseNpgsql(connString)
            .UseSnakeCaseNamingConvention();
    }
}

public class UserInfo
{
    public long Id { get; set; }

    [MaxLength(128)]
    public string? Name { get; set; }
}

public class UserAmount
{
    public long Id { get; set; }

    public UserInfo? UserInfo { get; set; }

    public long Amount { get; set; }
}