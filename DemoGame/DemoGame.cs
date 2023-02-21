namespace DemoGame
{
    partial class DemoGame
    {

        static Character CreateCharacter
        {
            get
            {
                const int NUM_INPUTS = 3;

                // Input loop
                Character? player = null;
                while (player == null)
                {
                    try
                    {
                        // Read input and parse to integers
                        int[]? inputs = Console.ReadLine().Split(',')
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

                        List<Item> inventory = new List<Item>();
                        List<Move> moves = new List<Move>();
                        Console.WriteLine("What is your name?");
                        player = new Character(inputs[0], inputs[1], inputs[2], 50, 50, inventory, moves, Console.ReadLine());
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
        }

        static bool Battle(Character player, Enemy enemy)
        {
            Console.WriteLine($"You have encountered a(n) {enemy.Name}.");

            Random random = new Random();

            while (player.HP > 0 && enemy.HP > 0)
            {
                Console.WriteLine("Here are your available moves:");
                for (int i = 0; i < player.Moves.Count; i++)
                {
                    Console.WriteLine((i + 1) + ". " + player.Moves[i].Name);
                }

                int choice;
                while (true)
                {
                    if (int.TryParse(Console.ReadLine(), out choice) && choice >= 1 && choice <= player.Moves.Count)
                    {
                        break;
                    }
                    Console.WriteLine("Invalid input. Please enter a valid move number.");
                }

                Move selectedMove = player.Moves[choice - 1];

                int damage = random.Next(selectedMove.Damage / 2, selectedMove.Damage + 1); // random damage within the range [selectedMove.Damage / 2, selectedMove.Damage]
                enemy.HP -= damage;

                Console.WriteLine($"You used {selectedMove.Name}!");
                Console.WriteLine($"It did {damage} damage!");
                if(enemy.HP > 0)
                {
                    Console.WriteLine($"Current Enemy Health: {enemy.HP} HP.");
                }
                if (enemy.HP <= 0)
                {
                    Console.WriteLine("You have won!");
                    return true;
                }

                damage = random.Next(enemy.Attack / 2, enemy.Attack + 1); // random damage within the range [enemy.Attack / 2, enemy.Attack]
                player.HP -= damage;

                Console.WriteLine($"The enemy attacks! You take {damage} damage!");
                Console.WriteLine($"Current Health: {player.HP}");

                if (player.HP <= 0)
                {
                    Console.WriteLine("You have lost...");
                    return false;
                }
            }

            return false; // this line should be unreachable
        }



        private static void Main()
        {
            Console.WriteLine("Welcome to [INSERT GAME NAME HERE].");
            Console.WriteLine("Please input your character's stats (strength, agility, intelligence) in the format of an array (e.g. 1,2,3).");
            Console.WriteLine("You need to assign 20 skill points.");
            //Increases the health and attack stats of monsters with the player's (not yet implemented)
            float LevelScale = 1.0f;
            // Creates the character
            Character player = CreateCharacter;
            
            Console.WriteLine($"{player.Name} has a strength stat of {player.Strength}, an agility stat of {player.Agility}, and an intelligence stat of {player.Intelligence}.");

            //Test add item and move
            Item sword = new Item(1, "Sword", "A sharp weapon used for combat.");
            Move fireball = new Move(10, 90, "Magic", "Fireball");
            player.Inventory.Add(sword);
            player.Inventory.ForEach(Console.WriteLine);
            
            player.Moves.Add(fireball);
            player.Moves.ForEach(Console.WriteLine);

            Enemy dude = new Enemy(50, 10, "dude");

            Battle(player, dude);

            Console.ReadLine();
        }
    }
}