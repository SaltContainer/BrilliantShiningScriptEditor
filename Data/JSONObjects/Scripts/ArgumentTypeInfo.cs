using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrilliantShiningScriptEditor.Data.JSONObjects
{
    class ArgumentTypeInfo : IEquatable<ArgumentTypeInfo>
    {
        [JsonProperty("Id")]
        public int Id { get; set; } = 0;
        [JsonProperty("Name")]
        public string Name { get; set; } = "";
        [JsonProperty("Description")]
        public string Description { get; set; } = "";

        public override string ToString()
        {
            return Name;
        }

        public bool Equals(ArgumentTypeInfo other)
        {
            if (other is null)
                return false;

            return Id == other.Id;
        }

        public override bool Equals(object obj) => Equals(obj as ArgumentTypeInfo);
        public override int GetHashCode() => (Id).GetHashCode();
    }
}
