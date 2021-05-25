using System.Reflection;
using HarmonyLib;
using FixURLOpen.MainPatch;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityModManagerNet;

namespace FixURLOpen {
    internal static class Main {
        internal static UnityModManager.ModEntry Mod;
        private static Harmony _harmony;
        internal static bool IsEnabled { get; private set; }

        private static void Load(UnityModManager.ModEntry modEntry) {
            Mod = modEntry;
            Mod.OnToggle = OnToggle;
        }

        private static bool OnToggle(UnityModManager.ModEntry modEntry, bool value) {
            IsEnabled = value;

            if (value) Start();
            else Stop();

            return true;
        }

        private static void Start() {
            _harmony = new Harmony(Mod.Info.Id);
            _harmony.PatchAll(Assembly.GetExecutingAssembly());
        }

        private static void Stop() {
            _harmony.UnpatchAll(Mod.Info.Id);
            _harmony = null;
        }
    }
}