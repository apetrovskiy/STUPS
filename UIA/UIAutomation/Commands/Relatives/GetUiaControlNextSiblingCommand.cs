/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/12/2013
 * Time: 11:05 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Commands
{
    extern alias UIANET;using System.Windows.Automation;
    using System.Management.Automation;
    using classic = UIANET::System.Windows.Automation; // using System.Windows.Automation;

    /// <summary>
    /// Description of GetUiaControlNextSiblingCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaControlNextSibling", DefaultParameterSetName = "UiaWildCard")]
    public class GetUiaControlNextSiblingCommand : GetFamilyCmdletBase //GetRelativesCmdletBase
    {
        /// <summary>
        /// Processes the pipeline.
        /// </summary>
        protected override void ProcessRecord()
        {
            GetAutomationElementsSiblings(true);
        }
    }
}
