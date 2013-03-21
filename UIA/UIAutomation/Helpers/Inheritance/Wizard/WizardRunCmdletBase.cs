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
    using System.Collections;
    using System.Collections.Generic;

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
        	
        	// 20130318
        	this.ParametersDictionaries =
        	    new List<Dictionary<string, object>>();
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
        // 20130318
        //public ScriptBlock[] OnSleepAction { get; set; }
        public new ScriptBlock[] OnSleepAction { get; set; }
        
        [Parameter(Mandatory = false)]
        // 20130318
        //internal new Wizard InputObject { get; set; }
        public new Wizard InputObject { get; set; }
        
        [Parameter(Mandatory = false)]
        public SwitchParameter Automatic { get; set; }
        
        [Parameter(Mandatory = false)]
        public SwitchParameter ForwardDirection { get; set; }
        
        // 20130318
        [Parameter(Mandatory = false)]
        public Hashtable[] Parameters { get; set; }
        
        // 20130321
        [Parameter(Mandatory = false)]
        public SwitchParameter Quiet { get; set; }
        #endregion Parameters
        
        internal List<Dictionary<string, object>> ParametersDictionaries { get; set; }
        
		protected internal void RunWizardInAutomaticMode(WizardRunCmdletBase cmdlet, Wizard wizard)
		{
		    // 20130320
			//CurrentData.CurrentWindow = AutomationElement.RootElement;
			
			cmdlet.StartDate =
			    System.DateTime.Now;

			// 20130320
			//while ((null != CurrentData.CurrentWindow)) {
			while (cmdlet.RunWizardGetWindowScriptBlocks(cmdlet, wizard, null)) {

			    if (wizard.StopImmediately) {
			        break;
			    }
			    
			    // 20130320
				//CurrentData.CurrentWindow = null;
				// 20130318
				//cmdlet.RunWizardGetWindowScriptBlocks(cmdlet, wizard);
				// 20130320
				//cmdlet.RunWizardGetWindowScriptBlocks(cmdlet, wizard, null);
				if (null != (CurrentData.CurrentWindow as AutomationElement)) {
				    
				    cmdlet.WriteVerbose(
				        cmdlet,
				        "the window: name = '" +
				        CurrentData.CurrentWindow.Current.Name +
				        "', automationId = '" +
				        CurrentData.CurrentWindow.Current.AutomationId +
				        "', class = '" +
				        CurrentData.CurrentWindow.Current.ClassName +
				        "', processId = " +
				        CurrentData.CurrentWindow.Current.ProcessId.ToString() +
				        ".");
				    
    				// selector of steps' unique controls
    				WizardStep currentStep =
    					wizard.GetActiveStep();

    				if (null != currentStep) {
        
                        cmdlet.WriteVerbose(
                            cmdlet,
                            "current step name = '" +
                            currentStep.Name +
                            "'");
                        
    				    // 20130321
    				    ScriptBlock[] whichToRun = null;
    				    if (wizard.ForwardDirection) {
    				        whichToRun = currentStep.StepForwardAction;
    				    } else {
    				        whichToRun = currentStep.StepBackwardAction;
    				    }
    				    // if the step has its own direction
    				    switch (currentStep.ToDo) {
    				        case WizardStepActions.NotSet:
    				            // nothing to do
    				            break;
    				        case WizardStepActions.Forward:
    				            whichToRun = currentStep.StepForwardAction;
    				            break;
    				        case WizardStepActions.Backward:
    				            whichToRun = currentStep.StepBackwardAction;
    				            break;
    				        case WizardStepActions.Cancel:
    				            whichToRun = currentStep.StepCancelAction;
    				            break;
    				        case WizardStepActions.Stop:
    				            whichToRun = currentStep.Parent.StopAction;
    				            wizard.StopImmediately = true;
    				            break;
    				        default:
    				            throw new Exception("Invalid value for WizardStepActions");
    				    }
    				    
    				    // 20130318
    					//cmdlet.RunWizardStepScriptBlocks(cmdlet, currentStep, cmdlet.ForwardDirection);
    					cmdlet.RunWizardStepScriptBlocks(
    					    cmdlet,
    					    currentStep,
    					    // 20130321
    					    //cmdlet.ForwardDirection,
    					    currentStep.ToDo,
    					    // 20130321
    					    //cmdlet.ForwardDirection ? currentStep.StepForwardActionParameters : currentStep.StepBackwardActionParameters);
    					    whichToRun);

    					// 20130319 - need moving to an appropriate place
    					//cmdlet.RunWizardStepCancelScriptBlocks(
    					//    cmdlet,
    					//    currentStep,
    					//    currentStep.StepCancelActionParameters);
    					
    					cmdlet.StartDate =
    					    System.DateTime.Now;
    					
                    } else {
                        
                        cmdlet.WriteVerbose(
                            cmdlet,
                            "current step is still null");
    				    
				    
    				    System.DateTime nowDate = 
                            System.DateTime.Now;

    				    if ((nowDate - cmdlet.StartDate).TotalSeconds > (Preferences.Timeout / 1000)) {
                            
    				        if (this.Quiet) {
    				            
    				            cmdlet.WriteObject(
    				                cmdlet,
    				                false);
    				            return;
    				            
    				        } else {
    				        
        				        cmdlet.WriteError(
        				            cmdlet,
        				            "Timeout expired",
        				            "TimeoutExpired",
        				            ErrorCategory.OperationTimeout,
        				            true);
    				        }
                        }
    				    
                    }
				} else {
				    
				    cmdlet.WriteVerbose(
				        cmdlet,
				        "window is still null");
				}
			}
		}
    }
}
