using HarmonyLib;
using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Verse;

namespace MechPsyControlRange_Hydroxyapatite.Patches.Biotech
{
    [HarmonyPatch(
        typeof(Pawn_MechanitorTracker), 
        nameof(Pawn_MechanitorTracker.DrawCommandRadius))]
    internal class PatchMechanitorTracker_DrawCommandRadius
    {
        static bool Prefix(
            Pawn_MechanitorTracker __instance
            )
        {
            if (__instance.Pawn.Spawned && __instance.AnySelectedDraftedMechs)
            {
                float psySens = __instance.Pawn.GetStatValue(StatDefOf.PsychicSensitivity, applyPostProcess: true, 1);
                float defaultRange = 24.9f;
                float range = Math.Min(psySens * defaultRange, (float) Math.Floor(GenRadial.MaxRadialPatternRadius));
                GenDraw.DrawRadiusRing(__instance.Pawn.Position, range, Color.white, (IntVec3 c) => __instance.CanCommandTo(c));
            }
            return false;
        }
    }
}
