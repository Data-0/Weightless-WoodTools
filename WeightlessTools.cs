using HarmonyLib;
using Il2Cpp;
using Il2CppSystem.Buffers;
using Il2CppTLD.IntBackedUnit;
using MelonLoader;

namespace WeightlessWoodTools
{

    public class WeightlessTool : MelonMod
    {
        [HarmonyPatch(typeof(GearItem), nameof(GearItem.Deserialize))]
        public class GearItem_Awake
        {
            public static void Postfix(ref GearItem __instance)
            {
                if (__instance == null) return;
                if (string.IsNullOrWhiteSpace(__instance.name)) return;
                if (__instance.name == "GEAR_WoodworkingTools")
                {
                    Melon<WeightlessTool>.Logger.Msg("Found GEAR_WoodworkingTools");
                    __instance.WeightKG = ItemWeight.FromKilograms(0.01f);
                }
            }
        }
    }
    
}
