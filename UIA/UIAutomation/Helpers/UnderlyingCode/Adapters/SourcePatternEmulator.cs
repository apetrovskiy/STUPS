/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/11/2013
 * Time: 7:14 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    extern alias UIANET; extern alias UIACOM;// using System.Windows.Automation;
    using classic = UIANET::System.Windows.Automation; using viacom = UIACOM::System.Windows.Automation; // using System.Windows.Automation;
    
    /// <summary>
    /// Description of SourcePatternEmulator.
    /// </summary>
    public class SourcePatternEmulator
    {
        public static classic.AutomationPattern Pattern { get; set; }
        
        public SourcePatternEmulator(object pattern)
        {
            Pattern = pattern as classic.AutomationPattern;
        }
    }
}
