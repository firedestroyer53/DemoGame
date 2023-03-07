namespace DemoGame
{
    internal class Item
    {
        public int Amount { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Item(int amount, string name, string description)
        {   
            Amount = amount;
            Name = name;
            Description = description;
        }
        public override string ToString()
        {
            return $"{Name} (x{Amount}): {Description}";
        }
    }
}