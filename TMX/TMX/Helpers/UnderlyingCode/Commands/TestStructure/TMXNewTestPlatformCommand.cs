/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 5/31/2013
 * Time: 4:13 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of TMXNewTestPlatformCommand.
    /// </summary>
    internal class TMXNewTestPlatformCommand : TMXCommand
    {
        internal TMXNewTestPlatformCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        internal override void Execute()
        {
            NewPlatformCmdletBase cmdlet =
                (NewPlatformCmdletBase)this.Cmdlet;
            
            bool result = 
                TMX.TMXHelper.NewTestPlatform(
                    cmdlet.Name,
                    cmdlet.Id,
                    cmdlet.Description,
                    cmdlet.OperatingSystem,
                    cmdlet.Version,
                    cmdlet.Architecture,
                    cmdlet.Language);
            if (result) {

                cmdlet.WriteObject(cmdlet, TestData.CurrentTestPlatform);
            } else {
                
                cmdlet.WriteError(
                    cmdlet,
                    "Couldn't create a test platform",
                    "CreatingTestPlatform",
                    ErrorCategory.InvalidArgument,
                    true);
            }
        }
    }
}
