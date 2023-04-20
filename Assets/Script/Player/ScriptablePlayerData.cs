using UnityEngine;

namespace Script.Player
{
    [CreateAssetMenu(fileName = "Player Data", menuName = "ScriptableObjects/Player Data")]
    public class ScriptablePlayerData : ScriptableObject
    {
        [SerializeField] private int baseShotSpeed;
        [SerializeField] private int baseProjectileSpeed;

        public int BaseShotSpeed => baseShotSpeed;
        public int BaseProjectileSpeed => baseProjectileSpeed;

    }
}

