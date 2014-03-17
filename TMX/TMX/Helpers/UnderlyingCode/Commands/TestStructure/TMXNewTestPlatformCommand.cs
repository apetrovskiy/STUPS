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
    using PSTestLib;
    
    /// <summary>
    /// Description of TmxNewTestPlatformCommand.
    /// </summary>
    internal class TmxNewTestPlatformCommand : AbstractCommand // : TmxCommand
    {
        internal TmxNewTestPlatformCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        // internal override void Execute()
        public override void Execute()
        {
            var cmdlet =
                (NewPlatformCmdletBase)this.Cmdlet;
            
            bool result = 
                TMX.TmxHelper.NewTestPlatform(
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
