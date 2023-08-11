using MelonLoader;
using Il2CppAssets.Scripts.Simulation.Towers;
using Il2CppAssets.Scripts.Unity;

[assembly: MelonInfo(typeof(UpgradableShootyTurret.UpgradableShootyTurret), UpgradableShootyTurret.ModHelperData.Name, UpgradableShootyTurret.ModHelperData.Version, UpgradableShootyTurret.ModHelperData.RepoOwner)]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]

namespace UpgradableShootyTurret
{
    internal class PutTowersInShop
    {
        [HarmonyLib.HarmonyPatch(typeof(Tower), nameof(Tower.Initialise))]
        private static class Tower_Initialise
        {
            [HarmonyLib.HarmonyPostfix]
            private static void Postfix(Tower __instance)
            {
                //UpgradableShootyTurret-UpgradableShootyTurret
                if (__instance.towerModel.baseId == "ShootyTurret" || __instance.towerModel.baseId == "ShootyTurretV2")
                {
                    __instance.UpdateRootModel(Game.instance.model
                        .GetTowerFromId("UpgradableShootyTurret-UpgradableShootyTurret"));
                }
            }
        }

        /*[HarmonyLib.HarmonyPatch(typeof(ShopMenu), nameof(ShopMenu.Initialise))]
        private static class ShopMenu_Initialise
        {
            [HarmonyLib.HarmonyPostfix]
            private static void Postfix(ShopMenu __instance)
            {
                MelonLogger.Msg("no");
                MelonLogger.Msg(__instance.towerButtonPrefab);
                MelonLogger.Msg(__instance.GetTowerButtonFromBaseId("DartMonkey"));
            }
        }*/
    }
}
