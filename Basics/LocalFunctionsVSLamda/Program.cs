using System.Runtime.InteropServices;

namespace LocalFunctionsVSLamda
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // action("hiii"); cant use before decration
            Action<string> action = (string str) => { Console.WriteLine(str); };
            action("szia"); //just after
            print("Test1");// can use befor decration
            action += print;
            action += print;
            action("Test2"); //write it 3 times
            int age;

            void print(string str)
            {
                Console.WriteLine(str);
            }
            Action<string> action1 = print;
        }
        private static void AnotherFunction()
            {
            //print(); cant see it. 
        }


    }
}
