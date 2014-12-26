/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/26/2014
 * Time: 3:48 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TestUtils.Commands
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of NewTuScheduledTaskCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "TuScheduledTask")]
    public class NewTuScheduledTaskCommand : CommonCmdletBase
    {
        protected override void BeginProcessing()
        {
            var command = new NewScheduledTaskCommand(this);
            command.Execute();
        }
    }
}
