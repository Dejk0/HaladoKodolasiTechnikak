namespace Reevaluation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            {
                var numbers = new List<int>() { 1, 2 };
                IEnumerable<int> query = numbers.Select(n => n * 10);
                foreach (int n in query) Console.Write(n + "|"); // 10|20|
                numbers.Clear();
                foreach (int n in query) Console.Write(n + "|"); // <nothing>
            }
            Console.WriteLine();
            Console.WriteLine("-------------");
            {
                var numbers = new List<int>() { 1, 2 };
                List<int> timesTen = numbers
                                     .Select(n => n * 10)
                                     .ToList(); // Executes immediately into a List<int>
                numbers.Clear();
                Console.WriteLine(timesTen.Count); // Still 2
            }

        }
    }
}
