namespace DeferredExecution
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numbers = new List<int> { 1 };
            IEnumerable<int> query = numbers.Select(n => n * 10); // Build query
            numbers.Add(2); // Sneak in an extra element
            foreach (int n in query)
                Console.Write(n + "|");

            Action a = () => Console.WriteLine("Foo");
            // We’ve not written anything to the Console yet. Now let’s run it:
            a(); // Deferred execution!

            int matches = numbers.Where(n => n <= 2).Count();
            Console.WriteLine(matches);

        }
    }
}
