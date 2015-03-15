/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/14/2012
 * Time: 5:45 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx
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
                Cmdlet, 
                ((AddTLBuildCommand)Cmdlet).InputObject,
                ((AddTLBuildCommand)Cmdlet).Name,
                ((AddTLBuildCommand)Cmdlet).Description);
        }
    }
}
