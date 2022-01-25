using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonBDSPEditor.Engine.Editor.DTO
{
    class ScriptDTO
    {
        [JsonProperty("Label")]
        public string Label { get; set; }
        [JsonProperty("Commands")]
        public IList<CommandDTO> Commands { get; set; }
    }
}
