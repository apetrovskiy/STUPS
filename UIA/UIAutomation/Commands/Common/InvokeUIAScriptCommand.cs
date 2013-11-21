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
    /// Description of InvokeUIAScriptCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UIAScript")]
    internal class InvokeUIAScriptCommand : HasTimeoutCmdletBase
    {
        #region Parameters
        [Parameter(Mandatory = true)]
        public ScriptBlock[] ScriptBlock { get; set; }
        #endregion Parameters
        
        protected override void BeginProcessing()
        {
            // RunScriptBlocks(this);
            this.SleepAndRunScriptBlocks(this);
        }
    }
}
