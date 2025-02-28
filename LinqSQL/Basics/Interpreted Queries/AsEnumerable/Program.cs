﻿using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace AsEnumerable
{
    internal class Program
    {
        static void Main(string[] args)
        {

            using var dbContext = new NutshellContext();



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
        public static IEnumerable<TSource> AsEnumerable<TSource>
            (this IEnumerable<TSource> source)
        {
            return source;
        }

    }
}
