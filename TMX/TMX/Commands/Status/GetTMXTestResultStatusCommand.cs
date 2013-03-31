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
    /// Description of GetTMXTestResultStatusCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "TMXTestResultStatus")]
    public class GetTMXTestResultStatusCommand : TestResultCmdletBase
    {
        public GetTMXTestResultStatusCommand()
        {
        }
        
        protected override void BeginProcessing()
        {
            TMXGetTestResultStatusCommand command =
                new TMXGetTestResultStatusCommand(this);
            command.Execute();
        }
    }
}
