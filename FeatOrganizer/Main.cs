using System;
using System.Collections.Generic;
using HarmonyLib;
using UnityModManagerNet;
using FeatOrganizer.Utils;

namespace FeatOrganizer
{
    internal static class Main
    {
        private const string HarmonyId = "com.combatoverhaul.core";

        private static Harmony _harmony;
        private static UnityModManager.ModEntry _mod;
        private static bool _enabled;

        // Guardamos los IDisposable devueltos por EventBus.Subscribe
        private static readonly List<IDisposable> _busSubs = new List<IDisposable>();

        // ---------- UMM entry ----------
        static bool Load(UnityModManager.ModEntry entry)
        {
            _mod = entry;
            entry.OnToggle = OnToggle;
            entry.OnUnload = OnUnload;
            Log.Info("UMM entry loaded.");
            return true;
        }

        // ---------- Toggle ----------
        private static bool OnToggle(UnityModManager.ModEntry entry, bool value)
        {
            if (_enabled == value) return true;

            try
            {
                _enabled = value;
                if (value)
                {
                    // 1) Aplicar parches
                    _harmony = new Harmony(HarmonyId);
                    _harmony.PatchAll(typeof(Main).Assembly);

                    Log.Info("Enabled. Harmony patches applied and handlers subscribed.");
                }
                else
                {
                    // 1) Desuscribir handlers
                    UnsubscribeHandlers();

                    // 2) Retirar parches
                    if (_harmony != null) _harmony.UnpatchAll(HarmonyId);
                    _harmony = null;

                    Log.Info("Disabled. Handlers unsubscribed and patches removed.");
                }
                return true;
            }
            catch (Exception ex)
            {
                Log.Error("Toggle failed.", ex);
                return false;
            }
        }

        // ---------- Unload ----------
        private static bool OnUnload(UnityModManager.ModEntry entry)
        {
            try
            {
                UnsubscribeHandlers();

                if (_harmony != null) _harmony.UnpatchAll(HarmonyId);
                _harmony = null;

                _enabled = false;
                Log.Info("Unloaded.");
            }
            catch (Exception ex)
            {
                Log.Error("Error on unload.", ex);
            }
            return true;
        }

        private static void UnsubscribeHandlers()
        {
            foreach (var d in _busSubs)
            {
                try { d?.Dispose(); }
                catch (Exception ex) { Log.Error("Unsubscribe failed.", ex); }
            }
            _busSubs.Clear();
        }
    }
}
