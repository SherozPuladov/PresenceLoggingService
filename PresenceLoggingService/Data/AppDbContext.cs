using Microsoft.EntityFrameworkCore;
using PresenceLoggingService.Models;

namespace PresenceLoggingService.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
        
    }
    
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Shift> Shifts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Employee>()
            .HasOne(e => e.Role)
            .WithMany(r => r.Employees)
            .HasForeignKey(e => e.RoleId);

        modelBuilder.Entity<Employee>()
            .HasMany(e => e.Shifts)
            .WithOne(s => s.Employee)
            .HasForeignKey(s => s.EmployeeId);

        modelBuilder.Entity<Employee>()
            .HasOne(e => e.LastShift)
            .WithOne(s => s.Employee)
            .HasForeignKey<Employee>(e => e.LastShiftId);

        modelBuilder.Entity<Shift>()
            .HasOne(s => s.Employee)
            .WithMany(e => e.Shifts)
            .HasForeignKey(s => s.EmployeeId);
    }
}