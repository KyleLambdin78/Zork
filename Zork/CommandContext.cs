using System;
using System.Collections.Generic;
using System.Text;

namespace Zork
{
    public struct CommandContext
    {
        public string CommandString { get; }
        public Commands Command { get; }
        public CommandContext(string commandString, Commands command)
        {
            CommandString = commandString;
            Command = command;
        }
    }
}
