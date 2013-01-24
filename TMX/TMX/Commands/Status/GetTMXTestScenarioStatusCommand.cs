/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/18/2012
 * Time: 2:01 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX.Commands
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of GetTMXTestScenarioStatusCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "TMXTestScenarioStatus")]
    public class GetTMXTestScenarioStatusCommand : OpenScenarioCmdletBase
    {
        public GetTMXTestScenarioStatusCommand()
        {
        }
        
        protected override void BeginProcessing()
        {
            TMXGetTestScenarioStatusCommand command =
                new TMXGetTestScenarioStatusCommand(this);
            command.Execute();
        }
    }
}
