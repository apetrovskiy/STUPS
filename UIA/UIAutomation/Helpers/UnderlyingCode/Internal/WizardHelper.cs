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
    extern alias UIANET; extern alias UIACOM;// using System.Windows.Automation;
    using System;
    using System.Management.Automation;
    using classic = UIANET::System.Windows.Automation; using viacom = UIACOM::System.Windows.Automation; // using System.Windows.Automation;
    using Commands;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    
    /// <summary>
    /// Description of WizardHelper.
    /// </summary>
    public static class WizardHelper
    {
        public static void CreateWizard(NewUiaWizardCommand cmdlet)
        {
            if (!cmdlet.ValidateWizardName(cmdlet.Name)) {
                
                cmdlet.WriteVerbose(
                    cmdlet,
                    "The wizard name you selected is already in use");
                
                cmdlet.WriteError(
                    cmdlet,
                    "The wizard name you selected is already in use",
                    "NameInUse",
                    ErrorCategory.InvalidArgument,
                    true);
            }
            
            cmdlet.WriteVerbose(cmdlet, "wizard name validated");
            var wzd = new Wizard(cmdlet.Name);
            cmdlet.WriteVerbose(cmdlet, "wizard object created");
            wzd.StartAction = cmdlet.StartAction;
            wzd.StopAction = cmdlet.StopAction;
            wzd.DefaultStepForwardAction = cmdlet.DefaultStepForwardAction;
            wzd.DefaultStepBackwardAction = cmdlet.DefaultStepBackwardAction;
            wzd.DefaultStepCancelAction = cmdlet.DefaultStepCancelAction;
            // 20130319
            //wzd.DefaultStepGetWindowAction = cmdlet.DefaultStepGetWindowAction;
            wzd.GetWindowAction = cmdlet.GetWindowAction;
            cmdlet.WriteVerbose(cmdlet, "the wizard is fulfilled with properties");
            
            cmdlet.WriteObject(cmdlet, wzd);
        }
        
        public static void AddWizardStep(WizardStepCmdletBase cmdlet)
        {
            if (null != cmdlet.InputObject && null != cmdlet.InputObject) {
                
                WizardStep probeTheSameStep = cmdlet.InputObject.GetStep(cmdlet.Name);
                if (null != probeTheSameStep) {
                    
                    cmdlet.WriteError(
                        cmdlet,
                        "A step with the name provided already exists",
                        "StepAlreadyExists",
                        ErrorCategory.InvalidArgument,
                        true);
                }
                
                // WizardStep step = new WizardStep(cmdlet.Name, cmdlet.Order)
                var step = new WizardStep(cmdlet.Name, cmdlet.Order)
                {
                    SearchCriteria = cmdlet.SearchCriteria,
                    StepForwardAction = cmdlet.StepForwardAction,
                    StepBackwardAction = cmdlet.StepBackwardAction,
                    StepCancelAction = cmdlet.StepCancelAction,
                    Description = cmdlet.Description,
                    Parent = cmdlet.InputObject
                };
                // 20130319
                //step.StepGetWindowAction = cmdlet.StepGetWindowAction;
                
                cmdlet.WriteVerbose(cmdlet, "adding the step");
                cmdlet.InputObject.Steps.Add(step);
                
                // 20130508
                cmdlet.WriteInfo(cmdlet, step.Name + " has been added");

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
            cmdlet.WriteVerbose(
                cmdlet,
                "Getting the wizard");
            Wizard wzd = cmdlet.GetWizard(cmdlet.Name);

            if (null == wzd) {

                cmdlet.WriteError(cmdlet, "Couldn't get the wizard you asked for", "NoSuchWizard", ErrorCategory.InvalidArgument, true);
            } else {

                cmdlet.WriteVerbose(
                    cmdlet,
                    "The wizard has been obtained from the collection");
                
                // publish the wizard as a global variable
                WizardCollection.CurrentWizard = wzd;
                
                cmdlet.WriteInfo(cmdlet, "the current wizard is '" + WizardCollection.CurrentWizard.Name + "'");
#region commented
//                try {
//
//                    System.Management.Automation.Runspaces.Runspace.DefaultRunspace.SessionStateProxy.GetVariable(".SessionStateProxy.PSVariable.Set(
//                        "Wizard",
//                        wzd);
//
////                    testRunSpace.SessionStateProxy.SetVariable(
////                        variableName,
////                        variableValue);
////                    result = true;
//                }
//                catch (Exception eWizardVariable) {
//
//                    cmdlet.WriteError(
//                        cmdlet,
//                        eWizardVariable.Message,
//                        "VariablePublishingFailed",
//                        ErrorCategory.InvalidOperation,
//                        true);
//                }
#endregion commented

                if (null != cmdlet.Directions && 0 < cmdlet.DirectionsDictionaries.Count) {
                    
                    cmdlet.WriteVerbose(cmdlet, "Preparing step directions");
                    PrepareStepDirections(cmdlet, wzd);
                }

                // scriptblocks' parameters
                if (null != cmdlet.ParametersDictionaries && 0 < cmdlet.ParametersDictionaries.Count) {

                    cmdlet.WriteVerbose(cmdlet, "Preparing step parameters");
                    PrepareStepParameters(cmdlet, wzd);
                }

                // 20130508
                // temporary
                cmdlet.WriteInfo(cmdlet, "running Wizard StartAction scriptblocks");
                cmdlet.WriteInfo(cmdlet, "parameters: " + cmdlet.ConvertObjectArrayToString(wzd.StartActionParameters));
                
                cmdlet.RunWizardStartScriptBlocks(cmdlet, wzd, wzd.StartActionParameters);
                
                cmdlet.WriteVerbose(cmdlet, "running Wizard in the automated mode");
                cmdlet.WriteInfo(cmdlet, "working in unattended mode");

                cmdlet.RunWizardInAutomaticMode(cmdlet, wzd);

                if (cmdlet.Quiet) {
                    cmdlet.WriteObject(cmdlet, true);
                } else {
                    cmdlet.WriteObject(cmdlet, wzd);
                }
            }
        }

        // 20130325

        // these were an action in the Parameters hashtable (the outer hashtable):
        // @{step="Step05PrinterData";action="forward";parameters=@{action="forward";list=@("printer_2","port_2")}}
        #region commented
        //                            try {
//
        //                                switch (dictParameters["ACTION"].ToString().ToUpper()) {
        //                                    case "FORWARD":
        //                                        stepWithParameters.ToDo = WizardStepActions.Forward;
        //                                        break;
        //                                    case "BACKWARD":
        //                                        stepWithParameters.ToDo = WizardStepActions.Backward;
        //                                        break;
        //                                    case "CANCEL":
        //                                        stepWithParameters.ToDo = WizardStepActions.Cancel;
        //                                        break;
        //                                    case "STOP":
        //                                        stepWithParameters.ToDo = WizardStepActions.Stop;
        //                                        break;
        //                                    default:
        //                                        // nothing to do
        //                                        break;
        //                                }
        //                            }
        //                            catch (Exception eActionType) {
//
        //                                cmdlet.WriteVerbose(
        //                                    cmdlet,
        //                                    "The action parameter: " +
        //                                    eActionType.Message);
        //                            }
        #endregion commented

        // these were a hashtable of parameters in the outerhashtable
        // @{step="Step05PrinterData";action="forward";parameters=@{action="forward";list=@("printer_2","port_2")}}
        #region commented
        //                                Hashtable parameters =
        //                                    (Hashtable)dictParameters["PARAMETERS"];
//
        //                                if (null != parameters) {
//
        //                                    switch (parameters["ACTION"].ToString().ToUpper()) {
        //                                        case "FORWARD":
        //                                            stepWithParameters.StepForwardActionParameters = (object[])parameters["LIST"];
        //                                            break;
        //                                        case "BACKWARD":
        //                                            stepWithParameters.StepBackwardActionParameters = (object[])parameters["LIST"];
        //                                            break;
        //                                        case "CANCEL":
        //                                            stepWithParameters.StepCancelActionParameters = (object[])parameters["LIST"];
        //                                            break;
        //                                        default:
        //                                            // nothing to do
        //                                            break;
        //                                    }
//
        //                                } else {
//
        //                                    cmdlet.WriteVerbose(
        //                                        cmdlet,
        //                                        "Parameters: " +
        //                                        "parameters hashtable is null.");
        //                                }
        #endregion commented
        // 20130322
        internal static void PrepareStepParameters(WizardRunCmdletBase cmdlet, Wizard wzd)
        {
            foreach (Dictionary<string, object> dictParameters in cmdlet.ParametersDictionaries) {
                WizardStep stepWithParameters = null;
                string stepWithParametersName = string.Empty;
                try {
                    stepWithParametersName = dictParameters["STEP"].ToString();
                    
                    if ("0" == stepWithParametersName) {
                        //
                    } else {
                        stepWithParameters = wzd.GetStep(stepWithParametersName);
                        
                        if (null == stepWithParameters) {
                            cmdlet.WriteError(
                                cmdlet, 
                                "Failed to get a step with name '" +
                                stepWithParametersName +
                                "' in the Parameters hashtable.",
                                "FailedToGetStep",
                                ErrorCategory.InvalidArgument,
                                true);
                        }
                    }
                    
                    try {
                        switch (dictParameters["ACTION"].ToString().ToUpper()) {
                            case "FORWARD":
                                stepWithParameters.StepForwardActionParameters = (object[])dictParameters["PARAMETERS"];
                                break;
                            case "BACKWARD":
                                stepWithParameters.StepBackwardActionParameters = (object[])dictParameters["PARAMETERS"];
                                break;
                            case "CANCEL":
                                stepWithParameters.StepCancelActionParameters = (object[])dictParameters["PARAMETERS"];
                                break;
                            case "STOP":
                                wzd.StopActionParameters = (object[])dictParameters["PARAMETERS"];
                                break;
                            case "START":
                                wzd.StartActionParameters = (object[])dictParameters["PARAMETERS"];
                                break;
                            default:

                                break;
                        }
                    } catch (Exception eParameters) {

                        cmdlet.WriteVerbose(
                            cmdlet,
                            "Parameters: " +
                            eParameters.Message);
                    }

                } catch (Exception eParametersDictionaries) {

                    cmdlet.WriteError(
                        cmdlet,
                        "Failed to parse parameters for step '" +
                        stepWithParametersName +
                        "'. " +
                        eParametersDictionaries.Message,
                        "FailedToParseParameters",
                        ErrorCategory.InvalidArgument,
                        true);
                }
            }
        }

        internal static void PrepareStepDirections(WizardRunCmdletBase cmdlet, Wizard wzd)
        {
            foreach (Dictionary<string, object> dictDirections in cmdlet.DirectionsDictionaries) {
                WizardStep stepWithDirections = null;
                string stepWithDirectionsName = string.Empty;
                try {
                    
                    stepWithDirectionsName = dictDirections["STEP"].ToString();
                    
                    if ("0" == stepWithDirectionsName) {
                        //
                    } else {
                    
                        stepWithDirections = wzd.GetStep(stepWithDirectionsName);
                        
                        if (null == stepWithDirections) {
                            cmdlet.WriteError(
                                cmdlet,
                                "Failed to get a step with name '" +
                                stepWithDirectionsName +
                                "' in the Directions hashtable.",
                                "FailedToGetStep",
                                ErrorCategory.InvalidArgument,
                                true);
                        }
                    }
                    
                    try {
                        switch (dictDirections["ACTION"].ToString().ToUpper()) {
                            case "FORWARD":
                                stepWithDirections.ToDo = WizardStepActions.Forward;
                                break;
                            case "BACKWARD":
                                stepWithDirections.ToDo = WizardStepActions.Backward;
                                break;
                            case "CANCEL":
                                stepWithDirections.ToDo = WizardStepActions.Cancel;
                                break;
                            case "STOP":
                                stepWithDirections.ToDo = WizardStepActions.Stop;
                                break;
                            default:
                                throw new Exception("Invalid value for directions");
                                //stepWithDirections.ToDo = WizardStepActions.Forward;
                                //break;
                        }
                        
                    } catch (Exception eActionType) {
                        
                        cmdlet.WriteVerbose(
                            cmdlet,
                            "The action parameter: " +
                            eActionType.Message);
                    }
                } catch (Exception eDirectionsDictionaries) {
                    cmdlet.WriteError(
                        cmdlet,
                        "Failed to parse directions for step '" +
                        stepWithDirectionsName +
                        "'. " +
                        eDirectionsDictionaries.Message,
                        "FailedToParseDirections",
                        ErrorCategory.InvalidArgument,
                        true);
                }
            }
        }
        
        // 20140314
        /*
        public static void GetWizard(GetUiaWizardCommand cmdlet)
        {
            Wizard wzd = cmdlet.GetWizard(cmdlet.Name);
            if (wzd != null) {
                
                cmdlet.WriteObject(cmdlet, wzd);

            } else {
                
                cmdlet.WriteError(
                    cmdlet,
                    "Can't get the wizard you asked for",
                    "NoWizard",
                    ErrorCategory.InvalidArgument,
                    true);

            }
        }
        */
        
        public static void GetWizard(GetUiaWizardCommand cmdlet)
        {
            Wizard wzd = cmdlet.GetWizard(cmdlet.Name);
            if (wzd != null) {
                
                cmdlet.WriteObject(cmdlet, wzd);

            } else {
                
                cmdlet.WriteError(
                    cmdlet,
                    "Can't get the wizard you asked for",
                    "NoWizard",
                    ErrorCategory.InvalidArgument,
                    true);

            }
        }
        
        public static void RemoveWizardStep(RemoveUiaWizardStepCommand cmdlet)
        {
            if (cmdlet.InputObject != null && null != cmdlet.InputObject) {
                
                WizardStep stepToRemove = null;
                
                foreach (WizardStep step in cmdlet.InputObject.Steps.Where(step => step.Name == cmdlet.Name))
                {
                    stepToRemove = step;
                }
                
                cmdlet.InputObject.Steps.Remove(stepToRemove);
                
                if (cmdlet.PassThru) {
                    cmdlet.WriteObject(cmdlet, cmdlet.InputObject);
                } else {
                    cmdlet.WriteObject(cmdlet, true);
                }
            } else {
                
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
        
        public static void StepWizardStep(StepUiaWizardCommand cmdlet)
        {
            // getting the step the user ordered to run
            if (cmdlet.InputObject != null && null != cmdlet.InputObject) {
                
                WizardStep stepToRun = null;
                
                cmdlet.WriteVerbose(cmdlet, "searching for a step");
                
                foreach (WizardStep step in cmdlet.InputObject.Steps) {
                    
                    cmdlet.WriteVerbose(cmdlet, "found step: " + step.Name);
                    
                    if (step.Name != cmdlet.Name) continue;
                    
                    cmdlet.WriteVerbose(cmdlet, "found the step we've been searching for");
                    stepToRun = step;
                    break;

                    /*
                    if (step.Name == cmdlet.Name) {
                        //WriteVerbose(this, "found the step we've been searching for");
                        cmdlet.WriteVerbose(cmdlet, "found the step we've been searching for");
                        stepToRun = step;
                        break;
                    }
                    */
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
                    cmdlet.WriteVerbose(cmdlet, "checking controls' properties");
                    
                    // if there is no SearchCriteria, for example, there's at least one @{}
                    if (stepToRun.SearchCriteria.Length == 0 ||
                        Regex.IsMatch(
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
                        
                        cmdlet.WriteVerbose(cmdlet, "there are no SearchCriteria");
                        cmdlet.WriteVerbose(cmdlet, "thus, control state is confirmed");
                    } else {
                        cmdlet.WriteVerbose(cmdlet, "control state is not yet confirmed. Checking the timeout");
                        cmdlet.SleepAndRunScriptBlocks(cmdlet);
                        // wait until timeout expires or the state will be confirmed as valid
                        DateTime nowDate =
                            DateTime.Now;
                        
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
