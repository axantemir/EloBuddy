using EloBuddy;

namespace S_Class_Library
{
    public static class Misc
    {
        public static bool IsNotNull(this Obj_AI_Base target)
        {
            return target != null;
        }

        public static bool CanMove(this Obj_AI_Base target)
        {
            return !(target.MoveSpeed < 50) && !target.IsStunned && !target.HasBuffOfType(BuffType.Stun) && !target.HasBuffOfType(BuffType.Fear) &&
                   !target.HasBuffOfType(BuffType.Snare) && !target.HasBuffOfType(BuffType.Knockup) && !target.HasBuff("Recall") &&
                   !target.HasBuffOfType(BuffType.Knockback) && !target.HasBuffOfType(BuffType.Charm) && !target.HasBuffOfType(BuffType.Taunt) &&
                   !target.HasBuffOfType(BuffType.Suppression) && (!target.Spellbook.IsChanneling || target.IsMoving);
        }
    }
}