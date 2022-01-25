using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonBDSPEditor.Engine.Editor.Model
{
    class Script
    {
        private List<Command> commands;

        public Script(List<Command> commands)
        {
            this.commands = commands;
        }
    }
}
