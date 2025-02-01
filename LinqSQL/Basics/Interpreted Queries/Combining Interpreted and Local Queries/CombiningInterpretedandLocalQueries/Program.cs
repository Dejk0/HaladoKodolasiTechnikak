using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
namespace CombiningInterpretedandLocalQueries
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var dbContext = new NutshellContext();
            IEnumerable<string> q = dbContext.Customers
             .Select(c => c.Name.ToUpper())
             .OrderBy(n => n)
             .Pair() // Local from this point on.
             .Select((n, i) => "Pair " + i.ToString() + " = " + n);

            foreach (string element in q) Console.WriteLine(element);



        }
        public class Customer
        {
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
        public static IEnumerable<string> Pair(this IEnumerable<string> source)
        {
            string firstHalf = null;
            foreach (string element in source)
                if (firstHalf == null)
                    firstHalf = element;
                else
                {
                    yield return firstHalf + ", " + element;
                    firstHalf = null;
                }
        }

    }
}
