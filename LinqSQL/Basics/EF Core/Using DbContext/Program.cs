using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Using_DbContext
{
    internal class Program
    {
        static void Main(string[] args)
        {

            using var dbContext = new NutshellContext();
            Customer cust = new Customer()
            {
                Name = "Sara Wells"
                //ID = 1
            };
            dbContext.Customers.Add(cust);
            dbContext.Entry(cust).Reload(); // Reloads the entity from the database
            dbContext.SaveChanges(); // Writes changes back to database
            Console.WriteLine(dbContext.Customers.Count());

        }
        public class Customer
        {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int ID { get; set; }
            public string Name { get; set; }
        }
        public class NutshellContext : DbContext
        {
            public virtual DbSet<Customer> Customers { get; set; }
            protected override void OnConfiguring(DbContextOptionsBuilder builder)
            => builder.UseSqlite("Data Source=mydatabase.db");
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            => modelBuilder.Entity<Customer>().ToTable("Customer")
            .HasKey(c => c.ID);
        }
    }

    public static class Extensions
    {
        public static IEnumerable<TSource> AsEnumerable<TSource>
            (this IEnumerable<TSource> source)
        {
            return source;
        }

    }
}

