using System.Collections;
using System.IO.Pipes;

namespace IEnumarable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            List<int> list = new List<int>();
            foreach (int i in list) { } //it is works
            var player = new Player();

            //foreach (int i in player) { } // it is not works
            //dont get the Enumerable.  

            PlayerStat playerStat = new PlayerStat();
            foreach(Stat stat in playerStat)
            {
                Console.WriteLine(stat.ToString());
            }

        }
        public class PlayerStat : IEnumerable<Stat>
        {
            public Stat Dex = new Stat { name = "Dexterity", value = 10 };
            public Stat Int = new Stat { name = "Intelect", value = 80 };
            public Stat Wis = new Stat { name = "Wisdom", value = 35 };

            public IEnumerator GetEnumerator()
            {
                return new PlayerStatEnumerator(this);
            }
            IEnumerator IEnumerable.GetEnumerator()
            {
                //return GetEnumerator();
                yield return Dex;
                yield return Int;
                yield return Wis;
            }
            IEnumerator<Stat> IEnumerable<Stat>.GetEnumerator()
            {
                throw new NotImplementedException();
            }
            public class PlayerStatEnumerator : IEnumerator<Stat>
            {
                private readonly PlayerStat playerStats;
                private int index;
                public PlayerStatEnumerator(PlayerStat plyerStat)
                {
                    this.playerStats = plyerStat;
                    index = -1;
                }
                public Stat Current {
                    get {
                        switch (index)
                        {
                            default:
                            case 0: return playerStats.Dex;
                            case 1: return playerStats.Int;
                            case 2: return playerStats.Wis;
                        } 
                    }
                }

                Stat IEnumerator<Stat>.Current => throw new NotImplementedException();

                object IEnumerator.Current => Current;

                public void Dispose()
                {
                   // throw new NotImplementedException();
                }

                public bool MoveNext()
                {
                   index++;
                    if (index>2)
                    {
                        index = -1;
                    }
                    return index != -1;
                }

                public void Reset()
                {
                    throw new NotImplementedException();
                }
            }

        }
        
        public class Stat
        {
            public string name { get; set; }
            public int value { get; set; }
            public override string ToString()
            {
                return name + ": " + value;     
            }
        }
        private class Player
        {

        }
    }
}
