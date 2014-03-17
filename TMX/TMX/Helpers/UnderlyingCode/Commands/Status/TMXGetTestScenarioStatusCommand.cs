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
    using PSTestLib;
    
    /// <summary>
    /// Description of TmxGetTestScenarioStatusCommand.
    /// </summary>
    internal class TmxGetTestScenarioStatusCommand : AbstractCommand // : TmxCommand
    {
        internal TmxGetTestScenarioStatusCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        // internal override void Execute()
        public override void Execute()
        {
            // 20130322
            //OpenScenarioCmdletBase cmdlet =
            //    (OpenScenarioCmdletBase)this.Cmdlet;
            var cmdlet =
                (GetTmxTestScenarioStatusCommand)this.Cmdlet;
            
            if (!string.IsNullOrEmpty(cmdlet.Name)) {
                
                // 20130322
                TmxHelper.GetTestScenarioStatus(
                    //cmdlet);
                    cmdlet,
                    cmdlet.FilterOutAutomaticResults);
                
            } else if (!string.IsNullOrEmpty(cmdlet.Id)) {
                
                // 20130322
                TmxHelper.GetTestScenarioStatus(
                    //cmdlet);
                    cmdlet,
                    cmdlet.FilterOutAutomaticResults);
                
            } else {
                
                // 20130322
                // 20130918
                //TmxHelper.GetCurrentTestScenarioStatus(
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
