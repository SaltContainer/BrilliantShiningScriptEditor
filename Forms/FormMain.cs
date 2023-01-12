using Microsoft.WindowsAPICodePack.Dialogs;
using BrilliantShiningScriptEditor.Data.JSONObjects;
using BrilliantShiningScriptEditor.Data.Utils;
using BrilliantShiningScriptEditor.Engine.ScriptEditor;
using BrilliantShiningScriptEditor.Engine.ScriptEditor.Exceptions;
using BrilliantShiningScriptEditor.Engine.ScriptEditor.Model;
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
using System.IO;
using System.Windows.Threading;
using Microsoft.Web.WebView2.Core;

namespace BrilliantShiningScriptEditor.Forms
{
    public partial class FormMain : Form
    {
        private ScriptEditorEngine scriptEditorEngine;
        private List<ScriptFile> scriptFiles;

        public FormMain()
        {
            InitializeComponent();
            AddToolTips();

            scriptEditorEngine = new ScriptEditorEngine();

            comboScriptCommand.DataSource = FileConstants.Commands;
        }

        #region Web View Stuff
        private void FormMain_Load(object sender, EventArgs e)
        {
            LoadPage();
        }

        private void webEditor_NavigationCompleted(object sender, Microsoft.Web.WebView2.Core.CoreWebView2NavigationCompletedEventArgs e)
        {
            stripMain.Enabled = true;
        }

        private async void LoadPage()
        {
            var options = new CoreWebView2EnvironmentOptions("--allow-file-access-from-files");
            var environment = await CoreWebView2Environment.CreateAsync(null, null, options);
            await webEditor.EnsureCoreWebView2Async(environment);
            webEditor.Source = new Uri(Path.Combine(Application.StartupPath, @"Monaco\index.html"));
        }

        private void SetEditorValue(string code)
        {
            code = code.Replace("\n", "\\n");
            ExecuteEditorScript($"editor.setValue('{code}')");
        }

        private string GetEditorValue()
        {
            string code = ExecuteEditorScript("editor.getValue()");
            code = code.Replace("\"", "");
            code = code.Replace("\\n", "\n");
            return code;
        }

        private string ExecuteEditorScript(string script)
        {
            return EditorWait(webEditor.CoreWebView2.ExecuteScriptAsync(script));
        }

        // NEVER call within a WebView handler, this will deadlock
        private static string EditorWait(Task<string> task)
        {
            System.Timers.Timer timer = new System.Timers.Timer();
            DispatcherFrame frame = new DispatcherFrame();

            string wait = "Empty";

            task.ContinueWith(
                _ =>
                {
                    if (task.IsFaulted) wait = task.Exception.Message;
                    else wait = task.Result;
                    frame.Continue = false;
                });

            // Timeout if task takes too long
            timer.Enabled = true;
            frame.Continue = true;
            Dispatcher.PushFrame(frame);
            timer.Enabled = false;

            return wait;
        }
        #endregion

        private void AddToolTips()
        {
            ttFormMain.SetToolTip(btnScriptAdd, "Add a Script to this file");
            ttFormMain.SetToolTip(btnScriptRemove, "Remove this Script from this file");
            ttFormMain.SetToolTip(btnScriptCompile, "Compile this Script (Check for errors)");
            ttFormMain.SetToolTip(btnScriptSave, "Save this Script to memory");
            ttFormMain.SetToolTip(checkScriptSafe, "Disallow saving for Scripts with errors");
        }
        
        private void UpdateScriptFileList(List<ScriptFile> scriptFiles)
        {
            comboScriptFile.DataSource = scriptFiles.OrderBy(s => s.ToString()).ToList();
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
            SetEditorValue(scriptEditorEngine.DecompileScript(script));
        }

        private void UpdateCommandInfo(CommandInfo command)
        {
            lbScriptCommandName.Text = string.Format("{0} - {1}", command.Id, command.Name);
            string arguments = "";
            if (command.Arguments.Count == 0) arguments = "No arguments.";
            else arguments = string.Join("\n", command.Arguments.Select(a => string.Format("[{0}] {1} - {2}{3}", string.Join(", ", a.Type), a.Name, a.Optional ? "(Optional) " : "", a.Description)));
            List<string> descriptionItems = new List<string>();
            if (command.Animation) descriptionItems.Add("[Animation command]");
            if (command.Dummy) descriptionItems.Add("This command is dummied out and does nothing.");
            else descriptionItems.Add(command.Description == "" ? "This command is not documented yet." : command.Description);
            lbScriptCommandDescription.Text = string.Format("{0}\n\nArguments:\n{1}", string.Join(" ", descriptionItems), arguments);
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
                string code = GetEditorValue();
                Script script = scriptEditorEngine.CompileScript(code, ((Script)comboScript.SelectedItem).Name, false);
                MessageBox.Show("No compilation errors found.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                string code = GetEditorValue();
                Script script = scriptEditorEngine.CompileScript(code, ((Script)comboScript.SelectedItem).Name, false);
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
                        string code = GetEditorValue();
                        Script script = scriptEditorEngine.CompileScript(code, ((Script)comboScript.SelectedItem).Name, true);
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
                        ExecuteEditorScript("editor.updateOptions({readOnly: false})");
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
