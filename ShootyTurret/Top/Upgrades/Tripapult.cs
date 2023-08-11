using BTD_Mod_Helper.Api.Towers;
using Il2Cpp;
using Il2CppAssets.Scripts.Models.GenericBehaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions;
using Il2CppAssets.Scripts.Models.Towers;
using static UpgradableShootyTurret.UpgradableShootyTurret;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Utils;

public class Tripapult : ModUpgrade<UpgradableShootyTurretModTower>
{
    public override string Name => "Tripapult";
    public override string DisplayName => "Tripapult";
    public override string Description => "Give the catapult 3 shots and can pop any bloon type.";
    public override int Cost => 25000;
    public override int Path => TOP;
    public override int Tier => 4;
    public override void ApplyUpgrade(TowerModel towerModel)
    {
        AttackModel attackModel = towerModel.GetBehavior<AttackModel>();
        attackModel.weapons[0].projectile.display = new PrefabReference() { guidRef = "ee74983d627954e4e9765d86e05b4500" };
        towerModel.display = new PrefabReference() { guidRef = "9a4bf86ce3861a64c9e118a693db992f" };
        towerModel.GetBehavior<DisplayModel>().display = new PrefabReference() { guidRef = "9a4bf86ce3861a64c9e118a693db992f" };
        attackModel.weapons[0].emission = new ArcEmissionModel("ArcEmissionModel_Tripapult", 3, 0f, 15f, null, false, true);
        attackModel.weapons[0].projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
        attackModel.weapons[0].projectile.GetDamageModel().damage += 2;
    }
}