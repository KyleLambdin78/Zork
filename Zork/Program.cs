using System;

namespace Zork
{

    class Program
    {
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
                        outputString = "You moved North";
                        break;
                    case Commands.SOUTH:
                        outputString = "You moved South";
                        break;
                    case Commands.EAST:
                        outputString = "You moved East";
                        break;
                    case Commands.WEST:
                        outputString = "You moved West";
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
    }
}
