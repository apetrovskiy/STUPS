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
    /// Description of ShowUiaExecutionPlanCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Show, "UiaExecutionPlan")]
    public class ShowUiaExecutionPlanCommand : ExecutionPlanCmdletBase
    {
        #region Parameters
        [UiaParameter][Parameter(Mandatory = false)]
        public int MaxControlsHighlighted { get; set; }
        #endregion Parameters
        
        protected override void BeginProcessing()
        {
            ExecutionPlan.DisposeHighlighers();
            ExecutionPlan.Init();
            HighlighterGeneration = 0;
            if (0 != MaxControlsHighlighted) {
                ExecutionPlan.DecreaseMaxCount(
                // UIAutomation.ExecutionPlan.DecreaseMaxCount(
                    MaxControlsHighlighted);
            }
            Preferences.ShowExecutionPlan = true;
        }
    }
}
