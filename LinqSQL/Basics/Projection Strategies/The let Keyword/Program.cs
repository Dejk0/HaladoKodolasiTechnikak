namespace The_let_Keyword
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] names = { "Tom", "Dick", "Harry", "Mary", "Jay" };
            IEnumerable<string> query =
             from n in names
             let vowelless = n.Replace("a", "").Replace("e", "").Replace("i", "")
             .Replace("o", "").Replace("u", "")
             where vowelless.Length > 2
             orderby vowelless
             select n; // Thanks to let, n is still in scope.
        }
    }
}
