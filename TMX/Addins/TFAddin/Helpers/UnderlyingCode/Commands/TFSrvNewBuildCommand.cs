/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 4/9/2013
 * Time: 4:37 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of TFSrvNewBuildCommand.
    /// </summary>
    internal class TFSrvNewBuildCommand : TFSrvCommand
    {
        internal TFSrvNewBuildCommand(TFSCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        internal override void Execute()
        {
            TFHelper.NewBuild(this.Cmdlet, this.Cmdlet.Name);
        }
    }
}
