using PokemonBDSPEditor.Data.Utils;
using PokemonBDSPEditor.Engine.Editor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PokemonBDSPEditor.Forms
{
    public partial class FormMain : Form
    {
        private EditorEngine editorEngine;

        public FormMain()
        {
            InitializeComponent();
            editorEngine = new EditorEngine();
        }

        private void btnScriptAdd_Click(object sender, EventArgs e)
        {
            editorEngine.GetScriptFiles();
        }
    }
}
