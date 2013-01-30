/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/9/2012
 * Time: 6:50 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of GetTLTestPlanCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "TLTestPlan", DefaultParameterSetName = "PipelineInput")]
    public class GetTLTestPlanCommand : TLGetTestPlanCmdletBase //TLTestPlanCmdletBase
    {
        public GetTLTestPlanCommand()
        {
        }
        
        #region Parameters
        #endregion Parameters
        
        protected override void ProcessRecord()
        {
            TLSrvGetTestPlanCommand command =
                new TLSrvGetTestPlanCommand(this);
            command.Execute();
        }
    }
}
