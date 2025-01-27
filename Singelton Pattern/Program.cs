namespace Singelton_Pattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var GM = new GameManager(); it is private
            Console.WriteLine(GameManager.Instance); // it is exist
            GameManager.Instance.TestFunction();           
            Console.WriteLine(GameManager.Instance.TestInt);
        }
        public class GameManager
        {
            private static GameManager instance;
            public static GameManager Instance
            { 
                get { 
                    if (instance == null)
                    {
                        instance = new GameManager();
                    }
                    
                    return instance;
                }
                
                private set {
                    instance = value;
                } 
            }
            private GameManager() {
                if (instance == null)
                {
                    instance = this;
                }
            }
            public int TestInt;
            public void TestFunction()
            {
                Console.WriteLine("The GameManager is exist.");
                TestInt = 20;
            }


        } 
    }
}
