/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 6/15/2013
 * Time: 1:37 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX.Commands
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of InvokeTmxTestSuiteCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "TmxTestSuite")]
    public class InvokeTmxTestSuiteCommand : TestSuiteExecCmdletBase
    {
        public InvokeTmxTestSuiteCommand()
        {
        }
        
        #region Parameters
        #endregion Parameters
        
        protected override void BeginProcessing()
        {
            this.CheckCmdletParameters();
            
            TmxInvokeTestSuiteCommand command =
                new TmxInvokeTestSuiteCommand(this);
                // new TmxInvokeTestSuiteCommand() { Cmdlet = this };
            command.Execute();
        }
    }
}
