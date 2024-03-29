﻿using Newtonsoft.Json;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
namespace DemoGame
{
    public class DemoGame
    {
        private static void SaveGame(Character player, World world)
        {
            string fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "saved_game.json");

            using (StreamWriter writer = new StreamWriter(fileName))
            {
                Newtonsoft.Json.JsonSerializer serializer = new Newtonsoft.Json.JsonSerializer();
                serializer.Serialize(writer, player);
                serializer.Serialize(writer, world);
            }
            Console.WriteLine($"Game saved to saved_game.json.");
        }
        private static Tuple<Character,World> LoadGame()
        {
            string fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "saved_game.json");

            if (!File.Exists(fileName))
            {
                Console.WriteLine($"Save file '{fileName}' not found.");
                return null;

            }
            using (StreamReader reader = new StreamReader(fileName))
            {
                Newtonsoft.Json.JsonSerializer serializer = new Newtonsoft.Json.JsonSerializer();
                Character player = (Character)serializer.Deserialize(reader, typeof(Character));
                World world = (World)serializer.Deserialize(reader, typeof(World));
                return new Tuple<Character, World>(player, world);
                
            }
        }
        private static World CreateWorld()
        {
            Type Normal = new Type("Normal", null, null, null);
            Enemy Guy = new Enemy(10, 10, "Guy", Normal);
            Enemy Guy2 = new Enemy(20, 20, "Guy2", Normal);
            Enemy Guy3 = new Enemy(30, 30, "Guy3", Normal);
            // random generation of world
            Random rnd = new Random();
            int numSectors = rnd.Next(5, 10);
            List<Sector> sectors = new List<Sector>();
            for (int i = 0; i < numSectors; i++)
            {
                // random generation of enemies
                int numEnemies = rnd.Next(1, 5);
                List<Enemy> enemies = new List<Enemy>();
                for (int j = 0; j < numEnemies; j++)
                {
                    int enemyType = rnd.Next(1, 4);
                    // adding random enemy to the list
                    switch (enemyType)
                    {
                        case 1:
                            enemies.Add(Guy);
                            break;
                        case 2:
                            enemies.Add(Guy2);
                            break;
                        case 3:
                            enemies.Add(Guy3);
                            break;
                    }
                }
                // adding sector to the list
                sectors.Add(new Sector("Sector " + i, enemies, sectors));
            }
            return new World(sectors);
            }


        private static Tuple<Character,World> Intro()
        {
            Console.WriteLine("Welcome to [INSERT GAME NAME HERE].");
            Console.WriteLine("Enter '1' to start a new game or '2' to load a saved game.");

            string input = Console.ReadLine();
            bool newCharacter = false;

            Character player;
            if (input == "2")
            {
                Console.WriteLine("Loading game...");
                return LoadGame();
            }
            else
            {
                Console.WriteLine("Please input your character's stats (strength, agility, intelligence) in the format of an array (e.g. 1,2,3).");
                Console.WriteLine("You need to assign 20 skill points.");
                player = GetCreateCharacter();
                newCharacter = true;
            }

            Console.WriteLine($"{player.Name} has a strength stat of {player.Strength}, an agility stat of {player.Agility}, and an intelligence stat of {player.Intelligence}.");
            if (newCharacter == true)
            {
                // Test add item and move
                Type Magic = new Type("Magic", null, null, null);
                Item sword = new Item(1, "Sword", "A sharp weapon used for combat.");
                Move fireball = new Move(10, 90, Magic, "Fireball");
                player.Inventory.Add(sword);


                player.Moves.Add(fireball);
            }
            Console.WriteLine("Inventory:");
            player.Inventory.ForEach(Console.WriteLine);
            Console.WriteLine("Moveset:");
            player.Moves.ForEach(Console.WriteLine);
            World world = CreateWorld();
            return new Tuple<Character,World>(player,world);   
        }

        private static Character GetCreateCharacter()
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
                    player = new Character(inputs[0], inputs[1], inputs[2], 50, 100, inventory, moves, Console.ReadLine());
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

        static bool Battle(Character player, Enemy enemy)
        {
            Console.WriteLine($"You have encountered a(n) {enemy.Name}.");
            int initialHealth = player.HP;
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
                    player.HP = initialHealth;
                    return true;
                }

                damage = random.Next(enemy.Attack / 2, enemy.Attack + 1); // random damage within the range [enemy.Attack / 2, enemy.Attack]
                player.HP -= damage;

                Console.WriteLine($"The enemy attacks! You take {damage} damage!");
                

                if (player.HP <= 0)
                {
                    Console.WriteLine("You have lost...");
                    player.HP = initialHealth / 2;
                    return false;
                }
                else
                {
                    Console.WriteLine($"Current Health: {player.HP}");
                }
            }
            
            return false; // this line should be unreachable
        }

        private static void Main()
        {
            Tuple<Character,World> Introvar = Intro();
            Character player = Introvar.Item1;
            World world = Introvar.Item2;


            Console.WriteLine("Do you want to save your game? (y/n)");

            var input = Console.ReadLine();
            if (input?.ToLower() == "y")
            {
                SaveGame(player, world);
                Console.WriteLine("Game saved.");
            }
        }
    }
}