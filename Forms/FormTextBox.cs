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
    public partial class FormTextBox : Form
    {
        public string Result { get; set; }

        public FormTextBox(string title, string description, string yesButton, string noButton)
        {
            InitializeComponent();

            Text = title;
            lbInfo.Text = description;
            btnYes.Text = yesButton;
            btnNo.Text = noButton;
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            Result = txtAnswer.Text;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
