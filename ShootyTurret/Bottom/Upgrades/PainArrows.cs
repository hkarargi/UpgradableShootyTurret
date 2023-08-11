
using BTD_Mod_Helper.Api.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Models.Towers;
using static UpgradableShootyTurret.UpgradableShootyTurret;
using BTD_Mod_Helper.Extensions;

public class PainArrows : ModUpgrade<UpgradableShootyTurretModTower>
{
    public override string Name => "PainArrows";
    public override string DisplayName => "Pain Arrows";
    public override string Description => "Arrows deal more damage and are faster!";
    public override int Cost => 750;
    public override int Path => BOTTOM;
    public override int Tier => 1;
    public override void ApplyUpgrade(TowerModel towerModel)
    {
        AttackModel attackModel = towerModel.GetBehavior<AttackModel>();
        attackModel.weapons[0].projectile.GetDamageModel().damage += 4;
        attackModel.weapons[0].projectile.GetBehavior<TravelStraitModel>().Speed *= 1.5f;
    }
    public override string Portrait => "6dc10060b4cb6174992724ee4ff00d95";
}