/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 6/15/2013
 * Time: 4:17 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Commands
{
    using System.Management.Automation;
    
    /// <summary>
    /// Description of InvokeTmxTestCaseCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "TmxTestCase")]
    public class InvokeTmxTestCaseCommand : TestCaseExecCmdletBase
    {
        protected override void BeginProcessing()
        {
            CheckCmdletParameters();
            
            TmxInvokeTestCaseCommand command =
                new TmxInvokeTestCaseCommand(this);
            command.Execute();
        }
    }
}
