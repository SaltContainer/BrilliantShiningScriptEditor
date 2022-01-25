using AssetsTools.NET;
using AssetsTools.NET.Extra;
using PokemonBDSPEditor.Data.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonBDSPEditor.Data
{
    class BundleData
    {
        private AssetsManager assetsManager;
        private string bundleKey;
        private BundleFileInstance bundle;
        private AssetsFileInstance assetsFile;
        private byte[] newData;

        public BundleData(AssetsManager assetsManager, BundleFileInstance bundle, string bundleKey)
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

        public void SetFilesInBundle(Dictionary<string, string> files)
        {
            List<AssetsReplacer> replacers = new List<AssetsReplacer>();
            foreach (var file in files)
            {
                AssetFileInfoEx fileInfo = assetsFile.table.GetAssetInfo(file.Key);
                AssetTypeValueField baseField = assetsManager.GetTypeInstance(assetsFile, fileInfo).GetBaseField();
                baseField.Get(file.Key).GetValue().Set(file.Value);
                replacers.Add(new AssetsReplacerFromMemory(0, fileInfo.index, (int)fileInfo.curFileType, 0xffff, baseField.WriteToByteArray()));
            }

            using (var stream = new MemoryStream())
            using (var writer = new AssetsFileWriter(stream))
            {
                assetsFile.file.Write(writer, 0, replacers, 0);
                newData = stream.ToArray();
            }
        }

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
