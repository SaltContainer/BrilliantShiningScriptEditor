using AssetsTools.NET;
using PokemonBDSPEditor.Data;
using PokemonBDSPEditor.Data.Utils;
using PokemonBDSPEditor.Engine.Editor.DTO;
using PokemonBDSPEditor.Engine.Editor.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonBDSPEditor.Engine.Editor
{
    class EditorEngine
    {
        private BundleManipulator bundleManipulator;
        private List<ScriptFile> scriptFiles;
        private bool scriptFilesLoaded;

        public EditorEngine()
        {
            bundleManipulator = new BundleManipulator();
            scriptFiles = new List<ScriptFile>();
            scriptFilesLoaded = false;
        }

        public List<ScriptFile> GetScriptFiles()
        {
            if (!AreScriptFilesLoaded()) LoadScriptFiles();
            return scriptFiles;
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
                scripts.Add(new Script(commands));
            }

            List<string> strings = new List<string>();
            foreach (var str in root["StrList"][0].GetChildrenList())
            {
                strings.Add(str.GetValue().AsString());
            }

            return new ScriptFile(strings, scripts, root["m_Name"].GetValue().AsString());
        }

        public bool AreScriptFilesLoaded()
        {
            return scriptFilesLoaded;
        }
    }
}
