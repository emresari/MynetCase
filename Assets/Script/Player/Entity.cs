using Script.Managers;
using UnityEngine;

namespace Script.Player
{
    [RequireComponent(typeof(Shot))]
    public abstract class Entity : MonoBehaviour
    {
        public Shot shot;
        public bool isLocalEntity;

        protected virtual void Awake()
        {
            shot = GetComponent<Shot>();
        }

        protected virtual void Start()
        {
            GameManager.Instance.entities.Add(this);
        }
    }
}