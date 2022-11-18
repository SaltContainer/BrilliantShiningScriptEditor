using AssetsTools.NET;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PokemonBDSPEditor.Data;
using PokemonBDSPEditor.Data.JSONObjects;
using PokemonBDSPEditor.Data.Utils;
using PokemonBDSPEditor.Engine.ScriptEditor.Model;
using PokemonBDSPEditor.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PokemonBDSPEditor.Engine.ScriptEditor
{
    class ScriptEditorEngine
    {
        private BundleManipulator bundleManipulator;
        private ScriptValidator scriptValidator;
        private List<ScriptFile> scriptFiles;

        public ScriptEditorEngine()
        {
            bundleManipulator = new BundleManipulator();
            scriptValidator = new ScriptValidator();
            scriptFiles = new List<ScriptFile>();
        }

        public bool SetBasePath(string path)
        {
            return bundleManipulator.SetBasePath(path);
        }

        public List<ScriptFile> GetScriptFiles()
        {
            if (!AreScriptFilesLoaded()) LoadScriptFiles();
            return scriptFiles;
        }

        public void SetScriptFiles(List<ScriptFile> scriptFiles)
        {
            bundleManipulator.SetFilesToBundle(FileConstants.ScriptDataBundleKey, ConvertFromScriptFiles(scriptFiles));
        }

        public bool SaveScriptFiles(string path)
        {
            return bundleManipulator.SaveBundles(new List<string>() { FileConstants.ScriptDataBundleKey }, path);
        }

        public bool SaveScriptFilesInBasePath()
        {
            return bundleManipulator.SaveBundlesInBasePath(new List<string>() { FileConstants.ScriptDataBundleKey });
        }

        public bool AreScriptFilesLoaded()
        {
            return bundleManipulator.IsBundleLoaded(FileConstants.ScriptDataBundleKey);
        }

        public List<CommandInfo> GetCommands()
        {
            return FileConstants.Commands;
        }

        public string DecompileScript(Script script)
        {
            return scriptValidator.DecompileScript(script);
        }

        public Script CompileScript(string script, string name, bool ignoreExceptions)
        {
            return scriptValidator.CompileScript(script, name, ignoreExceptions);
        }

        private bool LoadScriptFiles()
        {
            bool result = bundleManipulator.LoadBundles(new List<string>() { FileConstants.ScriptDataBundleKey });
            if (result)
            {
                var files = bundleManipulator.GetFilesOfBundle(FileConstants.ScriptDataBundleKey);
                foreach (var file in files)
                {
                    if (file["Scripts"] != null && file["Scripts"].GetChildrenCount() > 0)
                    {
                        scriptFiles.Add(ConvertToScriptFile(file));
                    }
                }
                scriptFiles = scriptFiles.OrderBy(s => s.FileName).ToList();
            }
            return result;
        }

        private ScriptFile ConvertToScriptFile(AssetTypeValueField root)
        {
            List<string> strings = new List<string>();
            foreach (var str in root["StrList"][0].GetChildrenList())
            {
                strings.Add(str.GetValue().AsString());
            }

            List<Script> scripts = new List<Script>();
            foreach (var script in root["Scripts"][0].GetChildrenList())
            {
                List<Command> commands = new List<Command>();
                foreach (var command in script["Commands"][0].GetChildrenList())
                {
                    List<Argument> args = new List<Argument>();
                    foreach (var arg in command["Arg"][0].GetChildrenList())
                    {
                        ArgumentType type = (ArgumentType)arg["argType"].GetValue().AsInt();
                        if (type == ArgumentType.String) args.Add(new Argument(type, strings[arg["data"].GetValue().AsInt()]));
                        else args.Add(new Argument(type, arg["data"].GetValue().AsInt()));
                    }
                    commands.Add(new Command(args));
                }
                scripts.Add(new Script(script["Label"].GetValue().AsString(), commands));
            }

            return new ScriptFile(strings, scripts, root["m_Name"].GetValue().AsString());
        }

        private Dictionary<string, JObject> ConvertFromScriptFiles(List<ScriptFile> scriptFiles)
        {
            List<ScriptFile> convertedScriptFiles = ConvertStringsToIndex(scriptFiles);

            Dictionary<string, JObject> json = new Dictionary<string, JObject>();

            foreach (ScriptFile scriptFile in convertedScriptFiles)
            {
                json.Add(scriptFile.FileName, new JObject(
                    new JProperty("Scripts",
                        new JArray(
                            from s in scriptFile.Scripts
                            select new JObject(
                                new JProperty("Label", new JValue(s.Name)),
                                new JProperty("Commands",
                                    new JArray(
                                        from c in s.Commands
                                        select new JObject(
                                            new JProperty("Arg",
                                                new JArray(
                                                    from a in c.Arguments
                                                    select new JObject(
                                                        new JProperty("argType", a.Type),
                                                        new JProperty("data", a.GetNumberValue())
                                                    )
                                                )
                                            )
                                        )
                                    )
                                )
                            )
                        )
                    ),
                    new JProperty("StrList",
                        new JArray(
                            from s in scriptFile.Strings
                            select new JValue(s)
                        )
                    )
                ));
            }

            return json;
        }

        private List<ScriptFile> ConvertStringsToIndex(List<ScriptFile> scriptFiles)
        {
            foreach (ScriptFile scriptFile in scriptFiles)
            {
                List<string> strings = new List<string>();

                foreach (Script script in scriptFile.Scripts)
                {
                    foreach (Command command in script.Commands)
                    {
                        foreach (Argument arg in command.Arguments)
                        {
                            if (arg.Type == ArgumentType.String)
                            {
                                if (strings.Contains(arg.GetStringValue()))
                                {
                                    arg.SetNumberValue(strings.IndexOf(arg.GetStringValue()));
                                }
                                else
                                {
                                    arg.SetNumberValue(strings.Count);
                                    strings.Add(arg.GetStringValue());
                                }
                            }
                        }
                    }
                }

                scriptFile.Strings = strings;
            }

            return scriptFiles;
        }

        public string GetBasePath()
        {
            return bundleManipulator.GetBasePath();
        }
    }
}
