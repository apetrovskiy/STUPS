/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/20/2012
 * Time: 8:22 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX
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
            TLHelper.GetBuild(
                this.Cmdlet, 
                ((GetTLBuildCommand)this.Cmdlet).InputObject,
                //this.Cmdlet.Name);
                ((GetTLBuildCommand)this.Cmdlet).Name);
        }
    }
}
