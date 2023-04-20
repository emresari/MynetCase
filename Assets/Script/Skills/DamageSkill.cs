using Script.Player;

namespace Script.Skills
{
    public abstract class DamageSkill : ScriptableSkill
    {
        public override void TryUse(Entity entity)
        {
            entity.shot.scriptableSkills.Add(this);
        }
    }
}