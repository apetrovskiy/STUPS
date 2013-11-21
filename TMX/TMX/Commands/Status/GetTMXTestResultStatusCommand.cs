/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 3/31/2013
 * Time: 8:36 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX.Commands
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of GetTmxTestResultStatusCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "TmxTestResultStatus")]
    public class GetTmxTestResultStatusCommand : TestResultStatusCmdletBase //TestResultCmdletBase
    {
        public GetTmxTestResultStatusCommand()
        {
        }
        
        protected override void BeginProcessing()
        {
            TmxGetTestResultStatusCommand command =
                new TmxGetTestResultStatusCommand(this);
            command.Execute();
        }
    }
}
