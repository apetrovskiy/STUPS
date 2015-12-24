/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/20/2012
 * Time: 8:22 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of TLSrvGetBuildCommand.
    /// </summary>
    internal class TLSrvGetBuildCommand : TLSrvCommand
    {
        internal TLSrvGetBuildCommand(TLSCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        internal override void Execute()
        {
            var cmdlet = (TLBuildCmdletBase)Cmdlet;
            
            if (null != cmdlet.Id && 0 < cmdlet.Id.Length) {
                
                cmdlet.WriteError(
                    cmdlet,
                    "Not implemented",
                    "NotImplemented",
                    ErrorCategory.InvalidResult,
                    true);
                
            } else {

                TLHelper.GetBuild(
                    Cmdlet, 
                    ((GetTLBuildCommand)Cmdlet).InputObject,
                    ((GetTLBuildCommand)Cmdlet).Name);
                
            }
        }
    }
}
