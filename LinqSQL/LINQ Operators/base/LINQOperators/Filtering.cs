namespace LINQOperators.Filter
{
    public class Filter
    {
        public void Filtering(string[] names)
        {
            //Filterint
            // 1. Where - Filters elements based on a condition
            var whereResult = names.Where(n => n.Length == 4);
            Console.WriteLine("Where: " + string.Join(", ", whereResult)); // Output: Mary, Dick

            // 2. Take – Takes the first N elements (e.g., first 3 names)
            var takeResult = names.Take(3);
            Console.WriteLine("Take: " + string.Join(", ", takeResult)); // Output: Tom, Dick, Harry

            // 3. TakeLast – Takes the last N elements (e.g., last 2 names)
            var takeLastResult = names.TakeLast(2);
            Console.WriteLine("TakeLast: " + string.Join(", ", takeLastResult)); // Output: Mary, Jay

            // 4. TakeWhile – Takes elements while the condition is true (e.g., while the name is 3 letters long)
            var takeWhileResult = names.TakeWhile(n => n.Length == 3);
            Console.WriteLine("TakeWhile: " + string.Join(", ", takeWhileResult)); // Output: Tom

            // 5. Skip – Skips the first N elements (e.g., skips the first 2 names)
            var skipResult = names.Skip(2);
            Console.WriteLine("Skip: " + string.Join(", ", skipResult)); // Output: Harry, Mary, Jay

            // 6. SkipLast – Skips the last N elements (e.g., skips the last 3 names)
            var skipLastResult = names.SkipLast(3);
            Console.WriteLine("SkipLast: " + string.Join(", ", skipLastResult)); // Output: Tom, Dick

            // 7. SkipWhile – Skips elements while the condition is true (e.g., while the name is 3 letters long)
            var skipWhileResult = names.SkipWhile(n => n.Length == 3);
            Console.WriteLine("SkipWhile: " + string.Join(", ", skipWhileResult)); // Output: Dick, Harry, Mary, Jay

            // 8. Distinct – Removes duplicate elements
            var distinctResult = names.Distinct();
            Console.WriteLine("Distinct: " + string.Join(", ", distinctResult)); // Output: Tom, Dick, Harry, Mary, Jay

            // 9. DistinctBy – Takes unique elements based on a specific condition (e.g., unique name lengths)
            var distinctByResult = names.DistinctBy(n => n.Length);
            Console.WriteLine("DistinctBy: " + string.Join(", ", distinctByResult)); // Output: Tom, Dick, Harry
        }
    
     private static Filter _filter;
        private static readonly object _lock = new object();

        public static Filter Instance
        {
            get
            {
                if (_filter == null)
                {
                    lock (_lock)
                    {
                        if (_filter == null)
                        {
                            _filter = new Filter();
                        }
                    }
                }
                return _filter;
            }
        }
    } }