using NoVisitorRomance.HarmonyPatches;
using Verse;

Pawn colonist = new() { Faction = new() { IsPlayer = true } };
Pawn visitor = new() { Faction = new() { IsPlayer = false } };
Pawn factionless = new();
(string Name, Pawn Initiator, Pawn Recipient, float Expected)[] cases =
{
    ("visitor to colonist", visitor, colonist, 0f),
    ("factionless visitor to colonist", factionless, colonist, 0f),
    ("colonist to colonist", colonist, colonist, 0.6f),
    ("colonist to visitor retains existing scope", colonist, visitor, 0.6f),
    ("visitor to visitor", visitor, visitor, 0.6f),
    ("visitor to factionless recipient", visitor, factionless, 0.6f),
    ("factionless to factionless", factionless, factionless, 0.6f),
    ("null initiator", null, colonist, 0.6f),
    ("null recipient", visitor, null, 0.6f),
    ("both null", null, null, 0.6f)
};
foreach (var test in cases)
{
    float result = 0.6f;
    Postfix_SuccessChance.SuccessChance_Postfix(ref result, test.Initiator, test.Recipient);
    if (result != test.Expected) throw new Exception($"Failed: {test.Name}");
}
Console.WriteLine($"PASS: {cases.Length} production-patch regressions.");

// Minimal engine/attribute doubles; the actual production postfix is linked
// above. These tests exercise its behavior without starting a RimWorld game.
namespace Verse
{
    public class Pawn { public Faction Faction; }
    public class Faction { public bool IsPlayer; }
}
namespace RimWorld { public class InteractionWorker_RomanceAttempt { } }
namespace HarmonyLib
{
    public class HarmonyPatch : Attribute { public HarmonyPatch(Type type, string method) { } }
    public class HarmonyPostfix : Attribute { }
    public class HarmonyPriority : Attribute { public HarmonyPriority(int priority) { } }
}
