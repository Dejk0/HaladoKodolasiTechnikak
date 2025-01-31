using System.Linq;
using System.Collections.Generic;


namespace HowDeferredExecutionWorks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numbers = new List<int> { 1, 2, 3, 4, 5 };
            var squaredNumbers = numbers.MySelect(n => n * n);

            foreach (var num in squaredNumbers)
            {
                Console.WriteLine(num);
            }
        }
    }
    public static class EnumerableExtensions
    {
        public static IEnumerable<TResult> MySelect<TSource, TResult>
            (this IEnumerable<TSource> source, Func<TSource, TResult> selector)
        {
            foreach (TSource element in source)
                yield return selector(element);
        }
    }
}
