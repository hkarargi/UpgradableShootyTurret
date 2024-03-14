
using BTD_Mod_Helper.Api.Towers;
using Il2CppAssets.Scripts.Models.GenericBehaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Unity;
using static UpgradableShootyTurret.UpgradableShootyTurret;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Utils;

public class MachineGun : ModUpgrade<UpgradableShootyTurretModTower>
{
    public override string Name => "MachineGun";
    public override string DisplayName => "Machine Gun";
    public override string Description => "The Shooty Turret has been installed with a gun that can shoot arrows faster than usual! Now it can more easily destroy bloons!";
    public override int Cost => 10000;
    public override int Path => MIDDLE;
    public override int Tier => 4;
    public override void ApplyUpgrade(TowerModel towerModel)
    {
        AttackModel attackModel = towerModel.GetBehavior<AttackModel>();
        towerModel.AddBehavior(Game.instance.model.GetTowerFromId("MortarMonkey-040").GetAbility().Duplicate());
        towerModel.GetAbility().name = "Machine Gun";
        towerModel.GetAbility().GetBehavior<TurboModel>().extraDamage = 2;
        towerModel.GetAbility().GetBehavior<TurboModel>().multiplier = 0.125f;
        towerModel.GetAbility().GetBehavior<TurboModel>().Lifespan = 15;
        towerModel.GetAbility().Cooldown = 30;
        attackModel.weapons[0].Rate *= 0.375f;
        attackModel.weapons[0].projectile.GetBehavior<TravelStraitModel>().Speed *= 1.5f;
        towerModel.display = new PrefabReference() { guidRef = "ea0dfb74811b4774683b38311b64794c" };
        towerModel.GetBehavior<DisplayModel>().display = new PrefabReference() { guidRef = "ea0dfb74811b4774683b38311b64794c" };
        attackModel.range *= 2;
        towerModel.range *= 2;
    }
    public override string Portrait => "ShootyTurretIcon";
}