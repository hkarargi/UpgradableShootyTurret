
using BTD_Mod_Helper.Api.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using Il2CppAssets.Scripts.Models.Towers;
using static UpgradableShootyTurret.UpgradableShootyTurret;
using BTD_Mod_Helper.Extensions;

public class SharperArrows : ModUpgrade<UpgradableShootyTurretModTower>
{
    public override string Name => "SharperArrows";
    public override string DisplayName => "Sharper Arrows";
    public override string Description => "The Alchemist gave the shooty turret a potion to make his arrows sharper and deal more damage.";
    public override int Cost => 500;
    public override int Path => MIDDLE;
    public override int Tier => 2;
    public override void ApplyUpgrade(TowerModel towerModel)
    {
        AttackModel attackModel = towerModel.GetBehavior<AttackModel>();
        attackModel.weapons[0].projectile.GetDamageModel().damage += 4;
        attackModel.weapons[0].projectile.pierce += 2;
    }
    public override string Portrait => "ShootyTurretIcon";
}