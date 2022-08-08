using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonBDSPEditor.Engine.ScriptEditor.Exceptions
{
    class ScriptValidationException : Exception
    {
        public bool Ignorable { get; }

        public ScriptValidationException()
        {
        }

        public ScriptValidationException(string message, bool ignorable)
            : base(message)
        {
            Ignorable = ignorable;
        }

        public ScriptValidationException(string message, bool ignorable, Exception inner)
            : base(message, inner)
        {
            Ignorable = ignorable;
        }
    }
}
