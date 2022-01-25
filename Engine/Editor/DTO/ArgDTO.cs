using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonBDSPEditor.Engine.Editor.DTO
{
    class ArgDTO
    {
        [JsonProperty("argType")]
        public int ArgType { get; set; }
        [JsonProperty("data")]
        public int Data { get; set; }
    }
}
