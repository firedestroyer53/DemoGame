namespace DemoGame
{
    class DemoGame
    {
        public class Character
        {
            public int Strength { get; set; }
            public int Intelligence { get; set; }
            public int Agility { get; set; }
            public int Reputation { get; set; }
            public int HP { get; set; }
            public string Name { get; set; }
            public Character(int strength, int agility, int intelligence, string name, int reputation, int hp)
            {
                Strength = strength;
                Agility = agility;
                Intelligence = intelligence;
                Name = name;
                Reputation = reputation;
                HP = hp;
            }

        }
        public class NPC
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
        public class Enemy
        {
            public int HP { get; set; }
            public int Attack { get; set; }
            public int Dodge { get; set; }
            public string Name { get; set; }

            public Enemy(int hp, int attack, string name, int dodge)
            {
                HP = hp;
                Attack = attack;
                Name = name;
                Dodge = dodge;
            }
        }

        static Character CreateCharacter()
        {
            const int NUM_INPUTS = 3;

            // Input loop
            Character player = null;
            while (player == null)
            {
                try
                {
                    // Read input and parse to integers
                    int[] inputs = Console.ReadLine().Split(',')
                        .Select(int.Parse).ToArray();

                    // Check number of inputs
                    if (inputs.Length != NUM_INPUTS)
                    {
                        Console.WriteLine($"Invalid number of inputs. Please enter {NUM_INPUTS} inputs.");
                        continue;
                    }

                    // Check skill point total
                    int totalSkillPoints = inputs.Sum();
                    if (totalSkillPoints != 20)
                    {
                        Console.WriteLine("Invalid skill point total. Please assign exactly 20 skill points.");
                        continue;
                    }

                    // Create player character
                    Console.WriteLine("What is your name?");
                    player = new Character(inputs[0], inputs[1], inputs[2], Console.ReadLine(), 50, 100);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input format. Please enter integers separated by commas.");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Input value is too large. Please enter a smaller value.");
                }
            }

            return player;
        }

        static void Battle(Character player, Enemy enemy)
        {
            Console.WriteLine("")
        }

        public static void Main()
        {
            Console.WriteLine("Welcome to [INSERT GAME NAME HERE].");
            Console.WriteLine("Please input your character's stats (strength, agility, intelligence) in the format of an array (e.g. 1,2,3).");
            Console.WriteLine("You need to assign 20 skill points.");
            //Increases the health and attack stats of monsters with the player's
            float LevelScale = 1.0f;
            // Creates the character
            Character player = CreateCharacter();

            Console.WriteLine($"{player.Name} has a strength stat of {player.Strength}, an agility stat of {player.Agility}, and an intelligence stat of {player.Intelligence}.");

            Console.WriteLine("No tutorial yet, here is first battle");
            
    }
}