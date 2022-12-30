using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonBDSPEditor.Data.JSONObjects
{
    class CommandInfo
    {
        [JsonProperty("Id")]
        public int Id { get; set; }
        [JsonProperty("Name")]
        public string Name { get; set; }
        [JsonProperty("Description")]
        public string Description { get; set; }
        [JsonProperty("Dummy")]
        public bool Dummy { get; set; }
        [JsonProperty("Args")]
        public IList<ArgumentInfo> Arguments { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
