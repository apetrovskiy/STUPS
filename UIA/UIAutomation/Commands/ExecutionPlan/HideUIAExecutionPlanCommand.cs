/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/1/2012
 * Time: 6:08 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Commands
{
    using System.Management.Automation;

    /// <summary>
    /// Description of HideUiaExecutionPlanCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Hide, "UiaExecutionPlan")]
    public class HideUiaExecutionPlanCommand : ExecutionPlanCmdletBase
    {
        protected override void BeginProcessing()
        {
            ExecutionPlan.DisposeHighlighers();
            Preferences.ShowExecutionPlan = false;
        }
    }
}
