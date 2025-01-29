namespace IsAsCasting

{
    internal class Program
    {
        static void Main(string[] args)
        {
            IAttacable attacable = new Player();
            attacable.Damage(); //Player dmg

            Console.WriteLine( attacable.GetType());
            if (attacable is Player)
            {
               //attackable.PlayerSayHello is not awilablel. 
            }
            if (attacable.GetType() == typeof( Player))
            {

            }
            if (attacable is Player)
            {
                Player player = attacable as Player;
                player.PlayerSayHello();
            }
            Player player1 = new Player();
            Enemy enemy = new Enemy();

            Player testPlayer = attacable as Player;
            Console.WriteLine(testPlayer);

            int a = 5;
            //float f = a as (float); // only referenc type
            float f = (float)a;

            //boxing
            int b = 5;
            object obj = a;
            int c = (int)obj; //5
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
            public int Healt { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

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
