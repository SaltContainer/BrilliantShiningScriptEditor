using Microsoft.WindowsAPICodePack.Dialogs;
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

            comboScriptCommand.DataSource = FileConstants.Commands;
        }

        private void UpdateScriptFileList(List<ScriptFile> scriptFiles)
        {
            comboScriptFile.DataSource = scriptFiles;
            comboScriptFile.SelectedIndex = 0;
        }

        private void UpdateScriptList(List<Script> scripts)
        {
            comboScript.DataSource = null;
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
            string arguments = "";
            if (command.Arguments.Count == 0) arguments = "No arguments.";
            else arguments = string.Join("\n", command.Arguments.Select(a => string.Format("[{0}] {1} - {2}{3}", string.Join(", ", a.Type), a.Name, a.Optional ? "(Optional) " : "", a.Description)));
            lbScriptCommandDescription.Text = string.Format("{0}\n\nArguments:\n{1}", command.Description == "" ? "This command is not documented yet." : command.Description, arguments);
        }

        private void SaveScriptInMemory(Script script)
        {
            ScriptFile selected = (ScriptFile)comboScriptFile.SelectedItem;
            selected.Scripts[selected.Scripts.FindIndex(f => f.Name == script.Name)] = script;

            MessageBox.Show("Successfully saved the script in memory!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            UpdateScriptList(selected.Scripts);
        }

        private void comboScriptFile_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateScriptList(((ScriptFile)comboScriptFile.SelectedItem).Scripts);
        }

        private void comboScript_SelectedIndexChanged(object sender, EventArgs e)
        {
            Script script = (Script)comboScript.SelectedItem;
            if (script != null) UpdateScriptBox(script);
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
                Script script = scriptEditorEngine.CompileScript(rtbScript.Text, ((Script)comboScript.SelectedItem).Name, false);
            }
            catch (ScriptValidationExceptionListException ex)
            {
                bool ignorable = !ex.InnerExceptions.Select(exception => exception.Ignorable).Contains(false);
                string fullError = string.Join("\n", ex.InnerExceptions.Select(exception => exception.Message));
                MessageBox.Show(fullError, "Compilation Error" + (ex.InnerExceptions.Count > 1 ? "s" : ""), MessageBoxButtons.OK, ignorable ? MessageBoxIcon.Warning : MessageBoxIcon.Error);
            }
        }

        private void btnScriptSave_Click(object sender, EventArgs e)
        {
            // Save Script

            try
            {
                Script script = scriptEditorEngine.CompileScript(rtbScript.Text, ((Script)comboScript.SelectedItem).Name, false);
                SaveScriptInMemory(script);
            }
            catch (ScriptValidationExceptionListException ex)
            {
                bool ignorable = !ex.InnerExceptions.Select(exception => exception.Ignorable).Contains(false);
                string fullError = string.Join("\n", ex.InnerExceptions.Select(exception => exception.Message));
                if (ignorable && !checkScriptSafe.Checked)
                {
                    fullError += "\nAre you sure you want to save this script anyways?";
                    if (MessageBox.Show(fullError, "Compilation Error" + (ex.InnerExceptions.Count > 1 ? "s" : ""), MessageBoxButtons.YesNo, ignorable ? MessageBoxIcon.Warning : MessageBoxIcon.Error) == DialogResult.Yes)
                    {
                        Script script = scriptEditorEngine.CompileScript(rtbScript.Text, ((Script)comboScript.SelectedItem).Name, true);
                        SaveScriptInMemory(script);
                    }
                }
                else MessageBox.Show(fullError, "Compilation Error" + (ex.InnerExceptions.Count > 1 ? "s" : ""), MessageBoxButtons.OK, ignorable ? MessageBoxIcon.Warning : MessageBoxIcon.Error);
            }
        }

        private void tbtnOpen_Click(object sender, EventArgs e)
        {
            // Open ROMFS

            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            dialog.IsFolderPicker = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                if (scriptEditorEngine.SetBasePath(dialog.FileName))
                {
                    List<ScriptFile> scriptFiles = scriptEditorEngine.GetScriptFiles();
                    if (scriptFiles.Count > 0)
                    {
                        this.scriptFiles = scriptFiles;
                        UpdateScriptFileList(this.scriptFiles);

                        tbtnSave.Enabled = true;
                        tbtnOpen.Enabled = false;
                        btnScriptCompile.Enabled = true;
                        btnScriptSave.Enabled = true;
                    }
                }
                else
                {
                    MessageBox.Show(string.Format("\"{0}\" does not contain the \"{1}\" folder, or it could not be read.", dialog.FileName, "Data"), "Invalid folder", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void tbtnSave_Click(object sender, EventArgs e)
        {
            // Save ROMFS

            if (MessageBox.Show(string.Format("This will overwrite the affected file(s) in \"{0}\". Are you sure you want to export?", scriptEditorEngine.GetBasePath()), "Export Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                scriptEditorEngine.SetScriptFiles(scriptFiles);
                if (scriptEditorEngine.SaveScriptFilesInBasePath())
                {
                    MessageBox.Show(string.Format("Successfully exported all files to \"{0}\"!", scriptEditorEngine.GetBasePath()), "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
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
