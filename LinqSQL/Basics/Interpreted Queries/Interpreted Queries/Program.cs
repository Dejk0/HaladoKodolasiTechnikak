using System.Collections.Generic;
using System.Reflection.Emit;
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore;

namespace Interpreted_Queries
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var dbContext = new NutshellContext();
            
            IQueryable<string> query = from c in dbContext.Customers
                                       where c.Name.Contains("a")
                                       orderby c.Name.Length
                                       select c.Name.ToUpper();
            foreach (string name in query) Console.WriteLine(name);
        }

        public class Customer
        {
            public int ID { get; set; }
            public string Name { get; set; }
        }
        // We’ll explain the following class in more detail in the next section.
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
}
