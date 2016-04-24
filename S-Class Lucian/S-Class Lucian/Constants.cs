using System;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using SharpDX;
using static S_Class_Lucian.SpellsManager;

namespace S_Class_Lucian
{
    internal static class Constants
    {
        // Champion-specific constants
        // Lucian
        public static float AttackRange => 550;
        public static string[] SkillOrder = { "Q", "E", "Q", "W", "Q", "R", "Q", "E", "Q", "E", "R", "E", "E", "W", "W", "R", "W", "W" };
        public static string[] SkillPriority = { "R", "Q", "E", "W" };

        // S-Class logic
        public static float EffectiveAttackRange => AttackRange * AttackRangeMod;
        public static float EffectiveExtendedAttackRange => EffectiveAttackRange + (E.IsReady() ? E.Range : 0);
        public static float EffectiveSkillRange => (Q.IsReady() ? Q.Range : EffectiveAttackRange);
        public static float EffectiveExtendedSkillRange
        {
            get {
                float range = (Q.IsReady() ? Q.Range : 0) + (E.IsReady() ? E.Range : 0);
                return (range > EffectiveAttackRange) ? range : EffectiveAttackRange;
            }
        }
        public static float EffectiveReachRange => (Q.IsReady() ? QExtended.Range : EffectiveAttackRange);
        public static float EffectiveExtendedReachRange
        {
            get
            {
                float range = (Q.IsReady() ? QExtended.Range : 0) + (E.IsReady() ? E.Range : 0);
                return (range > EffectiveAttackRange) ? range : EffectiveAttackRange;
            }
        }
        public static float EffectiveDashRange => E.IsReady() ? E.Range : 0;

        public static float NearRange => AttackRange*1.5f;
        public static float ScanRange => AttackRange*3f;
        public static float TurretNearRange => ScanRange*1.5f;

        public static float[] PredictionDashAngles => new float[] {180, 160, 140, 120, 100, 85, 60, 40, 20, 10, 0, -10, -20, -40, -60, -85, -100, -120, -140, -160};
        public static string[] DangerousGapClosers => new[]
        {
            "Braum", "Ekko", "Elise", "Fiora", "Kindred", "Lucian", "Yi", "Nidalee", "Quinn",
            "Riven", "Shaco", "Sion", "Vayne", "Yasuo", "Graves", "Azir", "Gnar", "Irelia", "Kalista"
        };

        // S-Class modifiers
        public static float AttackRangeMod => 1.1f;

        // Game-wide constants
        public static float TurretRange => 775;

        // Helpers
        public static AIHeroClient Self => ObjectManager.Player;
        public static Vector3 MousePosition => Game.CursorPos;
        public static Orbwalker.ActiveModes OrbwalkerFlag => Orbwalker.ActiveModesFlags;

        // Calculation Methods
        public static float GetEffectiveRange(this AIHeroClient target)
        {
            return target.IsMelee ? target.GetAutoAttackRange()*2 : target.GetAutoAttackRange();
        }
        public static float TotalDistanceToEnemies(Vector3 position, float range)
        {
            return EntityManager.Heroes.Enemies.Where(enemy => enemy.Distance(position) <= range && !enemy.IsDead).Sum(enemy => enemy.Distance(position));
        }
        public static float TotalDistanceToEnemies(AIHeroClient target, float range)
        {
            return TotalDistanceToEnemies(target.ServerPosition, range);
        }
        public static Vector2 Deviation(Vector2 point1, Vector2 point2, double angle)
        {
            angle *= Math.PI / 180.0;
            var temp = Vector2.Subtract(point2, point1);
            var result = new Vector2(0)
            {
                X = (float)(temp.X * Math.Cos(angle) - temp.Y * Math.Sin(angle)) / 4,
                Y = (float)(temp.X * Math.Sin(angle) + temp.Y * Math.Cos(angle)) / 4
            };
            result = Vector2.Add(result, point1);
            return result;
        }
    }
}