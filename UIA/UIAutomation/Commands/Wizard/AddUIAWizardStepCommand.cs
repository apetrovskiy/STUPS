/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 08/02/2012
 * Time: 02:30 a.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Commands
{
    using System;
    using System.Management.Automation;
    using System.Windows.Automation;
    using System.Collections;

    /// <summary>
    /// Description of AddUIAWizardStepCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Add, "UIAWizardStep")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class AddUIAWizardStepCommand : WizardStepCmdletBase //WizardConstructionCmdletBase
    //internal class AddUIAWizardStepCommand : WizardCmdletBase
    {
        public AddUIAWizardStepCommand()
        {
        }
        
        #region Parameters
//        [Parameter(Mandatory = false)]
//        //public System.Collections.Hashtable[] SearchCriteria { get; set; }
//        public Hashtable[] SearchCriteria { get; set; }
//        [Parameter(Mandatory = false)]
//        public ScriptBlock[] StepForwardAction { get; set; }
//        [Parameter(Mandatory = false)]
//        public ScriptBlock[] StepBackwardAction { get; set; }
//        // 20130317
//        [Parameter(Mandatory = false)]
//        public ScriptBlock[] StepCancelAction { get; set; }
//        // 20130317
//        [Parameter(Mandatory = false)]
//        public ScriptBlock[] StepGetWindowAction { get; set; }
//        [Parameter(Mandatory = false)]
//        public int Order { get; set; }
        #endregion Parameters
        
        /// <summary>
        /// Processes the pipeline.
        /// </summary>
        protected override void ProcessRecord()
        {
            UIAAddWizardStepCommand command =
                new UIAAddWizardStepCommand(this);
            command.Execute();
        }
        
    }
}
