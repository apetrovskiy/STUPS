/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/9/2012
 * Time: 5:47 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of NewTFTestPlanCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "TFTestPlan")]
    public class NewTFTestPlanCommand : TFTestPlanCmdletBase
    {
        protected override void BeginProcessing()
        {
            this.CheckCmdletParameters();
            
            TFSrvNewTestPlanCommand command =
                new TFSrvNewTestPlanCommand(this);
            command.Execute();
        }
    }
}
