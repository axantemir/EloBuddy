using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;
using S_Class_Library;

namespace S_Class_Lucian
{
    internal class Menus
    {
        public const string ComboMenuID = "combomenuid";
        public const string HarassMenuID = "harassmenuid";
        public const string AutoHarassMenuID = "autoharassmenuid";
        public const string LaneClearMenuID = "laneclearmenuid";
        public const string LastHitMenuID = "lasthitmenuid";
        public const string JungleClearMenuID = "jungleclearmenuid";
        public const string KillStealMenuID = "killstealmenuid";
        public const string DrawingsMenuID = "drawingsmenuid";
        public const string MiscMenuID = "miscmenuid";
        public static Menu FirstMenu;
        public static Menu ComboMenu;
        public static Menu HarassMenu;
        public static Menu LaneClearMenu;
        public static Menu JungleClearMenu;
        public static Menu KillStealMenu;
        public static Menu DrawingsMenu;
        public static Menu MiscMenu;

        //These colorslider are from Mario`s Lib
        public static ColorSlide QColorSlide;
        public static ColorSlide WColorSlide;
        public static ColorSlide EColorSlide;
        public static ColorSlide RColorSlide;
        public static ColorSlide DamageIndicatorColorSlide;

        public static void CreateMenu()
        {
            FirstMenu = MainMenu.AddMenu("S-Class " + Player.Instance.ChampionName, Player.Instance.ChampionName.ToLower() + "hue");
            ComboMenu = FirstMenu.AddSubMenu("• Combo", ComboMenuID);
            HarassMenu = FirstMenu.AddSubMenu("• Harass", HarassMenuID);
            LaneClearMenu = FirstMenu.AddSubMenu("• LaneClear", LaneClearMenuID);
            JungleClearMenu = FirstMenu.AddSubMenu("• JungleClear", JungleClearMenuID);
            KillStealMenu = FirstMenu.AddSubMenu("• KillSteal", KillStealMenuID);
            MiscMenu = FirstMenu.AddSubMenu("• S-Class Logic", MiscMenuID);
            DrawingsMenu = FirstMenu.AddSubMenu("• Drawings", DrawingsMenuID);

            ComboMenu.AddGroupLabel("Spells");
            ComboMenu.CreateCheckBox(" - Use Q", "qUse");
            ComboMenu.CreateCheckBox(" - Use W", "wUse");
            ComboMenu.CreateCheckBox(" - Use E", "eUse");
            ComboMenu.CreateCheckBox(" - Use R", "rUse");

            HarassMenu.AddGroupLabel("Early game settings");
            HarassMenu.CreateCheckBox(" - Use Q", "qUse");
            HarassMenu.CreateCheckBox(" - Use W", "wUse");
            HarassMenu.CreateCheckBox(" - Use E", "eUse");
            HarassMenu.CreateSlider("Mana must be higher than [{0}%] to use Harass spells", "manaSlider", 70);
            HarassMenu.AddSeparator();
            HarassMenu.AddGroupLabel("Late game settings");
            HarassMenu.CreateSlider("Use late game settings when my level is [{0}] ", "lateGameLevelSlider", 12, 1, 18);
            HarassMenu.CreateCheckBox(" - Use Q", "qUseLateGame");
            HarassMenu.CreateCheckBox(" - Use W", "wUseLateGame");
            HarassMenu.CreateCheckBox(" - Use E", "eUseLateGame");
            HarassMenu.CreateSlider("Mana must be higher than [{0}%] to use Harass spells", "manaSliderLateGame", 30);

            LaneClearMenu.AddGroupLabel("Early game settings");
            LaneClearMenu.CreateCheckBox(" - Use Q", "qUse");
            LaneClearMenu.CreateCheckBox(" - Use W", "wUse");
            LaneClearMenu.CreateCheckBox(" - Use E", "eUse");
            LaneClearMenu.CreateSlider("Use Q if it hits at least [{0}] minions", "minQHits", 3, 1, 4);
            LaneClearMenu.CreateSlider("Mana must be higher than [{0}%] to use LaneClear spells", "manaSlider", 70);
            LaneClearMenu.AddGroupLabel("Late game settings");
            LaneClearMenu.CreateSlider("Use late game settings when my level is [{0}] ", "lateGameLevelSlider", 12, 1, 18);
            LaneClearMenu.CreateCheckBox(" - Use Q", "qUseLateGame");
            LaneClearMenu.CreateCheckBox(" - Use W", "wUseLateGame");
            LaneClearMenu.CreateCheckBox(" - Use E", "eUseLateGame");
            LaneClearMenu.CreateSlider("Use Q if it hits at least [{0}] minions", "minQHitsLateGame", 2, 1, 4);
            LaneClearMenu.CreateSlider("Mana must be higher than [{0}%] to use LaneClear spells", "manaSliderLateGame", 30);

            JungleClearMenu.AddGroupLabel("Spells");
            JungleClearMenu.CreateCheckBox(" - Use Q", "qUse");
            JungleClearMenu.CreateCheckBox(" - Use W", "wUse");
            JungleClearMenu.CreateCheckBox(" - Use E", "eUse");
            JungleClearMenu.CreateSlider("Mana must be higher than [{0}%] to use JungleClear spells", "manaSlider", 30);

            KillStealMenu.AddGroupLabel("Spells");
            KillStealMenu.CreateCheckBox(" - Use Q", "qUse");
            KillStealMenu.CreateCheckBox(" - Use W", "wUse");
            KillStealMenu.CreateCheckBox(" - Use E", "eUse");
            //KillStealMenu.CreateCheckBox(" - Use R (Not implemented yet)", "rUse");
            KillStealMenu.CreateSlider("Mana must be higher than [{0}%] to use Killsteal spells", "manaSlider", 30);


            MiscMenu.AddGroupLabel("S-Class Settings");
            MiscMenu.CreateCheckBox("Spellweave attacks", "spellweaving", true);
            MiscMenu.CreateCheckBox("Anti-melee (E)", "antiMeleeDash", false);
            MiscMenu.CreateCheckBox("Dash away from Gap closers (E)", "antiGapDash", false);
            MiscMenu.AddSeparator();
            MiscMenu.CreateSlider("Dash for combo into maximum [{0}] enemies", "maxEnemiesNear", 2, 0, 5);
            MiscMenu.AddSeparator();
            MiscMenu.CreateComboBox("Dash prediction", "dashPrediction", new List<string> { "S-Class Logic", "Mouse" });

            var skinList = S_Class_Library.DataBases.Skins.SkinsDB.FirstOrDefault(list => list.Champ == Player.Instance.Hero);
            if (skinList != null)
            {
                MiscMenu.CreateComboBox("Choose the skin", "skinComboBox", skinList.Skins);
                MiscMenu.Get<ComboBox>("skinComboBox").OnValueChange += delegate (ValueBase<int> sender, ValueBase<int>.ValueChangeArgs args)
                {
                    Player.Instance.SetSkinId(sender.CurrentValue);
                };
            }

            MiscMenu.AddGroupLabel("Auto Level UP");
            MiscMenu.CreateCheckBox("Activate Auto Leveler", "activateAutoLVL", false);
            MiscMenu.CreateSlider("Delay slider", "delaySlider", 200, 150, 500);

            
            DrawingsMenu.AddGroupLabel("Setting");
            DrawingsMenu.CreateCheckBox(" - Draw Spell`s range only if they are ready.", "readyDraw");
            DrawingsMenu.CreateCheckBox(" - Draw damage indicator.", "damageDraw");
            DrawingsMenu.CreateCheckBox(" - Draw damage indicator percent.", "perDraw");
            DrawingsMenu.CreateCheckBox(" - Draw damage indicator statistics.", "statDraw", false);
            DrawingsMenu.AddGroupLabel("Spells");
            DrawingsMenu.CreateCheckBox(" - Draw Q.", "qDraw");
            DrawingsMenu.CreateCheckBox(" - Draw W.", "wDraw");
            DrawingsMenu.CreateCheckBox(" - Draw E.", "eDraw");
            DrawingsMenu.CreateCheckBox(" - Draw R.", "rDraw");
            DrawingsMenu.AddGroupLabel("Drawings Color");
            QColorSlide = new ColorSlide(DrawingsMenu, "qColor", Color.Red, "Q Color:");
            WColorSlide = new ColorSlide(DrawingsMenu, "wColor", Color.Purple, "W Color:");
            EColorSlide = new ColorSlide(DrawingsMenu, "eColor", Color.Orange, "E Color:");
            RColorSlide = new ColorSlide(DrawingsMenu, "rColor", Color.DeepPink, "R Color:");
            DamageIndicatorColorSlide = new ColorSlide(DrawingsMenu, "healthColor", Color.YellowGreen, "DamageIndicator Color:");
        }
    }
}