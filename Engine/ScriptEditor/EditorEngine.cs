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
using System.Threading.Tasks;

namespace PokemonBDSPEditor.Engine.ScriptEditor
{
    class ScriptEditorEngine
    {
        private BundleManipulator bundleManipulator;
        private List<ScriptFile> scriptFiles;

        public ScriptEditorEngine()
        {
            bundleManipulator = new BundleManipulator();
            scriptFiles = new List<ScriptFile>();
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
                        args.Add(new Argument((ArgumentType)arg["argType"].GetValue().AsInt(), arg["data"].GetValue().AsInt()));
                    }
                    commands.Add(new Command(args));
                }
                scripts.Add(new Script(script["Label"].GetValue().AsString(), commands));
            }

            return new ScriptFile(strings, scripts, root["m_Name"].GetValue().AsString());
        }
    }
}
