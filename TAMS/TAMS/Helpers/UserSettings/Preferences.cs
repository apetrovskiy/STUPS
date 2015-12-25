/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 4/30/2013
 * Time: 3:01 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TAMS
{
    /// <summary>
    /// Description of Preferences.
    /// </summary>
    public static class Preferences
    {
        static Preferences()
        {
            // 20130430
            AutoLog = false;
        }
        
        // 20130429
        public static bool AutoLog { get; set; }
    }
}
