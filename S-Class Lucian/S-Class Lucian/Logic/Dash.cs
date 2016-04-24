using System;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using S_Class_Library;
using SharpDX;
using static S_Class_Lucian.SpellsManager;
using static S_Class_Lucian.Constants;
using static S_Class_Lucian.Menus;

namespace S_Class_Lucian.Logic
{
    internal class Dash
    {
        public static bool Attempt(AIHeroClient target, int maxEnemiesNear = 1, bool dash = true)
        {
            // Are we chasing?
            if (target.Health < (Self.Health * 0.8) && Self.HealthPercent >= 20)
            {
                var dashToDarget = PostPosition(target.ServerPosition);
                if (target.HealthPercent <= 35 && Self.HealthPercent >= 50 &&
                    dashToDarget.EnemiesWithinRange(NearRange) < maxEnemiesNear &&
                    target.WithinRange(dashToDarget, EffectiveSkillRange))
                {
                    if (dash)
                        Player.CastSpell(SpellSlot.E, dashToDarget);

                    return true;
                }

                if (target.HealthPercent <= 15 && Self.HealthPercent >= 50 &&
                    dashToDarget.EnemiesWithinRange(NearRange) <= maxEnemiesNear &&
                    target.WithinRange(dashToDarget, EffectiveSkillRange))
                {
                    if (dash)
                        Player.CastSpell(SpellSlot.E, dashToDarget);

                    return true;
                }

                if (target.HealthPercent <= 10 &&
                    Self.HealthPercent >= 50 &&
                    target.WithinRange(dashToDarget, EffectiveSkillRange))
                {
                    if (dash)
                        Player.CastSpell(SpellSlot.E, dashToDarget);

                    return true;
                }
            }

            // Are we fleeing?
            if ((target.Health * 0.8) > Self.Health &&
                Self.HealthPercent <= 30 &&
                Self.AlliesWithinRange() < target.EnemiesWithinRange() &&
                (target.TotalAttackDamage >= (Self.TotalAttackDamage * 0.7) ||
                target.TotalMagicalDamage >= Self.TotalAttackDamage))
            {
                var dashToFlee = Flee(target).Position;
                if (dash)
                    Player.CastSpell(SpellSlot.E, dashToFlee);

                return true;
            }

            // Standard Dashing
            // Predict best E position
            var prediction = Prediction(target).Position;

            // Make sure prediction position is within AA range, not under turret and not close to X enemies
            if (target.WithinRange(prediction, EffectiveAttackRange) &&
                !prediction.UnderEnemyTurret() &&
                prediction.EnemiesWithinRange(NearRange) <= maxEnemiesNear)
            {
                if (dash)
                    Player.CastSpell(SpellSlot.E, prediction);

                return true;
            }

            return false;
        }
        public static DashPrediction Prediction(AIHeroClient target)
        {
            var logic = MiscMenu.GetComboBoxValue("dashPrediction");

            // MOUSE LOGIC
            if (logic.ToString().Contains("Mouse"))
                return new DashPrediction { Position = PostPosition(MousePosition), Score = 0 };

            // S-CLASS LOGIC
            // Calculate positions
            var playerPosition = Self.ServerPosition.To2D();
            var targetPosition = EloBuddy.SDK.Prediction.Position.PredictUnitPosition(target, E.CastDelay);

            // Default mode is to mouse
            var position = PostPosition(MousePosition);
            var score = GetPositionScore(target, position);

            // Check if to target is better
            var toTargetPosition = PostPosition(targetPosition.To3D());
            var toTargetScore = GetPositionScore(target, toTargetPosition);
            if (target.WithinRange(toTargetPosition, EffectiveAttackRange) &&
                (toTargetScore > score || !target.WithinRange(position, EffectiveAttackRange)))
            {
                position = toTargetPosition;
                score = toTargetScore;
            }

            // Check if prediction angles are better
            foreach (var angle in PredictionDashAngles)
            {

                var predictedPosition = PostPosition(Deviation(playerPosition, targetPosition, angle).To3D());
                var predictedScore = GetPositionScore(target, predictedPosition);

                if (predictedScore < score || !target.WithinRange(predictedPosition, EffectiveAttackRange))
                    continue;

                score = predictedScore;
                position = predictedPosition;
            }

            return new DashPrediction {Position = position, Score = score};
        }

        public static DashPrediction Flee(AIHeroClient target)
        {
            // S-CLASS LOGIC
            // Calculate positions
            var playerPosition = Self.ServerPosition.To2D();
            var targetPosition = target.ServerPosition.To2D();

            var score = 0f;
            var position = Self.ServerPosition;

            // Check if prediction angles are better
            foreach (var angle in PredictionDashAngles)
            {
                var predictedPosition = PostPosition(Deviation(playerPosition, targetPosition, angle).To3D());
                var predictedScore = GetPositionScore(target, predictedPosition, true, true);

                if (predictedScore < score || predictedPosition.IsWall() || !predictedPosition.IsValid())
                    continue;

                score = predictedScore;
                position = predictedPosition;
            }

            return new DashPrediction { Position = position, Score = score };
        }
        public static Vector3 PostPosition(Vector3 position)
        {
            return Self.ServerPosition.Extend(position, E.Range).To3D();
        }
        public static float GetPositionScore(AIHeroClient target, Vector3 position, bool countAllies = false, bool countAllyTurret = false, string getScoreOf = null)
        {
            const int wallScore = 600;
            const int enemyScore = 300;

            // Count getting closer to allies as a positive score
            var alliesScore = 0f;
            if (countAllies)
            {
                alliesScore = EntityManager.Heroes.Allies.Where(ally => ally.WithinRange(position, ScanRange) && !ally.IsDead).Sum(ally => Math.Max(EffectiveAttackRange * 2 - ally.Distance(position), 0));

                if (getScoreOf != null && getScoreOf.Contains("alliesScore"))
                    return alliesScore;
            }

            // Count getting closer to ally turret as a positive score
            var allyTurretScore = 0f;
            if (countAllyTurret)
            {
                var closeAllyTurret = EntityManager.Turrets.Allies.Where(turret => turret.WithinRange(position, TurretNearRange));
                if (closeAllyTurret.Any())
                    allyTurretScore = Math.Max((TurretNearRange - closeAllyTurret.First().Distance(position)), 0) * 2f;

                if (getScoreOf != null && getScoreOf.Contains("allyTurretScore"))
                    return allyTurretScore;
            }

            // Calculations
            var enemies = position.EnemiesWithinRange(NearRange);
            var isWall = (position.IsWall() || !position.IsValid() || NavMesh.GetCollisionFlags(position).HasFlag(CollisionFlags.Wall) || NavMesh.GetCollisionFlags(position).HasFlag(CollisionFlags.Building)) ? 1 : 0;

            return -(Math.Abs(enemies - 1) * enemyScore)
                   - (isWall * wallScore)
                   + position.Distance(target)
                   + (TotalDistanceToEnemies(position, NearRange) / enemies)
                   + (allyTurretScore)
                   + alliesScore;
        }
    }
    internal class DashPrediction
    {
        public float Score { get; set; }
        public Vector3 Position { get; set; }
    }
}