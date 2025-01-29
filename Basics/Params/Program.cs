namespace Params
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //sajnos ez a technika megsérti a Clean Code szabályokat, mi szerint törekedni kell a
            //lehető legkevesebb paraméterre ezért nem szoktam használni.

            PrintName("Deák Tamás");//1 név
            PrintName2("Deák Tamás", "Báthory Dóra");
            PrintName3("Deák Tamás", "Báthory Dóra");// 2
        }
        private static void PrintName(string name)
        {
            Console.WriteLine(name);

        }
        private static void PrintName2(string name1, string name2)
        {
            Console.WriteLine(name1 + name2);
        }
        private static void PrintName3(params string[] strings) 
        {
            //bár mennyi paraméteret belehet írni.
            //szabály h a pram a végén legyen.
            Console.WriteLine(strings.Length);
        }
    }
}
