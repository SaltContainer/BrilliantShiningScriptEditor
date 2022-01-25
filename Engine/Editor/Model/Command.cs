using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonBDSPEditor.Engine.Editor.Model
{
    class Command
    {
        private int id;
        private List<Argument> arguments;

        public Command(int id, List<Argument> arguments)
        {
            this.id = id;
            this.arguments = arguments;
        }
    }
}
