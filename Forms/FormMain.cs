using PokemonBDSPEditor.Data.Utils;
using PokemonBDSPEditor.Engine.Editor;
using PokemonBDSPEditor.Engine.Editor.Model;
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

        private void UpdateScriptFileList(List<ScriptFile> scriptFiles)
        {
            comboScriptFile.DataSource = scriptFiles;
            comboScriptFile.SelectedIndex = 0;
        }

        private void UpdateScriptList(List<Script> scripts)
        {
            comboScript.DataSource = scripts;
            comboScript.SelectedIndex = 0;
        }

        private void btnScriptAdd_Click(object sender, EventArgs e)
        {
            List<ScriptFile> scripts = editorEngine.GetScriptFiles();
            UpdateScriptFileList(scripts);
        }

        private void comboScriptFile_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateScriptList(editorEngine.GetScriptFiles()[comboScriptFile.SelectedIndex].Scripts);
        }
    }
}
