namespace Multi_Dimensional_Arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //pl mozi székeinek foglalására lehet használni, hisz a darabszám fix, kevésbé változik

            int[,] intArray =new int[5,6];

            Console.WriteLine(intArray.Length); //5*6=30
            for (int i = 0; i < intArray.GetLength(0); i++) {
                for (int j = 0; j < intArray.GetLength(1); j++)
                {
                    //cw
                    Console.WriteLine(i+", " + j +": "+ intArray[i,j]);
                }
            }
            //fontos, hogy ugyan annyi elemet tartalmazzanak.
            intArray = new int[,] { { 1, 2 ,3 }, { 4, 5, 6 } };
            for (int i = 0; i < intArray.GetLength(0); i++)
            {
                for (int j = 0; j < intArray.GetLength(1); j++)
                {
                    //cw
                    Console.WriteLine(i + ", " + j + ": " + intArray[i, j]);
                }
            }
            //arrayarray
            int[][] intArray2 = new int[5][];
            for (int i = 0; i < intArray.GetLength(0); i++)
            {
                intArray2[i] = new int[6];
                //feltöltés
            }
            //modosítás
            intArray2[0][5] = 5;

            //egyedi array
            int[][] intarray3 = new int[5][];
            intarray3[0] = new int[3];
            intarray3[1] = new int[6];
            intarray3[2] = new int[10];
        }
    }
}
