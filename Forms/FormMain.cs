using PokemonBDSPEditor.Data.JSONObjects;
using PokemonBDSPEditor.Data.Utils;
using PokemonBDSPEditor.Engine.ScriptEditor;
using PokemonBDSPEditor.Engine.ScriptEditor.Exceptions;
using PokemonBDSPEditor.Engine.ScriptEditor.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PokemonBDSPEditor.Forms
{
    public partial class FormMain : Form
    {
        private ScriptEditorEngine scriptEditorEngine;
        private List<ScriptFile> scriptFiles;

        public FormMain()
        {
            InitializeComponent();
            scriptEditorEngine = new ScriptEditorEngine();
            scriptEditorEngine.SetBasePath("romfs");

            comboScriptCommand.DataSource = FileConstants.Commands;
        }

        private void UpdateScriptFileList(List<ScriptFile> scriptFiles)
        {
            comboScriptFile.DataSource = scriptFiles;
            comboScriptFile.SelectedIndex = 0;
        }

        private void UpdateScriptList(List<Script> scripts)
        {
            comboScript.DataSource = scripts;
            comboScript.SelectedIndex = 0;
        }

        private void UpdateScriptBox(Script script)
        {
            rtbScript.Text = scriptEditorEngine.DecompileScript(script);
        }

        private void UpdateCommandInfo(CommandInfo command)
        {
            lbScriptCommandName.Text = string.Format("{0} - {1}", command.Id, command.Name);
            string arguments = string.Join("\n", command.Arguments.Select(a => string.Format("[{0}] {1} - {2}{3}", string.Join(", ", a.Type), a.Name, a.Optional ? "(Optional) " : "", a.Description)));
            lbScriptCommandDescription.Text = string.Format("{0}\n\nArguments:\n{1}", command.Description, arguments);
        }

        private void comboScriptFile_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateScriptList(scriptEditorEngine.GetScriptFiles()[comboScriptFile.SelectedIndex].Scripts);
        }

        private void comboScript_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateScriptBox((Script)comboScript.SelectedItem);
        }

        private void btnScriptAdd_Click(object sender, EventArgs e)
        {
            // Add Script
        }

        private void btnScriptRemove_Click(object sender, EventArgs e)
        {
            // Remove Script
        }

        private void btnScriptCompile_Click(object sender, EventArgs e)
        {
            // Compile Script

            try
            {
                Script script = scriptEditorEngine.CompileScript(rtbScript.Text, ((Script)comboScript.SelectedItem).Name);
            }
            catch (ScriptValidationException ex)
            {
                MessageBox.Show(ex.Message, "Compilation Error", MessageBoxButtons.OK, ex.Ignorable ? MessageBoxIcon.Warning : MessageBoxIcon.Error);
            }
        }

        private void btnScriptSave_Click(object sender, EventArgs e)
        {
            // Save Script

            try
            {
                Script script = scriptEditorEngine.CompileScript(rtbScript.Text, ((Script)comboScript.SelectedItem).Name);
                ScriptFile selected = (ScriptFile)comboScriptFile.SelectedItem;
                selected.Scripts[selected.Scripts.FindIndex(f => f.Name == script.Name)] = script;

                MessageBox.Show("Successfully saved the script in memory!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (ScriptValidationException ex)
            {
                MessageBox.Show(ex.Message, "Compilation Error", MessageBoxButtons.OK, ex.Ignorable ? MessageBoxIcon.Warning : MessageBoxIcon.Error);
            }
        }

        private void tbtnOpen_Click(object sender, EventArgs e)
        {
            // Open ROMFS

            List<ScriptFile> scriptFiles = scriptEditorEngine.GetScriptFiles();
            if (scriptFiles.Count > 0)
            {
                this.scriptFiles = scriptFiles;
                UpdateScriptFileList(this.scriptFiles);
            }
        }

        private void tbtnSave_Click(object sender, EventArgs e)
        {
            // Save ROMFS

            scriptEditorEngine.SetScriptFiles(scriptFiles);
            scriptEditorEngine.SaveScriptFiles();
        }

        private void lbScriptCommandName_SizeChanged(object sender, EventArgs e)
        {
            lbScriptCommandDescription.Location = new Point(lbScriptCommandDescription.Location.X, lbScriptCommandName.Size.Height + 74);
        }

        private void comboScriptCommand_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateCommandInfo((CommandInfo)comboScriptCommand.SelectedItem);
        }
    }
}
