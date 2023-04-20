using System.Collections.Generic;
using Script.Attack;
using Script.Pools;
using Script.Pools.Factory;
using Script.Skills;
using UnityEngine;

namespace Script.Player
{
    [RequireComponent(typeof(Entity))]
    public abstract class Shot : MonoBehaviour
    {
        [SerializeField] private Projectile projectile;
        [SerializeField] private Transform spawnPosition;
        public List<ScriptableSkill> scriptableSkills;
        protected Entity Entity;

        public float ShotSpeed { get; set; }
        public float ProjectileSpeed { get; set; }
        public Transform SpawnPosition => spawnPosition;
        public Pool<Projectile> ProjectilePool { get; private set; }

        protected virtual void Awake()
        {
            Entity = GetComponent<Entity>();
        }

        protected virtual void Start()
        {
            ProjectilePool = new Pool<Projectile>(new PrefabFactory<Projectile>(projectile.gameObject), 20);
        }

        public void Init(float shotSpeed, float projectileSpeed)
        {
            ShotSpeed = shotSpeed;
            ProjectileSpeed = projectileSpeed;
        }
    }
}