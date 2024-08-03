
using BTD_Mod_Helper.Api.Towers;
using Il2CppAssets.Scripts.Models.GenericBehaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Unity;
using static UpgradableShootyTurret.UpgradableShootyTurret;
using BTD_Mod_Helper.Extensions;
using System.Linq;
using Il2CppAssets.Scripts.Utils;
using Il2CppNinjaKiwi.Common.ResourceUtils;

public class HomingArrows : ModUpgrade<UpgradableShootyTurretModTower>
{
    public override string Name => "HomingArrows";
    public override string DisplayName => "Homing Arrows";
    public override string Description => "Arrows now follow bloons and are larger.";
    public override int Cost => 3000;
    public override int Path => BOTTOM;
    public override int Tier => 3;
    public override void ApplyUpgrade(TowerModel towerModel)
    {
        AttackModel attackModel = towerModel.GetBehavior<AttackModel>();
        towerModel.displayScale *= 1.25f;
        towerModel.GetBehavior<DisplayModel>().scale *= 1.25f;
        attackModel.weapons[0].projectile.scale *= 1.25f;
        attackModel.weapons[0].projectile.GetBehavior<DisplayModel>().scale *= 1.25f;
        attackModel.range *= 1.25f;
        towerModel.range *= 1.25f;
        var homing = Game.instance.model.GetTowerFromId("NinjaMonkey-001").GetWeapon().projectile
            .GetBehavior<TrackTargetWithinTimeModel>().Duplicate();
        attackModel.weapons[0].projectile.AddBehavior(homing);
        attackModel.weapons[0].projectile.GetDamageModel().damage += 6;
        attackModel.weapons[0].Rate *= 0.5f;
        if (towerModel.tiers[0] < 3 && towerModel.tiers[1] < 3)
        {
            towerModel.GetBehaviors<DisplayModel>().First(a => a.name == "DisplayModel_UST_Top").display = new PrefabReference() { guidRef = "3b7505fd21be1fe42ad9b627219c2e43" };
        }
        attackModel.weapons[0].projectile.pierce += 2;
    }
    public override string Portrait => "ShootyTurretIcon";
}