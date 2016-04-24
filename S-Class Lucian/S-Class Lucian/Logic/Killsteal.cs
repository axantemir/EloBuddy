using System;
using System.Collections.Generic;
using System.Linq;
using EloBuddy.SDK;
using S_Class_Library;

namespace S_Class_Lucian.Logic
{
    internal class Killsteal
    {
        public static bool Attempt(List<Spell.SpellBase> spells)
        {
            var target =
                EntityManager.Heroes.Enemies.OrderBy(e => e.Health)
                    .ThenByDescending(TargetSelector.GetPriority)
                    .ThenBy(e => e.FlatArmorMod)
                    .ThenBy(e => e.FlatMagicReduction)
                    .FirstOrDefault(e => e.IsValidTarget(spells.GetSmallestRange()) && !e.HasUndyingBuff());

            if (target != null)
            {
                var dmg = spells.Where(spell => spell.IsReady()).Sum(spell => target.GetDamage(spell.Slot));
                var delay = spells.Sum(s => s.CastDelay);
                var targetPredictedHealth = Prediction.Health.GetPrediction(target, delay);

                if (targetPredictedHealth <= dmg)
                {
                    foreach (var spell in spells.Where(s => target.CanCastSpell(s)))
                    {
                        try
                        {
                            spell.Cast();
                        }
                        catch (Exception)
                        {
                            spell.Cast(target);
                        }
                    }
                }
            }
            return false;
        }
    }
}