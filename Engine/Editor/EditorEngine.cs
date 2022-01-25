using AssetsTools.NET;
using PokemonBDSPEditor.Data;
using PokemonBDSPEditor.Data.Utils;
using PokemonBDSPEditor.Engine.Editor.DTO;
using PokemonBDSPEditor.Engine.Editor.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonBDSPEditor.Engine.Editor
{
    class EditorEngine
    {
        private BundleManipulator bundleManipulator;
        private List<ScriptFile> scriptFiles;
        private bool scriptFilesLoaded;

        public EditorEngine()
        {
            bundleManipulator = new BundleManipulator();
            scriptFiles = new List<ScriptFile>();
            scriptFilesLoaded = false;
        }

        public List<ScriptFile> GetScriptFiles()
        {
            if (!AreScriptFilesLoaded()) LoadScriptFiles();
            return scriptFiles;
        }

        private void LoadScriptFiles()
        {
            bundleManipulator.LoadBundles(new List<string>() { FileConstants.ScriptDataBundleKey });
            var files = bundleManipulator.GetFilesOfBundle(FileConstants.ScriptDataBundleKey);
            foreach (var file in files)
            {
                if (file["Scripts"] != null)
                {
                    AssetTypeValueField[] scripts = files[0]["Scripts"]["Array"].children;
                }
            }
        }

        private ScriptFile ConvertToScriptFile(List<ScriptDTO> dto)
        {
            return null;
        }

        public bool AreScriptFilesLoaded()
        {
            return scriptFilesLoaded;
        }
    }
}
