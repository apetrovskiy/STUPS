/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/9/2012
 * Time: 7:34 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of TFSrvGetTestPlanCommand.
    /// </summary>
    internal class TFSrvGetTestPlanCommand : TFSrvCommand
    {
        internal TFSrvGetTestPlanCommand(TFSCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        internal override void Execute()
        {
            TFHelper.GetTestPlan(this.Cmdlet, this.Cmdlet.Name);
        }
    }
}
