using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonBDSPEditor.Engine.ScriptEditor.Model
{
    class Command
    {
        public List<Argument> Arguments { get; set; }

        public Command(List<Argument> arguments)
        {
            Arguments = arguments;
        }
    }
}
