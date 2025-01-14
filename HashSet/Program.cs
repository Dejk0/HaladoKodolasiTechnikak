namespace HashSet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //minden element egyedi
            HashSet<string> set = new HashSet<string>();    

            set.Add("a");
            set.Add("b");
            set.Add("c");
            Console.WriteLine(set.Count); //3
            set.Add("c");
            Console.WriteLine(set.Count); //3 mert duplikált a "c" és csak egyszer szerepelhet

            set.Union(set); // Halmaz műveletekre való ahol csak 1x szerepelhetnek az elemek
        }
    }
}
