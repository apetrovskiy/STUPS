/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/23/2012
 * Time: 11:21 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    using System;
    using System.Management.Automation;
    using System.Windows.Automation;

    /// <summary>
    /// Description of WizardRunCmdletBase.
    /// </summary>
    public class WizardRunCmdletBase : WizardCmdletBase
    {
        public WizardRunCmdletBase()
        {
            Timeout = Preferences.Timeout;
        	this.Automatic = false;
        	this.ForwardDirection = true;
        }
        
        #region Parameters
        [Alias("Milliseconds")]
        [Parameter(Mandatory = false)]
        public int Timeout { get; set; }
        [Parameter(Mandatory = false)]
        public int Seconds {
            get { return Timeout / 1000; } 
            set{ Timeout = value * 1000; }
        }

        [Parameter(Mandatory = false)]
        public ScriptBlock[] OnSleepAction { get; set; }
        
        
        
        [Parameter(Mandatory = false)]
        internal new Wizard InputObject { get; set; }
        
        [Parameter(Mandatory = false)]
        public SwitchParameter Automatic { get; set; }
        
        [Parameter(Mandatory = false)]
        public SwitchParameter ForwardDirection { get; set; }
        #endregion Parameters
        
		protected internal void RunWizardInAutomaticMode(WizardRunCmdletBase cmdlet, Wizard wizard)
		{
			CurrentData.CurrentWindow = AutomationElement.RootElement;

			while ((null != CurrentData.CurrentWindow)) {

				CurrentData.CurrentWindow = null;
				cmdlet.RunWizardGetWindowScriptBlocks(cmdlet, wizard);

				// selector of steps' unique controls
				WizardStep currentStep =
					wizard.GetActiveStep();

				if (null != currentStep) {
					cmdlet.RunWizardStepScriptBlocks(cmdlet, currentStep, cmdlet.ForwardDirection);
				}
			}
		}
    }
}
