/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/12/2013
 * Time: 11:03 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Commands
{
    extern alias UIANET;using System.Windows.Automation;
    using System.Management.Automation;
    using classic = UIANET::System.Windows.Automation; // using System.Windows.Automation;

    /// <summary>
    /// Description of GetUiaControlDescendantsCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaControlDescendants", DefaultParameterSetName = "UiaWildCard")]
    public class GetUiaControlDescendantsCommand : GetRelativesCmdletBase
    {
        /// <summary>
        /// Processes the pipeline.
        /// </summary>
        protected override void ProcessRecord()
        {
            GetAutomationElements(classic.TreeScope.Descendants);
        }
    }
}
