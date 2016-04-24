using EloBuddy;
using S_Class_Library;
using S_Class_Lucian.Logic;
using static S_Class_Lucian.Menus;
using static S_Class_Lucian.SpellsManager;
using static S_Class_Lucian.Constants;

namespace S_Class_Lucian.Modes
{
    internal class JungleClear
    {
        public static void Execute()
        {
            // Get closest jungle creep
            var target = Targeting.Monsters();

            // Check if target/self are valid for spells
            if (!States.SpellReady(target))
                return;

            // Check if no enemy before casting E  
            if (Self.EnemiesWithinRange(ScanRange) == 0)
            {
                // Check if should E to mouse or target
                if (target.WithinRange(Dash.PostPosition(MousePosition), EffectiveAttackRange))
                {
                    Player.CastSpell(SpellSlot.E, MousePosition);
                }
                else if (target.WithinRange(Dash.PostPosition(target.ServerPosition), EffectiveAttackRange))
                {
                    Player.CastSpell(SpellSlot.E, target.ServerPosition);
                }

            } 

            // Cast Q
            Q.TryToCast(target, JungleClearMenu);

            // Cast W
            if (JungleClearMenu.GetCheckBoxValue("wUse") && target.WithinRange(EffectiveAttackRange))
            {
                if (!W.TryToCast(target, ComboMenu))
                    CastW(target.ServerPosition);
            }
        }
    }
}