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
            // 20130322
        	//this.Automatic = false;
        	// 20130322
        	//this.ForwardDirection = true;
        	
        	// 20130318
        	this.ParametersDictionaries =
        	    new List<Dictionary<string, object>>();
        	
        	// 20130322
        	this.DirectionsDictionaries =
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
        
        // 20130322
        //[Parameter(Mandatory = false)]
        //public SwitchParameter Automatic { get; set; }
        
        // 20130322
        //[Parameter(Mandatory = false)]
        //public SwitchParameter ForwardDirection { get; set; }
        
        // 20130322
        [Parameter(Mandatory = false)]
        public Hashtable[] Directions { get; set; }
        
        // 20130318
        [Parameter(Mandatory = false)]
        public Hashtable[] Parameters { get; set; }
        
        // 20130321
        [Parameter(Mandatory = false)]
        public SwitchParameter Quiet { get; set; }
        #endregion Parameters
        
        internal List<Dictionary<string, object>> ParametersDictionaries { get; set; }
        // 20130322
        internal List<Dictionary<string, object>> DirectionsDictionaries { get; set; }
        
		protected internal void RunWizardInAutomaticMode(WizardRunCmdletBase cmdlet, Wizard wizard)
		{
		    // 20130320
			//CurrentData.CurrentWindow = AutomationElement.RootElement;
			
			cmdlet.StartDate =
			    System.DateTime.Now;
			
			// 20130327
			string previousStepName = string.Empty;

			// 20130320
			//while ((null != CurrentData.CurrentWindow)) {
			while (cmdlet.RunWizardGetWindowScriptBlocks(cmdlet, wizard, null)) {
			    
                // 20130325
//			    if (wizard.StopImmediately) {
//			        break;
//			    }
			    
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
    				    
    				    // 20130327
    				    if (previousStepName == currentStep.Name) {
Console.WriteLine("the first step duplication check");
    				        // the same code as below
    				        System.DateTime nowDate =
    				            System.DateTime.Now;
    				        
        				    if ((nowDate - cmdlet.StartDate).TotalSeconds > (Preferences.Timeout / 1000)) {
Console.WriteLine("the first step duplication check 2");
        				        if (this.Quiet) {
Console.WriteLine("the first step duplication check 3");
        				            cmdlet.WriteObject(
        				                cmdlet,
        				                false);
        				            return;
        				            
        				        } else {
Console.WriteLine("the first step duplication check 4");
            				        cmdlet.WriteError(
            				            cmdlet,
            				            "Timeout expired",
            				            "TimeoutExpired",
            				            ErrorCategory.OperationTimeout,
            				            true);
        				        }
                            }
    				        
    				        System.Threading.Thread.Sleep(Preferences.OnSelectWizardStepDelay);
    				        continue;
    				    }
    				    previousStepName = currentStep.Name;
Console.WriteLine("wzd 00003");
    				    // 20130322
    				    // // 20130321
    				    object[] currentParameters = null;
    				    //if (wizard.ForwardDirection) {
    				    //    currentParameters = currentStep.StepForwardActionParameters;
    				    //} else {
    				    //    currentParameters = currentStep.StepBackwardActionParameters;
    				    //}
    				    
    				    // if the step has its own direction
    				    switch (currentStep.ToDo) {
    				        case WizardStepActions.Forward:
    				            currentParameters = currentStep.StepForwardActionParameters;
    				            break;
    				        case WizardStepActions.Backward:
    				            currentParameters = currentStep.StepBackwardActionParameters;
    				            break;
    				        case WizardStepActions.Cancel:
    				            currentParameters = currentStep.StepCancelActionParameters;
    				            break;
    				        case WizardStepActions.Stop:
    				        //    currentParameters = currentStep.Parent.StopActionp; // ??
    				            wizard.StopImmediately = true;
    				            // 20130325
    				            currentParameters = wizard.StopActionParameters;
    				            break;
    				        default:
    				            throw new Exception("Invalid value for WizardStepActions");
    				            //currentParameters = currentStep.StepForwardActionParameters;
    				            //break;
    				    }
Console.WriteLine("wzd 00004");
    				    // 20130325
    				    if (WizardStepActions.Stop == currentStep.ToDo) {
Console.WriteLine("wzd 00005 stop");
    				        cmdlet.RunWizardStopScriptBlocks(
    				            cmdlet,
    				            wizard,
    				            currentParameters);
    				            
                            // 20130329
                            cmdlet.WriteVerbose(
                                cmdlet,
                                "StopAction has finished, exiting...");
                            return;
                            
    				    } else {
Console.WriteLine("wzd 00006 non-stop");
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
        					    currentParameters);
    				    }
Console.WriteLine("wzd 00007");
    				    // 20130325
        			    if (wizard.StopImmediately) {
Console.WriteLine("wzd 00008 stop immediately");
        			        break;
        			    }
    				    
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
    				    
Console.WriteLine("wzd 00009 checking for timeout expiration");
    				    System.DateTime nowDate = 
                            System.DateTime.Now;

    				    if ((nowDate - cmdlet.StartDate).TotalSeconds > (Preferences.Timeout / 1000)) {
                            
    				        if (this.Quiet) {
Console.WriteLine("wzd 00011");
    				            cmdlet.WriteObject(
    				                cmdlet,
    				                false);
    				            return;
    				            
    				        } else {
Console.WriteLine("wzd 00012");
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
Console.WriteLine("wzd 00015");
				    cmdlet.WriteVerbose(
				        cmdlet,
				        "window is still null");
				}
			}
		}
    }
}
