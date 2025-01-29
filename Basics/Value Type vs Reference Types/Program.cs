using System.Runtime.CompilerServices;
using System.Security.AccessControl;

namespace Value_Type_vs_Reference_Types
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Value Types:
            //int, float, bool, enum, struct
            //csak egy változó mutat egy értékre, esetleg másolatra 
            //nem lehetnek null értékűek

            //Reference Types:
            //class, object, array, string
            //több változó mutat egy objektre 

            
            var myclass = new MyClass();
            myclass.a = 7;
            var myclass2 = myclass;
            myclass2.a = 5;
            Console.WriteLine( myclass.a);//5 mert reference type

            int a = 7;
            int b = a;
            b = a;
            Console.WriteLine(a); //7 mert Value type
            var myStruct = new MyStruct();
            myStruct.a = 7;
            var myStruct2 = myStruct;// készül egy másolat ezért nem már nem lesz köze az eredezihez
            myStruct2.a = 5;
            Console.WriteLine(myStruct.a);//7 mert Value  type
        }
        private class MyClass
        {
            public int a;
        }
        private struct MyStruct
        {
            public int a;
        }
    }

}
