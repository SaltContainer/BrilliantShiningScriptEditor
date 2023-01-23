using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrilliantShiningScriptEditor.Engine.ScriptEditor.Exceptions
{
    public class ScriptValidationException : Exception
    {
        public bool Ignorable { get; }
        public int Line { get; }

        public ScriptValidationException()
        {
        }

        public ScriptValidationException(string message, bool ignorable, int line)
            : base(message)
        {
            Ignorable = ignorable;
            Line = line;
        }

        public ScriptValidationException(string message, bool ignorable, int line, Exception inner)
            : base(message, inner)
        {
            Ignorable = ignorable;
            Line = line;
        }
    }
}
