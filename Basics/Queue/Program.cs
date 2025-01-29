namespace Queue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //FIFO
            //First In First Out
            //Sorban állásra való. 

            Queue<string> que = new Queue<string>();    
            que.Enqueue("A");
            que.Enqueue("B");
            que.Enqueue("C");

            Console.WriteLine(que.Dequeue()); //"A" az első elem
        }
    }
}
