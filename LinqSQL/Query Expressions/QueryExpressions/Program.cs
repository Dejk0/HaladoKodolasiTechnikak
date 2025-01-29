namespace QueryExpressions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] names = { "Tom", "Dick", "Harry", "Mary", "Jay" };
            IEnumerable<string> query =
             from n in names
             where n.Contains("a") // Filter elements
             orderby n.Length // Sort elements
             select n.ToUpper(); // Translate each element (project)
            foreach (string name in query) Console.WriteLine(name);
        }
    }
}
