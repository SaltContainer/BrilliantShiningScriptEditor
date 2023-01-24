using BrilliantShiningScriptEditor.Data.JSONObjects;
using BrilliantShiningScriptEditor.Data.Utils;
using Microsoft.WindowsAPICodePack.Dialogs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrilliantShiningScriptEditor.UI.Forms
{
    public partial class FormReference : Form
    {
        private FormMain parent;

        public FormReference(FormMain parent)
        {
            InitializeComponent();

            this.parent = parent;

            UpdateDataSources();
        }

        private void UpdateDataSources()
        {
            comboCmdRef.DataSource = FileConstants.AllCommands.OrderBy(c => c.Name).ToList();
            comboFlagRef.DataSource = FileConstants.AllFlags.OrderBy(f => f.Name).ToList();
            comboSysRef.DataSource = FileConstants.AllSystemFlags.OrderBy(s => s.Name).ToList();
            comboWorkRef.DataSource = FileConstants.AllWorkVariables.OrderBy(w => w.Name).ToList();
            comboFileRef.DataSource = FileConstants.AllScriptFileNames.OrderBy(f => f.FriendlyName).ToList();

            parent.ExecuteEditorScript("syntaxReload();");
        }

        private void UpdateCommandInfo(CommandInfo command)
        {
            lbCmdName.Text = string.Format("{0} - {1}", command.Id, command.Name);
            string arguments = "";
            if (command.Arguments.Count == 0) arguments = "No arguments.";
            else arguments = string.Join("\n", command.Arguments.Select(a => string.Format("[{0}] {1} - {2}{3}", string.Join(", ", a.Type), a.Name, a.Optional ? "(Optional) " : "", a.Description)));
            List<string> descriptionItems = new List<string>();
            if (command.Animation) descriptionItems.Add("[Animation command]");
            if (command.Dummy) descriptionItems.Add("This command is dummied out and does nothing.");
            else descriptionItems.Add(command.Description == "" ? "This command is not documented yet." : command.Description);
            lbCmdDescription.Text = string.Format("{0}\n\nArguments:\n{1}", string.Join(" ", descriptionItems), arguments);
        }

        private void UpdateFlagInfo(ArgumentTypeInfo arg)
        {
            lbFlagName.Text = string.Format("{0} - {1}", arg.Id, arg.Name);
            lbFlagDescription.Text = arg.Description == "" ? "This flag is not documented yet." : arg.Description;
        }

        private void UpdateSysFlagInfo(ArgumentTypeInfo arg)
        {
            lbSysName.Text = string.Format("{0} - {1}", arg.Id, arg.Name);
            lbSysDescription.Text = arg.Description == "" ? "This system flag is not documented yet." : arg.Description;
        }

        private void UpdateWorkInfo(ArgumentTypeInfo arg)
        {
            lbWorkName.Text = string.Format("{0} - {1}", arg.Id, arg.Name);
            lbWorkDescription.Text = arg.Description == "" ? "This work variable is not documented yet." : arg.Description;
        }

        private void UpdateFileInfo(FileInfo file)
        {
            lbFileName.Text = string.Format("{0} - {1}", file.PathID, file.FileName);
            lbFileDescription.Text = file.Description == "" ? "This script file is not documented yet." : file.Description;
        }

        private string OpenCustomFile()
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                try
                {
                    string fullJson = "";
                    using (System.IO.StreamReader reader = System.IO.File.OpenText(dialog.FileName))
                    {
                        fullJson = reader.ReadToEnd();
                    }
                    return fullJson;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("There was an exception while reading this file. Exception: " + ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return null;
        }

        private bool WriteCustomToFile(string path, string json)
        {
            try
            {
                using (System.IO.StreamWriter sw = new System.IO.StreamWriter(path))
                {
                    sw.Write(json);
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an exception while writing the custom file. Exception: " + ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        private List<T> TryParseJson<T>(string jsonString)
        {
            try
            {
                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.MissingMemberHandling = MissingMemberHandling.Error;

                return JsonConvert.DeserializeObject<List<T>>(jsonString, settings);
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an exception while parsing this file. Exception: " + ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return null;
        }

        private void FormReference_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

        private void comboCmdRef_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateCommandInfo((CommandInfo)comboCmdRef.SelectedItem);
        }

        private void comboFlagRef_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateFlagInfo((ArgumentTypeInfo)comboFlagRef.SelectedItem);
        }

        private void comboSysRef_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateSysFlagInfo((ArgumentTypeInfo)comboSysRef.SelectedItem);
        }

        private void comboWorkRef_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateWorkInfo((ArgumentTypeInfo)comboWorkRef.SelectedItem);
        }

        private void comboFileRef_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateFileInfo((FileInfo)comboFileRef.SelectedItem);
        }

        private void btnCmdImport_Click(object sender, EventArgs e)
        {
            string json = OpenCustomFile();
            if (json != null)
            {
                List<CommandInfo> commands = TryParseJson<CommandInfo>(json);
                if (commands != null && MessageBox.Show("Importing this file will overwrite the custom commands that were previously imported. Are you sure you want to import this new file?", "Potential Data Loss", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    FileConstants.CustomCommands = commands;
                    if (WriteCustomToFile(System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "JSON", "CustomReference", "commands.json"), JsonConvert.SerializeObject(commands)))
                    {
                        MessageBox.Show("Successfully imported custom commands!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    UpdateDataSources();
                }
            }
        }

        private void btnFlagImport_Click(object sender, EventArgs e)
        {
            string json = OpenCustomFile();
            if (json != null)
            {
                List<ArgumentTypeInfo> flags = TryParseJson<ArgumentTypeInfo>(json);
                if (flags != null && MessageBox.Show("Importing this file will overwrite the custom flags that were previously imported. Are you sure you want to import this new file?", "Potential Data Loss", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    FileConstants.CustomFlags = flags;
                    if (WriteCustomToFile(System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "JSON", "CustomReference", "flags.json"), JsonConvert.SerializeObject(flags)))
                    {
                        MessageBox.Show("Successfully imported custom flags!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    UpdateDataSources();
                }
            }
        }

        private void btnSysImport_Click(object sender, EventArgs e)
        {
            string json = OpenCustomFile();
            if (json != null)
            {
                List<ArgumentTypeInfo> sys_flags = TryParseJson<ArgumentTypeInfo>(json);
                if (sys_flags != null && MessageBox.Show("Importing this file will overwrite the custom system flags that were previously imported. Are you sure you want to import this new file?", "Potential Data Loss", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    FileConstants.CustomSystemFlags = sys_flags;
                    if (WriteCustomToFile(System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "JSON", "CustomReference", "sys_flags.json"), JsonConvert.SerializeObject(sys_flags)))
                    {
                        MessageBox.Show("Successfully imported custom system flags!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    UpdateDataSources();
                }
            }
        }

        private void btnWorkImport_Click(object sender, EventArgs e)
        {
            string json = OpenCustomFile();
            if (json != null)
            {
                List<ArgumentTypeInfo> work = TryParseJson<ArgumentTypeInfo>(json);
                if (work != null && MessageBox.Show("Importing this file will overwrite the custom work variables that were previously imported. Are you sure you want to import this new file?", "Potential Data Loss", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    FileConstants.CustomWorkVariables = work;
                    if (WriteCustomToFile(System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "JSON", "CustomReference", "work.json"), JsonConvert.SerializeObject(work)))
                    {
                        MessageBox.Show("Successfully imported custom work variables!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    UpdateDataSources();
                }
            }
        }

        private void btnFileImport_Click(object sender, EventArgs e)
        {
            string json = OpenCustomFile();
            if (json != null)
            {
                List<FileInfo> file_names = TryParseJson<FileInfo>(json);
                if (file_names != null && MessageBox.Show("Importing this file will overwrite the custom file names that were previously imported. Are you sure you want to import this new file?", "Potential Data Loss", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    FileConstants.CustomScriptFileNames = file_names;
                    if (WriteCustomToFile(System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "JSON", "CustomReference", "file_names.json"), JsonConvert.SerializeObject(file_names)))
                    {
                        MessageBox.Show("Successfully imported custom file names! A restart might be required to get everything up to date.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    UpdateDataSources();
                }
            }
        }
    }
}
