using System;
using EloBuddy;
using EloBuddy.SDK.Events;
using S_Class_Lucian.Modes;

namespace S_Class_Lucian
{
    internal class Program
    {
        public static string Champion = "Lucian";
        private static void Main(string[] args)
        {
            Loading.OnLoadingComplete += Loading_OnLoadingComplete;
        }
        private static void Loading_OnLoadingComplete(EventArgs args)
        {
            if (Player.Instance.ChampionName != Champion) return;
            
            SpellsManager.InitializeSpells();
            Menus.CreateMenu();
            ModeManager.InitializeModes();
            DrawingsManager.InitializeDrawings();
            States.InitializeStates();
            Events.InitializeEvents();

            Chat.Print("S-Class Lucian loaded.");
        }
    }
}