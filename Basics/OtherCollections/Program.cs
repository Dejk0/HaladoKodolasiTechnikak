namespace OtherCollections
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //stack
            //FILO
            //First In Last Out
            //könyv kupac példa, amit a teltejére teszel azt tudod levenni legközelebb
            Stack<string> stack = new Stack<string>();

            stack.Push("Deák Tamás");
            stack.Push("Bathory Dóra");
            stack.Push("Oreó");
            Console.WriteLine(stack.Pop()); //"oreo" az utolsó

        }
    }
}
