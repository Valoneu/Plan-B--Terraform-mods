using BepInEx;
using BepInEx.Configuration;
using HarmonyLib;
using System;

namespace LargerCities
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        private void Awake()
        {
            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
            var harmony = new Harmony(PluginInfo.PLUGIN_GUID);
            harmony.PatchAll(typeof(Patch));
        }

        [HarmonyPatch]
        public class Patch
        {
            [HarmonyPostfix]
            [HarmonyPatch(typeof(CCity), "GetNbHexesTargetRaw")]
            public static void Postfix(ref float __result, double ___population)
            {
                __result = (float)(Math.Sqrt(___population * Math.Sqrt(___population)));
            }
        }
    }
}
