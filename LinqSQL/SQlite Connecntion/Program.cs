﻿using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace SQLite_EFCore
{
    internal class Program
    {
        static void Main()
        {
            using (var context = new AppDbContext())
            {
                context.Database.EnsureCreated(); 

                InsertData(context);
                ReadData(context);
            }
        }

        static void InsertData(AppDbContext context)
        {
            var user = new User { Name = "John Doe", Age = 30 };
            context.Users.Add(user);
            context.SaveChanges();
            Console.WriteLine("Adat beszúrva.");
        }

        static void ReadData(AppDbContext context)
        {
            var users = context.Users.ToList();
            foreach (var user in users)
            {
                Console.WriteLine($"ID: {user.Id}, Név: {user.Name}, Kor: {user.Age}");
            }
        }
    }

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Age { get; set; }
    }

    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=mydatabase.db");
        }
    }
}
