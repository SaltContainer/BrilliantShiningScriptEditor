using BrilliantShiningScriptEditor.Engine.ScriptEditor.Exceptions;
using BrilliantShiningScriptEditor.UI.DataView;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace BrilliantShiningScriptEditor.UI.Controls
{
    public partial class CollapsibleErrorList : UserControl
    {
        private bool collapsed;
        private Size intendedSize;

        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), Bindable(true)]
        [Description("The text displayed on the tab."), Category("Appearance")]
        public string ButtonText
        {
            get => tabButton.Text;
            set => tabButton.Text = value;
        }

        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), Bindable(true)]
        [Description("The intended full size of the panel."), Category("Layout")]
        public Size IntendedSize
        {
            get => intendedSize;
            set => intendedSize = value;
        }

        public CollapsibleErrorList()
        {
            InitializeComponent();
            collapsed = true;
        }

        private void UpdateSize(bool collapsed)
        {
            if (collapsed) Size = new Size(Size.Width, 32);
            else Size = new Size(Size.Width, IntendedSize.Height);
        }

        public void ClearErrors()
        {
            gridErrors.DataSource = new List<Error>();
        }

        public void UpdateErrors(ScriptValidationExceptionListException errors)
        {
            List<Error> messages = errors.InnerExceptions.Select(ex => new Error(ex.Ignorable, ex.Line, ex.Message)).ToList();
            gridErrors.DataSource = messages;
        }

        private void tabContainer_Selected(object sender, TabControlEventArgs e)
        {
            
        }

        private void tabContainer_Selecting(object sender, TabControlCancelEventArgs e)
        {
            
        }

        private void tabContainer_SelectedIndexChanged(object sender, EventArgs e)
        {
            collapsed = !collapsed;
            UpdateSize(collapsed);
        }
    }
}
