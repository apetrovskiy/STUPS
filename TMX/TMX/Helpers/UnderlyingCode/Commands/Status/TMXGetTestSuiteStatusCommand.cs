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
    
    /// <summary>
    /// Description of TMXGetTestSuiteStatusCommand.
    /// </summary>
    internal class TMXGetTestSuiteStatusCommand : TMXCommand
    {
        internal TMXGetTestSuiteStatusCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        internal override void Execute()
        {
            OpenSuiteCmdletBase cmdlet =
                (OpenSuiteCmdletBase)this.Cmdlet;
            if (null != cmdlet.Name && string.Empty != cmdlet.Name) {
                TMXHelper.GetTestSuiteStatusByName(
                    cmdlet,
                    cmdlet.Name);
            } else if (null != cmdlet.Id && string.Empty != cmdlet.Id) {
                TMXHelper.GetTestSuiteStatusById(
                    cmdlet,
                    cmdlet.Id);
            } else {
                TMXHelper.GetCurrentTestSuiteStatus(
                    cmdlet);
            }
        }
    }
}
