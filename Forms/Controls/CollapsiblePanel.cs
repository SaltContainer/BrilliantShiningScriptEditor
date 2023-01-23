using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrilliantShiningScriptEditor.Forms.Controls
{
    public partial class CollapsiblePanel : UserControl
    {
        private bool collapsed;
        private Size intendedSize;

        [Description("The text displayed on the tab."), Category("Appearance")]
        public string ButtonText
        {
            get => tabButton.Text;
            set => tabButton.Text = value;
        }

        [Description("The intended full size of the panel."), Category("Appearance")]
        public Size IntendedSize
        {
            get => intendedSize;
            set => intendedSize = value;
        }

        public CollapsiblePanel()
        {
            InitializeComponent();
            collapsed = true;
        }

        private void UpdateSize(bool collapsed)
        {
            if (collapsed) Size = new Size(Size.Width, 32);
            else Size = new Size(Size.Width, IntendedSize.Height);
        }

        private void tabContainer_Selected(object sender, TabControlEventArgs e)
        {
            collapsed = !collapsed;
            UpdateSize(collapsed);
        }
    }
}
