using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace Generics
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            List<int> ints = new List<int>(); //it can be anything string/double  class
            
            MyList<int> myIntList = new MyList<int>();  
            myIntList.field = 1;

            MyList<bool> myList = new MyList<bool>();
            myList.field = false;
            Console.WriteLine(myList.field.GetType() + ", " + myIntList.field.GetType());
            Console.WriteLine(myList.MyFunction()+ ", " + myIntList.MyFunction());
            TestFunction(5);
            TestFunction("5");
        }
        private static void GetAttackWinner<TAttackable, TDefendable>(IAttackable attackabel, IDefendable defendable) 
            where TAttackable  : IAttackable where TDefendable : IDefendable
        {
            attackabel.GetAtackPoints();
            defendable.GetDefendPoints();
            //it can be type safe
        }
          
        private interface IAttackable
        {
            public int GetAtackPoints();
            
        }
        private interface IDefendable
        {
            public int GetDefendPoints();
        } 
        private static void TestFunction<T>(T p)
        {
            Console.WriteLine(p);
        }
        private class MyList<T>() //where T : class => it can be only class
        {
            public T field;

            
            public T MyFunction()
            {
                //return null; some type cant be null
                return default;
            }
        }
        private interface MyInterface<T>
        {
            T Value { get; set; }
        }
        
       
    }
}
