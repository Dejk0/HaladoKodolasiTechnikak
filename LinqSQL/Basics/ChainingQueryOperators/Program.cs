using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;


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
            Console.WriteLine(  );

            Console.WriteLine("------------------");


            IEnumerable<string> filtered = names.Where(n => n.Contains("a"));
            IEnumerable<string> sorted = filtered.OrderBy(n => n.Length);
            IEnumerable<string> finalQuery = sorted.Select(n => n.ToUpper());
            foreach (string name in filtered)
                Console.Write(name + "|"); // Harry|Mary|Jay|
            Console.WriteLine();
            foreach (string name in sorted)
                Console.Write(name + "|"); // Jay|Mary|Harry|
            Console.WriteLine();
            foreach (string name in finalQuery)
                Console.Write(name + "|"); // JAY|MARY|HARRY|
            Console.WriteLine(  );


            Console.WriteLine("------------------");
            //Select to transform string type elements to integer type elements:
            string[] names1 = { "Tom", "Dick", "Harry", "Mary", "Jay" };
            IEnumerable<int> query1 = names.Select(n => n.Length);
            foreach (int length in query1)
                Console.Write(length + "|");
            Console.WriteLine();


            Console.WriteLine("------------------");
            string[] names2 = { "Tom", "Dick", "Harry", "Mary", "Jay" };
            IEnumerable<string> sortedByLength, sortedAlphabetically;

            Console.WriteLine("sortedByLength ");
            sortedByLength = names2.OrderBy(n => n.Length);
            foreach (string length in sortedByLength)
                Console.Write(length + "|");
            Console.WriteLine();
            Console.WriteLine("sortedAlphabetically");
            sortedAlphabetically = names2.OrderBy(n => n);
            foreach (string length in sortedAlphabetically)
                Console.Write(length + "|");
            Console.WriteLine( );


            Console.WriteLine("------------------");
        }
    }
}
