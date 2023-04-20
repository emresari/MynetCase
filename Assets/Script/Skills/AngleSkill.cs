using System.Collections.Generic;
using Script.Attack;
using Script.Player;
using UnityEngine;

namespace Script.Skills
{
    [CreateAssetMenu(fileName = "AngleSkill", menuName = "ScriptableObjects/Angle Skill")]
    public class AngleSkill : DamageSkill
    {
        [SerializeField] private List<float> angle;

        public override void Apply(Entity entity)
        {
            Shot playerShot = entity.shot;
            foreach (var value in angle)
            {
                var skillAngle = Vector3.zero;
                skillAngle.y = entity.transform.eulerAngles.y + value;
                Projectile projectile = playerShot.ProjectilePool.Allocate();
                projectile.Init(playerShot.SpawnPosition.position, skillAngle,playerShot.ProjectileSpeed);
                projectile.DestroyHandler = (sender, e) => {
                    playerShot.ProjectilePool.Release(projectile);
                };
                projectile.gameObject.SetActive(true);
                projectile.AddVelocity();
            }
        }
    }
}