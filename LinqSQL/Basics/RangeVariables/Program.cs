namespace RangeVariables
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //from n in names            // n is our range variable
            //where n.Contains("a")      // n = directly from the array
            //orderby n.Length           // n = subsequent to being filtered
            //select n.ToUpper()         // n = subsequent to being sorted

             // names.Where(n => n.Contains("a"))   // Locally scoped n
             //.OrderBy(n => n.Length)              // Locally scoped n
             //.Select(n => n.ToUpper())            // Locally scoped n

        }
    }
}
