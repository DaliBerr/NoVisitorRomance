using Verse;
using HarmonyLib;

namespace NoVisitorRomance.Startup
{
    [StaticConstructorOnStartup]
    public static class HarmonyInit
    {
        static HarmonyInit()
        {
            var harmony = new Harmony("com.noVisitorRomance");
            harmony.PatchAll();
            // Log.Message("[noVisitorRomance] Harmony patches applied");
        }
    }
}
