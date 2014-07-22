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
    /// Description of NewTLTestPlanCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "TLTestPlan", DefaultParameterSetName = "PipelineInput")]
    public class NewTLTestPlanCommand : TLAddTestPlanCmdletBase
    {
        public NewTLTestPlanCommand()
        {
            this.Active = true;
        }
        
        protected override void ProcessRecord()
        {
            var command = new TLSrvNewTestPlanCommand(this);
            command.Execute();
        }
    }
}
