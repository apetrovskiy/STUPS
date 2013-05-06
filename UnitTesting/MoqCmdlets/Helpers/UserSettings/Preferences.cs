/*
 * Created by SharpDevelop.
 * User: APetrovsky
 * Date: 5/1/2013
 * Time: 10:08 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace MoqCmdlets
{
    /// <summary>
    /// Description of Preferences.
    /// </summary>
    public class Preferences
    {
        public Preferences()
        {
            // 20130501
            AutoLog = false;
        }
        
        // 20130501
        public static bool AutoLog { get; set; }
    }
}
