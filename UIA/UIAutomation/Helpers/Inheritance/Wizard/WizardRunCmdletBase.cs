/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/23/2012
 * Time: 11:21 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System.Threading;

namespace UIAutomation
{
    using System;
    using System.Management.Automation;
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
            ParametersDictionaries =
                new List<Dictionary<string, object>>();
            DirectionsDictionaries =
                new List<Dictionary<string, object>>();
        }
        
        #region Parameters
        [Alias("Milliseconds")]
        [UiaParameter][Parameter(Mandatory = false)]
        public int Timeout { get; set; }
        [UiaParameter][Parameter(Mandatory = false)]
        public int Seconds {
            get { return Timeout / 1000; }
            set{ Timeout = value * 1000; }
        }

        [UiaParameter][Parameter(Mandatory = false)]
        // 20130318
        //public ScriptBlock[] OnSleepAction { get; set; }
        public new ScriptBlock[] OnSleepAction { get; set; }
        
        [UiaParameter][Parameter(Mandatory = false)]
        // 20130318
        //internal new Wizard InputObject { get; set; }
        public new Wizard InputObject { get; set; }
        
        // 20130322
        //[UiaParameterNotUsed][Parameter(Mandatory = false)]
        //public SwitchParameter Automatic { get; set; }
        
        // 20130322
        //[UiaParameterNotUsed][Parameter(Mandatory = false)]
        //public SwitchParameter ForwardDirection { get; set; }
        
        // 20130322
        [UiaParameter][Parameter(Mandatory = false)]
        public Hashtable[] Directions { get; set; }
        
        // 20130318
        [UiaParameter][Parameter(Mandatory = false)]
        public Hashtable[] Parameters { get; set; }
        
        // 20130321
        [UiaParameter][Parameter(Mandatory = false)]
        public SwitchParameter Quiet { get; set; }
        #endregion Parameters
        
        internal List<Dictionary<string, object>> ParametersDictionaries { get; set; }
        internal List<Dictionary<string, object>> DirectionsDictionaries { get; set; }
        
        protected internal void RunWizardInAutomaticMode(WizardRunCmdletBase cmdlet, Wizard wizard)
        {
            cmdlet.StartDate =
                DateTime.Now;
            
            string previousStepName = string.Empty;
            
            // 20140314
            // while (cmdlet.RunWizardGetWindowScriptBlocks(wizard, null)) {
            while (cmdlet.RunWizardGetWindowScriptBlocks(wizard, null) && !wizard.StopImmediately) {
                
                if (null != CurrentData.CurrentWindow) {
                    
                    cmdlet.WriteInfo(cmdlet, "Getting the active step");
                    
                    // selector of steps' unique controls
                    WizardStep currentStep = null;
                    try {
                        currentStep = wizard.GetActiveStep();
                    } catch (Exception) {
                        continue;
                    }
                    
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
                            Thread.Sleep(Preferences.OnSelectWizardStepDelay);
                            continue;
                        }
                        previousStepName = currentStep.Name;

                        object[] currentParameters = GetStepParameters(wizard, currentStep);

                        cmdlet.WriteInfo(cmdlet, "running step '" + currentStep.Name + "'");
                        cmdlet.WriteInfo(cmdlet, "parameters: " + ConvertObjectArrayToString(currentParameters));
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
                            DateTime.Now;
                        
                    } else {
                        
                        cmdlet.WriteVerbose(
                            cmdlet,
                            "current step is still null");
                        
                        // 20130508
                        // temporary
                        // profiling
                        cmdlet.WriteInfo(cmdlet, "the current step is still null");

                        // 20130712
                        //InterruptOnTimeoutExpiration(cmdlet, wizard);
                        bool interrupt1 = InterruptOnTimeoutExpiration(cmdlet, wizard);
                        // 20130402
                        // 20130712
                        //break;
                        if (interrupt1) {
                            break;
                        }
                        
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
                    // 20130712
                    //InterruptOnTimeoutExpiration(cmdlet, wizard);
                    bool interrupt2 = InterruptOnTimeoutExpiration(cmdlet, wizard);
                    if (interrupt2) {
                        break;
                    }
                    // 20130712
                    //break;
                }
            }
        }

        // 20130329
        // running the StopAction script after timeout expired
        
        internal bool InterruptOnTimeoutExpiration(WizardRunCmdletBase cmdlet, Wizard wizard)
        {
            // 20130712
            bool interrupt = false;
            
            DateTime nowDate = DateTime.Now;
            if (!((nowDate - cmdlet.StartDate).TotalSeconds > Preferences.Timeout/1000)) return interrupt;
            
            cmdlet.WriteVerbose(
                cmdlet,
                "Timout expired. Running the StopAction scriptblock");
            
            cmdlet.RunWizardStopScriptBlocks(cmdlet, wizard, wizard.StopActionParameters, false);
                
            cmdlet.WriteVerbose(
                cmdlet,
                "outputting the wizard");
                
            if (Quiet) {
                cmdlet.WriteObject(cmdlet, false);
                return interrupt;
            } else {
                cmdlet.WriteError(cmdlet, "Timeout expired", "TimeoutExpired", ErrorCategory.OperationTimeout, true);
            }
            
            interrupt = true;
            
            return interrupt;
        }
        
        internal void RunCurrentStepParameters(WizardRunCmdletBase cmdlet, Wizard wizard, WizardStep currentStep, object[] currentParameters)
        {
            // 20130606
            //cmdlet.WriteVerbose(cmdlet, "running scriptblocks for the '" + currentStep.Name + "' step");
            cmdlet.WriteInfo(cmdlet, "running scriptblocks for the '" + currentStep.Name + "' step");
            
            if (WizardStepActions.Stop == currentStep.ToDo) {
                
                cmdlet.WriteInfo(cmdlet, "running scriptblocks from the StopAction scriptblock set");
                // 20130819
                // cmdlet.RunWizardStopScriptBlocks(cmdlet, wizard, currentParameters);
                cmdlet.RunWizardStopScriptBlocks(cmdlet, wizard, currentParameters, true);
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
