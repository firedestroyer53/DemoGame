namespace DemoGame
{
    partial class DemoGame
    {
        private class Move
        {
            public int Damage { get; set; }
            public int Accuracy { get; set; }
            public string Type { get; set; }
            public string Name { get; set; }

            public Move(int damage, int accuracy, string type, string name)
            {
                Damage = damage;
                Accuracy = accuracy;
                Type = type;
                Name = name;
            }
            public override string ToString()
            {
                return $"{Name} ({Type}): {Damage} damage, {Accuracy}% accurate";
            }
        }
    }
}