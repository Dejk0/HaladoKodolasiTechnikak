namespace LINQOperators.Projecting
{
    public class Join
    {
        public void Projecting(string[] names)
        {
            // Select: Transform the names to uppercase
            var upperNames = names.Select(n => n.ToUpper());
            Console.WriteLine("Uppercase names: " + string.Join(", ", upperNames));

            // Select:  Calculate the name sting lenght
            var nameLengths = names.Select(n => new { Name = n, Length = n.Length });
            foreach (var item in nameLengths)
            {
                Console.WriteLine($"{item.Name} has {item.Length} characters.");
            }
        }

        private static Join _projectInstance;
        private static readonly object _lock = new object();
        public static Join Instance
        {
            get
            {
                if (_projectInstance == null)
                {
                    lock (_lock)
                    {
                        if (_projectInstance == null)
                        {
                            _projectInstance = new Join();
                        }
                    }
                }
                return _projectInstance;
            }
        }
    }
}