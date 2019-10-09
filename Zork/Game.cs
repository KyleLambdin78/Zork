using System;
using System.IO;
using Newtonsoft.Json;

namespace Zork
{
    public class Game
    {
        public World World { get; set; }
        [JsonIgnore]
        public Player Player { get; private set; }
        [JsonIgnore]
        private bool IsRunning { get; set; }
        [JsonIgnore]
        public CommandsManager CommandsManager { get; }

        

        public Game(World world, Player player)
        {
            World = world;
            Player = player;
        }

        public Game()
        {
            Commands[] commands =
            {
                new Commands("LOOK", new string[] { "LOOK", "L"},
                (game, commandContext) => Console.WriteLine(game.Player.Location.Description)),

                 new Commands("QUIT", new string[] { "QUIT", "Q"},
                (game, commandContext) => game.IsRunning = false),

                 new Commands("NORTH", new string[] { "NORTH", "N"}, MovementCommands.North),
                 new Commands("WEST", new string[] { "WEST", "W"}, MovementCommands.West),
                 new Commands("SOUTH", new string[] { "SOUTH", "S"}, MovementCommands.South),
                 new Commands("EAST", new string[] { "EAST", "E"}, MovementCommands.East),
            };
            CommandsManager = new CommandsManager(commands);
        }
        public void Run()
        {
            IsRunning = true;
            Room previousRoom = null;
            while (IsRunning)
            {
                Console.WriteLine(Player.Location);
               if(previousRoom != Player.Location)
                {
                    CommandsManager.PerformCommand(this, "LOOK");
                    previousRoom = Player.Location;
                }

                Console.Write("\n>");
                if (CommandsManager.PerformCommand(this, Console.ReadLine().Trim()))
                {
                    Player.Moves++;
                }
                else
                {
                    Console.WriteLine("That's not a verb I recognize.");
                }

            }
        }

        public static Game Load(string filename)
        {
            Game game = JsonConvert.DeserializeObject<Game>(File.ReadAllText(filename));
            game.Player = game.World.SpawnPlayer();

            return game;
        }
        
    }

}
