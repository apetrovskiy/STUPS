/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 19/01/2012
 * Time: 10:04 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */


namespace UIAutomation.Commands
{
    using System.Management.Automation;

    /// <summary>
    /// Description of InvokeUiaScriptCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UiaScript")]
    internal class InvokeUiaScriptCommand : HasTimeoutCmdletBase
    {
        #region Parameters
        [UiaParameter][Parameter(Mandatory = true)]
        public ScriptBlock[] ScriptBlock { get; set; }
        #endregion Parameters
        
        protected override void BeginProcessing()
        {
            // RunScriptBlocks(this);
            SleepAndRunScriptBlocks(this);
        }
    }
}
