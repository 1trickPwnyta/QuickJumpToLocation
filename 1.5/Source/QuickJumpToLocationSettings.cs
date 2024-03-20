using UnityEngine;
using Verse;

namespace QuickJumpToLocation
{
    public class QuickJumpToLocationSettings : ModSettings
    {
        public static bool JumpOnly = false;

        public static void DoSettingsWindowContents(Rect inRect)
        {
            Listing_Standard listingStandard = new Listing_Standard();

            listingStandard.Begin(inRect);

            listingStandard.CheckboxLabeled("QuickJumpToLocation_JumpOnly".Translate(), ref JumpOnly);

            listingStandard.End();
        }

        public override void ExposeData()
        {
            Scribe_Values.Look(ref JumpOnly, "JumpOnly");
        }
    }
}
