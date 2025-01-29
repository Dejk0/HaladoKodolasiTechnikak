using System.Security.Cryptography;

namespace NaturalOrdering
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 10, 9, 8, 7, 6 };
            Console.WriteLine("firstThree");
            IEnumerable<int> firstThree = numbers.Take(3);
            foreach (int length in firstThree)
                Console.Write(length + "|");
            Console.WriteLine();
            Console.WriteLine("-----------");
            Console.WriteLine("lastTwo");
            IEnumerable<int> lastTwo = numbers.Skip(3);
            foreach (int length in lastTwo)
                Console.Write(length + "|");
            Console.WriteLine();
            Console.WriteLine("-----------");
            Console.WriteLine("reversed");
            IEnumerable<int> reversed = numbers.Reverse();
            foreach (int length in reversed)
                Console.Write(length + "|");
            Console.WriteLine();
            Console.WriteLine("-----------");

            int firstNumber = numbers.First(); // 10
            int lastNumber = numbers.Last(); // 6
            int secondNumber = numbers.ElementAt(1); // 9
            int secondLowest = numbers.OrderBy(n => n).Skip(1).First();// 7
            int count = numbers.Count(); // 5;
            int min = numbers.Min(); // 6;

            bool hasTheNumberNine = numbers.Contains(9); // true
            bool hasMoreThanZeroElements = numbers.Any(); // true
            bool hasAnOddElement = numbers.Any(n => n % 2 != 0); // true

            int[] seq1 = { 1, 2, 3 };
            int[] seq2 = { 3, 4, 5 };
            IEnumerable<int> concat = seq1.Concat(seq2); // { 1, 2, 3, 3, 4, 5 }
            IEnumerable<int> union = seq1.Union(seq2); // { 1, 2, 3, 4, 5 }



        }
    }
}
