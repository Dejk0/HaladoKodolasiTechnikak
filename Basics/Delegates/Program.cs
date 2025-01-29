namespace Delegates
{
    internal class Program
    {
        //only return with void. cant return with value.
        //looklike variable but storing functions

        private delegate void AttackDelegate();
        private delegate int MyDelegate(string str);
        private static AttackDelegate attackAction;
        private static Action myAction;
        private static Func<int> attackFunc; 

        static void Main(string[] args)
        {
            attackAction = MeleeAttack;
            attackAction();
            // MyDelegate myDelegate = MeleeAttack(); no version from it. cant use it.
            MyDelegate myDelegate = MyTestFunction;
            myDelegate("MeleeAttack");
            myAction = MeleeAttack;
            attackFunc = MyTestFunction1;

            Action action = () => { };//lamda
            Action action2 = () => { Console.WriteLine("Action2"); };
            Func<int,bool> func  = (int i) => false;

            attackAction = RangeAttack;
            attackAction();
            attackAction -= RangeAttack;
            attackAction += MeleeAttack;
            attackAction += RangeAttack;
            Console.WriteLine("-----------------------");
            attackAction();

        }

        private static void MeleeAttack()
        {
            Console.WriteLine( "MeleeAttack");
        }
        private static void RangeAttack()
        {
            Console.WriteLine("RangeAttack");
        }
        private static int MyTestFunction(string mystring)
        {
            return 0;
        }
        private static int MyTestFunction1()
        {
            return 0;
        }
    }
}
