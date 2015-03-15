/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/20/2012
 * Time: 8:20 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of GetTLBuildCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "TLBuild", DefaultParameterSetName = "ByName")]
    public class GetTLBuildCommand : TLBuildCmdletBase
    {
        protected override void ProcessRecord()
        {
            TLHelper.checkTestPlan(this.InputObject);
            
            var command = new TLSrvGetBuildCommand(this);
            command.Execute();
        }
    }
}
