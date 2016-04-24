using System;
using System.Collections.Generic;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;
using SharpDX;
using S_Class_Lucian.Logic;
using static S_Class_Lucian.Constants;

namespace S_Class_Lucian
{
    public static class SpellsManager
    {
        /*
        Targeted spells are like Katarina`s Q
        Active spells are like Katarina`s W
        Skillshots are like Ezreal`s Q
        Circular Skillshots are like Lux`s E and Tristana`s W
        Cone Skillshots are like Annie`s W and ChoGath`s W
        */

        //Remenber of putting the correct type of the spell here
        public static Spell.Targeted Q;
        public static Spell.Skillshot W;
        public static Spell.Skillshot E;
        public static Spell.Skillshot R;
        public static Spell.Skillshot QExtended;

        public static List<Spell.SpellBase> SpellList = new List<Spell.SpellBase>();

        public static void InitializeSpells()
        {
            // Regular spells
            Q = new Spell.Targeted(SpellSlot.Q, 675);
            W = new Spell.Skillshot(SpellSlot.W, 1000, SkillShotType.Linear, 250, 1600, 80);
            E = new Spell.Skillshot(SpellSlot.E, 475, SkillShotType.Linear);
            R = new Spell.Skillshot(SpellSlot.R, 1200, SkillShotType.Linear, 500, 2800, 110);

            // Extended spells
            QExtended = new Spell.Skillshot(SpellSlot.Q, 1400, SkillShotType.Linear);

            SpellList.Add(Q);
            SpellList.Add(W);
            SpellList.Add(E);
            SpellList.Add(R);
            SpellList.Add(QExtended);
        }

        #region Damages

        public static float GetDamage(this Obj_AI_Base target, SpellSlot slot)
        {
            const DamageType damageType = DamageType.Physical;
            var AD = Self.FlatPhysicalDamageMod;
            var AP = Self.FlatMagicDamageMod;
            var sLevel = Player.GetSpell(slot).Level - 1;
            var dmg = 0f;

            switch (slot)
            {
                case SpellSlot.Q:
                    if (Q.IsReady())
                    {
                        //Information of Q damage
                        dmg += new float[] {80, 110, 140, 170, 200}[sLevel] + 1.2f*AD;
                        dmg += Self.GetAutoAttackDamage(target) * 0.5f;
                    }
                    break;
                case SpellSlot.W:
                    if (W.IsReady())
                    {
                        //Information of W damage
                        dmg += new float[] {60, 100, 140, 180, 220}[sLevel] + 0.9f*AP;
                        dmg += Self.GetAutoAttackDamage(target) * 1.5f;
                    }
                    break;
                case SpellSlot.E:
                    if (E.IsReady())
                    {
                        //Information of E damage
                        dmg += Self.GetAutoAttackDamage(target) * 1.5f;
                    }
                    break;
                case SpellSlot.R:
                    if (R.IsReady())
                    {
                        //Information of R damage
                        //dmg += new float[] {600, 840, 1080}[sLevel]*0.6f + 1.2f*AP;
                    }
                    break;
            }
            return Player.Instance.CalculateDamageOnUnit(target, damageType, dmg - 10);
        }

        #endregion Damages
    
        public static float GetComboDamage(Obj_AI_Base target)
        {
            const DamageType damageType = DamageType.Physical;
            var AD = Self.FlatPhysicalDamageMod;
            var AP = Self.FlatMagicDamageMod;
            var dmg = 0f;

            if (Q.IsReady())
            {
                //Information of Q damage
                dmg += new float[] { 80, 110, 140, 170, 200 }[Player.GetSpell(SpellSlot.Q).Level - 1] + 1.2f * AD;
                dmg += Player.Instance.GetAutoAttackDamage(target) * 0.5f;
            }

            if (W.IsReady())
            {
                //Information of W damage
                dmg += new float[] { 60, 100, 140, 180, 220 }[Player.GetSpell(SpellSlot.Q).Level - 1] + 0.9f * AP;
                dmg += Player.Instance.GetAutoAttackDamage(target) * 1.5f;
            }


            if (E.IsReady())
            {
                //Information of E damage
                dmg += Player.Instance.GetAutoAttackDamage(target) * 1.5f;
            }

            return Self.CalculateDamageOnUnit(target, damageType, (float)Math.Floor((dmg - 10) * 0.8));
        }

        public static int GetComboCastDelay()
        {
            var delay = 0;

            if (Q.IsReady())
                delay += Q.CastDelay;

            if (W.IsReady())
                delay += W.CastDelay;

            if (E.IsReady())
                delay += E.CastDelay;

            return delay;
        }

        public static SpellSlot GetSlotFromName(this string value)
        {
            switch (value)
            {
                case "Q":
                    return SpellSlot.Q;
                case "W":
                    return SpellSlot.W;
                case "E":
                    return SpellSlot.E;
                case "R":
                    return SpellSlot.R;
            }
            Chat.Print("Failed getting slot");
            return SpellSlot.Unknown;
        }

        public static void CastQExtended(AIHeroClient target)
        {
            if (!target.IsValidTarget(QExtended.Range))
                return;

            var predPos = QExtended.GetPrediction(target);
            var minions =
                EntityManager.MinionsAndMonsters.EnemyMinions.Where(m => m.Distance(ObjectManager.Player) <= Q.Range);
            var champs = EntityManager.Heroes.Enemies.Where(m => m.Distance(ObjectManager.Player) <= Q.Range);
            var monsters =
                EntityManager.MinionsAndMonsters.Monsters.Where(m => m.Distance(ObjectManager.Player) <= Q.Range);
            {
                foreach (var minion in from minion in minions
                                       let polygon = new Geometry.Polygon.Rectangle(
                                           ObjectManager.Player.ServerPosition.To2D(),
                                           ObjectManager.Player.ServerPosition.Extend(minion.ServerPosition, QExtended.Range), 65f)
                                       where polygon.IsInside(predPos.CastPosition)
                                       select minion)
                {
                    Q.Cast(minion);
                }

                foreach (var champ in from champ in champs
                                      let polygon = new Geometry.Polygon.Rectangle(
                                          ObjectManager.Player.ServerPosition.To2D(),
                                          ObjectManager.Player.ServerPosition.Extend(champ.ServerPosition, QExtended.Range), 65f)
                                      where polygon.IsInside(predPos.CastPosition)
                                      select champ)
                {
                    Q.Cast(champ);
                }

                foreach (var monster in from monster in monsters
                                        let polygon = new Geometry.Polygon.Rectangle(
                                           ObjectManager.Player.ServerPosition.To2D(),
                                           ObjectManager.Player.ServerPosition.Extend(monster.ServerPosition, QExtended.Range), 65f)
                                        where polygon.IsInside(predPos.CastPosition)
                                        select monster)
                {
                    Q.Cast(monster);
                }
            }
        }

        public static void CastW(Vector3 position)
        {
            if (!W.IsReady())
                return;

            W.Cast(position);
        }

        public static void CastR(AIHeroClient target)
        {
            // Check if target is within range
            if (!target.IsAttackable(false) || !target.WithinRange(R.Range))
                return;

            var prediction = Prediction.Position.PredictLinearMissile(target, R.Range, R.Width, R.CastDelay, R.Speed, 0, null, true);
            var spellDamage = new float[]{20, 25, 30}[R.Level] * (new float[] {20, 35, 50}[R.Level] + Self.TotalAttackDamage * 0.2f + Self.TotalMagicalDamage * 0.1);
            var calculatedDamage = Self.CalculateDamageOnUnit(target, DamageType.Mixed, (float)Math.Floor((spellDamage - 10) * 0.8));
            var distance = Self.Distance(target);

            if ((Q.IsReady() && target.WithinRange(EffectiveSkillRange)) ||
                (prediction.HitChance == HitChance.Collision &&
                 prediction.CollisionObjects.OfType<Obj_AI_Minion>().Count() > 3)) return;

            var damageRequiredMod = new float[] {0.8f, 0.7f, 0.6f, 0.5f, 0.4f, 0.3f};
            var maximumDistance = new float[] {700, 800, 900, 1000, 1100, 1200};

            for (var i = 0; i < damageRequiredMod.Count(); i++)
            {
                if (calculatedDamage*damageRequiredMod[i] > target.Health && distance < maximumDistance[i])
                {
                    Player.CastSpell(SpellSlot.R, target.ServerPosition);
                }
            } 
        }
    }
}