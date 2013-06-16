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
    /// Description of InvokeTMXTestSuiteCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "TMXTestSuite")]
    public class InvokeTMXTestSuiteCommand : TestSuiteExecCmdletBase
    {
        public InvokeTMXTestSuiteCommand()
        {
        }
        
        #region Parameters
        #endregion Parameters
        
        protected override void BeginProcessing()
        {
            this.CheckCmdletParameters();
            
            TMXInvokeTestSuiteCommand command =
                new TMXInvokeTestSuiteCommand(this);
            command.Execute();
        }
    }
}
