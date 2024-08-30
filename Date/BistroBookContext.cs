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
            //modelBuilder.Entity<Reservation>()
            //    .HasIndex(r => new { r.FK_TableId, r.Date, r.Time })
            //    .IsUnique();

            modelBuilder.Entity<Customer>().HasData
                (
                    new Customer { CustomerId = 1, FirstName = "Jan", LastName = "Eriksson", Email = "Jan.Eriksson@gmail.com", PhoneNumber = "0701234567"},
                    new Customer { CustomerId = 2, FirstName = "Johan", LastName = "Anderson", Email = "Johan.Anderson@gmail.com", PhoneNumber = "0702345678" },
                    new Customer { CustomerId = 3, FirstName = "Anton", LastName = "StenBerg", Email = "Anton.StenBerg@gmail.com", PhoneNumber = "0703456789" },
                    new Customer { CustomerId = 4, FirstName = "Ida", LastName = "Lundberg", Email = "Ida.Lundberg@gmail.com", PhoneNumber = "0704567890" },
                    new Customer { CustomerId = 5, FirstName = "Julia", LastName = "Levenhagen", Email = "Julia.Levenhagen@gmail.com", PhoneNumber = "0705678901" }
                );

            modelBuilder.Entity<Table>().HasData
                (
                    new Table { TableId = 1, TableNumber = 1, SeatCount = 4 },
                    new Table { TableId = 2, TableNumber = 2, SeatCount = 6 },
                    new Table { TableId = 3, TableNumber = 3, SeatCount = 2 },
                    new Table { TableId = 4, TableNumber = 4, SeatCount = 8 },
                    new Table { TableId = 5, TableNumber = 5, SeatCount = 5 }
                );

            modelBuilder.Entity<Menu>().HasData
                (
                    new Menu { MenuId = 1, DishName = "Swedish Meatballs", Description = "Tender meatballs served with creamy mashed potatoes, lingonberry sauce, and gravy.", Price = 120, IsAvailable = true },
                    new Menu { MenuId = 2, DishName = "Grilled Salmon Fillet", Description = "Fresh salmon fillet grilled to perfection, served with dill sauce and roasted vegetables.", Price = 180, IsAvailable = true },
                    new Menu { MenuId = 3, DishName = "Creamy Mushroom Pasta", Description = "Tagliatelle pasta tossed in a creamy mushroom sauce with a hint of garlic and Parmesan.", Price = 140, IsAvailable = true },
                    new Menu { MenuId = 4, DishName = "Crispy Chicken Salad", Description = "Crisp chicken strips served on a bed of mixed greens, cherry tomatoes, cucumbers, and honey mustard dressing.", Price = 99, IsAvailable = true },
                    new Menu { MenuId = 5, DishName = "Shrimp Skagen", Description = "A classic Swedish shrimp salad mixed with mayonnaise, dill, and lemon, served on toast.", Price = 115, IsAvailable = false }
                );

            modelBuilder.Entity<Reservation>().HasData(
                new Reservation
                {
                    ReservationId = 1,
                    FK_CustomerId = 1,
                    FK_TableId = 1,
                    Date = new DateTime(2024, 8, 29),
                    StartTime = new TimeSpan(18, 0, 0),
                    EndTime = new TimeSpan(19, 0, 0),
                    GuestCount = 2
                },
                new Reservation
                {
                    ReservationId = 2,
                    FK_CustomerId = 2,
                    FK_TableId = 2,
                    Date = new DateTime(2024, 8, 30),
                    StartTime = new TimeSpan(20, 0, 0),
                    EndTime = new TimeSpan(21, 0, 0),
                    GuestCount = 2
                }
    );
        }
    }
}
