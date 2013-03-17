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

            
        	// 20130317
        	//this.Automatic = true;
        	this.Automatic = false;
        	
        	// 20130317
        	this.ForwardDirection = true;
        }
        
        #region Parameters
// [Parameter(Mandatory = true,
// ValueFromPipeline = true)]
// public Wizard InputObject { get; set; }
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
        
        // 20130317
        [Parameter(Mandatory = false)]
        public SwitchParameter Automatic { get; set; }
        
        // 20130317
        [Parameter(Mandatory = false)]
        public SwitchParameter ForwardDirection { get; set; }
        #endregion Parameters
        
		protected internal void RunWizardInAutomaticMode(WizardRunCmdletBase cmdlet, Wizard wizard)
		{
			
			//CurrentData.CurrentWindow = null;
			//cmdlet.RunWizardGetWindowScriptBlocks(cmdlet, wizard);
			CurrentData.CurrentWindow = AutomationElement.RootElement;
Console.WriteLine("00001");
			//while (cmdlet.RunWizardGetWindowScriptBlocks(cmdlet, wizard)) { // better: until timeout expires
			while ((null != CurrentData.CurrentWindow)) {
Console.WriteLine("00002");
				CurrentData.CurrentWindow = null;
				cmdlet.RunWizardGetWindowScriptBlocks(cmdlet, wizard);
Console.WriteLine("00003");
				// selector of steps' unique controls
				WizardStep currentStep =
					wizard.GetActiveStep();
Console.WriteLine("00004");
				cmdlet.RunWizardStepScriptBlocks(cmdlet, currentStep, cmdlet.ForwardDirection);
Console.WriteLine("00005");
			}
		}
    }
}
