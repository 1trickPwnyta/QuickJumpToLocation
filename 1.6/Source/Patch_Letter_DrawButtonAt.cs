using HarmonyLib;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using Verse;

namespace QuickJumpToLocation
{
    [HarmonyPatch(typeof(Letter))]
    [HarmonyPatch(nameof(Letter.DrawButtonAt))]
    public static class Patch_Letter_DrawButtonAt
    {
        public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            bool foundRect = false;
            object ldlocRectLoc = null;

            foreach (CodeInstruction instruction in instructions)
            {
                if (!foundRect && instruction.opcode == OpCodes.Call && instruction.operand is ConstructorInfo && (ConstructorInfo) instruction.operand == Refs.c_Rect)
                {
                    foundRect = true;
                }
                else if (foundRect && ldlocRectLoc == null && instruction.opcode == OpCodes.Ldloca_S)
                {
                    ldlocRectLoc = instruction.operand;
                }
                else if (ldlocRectLoc != null && instruction.opcode == OpCodes.Call && instruction.operand is MethodInfo && (MethodInfo)instruction.operand == Refs.m_ButtonInvisible)
                {
                    yield return new CodeInstruction(OpCodes.Ldarg_0);
                    yield return new CodeInstruction(OpCodes.Ldloc_S, ldlocRectLoc);
                    yield return new CodeInstruction(OpCodes.Call, Refs.m_QuickJumpToLocation);
                }

                yield return instruction;
            }
        }
    }
}
