using Verse;
using HarmonyLib;
using RimWorld;
namespace NoVisitorRomance.HarmonyPatches
{
    [HarmonyPatch(typeof(InteractionWorker_RomanceAttempt), "SuccessChance")]

    public static class Postfix_SuccessChance
    {
        [HarmonyPostfix]
        [HarmonyPriority(-100)]
        public static void SuccessChance_Postfix(ref float __result, Pawn initiator, Pawn recipient)
        {
            if (initiator.Faction != null)
            {
                if (!initiator.Faction.IsPlayer && recipient.Faction.IsPlayer)
                {
                    __result = 0f;
                    return;
                }
            }
            else
            {
                if (initiator != null)
                {
                    if (!initiator.Faction.IsPlayer && recipient.Faction.IsPlayer)
                    {
                        __result = 0f;
                        return;
                    }
                }
            }
        }
    }
}