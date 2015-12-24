/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 6/15/2013
 * Time: 1:57 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Commands
{
    using System.Management.Automation;
    
    /// <summary>
    /// Description of InvokeTmxTestScenarioCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "TmxTestScenario")]
    public class InvokeTmxTestScenarioCommand : TestScenarioExecCmdletBase
    {
        protected override void BeginProcessing()
        {
            CheckCmdletParameters();
            
            TmxInvokeTestScenarioCommand command =
                new TmxInvokeTestScenarioCommand(this);
            command.Execute();
        }
    }
}
