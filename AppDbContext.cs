using Microsoft.EntityFrameworkCore;

namespace hello;

public class AppDbContext : DbContext
{
    public DbSet<Person> People { get; set; } = null!;
    public DbSet<Employee> Employees { get; set; } = null!;
    public DbSet<Department> Departments { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=hello.db");
    }
}
