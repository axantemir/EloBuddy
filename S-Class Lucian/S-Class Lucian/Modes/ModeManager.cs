using System;
using EloBuddy;
using EloBuddy.SDK;
using S_Class_Library;
using static S_Class_Lucian.Menus;
using static S_Class_Lucian.Constants;

namespace S_Class_Lucian.Modes
{
    internal class ModeManager
    {
        public static void InitializeModes()
        {
            Game.OnTick += Game_OnTick;
        }
        private static void Game_OnTick(EventArgs args)
        {
            var orbMode = Orbwalker.ActiveModesFlags;
            var playerMana = Player.Instance.ManaPercent;
            var harassSettingsType = (Self.Level >= HarassMenu.GetSliderValue("lateGameLevelSlider")) ? "LateGame" : "";
            var laneClearSettingsType = (Self.Level >= LaneClearMenu.GetSliderValue("lateGameLevelSlider")) ? "LateGame" : "";

            Active.Execute();

            if (orbMode.HasFlag(Orbwalker.ActiveModes.Combo))
            {
                Combo.Execute();
            }

            if (orbMode.HasFlag(Orbwalker.ActiveModes.Harass) && playerMana > HarassMenu.GetSliderValue("manaSlider" + harassSettingsType))
            {
                Harass.Execute();
            }

            if (orbMode.HasFlag(Orbwalker.ActiveModes.LaneClear) && playerMana > LaneClearMenu.GetSliderValue("manaSlider" + laneClearSettingsType))
            {
                LaneClear.Execute();
            }

            if (orbMode.HasFlag(Orbwalker.ActiveModes.JungleClear) && playerMana > JungleClearMenu.GetSliderValue("manaSlider"))
            {
                JungleClear.Execute();
            }
        }
    }
}