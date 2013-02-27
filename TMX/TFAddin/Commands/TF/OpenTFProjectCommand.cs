/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/9/2012
 * Time: 5:46 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of OpenTFProjectCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Open, "TFProject")]
    public class OpenTFProjectCommand : TFProjectCmdletBase
    {
        public OpenTFProjectCommand()
        {
        }
        
        protected override void BeginProcessing()
        {
            this.CheckCmdletParameters();
            
            TFSrvOpenProjectCommand command =
                new TFSrvOpenProjectCommand(this);
            command.Execute();
        }
    }
}
