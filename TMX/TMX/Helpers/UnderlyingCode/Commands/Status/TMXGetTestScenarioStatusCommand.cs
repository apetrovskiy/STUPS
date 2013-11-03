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
    /// Description of TMXGetTestScenarioStatusCommand.
    /// </summary>
    internal class TMXGetTestScenarioStatusCommand : TMXCommand
    {
        internal TMXGetTestScenarioStatusCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        internal override void Execute()
        {
            // 20130322
            //OpenScenarioCmdletBase cmdlet =
            //    (OpenScenarioCmdletBase)this.Cmdlet;
            GetTMXTestScenarioStatusCommand cmdlet =
                (GetTMXTestScenarioStatusCommand)this.Cmdlet;
            
            if (!string.IsNullOrEmpty(cmdlet.Name)) {
                
                // 20130322
                TMXHelper.GetTestScenarioStatus(
                    //cmdlet);
                    cmdlet,
                    cmdlet.FilterOutAutomaticResults);
                
            } else if (!string.IsNullOrEmpty(cmdlet.Id)) {
                
                // 20130322
                TMXHelper.GetTestScenarioStatus(
                    //cmdlet);
                    cmdlet,
                    cmdlet.FilterOutAutomaticResults);
                
            } else {
                
                // 20130322
                // 20130918
                //TMXHelper.GetCurrentTestScenarioStatus(
                //    //cmdlet);
                //    cmdlet,
                //    cmdlet.FilterOutAutomaticResults);
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
}
