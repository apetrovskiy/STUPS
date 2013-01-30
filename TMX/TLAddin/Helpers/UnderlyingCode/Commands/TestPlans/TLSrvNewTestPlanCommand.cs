/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/9/2012
 * Time: 7:35 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of TLSrvNewTestPlanCommand.
    /// </summary>
    internal class TLSrvNewTestPlanCommand : TLSrvCommand
    {
        internal TLSrvNewTestPlanCommand(TLSCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        internal override void Execute()
        {
            TLHelper.NewTestPlan(
                this.Cmdlet, 
                ((NewTLTestPlanCommand)this.Cmdlet).TestPlanName,
                ((NewTLTestPlanCommand)this.Cmdlet).Description, 
                ((NewTLTestPlanCommand)this.Cmdlet).Active);
        }
    }
}
