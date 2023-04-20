using Script.Player;

namespace Script.Skills
{
    public abstract class BuffSkill : ScriptableSkill
    {
        public override void TryUse(Entity entity)
        {
            Apply(entity);
        }
    }
}