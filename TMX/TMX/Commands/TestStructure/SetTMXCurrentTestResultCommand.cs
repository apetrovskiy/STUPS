/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 3/25/2013
 * Time: 1:37 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX.Commands
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of SetTMXCurrentTestResultCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "TMXCurrentTestResult")]
    public class SetTMXCurrentTestResultCommand : TestResultCmdletBase
    {
        public SetTMXCurrentTestResultCommand()
        {
        }
        
        #region Parameters
        // 20130327
        //[Parameter(Mandatory = false)]
        //public string Banner { get; set; }
        #endregion Parameters
        
        protected override void BeginProcessing()
        {
            TMXSetCurrentTestResultCommand command =
                new TMXSetCurrentTestResultCommand(this);
            command.Execute();
        }
    }
}
