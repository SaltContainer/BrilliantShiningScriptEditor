using PokemonBDSPEditor.Data.JSONObjects;
using PokemonBDSPEditor.Data.Utils;
using PokemonBDSPEditor.Engine.ScriptEditor.Exceptions;
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
        private List<ScriptValidationException> validationExceptions;

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

        public Script CompileScript(string script, string name, bool ignoreExceptions)
        {
            ClearExceptions();
            List<Command> convertedCommands = new List<Command>();
            string[] commands = script.Split('\n');
            for (int i=0; i<commands.Length; i++)
            {
                string command = commands[i];
                if (command != "")
                {
                    List<Argument> convertedArguments = new List<Argument>();
                    string[] args = command.Split(' ');
                    for (int j = 0; j < args.Length; j++)
                    {
                        string arg = args[j];
                        if (j == 0)
                        {
                            if (ValidateCommand(arg, i))
                            {
                                CommandInfo result = GetCommandFromName(arg);
                                if (result != null) convertedArguments.Add(new Argument(ArgumentType.Command, result.Id));
                                else if (RegexPatterns.RegexInvalidCommand.IsMatch(arg)) convertedArguments.Add(new Argument(ArgumentType.Command, int.Parse(arg.Split('_')[1])));
                            }
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
                    if (ValidateArguments(convertedArguments, i)) convertedCommands.Add(new Command(convertedArguments));
                }
            }
            if (validationExceptions.Count > 0 && !ignoreExceptions) throw new ScriptValidationExceptionListException("", validationExceptions);
            return new Script(name, convertedCommands);
        }

        private bool ValidateArguments(List<Argument> arguments, int line)
        {
            if (arguments.Count() <= 0)
            {
                return false;
            }
            if (arguments[0].Type != ArgumentType.Command)
            {
                validationExceptions.Add(new ScriptValidationException(string.Format("Line {0}: Not a command.", line + 1), false));
                return false;
            }

            CommandInfo commandInfo = GetCommandFromId(arguments[0].GetNumberValue());
            if (commandInfo == null)
            {
                validationExceptions.Add(new ScriptValidationException(string.Format("Line {0}: Unrecognized command.", line + 1), true));
            }
            else
            {
                if (arguments.Count() - 1 < commandInfo.Arguments.Where(a => !a.Optional).Count() || arguments.Count() - 1 > commandInfo.Arguments.Count())
                {
                    if (commandInfo.Arguments.Where(a => !a.Optional).Count() == commandInfo.Arguments.Count())
                    {
                        validationExceptions.Add(new ScriptValidationException(string.Format("Line {0}: Invalid argument count. Expected {1} argument(s) but got {2}.", line + 1, commandInfo.Arguments.Count(), arguments.Count() - 1), true));
                    }
                    else
                    {
                        validationExceptions.Add(new ScriptValidationException(string.Format("Line {0}: Invalid argument count. Expected {1} to {2} argument(s) but got {3}.", line + 1, commandInfo.Arguments.Where(a => !a.Optional).Count(), commandInfo.Arguments.Count(), arguments.Count() - 1), true));
                    }
                }
                else
                {
                    int j = 0;
                    int i = 1;
                    while (i <= commandInfo.Arguments.Count())
                    {
                        if (i + j - 1 >= commandInfo.Arguments.Count())
                        {
                            validationExceptions.Add(new ScriptValidationException(string.Format("Line {0}, Argument {1}: Invalid argument type. Expected [{2}], but was {3}.", line + 1, i, string.Join(", ", commandInfo.Arguments[i - 1].Type), arguments[i - 1].Type), true));
                        }

                        if (commandInfo.Arguments[i + j - 1].Optional)
                        {
                            if (arguments.Count() - 1 < i) i++;
                            else if (!commandInfo.Arguments[i + j - 1].Type.Contains(GetTypeNameFromType(arguments[i].Type))) j++;
                            else i++;
                        }
                        else
                        {
                            if (!commandInfo.Arguments[i + j - 1].Type.Contains(GetTypeNameFromType(arguments[i].Type)))
                            {
                                validationExceptions.Add(new ScriptValidationException(string.Format("Line {0}, Argument {1}: Invalid argument type. Expected [{2}], but was {3}.", line + 1, i, string.Join(", ", commandInfo.Arguments[i + j].Type), arguments[i].Type), true));
                            }
                            else i++;
                        }
                    }
                }
            }
            return true;
        }

        private bool ValidateCommand(string command, int line)
        {
            if (RegexPatterns.RegexValidCommand.IsMatch(command))
            {
                CommandInfo foundCommand = GetCommandFromName(command);
                if (foundCommand == null)
                {
                    validationExceptions.Add(new ScriptValidationException(string.Format("Line {0}: Invalid command.", line + 1), false));
                    return false;
                }
            }
            else if (!RegexPatterns.RegexInvalidCommand.IsMatch(command))
            {
                validationExceptions.Add(new ScriptValidationException(string.Format("Line {0}: Invalid command.", line + 1), false));
                return false;
            }

            return true;
        }

        private CommandInfo GetCommandFromName(string name)
        {
            return FileConstants.Commands.Where(c => c.Name == name).DefaultIfEmpty(null).First();
        }

        private CommandInfo GetCommandFromId(int id)
        {
            return FileConstants.Commands.Where(c => c.Id == id).DefaultIfEmpty(null).First();
        }

        private string GetTypeNameFromType(ArgumentType type)
        {
            string result = "";
            switch (type)
            {
                case ArgumentType.Number:
                    result = "Number";
                    break;
                case ArgumentType.Variable:
                    result = "Var";
                    break;
                case ArgumentType.Flag:
                    result = "Flag";
                    break;
                case ArgumentType.SystemFlag:
                    result = "System";
                    break;
                case ArgumentType.String:
                    result = "Label";
                    break;
            }
            return result;
        }

        private void ClearExceptions()
        {
            validationExceptions = new List<ScriptValidationException>();
        }
    }
}
