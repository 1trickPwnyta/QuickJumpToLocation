using HarmonyLib;
using System.Reflection;
using UnityEngine;
using Verse;

namespace QuickJumpToLocation
{
    public static class Refs
    {
        public static ConstructorInfo c_Rect = AccessTools.Constructor(typeof(Rect), new[] { typeof(float), typeof(float), typeof(float), typeof(float) });
        public static MethodInfo m_ButtonInvisible = SymbolExtensions.GetMethodInfo(() => Widgets.ButtonInvisible(Rect.zero, false));
        public static MethodInfo m_QuickJumpToLocation = SymbolExtensions.GetMethodInfo(() => Tools.QuickJumpToLocation(null, Rect.zero));
    }
}
