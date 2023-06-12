using System.Linq;
using Il2CppAssets.Scripts.Models.GenericBehaviors;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using Il2CppAssets.Scripts.Utils;
using MelonLoader;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers.Projectiles;
using BTD_Mod_Helper;
using BTD_Mod_Helper.Api.Towers;
using Il2Cpp;

[assembly: MelonInfo(typeof(UpgradableShootyTurret.Main), UpgradableShootyTurret.ModHelperData.Name, UpgradableShootyTurret.ModHelperData.Version, UpgradableShootyTurret.ModHelperData.RepoOwner)]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]
namespace UpgradableShootyTurret
{

    public class Main : BloonsTD6Mod
    {
        //https://github.com/gurrenm3/BloonsTD6-Mod-Helper/releases

        public class UpgradableShootyTurret : ModTower
        {
            public override string Name => "UpgradableShootyTurret";
            public override string DisplayName => "Upgradable Shooty Turret";
            public override string Description => "This is Geraldo's Shooty Turret but now it is upgradable!";
            public override string BaseTower => "DartMonkey";
            public override int Cost => 500;
            public override int TopPathUpgrades => 5;
            public override int MiddlePathUpgrades => 5;
            public override int BottomPathUpgrades => 5;
            public override Il2CppAssets.Scripts.Models.TowerSets.TowerSet TowerSet => Il2CppAssets.Scripts.Models.TowerSets.TowerSet.Support;
            public override void ModifyBaseTowerModel(TowerModel towerModel)
            {
                //stuff
                towerModel.GetBehavior<DisplayModel>().ignoreRotation = true;
                towerModel.AddBehavior(new DisplayModel("DisplayModel_UST_Top", new PrefabReference() { guidRef = "6a8505a5c8dd849489c750e3b65047dc" }, 0, default, default, 1, false, 0));
                var attackModel = towerModel.GetBehavior<AttackModel>();
                attackModel.weapons[0].projectile.GetBehavior<TravelStraitModel>().Lifespan = 4;
                attackModel.weapons[0].projectile.display = new PrefabReference() { guidRef = "e57060793f03d3046a9f97b8cb24986a" };

                //pierce, damage, and range
                attackModel.weapons[0].projectile.pierce = 10;
                attackModel.weapons[0].projectile.GetDamageModel().damage = 2;
                attackModel.range = 50;
                towerModel.range = 50;

                //how many seconds until it shoots
                attackModel.weapons[0].Rate = 1.5f;

                //makes tower look like shooty turret.
                towerModel.display = new PrefabReference() { guidRef = "c834b6ab8cd5afc429065acb83992abb" };
                towerModel.GetBehavior<DisplayModel>().display = new PrefabReference() { guidRef = "c834b6ab8cd5afc429065acb83992abb" };
            }
            public override bool IsValidCrosspath(int[] tiers) =>
            ModHelper.HasMod("UltimateCrosspathing") || base.IsValidCrosspath(tiers);
            public override string Icon => "Icon";
            public override string Portrait => "Icon";
        }
        public class FasterMechanisms : ModUpgrade<UpgradableShootyTurret>
        {
            public override string Name => "FasterMechanisms";
            public override string DisplayName => "Faster Mechanisms";
            public override string Description => "Shooty Turrets shoot faster!";
            public override int Cost => 250;
            public override int Path => TOP;
            public override int Tier => 1;
            public override void ApplyUpgrade(TowerModel towerModel)
            {
                AttackModel attackModel = towerModel.GetBehavior<AttackModel>();
                attackModel.weapons[0].Rate *= 0.8f;
            }
            public override string Portrait => "Icon";
        }
        public class EnhancedMechanisms : ModUpgrade<UpgradableShootyTurret>
        {
            public override string Name => "EnhancedMechanisms";
            public override string DisplayName => "Enhanced Mechanisms";
            public override string Description => "Arrows do more damage and the Shooty Turret shoots them faster and can pop camo bloons!";
            public override int Cost => 500;
            public override int Path => TOP;
            public override int Tier => 2;
            public override void ApplyUpgrade(TowerModel towerModel)
            {
                AttackModel attackModel = towerModel.GetBehavior<AttackModel>();
                attackModel.weapons[0].Rate *= 0.7f;
                attackModel.weapons[0].projectile.GetDamageModel().damage += 2;
                towerModel.AddBehavior(new OverrideCamoDetectionModel("OverrideCamoDetectionModel_", true));
            }
            public override string Portrait => "Icon";
        }
        public class Catapult : ModUpgrade<UpgradableShootyTurret>
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
            public override string Portrait => "Icon";
        }
        
        public class Tripapult : ModUpgrade<UpgradableShootyTurret>
        {
            public override string Name => "Tripapult";
            public override string DisplayName => "Tripapult";
            public override string Description => "Give the catapult 3 shots and can pop any bloon type.";
            public override int Cost => 5000;
            public override int Path => TOP;
            public override int Tier => 4;
            public override void ApplyUpgrade(TowerModel towerModel)
            {
                AttackModel attackModel = towerModel.GetBehavior<AttackModel>();
                attackModel.weapons[0].projectile.display = new PrefabReference() { guidRef = "ee74983d627954e4e9765d86e05b4500" };
                towerModel.display = new PrefabReference() { guidRef = "9a4bf86ce3861a64c9e118a693db992f" };
                towerModel.GetBehavior<DisplayModel>().display = new PrefabReference() { guidRef = "9a4bf86ce3861a64c9e118a693db992f" };
                attackModel.weapons[0].emission = new ArcEmissionModel("ArcEmissionModel_Tripapult", 3, 0f, 15f, null, false,true);
                attackModel.weapons[0].projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
                attackModel.weapons[0].projectile.GetDamageModel().damage += 2;
            }
            public override string Portrait => "Icon";
        }
        public class Megapult : ModUpgrade<UpgradableShootyTurret>
        {
            public override string Name => "Megapult";
            public override string DisplayName => "Megapult";
            public override string Description => "Each projectile clusters into 2 projectiles.";
            public override int Cost => 27500;
            public override int Path => TOP;
            public override int Tier => 5;
            public override void ApplyUpgrade(TowerModel towerModel)
            {
                AttackModel attackModel = towerModel.GetBehavior<AttackModel>();
                attackModel.weapons[0].projectile.display = new PrefabReference() { guidRef = "c4b8e7aa3e07d764fb9c3c773ceec2ab" };
                towerModel.display = new PrefabReference() { guidRef = "b194c58ed09f1aa468e935b453c6843c" };
                towerModel.GetBehavior<DisplayModel>().display = new PrefabReference() { guidRef = "b194c58ed09f1aa468e935b453c6843c" };
                attackModel.weapons[0].projectile.AddBehavior<CreateProjectileOnContactModel>(new CreateProjectileOnContactModel("CreateProjectileOnContactModel_Megapult", ModelExt.Duplicate<ProjectileModel>(attackModel.weapons[0].projectile), new ArcEmissionModel("ArcEmissionModel_Megapult", 2, 0f, 0f, null, true, true), false, false, true));
                if (InGame.Bridge.GetCurrentRound() > 80)
                {
                    attackModel.weapons[0].projectile.GetDamageModel().damage *= (InGame.Bridge.GetCurrentRound() / 50);
                }
            }
            public override string Portrait => "Icon";
        }
        public class PiercingShots : ModUpgrade<UpgradableShootyTurret>
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
            public override string Portrait => "Icon";
        }
        public class SharperArrows : ModUpgrade<UpgradableShootyTurret>
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
            public override string Portrait => "Icon";
        }
        public class ExplosiveArrows : ModUpgrade<UpgradableShootyTurret>
        {
            public override string Name => "ExplosiveArrows";
            public override string DisplayName => "Explosive Arrows";
            public override string Description => "Someone accidently spilled gunpowder on the Shooty Turret's arrows! Now they explode on contact with bloons and also all bloon types even black and camo bloons!";
            public override int Cost => 1500;
            public override int Path => MIDDLE;
            public override int Tier => 3;
            public override void ApplyUpgrade(TowerModel towerModel)
            {
                AttackModel attackModel = towerModel.GetBehavior<AttackModel>();;
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
            public override string Portrait => "Icon";
        }
        public class MachineGun : ModUpgrade<UpgradableShootyTurret>
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
            public override string Portrait => "Icon";
        }
    }
    public class HeavyMachineGun : ModUpgrade<UpgradableShootyTurret.Main.UpgradableShootyTurret>
    {
        public override string Name => "HeavyMachineGun";
        public override string DisplayName => "Heavy Machine Gun";
        public override string Description => "The Shooty Turret was installed with a bigger and better machine gun that has infinite range!";
        public override int Cost => 50000;
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
            attackModel.weapons[0].projectile.GetBehavior<TravelStraitModel>().Speed *= 1.75f;
            if (InGame.Bridge.GetCurrentRound() > 80)
            {
                attackModel.weapons[0].projectile.GetDamageModel().damage *= (InGame.Bridge.GetCurrentRound() / 50);
            }
        }
        public override string Portrait => "Icon";
    }
    public class PainArrows : ModUpgrade<UpgradableShootyTurret.Main.UpgradableShootyTurret>
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
        public override string Portrait => "Icon";
    }
    public class BloontoniumArrows : ModUpgrade<UpgradableShootyTurret.Main.UpgradableShootyTurret>
    {
        public override string Name => "BloontoniumArrows";
        public override string DisplayName => "Bloontonium Arrows";
        public override string Description => "Arrows deal more damage now can pop lead!";
        public override int Cost => 1500;
        public override int Path => BOTTOM;
        public override int Tier => 2;
        public override void ApplyUpgrade(TowerModel towerModel)
        {
            AttackModel attackModel = towerModel.GetBehavior<AttackModel>();
            attackModel.weapons[0].projectile.GetDamageModel().damage += 4;
            attackModel.weapons[0].projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
        }
        public override string Portrait => "Icon";
    }
    public class HomingArrows : ModUpgrade<UpgradableShootyTurret.Main.UpgradableShootyTurret>
    {
        public override string Name => "HomingArrows";
        public override string DisplayName => "Homing Arrows";
        public override string Description => "Arrows now follow bloons and are larger.";
        public override int Cost => 3000;
        public override int Path => BOTTOM;
        public override int Tier => 3;
        public override void ApplyUpgrade(TowerModel towerModel)
        {
            AttackModel attackModel = towerModel.GetBehavior<AttackModel>();
            towerModel.displayScale *= 1.25f;
            towerModel.GetBehavior<DisplayModel>().scale *= 1.25f;
            attackModel.weapons[0].projectile.scale *= 1.25f;
            attackModel.weapons[0].projectile.GetBehavior<DisplayModel>().scale *= 1.25f;
            attackModel.range *= 1.25f;
            towerModel.range *= 1.25f;
            var homing = Game.instance.model.GetTowerFromId("NinjaMonkey-001").GetWeapon().projectile
                .GetBehavior<TrackTargetWithinTimeModel>().Duplicate();
            attackModel.weapons[0].projectile.AddBehavior(homing);
            attackModel.weapons[0].projectile.GetDamageModel().damage += 6;
            attackModel.weapons[0].Rate *= 0.5f;
            towerModel.GetBehaviors<DisplayModel>().First(a => a.name == "DisplayModel_UST_Top").display = new PrefabReference() { guidRef = "3b7505fd21be1fe42ad9b627219c2e43" };
            attackModel.weapons[0].projectile.pierce += 2;
        }
        public override string Portrait => "Icon";
    }
    public class BloonDeletion : ModUpgrade<UpgradableShootyTurret.Main.UpgradableShootyTurret>
    {
        public override string Name => "BloonDeletion";
        public override string DisplayName => "Bloon Deletion";
        public override string Description => "The Shooty turret now shoots faster and deals alot more damage with way more pierce and the ability to pop camo.";
        public override int Cost => 25000;
        public override int Path => BOTTOM;
        public override int Tier => 4;
        public override void ApplyUpgrade(TowerModel towerModel)
        {
            AttackModel attackModel = towerModel.GetBehavior<AttackModel>();
            towerModel.displayScale *= 1.25f;
            towerModel.GetBehavior<DisplayModel>().scale *= 1.25f;
            attackModel.weapons[0].projectile.scale *= 1.25f;
            attackModel.range *= 1.25f;
            towerModel.range *= 1.25f;
            attackModel.weapons[0].projectile.GetBehavior<DisplayModel>().scale *= 1.25f;
            attackModel.weapons[0].projectile.GetDamageModel().damage += 100;
            attackModel.weapons[0].projectile.pierce += 100;
            attackModel.weapons[0].Rate *= 0.75f;
            towerModel.AddBehavior(new OverrideCamoDetectionModel("OverrideCamoDetectionModel_", true));
        }
        public override string Portrait => "Icon";
    }
    public class UtterDeletion : ModUpgrade<UpgradableShootyTurret.Main.UpgradableShootyTurret>
    {
        public override string Name => "UtterDeletion";
        public override string DisplayName => "UtterDeletion";
        public override string Description => "THE BLOONS ARE NO MORE.";
        public override int Cost => 100000;
        public override int Path => BOTTOM;
        public override int Tier => 5;
        public override void ApplyUpgrade(TowerModel towerModel)
        {
            AttackModel attackModel = towerModel.GetBehavior<AttackModel>();
            towerModel.displayScale *= 1.5f;
            towerModel.GetBehavior<DisplayModel>().scale *= 1.5f;
            attackModel.weapons[0].projectile.scale *= 1.5f;
            attackModel.weapons[0].projectile.GetBehavior<DisplayModel>().scale *= 1.25f;
            attackModel.weapons[0].projectile.GetDamageModel().damage = 1000;
            attackModel.weapons[0].projectile.pierce = 9999999999;
            attackModel.weapons[0].Rate = 0.25f;
            attackModel.range *= 1.5f;
            towerModel.range *= 1.5f;
            if (InGame.Bridge.GetCurrentRound() > 80) 
            {
                attackModel.weapons[0].projectile.GetDamageModel().damage *= (InGame.Bridge.GetCurrentRound()/50);
            }
        }
        public override string Portrait => "Icon";
    }
}
