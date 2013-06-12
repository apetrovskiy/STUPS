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
    /// Description of TMXGetTestSuiteStatusCommand.
    /// </summary>
    internal class TMXGetTestSuiteStatusCommand : TMXCommand
    {
        internal TMXGetTestSuiteStatusCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        internal override void Execute()
        {
            // 20130322
            //OpenSuiteCmdletBase cmdlet =
            //    (OpenSuiteCmdletBase)this.Cmdlet;
            GetTMXTestSuiteStatusCommand cmdlet =
                (GetTMXTestSuiteStatusCommand)this.Cmdlet;
            
            if (null != cmdlet.Name && string.Empty != cmdlet.Name) {
                
                // 20130322
                TMXHelper.GetTestSuiteStatusByName(
                    cmdlet,
                    // 20130322
                    //cmdlet.Name);
                    cmdlet.Name,
                    cmdlet.TestPlatformId,
                    cmdlet.FilterOutAutomaticResults);
                
            } else if (null != cmdlet.Id && string.Empty != cmdlet.Id) {
                
                // 20130322
                TMXHelper.GetTestSuiteStatusById(
                    cmdlet,
                    // 20130322
                    //cmdlet.Id);
                    cmdlet.Id,
                    cmdlet.TestPlatformId,
                    cmdlet.FilterOutAutomaticResults);
                
            } else {
                
                // 20130322
                TMXHelper.GetCurrentTestSuiteStatus(
                    // 20130322
                    //cmdlet);
                    cmdlet,
                    cmdlet.FilterOutAutomaticResults);
            }
        }
    }
}
