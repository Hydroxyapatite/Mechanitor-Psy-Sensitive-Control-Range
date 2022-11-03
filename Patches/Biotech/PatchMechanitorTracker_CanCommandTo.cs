using HarmonyLib;
using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace MechPsyControlRange_Hydroxyapatite.Patches.Biotech
{
    [HarmonyPatch(
        typeof(Pawn_MechanitorTracker), 
        nameof(Pawn_MechanitorTracker.CanCommandTo), 
        new Type[] { typeof(LocalTargetInfo) })]
    internal class PatchMechanitorTracker_CanCommandTo
    {
        static void Postfix(
            Pawn_MechanitorTracker __instance,
            LocalTargetInfo target,
            ref bool __result
            )
        {
            if (!target.Cell.InBounds(__instance.Pawn.MapHeld))
            {
                __result = false;
            }
            float defaultRange = 620.01f;
            float psySensSq = (float) Math.Pow(__instance.Pawn.GetStatValue(StatDefOf.PsychicSensitivity, applyPostProcess: true, 1), 2);
            float maxRange = (float) Math.Pow(Math.Floor(GenRadial.MaxRadialPatternRadius), 2);
            float range = Math.Min(defaultRange * psySensSq, maxRange);
            __result = __instance.Pawn.Position.DistanceToSquared(target.Cell) < range;
        }
    }
}