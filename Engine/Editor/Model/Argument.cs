using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonBDSPEditor.Engine.Editor.Model
{
    class Argument
    {
        private ArgumentType type;
        private uint numberValue;
        private string stringValue;

        public Argument(ArgumentType type, uint value)
        {
            this.type = type;
            this.numberValue = value;
        }

        public Argument(ArgumentType type, string value)
        {
            this.type = type;
            this.stringValue = value;
        }

        public object GetValue()
        {
            switch(type)
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

        public uint GetNumberValue()
        {
            return numberValue;
        }

        public string GetStringValue()
        {
            return stringValue;
        }
    }
}
