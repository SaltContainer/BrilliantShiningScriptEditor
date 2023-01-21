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

namespace BrilliantShiningScriptEditor.Forms
{
    public partial class FormReference : Form
    {
        public FormReference()
        {
            InitializeComponent();

            comboCmdRef.DataSource = FileConstants.Commands;
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
    }
}
