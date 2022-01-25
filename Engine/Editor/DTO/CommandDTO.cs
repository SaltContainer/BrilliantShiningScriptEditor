using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonBDSPEditor.Engine.Editor.DTO
{
    class CommandDTO
    {
        [JsonProperty("Arg")]
        public IList<ArgDTO> Args { get; set; }
    }
}
