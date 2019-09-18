using System;

namespace Zork
{

    class Program
    {
        private static string CurrentRoom
        {
            get
            {
                return Rooms[Location.Row, Location.Column];
            }
        }
        private static (int Row, int Column) Location = (0, 1);
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Zork!");


            Commands command = Commands.UNKNOWN;
            while (command != Commands.QUIT)
            {
                Console.WriteLine(CurrentRoom);
                Console.Write("> ");
                command = ToCommand(Console.ReadLine().Trim());


                switch (command)
                {
                    case Commands.QUIT:
                        Console.WriteLine("Thank you for playing!");
                        break;
                    case Commands.LOOK:
                        Console.WriteLine("This is an open field west of a white house, with a boarded front door. A rubber mat saying 'Welcome to Zork! lies by the door");
                        break;
                    case Commands.NORTH:
                    case Commands.SOUTH:
                    case Commands.EAST:
                    case Commands.WEST:
                        if (Move(command) == false)
                        {
                            Console.WriteLine("This way is shut!");
                        }
                        else
                            Console.WriteLine($"You moved {command}.");
                        break;

                    default:
                        Console.WriteLine("Unkown command.");
                        break;

                }



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
                    if (Location.Column > 0)
                    {
                        Location.Column--;
                        return true;
                    }

                    break;
                case Commands.EAST:
                    if (Location.Column < Rooms.GetLength(1) - 1)
                    {
                        Location.Column++;

                        return true;

                    }
                    break;




            }
            return false;
        }
    }
}
