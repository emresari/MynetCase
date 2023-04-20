using Script.Player;
using UnityEngine;

namespace Script.Skills
{
    public abstract class ScriptableSkill : ScriptableObject
    {
        [SerializeField] private Sprite skillSprite;

        public Sprite SkillSprite => skillSprite;

        public abstract void Apply(Entity entity);

        public virtual void TryUse(Entity entity)
        {
        }
    }
}