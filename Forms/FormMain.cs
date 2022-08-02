using PokemonBDSPEditor.Data.JSONObjects;
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
using System.Text.RegularExpressions;
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
            scriptEditorEngine.SetBasePath("romfs");

            dataScriptCommands.DataSource = scriptEditorEngine.GetCommands();
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

        private void UpdateScriptBox()
        {
            rtbScript.Text = scriptEditorEngine.DecompileScript((Script)comboScript.SelectedItem);
        }

        private void comboScriptFile_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateScriptList(scriptEditorEngine.GetScriptFiles()[comboScriptFile.SelectedIndex].Scripts);
        }

        private void comboScript_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateScriptBox();
        }

        private void btnScriptAdd_Click(object sender, EventArgs e)
        {
            // Add Script

            Script script = scriptEditorEngine.CompileScript(rtbScript.Text, ((Script)comboScript.SelectedItem).Name);
        }

        private void btnScriptCompile_Click(object sender, EventArgs e)
        {
            // Compile Script
        }

        private void btnScriptSave_Click(object sender, EventArgs e)
        {
            // Save Script
        }

        private void tbtnOpen_Click(object sender, EventArgs e)
        {
            // Open ROMFS

            List<ScriptFile> scripts = scriptEditorEngine.GetScriptFiles();
            UpdateScriptFileList(scripts);
        }

        private void tbtnSave_Click(object sender, EventArgs e)
        {
            // Save ROMFS
        }
    }
}
