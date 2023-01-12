using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrilliantShiningScriptEditor.Data.JSONObjects
{
    class FileInfo
    {
        [JsonProperty("PathID")]
        public long PathID { get; set; }
        [JsonProperty("FileName")]
        public string FileName { get; set; }
        [JsonProperty("FriendlyName")]
        public string FriendlyName { get; set; }
    }
}
