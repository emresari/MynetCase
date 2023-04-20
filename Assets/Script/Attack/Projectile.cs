using System;
using Script.Pools;
using UnityEngine;

namespace Script.Attack
{
    [RequireComponent(typeof(Rigidbody))]
    public class Projectile : MonoBehaviour, IResettable
    {
        public EventHandler DestroyHandler = null;
        public float speed = 20f;
        private Rigidbody _rigidbody;


        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        public void Init(Vector3 position, Vector3 rotation, float projectileSpeed)
        {
            transform.position = position;
            transform.rotation = Quaternion.Euler(rotation);
            speed = projectileSpeed;
        }

        public void AddVelocity()
        {
            _rigidbody.velocity = transform.forward * speed;
        }

        private void OnCollisionEnter()
        {
            DestroyHandler.Invoke(this, null);
        }

        public void Reset()
        {
            _rigidbody.velocity = Vector3.zero;
            gameObject.SetActive(false);
        }
    }
}