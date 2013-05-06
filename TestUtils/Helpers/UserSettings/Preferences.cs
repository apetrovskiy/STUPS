/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 5/1/2013
 * Time: 3:47 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TestUtils
{
    
    /// <summary>
    /// Description of Preferences.
    /// </summary>
    public class Preferences
    {
        public Preferences()
        {
            // 20130430
            AutoLog = false;
        }
        
        // 20130429
        public static bool AutoLog { get; set; }
    }
}
