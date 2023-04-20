using System.Collections;
using Script.Player;
using Script.Pools;
using UnityEngine;

namespace Script.Skills
{
    [CreateAssetMenu(fileName = "Multi Shot Skill", menuName = "ScriptableObjects/Multi Shot Skill")]
    public class MultiShotSkill : DamageSkill
    {
        [SerializeField] private float delay;

        public override void Apply(Entity entity)
        {
            entity.StartCoroutine(CreateDelaySkillRoutine(entity));
        }

        private IEnumerator CreateDelaySkillRoutine(Entity entity)
        {
            yield return PoolWaitForSeconds.Wait(delay);
            foreach (var skill in entity.shot.scriptableSkills)
            {
                if (skill is MultiShotSkill) continue;
                skill.Apply(entity);
            }
        }
    }
}