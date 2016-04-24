using System.Collections.Generic;
using EloBuddy.SDK;
using S_Class_Lucian.Logic;
using static S_Class_Lucian.SpellsManager;

namespace S_Class_Lucian.Modes
{
    /// <summary>
    /// This mode will always run
    /// </summary>
    internal class Active
    {
        /// <summary>
        /// Put in here what you want to do when the mode is running
        /// </summary>
        public static void Execute()
        {
            var spellsToKs = new List<Spell.SpellBase> { Q, W };
            Killsteal.Attempt(spellsToKs);
        }
    }
}