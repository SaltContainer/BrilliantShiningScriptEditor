using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonBDSPEditor.Engine.ScriptEditor.Model
{
    class Argument
    {
        public ArgumentType Type { get; set; }
        private int numberValue;
        private string stringValue;

        public Argument(ArgumentType type, int value)
        {
            Type = type;
            this.numberValue = value;
        }

        public Argument(ArgumentType type, string value)
        {
            Type = type;
            this.stringValue = value;
        }

        public object GetValue()
        {
            switch(Type)
            {
                case ArgumentType.Command:
                case ArgumentType.Number:
                case ArgumentType.Variable:
                case ArgumentType.Flag:
                case ArgumentType.SystemFlag:
                    return numberValue;
                default:
                    return stringValue;
            }
        }

        public int GetNumberValue()
        {
            return numberValue;
        }

        public string GetStringValue()
        {
            return stringValue;
        }
    }
}
