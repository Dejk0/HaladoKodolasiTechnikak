using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static NavigationProperties.Program;

namespace NavigationProperties
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
           
            using var dbContext = new NutshellContext();
            {
                Customer cust = dbContext.Customers.Single(c => c.ID == 1);

                Purchase p1 = new Purchase { Description = "Bike", Price = 500 };
                Purchase p2 = new Purchase { Description = "Tools", Price = 100 };
                cust.Purchases.Add(p1);
                cust.Purchases.Add(p2);
                dbContext.Purchases.Add(p1);



                var customersWithPurchases = dbContext.Customers.Where(c => c.Purchases.Any());
                foreach (var c in customersWithPurchases)
                {
                    Console.WriteLine($"Customer {c.Name} has made the following purchases:");
                    foreach (var p in c.Purchases)
                    {
                        Console.WriteLine($"  {p.Description} for {p.Price:C}");
                    }
                }
            }
            //{
            //    using var dbContext = new NutshellContext();
            //    var cust = dbContext.Customers.First();
            //    Console.WriteLine(cust.Purchases.Count);
            //}

            await dbContext.SaveChangesAsync();
        }
        public class Customer
        {
            public int ID { get; set; }
            public string Name { get; set; }
            // Child navigation property, which must be of type ICollection<T>:
            public virtual List<Purchase> Purchases { get; set; } = new List<Purchase>();
        }
        public class NutshellContext : DbContext
        {
            public virtual DbSet<Customer> Customers { get; set; }
            public virtual DbSet<Purchase> Purchases { get; set; } 
            protected override void OnConfiguring(DbContextOptionsBuilder builder)
            => builder.UseSqlite("Data Source=mydatabase.db");
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Customer>().ToTable("Customer")
                 .HasKey(c => c.ID);

                modelBuilder.Entity<Purchase>()
                 .HasOne(e => e.Customer)
                 .WithMany(e => e.Purchases)
                 .HasForeignKey(e => e.CustomerID);
            }
        }
        public class Purchase
        {
            public int ID { get; set; }
            public DateTime Date { get; set; }
            public string Description { get; set; }
            public decimal Price { get; set; }
            public int CustomerID { get; set; } // Foreign key field
        public Customer Customer { get; set; } // Parent navigation property
        }
    }
}

