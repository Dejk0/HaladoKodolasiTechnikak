namespace InventoryExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var GoldInventory = new Inventory<Gold>();
            var WoodInventory = new Inventory<Wood>();

            //GoldInventory.Add(new Wood()); cant work. Type error
            WoodInventory.Add(new Wood());  // it is work
           
        }
        private class Gold
        {

        }
        private class Wood
        {

        }
        private class Inventory<T>{
            public void Add(T t) { }
        } 
    }
}
