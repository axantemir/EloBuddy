using System;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Constants;
using EloBuddy.SDK.Events;
using S_Class_Library;
using static S_Class_Lucian.SpellsManager;
using static S_Class_Lucian.Menus;
using static S_Class_Lucian.Constants;


namespace S_Class_Lucian
{
    internal class Events
    {
        public static void InitializeEvents()
        {
            Gapcloser.OnGapcloser += Gapcloser_OnGapCloser;
            Obj_AI_Base.OnSpellCast += Obj_AI_Base_OnProcessSpellCast;
            Chat.OnInput += Chat_OnInput;
            Obj_AI_Base.OnLevelUp += Obj_AI_Base_OnLevelUp;
        }

        public static void Obj_AI_Base_OnLevelUp(Obj_AI_Base sender, Obj_AI_BaseLevelUpEventArgs args)
        {
            if (MiscMenu.GetCheckBoxValue("activateAutoLVL") && sender.IsMe)
            {
                Random rnd = new Random();
                var delay = MiscMenu.GetSliderValue("delaySlider") + rnd.Next((int)Math.Ceiling(MiscMenu.GetSliderValue("delaySlider") * 0.5), (int)MiscMenu.GetSliderValue("delaySlider"));
                Core.DelayAction(LevelUpSpells, delay);
            }
        }

        private static void LevelUpSpells()
        {
            // Prioritize R
            if (Player.Instance.Spellbook.CanSpellBeUpgraded(SpellSlot.R))
            {
                Player.Instance.Spellbook.LevelSpell(SpellSlot.R);
            }

            // Follow Skill Order if possible
            var spellToLearn = SkillOrder[(Player.Instance.Level - 1)].GetSlotFromName();
            if (Player.Instance.Spellbook.CanSpellBeUpgraded(spellToLearn))
            {
                Player.Instance.Spellbook.LevelSpell(spellToLearn);
            }

            // Fallbacks
            foreach (var spellSlot in SkillPriority.Select(SpellsManager.GetSlotFromName).Where(spellSlot => Player.Instance.Spellbook.CanSpellBeUpgraded(spellSlot)))
            {
                Player.Instance.Spellbook.LevelSpell(spellSlot);
            }
        }

        private static void Chat_OnInput(ChatInputEventArgs args)
        {
            if (args.Input.Contains("//buffs"))
            {
                args.Process = false;
                Chat.Print("Listing buffs:");
                foreach (var buff in Self.Buffs)
                {
                    Chat.Print(buff.DisplayName);
                }
            } else if (args.Input.Contains("//sw"))
            {
                args.Process = false;
                Chat.Print("Spellweaving: " + States.Spellweaving);
            }
        }

        private static void Gapcloser_OnGapCloser(AIHeroClient target, Gapcloser.GapcloserEventArgs args)
        {
            if (!MiscMenu.GetCheckBoxValue("antiGapDash") || target.IsMe) return;

            // Only trigger if target is enemy, within AA range and in gapcloser list
            if (!target.IsEnemy || !args.End.WithinRange(target.GetEffectiveRange()) ||
                DangerousGapClosers.Any(target.ChampionName.Contains)) return;

            // Predict best flee position
            var predictedPosition = Logic.Dash.Flee(target).Position;
            
            // Flee if E is ready and position is good
            if (E.IsReady() && predictedPosition != Self.ServerPosition)
            {
                Player.CastSpell(SpellSlot.E, predictedPosition);
            }
        }

        private static void Obj_AI_Base_OnProcessSpellCast(Obj_AI_Base unit, GameObjectProcessSpellCastEventArgs args)
        {
            // WAD?
            if (unit.IsMe && (args.Slot == SpellSlot.E || args.Slot == SpellSlot.W))
            {
                //Core.DelayAction(() => Orbwalker.ResetAutoAttack(), 450);
            }

            // Anti-melee (E)
            if (MiscMenu.GetCheckBoxValue("antiMeleeDash"))
            {
                
                if (args.Target.IsMe && unit.Type == GameObjectType.AIHeroClient && unit.IsEnemy && unit.IsMelee &&
                    args.SData.IsAutoAttack() && E.IsReady())
                {
                    var predictedPosition = Logic.Dash.Flee((AIHeroClient)unit).Position;

                    if (predictedPosition.EnemiesWithinRange(NearRange) <= Self.EnemiesWithinRange(NearRange) &&
                        !predictedPosition.IsUnderTurret())
                    {
                        Player.CastSpell(SpellSlot.E, predictedPosition);
                    }
                }
            }
        }
    }
}