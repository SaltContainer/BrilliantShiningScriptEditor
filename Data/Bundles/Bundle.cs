using AssetsTools.NET;
using AssetsTools.NET.Extra;
using PokemonBDSPEditor.Data.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PokemonBDSPEditor.Data
{
    abstract class Bundle
    {
        protected AssetsManager assetsManager;
        protected string bundleKey;
        protected BundleFileInstance bundle;
        protected AssetsFileInstance assetsFile;
        protected byte[] newData;

        public Bundle(AssetsManager assetsManager, BundleFileInstance bundle, string bundleKey)
        {
            this.assetsManager = assetsManager;
            this.bundle = bundle;
            this.bundleKey = bundleKey;

            assetsFile = assetsManager.LoadAssetsFileFromBundle(bundle, FileConstants.Bundles[bundleKey].CabDirectory);
            if (!assetsFile.file.typeTree.hasTypeTree)
                assetsManager.LoadClassDatabaseFromPackage(assetsFile.file.typeTree.unityVersion);
        }

        public AssetTypeValueField GetFileInBundle(string fileName)
        {
            return GetBaseField(fileName);
        }

        public void SetFilesInBundle(Dictionary<string, JObject> files)
        {
            List<AssetsReplacer> replacers = GenerateReplacers(files);

            if (replacers != null)
            {
                using (var stream = new MemoryStream())
                using (var writer = new AssetsFileWriter(stream))
                {
                    assetsFile.file.Write(writer, 0, replacers, 0);
                    newData = stream.ToArray();
                }
            }
        }

        protected abstract List<AssetsReplacer> GenerateReplacers(Dictionary<string, JObject> files);

        private AssetTypeValueField GetBaseField(string fileName)
        {
            AssetFileInfoEx fileInfo = assetsFile.table.GetAssetInfo(fileName);
            return assetsManager.GetTypeInstance(assetsFile, fileInfo).GetBaseField();
        }

        public List<AssetTypeValueField> GetFilesInBundle()
        {
            List<AssetTypeValueField> files = new List<AssetTypeValueField>();
            foreach (var info in assetsFile.table.assetFileInfo)
            {
                files.Add(assetsManager.GetTypeInstance(assetsFile, info).GetBaseField());
            }
            return files;
        }

        public AssetsFileInstance GetAssetsFile()
        {
            return assetsFile;
        }

        public BundleFileInstance GetBundle()
        {
            return bundle;
        }

        public byte[] GetNewData()
        {
            return newData;
        }
    }
}
