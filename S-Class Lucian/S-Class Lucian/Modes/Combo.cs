using System.Collections.Generic;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;
using S_Class_Library;
using SharpDX;
using S_Class_Lucian.Logic;
using static S_Class_Lucian.Menus;
using static S_Class_Lucian.SpellsManager;
using static S_Class_Lucian.Constants;

namespace S_Class_Lucian.Modes
{
    internal class Combo
    {
        public static AIHeroClient RTarget;
        public static void Execute()
        {
            //if (InRLock()) return;

            // Primary target
            var target = Targeting.Champions(EffectiveExtendedSkillRange);

            // Check if we should wait with spells
            if (!States.SpellReady(target))
                return;

            // Use E?
            if (E.IsReady() && ComboMenu.GetCheckBoxValue("eUse"))
            {
                // Attempt to dash
                if (!Dash.Attempt(target, MiscMenu.GetSliderValue("maxEnemiesNear")))
                {
                    // No dash is suitable, target closer enemies and attempt to dash again
                    target = Targeting.Champions(EffectiveSkillRange, true);
                    Dash.Attempt(target, MiscMenu.GetSliderValue("maxEnemiesNear"));
                }
            }

            // Cast Q
            if (ComboMenu.GetCheckBoxValue("qUse"))
            {
                if (!Q.TryToCast(target, ComboMenu))
                {
                    CastQExtended(target);
                }
            }

            // Cast W
            if (ComboMenu.GetCheckBoxValue("wUse"))
            {
                var wPrediction = W.GetPrediction(target);

                if ((!Q.IsReady() || !target.WithinRange(Q.Range)) &&
                    (wPrediction.HitChance != HitChance.Collision && wPrediction.HitChance >= HitChance.Medium))
                {
                    if (!W.TryToCast(wPrediction.CastPosition, ComboMenu) && target.WithinRange(EffectiveAttackRange))
                    {
                        CastW(wPrediction.CastPosition);
                    }
                }  
            }

            // Attempt to cast R
            if (R.IsReady() && ComboMenu.GetCheckBoxValue("rUse"))
            {
                target = Targeting.Champions(R.Range);
                RTarget = target;
                //Chat.Print("Casting R!");
                CastR(target);
            }

            // Attempt to cast extended Q
            if (ComboMenu.GetCheckBoxValue("qUse"))
            {
                target = Targeting.Champions(EffectiveReachRange);
                if (!Q.TryToCast(target, ComboMenu))
                {
                    CastQExtended(target);
                }
            }
        }

        public static bool InRLock()
        {
            if (!Self.HasBuff("LucianR") || !RTarget.IsAttackable(false) || !RTarget.WithinRange(R.Range))
                return false;

            var endPos = (Self.ServerPosition - RTarget.ServerPosition).Normalized();
            var predPos = R.GetPrediction(RTarget).CastPosition.To2D();
            var fullPoint = new Vector2(predPos.X + endPos.X * R.Range * 0.98f, predPos.Y + endPos.Y * R.Range * 0.98f);
            var closestPoint = Self.ServerPosition.To2D()
                .Closest(new List<Vector2> { predPos, fullPoint });

            if (closestPoint.IsValid() &&
                !NavMesh.GetCollisionFlags(closestPoint).HasFlag(CollisionFlags.Wall) &&
                !NavMesh.GetCollisionFlags(closestPoint).HasFlag(CollisionFlags.Building) &&
                predPos.Distance(closestPoint) > E.Range)
            {
                Orbwalker.MoveTo(closestPoint.To3D());
            }
            else if (fullPoint.IsValid() &&
                     !NavMesh.GetCollisionFlags(fullPoint).HasFlag(CollisionFlags.Wall) &&
                     !NavMesh.GetCollisionFlags(fullPoint).HasFlag(CollisionFlags.Building) &&
                     predPos.Distance(fullPoint) < R.Range &&
                     predPos.Distance(fullPoint) > 100)
            {
                Orbwalker.MoveTo(fullPoint.To3D());
            }

            return true;
        }

        public static Vector3 GetRLockPosition()
        {
            //if (!Self.HasBuff("LucianR") || !RTarget.IsTargetable(false) || !RTarget.WithinRange(R.Range))
            //    return false;

            var endPos = (Self.ServerPosition - RTarget.ServerPosition).Normalized();
            var predPos = R.GetPrediction(RTarget).CastPosition.To2D();
            var fullPoint = new Vector2(predPos.X + endPos.X * R.Range * 0.98f, predPos.Y + endPos.Y * R.Range * 0.98f);
            var closestPoint = Self.ServerPosition.To2D()
                .Closest(new List<Vector2> { predPos, fullPoint });

            if (closestPoint.IsValid() &&
                !NavMesh.GetCollisionFlags(closestPoint).HasFlag(CollisionFlags.Wall) &&
                !NavMesh.GetCollisionFlags(closestPoint).HasFlag(CollisionFlags.Building) &&
                predPos.Distance(closestPoint) > E.Range)
            {
                return closestPoint.To3D();
            }
            else if (fullPoint.IsValid() &&
                     !NavMesh.GetCollisionFlags(fullPoint).HasFlag(CollisionFlags.Wall) &&
                     !NavMesh.GetCollisionFlags(fullPoint).HasFlag(CollisionFlags.Building) &&
                     predPos.Distance(fullPoint) < R.Range &&
                     predPos.Distance(fullPoint) > 100)
            {
                return fullPoint.To3D();
            }

            return closestPoint.To3D();
        }
    }
}