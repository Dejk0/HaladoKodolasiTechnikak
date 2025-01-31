namespace ChainingDecorators
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<int> query = new int[] { 5, 12, 3 }.Where(n => n < 10)
                                                           .OrderBy(n => n)
                                                           .Select(n => n * 10);
            foreach (int item in query)
            {
                Console.Write(item + "|");
            }
            Console.WriteLine();
            IEnumerable<int>
                     source = new int[] { 5, 12, 3 },
                     filtered = source.Where(n => n < 10),
                     sorted = filtered.OrderBy(n => n),
                     query2 = sorted.Select(n => n * 10);
            foreach (int item in query2)
            {
                Console.Write(item + "|");
            }
        }
    }
}
