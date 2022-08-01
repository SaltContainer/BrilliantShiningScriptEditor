using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonBDSPEditor.Engine.ScriptEditor.Model
{
    class ScriptFile
    {
        public List<string> Strings { get; set; }
        public List<Script> Scripts { get; set; }
        public string FileName { get; set; }

        public ScriptFile(List<string> strings, List<Script> scripts, string fileName)
        {
            Strings = strings;
            Scripts = scripts;
            FileName = fileName;
        }

        public override string ToString()
        {
            return FileName;
        }
    }
}
