using AssetsTools.NET;
using AssetsTools.NET.Extra;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonBDSPEditor.Data
{
    class ScriptBundle : Bundle
    {
        public ScriptBundle(AssetsManager assetsManager, BundleFileInstance bundle, string bundleKey) : base(assetsManager, bundle, bundleKey) { }

        protected override List<AssetsReplacer> GenerateReplacers(Dictionary<string, JObject> files)
        {
            List<AssetsReplacer> replacers = new List<AssetsReplacer>();
            foreach (var file in files)
            {
                AssetFileInfoEx fileInfo = assetsFile.table.GetAssetInfo(file.Key);
                AssetTypeValueField baseField = assetsManager.GetTypeInstance(assetsFile, fileInfo).GetBaseField();

                List<AssetTypeValueField> scripts = new List<AssetTypeValueField>();
                foreach (var script in (JArray)file.Value["Scripts"])
                {
                    List<AssetTypeValueField> commands = new List<AssetTypeValueField>();
                    foreach (var command in (JArray)script["Commands"])
                    {
                        List<AssetTypeValueField> arguments = new List<AssetTypeValueField>();
                        foreach (var arg in (JArray)command["Arg"])
                        {
                            var template = baseField.Get("Scripts").Get("Array");
                            var transform = ValueBuilder.DefaultValueFieldFromArrayTemplate(template);
                            transform.Get("m_FileID").GetValue().Set(0);
                            transform.Get("m_PathID").GetValue().Set(123);
                            AssetTypeValueField[] newChildren = new AssetTypeValueField[] { transform };
                            baseField["Scripts"].SetChildrenList(newChildren);
                        }
                        //commands.Add(arguments.ToArray());
                    }
                    //scripts.Add(commands.ToArray());
                }
                baseField["Scripts"][0].SetChildrenList(scripts.ToArray());

                replacers.Add(new AssetsReplacerFromMemory(0, fileInfo.index, (int)fileInfo.curFileType, 0xffff, baseField.WriteToByteArray()));
            }

            return replacers;
        }
    }
}
