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
    using System;
    using System.Management.Automation;

	/// <summary>
	/// Description of ShowUIAExecutionPlanCommand.
	/// </summary>
	[Cmdlet(VerbsCommon.Show, "UIAExecutionPlan")]
	public class ShowUIAExecutionPlanCommand : ExecutionPlanCmdletBase
	{
		public ShowUIAExecutionPlanCommand()
		{
		}
		
		#region Parameters
		[Parameter(Mandatory = false)]
		public int MaxControlsHighlighted { get; set; }
		#endregion Parameters
		
		protected override void BeginProcessing()
		{
			UIAutomation.ExecutionPlan.DisposeHighlighers();
			UIAutomation.ExecutionPlan.Init();
			CommonCmdletBase.HighlighterGeneration = 0;
			if (0 != this.MaxControlsHighlighted) {
				UIAutomation.ExecutionPlan.DecreaseMaxCount(
					this.MaxControlsHighlighted);
			}
			UIAutomation.Preferences.ShowExecutionPlan = true;
		}
	}
}
