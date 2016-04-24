using EloBuddy;
using EloBuddy.SDK;
using S_Class_Library;
using static S_Class_Lucian.SpellsManager;

namespace S_Class_Lucian.Modes
{
    /// <summary>
    /// This mode will always run
    /// </summary>
    internal class AutoHarass
    {
        /// <summary>
        /// Put in here what you want to do when the mode is running
        /// </summary>
        public static void Execute()
        {
            var target = TargetSelector.GetTarget(SpellList.GetHighestRange(), DamageType.Mixed);
        }
    }
}