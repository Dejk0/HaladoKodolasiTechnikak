using System.Security.AccessControl;

namespace Struct
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Olyan mint az Class csak Reference típus helyett Value
            PersonStruct personS = new PersonStruct();   
            personS.a = 1;
            PersonClass personClass = new PersonClass();
            personClass.a = 1;

            TestFunctionStruct(personS);
            TestFunctionClass(personClass);

            Console.WriteLine("Struct " + personS.a); //valtozik
            Console.WriteLine("Class " + personClass.a); //nem valtozik
        }
        public struct PersonStruct
        {
            public int a { get; set; }
        }
        public class PersonClass
        {
            public int a { get; set; }
        }
        public static void TestFunctionStruct(PersonStruct personStruct)
        {
            personStruct.a = 2;
        }
        public static void TestFunctionClass(PersonClass personClass)
        {
            personClass.a = 2;
        }

    }
}
