using BistroBook.Model;
using Microsoft.EntityFrameworkCore;

namespace BistroBook.Date
{
    public class BistroBookContext : DbContext
    {
        public BistroBookContext(DbContextOptions<BistroBookContext> options) : base(options)
        {
            
        }

        public DbSet<Table> Tables { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Menu> Menus { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Define a unique index on the combination of TableID, Date, and Time
            modelBuilder.Entity<Reservation>()
                .HasIndex(r => new { r.FK_TableID, r.Date, r.Time })
                .IsUnique();

            modelBuilder.Entity<Customer>().HasData
                (
                    new Customer { CustomerId = 1, FirstName = "Emil", LastName = "Ejderklev", Email = "Emil.Ejderklev@gmail.com", PhoneNumber = "0727022881"},
                    new Customer { CustomerId = 2, FirstName = "Johan", LastName = "Anderson", Email = "Johan.Anderson@gmail.com", PhoneNumber = "0727022882" },
                    new Customer { CustomerId = 3, FirstName = "Anton", LastName = "StenBerg", Email = "Anton.StenBerg@gmail.com", PhoneNumber = "0727022883" },
                    new Customer { CustomerId = 4, FirstName = "Ida", LastName = "Lundberg", Email = "Ida.Lundberg@gmail.com", PhoneNumber = "0727022884" },
                    new Customer { CustomerId = 5, FirstName = "Julia", LastName = "Levenhagen", Email = "Julia.Levenhagen@gmail.com", PhoneNumber = "0727022885" }
                );
        }
    }
}
