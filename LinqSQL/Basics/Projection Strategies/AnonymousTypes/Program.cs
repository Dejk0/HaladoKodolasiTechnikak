namespace AnonymousTypes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] names = { "Tom", "Dick", "Harry", "Mary", "Jay" };

            var intermediate = from n in names
                               select new
                               {
                                   Original = n,
                                   Vowelless = n.Replace("a", "").Replace("e", "").Replace("i", ""),
                                   test = n
                               .Replace("o", "").Replace("u", "")
                               };
            IEnumerable<string> query = from item in intermediate
                                        where item.Vowelless.Length > 2
                                        select item.Original;

            foreach (var item in query)
            {
                Console.WriteLine(item);
            }

            var query2 = from n in names
                        select new
                        {
                            Original = n,
                            Vowelless = n.Replace("a", "").Replace("e", "").Replace("i", "")
                        .Replace("o", "").Replace("u", "")
                        }
                        into temp
                        where temp.Vowelless.Length > 2
                        select temp.Original;


        }
        //class TempProjectionItem   // it is not needed
        //{
        //    public string Original; // Original name
        //    public string Vowelless; // Vowel-stripped name
        //}
    }
}
