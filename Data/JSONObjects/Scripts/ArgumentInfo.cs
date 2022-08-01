﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonBDSPEditor.Data.JSONObjects
{
    class ArgumentInfo
    {
        [JsonProperty("TentativeName")]
        public string Name { get; set; }
        [JsonProperty("Type")]
        public string Type { get; set; }
    }
}
