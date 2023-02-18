namespace environmental;

public class Robot
{
    public static void Robot1()
    {
        const int GridHeight = 30;
        const int GridWidth = 30;

        char robotFacing = 'n';
        int robotRow = 0;
        int robotColumn = 0;
        int prevRow = -1;
        int prevColumn = -1;

        int[,] grid = new int[GridHeight, GridWidth];

        Console.WriteLine("Give commands to the robot. 'F' for forward, 'L' for turn left, and 'R' for turn right. It should be laid out like this: FLLFFRF. Keep in mind that the robot starts in the top left corner of the grid.");
        string commands = Console.ReadLine();

        foreach (char c in commands)
        {
            switch (c)
            {
                case 'F':
                    Move(robotFacing);
                    break;
                case 'L':
                    switch (robotFacing)
                    {
                        case 'n':
                            robotFacing = 'w';
                            break;
                        case 's':
                            robotFacing = 'e';
                            break;
                        case 'e':
                            robotFacing = 'n';
                            break;
                        case 'w':
                            robotFacing = 's';
                            break;
                    }
                    break;
                case 'R':
                    switch (robotFacing)
                    {
                        case 'n':
                            robotFacing = 'e';
                            break;
                        case 's':
                            robotFacing = 'w';
                            break;
                        case 'e':
                            robotFacing = 's';
                            break;
                        case 'w':
                            robotFacing = 'n';
                            break;
                    }
                    break;
                default:
                    Console.WriteLine($"Invalid command: {c}");
                    break;
            }

        }

        Console.WriteLine($"The robot ended up in {robotRow}, {robotColumn}");

        void Move(char direction)
        {
            int newRow = robotRow;
            int newColumn = robotColumn;

            switch (direction)
            {
                case 'n':
                    newRow++;
                    break;
                case 's':
                    newRow--;
                    break;
                case 'e':
                    newColumn++;
                    break;
                case 'w':
                    newColumn--;
                    break;
            }

            if (newRow < 0 || newRow >= GridHeight || newColumn < 0 || newColumn >= GridWidth)
            {
                // invalid move
                return;
            }

            grid[robotRow, robotColumn] = 0;
            grid[newRow, newColumn] = 1;
            robotRow = newRow;
            robotColumn = newColumn;

            for (int i = 0; i < GridHeight; i++)
            {
                for (int j = 0; j < GridWidth; j++)
                {
                    if (i == robotRow && j == robotColumn)
                    {
                        Console.Write('R');
                    }
                    else if (grid[i, j] == 1)
                    {
                        Console.Write('X');
                    }
                    else
                    {
                        Console.Write('-');
                    }
                }

                Console.WriteLine();
            }

        }

    }
}