using AssetsTools.NET;
using Newtonsoft.Json;
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

        public void SetBasePath(string path)
        {
            bundleManipulator.SetBasePath(path);
        }

        public List<ScriptFile> GetScriptFiles()
        {
            if (!AreScriptFilesLoaded()) LoadScriptFiles();
            return scriptFiles;
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

        public Script CompileScript(string script, string name)
        {
            return scriptValidator.CompileScript(script, name);
        }

        private void LoadScriptFiles()
        {
            bundleManipulator.LoadBundles(new List<string>() { FileConstants.ScriptDataBundleKey });
            var files = bundleManipulator.GetFilesOfBundle(FileConstants.ScriptDataBundleKey);
            foreach (var file in files)
            {
                if (file["Scripts"] != null && file["Scripts"].GetChildrenCount() > 0)
                {
                    scriptFiles.Add(ConvertToScriptFile(file));
                }
            }
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
    }
}
