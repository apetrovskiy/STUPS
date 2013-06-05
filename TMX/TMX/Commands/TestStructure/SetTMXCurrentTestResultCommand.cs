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
    // 20130330
    //[Cmdlet(VerbsCommon.Set, "TMXCurrentTestResult")]
    [Cmdlet(VerbsCommon.Set, "TMXCurrentTestResult", DefaultParameterSetName = "DefaultLogicId")]
    public class SetTMXCurrentTestResultCommand : TestResultCmdletBase
    {
        public SetTMXCurrentTestResultCommand()
        {
        }
        
        #region Parameters
        // 20130605
        [Parameter(Mandatory = false)]
        internal new TestResultStatuses TestResultStatus { get; set; }
        [Parameter(Mandatory = false)]
        internal new SwitchParameter TestPassed { get; set; }
        [Parameter(Mandatory = false)]
        internal new SwitchParameter KnownIssue { get; set; }
        #endregion Parameters
        
        protected override void BeginProcessing()
        {
            TMXSetCurrentTestResultCommand command =
                new TMXSetCurrentTestResultCommand(this);
            command.Execute();
        }
    }
}
