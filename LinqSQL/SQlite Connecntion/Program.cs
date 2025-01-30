using System;
using Microsoft.Data.Sqlite;
using SQLitePCL;

namespace SQlite_Connecntion
{
    internal class Program
    {
        static void Main()
        {
            Batteries.Init();  
            string connectionString = "Data Source=mydatabase.db;";

            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                CreateTable(connection);
                InsertData(connection);
                ReadData(connection);
            }
        }
    
    static void CreateTable(SqliteConnection connection)
        {
            string tableQuery = @"
            CREATE TABLE IF NOT EXISTS Users (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Name TEXT NOT NULL,
                Age INTEGER NOT NULL
            );";

            using (var command = new SqliteCommand(tableQuery, connection))
            {
                command.ExecuteNonQuery();
            }
        }
        static void CreateTable2(SqliteConnection connection)
        {
            string tableQuery = @"
            CREATE TABLE IF NOT EXISTS Users (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Name TEXT NOT NULL,
                Age INTEGER NOT NULL
            );";

            using (var command = new SqliteCommand(tableQuery, connection))
            {
                command.ExecuteNonQuery();
            }
        }

        static void InsertData(SqliteConnection connection)
        {
            string insertQuery = "INSERT INTO Users (Name, Age) VALUES (@name, @age);";

            using (var command = new SqliteCommand(insertQuery, connection))
            {
                command.Parameters.AddWithValue("@name", "John Doe");
                command.Parameters.AddWithValue("@age", 30);
                command.ExecuteNonQuery();
            }

            Console.WriteLine("Adat beszúrva.");
        }

        static void ReadData(SqliteConnection connection)
        {
            string selectQuery = "SELECT Id, Name, Age FROM Users;";

            using (var command = new SqliteCommand(selectQuery, connection))
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Console.WriteLine($"ID: {reader.GetInt32(0)}, Név: {reader.GetString(1)}, Kor: {reader.GetInt32(2)}");
                }
            }
        }
    }
}
