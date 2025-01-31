namespace TheíintoKeyword
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] names = { "Tom", "Dick", "Harry", "Mary", "Jay" };

            IEnumerable<string> query =
                     from n in names
                     select n.Replace("a", "").Replace("e", "").Replace("i", "")
                     .Replace("o", "").Replace("u", "")
                     into noVowel
                     where noVowel.Length > 2
                     orderby noVowel
                     select noVowel;

            foreach (string name in query)
            {
                Console.WriteLine(name);
            }
        }
    }
}
