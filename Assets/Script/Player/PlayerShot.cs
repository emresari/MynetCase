using System.Collections;
using Script.Attack;
using Script.Pools;
using UnityEngine;


namespace Script.Player
{
    public class PlayerShot : Shot
    {
        protected override void Start()
        {
            base.Start();
            StartCoroutine(nameof(ShotRoutine));
        }

        private IEnumerator ShotRoutine()
        {
            while (true)
            {
                yield return PoolWaitForSeconds.Wait(ShotSpeed);
                CreateSkill();
                yield return new WaitForFixedUpdate();
            }
        }

        private void CreateSkill()
        {
            foreach (var skill in scriptableSkills)
            {
                skill.Apply(Entity);
            }
        }
    }
}