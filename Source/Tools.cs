using RimWorld;
using UnityEngine;
using Verse;
using Verse.Sound;

namespace QuickJumpToLocation
{
    public static class Tools
    {
        public static void QuickJumpToLocation(Letter __instance, Rect rect)
        {
            if (__instance != null)
            {
                if (Event.current.type == EventType.MouseDown && Event.current.button == 2 && Mouse.IsOver(rect))
                {
                    bool validTarget = __instance.lookTargets.IsValid();
                    bool canDismiss = __instance.CanDismissWithRightClick;

                    if (validTarget)
                    {
                        CameraJumper.TryJumpAndSelect(__instance.lookTargets.TryGetPrimaryTarget());
                    }

                    if (canDismiss)
                    {
                        Find.LetterStack.RemoveLetter(__instance);
                    }

                    if (validTarget || canDismiss)
                    {
                        SoundDefOf.Click.PlayOneShotOnCamera(null);
                        Event.current.Use();
                    }
                }
            }
        }
    }
}
