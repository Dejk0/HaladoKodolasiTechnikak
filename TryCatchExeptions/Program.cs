namespace TryCatchExeptions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Player player = new Player();
                player.TestFunction();
                int a = 0;
                int b = 1 / a;
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("DivideByZeroException");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            finally {
                Console.WriteLine("finaly");
            }

        }
        class Player()
        {
            public class InvalidPalyerNameExeption : Exception
            {

            }
            public void TestFunction()
            {
               // throw new Exception("PlayerExeption");
               throw new InvalidPalyerNameExeption();   
            }
        }
    }
}
