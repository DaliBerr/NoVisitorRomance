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
            if (initiator == null || recipient == null) return;

            // A factionless visitor is still an outsider. Neither participant
            // is guaranteed to have a faction (for example, a wild person).
            if (initiator.Faction?.IsPlayer != true && recipient.Faction?.IsPlayer == true)
                __result = 0f;
        }
    }
}
