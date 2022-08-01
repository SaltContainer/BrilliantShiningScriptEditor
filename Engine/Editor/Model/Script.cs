using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonBDSPEditor.Engine.Editor.Model
{
    class Script
    {
        public string Name { get; set; }
        public List<Command> Commands { get; set; }

        public Script(string name, List<Command> commands)
        {
            Name = name;
            Commands = commands;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
