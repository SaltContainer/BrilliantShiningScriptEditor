using BrilliantShiningScriptEditor.Engine.ScriptEditor.Settings;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrilliantShiningScriptEditor.UI.Forms
{
    public partial class FormSettings : Form
    {
        public FormSettings()
        {
            InitializeComponent();

            UpdateUIFromSettings();
        }

        private void UpdateUIFromSettings()
        {
            switch ((ArgumentSyntax)Properties.Settings.Default.ArgumentSyntax)
            {
                case ArgumentSyntax.Assembly:
                    radioArgSyntaxAssembly.Checked = true;
                    break;
                case ArgumentSyntax.Function:
                    radioArgSyntaxFunction.Checked = true;
                    break;
            }

            switch ((TypeSyntax)Properties.Settings.Default.TypeSyntax)
            {
                case TypeSyntax.Typed:
                    radioTypeSyntaxTyped.Checked = true;
                    break;
                case TypeSyntax.Symbol:
                    radioTypeSyntaxSymbol.Checked = true;
                    break;
            }

            switch ((CommentSyntax)Properties.Settings.Default.CommentSyntax)
            {
                case CommentSyntax.SemiColon:
                    radioCommentSyntaxSemiColon.Checked = true;
                    break;
                case CommentSyntax.TriangularBrackets:
                    radioCommentSyntaxTriBrackets.Checked = true;
                    break;
                case CommentSyntax.DoubleSlash:
                    radioCommentSyntaxDoubleSlash.Checked = true;
                    break;
            }
        }

        private void UpdateSettingsFromUI()
        {
            if (radioArgSyntaxAssembly.Checked) Properties.Settings.Default.ArgumentSyntax = (int)ArgumentSyntax.Assembly;
            else if (radioArgSyntaxFunction.Checked) Properties.Settings.Default.ArgumentSyntax = (int)ArgumentSyntax.Function;

            if (radioTypeSyntaxTyped.Checked) Properties.Settings.Default.TypeSyntax = (int)TypeSyntax.Typed;
            else if (radioTypeSyntaxSymbol.Checked) Properties.Settings.Default.TypeSyntax = (int)TypeSyntax.Symbol;

            if (radioCommentSyntaxSemiColon.Checked) Properties.Settings.Default.CommentSyntax = (int)CommentSyntax.SemiColon;
            else if (radioCommentSyntaxTriBrackets.Checked) Properties.Settings.Default.CommentSyntax = (int)CommentSyntax.TriangularBrackets;
            else if (radioCommentSyntaxDoubleSlash.Checked) Properties.Settings.Default.CommentSyntax = (int)CommentSyntax.DoubleSlash;

            Properties.Settings.Default.Save();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            UpdateSettingsFromUI();

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
