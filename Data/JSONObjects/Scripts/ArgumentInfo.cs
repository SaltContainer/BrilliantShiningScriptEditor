﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrilliantShiningScriptEditor.Data.JSONObjects
{
    class ArgumentInfo
    {
        [JsonProperty("TentativeName")]
        public string Name { get; set; }
        [JsonProperty("Description")]
        public string Description { get; set; }
        [JsonProperty("Type")]
        public IList<string> Type { get; set; }
        [JsonProperty("Optional")]
        public bool Optional { get; set; }
    }
}
