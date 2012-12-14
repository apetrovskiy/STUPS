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
    public class GetTLTestPlanCommand : TLTestPlanCmdletBase
    {
        public GetTLTestPlanCommand()
        {
        }
        
        #region Parameters
        [Parameter(Mandatory = false,
                   ParameterSetName = "PipelineInput")]
        [Parameter(Mandatory = false,
                   ParameterSetName = "StringInput")]
        [Parameter(Mandatory = false,
                   ParameterSetName = "FromStore")]
        public new string[] TestPlanName { get; set; }
        #endregion Parameters
        
        protected override void ProcessRecord()
        {
            TLSrvGetTestPlanCommand command =
                new TLSrvGetTestPlanCommand(this);
            command.Execute();
        }
    }
}
