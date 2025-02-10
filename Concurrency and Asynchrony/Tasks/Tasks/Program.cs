namespace Tasks
{
    internal class Program
    {
        static async Task Main()
        {
            var task1 = Task.Delay(3000);
            var task2 = Task.Delay(2000); 
            var task3 = Task.Delay(1000); 

            var firstCompletedTask = await Task.WhenAny(task1, task2, task3);

            Console.WriteLine("Az első befejeződött feladat befejeződött.");

            await Task.WhenAll(task1, task2, task3);
            Console.WriteLine("Minden feladat befejeződött.");
        }
    }
}
