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
            foreach (var jfile in files)
            {
                AssetFileInfoEx fileInfo = assetsFile.table.GetAssetInfo(jfile.Key);
                AssetTypeValueField baseField = assetsManager.GetTypeInstance(assetsFile, fileInfo).GetBaseField();

                JArray jscripts = (JArray)jfile.Value["Scripts"];
                var scriptArray = baseField["Scripts"]["Array"];
                
                if (jscripts.Count <= scriptArray.childrenCount) scriptArray.SetChildrenList(scriptArray.children.Take(jscripts.Count).ToArray());
                else
                {
                    List<AssetTypeValueField> extra = new List<AssetTypeValueField>();
                    for (int i = scriptArray.childrenCount; i < jscripts.Count; i++) extra.Add(ValueBuilder.DefaultValueFieldFromArrayTemplate(scriptArray));
                    scriptArray.SetChildrenList(scriptArray.children.Concat(extra).ToArray());
                }

                for (int i = 0; i < jscripts.Count; i++)
                {
                    JToken jscript = jscripts[i];
                    baseField["Scripts"][0][i]["Label"].GetValue().Set(jscript["Label"]);

                    JArray jcommands = (JArray)jscript["Commands"];
                    var commandArray = baseField["Scripts"][0][i]["Commands"]["Array"];

                    if (jcommands.Count <= commandArray.childrenCount) commandArray.SetChildrenList(commandArray.children.Take(jcommands.Count).ToArray());
                    else
                    {
                        List<AssetTypeValueField> extra = new List<AssetTypeValueField>();
                        for (int j = commandArray.childrenCount; j < jcommands.Count; j++) extra.Add(ValueBuilder.DefaultValueFieldFromArrayTemplate(commandArray));
                        commandArray.SetChildrenList(commandArray.children.Concat(extra).ToArray());
                    }

                    for (int j = 0; j < jcommands.Count; j++)
                    {
                        JToken jcommand = jcommands[j];

                        JArray jargs = (JArray)jcommand["Arg"];
                        var argArray = baseField["Scripts"][0][i]["Commands"][0][j]["Arg"]["Array"];

                        if (jargs.Count <= argArray.childrenCount) argArray.SetChildrenList(argArray.children.Take(jargs.Count).ToArray());
                        else
                        {
                            List<AssetTypeValueField> extra = new List<AssetTypeValueField>();
                            for (int k = argArray.childrenCount; k < jargs.Count; k++) extra.Add(ValueBuilder.DefaultValueFieldFromArrayTemplate(argArray));
                            argArray.SetChildrenList(argArray.children.Concat(extra).ToArray());
                        }

                        for (int k = 0; k < jargs.Count; k++)
                        {
                            JToken jarg = jargs[k];
                            baseField["Scripts"][0][i]["Commands"][0][j]["Arg"][0][k]["argType"].GetValue().Set(jarg["argType"]);
                            baseField["Scripts"][0][i]["Commands"][0][j]["Arg"][0][k]["data"].GetValue().Set(jarg["data"]);
                        }
                    }
                }

                replacers.Add(new AssetsReplacerFromMemory(0, fileInfo.index, (int)fileInfo.curFileType, 0xffff, baseField.WriteToByteArray()));
            }

            return replacers;
        }
    }
}
