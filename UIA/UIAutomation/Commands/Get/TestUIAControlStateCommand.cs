/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 17/02/2012
 * Time: 12:23 a.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Commands
{
    extern alias UIANET; extern alias UIACOM;// using System.Windows.Automation;
    using System.Management.Automation;
//    using System.Windows.Automation;
    using Helpers.Commands;

    /// <summary>
    /// Description of TestUiaControlStateCommand.
    /// </summary>
    [Cmdlet(VerbsDiagnostic.Test, "UiaControlState", DefaultParameterSetName = "Search")]
    [OutputType(new[] { typeof(object) })]
    public class TestUiaControlStateCommand : GetControlStateCmdletBase
    {
        #region Parameters
        [Parameter]
        internal new int Timeout { get; set; }
        #endregion Parameters
        
        /// <summary>
        /// Processes the pipeline.
        /// </summary>
        protected override void ProcessRecord()
        {
            if (!CheckAndPrepareInput(this)) { return; }
            
            var command =
                AutomationFactory.GetCommand<TestControlStateCommand>(this);
            command.Execute();
        }
    }
}
