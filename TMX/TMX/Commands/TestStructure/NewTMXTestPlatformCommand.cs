/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 5/31/2013
 * Time: 3:34 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX.Commands
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of NewTmxTestPlatformCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "TmxTestPlatform")]
    public class NewTmxTestPlatformCommand : NewPlatformCmdletBase
    {
        public NewTmxTestPlatformCommand()
        {
        }
        
        protected override void BeginProcessing()
        {
            this.CheckCmdletParameters();
            
            TmxNewTestPlatformCommand command =
                new TmxNewTestPlatformCommand(this);
            command.Execute();
        }
    }
}
