using Newtonsoft.Json;
using BrilliantShiningScriptEditor.Data.JSONObjects;
using BrilliantShiningScriptEditor.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrilliantShiningScriptEditor.Data.Utils
{
    static class FileConstants
    {
        public static Dictionary<string, BundleInfo> Bundles { get; } = JsonConvert.DeserializeObject<Dictionary<string, BundleInfo>>(Resources.bundle_constants);
        public static List<CommandInfo> Commands { get; } = JsonConvert.DeserializeObject<List<CommandInfo>>(Resources.commands);
        public static List<ArgumentTypeInfo> Flags { get; } = JsonConvert.DeserializeObject<List<ArgumentTypeInfo>>(Resources.flags);
        public static List<ArgumentTypeInfo> SystemFlags { get; } = JsonConvert.DeserializeObject<List<ArgumentTypeInfo>>(Resources.sys_flags);
        public static List<ArgumentTypeInfo> WorkVariables { get; } = JsonConvert.DeserializeObject<List<ArgumentTypeInfo>>(Resources.work);
        public static List<FileInfo> ScriptFileNames { get; } = JsonConvert.DeserializeObject<List<FileInfo>>(Resources.file_names);
        public static string ScriptDataBundleKey { get; } = "script-data";
    }
}
