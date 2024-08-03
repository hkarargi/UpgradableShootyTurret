
using BTD_Mod_Helper.Api.Towers;
using Il2Cpp;
using Il2CppAssets.Scripts.Models.GenericBehaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using Il2CppAssets.Scripts.Models.Towers.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Unity;
using static UpgradableShootyTurret.UpgradableShootyTurret;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Utils;
using System.Linq;
using Il2CppNinjaKiwi.Common.ResourceUtils;

public class ExplosiveArrows : ModUpgrade<UpgradableShootyTurretModTower>
{
    public override string Name => "ExplosiveArrows";
    public override string DisplayName => "Explosive Arrows";
    public override string Description => "Someone accidently spilled gunpowder on the Shooty Turret's arrows! Now they explode on contact with bloons and also all bloon types even black and camo bloons!";
    public override int Cost => 1500;
    public override int Path => MIDDLE;
    public override int Tier => 3;
    public override void ApplyUpgrade(TowerModel towerModel)
    {
        AttackModel attackModel = towerModel.GetBehavior<AttackModel>(); ;
        var bomb = Game.instance.model.GetTowerFromId(TowerType.BombShooter).GetWeapon()
            .projectile.Duplicate();
        var pb = bomb.GetBehavior<CreateProjectileOnContactModel>();
        var sound = bomb.GetBehavior<CreateSoundOnProjectileCollisionModel>();
        var effect = bomb.GetBehavior<CreateEffectOnContactModel>();

        var behavior = new CreateProjectileOnContactModel(
            "CreateProjectileOnExhaustFractionModel_ExplosiveArrows",
            pb.projectile, pb.emission, false, false, false);
        attackModel.weapons[0].projectile.AddBehavior(behavior);

        var soundBehavior = new CreateSoundOnProjectileCollisionModel(
            "CreateSoundOnProjectileExhaustModel_ExplosiveArrows",
            sound.sound1, sound.sound2, sound.sound3, sound.sound4, sound.sound5);
        attackModel.weapons[0].projectile.AddBehavior(soundBehavior);

        var ceoc = new CreateEffectOnContactModel("CreateEffectOnContactModel_ExplosiveArrows", effect.effectModel);
        attackModel.weapons[0].projectile.AddBehavior(ceoc);
        attackModel.weapons[0].projectile.GetDamageModel().damage += 6;
        attackModel.weapons[0].projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
        towerModel.AddBehavior(new OverrideCamoDetectionModel("OverrideCamoDetectionModel_", true));
        towerModel.display = new PrefabReference() { guidRef = "26a654b46fa1fa6498a4a6e40c93a406" };
        towerModel.GetBehavior<DisplayModel>().display = new PrefabReference() { guidRef = "26a654b46fa1fa6498a4a6e40c93a406" };
        towerModel.GetBehavior<DisplayModel>().ignoreRotation = false;
        if (towerModel.tiers[0] < 3)
        {
            towerModel.RemoveBehavior(towerModel.behaviors.First(a => a.name == "DisplayModel_UST_Top"));
        }
    }
    public override string Portrait => "ShootyTurretIcon";
}