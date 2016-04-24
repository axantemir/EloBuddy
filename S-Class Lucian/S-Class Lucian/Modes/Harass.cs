using EloBuddy;
using EloBuddy.SDK;
using S_Class_Library;
using S_Class_Lucian.Logic;
using static S_Class_Lucian.Menus;
using static S_Class_Lucian.SpellsManager;
using static S_Class_Lucian.Constants;

namespace S_Class_Lucian.Modes
{
    internal class Harass
    {
        public static void Execute()
        {
            // 2-Leveled settings
            var settingsType = (Self.Level >= HarassMenu.GetSliderValue("lateGameLevelSlider")) ? "LateGame" : "";
        
            // Get best champion
            var target =
                Targeting.Champions(
                    HarassMenu.GetCheckBoxValue("eUse" + settingsType) ? EffectiveExtendedReachRange : EffectiveReachRange, true);

            // Check if target/self are valid for spells
            if (!States.SpellReady(target))
                return;

            // Use E?
            if (E.IsReady() && HarassMenu.GetCheckBoxValue("eUse" + settingsType))
            {
                // Predict best E position
                var predictedPosition = Dash.Prediction(target).Position;

                // Make sure prediction position is within AA range, not under turret and no other enemies are close
                if (target.WithinRange(predictedPosition, EffectiveAttackRange) &&
                    !predictedPosition.UnderEnemyTurret() &&
                    predictedPosition.EnemiesWithinRange(ScanRange) == 1)
                {
                    Player.CastSpell(SpellSlot.E, predictedPosition);
                }
            }

            // Harass with Q
            if (HarassMenu.GetCheckBoxValue("qUse" + settingsType))
            {
                if (!Q.Cast(target))
                    CastQExtended(target);
            }

            // Cast W
            if (HarassMenu.GetCheckBoxValue("wUse" + settingsType) && target.WithinRange(EffectiveAttackRange))
            {
                if (!W.Cast(target))
                    CastW(target.ServerPosition);
            }
        }
    }
}