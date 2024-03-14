using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.GenericBehaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Projectiles;
using Il2CppAssets.Scripts.Models.Towers;
using static UpgradableShootyTurret.UpgradableShootyTurret;
using Il2CppAssets.Scripts.Utils;

public class Megapult : ModUpgrade<UpgradableShootyTurretModTower>
{
    public override string Name => "Megapult";
    public override string DisplayName => "Megapult";
    public override string Description => "Each projectile clusters into 2 projectiles.";
    public override int Cost => 500000;
    public override int Path => TOP;
    public override int Tier => 5;
    public override void ApplyUpgrade(TowerModel towerModel)
    {
        AttackModel attackModel = towerModel.GetBehavior<AttackModel>();
        attackModel.weapons[0].projectile.display = new PrefabReference() { guidRef = "c4b8e7aa3e07d764fb9c3c773ceec2ab" };
        towerModel.display = new PrefabReference() { guidRef = "b194c58ed09f1aa468e935b453c6843c" };
        attackModel.weapons[0].projectile.GetDamageModel().damage = 1000;
        towerModel.GetBehavior<DisplayModel>().display = new PrefabReference() { guidRef = "b194c58ed09f1aa468e935b453c6843c" };
        attackModel.weapons[0].projectile.AddBehavior<CreateProjectileOnContactModel>(new CreateProjectileOnContactModel("CreateProjectileOnContactModel_Megapult", ModelExt.Duplicate<ProjectileModel>(attackModel.weapons[0].projectile), new ArcEmissionModel("ArcEmissionModel_Megapult", 2, 0f, 0f, null, true, true), false, false, true));
    }
    public override string Portrait => "ShootyTurretIcon";
}