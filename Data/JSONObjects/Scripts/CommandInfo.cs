using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrilliantShiningScriptEditor.Data.JSONObjects
{
    class CommandInfo : IEquatable<CommandInfo>
    {
        [JsonProperty("Id")]
        public int Id { get; set; } = 0;
        [JsonProperty("Name")]
        public string Name { get; set; } = "";
        [JsonProperty("Description")]
        public string Description { get; set; } = "";
        [JsonProperty("Dummy")]
        public bool Dummy { get; set; } = false;
        [JsonProperty("Animation")]
        public bool Animation { get; set; } = false;
        [JsonProperty("Args")]
        public IList<ArgumentInfo> Arguments { get; set; } = new List<ArgumentInfo>();

        public override string ToString()
        {
            return Name;
        }

        public bool Equals(CommandInfo other)
        {
            if (other is null)
                return false;

            return Id == other.Id;
        }

        public override bool Equals(object obj) => Equals(obj as CommandInfo);
        public override int GetHashCode() => (Id).GetHashCode();
    }
}
