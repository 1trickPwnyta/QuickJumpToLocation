using Verse;
using HarmonyLib;
using UnityEngine;

namespace QuickJumpToLocation
{
    public class QuickJumpToLocationMod : Mod
    {
        public const string PACKAGE_ID = "quickjumptolocation.1trickPonyta";
        public const string PACKAGE_NAME = "Quick Jump to Location";

        public static QuickJumpToLocationSettings Settings;

        public QuickJumpToLocationMod(ModContentPack content) : base(content)
        {
            Settings = GetSettings<QuickJumpToLocationSettings>();

            var harmony = new Harmony(PACKAGE_ID);
            harmony.PatchAll();

            Log.Message($"[{PACKAGE_NAME}] Loaded.");
        }

        public override string SettingsCategory() => PACKAGE_NAME;

        public override void DoSettingsWindowContents(Rect inRect)
        {
            base.DoSettingsWindowContents(inRect);
            QuickJumpToLocationSettings.DoSettingsWindowContents(inRect);
        }
    }
}
