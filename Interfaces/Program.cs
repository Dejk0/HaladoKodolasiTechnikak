namespace Interfaces
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IAttacable attacable = new Player();
            attacable.Damage(); //Player dmg
            AttackObject(new Player()); //Player dmg
            AttackObject(new Enemy()); //Enemy dmg
            AttackObject(new Deafault()); //dmg
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
