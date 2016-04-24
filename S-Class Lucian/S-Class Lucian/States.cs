using System;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;
using S_Class_Library;
using SharpDX;
using static S_Class_Lucian.Menus;
using static S_Class_Lucian.Constants;


namespace S_Class_Lucian
{
    internal static class States
    {
        public static bool Spellweaving = false;
        public static void InitializeStates()
        {
            Obj_AI_Base.OnBuffLose += OnBuffLose;
            Obj_AI_Base.OnProcessSpellCast += OnProcessSpellCast;
            Orbwalker.OnPostAttack += Orbwalker_OnPostAttack;
        }
        public static bool SpellReady(AIHeroClient target)
        {
            return (target.IsTargetable &&
                    ((InSpellweaving() && Self.EnemiesWithinRange(EffectiveAttackRange) < 1) || !InSpellweaving()));
        }
        public static bool SpellReady(Obj_AI_Minion target)
        {
            return (!Self.IsDead &&
                    target != null &&
                    !InSpellweaving() &&
                    !Orbwalker.IsAutoAttacking &&
                    !Self.IsDashing());
        }
        public static bool InSpellweaving()
        {
            return (MiscMenu.GetCheckBoxValue("spellweaving")) && Spellweaving;
        }
        private static void OnBuffLose(AttackableUnit unit, Obj_AI_BaseBuffLoseEventArgs args)
        {
            if (unit.IsMe && args.Buff.Name == "LucianPassiveBuff")
            {
                Spellweaving = false;
            }
        }
        private static void OnProcessSpellCast(Obj_AI_Base unit, GameObjectProcessSpellCastEventArgs args)
        {
            // Spells made by self
            if (unit.IsMe)
            {
                // If a skill was used, set spellweaving = true
                if (args.Slot == SpellSlot.Q || 
                    args.Slot == SpellSlot.W ||
                    args.Slot == SpellSlot.E ||
                    args.Slot == SpellSlot.R)
                {
                    Spellweaving = true;
                }       
            } 
        }
        private static void Orbwalker_OnPostAttack(AttackableUnit unit, EventArgs args)
        {
            Spellweaving = false;
        }
        public static bool UnderEnemyTurret(this Vector3 position)
        {
            return (EntityManager.Turrets.Enemies.Any(turret => turret.Distance(position) < TurretRange));
        }
        public static int EnemiesWithinRange(this Vector3 position, float range = 0f)
        {
            range = (range.Equals(0f)) ? EffectiveAttackRange : range;
            return EntityManager.Heroes.Enemies.Count(enemy => enemy.Distance(position) < range && !enemy.IsDead);
        }
        public static int EnemiesWithinRange(this AIHeroClient target, float range = 0f)
        {
            range = (range.Equals(0f)) ? EffectiveAttackRange : range;
            return EntityManager.Heroes.Enemies.Count(enemy => enemy.Distance(target) < range && !enemy.IsDead);
        }
        public static int AlliesWithinRange(this Vector3 position, float range = 0f)
        {
            range = (range.Equals(0f)) ? EffectiveAttackRange : range;
            return EntityManager.Heroes.Allies.Count(ally => ally.Distance(position) < range && !ally.IsDead);
        }
        public static int AlliesWithinRange(this AIHeroClient target, float range = 0f)
        {
            range = (range.Equals(0f)) ? EffectiveAttackRange : range;
            return EntityManager.Heroes.Allies.Count(ally => ally.Distance(target) < range && !ally.IsDead);
        }
        public static bool WithinRange(this Obj_AI_Base target, float range = 0f)
        {
            range = (range.Equals(0f)) ? EffectiveAttackRange : range;
            return (target.Distance(Self) <= range);
        }
        public static bool WithinRange(this Obj_AI_Base target, Vector3 source, float range = 0f)
        {
            range = (range.Equals(0f)) ? EffectiveAttackRange : range;
            return (target.Distance(source) <= range);
        }
        public static bool WithinRange(this Vector3 targetPosition, float range = 0f)
        {
            range = (range.Equals(0f)) ? EffectiveAttackRange : range;
            return (targetPosition.Distance(Self) <= range);
        }
    }
}