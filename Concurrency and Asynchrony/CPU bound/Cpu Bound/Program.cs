using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        int n = 100_000_0; 

        var stopwatch = Stopwatch.StartNew();
        var primes = FindPrimesSerial(n);
        stopwatch.Stop();
        Console.WriteLine($"Soros: {primes.Count} prímszámot találtunk.");
        Console.WriteLine($"Elapsed Time: {stopwatch.ElapsedMilliseconds} ms");

        stopwatch = Stopwatch.StartNew();
        primes = FindPrimesParallel(n);
        stopwatch.Stop();
        Console.WriteLine($"Párhuzamos: {primes.Count} prímszámot találtunk.");
        Console.WriteLine($"Elapsed Time: {stopwatch.ElapsedMilliseconds} ms");
        /*  Soros: 1000000 prímszámot találtunk.
            Elapsed Time: 2079 ms
            Párhuzamos: 1000000 prímszámot találtunk.
            Elapsed Time: 1517 ms*/
    }

    static List<int> FindPrimesSerial(int n)
    {
        List<int> primes = new();
        for (int i = 2; primes.Count < n; i++)
        {
            if (IsPrime(i))
            {
                primes.Add(i);
            }
        }
        return primes;
    }

    static List<int> FindPrimesParallel(int n)
    {
        List<int> primes = new();
        object lockObj = new();

        Parallel.ForEach(Enumerable.Range(2, int.MaxValue - 2), (i, state) =>
        {
            if (primes.Count >= n) state.Stop(); 
            if (IsPrime(i))
            {
                lock (lockObj)
                {
                    if (primes.Count < n) primes.Add(i);
                }
            }
        });

        return primes;
    }

    static bool IsPrime(int num)
    {
        if (num < 2) return false;
        if (num == 2 || num == 3) return true;
        if (num % 2 == 0) return false;

        int boundary = (int)Math.Sqrt(num);
        for (int i = 3; i <= boundary; i += 2)
        {
            if (num % i == 0) return false;
        }

        return true;
    }
}
