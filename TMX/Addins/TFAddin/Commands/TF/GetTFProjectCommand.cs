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
    /// Description of GetTFProjectCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "TFProject")]
    public class GetTFProjectCommand : TFProjectCmdletBase
    {
        protected override void BeginProcessing()
        {
            this.CheckCmdletParameters();
            
            TFSrvGetProjectCommand command =
                new TFSrvGetProjectCommand(this);
            command.Execute();
        }
    }
}
