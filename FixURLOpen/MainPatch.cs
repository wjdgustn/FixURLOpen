using System;
using System.CodeDom;
using System.Configuration;
using System.IO;
using System.Linq;
using HarmonyLib;
using UnityEngine;
using UnityModManagerNet;

namespace FixURLOpen.MainPatch {
    [HarmonyPatch(typeof(scnEditor), "FindAdofaiLevelOnDirectory")]

    internal static class FixURLOpen {
        private static bool Prefix(ref string __result, scnEditor __instance, string path) {
            string[] files = Directory.GetFiles(path, "*.adofai", SearchOption.AllDirectories).Where(s => !s.Contains("backup.adofai")).ToArray();
            if (files.Length == 0)
            {
                __instance.printe("level was not found");
                __result = null;
                return false;
            }
            string str = null;
            for (int index = 0; index < files.Length; ++index)
            {
                if (!Path.GetFileName(files[index]).StartsWith("."))
                {
                    str = files[index];
                    MonoBehaviour.print("selected file: " + str);
                    break;
                }
            }

            if (str != null) {
                __result = str;
                return false;
            }
            MonoBehaviour.print("was null");
            __result = null;
            return false;
        }
    }
}