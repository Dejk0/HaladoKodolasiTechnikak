using LINQOperators.Projecting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Azure.Core.HttpHeader;

namespace LINQOperators.Join
{
    public class Join
    {
        public void Joining(string[] names, int[] ages){

            var nameAgePairs = names.Zip(ages, (name, age) => new { Name = name, Age = age });


            foreach (var item in nameAgePairs)
            {
                Console.WriteLine($"{item.Name} is {item.Age} years old");
            }
        }
private static Join _joinInstance;
        private static readonly object _lock = new object();
        public static Join Instance
        {
            get
            {
                if (_joinInstance == null)
                {
                    lock (_lock)
                    {
                        if (_joinInstance == null)
                        {
                            _joinInstance = new Join();
                        }
                    }
                }
                return _joinInstance;
            }
        }
    }
}
