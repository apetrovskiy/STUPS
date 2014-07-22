/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/18/2012
 * Time: 2:11 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx
{
    using System;
    using System.Management.Automation;
	using TMX.Interfaces;
    using Tmx.Commands;
    
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
            
            // 20140721
            var dataObject = new GetTmxTestSuiteStatusDataObject {
                FilterOutAutomaticResults = cmdlet.FilterOutAutomaticResults,
                Name = cmdlet.Name,
                Id = cmdlet.Id,
                TestPlatformId = cmdlet.TestPlatformId
            };
            
            if (!string.IsNullOrEmpty(cmdlet.Name)) {
			    // 20140721
			    // 20140722
			    var result = 
    				TmxHelper.GetTestSuiteStatusByName(
    					// cmdlet,
    					// dataObject,
    					cmdlet.Name,
    					cmdlet.TestPlatformId,
    					cmdlet.FilterOutAutomaticResults);
                cmdlet.WriteObject(result);
            } else if (!string.IsNullOrEmpty(cmdlet.Id)) {
			    // 20140721
			    // 20140722
			    var result2 =
    				TmxHelper.GetTestSuiteStatusById(
    					// cmdlet,
    					// dataObject,
    					cmdlet.Id,
    					cmdlet.TestPlatformId,
    					cmdlet.FilterOutAutomaticResults);
                cmdlet.WriteObject(result2);
            } else {
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
}
