using BTD_Mod_Helper.Api.Towers;
using Il2CppAssets.Scripts.Models.GenericBehaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using Il2CppAssets.Scripts.Models.Towers;
using static UpgradableShootyTurret.UpgradableShootyTurret;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Utils;
using System.Linq;
using Il2CppNinjaKiwi.Common.ResourceUtils;

public class Catapult : ModUpgrade<UpgradableShootyTurretModTower>
{
    public override string Name => "Catapult";
    public override string DisplayName => "Catapult";
    public override string Description => "The Shooty Turret becomes a catapult that has more pierce and damage";
    public override int Cost => 1000;
    public override int Path => TOP;
    public override int Tier => 3;
    public override void ApplyUpgrade(TowerModel towerModel)
    {
        AttackModel attackModel = towerModel.GetBehavior<AttackModel>();
        attackModel.weapons[0].projectile.display = new PrefabReference() { guidRef = "fcddee8a92f5d2e4d8605a8924566620" };
        towerModel.display = new PrefabReference() { guidRef = "1f72b507ec539e84c84e25011d855974" };
        towerModel.GetBehavior<DisplayModel>().display = new PrefabReference() { guidRef = "1f72b507ec539e84c84e25011d855974" };
        towerModel.GetBehavior<DisplayModel>().ignoreRotation = false;
        towerModel.RemoveBehavior(towerModel.behaviors.First(a => a.name == "DisplayModel_UST_Top"));
        attackModel.weapons[0].projectile.GetDamageModel().damage += 3;
        attackModel.weapons[0].projectile.pierce += 5;
    }
    public override string Portrait => "ShootyTurretIcon";
}
