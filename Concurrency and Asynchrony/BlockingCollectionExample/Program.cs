using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        using (BlockingCollection<int> collection = new BlockingCollection<int>(5)) // Maximális kapacitás: 5 elem
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            Task producer = Task.Run(() =>
            {
                for (int i = 1; i <= 10; i++)
                {
                    collection.Add(i);
                    Console.WriteLine($"Producer: Added {i}, Timer: {watch.ElapsedMilliseconds} ms");
                    Thread.Sleep(500); 
                }
                collection.CompleteAdding(); // Jelzi, hogy nem adunk több elemet
            });

            Task consumer = Task.Run(() =>
            {
                foreach (int item in collection.GetConsumingEnumerable()) // Folyamatosan olvas, amíg van elem
                {
                    Console.WriteLine($"Consumer: Processed {item}, Timer: {watch.ElapsedMilliseconds} ms");
                    Thread.Sleep(1000); 
                }
            });

            Task.WaitAll(producer, consumer);
        }

        Console.WriteLine("Processing complete.");

        /*
         *  Producer: Added 1, Timer: 4 ms
            Consumer: Processed 1, Timer: 4 ms
            Producer: Added 2, Timer: 512 ms
            Producer: Added 3, Timer: 1013 ms
            Consumer: Processed 2, Timer: 1013 ms
            Producer: Added 4, Timer: 1529 ms
            Consumer: Processed 3, Timer: 2014 ms
            Producer: Added 5, Timer: 2044 ms
            Producer: Added 6, Timer: 2545 ms
            Consumer: Processed 4, Timer: 3029 ms
            Producer: Added 7, Timer: 3060 ms
            Producer: Added 8, Timer: 3576 ms
            Consumer: Processed 5, Timer: 4036 ms
            Producer: Added 9, Timer: 4083 ms
            Producer: Added 10, Timer: 4599 ms
            Consumer: Processed 6, Timer: 5044 ms
            Consumer: Processed 7, Timer: 6058 ms
            Consumer: Processed 8, Timer: 7068 ms
            Consumer: Processed 9, Timer: 8077 ms
            Consumer: Processed 10, Timer: 9081 ms
            Processing complete.
         */
    }
}
