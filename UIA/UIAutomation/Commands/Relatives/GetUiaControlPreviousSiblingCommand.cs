/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/12/2013
 * Time: 11:06 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Commands
{
    extern alias UIANET; extern alias UIACOM;// using System.Windows.Automation;
    using System.Management.Automation;
    using classic = UIANET::System.Windows.Automation; using viacom = UIACOM::System.Windows.Automation; // using System.Windows.Automation;

    /// <summary>
    /// Description of GetUiaControlPreviousSiblingCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaControlPreviousSibling", DefaultParameterSetName = "UiaWildCard")]
    public class GetUiaControlPreviousSiblingCommand : GetFamilyCmdletBase // GetRelativesCmdletBase
    {
        /// <summary>
        /// Processes the pipeline.
        /// </summary>
        protected override void ProcessRecord()
        {
            GetAutomationElementsSiblings(false);
        }
    }
}
