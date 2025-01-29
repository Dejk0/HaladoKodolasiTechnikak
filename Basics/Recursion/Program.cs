namespace Recursion
{
    public class Program
    {
        static void Main(string[] args)
        {
            //matematikai mód ciklus logikára
            int number = 0;
            while (number <5) {
                number++;
            }
            Console.WriteLine(number);
            Console.WriteLine(TestRecursion(5));


        }
        private static void TestRecursion_()
        {
            TestRecursion_(); // végtelen loop
            //system.stackoverflowexpetion túl sokszor futle a végtelen ciklus.
        }
        private static int TestRecursion(int number)
        {
            if (number < 5) {
               return TestRecursion(number + 1);
            }
            else
            {
                return number;
            }
        }
    }
}
