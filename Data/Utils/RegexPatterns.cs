using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PokemonBDSPEditor.Data.Utils
{
    static class RegexPatterns
    {
        public static string ValidCommandArgument { get; } = @"^([A-Z0-9]*_[A-Z0-9]*)+$";
        public static string InvalidCommandArgument { get; } = @"^cmd_\d+$";
        public static string NumberArgument { get; } = @"^-?(\d+\.)?\d+$";
        public static string VariableArgument { get; } = @"^var_\d+$";
        public static string FlagArgument { get; } = @"^flag_\d+$";
        public static string SystemFlagArgument { get; } = @"^sys_\d+$";
        public static Regex RegexValidCommand { get; } = new Regex(ValidCommandArgument);
        public static Regex RegexInvalidCommand { get; } = new Regex(InvalidCommandArgument);
        public static Regex RegexNumber { get; } = new Regex(NumberArgument);
        public static Regex RegexVariable { get; } = new Regex(VariableArgument);
        public static Regex RegexFlag { get; } = new Regex(FlagArgument);
        public static Regex RegexSystemFlag { get; } = new Regex(SystemFlagArgument);
    }
}
