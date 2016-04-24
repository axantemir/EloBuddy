using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;
using static S_Class_Lucian.SpellsManager;
using static S_Class_Lucian.Constants;

namespace S_Class_Lucian.Logic
{
    internal static class Targeting
    {
        public static AIHeroClient Champions(float range = 0f, bool forceRange = false)
        {
            range = (range.Equals(0f)) ? EffectiveExtendedAttackRange : range;
            var target = TargetSelector.GetTarget(range, DamageType.Physical);

            if (forceRange && range < EffectiveExtendedAttackRange)
            {
                // Check if we should focus a selected target
                if (TargetSelector.SelectedTarget != null &&
                    TargetSelector.SelectedTarget.WithinRange(EffectiveExtendedAttackRange))
                    target = TargetSelector.SelectedTarget;

                // Check if we need to finish off a low HP enemy
                var enemies =
                    EntityManager.Heroes.Enemies.Where(enemy => (enemy.WithinRange(EffectiveExtendedAttackRange) &&
                                                                 Prediction.Health.GetPrediction(enemy, GetComboCastDelay()) < GetComboDamage(enemy) &&
                                                                 enemy.HealthPercent < 40f));
                if (enemies.Any())
                {
                    target = enemies.First();
                }
            }

            return target;
        }

        public static AIHeroClient Preferred(float? range = null)
        {
            range = range ?? EffectiveExtendedAttackRange;
            return EntityManager.Heroes.Enemies.OrderBy(e => e.Health)
                    .ThenByDescending(TargetSelector.GetPriority)
                    .ThenBy(e => e.FlatArmorMod)
                    .ThenBy(e => e.FlatMagicReduction)
                    .FirstOrDefault(e => e.IsValidTarget(range) && !e.HasUndyingBuff());
        }
        public static Obj_AI_Minion Monsters(float range = 0f)
        {
            range = (range.Equals(0f)) ? EffectiveExtendedAttackRange : range;
            return EntityManager.MinionsAndMonsters.GetJungleMonsters(Self.ServerPosition, range).FirstOrDefault();
        }
        public static Obj_AI_Minion Minions(float range = 0f)
        {
            range = (range.Equals(0f)) ? EffectiveExtendedAttackRange : range;
            return EntityManager.MinionsAndMonsters.GetLaneMinions(EntityManager.UnitTeam.Enemy, Self.ServerPosition, range).FirstOrDefault();
        }
        public static bool IsAttackable(this AIHeroClient target, bool waitForAutoAttack = true)
        {
            return (!Self.IsDead &&
                    !target.IsDead &&
                    !target.IsPhysicalImmune &&
                    target.IsEnemy &&
                    ((waitForAutoAttack && !Orbwalker.IsAutoAttacking) || !waitForAutoAttack) &&
                    !Self.IsDashing() &&
                    !target.IsZombie &&
                    !target.HasBuffOfType(BuffType.Invulnerability));
        }
        public static bool IsAttackable(this Obj_AI_Minion target, bool waitForAutoAttack = true)
        {
            return (!Self.IsDead &&
                    target != null &&
                    ((waitForAutoAttack && !Orbwalker.IsAutoAttacking) || !waitForAutoAttack) &&
                    !Self.IsDashing());
        }
    }
}