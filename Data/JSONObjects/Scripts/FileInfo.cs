using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrilliantShiningScriptEditor.Data.JSONObjects
{
    class FileInfo : IEquatable<FileInfo>
    {
        [JsonProperty("PathID")]
        public long PathID { get; set; } = 0;
        [JsonProperty("FileName")]
        public string FileName { get; set; } = "";
        [JsonProperty("FriendlyName")]
        public string FriendlyName { get; set; } = "";
        [JsonProperty("Description")]
        public string Description { get; set; } = "";

        public override string ToString()
        {
            return FriendlyName;
        }

        public bool Equals(FileInfo other)
        {
            if (other is null)
                return false;

            return PathID == other.PathID;
        }

        public override bool Equals(object obj) => Equals(obj as FileInfo);
        public override int GetHashCode() => (PathID).GetHashCode();
    }
}
