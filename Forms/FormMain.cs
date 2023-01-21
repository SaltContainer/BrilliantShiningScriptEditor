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
        private FormReference formReference;

        private ScriptEditorEngine scriptEditorEngine;
        private List<ScriptFile> scriptFiles;

        private bool editorLoaded = false;

        public FormMain()
        {
            InitializeComponent();
            AddToolTips();

            scriptEditorEngine = new ScriptEditorEngine();
        }

        #region Web View Stuff
        private void FormMain_Load(object sender, EventArgs e)
        {
            LoadPage();
        }

        private void webEditor_NavigationCompleted(object sender, CoreWebView2NavigationCompletedEventArgs e)
        {
            stripMain.Enabled = true;
            editorLoaded = true;
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
            code = code.Replace("\\r", "");
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

        private void FormMain_SizeChanged(object sender, EventArgs e)
        {
            if (editorLoaded) ExecuteEditorScript("editor.layout()");
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
            ExecuteEditorScript("editor.updateOptions({readOnly: false})");
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

            FormTextBox newScriptForm = new FormTextBox("Add Script", "Enter the name for the script:", "Confirm", "Cancel");

            if (newScriptForm.ShowDialog() == DialogResult.OK)
            {
                string result = newScriptForm.Result;
                List<Script> list = ((ScriptFile)comboScriptFile.SelectedItem).Scripts;
                if (string.IsNullOrWhiteSpace(result))
                {
                    MessageBox.Show("The given Script name is empty.", "Invalid Script Name", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (list.Select(s => s.Name).Contains(result))
                {
                    MessageBox.Show("The given Script name already exists in this file.", "Invalid Script Name", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    int endId = FileConstants.Commands.Where(c => c.Name == "_END").Select(c => c.Id).DefaultIfEmpty(0).First();
                    Argument endArgument = new Argument(ArgumentType.Command, endId);
                    Script script = new Script(result, new List<Command>() { new Command(new List<Argument>() { endArgument }) });
                    list.Add(script);
                    MessageBox.Show("Added the new script in memory successfully! Don't forget to export all your changes.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    comboScriptFile_SelectedIndexChanged(this, new EventArgs());
                }
            }
        }

        private void btnScriptRemove_Click(object sender, EventArgs e)
        {
            // Remove Script

            if (MessageBox.Show("Are you sure you want to delete this script from memory? The script will be completely gone when you export your changes.", "Script Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                List<Script> list = ((ScriptFile)comboScriptFile.SelectedItem).Scripts;
                Script script = (Script)comboScript.SelectedItem;
                list.Remove(script);
                MessageBox.Show("Removed the new script from memory successfully! Don't forget to export all your changes.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                comboScriptFile_SelectedIndexChanged(this, new EventArgs());
            }
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
                        btnScriptAdd.Enabled = true;
                        btnScriptRemove.Enabled = true;
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

        private void tbtnReference_Click(object sender, EventArgs e)
        {
            if (formReference == null)
            {
                formReference = new FormReference();
            }
            if (!formReference.Visible)
            {
                formReference.Show(this);
            }
        }
    }
}
