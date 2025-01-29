namespace NestedLoops
{
    internal class Program
    {
        static void Main(string[] args)
        {

            for (int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 4; j++)
                {
                    Console.WriteLine(i + ", " +j );
                }
            }
            //szebben kifjezve
            int[,] intarray = new int[3,2];
            for (int i = 0; i < intarray.GetLength(0); i++)
            {
                for (int j = 0; j < intarray.GetLength(1); j++)
                {
                    Console.WriteLine(i + ", " + j);
                }
            }
            Console.WriteLine("-----------");
            for (int i = 0; i < intarray.GetLength(0); i++)
            {
                for (int j = 0; j < intarray.GetLength(1); j++)
                {
                    Console.WriteLine(i + ", " + j);
                    //break; megszakítja a ciklust
                    //continue; kihajda a következőt ebben a ciklusban
                    //cw("ezt hajda ki")
                    if (i == 0)
                    {
                        continue;
                    }
                    Console.WriteLine( "valami"); // az első iterációban nem fut
                }
            }
        }
    }
}
