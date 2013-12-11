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
    using System.Windows.Automation;
    
    /// <summary>
    /// Description of SourcePatternEmulator.
    /// </summary>
    public class SourcePatternEmulator
    {
        public static AutomationPattern Pattern { get; set; }
        
        public SourcePatternEmulator(object pattern)
        {
            Pattern = pattern;
        }
    }
}
