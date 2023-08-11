using BTD_Mod_Helper.Api.Towers;
using Il2CppAssets.Scripts.Models.GenericBehaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using Il2CppAssets.Scripts.Models.Towers;
using static UpgradableShootyTurret.UpgradableShootyTurret;
using BTD_Mod_Helper.Extensions;

public class UtterDeletion : ModUpgrade<UpgradableShootyTurretModTower>
{
    public override string Name => "UtterDeletion";
    public override string DisplayName => "UtterDeletion";
    public override string Description => "THE BLOONS ARE NO MORE.";
    public override int Cost => 250000;
    public override int Path => BOTTOM;
    public override int Tier => 5;
    public override void ApplyUpgrade(TowerModel towerModel)
    {
        AttackModel attackModel = towerModel.GetBehavior<AttackModel>();
        towerModel.displayScale *= 1.5f;
        towerModel.GetBehavior<DisplayModel>().scale *= 1.5f;
        attackModel.weapons[0].projectile.scale *= 1.5f;
        attackModel.weapons[0].projectile.GetBehavior<DisplayModel>().scale *= 1.25f;
        attackModel.weapons[0].projectile.GetDamageModel().damage = 10000;
        attackModel.weapons[0].projectile.pierce = 9999999999;
        attackModel.weapons[0].Rate = 0.5f;
        attackModel.range *= 1.5f;
        towerModel.range *= 1.5f;
    }
    public override string Portrait => "6dc10060b4cb6174992724ee4ff00d95";
}