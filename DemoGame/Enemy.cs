namespace DemoGame
{
    partial class DemoGame
    {
        [Serializable]
        private class Enemy
        {

            public int HP { get; set; }
            public int Attack { get; set; }
            public string Name { get; set; }

            public Enemy(int hp, int attack, string name)
            {
                HP = hp;
                Attack = attack;
                Name = name;
            }
        }
    }
}