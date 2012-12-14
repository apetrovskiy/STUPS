/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/20/2012
 * Time: 8:20 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of GetTLBuildCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "TLBuild")]
    public class GetTLBuildCommand : TLBuildCmdletBase
    {
        public GetTLBuildCommand()
        {
        }
        
        protected override void ProcessRecord()
        {
            TLHelper.checkTestPlan(this.InputObject);
            
            TLSrvGetBuildCommand command =
                new TLSrvGetBuildCommand(this);
            command.Execute();
        }
    }
}
