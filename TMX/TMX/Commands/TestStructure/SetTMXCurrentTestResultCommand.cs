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
    /// Description of SetTmxCurrentTestResultCommand.
    /// </summary>
    // 20130330
    //[Cmdlet(VerbsCommon.Set, "TmxCurrentTestResult")]
    [Cmdlet(VerbsCommon.Set, "TmxCurrentTestResult", DefaultParameterSetName = "DefaultLogicId")]
    public class SetTmxCurrentTestResultCommand : TestResultCmdletBase
    {
        public SetTmxCurrentTestResultCommand()
        {
            // 20130626
            this.TestOrigin = TestResultOrigins.Logical;
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
            TmxSetCurrentTestResultCommand command =
                new TmxSetCurrentTestResultCommand(this);
            command.Execute();
        }
    }
}
