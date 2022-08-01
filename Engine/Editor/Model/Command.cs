using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonBDSPEditor.Engine.Editor.Model
{
    class Command
    {
        private List<Argument> arguments;

        public Command(List<Argument> arguments)
        {
            this.arguments = arguments;
        }
    }
}
