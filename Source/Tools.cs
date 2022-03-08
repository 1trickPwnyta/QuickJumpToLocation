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
                    bool validTarget = letter.lookTargets.IsValid();
                    bool canDismiss = letter.CanDismissWithRightClick;

                    if (validTarget)
                    {
                        CameraJumper.TryJumpAndSelect(letter.lookTargets.TryGetPrimaryTarget());
                    }

                    if (canDismiss)
                    {
                        Find.LetterStack.RemoveLetter(letter);
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
