using BrilliantShiningScriptEditor.Data.JSONObjects;
using BrilliantShiningScriptEditor.Data.Utils;
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
    public partial class FormReference : Form
    {
        public FormReference()
        {
            InitializeComponent();

            comboCmdRef.DataSource = FileConstants.Commands.OrderBy(c => c.Name).ToList();
            comboFlagRef.DataSource = FileConstants.Flags.OrderBy(f => f.Name).ToList();
            comboSysRef.DataSource = FileConstants.SystemFlags.OrderBy(s => s.Name).ToList();
            comboWorkRef.DataSource = FileConstants.WorkVariables.OrderBy(w => w.Name).ToList();
            comboFileRef.DataSource = FileConstants.ScriptFileNames.OrderBy(f => f.FriendlyName).ToList();
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
    }
}
