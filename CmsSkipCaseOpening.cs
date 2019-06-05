using UnityEngine;
using Harmony12;
using System.Reflection;
using UnityModManagerNet;

namespace CmsSkipCaseOpening
{
    public static class CmsSkipCaseOpening
    {
        public static UnityModManager.ModEntry ModEntry;

        public static bool Load(UnityModManager.ModEntry modEntry)
        {
            ModEntry = modEntry;

            HarmonyInstance.Create(modEntry.Info.Id).PatchAll(Assembly.GetExecutingAssembly());

            return true;
        }
    }

    [HarmonyPatch(typeof(CaseOpening))]
    [HarmonyPatch("Prepare")]
    public class CaseOpeningPreparePatcher
    {
        [HarmonyPrefix]
        public static void Prefix(CaseOpening __instance)
        {
            __instance.GetComponent<Animator>().speed = 10;
        }
    }
}
