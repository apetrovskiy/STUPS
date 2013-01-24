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
            OpenScenarioCmdletBase cmdlet =
                (OpenScenarioCmdletBase)this.Cmdlet;
            if (null != cmdlet.Name && string.Empty != cmdlet.Name) {
                TMXHelper.GetTestScenarioStatus(
                    cmdlet);
            } else if (null != cmdlet.Id && string.Empty != cmdlet.Id) {
                TMXHelper.GetTestScenarioStatus(
                    cmdlet);
            } else {
                TMXHelper.GetCurrentTestScenarioStatus(
                    cmdlet);
            }
        }
    }
}
