/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/20/2014
 * Time: 12:09 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Commands
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of ReceiveTmxTestReportCommand.
    /// </summary>
    [Cmdlet(VerbsCommunications.Receive, "TmxTestReport")]
    public class ReceiveTmxTestReportCommand : ClientCmdletBase
    {
        protected override void BeginProcessing()
        {
            var command = new ReceiveTestResportCommand(this);
            command.Execute();
        }
    }
}
