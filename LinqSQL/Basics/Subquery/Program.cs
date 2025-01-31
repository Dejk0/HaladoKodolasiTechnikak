namespace Subquery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] musos =
            { "David Gilmour", "Roger Waters", "Rick Wright", "Nick Mason" };

            IEnumerable<string> query = musos.OrderBy(m => m.Split().Last());

            foreach (string item in query)
            {
                Console.Write(item + "|");
            }
            Console.WriteLine();
            string[] names = { "Tom", "Dick", "Harry", "Mary", "Jay" };
            //select that elements what character count is match with the the first element. 
            IEnumerable<string> outerQuery = names
             .Where(n => n.Length == names.OrderBy(n2 => n2.Length)
             .Select(n2 => n2.Length).First());

            foreach (string item in outerQuery)
            {
                Console.Write(item + "|");
            }
            Console.WriteLine();

            IEnumerable<string> outerQuery2 =
                 from n in names
                 where n.Length ==
                 (from n2 in names orderby n2.Length select n2.Length).First()
                 select n;
            foreach (string item in outerQuery2)
            {
                Console.Write(item + "|");
            }

            Console.WriteLine();
            //nolonger needs a subquerry
            int shortest = names.Min(n => n.Length);
            IEnumerable<string> query3 = from n in names
                                        where n.Length == shortest
                                        select n;
            foreach (string item in query3)
            {
                Console.Write(item + "|");
            }
        }
    }
}
