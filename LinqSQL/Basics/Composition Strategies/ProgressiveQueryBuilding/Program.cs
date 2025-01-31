using System.Text.RegularExpressions;

namespace ProgressiveQueryBuilding
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] names = { "Tom", "Dick", "Harry", "Mary", "Jay" };

            IEnumerable<string> query = names
                   .Select(n => n.Replace("a", "").Replace("e", "").Replace("i", "")
                   .Replace("o", "").Replace("u", ""))
                   .Where(n => n.Length > 2)
                   .OrderBy(n => n);

            //better
            query = names
                   .Select(n => Regex.Replace(n, "[aeiou]", ""))
                   .Where(n => n.Length > 2)
                   .OrderBy(n => n);

            query = from n in names
                     select n.Replace("a", "").Replace("e", "").Replace("i", "")
                     .Replace("o", "").Replace("u", "");


            query = from n in query where n.Length > 2 orderby n select n;

            foreach (string name in query)
            {
                Console.Write(name + "|");
            }

        }
    }
}
