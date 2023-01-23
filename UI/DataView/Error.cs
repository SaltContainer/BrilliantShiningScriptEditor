using BrilliantShiningScriptEditor.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrilliantShiningScriptEditor.UI.DataView
{
    class Error
    {
        public Image Image { get; set; }
        public int Line { get; set; }
        public string Message { get; set; }

        public Error(bool ignorable, int line, string message)
        {
            Image = ignorable ? Resources.warning : Resources.error;
            Line = line;
            Message = message;
        }
    }
}
