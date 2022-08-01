using PokemonBDSPEditor.Data.Utils;
using PokemonBDSPEditor.Engine.ScriptEditor;
using PokemonBDSPEditor.Engine.ScriptEditor.Model;
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
        private ScriptEditorEngine scriptEditorEngine;

        public FormMain()
        {
            InitializeComponent();
            scriptEditorEngine = new ScriptEditorEngine();
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
            List<ScriptFile> scripts = scriptEditorEngine.GetScriptFiles();
            UpdateScriptFileList(scripts);
        }

        private void comboScriptFile_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateScriptList(scriptEditorEngine.GetScriptFiles()[comboScriptFile.SelectedIndex].Scripts);
        }
    }
}
