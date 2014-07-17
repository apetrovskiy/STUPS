/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/18/2012
 * Time: 2:12 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX
{
    using System;
    using System.Management.Automation;
    using TMX.Commands;
    
    /// <summary>
    /// Description of TmxGetTestScenarioStatusCommand.
    /// </summary>
    class TmxGetTestScenarioStatusCommand : TmxCommand
    {
        internal TmxGetTestScenarioStatusCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        internal override void Execute()
        {
            var cmdlet = (GetTmxTestScenarioStatusCommand)Cmdlet;
            
			if (!string.IsNullOrEmpty(cmdlet.Name))
				TmxHelper.GetTestScenarioStatus(cmdlet, cmdlet.FilterOutAutomaticResults);
			else if (!string.IsNullOrEmpty(cmdlet.Id))
				TmxHelper.GetTestScenarioStatus(cmdlet, cmdlet.FilterOutAutomaticResults);
			else
				cmdlet.WriteError(
					cmdlet,
					"Failed to find test scenario with name = '" +
					cmdlet.Name +
					"' and id = '" +
					cmdlet.Id +
					"'",
					"FailedToFindTestScenario",
					ErrorCategory.InvalidArgument,
					true);
        }
    }
}
