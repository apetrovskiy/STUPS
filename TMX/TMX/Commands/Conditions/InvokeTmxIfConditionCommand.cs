/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 3/5/2012
 * Time: 12:35 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Commands
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of Invoke_TmxIfConditionCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "TmxIfCondition")]
    public class InvokeTmxIfConditionCommand : ConditionsCmdletBase
    {
        #region Parameters
        [Parameter(Mandatory = true)]
        public ScriptBlock Condition { get; set; }
        [Parameter(Mandatory = true)]
        public ScriptBlock TrueBlock { get; set; }
        [Parameter(Mandatory = false)]
        public ScriptBlock FalseBlock { get; set; }
        #endregion Parameters
        
        protected override void BeginProcessing()
        {
            CheckCmdletParameters();
            
            
        }
    }
}
