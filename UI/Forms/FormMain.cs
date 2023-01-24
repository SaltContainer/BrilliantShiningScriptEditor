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
using BrilliantShiningScriptEditor.UI.DataView;

namespace BrilliantShiningScriptEditor.UI.Forms
{
    public partial class FormMain : Form
    {
        private FormReference formReference;

        private ScriptEditorEngine scriptEditorEngine;
        private List<ScriptFile> scriptFiles;
        private ScriptFile parentOfLoadedScript;
        private Script loadedScript;

        private bool editorLoaded = false;
        private bool collapsedErrorList = false;
        private bool fullFileMode = false;

        private bool treeViewDoubleClick = false;

        public FormMain()
        {
            InitializeComponent();

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

        public string ExecuteEditorScript(string script)
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

        private void ResizeEditor()
        {
            if (editorLoaded) ExecuteEditorScript("editor.layout()");
        }
        #endregion

        private void FormMain_SizeChanged(object sender, EventArgs e)
        {
            ResizeEditor();
        }

        private void EnableControlsOnOpen()
        {
            tbtnSave.Enabled = true;
            tbtnOpen.Enabled = false;
            treeFiles.Enabled = true;
        }
        
        private void UpdateScriptFileList()
        {
            treeFiles.Nodes.Clear();

            List<ScriptFile> sortedFiles = scriptFiles.OrderBy(s => s.ToString()).ToList();
            foreach (ScriptFile file in sortedFiles)
            {
                List<TreeNode> children = new List<TreeNode>();
                foreach (Script script in file.Scripts)
                {
                    TreeNode node = new TreeNode(script.Name);
                    node.Tag = script;
                    node.ImageIndex = 0;
                    node.SelectedImageIndex = 0;
                    node.ContextMenuStrip = cntxtScript;
                    children.Add(node);
                }
                TreeNode fileNode = new TreeNode(file.ToString(), children.ToArray());
                fileNode.Tag = file;
                fileNode.ImageIndex = 1;
                fileNode.SelectedImageIndex = 1;
                fileNode.ContextMenuStrip = cntxtScriptFile;
                treeFiles.Nodes.Add(fileNode);
            }
        }

        private void UpdateScriptBox()
        {
            if (fullFileMode) SetEditorValue(scriptEditorEngine.DecompileScriptFile(parentOfLoadedScript));
            else SetEditorValue(scriptEditorEngine.DecompileScript(loadedScript));
            ExecuteEditorScript("editor.updateOptions({readOnly: false})");
        }

        private void UpdateScriptInfo()
        {
            List<string> lines = new List<string>();

            if (fullFileMode)
            {
                lines.Add("Loaded Script File:");
                if (parentOfLoadedScript == null)
                {
                    lines.Add("None");
                }
                else
                {
                    lines.Add(parentOfLoadedScript.ToString());
                    lines.Add("(" + parentOfLoadedScript.FileName + ")");
                    lines.Add("");
                    int cmdCount = parentOfLoadedScript.Scripts.SelectMany(s => s.Commands).Count();
                    int scriptCount = parentOfLoadedScript.Scripts.Count;
                    lines.Add(string.Format("This script file contains {0} command" + (cmdCount > 1 ? "s" : "") + " in {1} script" + (scriptCount > 1 ? "s" : "") + ".", cmdCount, scriptCount));
                }
            }
            else
            {
                lines.Add("Loaded Script:");
                if (loadedScript == null || parentOfLoadedScript == null)
                {
                    lines.Add("None");
                }
                else
                {
                    lines.Add(loadedScript.Name + " in " + parentOfLoadedScript.ToString());
                    lines.Add("(" + parentOfLoadedScript.FileName + "/" + loadedScript.Name + ")");
                    lines.Add("");
                    int cmdCount = loadedScript.Commands.Count;
                    lines.Add(string.Format("This script contains {0} command" + (cmdCount > 1 ? "s" : "") + ".", cmdCount));
                }
            }
            
            lbScriptInfo.Text = string.Join("\n", lines);
        }

        private void OpenScript(ScriptFile scriptFile, Script script)
        {
            parentOfLoadedScript = scriptFile;
            loadedScript = script;
            fullFileMode = false;
            UpdateScriptBox();
            UpdateScriptInfo();
            tbtnScriptCompile.Enabled = true;
            tbtnScriptSave.Enabled = true;
        }

        private void OpenScriptFile(ScriptFile scriptFile)
        {
            parentOfLoadedScript = scriptFile;
            loadedScript = null;
            fullFileMode = true;
            UpdateScriptBox();
            UpdateScriptInfo();
            tbtnScriptCompile.Enabled = true;
            tbtnScriptSave.Enabled = true;
        }

        private bool DoesScriptNameExist(string name)
        {
            return scriptFiles.SelectMany(f => f.Scripts).Select(s => s.Name).Contains(name);
        }

        private void AddScript(ScriptFile scriptFile)
        {
            FormTextBox newScriptForm = new FormTextBox("Add Script", "Enter the name for the script:", "Confirm", "Cancel");

            if (newScriptForm.ShowDialog() == DialogResult.OK)
            {
                string result = newScriptForm.Result;
                if (string.IsNullOrWhiteSpace(result))
                {
                    MessageBox.Show("The given Script name is empty.", "Invalid Script Name", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (DoesScriptNameExist(result))
                {
                    MessageBox.Show("The given Script name already exists in a Script File.", "Invalid Script Name", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    int endId = FileConstants.Commands.Where(c => c.Name == "_END").Select(c => c.Id).DefaultIfEmpty(0).First();
                    Argument endArgument = new Argument(ArgumentType.Command, endId);
                    Script script = new Script(result, new List<Command>() { new Command(new List<Argument>() { endArgument }) });
                    scriptFile.Scripts.Add(script);
                    MessageBox.Show("Added the new script in memory successfully! Don't forget to export all your changes.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    UpdateScriptFileList();
                }
            }
        }

        private void RenameScriptFile(ScriptFile scriptFile)
        {
            FormTextBox renameScriptForm = new FormTextBox("Rename Script File", "Enter the new name for the script file (This will replace the actual file name, not the friendly name):", "Confirm", "Cancel");

            if (renameScriptForm.ShowDialog() == DialogResult.OK)
            {
                string result = renameScriptForm.Result;
                if (string.IsNullOrWhiteSpace(result))
                {
                    MessageBox.Show("The given Script File name is empty.", "Invalid Script File Name", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    scriptFile.FileName = result;
                    MessageBox.Show("Renamed the Script File in memory successfully! Don't forget to export all your changes.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    UpdateScriptFileList();
                }
            }
        }

        private void RenameScript(ScriptFile scriptFile, Script script)
        {
            FormTextBox renameScriptForm = new FormTextBox("Rename Script", "Enter the new name for the script:", "Confirm", "Cancel");

            if (renameScriptForm.ShowDialog() == DialogResult.OK)
            {
                string result = renameScriptForm.Result;
                List<Script> list = scriptFile.Scripts;
                if (string.IsNullOrWhiteSpace(result))
                {
                    MessageBox.Show("The given Script name is empty.", "Invalid Script Name", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (DoesScriptNameExist(result))
                {
                    MessageBox.Show("The given Script name already exists in this file.", "Invalid Script Name", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    script.Name = result;
                    MessageBox.Show("Renamed the Script in memory successfully! Don't forget to export all your changes.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    UpdateScriptFileList();
                }
            }
        }

        private void DeleteScript(ScriptFile scriptFile, Script script)
        {
            if (MessageBox.Show("Are you sure you want to delete this script from memory? The script will be completely gone when you export your changes.", "Script Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                List<Script> list = scriptFile.Scripts;
                list.Remove(script);
                MessageBox.Show("Removed the new script from memory successfully! Don't forget to export all your changes.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UpdateScriptFileList();
            }
        }

        private void SaveScriptInMemory(Script script)
        {
            parentOfLoadedScript.Scripts[parentOfLoadedScript.Scripts.FindIndex(f => f.Name == script.Name)] = script;
            MessageBox.Show("Successfully saved the script in memory!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            UpdateScriptFileList();
        }

        private void SaveScriptFileInMemory(ScriptFile scriptFile)
        {
            scriptFiles[scriptFiles.FindIndex(f => f.PathID == scriptFile.PathID)] = scriptFile;
            MessageBox.Show("Successfully saved the script file in memory!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            UpdateScriptFileList();
        }

        private void CompileScript()
        {
            try
            {
                string code = GetEditorValue();
                if (fullFileMode)
                {
                    ScriptFile scriptFile = scriptEditorEngine.CompileScriptFile(code, parentOfLoadedScript.PathID, parentOfLoadedScript.FileName, false);
                }
                else
                {
                    Script script = scriptEditorEngine.CompileScript(code, loadedScript.Name, false);
                }
                ClearErrors();
            }
            catch (ScriptValidationExceptionListException ex)
            {
                UpdateErrors(ex);
            }
        }

        private void SaveScript()
        {
            try
            {
                string code = GetEditorValue();
                if (fullFileMode)
                {
                    if (MessageBox.Show("Saving will overwrite all the scripts in this script file. Are you sure you want to save?", "Potential Data Loss", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        ScriptFile scriptFile = scriptEditorEngine.CompileScriptFile(code, parentOfLoadedScript.PathID, parentOfLoadedScript.FileName, false);
                        SaveScriptFileInMemory(scriptFile);
                    }
                }
                else
                {
                    Script script = scriptEditorEngine.CompileScript(code, loadedScript.Name, false);
                    SaveScriptInMemory(script);
                }
            }
            catch (ScriptValidationExceptionListException ex)
            {
                bool ignorable = !ex.InnerExceptions.Select(exception => exception.Ignorable).Contains(false);
                string type = fullFileMode ? "script file" : "script";
                if (ignorable)
                {
                    int errors = ex.InnerExceptions.Count;
                    string fullError = "There " + (errors > 1 ? "were" : "was a") + " compilation warning" + (errors > 1 ? "s" : "") + ". See the Error List for more details.";
                    if (tbtnSafeMode.Checked)
                    {
                        MessageBox.Show(fullError, "Compilation Warning" + (ex.InnerExceptions.Count > 1 ? "s" : ""), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        fullError += "\nAre you sure you want to save this " + type + " anyways?";
                        if (MessageBox.Show(fullError, "Compilation Warning" + (ex.InnerExceptions.Count > 1 ? "s" : ""), MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            string code = GetEditorValue();
                            if (fullFileMode)
                            {
                                ScriptFile scriptFile = scriptEditorEngine.CompileScriptFile(code, parentOfLoadedScript.PathID, parentOfLoadedScript.FileName, true);
                                SaveScriptFileInMemory(scriptFile);
                            }
                            else
                            {
                                Script script = scriptEditorEngine.CompileScript(code, loadedScript.Name, true);
                                SaveScriptInMemory(script);
                            } 
                        }
                    }
                }
                else
                {
                    int errors = ex.InnerExceptions.Where(exception => !exception.Ignorable).Count();
                    string description = "There " + (errors > 1 ? "were" : "was a") + " compilation error" + (errors > 1 ? "s" : "") + " and the " + type + " cannot be saved. See the Error List for more details.";
                    MessageBox.Show(description, "Compilation Error" + (errors > 1 ? "s" : ""), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ClearErrors()
        {
            gridErrors.DataSource = new List<Error>();
        }

        private void UpdateErrors(ScriptValidationExceptionListException errors)
        {
            List<Error> messages = errors.InnerExceptions.Select(ex => new Error(ex.Ignorable, ex.Line, ex.Message)).ToList();
            gridErrors.DataSource = messages;
        }

        private void ToggleErrorList()
        {
            collapsedErrorList = !collapsedErrorList;

            if (collapsedErrorList)
            {
                splitEditor.Panel2Collapsed = true;
                splitEditor.Panel2.Hide();
            }
            else
            {
                splitEditor.Panel2Collapsed = false;
                splitEditor.Panel2.Show();
            }

            ResizeEditor();
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
                        UpdateScriptFileList();
                        EnableControlsOnOpen();
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

        private void tbtnScriptCompile_Click(object sender, EventArgs e)
        {
            CompileScript();
        }

        private void tbtnScriptSave_Click(object sender, EventArgs e)
        {
            SaveScript();
        }

        private void tbtnReference_Click(object sender, EventArgs e)
        {
            if (formReference == null)
            {
                formReference = new FormReference(this);
            }
            if (!formReference.Visible)
            {
                formReference.Show(this);
            }
        }

        private void tbtnError_Click(object sender, EventArgs e)
        {
            ToggleErrorList();
        }

        private void treeFiles_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (e.Node.Tag is Script script)
                {
                    OpenScript((ScriptFile)e.Node.Parent.Tag, script);
                }
                else if (e.Node.Tag is ScriptFile scriptFile)
                {
                    OpenScriptFile(scriptFile);
                }
            }
            
        }

        private void cntxtScriptFile_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            cntxtScriptFile.Close();
            if (e.ClickedItem == cntxtitemScriptFileOpen)
            {
                OpenScriptFile((ScriptFile)treeFiles.SelectedNode.Tag);
            }
            else if (e.ClickedItem == cntxtitemScriptFileRename)
            {
                RenameScriptFile((ScriptFile)treeFiles.SelectedNode.Tag);
            }
            else if (e.ClickedItem == cntxtitemScriptFileAdd)
            {
                AddScript((ScriptFile)treeFiles.SelectedNode.Tag);
            }
        }

        private void cntxtScript_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            cntxtScript.Close();
            if (e.ClickedItem == cntxtitemScriptOpen)
            {
                OpenScript((ScriptFile)treeFiles.SelectedNode.Parent.Tag, (Script)treeFiles.SelectedNode.Tag);
            }
            else if (e.ClickedItem == cntxtitemScriptRename)
            {
                RenameScript((ScriptFile)treeFiles.SelectedNode.Parent.Tag, (Script)treeFiles.SelectedNode.Tag);
            }
            else if (e.ClickedItem == cntxtitemScriptDelete)
            {
                DeleteScript((ScriptFile)treeFiles.SelectedNode.Parent.Tag, (Script)treeFiles.SelectedNode.Tag);
            }
        }

        private void treeFiles_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            treeFiles.SelectedNode = e.Node;
        }

        private void treeFiles_BeforeCollapse(object sender, TreeViewCancelEventArgs e)
        {
            if (treeViewDoubleClick && e.Action == TreeViewAction.Collapse) e.Cancel = true;
        }

        private void treeFiles_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (treeViewDoubleClick && e.Action == TreeViewAction.Expand) e.Cancel = true;
        }

        private void treeFiles_MouseDown(object sender, MouseEventArgs e)
        {
            treeViewDoubleClick = e.Clicks > 1;
        }
    }
}
