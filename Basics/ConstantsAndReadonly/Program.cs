namespace ConstantsAndReadonly
{
    internal class Program
    {
        private const float Player_Speed = 5f;
        //private const Player player = new Player();
        private readonly Player player = new Player(100);
        static void Main(string[] args)
        {
            int age;
            age = 5;
            age = 7;
           // Math.PI = 3; //it is constant
           //Player_Speed = age; //it is constant
        }
        class Player
        {
            private readonly int healtMax;
            public Player(int Mh)
            {
                this.healtMax = Mh;
            }
        }
    }
}
