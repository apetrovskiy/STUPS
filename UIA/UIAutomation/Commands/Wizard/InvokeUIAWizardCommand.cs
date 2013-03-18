/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/23/2012
 * Time: 3:16 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Commands
{
    using System;
    using System.Management.Automation;

    /// <summary>
    /// Description of InvokeUIAWizardCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UIAWizard")]
    public class InvokeUIAWizardCommand : WizardRunCmdletBase
    {
        public InvokeUIAWizardCommand()
        {
//        	// 20130317
//        	//this.Automatic = true;
//        	this.Automatic = false;
//        	
//        	// 20130317
//        	this.ForwardDirection = true;
        }
        
        #region Parameters
//        [Parameter(Mandatory = false)]
//        internal new Wizard InputObject { get; set; }
//        
//        // 20130317
//        [Parameter(Mandatory = false)]
//        public SwitchParameter Automatic { get; set; }
//        
//        // 20130317
//        [Parameter(Mandatory = false)]
//        public SwitchParameter ForwardDirection { get; set; }
        #endregion Parameters
        
        protected override void BeginProcessing()
        {
        	UIAInvokeWizardCommand command =
        		new UIAInvokeWizardCommand(this);
        	command.Execute();
        }
    }
}
