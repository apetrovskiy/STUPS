/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/12/2013
 * Time: 11:02 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Commands
{
    extern alias UIANET;
    using System.Management.Automation;
    using System.Windows.Automation;

    /// <summary>
    /// Description of GetUiaControlChildrenCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaControlChildren", DefaultParameterSetName = "UiaWildCard")]
    public class GetUiaControlChildrenCommand : GetRelativesCmdletBase
    {
        /// <summary>
        /// Processes the pipeline.
        /// </summary>
        protected override void ProcessRecord()
        {
            GetAutomationElements(TreeScope.Children);
        }
    }
}
