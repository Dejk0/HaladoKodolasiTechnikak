// NB: All samples in this chapter assume the following namespace imports:
using System;
using System.Threading;
namespace ConcurrencyAandAsynchrony
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Thread t = new Thread(WriteY); // Kick off a new thread
            t.Start(); // running WriteY()
                       // Simultaneously, do something on the main thread.
            for (int i = 0; i < 1000; i++) Console.Write("x");
            void WriteY()
            {
                for (int i = 0; i < 1000; i++) Console.Write("y");
            }
        }
    }
}
