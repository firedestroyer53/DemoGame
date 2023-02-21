namespace DemoGame
{
    partial class DemoGame
    {
        private class NPC
        {
            public int LikabilityScore { get; set; }
            public string[] Dialogue { get; set; }
            public int Reputation { get; set; }
            public bool IsAllyable { get; set; }
            public string Name { get; set; }

            public NPC(int likabilityScore, string[] dialogue, string name, int reputation, bool isAllyable)
            {
                LikabilityScore = likabilityScore;
                Dialogue = dialogue;
                Reputation = reputation;
                Name = name;
                IsAllyable = isAllyable;
            }
        }
    }
}