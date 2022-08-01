using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonBDSPEditor.Data.JSONObjects
{
    class BundleInfo
    {
        [JsonProperty("key")]
        public string Key { get; set; }
        [JsonProperty("file_name")]
        public string FileName { get; set; }
        [JsonProperty("full_path")]
        public string FullPath { get; set; }
        [JsonProperty("cab_directory")]
        public string CabDirectory { get; set; }
        [JsonProperty("files")]
        public IList<string> Files { get; set; }
    }
}
