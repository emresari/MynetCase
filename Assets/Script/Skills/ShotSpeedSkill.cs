using Script.Player;
using UnityEngine;

namespace Script.Skills
{
    [CreateAssetMenu(fileName = "ShotSpeedSkill", menuName = "ScriptableObjects/Shot Speed Skill")]
    public class ShotSpeedSkill : BuffSkill
    {
        [SerializeField] private float upgradeValue;

        public override void Apply(Entity entity)
        {
            entity.shot.ShotSpeed -= upgradeValue;
        }
    }
}