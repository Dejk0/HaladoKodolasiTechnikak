using System.Reflection.Metadata;

namespace MixedSyntaxQueries
{
    internal class Program
    {
        static void Main(string[] args)
        {
             string[] names = { "Tom", "Dick", "Harry", "Mary", "Jay" };
            {
                //mixed
                int matches = (from n 
                               in names 
                               where n.Contains("a") 
                               select n).Count();
                // 3
                Console.WriteLine(matches);
                string first = (from n 
                                in names 
                                orderby n 
                                select n).First(); // Dick
                Console.WriteLine(first);
            }
            Console.WriteLine("---------------");
            {
                //fluent
                int matches = names.Where(n => n.Contains("a")).Count(); // 3
                string first = names.OrderBy(n => n).First();
                Console.WriteLine(matches);
                Console.WriteLine(first);
            }
        }
    }
}
