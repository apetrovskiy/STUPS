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
				Cmdlet, 
				((NewTLTestPlanCommand)Cmdlet).TestPlanName,
				((NewTLTestPlanCommand)Cmdlet).Description, 
				((NewTLTestPlanCommand)Cmdlet).Active);
        }
    }
}
