namespace Dictionary
{
    internal class Program
    {
        private enum ResourceType
        {
            Stone,
            Wood,
            Gold
           
        }
        static void Main(string[] args)
        {
            //Képes tárolni a kulcs érték párosítást
            //Generics*
            Dictionary<ResourceType,int> ResoursTypAmountDicitionary = new Dictionary<ResourceType,int>();
            ResoursTypAmountDicitionary.Add(ResourceType.Stone, 56);
            ResoursTypAmountDicitionary.Add(ResourceType.Wood, 26);
            Console.WriteLine( ResoursTypAmountDicitionary[ResourceType.Stone]);
            //mivel mindenből csak 1 lehet így halmaz számításokra kíváló
            ResoursTypAmountDicitionary.ContainsKey(ResourceType.Wood); // megtalálható benn? van értéke?
            if (ResoursTypAmountDicitionary.TryGetValue(ResourceType.Gold, out int goldamount)){
                Console.WriteLine(goldamount);
            };
            ResoursTypAmountDicitionary.Remove(ResourceType.Gold);  // bár nem is volt de törölhető.
            foreach (KeyValuePair<ResourceType, int> keyValuePair in ResoursTypAmountDicitionary)
            {
                Console.WriteLine(keyValuePair.Key + ": " + keyValuePair.Value);
            }
        }
    }
}
