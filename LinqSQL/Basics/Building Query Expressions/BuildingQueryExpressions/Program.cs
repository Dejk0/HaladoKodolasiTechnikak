using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq.Expressions;
using System.Reflection.Emit;

namespace Using_DbContext
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Test();

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
            public virtual DbSet<Product> Products { get; set; }
            protected override void OnConfiguring(DbContextOptionsBuilder builder)
            => builder.UseSqlite("Data Source=mydatabase.db");
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            => modelBuilder.Entity<Customer>().ToTable("Customer")
            .HasKey(c => c.ID);
        }

        public class Product
        {
            public int ID { get; set; }
            public string Description { get; set; }
            public bool Discontinued { get; set; }
            public DateTime LastSale { get; set; }
            public static Expression<Func<Product, bool>> IsSelling()
            {
                return p => !p.Discontinued && p.LastSale > DateTime.Now.AddDays(-30);
            }

        }
        static void Test()
        {
            var dbContext = new NutshellContext();
            Product[] localProducts = dbContext.Products.ToArray();
            IQueryable<Product> sqlQuery =
            dbContext.Products.Where(Product.IsSelling());
            IEnumerable<Product> localQuery =
            localProducts.Where(Product.IsSelling().Compile());
        }

    }

}

