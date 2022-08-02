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

        public string DecompileScript(Script script)
        {
            List<string> convertedCommands = new List<string>();
            foreach (Command command in script.Commands)
            {
                List<string> convertedArgs = new List<string>();
                foreach (Argument arg in command.Arguments)
                {
                    switch (arg.Type)
                    {
                        case ArgumentType.Command:
                            convertedArgs.Add(FileConstants.Commands.Where(c => c.Id == arg.GetNumberValue())
                                .Select(c => c.Name)
                                .DefaultIfEmpty(string.Format("cmd_{0}", arg.GetNumberValue()))
                                .First());
                            break;
                        case ArgumentType.Number:
                            convertedArgs.Add(BitConverter.ToSingle(BitConverter.GetBytes(arg.GetNumberValue()), 0).ToString());
                            break;
                        case ArgumentType.Variable:
                            convertedArgs.Add(string.Format("var_{0}", arg.GetNumberValue()));
                            break;
                        case ArgumentType.Flag:
                            convertedArgs.Add(string.Format("flag_{0}", arg.GetNumberValue()));
                            break;
                        case ArgumentType.SystemFlag:
                            convertedArgs.Add(string.Format("sys_{0}", arg.GetNumberValue()));
                            break;
                        case ArgumentType.String:
                            convertedArgs.Add(arg.GetStringValue());
                            break;
                    }
                }
                convertedCommands.Add(string.Join(" ", convertedArgs));
            }
            return string.Join("\n", convertedCommands);
        }

        public Script CompileScript(string script, string name)
        {
            List<Command> convertedCommands = new List<Command>();
            string[] commands = script.Split('\n');
            foreach (string command in commands)
            {
                List<Argument> convertedArguments = new List<Argument>();
                string[] args = command.Split(' ');
                for (int i=0; i<args.Length; i++)
                {
                    string arg = args[i];
                    if (i == 0)
                    {
                        if (RegexPatterns.RegexValidCommand.IsMatch(arg))
                        {
                            convertedArguments.Add(new Argument(ArgumentType.Command, FileConstants.Commands.Where(c => c.Name == arg)
                                    .Select(c => c.Id)
                                    .First()));
                        }
                        else if (RegexPatterns.RegexInvalidCommand.IsMatch(arg)) convertedArguments.Add(new Argument(ArgumentType.Command, int.Parse(arg.Split('_')[1])));
                    }
                    else if (RegexPatterns.RegexNumber.IsMatch(arg))
                    {
                        byte[] bytes = BitConverter.GetBytes(float.Parse(arg));
                        convertedArguments.Add(new Argument(ArgumentType.Number, BitConverter.ToInt32(bytes, 0)));
                    }
                    else if (RegexPatterns.RegexVariable.IsMatch(arg)) convertedArguments.Add(new Argument(ArgumentType.Variable, int.Parse(arg.Split('_')[1])));
                    else if (RegexPatterns.RegexFlag.IsMatch(arg)) convertedArguments.Add(new Argument(ArgumentType.Flag, int.Parse(arg.Split('_')[1])));
                    else if (RegexPatterns.RegexSystemFlag.IsMatch(arg)) convertedArguments.Add(new Argument(ArgumentType.SystemFlag, int.Parse(arg.Split('_')[1])));
                    else convertedArguments.Add(new Argument(ArgumentType.String, arg));
                }
                convertedCommands.Add(new Command(convertedArguments));
            }
            return new Script(name, convertedCommands);
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
