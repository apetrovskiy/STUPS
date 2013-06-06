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
                
                #region commented
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
                #endregion commented
                
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
                    
                    cmdlet.WriteInfo(cmdlet, "Getting the active step");
                    
                    // selector of steps' unique controls
                    WizardStep currentStep =
                        wizard.GetActiveStep();
                    
                    // 20130506
                    //WizardCollection.CurrentWizard = wizard;

                    if (null != currentStep) {
                        
                        cmdlet.WriteVerbose(
                            cmdlet,
                            "current step name = '" +
                            currentStep.Name +
                            "'");
                        
                        cmdlet.WriteInfo(cmdlet, "the active step is '" + currentStep.Name + "'");
                        
                        // 20130327
                        if (previousStepName == currentStep.Name) {
                            
                            InterruptOnTimeoutExpiration(cmdlet, wizard);
                            
                            // 20130508
                            cmdlet.WriteInfo(cmdlet, "the same step, sleeping...");
                            System.Threading.Thread.Sleep(Preferences.OnSelectWizardStepDelay);
                            continue;
                        }
                        previousStepName = currentStep.Name;

                        object[] currentParameters = GetStepParameters(wizard, currentStep);

                        cmdlet.WriteInfo(cmdlet, "running step '" + currentStep.Name + "'");
                        cmdlet.WriteInfo(cmdlet, "parameters: " + this.ConvertObjectArrayToString(currentParameters));
                        RunCurrentStepParameters(cmdlet, wizard, currentStep, currentParameters);

                        // 20130325
                        if (wizard.StopImmediately) {

                            cmdlet.WriteInfo(cmdlet, "stopping the wizard");
                            break;
                        }
                        
                        #region commented
                        // 20130319 - need moving to an appropriate place
                        //cmdlet.RunWizardStepCancelScriptBlocks(
                        //    cmdlet,
                        //    currentStep,
                        //    currentStep.StepCancelActionParameters);
                        #endregion commented
                        
                        cmdlet.StartDate =
                            System.DateTime.Now;
                        
                    } else {
                        
                        cmdlet.WriteVerbose(
                            cmdlet,
                            "current step is still null");
                        
                        // 20130508
                        // temporary
                        // profiling
                        cmdlet.WriteInfo(cmdlet, "the current step is still null");

                        InterruptOnTimeoutExpiration(cmdlet, wizard);
                        // 20130402
                        break;
                        
                    }
                } else {

                    cmdlet.WriteVerbose(
                        cmdlet,
                        "window is still null");
                    
                    // 20130508
                    // temporary
                    // profiling
                    cmdlet.WriteInfo(cmdlet, "window is still null");
                    
                    // 20130402
                    InterruptOnTimeoutExpiration(cmdlet, wizard);
                    break;
                }
            }
        }

        // 20130329
        // running the StopAction script after timeout expired

        internal void InterruptOnTimeoutExpiration(WizardRunCmdletBase cmdlet, Wizard wizard)
        {
            System.DateTime nowDate = System.DateTime.Now;
            if ((nowDate - cmdlet.StartDate).TotalSeconds > (Preferences.Timeout / 1000)) {
                
                cmdlet.WriteVerbose(
                    cmdlet,
                    "Timout expired. Running the StopAction scriptblock");
                
                cmdlet.RunWizardStopScriptBlocks(cmdlet, wizard, wizard.StopActionParameters);
                
                cmdlet.WriteVerbose(
                    cmdlet,
                    "outputting the wizard");
                
                if (this.Quiet) {
                    cmdlet.WriteObject(cmdlet, false);
                    return;
                } else {
                    cmdlet.WriteError(cmdlet, "Timeout expired", "TimeoutExpired", ErrorCategory.OperationTimeout, true);
                }
            }
        }

        // 20130325


        // 20130329


        // 20130318
        //cmdlet.RunWizardStepScriptBlocks(cmdlet, currentStep, cmdlet.ForwardDirection);
        // 20130321
        //cmdlet.ForwardDirection,
        // 20130321
        //cmdlet.ForwardDirection ? currentStep.StepForwardActionParameters : currentStep.StepBackwardActionParameters);
        internal void RunCurrentStepParameters(WizardRunCmdletBase cmdlet, Wizard wizard, WizardStep currentStep, object[] currentParameters)
        {
            // 20130606
            //cmdlet.WriteVerbose(cmdlet, "running scriptblocks for the '" + currentStep.Name + "' step");
            cmdlet.WriteInfo(cmdlet, "running scriptblocks for the '" + currentStep.Name + "' step");
            
            if (WizardStepActions.Stop == currentStep.ToDo) {
                
                cmdlet.WriteInfo(cmdlet, "running scriptblocks from the StopAction scriptblock set");
                cmdlet.RunWizardStopScriptBlocks(cmdlet, wizard, currentParameters);
                // 20130508
                // temporary
                // profiling
                //cmdlet.WriteVerbose(cmdlet, "StopAction has finished, exiting...");
                cmdlet.WriteInfo(cmdlet, "StopAction has finished, exiting...");
                return;
            } else {
                // 20130508
                cmdlet.WriteInfo(cmdlet, "running scriptblocks for step '" + currentStep.Name + "', " + currentStep.ToDo.ToString());
                cmdlet.RunWizardStepScriptBlocks(cmdlet, currentStep, currentStep.ToDo, currentParameters);
                cmdlet.WriteInfo(cmdlet, "Forward, Backward or Cancel scriptblocks have finished");
            }
        }

        // 20130322
        // // 20130321
        //if (wizard.ForwardDirection) {
        //    currentParameters = currentStep.StepForwardActionParameters;
        //} else {
        //    currentParameters = currentStep.StepBackwardActionParameters;
        //}

        // if the step has its own direction
        //    currentParameters = currentStep.Parent.StopActionp; // ??
        // 20130325
        //currentParameters = currentStep.StepForwardActionParameters;
        //break;
        internal object[] GetStepParameters(Wizard wizard, WizardStep currentStep)
        {
            object[] currentParameters = null;
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
                    wizard.StopImmediately = true;
                    currentParameters = wizard.StopActionParameters;
                    break;
                default:
                    throw new Exception("Invalid value for WizardStepActions on getting steps' parameters");
            }
            return currentParameters;
        }
    }
}
