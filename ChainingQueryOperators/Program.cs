using System;
using System.Collections.Generic;
using System.Linq;


namespace ChainingQueryOperators
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] names = { "Tom", "Dick", "Harry", "Mary", "Jay" };
            IEnumerable<string> query = names
             .Where(n => n.Contains("a"))
             .OrderBy(n => n.Length)
             .Select(n => n.ToUpper());
            foreach (string name in query) Console.WriteLine(name);

            //The variable, n, in our example, is privately scoped to each of
            //the lambda expressions. We can reuse the identifier n for the
            //same reason that we can reuse the identifier c in the following
            //method:

                foreach (char c in "string1") Console.Write(c);
                foreach (char c in "string2") Console.Write(c);
                foreach (char c in "string3") Console.Write(c);
            

        }
    }
}
