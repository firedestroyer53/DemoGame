namespace DemoGame
{
    [Serializable]

    internal class Move
    {
        public int Damage { get; set; }
        public int Accuracy { get; set; }
        public Type Type { get; set; }
        public string Name { get; set; }
            

        public Move(int damage, int accuracy, Type type, string name)
        {
            Damage = damage;
            Accuracy = accuracy;
            Type = type;
            Name = name;
        }
            
        //To string method
        public override string ToString()
        {
            return $"{Name} (Damage: {Damage}, Accuracy: {Accuracy}, Type: {Type.ToString2})";
        }
    }
}