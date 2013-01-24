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
	/// Description of HideUIAExecutionPlanCommand.
	/// </summary>
	[Cmdlet(VerbsCommon.Hide, "UIAExecutionPlan")]
	public class HideUIAExecutionPlanCommand : ExecutionPlanCmdletBase
	{
		public HideUIAExecutionPlanCommand()
		{
		}
		
		protected override void BeginProcessing()
		{
			UIAutomation.ExecutionPlan.DisposeHighlighers();
			UIAutomation.Preferences.ShowExecutionPlan = false;
		}
	}
}
