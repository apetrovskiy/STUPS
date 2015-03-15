/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/9/2012
 * Time: 7:35 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of TFSrvNewTestPlanCommand.
    /// </summary>
    internal class TFSrvNewTestPlanCommand : TFSrvCommand
    {
        internal TFSrvNewTestPlanCommand(TFSCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        internal override void Execute()
        {
            TFHelper.NewTestPlan(this.Cmdlet, this.Cmdlet.Name);
        }
    }
}
