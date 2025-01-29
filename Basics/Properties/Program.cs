namespace Properties
{
    public class Program
    {
        // Egyszerre változó és metódus is.
        // a get és a set eszközeivel metódust lehet írni ha az írásra és az olvasásra.

        //prop
        public static string name { get; set; }
        //ha privat csak az osztály tudja írni/olvasni, ha public bárki 
        private static string Name {

            get {
                //validation
                if(name ==null) {
                    return "UnKnown";
                }
                return name;
            } 
            //private set //csak az egyiket lehet 
            set
            {
                if (value == "Deák Tamás") {
                    throw new Exception("nem lehet ez a neve");
                }
                name = value;
            }
        }
        static void Main(string[] args)
        {
            //Name = "Deák Tamás";
            Console.WriteLine(Name);
            Name = "Deák Tamás";
            Console.WriteLine(Name);
        }
    }
}
