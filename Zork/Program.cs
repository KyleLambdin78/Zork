using System;

namespace Zork
{

    class Program
    {
        private static (int Row, int Column) Location = (0, 1);
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Zork!");

            // string inputString = Console.ReadLine();
            Commands command = Commands.UNKNOWN;
            while (command != Commands.QUIT)
            {
                Console.Write("> ");
                command = ToCommand(Console.ReadLine().Trim());

                string outputString;
                switch (command)
                {
                    case Commands.QUIT:
                        outputString = "Thank you for playing!";
                        break;
                    case Commands.LOOK:
                        outputString = "This is an open field west of a white house, with a boarded front door. A rubber mat saying 'Welcome to Zork! lies by the door";
                        break;
                    case Commands.NORTH:
                    case Commands.SOUTH:
                    case Commands.EAST:
                    case Commands.WEST:
                        outputString = $"You moved {command}.";
                        break;

                    default:
                        outputString = "Unkown command.";
                        break;

                }

                Console.WriteLine(outputString);
                // Console.WriteLine(command);
            }
            
        }
        private static Commands ToCommand(string commandString) => Enum.TryParse(commandString, true, out Commands result) ? result : Commands.UNKNOWN;
        private static string[,] Rooms =
        {
            {"Forest", "West of House", "Behind House", "Clearing", "Canyon View" }
        };

        private static bool Move(Commands command)
        {
            switch (command)
            {
                case Commands.WEST:
                    if(Location.Column > 0)
                    {
                        Location.Column--;
                    }
                    break;
                case Commands.EAST:
                    if(Location.Column > 0)
                    {
                        Location.Column++;
                    }
                    break;
                
            }
        }
    }
}
