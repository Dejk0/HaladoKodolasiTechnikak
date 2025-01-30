using Dapper;
using System.Data.SqlClient;

Console.WriteLine("Querying for blogs");

await using var connection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Blog");

var sql = "SELECT * FROM Blogs WHERE BlogId = 1";

var results = await connection.QueryAsync<Blog>(sql);

foreach (var s in results)
{
    Console.WriteLine("Blog id: " + s.BlogId + " Blog URL: " + s.Url);
}
