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
    extern alias UIANET; extern alias UIACOM;// using System.Windows.Automation;
    using System.Management.Automation;
    using classic = UIANET::System.Windows.Automation; using viacom = UIACOM::System.Windows.Automation; // using System.Windows.Automation;

    /// <summary>
    /// Description of NewUiaWizardCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "UiaWizard")]
    public class NewUiaWizardCommand : WizardContainerCmdletBase
    {
        public NewUiaWizardCommand()
        {
        }
        
        #region Parameters
        [UiaParameter][Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public ScriptBlock[] StartAction { get; set; }
        
        [UiaParameter][Parameter(Mandatory = false)]
        public ScriptBlock[] StopAction { get; set; }
        
        [UiaParameter][Parameter(Mandatory = false)]
        public ScriptBlock[] DefaultStepForwardAction { get; set; }
        
        [UiaParameter][Parameter(Mandatory = false)]
        public ScriptBlock[] DefaultStepBackwardAction { get; set; }
        
        [UiaParameter][Parameter(Mandatory = false)]
        public ScriptBlock[] DefaultStepCancelAction { get; set; }
        
        [UiaParameter][Parameter(Mandatory = false)]
        public ScriptBlock[] GetWindowAction { get; set; }
//        [UiaParameterNotUsed][Parameter(Mandatory = false)]
//        internal int Order { get; set; }
        #endregion Parameters
        
        protected override void BeginProcessing()
        {
            NewWizardCommand command =
                new NewWizardCommand(this);
            command.Execute();
        }
        
    }
}
