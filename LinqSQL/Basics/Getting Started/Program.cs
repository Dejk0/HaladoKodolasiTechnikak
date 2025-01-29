

namespace Getting_Started
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] names = { "Tom", "Dick", "Harry" };

            //IEnumerable<string> filteredNames = Enumerable.Where
            // (names, n => n.Length >= 4);
            //foreach (string n in filteredNames)
            //    Console.WriteLine(n);

            //Fluent Syntax
            IEnumerable<string> filteredNames = names.Where(n => n.Length >= 4);
            foreach (string name in filteredNames) Console.WriteLine(name);

            //query expression
            IEnumerable<string> filteredNames1 = from n in names
                                                where n.Contains("a")
                                                select n;
            foreach (string name in filteredNames1) Console.WriteLine(name);


        }

    }
}
