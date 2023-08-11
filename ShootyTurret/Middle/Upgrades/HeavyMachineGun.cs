using BTD_Mod_Helper.Api.Towers;
using Il2CppAssets.Scripts.Models.GenericBehaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Models.Towers;
using static UpgradableShootyTurret.UpgradableShootyTurret;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Utils;

public class HeavyMachineGun : ModUpgrade<UpgradableShootyTurretModTower>
{
    public override string Name => "HeavyMachineGun";
    public override string DisplayName => "Heavy Machine Gun";
    public override string Description => "The Shooty Turret was installed with a bigger and better machine gun that has infinite range!";
    public override int Cost => 250000;
    public override int Path => MIDDLE;
    public override int Tier => 5;
    public override void ApplyUpgrade(TowerModel towerModel)
    {
        AttackModel attackModel = towerModel.GetBehavior<AttackModel>();
        towerModel.display = new PrefabReference() { guidRef = "1001186d3e8034b45929adb7ab6f048e" };
        towerModel.GetBehavior<DisplayModel>().display = new PrefabReference() { guidRef = "1001186d3e8034b45929adb7ab6f048e" };
        towerModel.GetAbility().name = "Heavy Machine Gun";
        towerModel.GetAbility().GetBehavior<TurboModel>().multiplier = 0.0625f;
        towerModel.GetAbility().GetBehavior<TurboModel>().extraDamage = 10;
        towerModel.GetAbility().GetBehavior<TurboModel>().Lifespan = 20;
        attackModel.weapons[0].Rate *= 0.25f;
        attackModel.range = 9999999999;
        towerModel.range = 10;
        attackModel.weapons[0].projectile.GetDamageModel().damage = 50;
        attackModel.weapons[0].projectile.GetBehavior<TravelStraitModel>().Speed *= 1.75f;
    }
    public override string Portrait => "6dc10060b4cb6174992724ee4ff00d95";
}