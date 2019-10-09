using System;
using System.Collections.Generic;
using System.Linq;

namespace Zork
{
   public class Commands : IEquatable<Commands>
    {
        public string Name { get; set; }

        public string[] Verbs { get; }

        public Action<Game, CommandContext> Action { get; }

        public Commands (string name, string verb, Action<Game, CommandContext> action):
            this(name, new string[] { verb }, action)
        {
        }

        public Commands(string name, IEnumerable<string> verbs, Action<Game, CommandContext> action)
        {
            Name = name;
            Verbs = verbs.ToArray();
            Action = action;
        }

        public static bool operator ==(Commands lhs, Commands rhs)
        {
            if (ReferenceEquals(lhs, rhs))
            {
                return true;
            }
            if (lhs is null || rhs is null)
            {
                return false;
            }

            return lhs.Name == rhs.Name;
        }

        public static bool operator !=(Commands lhs, Commands rhs) => !(lhs == rhs);

        public override bool Equals(object obj) => obj is Commands ? this == (Commands)obj : false;

        public bool Equals(Commands other) => this == other;

        public override int GetHashCode() => Name.GetHashCode();

        public override string ToString() => Name;
       


    }
    
    
}
