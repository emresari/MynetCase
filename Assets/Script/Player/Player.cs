using UnityEngine;

namespace Script.Player
{
    public class Player : Entity
    {
        [SerializeField] private ScriptablePlayerData playerData;

        protected override void Start()
        {
            base.Start();
            Init();
        }

        private void Init()
        {
            if (!isLocalEntity) return;
            shot.ShotSpeed = playerData.BaseShotSpeed;
            shot.ProjectileSpeed = playerData.BaseProjectileSpeed;
        }
        
    }
}