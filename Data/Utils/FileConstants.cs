using Newtonsoft.Json;
using PokemonBDSPEditor.Data.JSONObjects;
using PokemonBDSPEditor.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonBDSPEditor.Data.Utils
{
    static class FileConstants
    {
        public static Dictionary<string, BundleInfo> Bundles { get; } = JsonConvert.DeserializeObject<Dictionary<string, BundleInfo>>(Resources.bundle_constants);
        public static List<CommandInfo> Commands { get; } = JsonConvert.DeserializeObject<List<CommandInfo>>(Resources.commands);
        public static string ScriptDataBundleKey { get; } = "script-data";
    }
}
