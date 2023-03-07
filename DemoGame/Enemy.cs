namespace DemoGame
{
    [Serializable]
    internal class Enemy
    { 
        public int HP { get; set; }
        public int Attack { get; set; }
        public string Name { get; set; }
        public Type type { get; set; }
        public Enemy(int hp, int attack, string name, Type type)
        {
            HP = hp;
            Attack = attack;
            Name = name;
            this.type = type;
        }
    }
    
}