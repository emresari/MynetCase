using Script.Player;
using UnityEngine;

namespace Script.Skills
{
    [CreateAssetMenu(fileName = "ProjectileSpeedSkill", menuName = "ScriptableObjects/Projectile Speed Skill")]
    public class ProjectileSpeedSkill : BuffSkill
    {
        [SerializeField] private float upgradePercentageValue;

        public override void Apply(Entity entity)
        {
            entity.shot.ProjectileSpeed *= (1 + (upgradePercentageValue * 0.01f));
        }
    }
}