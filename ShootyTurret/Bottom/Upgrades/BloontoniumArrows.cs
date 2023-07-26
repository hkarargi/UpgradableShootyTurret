
using BTD_Mod_Helper.Api.Towers;
using Il2Cpp;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using Il2CppAssets.Scripts.Models.Towers;
using static UpgradableShootyTurret.UpgradableShootyTurret;
using BTD_Mod_Helper.Extensions;

public class BloontoniumArrows : ModUpgrade<UpgradableShootyTurretModTower>
{
    public override string Name => "BloontoniumArrows";
    public override string DisplayName => "Bloontonium Arrows";
    public override string Description => "Arrows deal more damage now can pop lead!";
    public override int Cost => 1500;
    public override int Path => BOTTOM;
    public override int Tier => 2;
    public override void ApplyUpgrade(TowerModel towerModel)
    {
        AttackModel attackModel = towerModel.GetBehavior<AttackModel>();
        attackModel.weapons[0].projectile.GetDamageModel().damage += 4;
        attackModel.weapons[0].projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
    }
    public override string Portrait => "ShootyTurretIcon";
}