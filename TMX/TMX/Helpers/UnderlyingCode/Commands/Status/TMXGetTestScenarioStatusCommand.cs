/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/18/2012
 * Time: 2:12 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx
{
    using System.Management.Automation;
    using Interfaces;
    using Commands;
    
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
            
            // 20140721
            var dataObject = new OpenScenarioCmdletBaseDataObject {
                // Description = cmdlet.de
                Id = cmdlet.Id,
                InputObject = cmdlet.InputObject,
                Name = cmdlet.Name,
                TestPlatformId = cmdlet.TestPlatformId,
                TestSuiteId = cmdlet.TestSuiteId,
                TestSuiteName = cmdlet.TestSuiteName
            };
            
            // 20140722
//            if (!string.IsNullOrEmpty(cmdlet.Name))
//                // 20140721
//                // TmxHelper.GetTestScenarioStatus(cmdlet, cmdlet.FilterOutAutomaticResults);
//                TmxHelper.GetTestScenarioStatus(dataObject, cmdlet.FilterOutAutomaticResults);
//            else if (!string.IsNullOrEmpty(cmdlet.Id))
//                // 20140721
//                // TmxHelper.GetTestScenarioStatus(cmdlet, cmdlet.FilterOutAutomaticResults);
//                TmxHelper.GetTestScenarioStatus(dataObject, cmdlet.FilterOutAutomaticResults);
            if (!string.IsNullOrEmpty(cmdlet.Name) || !string.IsNullOrEmpty(cmdlet.Id))
                cmdlet.WriteObject(TmxHelper.GetTestScenarioStatus(dataObject, cmdlet.FilterOutAutomaticResults));
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
