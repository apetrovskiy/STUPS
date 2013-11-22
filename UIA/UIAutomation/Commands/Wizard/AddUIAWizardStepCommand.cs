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
    /// Description of AddUiaWizardStepCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Add, "UiaWizardStep")]
    
    public class AddUiaWizardStepCommand : WizardStepCmdletBase //WizardConstructionCmdletBase
    //internal class AddUiaWizardStepCommand : WizardCmdletBase
    {
        public AddUiaWizardStepCommand()
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
            UiaAddWizardStepCommand command =
                new UiaAddWizardStepCommand(this);
            command.Execute();
        }
        
    }
}
