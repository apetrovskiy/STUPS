/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/18/2012
 * Time: 2:11 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX
{
    using System;
    using System.Management.Automation;
    using TMX.Commands;
    
    /// <summary>
    /// Description of TmxGetTestSuiteStatusCommand.
    /// </summary>
    class TmxGetTestSuiteStatusCommand : TmxCommand
    {
        internal TmxGetTestSuiteStatusCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        internal override void Execute()
        {
            var cmdlet = (GetTmxTestSuiteStatusCommand)Cmdlet;
            
			if (!string.IsNullOrEmpty(cmdlet.Name))
				TmxHelper.GetTestSuiteStatusByName(
					cmdlet,
					cmdlet.Name,
					cmdlet.TestPlatformId,
					cmdlet.FilterOutAutomaticResults);
			else if (!string.IsNullOrEmpty(cmdlet.Id))
				TmxHelper.GetTestSuiteStatusById(
					cmdlet,
					cmdlet.Id,
					cmdlet.TestPlatformId,
					cmdlet.FilterOutAutomaticResults);
			else
				cmdlet.WriteError(
					cmdlet,
					"Failed to find test suite with name = '" +
					cmdlet.Name +
					"' and id = '" +
					cmdlet.Id +
					"'",
					"FailedToFindTestSuite",
					ErrorCategory.InvalidArgument,
					true);
        }
    }
}
