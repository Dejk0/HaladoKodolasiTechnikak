using System.Security.Cryptography.X509Certificates;

namespace Class_Intermadiate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var unit = new Unit();
            unit.Speed = 10;
            unit.Move();
            var player = new Player();
            player.Speed = 10; //örökli a unit osztálytól.
            player.Move(); //örökli a unit osztálytól.
            Console.WriteLine("----------------");
            var unit2 = new Unit2();
            unit2.Move();
            var player2 = new Player2("Tamás");
            player2.Move(); //örökli a unit osztálytól. A név ugyan az a működés egyedi.
            
            Console.WriteLine(player2.ToString());

            Unit2 UnitTest = player2;
            UnitTest.Move();// move player mert abból készült 
            var player3 = new Player3();
            player3.jump();

            test();//destructor példa
            GC.Collect();
            Console.ReadKey();

            //var unit3 = new Unit3(); hibára fut mert abstract nem lehet

            /*
            Move
            Move
            ----------------
            Move unit
            ProtectedMove player
            Move player
            Player name is Tamás
            Move player
            ProtectedMove player
            Player name is Test alany
            elpusztult
            */
}
public static void test()
{
var player = new Player2("Test alany");
Console.WriteLine(player.ToString());
//destructor példa, a void lefutása után elpusztul
}
public class Unit
{
public float Speed { get; set; }
public void Move() 
{
    Console.WriteLine("Move");
}
}
private class Player : Unit //öröklés 
{

}
private class Unit2
{
public float Speed { get; set; }
public virtual void Move()
{
    Console.WriteLine("Move unit");
}
}
private class Player2 : Unit2 //öröklés
{
public override void Move()
{
    Console.WriteLine("Move player");

}
protected void ProtectedMove()
{
    Console.WriteLine("ProtectedMove player");

}
//minden osztály része a tostring ami újra íható
public override string ToString()
{
    return "Player name is " + Name; 
}
public string Name { get; set; }
~Player2() // distructor akkor futle amikor elpusztul az osztály
{
    Console.WriteLine("elpusztult");
}
public Player2(string name) //ctor akkor futle amikor keletkezik
{
    Name = name;
    ProtectedMove();
}

}
abstract class Unit3
{
public abstract void jump();
}
class Player3 : Unit3
{
public override void jump()
{
    //throw new NotImplementedException(); // mindenképpen hozzá kll addni az abstract void-ot
}
}


}

}
