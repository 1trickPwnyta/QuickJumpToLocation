using RimWorld;
using UnityEngine;
using Verse;
using Verse.Sound;

namespace QuickJumpToLocation
{
    public static class Tools
    {
        public static void QuickJumpToLocation(Letter letter, Rect rect)
        {
            if (letter != null)
            {
                if (Event.current.type == EventType.MouseDown && Event.current.button == 2 && Mouse.IsOver(rect))
                {
                    bool useEvent = false;

                    if (letter.lookTargets.IsValid())
                    {
                        CameraJumper.TryJumpAndSelect(letter.lookTargets.TryGetPrimaryTarget());
                        useEvent = true;
                    }

                    if (letter.CanDismissWithRightClick && !QuickJumpToLocationSettings.JumpOnly)
                    {
                        Find.LetterStack.RemoveLetter(letter);
                        SoundDefOf.Click.PlayOneShotOnCamera(null);
                        useEvent = true;
                    }

                    if (useEvent)
                    {
                        Event.current.Use();
                    }
                }
            }
        }
    }
}
