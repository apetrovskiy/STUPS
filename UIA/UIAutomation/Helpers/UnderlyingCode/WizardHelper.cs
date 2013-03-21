/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 3/17/2013
 * Time: 7:03 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    using System;
    using System.Management.Automation;
    using System.Windows.Automation;
    using UIAutomation.Commands;
    using System.Collections;
    using System.Collections.Generic;
    
    /// <summary>
    /// Description of WizardHelper.
    /// </summary>
    public static class WizardHelper
    {
        static WizardHelper()
        {
        }
        
        //public static void CreateWizard(WizardContainerCmdletBase cmdlet)
        public static void CreateWizard(NewUIAWizardCommand cmdlet)
        {
            if (!cmdlet.ValidateWizardName(cmdlet.Name)) {
                cmdlet.WriteError(cmdlet, "The wizard name you selected is already in use", "NameInUse", ErrorCategory.InvalidArgument, true);
                // return;
            }
            
            cmdlet.WriteVerbose(cmdlet, "wizard name validated");
            Wizard wzd = new Wizard(cmdlet.Name);
            cmdlet.WriteVerbose(cmdlet, "wizard object created");
            wzd.StartAction = cmdlet.StartAction;
            wzd.StopAction = cmdlet.StopAction;
            wzd.DefaultStepForwardAction = cmdlet.DefaultStepForwardAction;
            wzd.DefaultStepBackwardAction = cmdlet.DefaultStepBackwardAction;
            wzd.DefaultStepCancelAction = cmdlet.DefaultStepCancelAction;
            // 20130319
            //wzd.DefaultStepGetWindowAction = cmdlet.DefaultStepGetWindowAction;
            wzd.GetWindowAction = cmdlet.GetWindowAction;

            cmdlet.WriteObject(cmdlet, wzd);
        }
        
        // 20130320
        //public static void AddWizardStep(WizardConstructionCmdletBase cmdlet)
        public static void AddWizardStep(WizardStepCmdletBase cmdlet)
        {
            if (null != cmdlet.InputObject && cmdlet.InputObject is Wizard) {
                
                WizardStep probeTheSameStep = cmdlet.InputObject.GetStep(cmdlet.Name);
                if (null != probeTheSameStep) {
                    
                    cmdlet.WriteError(
                        cmdlet,
                        "A step with the name provided already exists",
                        "StepAlreadyExists",
                        ErrorCategory.InvalidArgument,
                        true);
                }
                
                WizardStep step = new WizardStep(cmdlet.Name, cmdlet.Order);
                step.SearchCriteria = cmdlet.SearchCriteria;
                step.StepForwardAction = cmdlet.StepForwardAction;
                step.StepBackwardAction = cmdlet.StepBackwardAction;
                step.StepCancelAction = cmdlet.StepCancelAction;
                // 20130319
                //step.StepGetWindowAction = cmdlet.StepGetWindowAction;
                step.Description = cmdlet.Description;
                step.Parent = cmdlet.InputObject;

                cmdlet.WriteVerbose(cmdlet, "adding the step");
                cmdlet.InputObject.Steps.Add(step);

                if (cmdlet.PassThru) {

                    cmdlet.WriteObject(cmdlet, cmdlet.InputObject);
                } else {

                    cmdlet.WriteObject(cmdlet, true);
                }
            } else {

                cmdlet.WriteError(cmdlet, "The wizard object you provided is not valid", "WrongWizardObject", ErrorCategory.InvalidArgument, true);
            }
        }
        
        public static void InvokeWizard(WizardRunCmdletBase cmdlet)
        {
            Wizard wzd = cmdlet.GetWizard(cmdlet.Name);

            if (null == wzd) {

                cmdlet.WriteError(cmdlet, "Couldn't get the wizard you asked for", "NoSuchWizard", ErrorCategory.InvalidArgument, true);
            } else {

                wzd.Automatic = cmdlet.Automatic;
                wzd.ForwardDirection = cmdlet.ForwardDirection;

                // scriptblocks' parameters
                if (null != cmdlet.ParametersDictionaries && 0 < cmdlet.ParametersDictionaries.Count) {

                    foreach (Dictionary<string, object> dict in cmdlet.ParametersDictionaries) {

                        WizardStep step = null;
                        string stepName = string.Empty;
                        
                        try {

                            stepName =
                                dict["STEP"].ToString();
                            
                            step =
                                wzd.GetStep(stepName);
                            
                            if (null == step) {
                                
                                cmdlet.WriteError(
                                    cmdlet,
                                    "Failed to get a step with name '" +
                                    stepName +
                                    ".",
                                    "FailedToGetStep",
                                    ErrorCategory.InvalidArgument,
                                    true);
                            }

                            try {
                            
                                switch (dict["ACTION"].ToString().ToUpper()) {
                                    case "FORWARD":
                                        step.ToDo = WizardStepActions.Forward;
                                        break;
                                    case "BACKWARD":
                                        step.ToDo = WizardStepActions.Backward;
                                        break;
                                    case "CANCEL":
                                        step.ToDo = WizardStepActions.Cancel;
                                        break;
                                    case "STOP":
                                        step.ToDo = WizardStepActions.Stop;
                                        break;
                                    default:
                                        // nothing to do
                                    	break;
                                }
                            }
                            catch (Exception eActionType) {
                                
                                cmdlet.WriteVerbose(
                                    cmdlet,
                                    "The action parameter: " +
                                    eActionType.Message);
                            }
                            
                            try {
                                Hashtable parameters =
                                    (Hashtable)dict["PARAMETERS"];
                                
                                if (null != parameters) {

                                    switch (parameters["ACTION"].ToString().ToUpper()) {
                                        case "FORWARD":
                                            step.StepForwardActionParameters = (object[])parameters["LIST"];
                                            break;
                                        case "BACKWARD":
                                            step.StepBackwardActionParameters = (object[])parameters["LIST"];
                                            break;
                                        case "CANCEL":
                                            step.StepCancelActionParameters = (object[])parameters["LIST"];
                                            break;
                                        default:
                                            // nothing to do
                                        	break;
                                    }
                                    
                                } else {
                                    
                                    cmdlet.WriteVerbose(
                                        cmdlet,
                                        "Parameters: " +
                                        "parameters hashtable is null.");
                                }
                            }
                            catch (Exception eParameters) {
                                
                                cmdlet.WriteVerbose(
                                    cmdlet,
                                    "Parameters: " +
                                    eParameters.Message);
                            }
                            
                        }
                        catch (Exception eSwitch) {
                            
                            cmdlet.WriteError(
                                cmdlet,
                                "Failed to parse parameters for step '" +
                                stepName +
                                "'. " +
                                eSwitch.Message,
                                "FailedToParseParameters",
                                ErrorCategory.InvalidArgument,
                                true);
                        }
                    }

                }

                cmdlet.WriteVerbose(cmdlet, "running Wizard StartAction scriptblocks");

                // 20130318
                //cmdlet.RunWizardStartScriptBlocks(cmdlet, wzd);
                cmdlet.RunWizardStartScriptBlocks(cmdlet, wzd, null);
                
                cmdlet.WriteVerbose(cmdlet, "running Wizard in the automated mode");

                cmdlet.RunWizardInAutomaticMode(cmdlet, wzd);

                if (cmdlet.Quiet) {
                    cmdlet.WriteObject(cmdlet, true);
                } else {
                    cmdlet.WriteObject(cmdlet, wzd);
                }
            }
        }
        
        public static void GetWizard(GetUIAWizardCommand cmdlet)
        {
            //Wizard wzd = GetWizard(Name);
            Wizard wzd = cmdlet.GetWizard(cmdlet.Name);
            if (wzd != null) {

                //WriteObject(this, wzd);
                cmdlet.WriteObject(cmdlet, wzd);

            } else {
//                ErrorRecord err = 
//                    new ErrorRecord(
//                        new Exception("Can't get the wizard you asked for"),
//                        "NoWizard",
//                        ErrorCategory.InvalidArgument,
//                        Name);
//                err.ErrorDetails = 
//                    new ErrorDetails(
//                        "Failed to get the wizard you asked for");
//
//                //ThrowTerminatingError(err);
//                this.WriteError(this, err, true);
                
                cmdlet.WriteError(
                    cmdlet,
                    "Can't get the wizard you asked for",
                    "NoWizard",
                    ErrorCategory.InvalidArgument,
                    true);

            }
        }
        
        public static void RemoveWizardStep(RemoveUIAWizardStepCommand cmdlet)
        {
            
            //if (InputObject != null && InputObject is Wizard) {
            if (cmdlet.InputObject != null && cmdlet.InputObject is Wizard) {
                WizardStep stepToRemove = null;
                //foreach (WizardStep step in InputObject.Steps) {
                foreach (WizardStep step in cmdlet.InputObject.Steps) {
                    //if (step.Name == Name) {
                    if (step.Name == cmdlet.Name) {
                        stepToRemove = step;
                    }
                }
                //InputObject.Steps.Remove(stepToRemove);
                cmdlet.InputObject.Steps.Remove(stepToRemove);
                //if (PassThru) {
                if (cmdlet.PassThru) {
                    //WriteObject(this, InputObject);
                    cmdlet.WriteObject(cmdlet, cmdlet.InputObject);
                } else {
                    //WriteObject(this, true);
                    cmdlet.WriteObject(cmdlet, true);
                }
            } else {
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
                
                cmdlet.WriteError(
                    cmdlet,
                    "The wizard object you provided is not valid",
                    "WrongWizardObject",
                    ErrorCategory.InvalidArgument,
                    true);
            }
        // WizardStep step = new WizardStep(Name, Order);
        // if (SearchCriteria != null && SearchCriteria.Length > 0) {
        }
        
        public static void StepWizardStep(StepUIAWizardCommand cmdlet)
        {
            // getting the step the user ordered to run
            //if (InputObject != null && InputObject is Wizard) {
            if (cmdlet.InputObject != null && cmdlet.InputObject is Wizard) {
                WizardStep stepToRun = null;
                //WriteVerbose(this, "searching for a step");
                cmdlet.WriteVerbose(cmdlet, "searching for a step");
                //foreach (WizardStep step in InputObject.Steps) {
                foreach (WizardStep step in cmdlet.InputObject.Steps) {
                    //WriteVerbose(this, "found step: " + step.Name);
                    cmdlet.WriteVerbose(cmdlet, "found step: " + step.Name);
                    //if (step.Name == Name) {
                    if (step.Name == cmdlet.Name) {
                        //WriteVerbose(this, "found the step we've been searching for");
                        cmdlet.WriteVerbose(cmdlet, "found the step we've been searching for");
                        stepToRun = step;
                        break;
                    }
                }
                if (stepToRun == null) {
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
                    
                    cmdlet.WriteError(
                        cmdlet,
                        "Couldn't find the step",
                        "StepNotFound",
                        ErrorCategory.InvalidArgument,
                        true);
                }
                
                bool result = false;
                do {
                    //WriteVerbose(this, "checking controls' properties");
                    cmdlet.WriteVerbose(cmdlet, "checking controls' properties");
                    
                    // if there is no SearchCriteria, for example, there's at least one @{}
                    if (stepToRun.SearchCriteria.Length == 0 ||
                        System.Text.RegularExpressions.Regex.IsMatch(
                            stepToRun.SearchCriteria.ToString(),
                           @"[\@][\{]\s+?[\}]")) {
                        result = true;
                    } else {
                        result = 
                            //testControlByPropertiesFromHashtable(
                            cmdlet.TestControlByPropertiesFromHashtable(
                                // 20130315
                                null,
                                stepToRun.SearchCriteria,
                                //this.Timeout);
                                cmdlet.Timeout);
                    }
                    if (result) {
                        
                        //WriteVerbose(this, "there are no SearchCriteria");
                        cmdlet.WriteVerbose(cmdlet, "there are no SearchCriteria");
                        //WriteVerbose(this, "thus, control state is confirmed");
                        cmdlet.WriteVerbose(cmdlet, "thus, control state is confirmed");
                        //WriteObject(this, true);
                        //return;
                    } else {
                        //WriteVerbose(this, "control state is not yet confirmed. Checking the timeout");
                        cmdlet.WriteVerbose(cmdlet, "control state is not yet confirmed. Checking the timeout");
                        //SleepAndRunScriptBlocks(this);
                        cmdlet.SleepAndRunScriptBlocks(cmdlet);
                        // wait until timeout expires or the state will be confirmed as valid
                        System.DateTime nowDate = 
                            System.DateTime.Now;
                        //if ((nowDate - startDate).TotalSeconds > this.Timeout / 1000) {
                        if ((nowDate - cmdlet.StartDate).TotalSeconds > cmdlet.Timeout / 1000) {
                            //WriteObject(this, false);
                            //result = true;
                            //return;
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
                            
                            cmdlet.WriteError(
                                cmdlet,
                                "Timeout expired",
                                "TimeoutExpired",
                                ErrorCategory.OperationTimeout,
                                true);
                        }
                    }
                } while (!result);
                
                //WriteVerbose(this, "running script blocks");
                // 20130319
                //cmdlet.WriteVerbose(cmdlet, "running ForwardAction, BackwardAction, CancelAction scriptblocks");
                cmdlet.WriteVerbose(cmdlet, "running ForwardAction or BackwardAction scriptblocks");
                //RunWizardStepScriptBlocks(this, stepToRun, Forward);
                // 20130318
                //cmdlet.RunWizardStepScriptBlocks(cmdlet, stepToRun, cmdlet.Forward);
                // 20130321
                //cmdlet.RunWizardStepScriptBlocks(cmdlet, stepToRun, cmdlet.Forward, null);
                cmdlet.RunWizardStepScriptBlocks(cmdlet, stepToRun, stepToRun.ToDo, null);

                //if (PassThru) {
                if (cmdlet.PassThru) {

                    //WriteObject(this, InputObject);
                    cmdlet.WriteObject(cmdlet, cmdlet.InputObject);
                } else {

                    //WriteObject(this, true);
                    cmdlet.WriteObject(cmdlet, true);
                }
            } else {

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
                
                cmdlet.WriteError(
                    cmdlet,
                    "The wizard object you provided is not valid",
                    "WrongWizardObject",
                    ErrorCategory.InvalidArgument,
                    true);
            }
        }
    }
}
