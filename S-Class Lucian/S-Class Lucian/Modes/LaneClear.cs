using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using S_Class_Library;
using S_Class_Lucian.Logic;
using static S_Class_Lucian.Menus;
using static S_Class_Lucian.SpellsManager;
using static S_Class_Lucian.Constants;

namespace S_Class_Lucian.Modes
{
    internal class LaneClear
    {
        public static void Execute()
        {
            // 2-Leveled settings
            var settingsType = (Self.Level >= HarassMenu.GetSliderValue("lateGameLevelSlider")) ? "LateGame" : "";

            // Get close minions
            var target = Targeting.Minions();

            // Check if target/self are valid for spells
            if (!States.SpellReady(target))
                return;

            // Farm with E
            if (E.IsReady() && LaneClearMenu.GetCheckBoxValue("eUse" + settingsType) && 
                Self.EnemiesWithinRange(ScanRange) == 0)
            {
                var postDashCursor = Dash.PostPosition(MousePosition);
                var postDashTarget = Dash.PostPosition(target.ServerPosition);

                // Only dash if no enemies close
                if (postDashTarget.EnemiesWithinRange(ScanRange) == 0 && 
                    postDashCursor.EnemiesWithinRange(ScanRange) == 0)
                {
                    // Check if should E to mouse or target
                    if (target.WithinRange(postDashCursor, EffectiveAttackRange))
                    {
                        Player.CastSpell(SpellSlot.E, MousePosition);
                    }
                    else if (target.WithinRange(postDashTarget, EffectiveAttackRange))
                    {
                        Player.CastSpell(SpellSlot.E, target);
                    }
                }  
            }

            // Farm with Q
            if (Q.IsReady() && LaneClearMenu.GetCheckBoxValue("qUse" + settingsType))
            { 
                var qMinions =
                    EntityManager.MinionsAndMonsters.GetLaneMinions(EntityManager.UnitTeam.Enemy,
                        Self.ServerPosition, Q.Range);
                var aiMinions = qMinions as Obj_AI_Minion[] ?? qMinions.ToArray();

                foreach (var m in from m in aiMinions
                                  let p = new Geometry.Polygon.Rectangle(Self.ServerPosition.To2D(), Self.ServerPosition.Extend(m.ServerPosition, QExtended.Range), 65)
                                  where aiMinions.Count(x => p.IsInside(x.ServerPosition)) >= LaneClearMenu.GetSliderValue("minQHits" + settingsType)
                                  select m)
                {
                    Q.Cast(m);
                    break;
                }
            }

            // Farm with W
            if (W.IsReady() && LaneClearMenu.GetCheckBoxValue("wUse" + settingsType))
            {
                var wMinions =
                    EntityManager.MinionsAndMonsters.GetLaneMinions(EntityManager.UnitTeam.Enemy,
                        ObjectManager.Player.Position, AttackRange)
                        .FirstOrDefault(x => x.IsValidTarget(AttackRange));
                if (wMinions != null)
                    W.Cast(wMinions);
            }
        }
    }
}