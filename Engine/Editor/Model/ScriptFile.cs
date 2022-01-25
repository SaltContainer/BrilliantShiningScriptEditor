using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonBDSPEditor.Engine.Editor.Model
{
    class ScriptFile
    {
        private List<string> strings;
        private List<Script> scripts;
        private string fileName;

        public ScriptFile(List<string> strings, List<Script> scripts, string fileName)
        {
            this.strings = strings;
            this.scripts = scripts;
            this.fileName = fileName;
        }
    }
}
