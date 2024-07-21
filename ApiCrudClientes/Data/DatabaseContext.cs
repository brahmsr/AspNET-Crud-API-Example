using ApiCrud.Models.Entities;
using ApiCrudClientes.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiCrud.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Client> Clients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Client>()
                .HasOne(c => c.Employee)
                .WithMany(e => e.Clients)
                .HasForeignKey(c => c.EmployeeId);
        }
    }
}
