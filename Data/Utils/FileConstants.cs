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
        public static string ScriptDataBundleKey { get; } = "script-data";

        public static List<CommandInfo> Commands { get; } = JsonConvert.DeserializeObject<List<CommandInfo>>(Resources.commands);
        public static List<ArgumentTypeInfo> Flags { get; } = JsonConvert.DeserializeObject<List<ArgumentTypeInfo>>(Resources.flags);
        public static List<ArgumentTypeInfo> SystemFlags { get; } = JsonConvert.DeserializeObject<List<ArgumentTypeInfo>>(Resources.sys_flags);
        public static List<ArgumentTypeInfo> WorkVariables { get; } = JsonConvert.DeserializeObject<List<ArgumentTypeInfo>>(Resources.work);
        public static List<FileInfo> ScriptFileNames { get; } = JsonConvert.DeserializeObject<List<FileInfo>>(Resources.file_names);

        public static List<CommandInfo> CustomCommands { get; set; } = JsonConvert.DeserializeObject<List<CommandInfo>>(Resources.custom_commands);
        public static List<ArgumentTypeInfo> CustomFlags { get; set; } = JsonConvert.DeserializeObject<List<ArgumentTypeInfo>>(Resources.custom_flags);
        public static List<ArgumentTypeInfo> CustomSystemFlags { get; set; } = JsonConvert.DeserializeObject<List<ArgumentTypeInfo>>(Resources.custom_sys_flags);
        public static List<ArgumentTypeInfo> CustomWorkVariables { get; set; } = JsonConvert.DeserializeObject<List<ArgumentTypeInfo>>(Resources.custom_work);
        public static List<FileInfo> CustomScriptFileNames { get; set; } = JsonConvert.DeserializeObject<List<FileInfo>>(Resources.custom_file_names);

        public static List<CommandInfo> AllCommands { get => CustomCommands.Union(Commands).ToList(); }
        public static List<ArgumentTypeInfo> AllFlags { get => CustomFlags.Union(Flags).ToList(); }
        public static List<ArgumentTypeInfo> AllSystemFlags { get => CustomSystemFlags.Union(SystemFlags).ToList(); }
        public static List<ArgumentTypeInfo> AllWorkVariables { get => CustomWorkVariables.Union(WorkVariables).ToList(); }
        public static List<FileInfo> AllScriptFileNames { get => CustomScriptFileNames.Union(ScriptFileNames).ToList(); }
    }
}
