using HarmonyLib;
using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace MechPsyControlRange_Hydroxyapatite
{
    [StaticConstructorOnStartup]
    public static class Main
    {
        static Main()
        {
            var harmony = new Harmony("rimworld.hydroxyapatite.MechPsyControlRange");
            harmony.PatchAll();
        }
    }
}