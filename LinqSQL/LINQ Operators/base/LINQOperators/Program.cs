using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using LINQOperators.Filter;
using LINQOperators.Projecting;


namespace LINQOperators
{
    internal class Program 
    {
        static void Main(string[] args)
        {
            string[] names = { "Tom", "Dick", "Harry", "Mary", "Jay" };
            string[] names2 = { "Tom", "Eric", "Jay", "Bela" };
            int[] ages = { 30, 25, 35, 28, 40 };

            Filter.Filter.Instance.Filtering(names);
            Console.WriteLine("----------------");
            Projecting.Join.Instance.Projecting(names);
            Console.WriteLine("----------------");
            Join.Join.Instance.Joining(names, ages);
            Console.WriteLine("----------------");
            Ordering.Order.Instance.Ordering(names, ages);


        }

        public class NutshellContext : DbContext
        {
            public DbSet<Customer> Customers { get; set; }
            public DbSet<Purchase> Purchases { get; set; }
            protected override void OnConfiguring(DbContextOptionsBuilder builder)
               => builder.UseSqlite("Data Source=mydatabase.db");
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Customer>(entity =>
                {
                    entity.ToTable("Customer");
                    entity.Property(e => e.Name).IsRequired(); // Column is not nullable
                });
                modelBuilder.Entity<Purchase>(entity =>
                {
                    entity.ToTable("Purchase");
                    entity.Property(e => e.Date).IsRequired();
                    entity.Property(e => e.Description).IsRequired();
                });
            }
        }
        public class Customer
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public virtual List<Purchase> Purchases { get; set; }
            = new List<Purchase>();
        }
        public class Purchase
        {
            public int ID { get; set; }
            public int? CustomerID { get; set; }
            public DateTime Date { get; set; }
            public string Description { get; set; }
            public decimal Price { get; set; }
            public virtual Customer Customer { get; set; }
        }

    }
}
