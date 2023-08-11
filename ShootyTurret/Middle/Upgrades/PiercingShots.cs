
using BTD_Mod_Helper.Api.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using Il2CppAssets.Scripts.Models.Towers;
using static UpgradableShootyTurret.UpgradableShootyTurret;
using BTD_Mod_Helper.Extensions;

public class PiercingShots : ModUpgrade<UpgradableShootyTurretModTower>
{
    public override string Name => "PiercingShots";
    public override string DisplayName => "Piercing Shots";
    public override string Description => "Geraldo gave a sharpened the Shooty Turrets arrows so the Shooty Turret now has more pierce.";
    public override int Cost => 250;
    public override int Path => MIDDLE;
    public override int Tier => 1;
    public override void ApplyUpgrade(TowerModel towerModel)
    {
        AttackModel attackModel = towerModel.GetBehavior<AttackModel>();
        attackModel.weapons[0].projectile.pierce += 2;
    }
    public override string Portrait => "6dc10060b4cb6174992724ee4ff00d95";
}