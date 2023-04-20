using Script.Player;
using UnityEngine;

namespace Script.Skills
{
    [CreateAssetMenu(fileName = "CloneSkill", menuName = "ScriptableObjects/Clone Skill")]
    public class CloneSkill : BuffSkill
    {
        [SerializeField] private Vector3 spawnPosition;

        public override void Apply(Entity entity)
        {
            var createdEntity = Instantiate(entity, spawnPosition, Quaternion.identity);
            createdEntity.isLocalEntity = false;
            createdEntity.shot.Init(entity.shot.ShotSpeed,entity.shot.ProjectileSpeed);
        }
    }
}