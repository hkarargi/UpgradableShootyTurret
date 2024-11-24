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
using Il2CppAssets.Scripts.Simulation.Towers.Behaviors;
using Il2CppNinjaKiwi.Common.ResourceUtils;

namespace UpgradableShootyTurret
{
    public class UpgradableShootyTurret : BloonsTD6Mod
    {
        //https://github.com/gurrenm3/BloonsTD6-Mod-Helper/releases

        public class UpgradableShootyTurretModTower : ModTower
        {
            public override string Name => "UpgradableShootyTurret";
            public override string DisplayName => "Upgradable Shooty Turret";
            public override string Description => "This is Geraldo's Shooty Turret but now it is upgradable!";
            public override string BaseTower => "DartMonkey";
            public override int Cost => 500;
            public override int TopPathUpgrades => 5;
            public override int MiddlePathUpgrades => 5;
            public override int BottomPathUpgrades => 5;
            public override Il2CppAssets.Scripts.Models.TowerSets.TowerSet TowerSet => Il2CppAssets.Scripts.Models.TowerSets.TowerSet.Support;
            public override void ModifyBaseTowerModel(TowerModel towerModel)
            {
                //stuff
                towerModel.GetBehavior<DisplayModel>().ignoreRotation = true;
                towerModel.AddBehavior(new DisplayModel("DisplayModel_UST_Top", new PrefabReference() { guidRef = "6a8505a5c8dd849489c750e3b65047dc" }, 0, default, default, 1, false, 0));
                var attackModel = towerModel.GetBehavior<AttackModel>();
                attackModel.weapons[0].projectile.GetBehavior<TravelStraitModel>().Lifespan = 4;
                attackModel.weapons[0].projectile.display = new PrefabReference() { guidRef = "e57060793f03d3046a9f97b8cb24986a" };

                //pierce, damage, and range
                attackModel.weapons[0].projectile.pierce = 10;
                attackModel.weapons[0].projectile.GetDamageModel().damage = 2;
                attackModel.range = 50;
                towerModel.range = 50;

                //how many seconds until it shoots
                attackModel.weapons[0].Rate = 1.5f;

                //makes tower look like shooty turret.
                towerModel.display = new PrefabReference() { guidRef = "c834b6ab8cd5afc429065acb83992abb" };
                towerModel.GetBehavior<DisplayModel>().display = new PrefabReference() { guidRef = "c834b6ab8cd5afc429065acb83992abb" };
                towerModel.radius = 3f;
                towerModel.radiusSquared = 9f;
                towerModel.footprint = new CircleFootprintModel("CircleFootprintModel_Circle",3f,false,false,false);
            }
            public override bool IsValidCrosspath(int[] tiers) =>
            ModHelper.HasMod("UltimateCrosspathing") || base.IsValidCrosspath(tiers);
            public override string Icon => "ShootyTurretIcon";
            public override string Portrait => "ShootyTurretIcon";
        }
    }
}
