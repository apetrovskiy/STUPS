/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 10/22/2014
 * Time: 8:39 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Commands
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of ReceiveTmxTestResultsCommand.
    /// </summary>
    [Cmdlet(VerbsCommunications.Receive, "TmxTestResults")]
    public class ReceiveTmxTestResultsCommand : ClientCmdletBase
    {
        protected override void BeginProcessing()
        {
            var command = new ReceiveTestResultsCommand(this);
            command.Execute();
        }
    }
}
