/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/9/2012
 * Time: 6:51 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of GetTLProjectCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "TLProject", DefaultParameterSetName = "ByName")]
    public class GetTLProjectCommand : TLProjectCmdletBase
    {
        protected override void BeginProcessing()
        {
            CheckCmdletParameters();
            
            var command = new TLSrvGetProjectCommand(this);
            command.Execute();
        }
    }
}
