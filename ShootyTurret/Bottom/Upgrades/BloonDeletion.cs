
using BTD_Mod_Helper.Api.Towers;
using Il2CppAssets.Scripts.Models.GenericBehaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using Il2CppAssets.Scripts.Models.Towers.Behaviors;
using Il2CppAssets.Scripts.Models.Towers;
using static UpgradableShootyTurret.UpgradableShootyTurret;
using BTD_Mod_Helper.Extensions;

public class BloonDeletion : ModUpgrade<UpgradableShootyTurretModTower>
{
    public override string Name => "BloonDeletion";
    public override string DisplayName => "Bloon Deletion";
    public override string Description => "The Shooty turret now shoots faster and deals alot more damage with way more pierce and the ability to pop camo.";
    public override int Cost => 25000;
    public override int Path => BOTTOM;
    public override int Tier => 4;
    public override void ApplyUpgrade(TowerModel towerModel)
    {
        AttackModel attackModel = towerModel.GetBehavior<AttackModel>();
        towerModel.displayScale *= 1.25f;
        towerModel.GetBehavior<DisplayModel>().scale *= 1.25f;
        attackModel.weapons[0].projectile.scale *= 1.25f;
        attackModel.range *= 1.25f;
        towerModel.range *= 1.25f;
        attackModel.weapons[0].projectile.GetBehavior<DisplayModel>().scale *= 1.25f;
        attackModel.weapons[0].projectile.GetDamageModel().damage += 100;
        attackModel.weapons[0].projectile.pierce += 100;
        attackModel.weapons[0].Rate *= 0.75f;
        towerModel.AddBehavior(new OverrideCamoDetectionModel("OverrideCamoDetectionModel_", true));
    }
    public override string Portrait => "ShootyTurretIcon";
}