/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/14/2012
 * Time: 5:45 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of TLSrvAddBuildCommand.
    /// </summary>
    internal class TLSrvAddBuildCommand : TLSrvCommand
    {
        public TLSrvAddBuildCommand(TLSCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        internal override void Execute()
        {
            TLHelper.AddBuild(
                this.Cmdlet, 
                ((AddTLBuildCommand)this.Cmdlet).InputObject,
                //this.Cmdlet.Name,
                ((AddTLBuildCommand)this.Cmdlet).Name,
                ((AddTLBuildCommand)this.Cmdlet).Description);
        }
    }
}
