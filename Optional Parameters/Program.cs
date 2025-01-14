namespace Optional_Parameters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Alap paraméter hozzáadása, úgy hogy az csak opcionális 
            NameAge(30); 
            NameAge(30, "Béla");
            NameAge(name: "Bence");

            

        }

        private static void NameAge(
            int age = default, 
            string name = "Deák Tamás") //fontos, hogy csak utolsó paraméterek
                                        //szerepelhetnek alap értékkel
        {
            Console.WriteLine(name + " is " + age +" years old.");
        }
    }
}
