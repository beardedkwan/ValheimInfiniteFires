using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BepInEx;
using HarmonyLib;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace ValheimInfiniteFires
{
    public class PluginInfo
    {
        public const string Name = "ValheimInfiniteFires";
        public const string Guid = "beardedkwan" + Name;
        public const string Version = "1.0.0";
    }

    [BepInPlugin(PluginInfo.Guid, PluginInfo.Name, PluginInfo.Version)]
    [BepInProcess("valheim.exe")]
    public class ValheimInfiniteFires : BaseUnityPlugin
    {
        [HarmonyPatch(typeof(Fireplace), "UpdateFireplace")]
        public static class Fireplace_Patch
        {
            static void Prefix(Fireplace __instance, ref ZNetView ___m_nview)
            {
                ___m_nview.GetZDO().Set("fuel", __instance.m_maxFuel);
            }
        }
    }
}
