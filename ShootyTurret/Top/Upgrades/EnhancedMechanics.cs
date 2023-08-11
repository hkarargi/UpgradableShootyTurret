using BTD_Mod_Helper.Api.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using Il2CppAssets.Scripts.Models.Towers.Behaviors;
using Il2CppAssets.Scripts.Models.Towers;
using static UpgradableShootyTurret.UpgradableShootyTurret;
using BTD_Mod_Helper.Extensions;

public class EnhancedMechanics : ModUpgrade<UpgradableShootyTurretModTower>
{
    public override string Name => "EnhancedMechanics";
    public override string DisplayName => "Enhanced Mechanics";
    public override string Description => "Arrows do more damage and the Shooty Turret shoots them faster and can pop camo bloons!";
    public override int Cost => 1000;
    public override int Path => TOP;
    public override int Tier => 2;
    public override void ApplyUpgrade(TowerModel towerModel)
    {
        AttackModel attackModel = towerModel.GetBehavior<AttackModel>();
        attackModel.weapons[0].Rate *= 0.7f;
        attackModel.weapons[0].projectile.GetDamageModel().damage += 2;
        towerModel.AddBehavior(new OverrideCamoDetectionModel("OverrideCamoDetectionModel_", true));
    }
    public override string Portrait => "6dc10060b4cb6174992724ee4ff00d95";
}