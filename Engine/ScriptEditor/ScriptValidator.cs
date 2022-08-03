using PokemonBDSPEditor.Data.Utils;
using PokemonBDSPEditor.Engine.ScriptEditor.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonBDSPEditor.Engine.ScriptEditor
{
    class ScriptValidator
    {
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
                for (int i = 0; i < args.Length; i++)
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
    }
}
