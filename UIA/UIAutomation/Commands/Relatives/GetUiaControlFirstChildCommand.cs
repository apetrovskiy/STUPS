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
    /// Description of GetUiaControlFirstChildCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaControlFirstChild", DefaultParameterSetName = "UiaWildCard")]
    public class GetUiaControlFirstChildCommand : GetFamilyCmdletBase //GetRelativesCmdletBase
    {
        /// <summary>
        /// Processes the pipeline.
        /// </summary>
        protected override void ProcessRecord()
        {
            // 20120824
            // 20131109
            //foreach (AutomationElement inputObject in this.InputObject) {
            foreach (IUiElement inputObject in InputObject) {
            
                GetAutomationElementsChildren(inputObject, true);
            
            } // 20120824
        }
    }
}
