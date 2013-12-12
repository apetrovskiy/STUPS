/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/12/2013
 * Time: 11:04 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Commands
{
    extern alias UIANET;
    using System.Management.Automation;
    using System.Windows.Automation;

    /// <summary>
    /// Description of GetUiaControlAncestorsCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaControlAncestors", DefaultParameterSetName = "UiaWildCard")]
    
    public class GetUiaControlAncestorsCommand : GetRelativesCmdletBase
    {
        /// <summary>
        /// Processes the pipeline.
        /// </summary>
        protected override void ProcessRecord()
        {
            GetAutomationElements(TreeScope.Ancestors);
        }
    }
}
