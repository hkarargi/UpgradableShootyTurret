using BTD_Mod_Helper.Api.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using Il2CppAssets.Scripts.Models.Towers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static UpgradableShootyTurret.UpgradableShootyTurret;
using BTD_Mod_Helper.Extensions;

namespace UpgradableShootyTurret.ShootyTurret.Top.Upgrades
{
    public class FasterMechanics : ModUpgrade<UpgradableShootyTurretModTower>
    {
        public override string Name => "FasterMechanics";
        public override string DisplayName => "Faster Mechanics";
        public override string Description => "Shooty Turrets shoot faster!";
        public override int Cost => 250;
        public override int Path => TOP;
        public override int Tier => 1;
        public override void ApplyUpgrade(TowerModel towerModel)
        {
            AttackModel attackModel = towerModel.GetBehavior<AttackModel>();
            attackModel.weapons[0].Rate *= 0.8f;
        }
        public override string Portrait => "ShootyTurretIcon";
    }
}
