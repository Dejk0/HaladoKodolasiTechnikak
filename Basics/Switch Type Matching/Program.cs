namespace SwitchTypeMatching


{
    internal class Program
    {
        static void Main(string[] args)
        {
            IAttacable attacable = new Enemy();
            attacable.Healt = 30;

            //IAttacable attacable = new Player();

            switch (attacable)
            {
                case Player player :
                    player.PlayerSayHello();
                    break;
                    case Enemy enemy when enemy.Healt<40:
                    Console.WriteLine("low healt");
                    break;
            }
        }

        public interface IAttacable
        {
            public void Damage()
            {
                Console.WriteLine("dmg");
            }
            public int Healt { get; set; }
        }
        public class Player() : IAttacable
        {
            public int Healt { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

            public void Damage()
            {
                Console.WriteLine("Player dmg");
            }
            public void PlayerSayHello()
            {
                Console.WriteLine("player say hello");
            }
        }
        public class Enemy() : IAttacable
        {
            public int Healt { get; set; }

            public void Damage()
            {
                Console.WriteLine("Enemy dmg");
            }
        }
        private static void AttackObject(IAttacable attacable)
        {
            attacable.Damage();
        }
        public class Deafault() : IAttacable
        {
            public int Healt { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

            //dont have dmg function.
        }
    }
}
