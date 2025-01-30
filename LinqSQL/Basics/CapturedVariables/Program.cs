namespace CapturedVariables
{
    internal class Program
    {
        static void Main(string[] args)
        {
            {
                int[] numbers = { 1, 2 };
            int factor = 10;
            IEnumerable<int> query = numbers.Select(n => n * factor);
            factor = 20;
            foreach (int n in query) Console.Write(n + "|"); // 20|40|
            }
            Console.WriteLine();
            Console.WriteLine("-------------");

            {
                IEnumerable<char> query = "Not what you might expect";
                query = query.Where(c => c != 'a');
                query = query.Where(c => c != 'e');
                query = query.Where(c => c != 'i');
                query = query.Where(c => c != 'o');
                query = query.Where(c => c != 'u');
                foreach (char c in query) Console.Write(c); // Nt wht y mght xpct
            }
            Console.WriteLine();
            Console.WriteLine("-------------");
            {
                IEnumerable<char> query = "Not what you might expect";
                string vowels = "aeiou";
                //for (int i = 0; i < vowels.Length; i++)
                //    query = query.Where(c => c != vowels[i]);
                for (int i = 0; i < vowels.Length; i++)
                {
                    char vowel = vowels[i];
                    query = query.Where(c => c != vowel);
                }
                foreach (char c in query) Console.Write(c);

            }
        }
    }
}
