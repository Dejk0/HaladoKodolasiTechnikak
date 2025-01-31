namespace Object_Initializers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] names = { "Tom", "Dick", "Harry", "Mary", "Jay" };
            IEnumerable<TempProjectionItem> temp =
             from n in names
             select new TempProjectionItem
             {
                 Original = n,
                 Vowelless = n.Replace("a", "").Replace("e", "").Replace("i", "")
             .Replace("o", "").Replace("u", "")
             };

            IEnumerable<string> query = from item in temp
                                        where item.Vowelless.Length > 2
                                        select item.Original;
            foreach (string item in query)
            {
                Console.WriteLine(item+"|");
            }
        }
        class TempProjectionItem
        {
            public string Original; // Original name
            public string Vowelless; // Vowel-stripped name
        }
    }
}
