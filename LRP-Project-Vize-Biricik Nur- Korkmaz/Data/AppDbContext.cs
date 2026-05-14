using Microsoft.EntityFrameworkCore;
using LRPProject.Models;

namespace LRPProject.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    // Veritabanındaki tablolarımızı temsil eden setler
    public DbSet<User> Users { get; set; }
    public DbSet<Lab> Labs { get; set; }
    public DbSet<Computer> Computers { get; set; }

    // Tablo yapılandırmaları (Gerekirse burada detaylandırılabilir)
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
