using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQOperators.Ordering
{
    public class Order
    {
        public void Ordering(string[] names, int[] ages)
        {
            Console.WriteLine("--------------OrderBy");
            var orderedNames = names.OrderBy(name => name);  // Növekvő sorrendben rendezés

            foreach (var name in orderedNames)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine("--------------OrderByDescending");
            var orderedNamesDescending = names.OrderByDescending(name => name);  // Csökkenő sorrend

            foreach (var name in orderedNamesDescending)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine("--------------ThenBy");
            var orderedNamesByAgeThenName = names
        .Zip(ages, (name, age) => new { Name = name, Age = age })
        .OrderBy(person => person.Age)        // Először életkor szerint növekvő
        .ThenBy(person => person.Name);       // Majd név szerint növekvő

            foreach (var person in orderedNamesByAgeThenName)
            {
                Console.WriteLine($"{person.Name} ({person.Age} years old)");
            }
            Console.WriteLine("--------------ThenByDescending");
            var orderedNamesByAgeThenNameDesc = names
        .Zip(ages, (name, age) => new { Name = name, Age = age })
        .OrderBy(person => person.Age)             // Először életkor szerint növekvő
        .ThenByDescending(person => person.Name);  // Majd név szerint csökkenő

            foreach (var person in orderedNamesByAgeThenNameDesc)
            {
                Console.WriteLine($"{person.Name} ({person.Age} years old)");
            }
            Console.WriteLine("--------------Reverse");
            var reversedNames = names.Reverse();  // Fordított sorrend

            foreach (var name in reversedNames)
            {
                Console.WriteLine(name);
            }
        }


        private static Order _orderingInstance;
        private static readonly object _lock = new object();
        public static Order Instance
        {
            get
            {
                if (_orderingInstance == null)
                {
                    lock (_lock)
                    {
                        if (_orderingInstance == null)
                        {
                            _orderingInstance = new Order();
                        }
                    }
                }
                return _orderingInstance;
            }
        }
    }
}
