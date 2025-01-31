namespace ScopingRules
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] names = { "Tom", "Dick", "Harry", "Mary", "Jay" };

            var query =
                 from n1 in names
                 select n1.ToUpper()
                 into n2 // Only n2 is visible from here on.
                 where n1.Contains("x") // Illegal: n1 is not in scope.
                 select n2;
            var query2 = names
                 .Select(n1 => n1.ToUpper())
                 .Where(n2 => n1.Contains("x")); // Error: n1 no longer in scope

        }
    }
}
