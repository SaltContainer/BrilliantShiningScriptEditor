using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonBDSPEditor.Engine.ScriptEditor.Exceptions
{
    class ScriptValidationExceptionListException : Exception
    {
        public List<ScriptValidationException> InnerExceptions { get; set; }

        public ScriptValidationExceptionListException(string message, List<ScriptValidationException> innerExceptions)
            : base(message)
        {
            InnerExceptions = innerExceptions;
        }
    }
}
