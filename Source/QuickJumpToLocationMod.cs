using Verse;
using HarmonyLib;

namespace QuickJumpToLocation
{
    public class QuickJumpToLocationMod : Mod
    {
        public const string PACKAGE_ID = "quickjumptolocation.1trickPonyta";
        public const string PACKAGE_NAME = "Quick Jump to Location";

        public QuickJumpToLocationMod(ModContentPack content) : base(content)
        {
            var harmony = new Harmony(PACKAGE_ID);
            harmony.PatchAll();

            Log.Message($"[{PACKAGE_NAME}] Loaded.");
        }
    }
}
