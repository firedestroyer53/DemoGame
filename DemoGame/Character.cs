namespace DemoGame
{
    partial class DemoGame
    {
        [Serializable]
        private class Character
        {
            public int Strength { get; set; }
            public int Intelligence { get; set; }
            public int Agility { get; set; }
            public int Reputation { get; set; }
            public int HP { get; set; }

            public List<Item> Inventory { get; set; }
            public List<Move> Moves { get; set; }

            public string Name { get; set; }
            public Character(int strength, int agility, int intelligence, int reputation, int hp, List<Item> inventory, List<Move> moves, string name)
            {
                Strength = strength;
                Agility = agility;
                Intelligence = intelligence;
                Reputation = reputation;
                HP = hp;
                Inventory = inventory;
                Moves = moves;
                Name = name;
            }

        }
    }
}