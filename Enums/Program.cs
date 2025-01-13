using System.ComponentModel;
using System.Runtime.CompilerServices;
using static Enums.Program.Car;

namespace Enums
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Ez a módszer abban segít, hogy egyszerűbb és érhetőbb kódot
            //lehessen írni bizonyos állapotok kifejezésére
            var car = new Car();
            car.HandleState();
           
            car.state = Car.State.forward;
            car.state++;
            Console.WriteLine(car.state); //backward
            Console.WriteLine((int)car.state); //2
            Console.WriteLine("-------------");
            var _state = car.state;
            foreach(Car.State state in Enum.GetValues(typeof(Car.State)))
            {
                Console.WriteLine(state);
            }
            Console.WriteLine();
        }

        public class Car()
        {
            public void HandleState()
            {
                switch (state)
                {
                    case State.forward:
                        //számítás, animáció, logika
                        break;
                    case State.backward:
                        break;
                    case State.stay:
                        break;
                }
            }
            public State state;
            public enum State
            {
                stay,
                forward,
                backward
            }           
        }
    }
}
