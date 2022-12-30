using EasyScintilla.Stylers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScintillaNET;
using System.Drawing;
using PokemonBDSPEditor.Data.Utils;

namespace PokemonBDSPEditor.Engine.ScriptEditor.Styler
{
    class BDSPScriptStyler : ScintillaStyler
    {
        public BDSPScriptStyler()
                    : base(Lexer.Cpp, lineNumbers: true, codeFolding: true, braceMatching: true, autoIndent: true)
        {
        }

        public override void ApplyStyle(Scintilla scintilla)
        {
            // Configure the CPP (C#) lexer styles
            scintilla.Styles[Style.Cpp.Default].ForeColor = Color.Silver;
            scintilla.Styles[Style.Cpp.Comment].ForeColor = Color.FromArgb(0, 128, 0); // Green
            scintilla.Styles[Style.Cpp.CommentLine].ForeColor = Color.FromArgb(0, 128, 0); // Green
            scintilla.Styles[Style.Cpp.CommentLineDoc].ForeColor = Color.FromArgb(0, 128, 0); // Green
            scintilla.Styles[Style.Cpp.Number].ForeColor = Color.DarkOliveGreen;
            scintilla.Styles[Style.Cpp.Word].ForeColor = Color.Blue;
            scintilla.Styles[Style.Cpp.Word2].ForeColor = Color.FromArgb(52, 146, 184); // Turqoise
            scintilla.Styles[Style.Cpp.String].ForeColor = Color.FromArgb(163, 21, 21); // Red
            scintilla.Styles[Style.Cpp.Character].ForeColor = Color.FromArgb(163, 21, 21); // Red
            scintilla.Styles[Style.Cpp.Verbatim].ForeColor = Color.FromArgb(163, 21, 21); // Red
            scintilla.Styles[Style.Cpp.StringEol].BackColor = Color.Pink;
            scintilla.Styles[Style.Cpp.Operator].ForeColor = Color.FromArgb(0, 0, 120); // Dark Blue
            scintilla.Styles[Style.Cpp.Preprocessor].ForeColor = Color.FromArgb(128, 128, 128); // Gray

            scintilla.SetSelectionBackColor(true, Color.FromArgb(153, 201, 239));
        }

        public override void RemoveStyle(Scintilla scintilla)
        {
            scintilla.SetSelectionBackColor(true, Color.Silver);
        }

        public override void SetKeywords(Scintilla scintilla)
        {
            scintilla.SetKeywords(0, string.Join(" ", FileConstants.Commands.Select(c => c.Name)));
            scintilla.SetKeywords(1, string.Join(" ", FileConstants.Flags.Select(f => f.Name)));
            scintilla.SetKeywords(2, string.Join(" ", FileConstants.SystemFlags.Select(s => s.Name)));
            scintilla.SetKeywords(3, string.Join(" ", FileConstants.WorkVariables.Select(w => w.Name)));
        }
    }
}
