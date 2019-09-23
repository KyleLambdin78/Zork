﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Zork
{
    class Room
    {
        public string Name { get; }

        public string Description { get; set; }

        public override string ToString() => Name;



        public Room(string name, string description = "")
        {
            Name = name;
            Description = description;
        }

    }
}
   