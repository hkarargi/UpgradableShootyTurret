using System.Linq;
using Il2CppAssets.Scripts.Models.GenericBehaviors;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using Il2CppAssets.Scripts.Utils;
using MelonLoader;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers.Projectiles;
using BTD_Mod_Helper;
using BTD_Mod_Helper.Api.Towers;
using Il2Cpp;

namespace UpgradableShootyTurret
{
    public class GenieBottle : BloonsTD6Mod
    {
        //https://github.com/gurrenm3/BloonsTD6-Mod-Helper/releases

        public class GenieBottleModTower : ModTower
        {
            public override string Name => "GenieBottle";
            public override string DisplayName => "Upgradable Genie Bottle";
            public override string Description => "This is Geraldo's Genie Bottle but now it is upgradable!";
            public override string BaseTower => "MonkeyAce";
            public override int Cost => 2000;
            public override int TopPathUpgrades => 0;
            public override int MiddlePathUpgrades => 0;
            public override int BottomPathUpgrades => 0;
            public override Il2CppAssets.Scripts.Models.TowerSets.TowerSet TowerSet => Il2CppAssets.Scripts.Models.TowerSets.TowerSet.Magic;
            public override void ModifyBaseTowerModel(TowerModel towerModel)
            {
                towerModel.RemoveBehavior<RectangleFootprintModel>();
                towerModel.footprint = new CircleFootprintModel("CircleFootprintModel_", 1f, false, false, false);
                towerModel.radius = 3f;
                towerModel.radiusSquared = 9f;
                towerModel.display = new PrefabReference() { guidRef = "323d12e1edad69b4e8ceabef67e8f744" };
                towerModel.GetBehavior<DisplayModel>().display = new PrefabReference() { guidRef = "323d12e1edad69b4e8ceabef67e8f744" };
                towerModel.GetBehavior<AirUnitModel>().display = new PrefabReference() { guidRef = "056161787db48454a943cbc7384bbfb7" };
            }
        }
    }
}
