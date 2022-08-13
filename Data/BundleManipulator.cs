﻿using AssetsTools.NET;
using AssetsTools.NET.Extra;
using Newtonsoft.Json.Linq;
using PokemonBDSPEditor.Data.Utils;
using PokemonBDSPEditor.Engine.ScriptEditor.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PokemonBDSPEditor.Data
{
    class BundleManipulator
    {
        private AssetsManager assetsManager;
        private BundleDecompressor bundleDecompressor;
        private Dictionary<string, Bundle> bundles;
        private string basePath;

        public BundleManipulator()
        {
            assetsManager = new AssetsManager();
            bundleDecompressor = new BundleDecompressor(assetsManager);
            bundles = new Dictionary<string, Bundle>();
            basePath = "";
        }

        public bool IsBundleLoaded(string bundle)
        {
            return bundles.ContainsKey(bundle);
        }

        public bool LoadBundles(List<string> bundles)
        {
            try
            {
                foreach (var entry in bundles)
                {
                    if (!IsBundleLoaded(entry))
                    {
                        Bundle data = new ScriptBundle(assetsManager, bundleDecompressor.LoadAndDecompressFile(string.Format("{0}\\{1}", basePath, FileConstants.Bundles[entry].FullPath)), entry);
                        this.bundles.Add(entry, data);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error reading or decompressing one of the bundles. Full Exception: " + ex.Message, "Loading Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool SaveAllBundles(string directory)
        {
            try
            {
                foreach (var entry in bundles)
                {
                    SaveBundleInFile(entry.Key, string.Format("{0}/{1}", directory, FileConstants.Bundles[entry.Key].FullPath));
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error writing one of the bundles. Full Exception: " + ex.Message, "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool SaveBundles(List<string> bundles, string directory)
        {
            try
            {
                foreach (var entry in bundles)
                {
                    SaveBundleInFile(entry, string.Format("{0}\\{1}", directory, FileConstants.Bundles[entry].FullPath));
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error writing one of the bundles. Full Exception: " + ex.Message, "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool SaveBundle(string bundleKey, string directory)
        {
            try
            {
                SaveBundleInFile(bundleKey, string.Format("{0}\\{1}", directory, FileConstants.Bundles[bundleKey].FullPath));
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error writing one of the bundles. Full Exception: " + ex.Message, "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void SaveBundleInFile(string bundleKey, string outFileName)
        {
            Bundle data = bundles[bundleKey];
            BundleFileInstance bundleInstance = data.GetBundle();
            string cabDirName = FileConstants.Bundles[bundleKey].CabDirectory;

            BundleReplacerFromMemory bundleReplacer = new BundleReplacerFromMemory(cabDirName, cabDirName, true, data.GetNewData(), -1);
            AssetsFileWriter bundleWriter = new AssetsFileWriter(File.OpenWrite(outFileName));
            bundleInstance.file.Write(bundleWriter, new List<BundleReplacer>() { bundleReplacer });

            bundleWriter.Close();
        }

        public List<AssetTypeValueField> GetFilesOfBundle(string bundleKey)
        {
            return bundles[bundleKey].GetFilesInBundle();
        }

        public AssetTypeValueField GetFileOfBundle(string bundleKey, string fileName)
        {
            return bundles[bundleKey].GetFileInBundle(fileName);
        }

        public void SetFilesToBundle(string bundleKey, Dictionary<string, JObject> files)
        {
            bundles[bundleKey].SetFilesInBundle(files);
        }

        public void SetBasePath(string path)
        {
            this.basePath = path;
        }
    }
}
