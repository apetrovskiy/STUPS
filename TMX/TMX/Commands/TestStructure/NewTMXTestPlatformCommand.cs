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
    /// Description of NewTMXTestPlatformCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "TMXTestPlatform")]
    public class NewTMXTestPlatformCommand : NewPlatformCmdletBase
    {
        public NewTMXTestPlatformCommand()
        {
        }
        
        protected override void BeginProcessing()
        {
            this.CheckCmdletParameters();
            
            TMXNewTestPlatformCommand command =
                new TMXNewTestPlatformCommand(this);
            command.Execute();
        }
    }
}
