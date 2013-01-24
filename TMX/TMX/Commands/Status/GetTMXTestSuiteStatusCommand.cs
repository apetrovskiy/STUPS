/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/18/2012
 * Time: 2:00 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX.Commands
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of GetTMXTestSuiteStatusCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "TMXTestSuiteStatus")]
    public class GetTMXTestSuiteStatusCommand : OpenSuiteCmdletBase
    {
        public GetTMXTestSuiteStatusCommand()
        {
        }
        
        protected override void BeginProcessing()
        {
            TMXGetTestSuiteStatusCommand command =
                new TMXGetTestSuiteStatusCommand(this);
            command.Execute();
        }
    }
}
