/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 08/02/2012
 * Time: 02:29 a.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Commands
{
    using System;
    using System.Management.Automation;
    using System.Windows.Automation;

    /// <summary>
    /// Description of NewUIAWizardCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "UIAWizard")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class NewUIAWizardCommand : WizardContainerCmdletBase
    {
        public NewUIAWizardCommand()
        {
        }
        
        #region Parameters
        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public ScriptBlock[] StartAction { get; set; }
        
        [Parameter(Mandatory = false)]
        public ScriptBlock[] StopAction { get; set; }
        
        [Parameter(Mandatory = false)]
        public ScriptBlock[] DefaultStepForwardAction { get; set; }
        
        [Parameter(Mandatory = false)]
        public ScriptBlock[] DefaultStepBackwardAction { get; set; }
        
        [Parameter(Mandatory = false)]
        public ScriptBlock[] DefaultStepCancelAction { get; set; }
        
        [Parameter(Mandatory = false)]
        public ScriptBlock[] GetWindowAction { get; set; }
//        [Parameter(Mandatory = false)]
//        internal int Order { get; set; }
        #endregion Parameters
        
        protected override void BeginProcessing()
        {
            UIANewWizardCommand command =
                new UIANewWizardCommand(this);
            command.Execute();
        }
        
    }
}
