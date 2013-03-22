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

    /// <summary>
    /// Description of StepUIAWizardCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Step, "UIAWizard")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    [Obsolete("This cmdlet is now obsolete. Wizard now support only automatic mode.")]
    public class StepUIAWizardCommand : WizardRunCmdletBase
    //internal class StepUIAWizardCommand : WizardCmdletBase
    {
        public StepUIAWizardCommand()
        {
            Forward = true;
        }
        
        
        #region Parameters
        [Parameter]
        public SwitchParameter Forward { get; set; }
        #endregion Parameters
        
        protected override void BeginProcessing()
        {
            WriteVerbose(this, "Timeout = " + Timeout.ToString());
            StartDate = System.DateTime.Now;
        }
        
        /// <summary>
        /// Processes the pipeline.
        /// </summary>
        protected override void ProcessRecord()
        {
            UIAStepWizardCommand command =
                new UIAStepWizardCommand(this);
            command.Execute();
            
//            // getting the step the user ordered to run
//            if (InputObject != null && InputObject is Wizard) {
//                WizardStep stepToRun = null;
//                WriteVerbose(this, "searching for a step");
//                foreach (WizardStep step in InputObject.Steps) {
//                    WriteVerbose(this, "found step: " + step.Name);
//                    if (step.Name == Name) {
//                        WriteVerbose(this, "found the step we've been searching for");
//                        stepToRun = step;
//                        break;
//                    }
//                }
//                if (stepToRun == null) {
//                    ErrorRecord err = 
//                        new ErrorRecord(
//                            new Exception("Couldn't find the step"),
//                            "StepNotFound",
//                            ErrorCategory.InvalidArgument,
//                            stepToRun.Name);
//                    err.ErrorDetails = 
//                        new ErrorDetails(
//                            "Failed to find the step");
//                    WriteError(this, err, true);
//                }
//                
//                bool result = false;
//                do {
//                    WriteVerbose(this, "checking controls' properties");
//                    
//                    // if there is no SearchCriteria, for example, there's at least one @{}
//                    if (stepToRun.SearchCriteria.Length == 0 ||
//                        System.Text.RegularExpressions.Regex.IsMatch(
//                            stepToRun.SearchCriteria.ToString(),
//                           @"[\@][\{]\s+?[\}]")) {
//                        result = true;
//                    } else {
//                        result = 
//                            testControlByPropertiesFromHashtable(
//                                // 20130315
//                                null,
//                                stepToRun.SearchCriteria,
//                                this.Timeout);
//                    }
//                    if (result) {
//                        
//                        WriteVerbose(this, "there are no SearchCriteria");
//                        WriteVerbose(this, "thus, control state is confirmed");
//                        //WriteObject(this, true);
//                        //return;
//                    } else {
//                        WriteVerbose(this, "control state is not yet confirmed. Checking the timeout");
//                        SleepAndRunScriptBlocks(this);
//                        // wait until timeout expires or the state will be confirmed as valid
//                        System.DateTime nowDate = 
//                            System.DateTime.Now;
//                        if ((nowDate - startDate).TotalSeconds > this.Timeout / 1000) {
//                            //WriteObject(this, false);
//                            //result = true;
//                            //return;
//                            WriteVerbose(this, "the timeout has already expired");
//                            ErrorRecord err = 
//                                new ErrorRecord(
//                                    new Exception("Timeout expired"),
//                                    "TimeoutExpired",
//                                    ErrorCategory.OperationTimeout,
//                                    this.InputObject);
//                            err.ErrorDetails = 
//                                new ErrorDetails(
//                                    "Timeout expired");
//                            WriteError(this, err, true);
//                        }
//                    }
//                } while (!result);
//                
//                WriteVerbose(this, "running script blocks");
//                RunWizardStepScriptBlocks(this, stepToRun, Forward);
//
//                if (PassThru) {
//
//                    WriteObject(this, InputObject);
//                } else {
//
//                    WriteObject(this, true);
//                }
//            } else {
//
//                ErrorRecord err = 
//                    new ErrorRecord(
//                        new Exception("The wizard object you provided is not valid"),
//                        "WrongWizardObject",
//                        ErrorCategory.InvalidArgument,
//                        InputObject);
//                err.ErrorDetails = 
//                    new ErrorDetails(
//                        "The wizard object you provided is not valid");
//                WriteError(this, err, true);
//            }
        }
        
    }
}
