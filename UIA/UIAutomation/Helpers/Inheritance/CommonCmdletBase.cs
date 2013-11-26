/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/2/2011
 * Time: 5:51 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

//using System.Collections.Generic;

using System.Diagnostics.CodeAnalysis;
using TMX;
using UIAutomation.Commands;

namespace UIAutomation
{
    using System;
    using System.Management.Automation;
    using System.Collections;
    using System.Collections.ObjectModel;
    using System.Threading;
    using System.Management.Automation.Runspaces;
    using System.Windows.Automation;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using System.Linq;
    
    using PSTestLib;
    
    /// <summary>
    /// The CommonCmdletBase class in the top of cmdlet hierarchy.
    /// </summary>
    //    [Cmdlet(VerbsCommon.Show, "UiaModuleSettings")]
    public class CommonCmdletBase : PSCmdletBase
    {
        #region Constructor
        public CommonCmdletBase()
        {
            #region creating the log file
            // 20131112
            //try {
            //    Global.CreateLogFile();
            //} catch { }
            #endregion creating the log file
            
            CurrentData.LastCmdlet = CmdletName(this);
            // ??
            if (!UnitTestMode && !ModuleAlreadyLoaded) {
                //WebDriverFactory.AutofacModule = new WebDriverModule();
                //ObjectsFactory.NinjectModule = new ObjectLifecycleModule();
                //WebDriverFactory.Init();
                
                ModuleAlreadyLoaded = true;
            }
            
            //CurrentData.Init();
            ObjectsFactory.Init();
        }
        #endregion Constructor
        
        internal static bool ModuleAlreadyLoaded { get; set; }
        
        protected override void EndProcessing()
        {
            #region close the log
            try {
                Global.CloseLogFile();
            } catch { }
            #endregion close the log
        }
        
        // 20131118
        // just experimental
//        protected AutomationElement EventSource { get; set; }
//        protected AutomationEventArgs EventArgs { get; set; }
        
        #region Write methods
        protected override void WriteLog(LogLevels logLevel, string logRecord)
        {
            if (!Preferences.AutoLog) return;
            switch (logLevel) {
                case LogLevels.Fatal:
                    Logger.Fatal(logRecord);
                    break;
                case LogLevels.Error:
                    Logger.Error(logRecord);
                    break;
                case LogLevels.Warn:
                    Logger.Warn(logRecord);
                    break;
                case LogLevels.Info:
                    Logger.Info(logRecord);
                    break;
                case LogLevels.Debug:
                    Logger.Debug(logRecord);
                    break;
                case LogLevels.Trace:
                    Logger.Trace(logRecord);
                    break;
            }


            /*
            if (Preferences.AutoLog) {
                
                switch (logLevel) {
                    case LogLevels.Fatal:
                        TMX.Logger.Fatal(logRecord);
                        break;
                    case LogLevels.Error:
                        TMX.Logger.Error(logRecord);
                        break;
                    case LogLevels.Warn:
                        TMX.Logger.Warn(logRecord);
                        break;
                    case LogLevels.Info:
                        TMX.Logger.Info(logRecord);
                        break;
                    case LogLevels.Debug:
                        TMX.Logger.Debug(logRecord);
                        break;
                    case LogLevels.Trace:
                        TMX.Logger.Trace(logRecord);
                        break;
                }
            }
            */
        }

        protected void WriteLog(LogLevels logLevel, ErrorRecord errorRecord)
        {
            if (!Preferences.AutoLog) return;
            WriteLog(logLevel, errorRecord.Exception.Message);
            WriteLog(logLevel, "Script: '" + errorRecord.InvocationInfo.ScriptName + "', line: " + errorRecord.InvocationInfo.Line.ToString());

            /*
            if (Preferences.AutoLog) {
                
                this.WriteLog(logLevel, errorRecord.Exception.Message);
                this.WriteLog(logLevel, "Script: '" + errorRecord.InvocationInfo.ScriptName + "', line: " + errorRecord.InvocationInfo.Line.ToString());
            }
            */
        }
        
        protected internal void WriteDebug(CommonCmdletBase cmdlet, string text)
        {
            string reportString =
                CmdletSignature(cmdlet) +
                text;
            
            WriteLog(LogLevels.Debug, reportString);
        }
        
        protected internal void WriteDebug(CommonCmdletBase cmdlet, object obj)
        {
            string reportString =
                CmdletSignature(cmdlet) +
                obj.ToString();
            
            WriteLog(LogLevels.Debug, reportString);
        }
        
        protected internal void WriteInfo(CommonCmdletBase cmdlet, string text)
        {
            string reportString =
                CmdletSignature(cmdlet) +
                text;
            
            Logger.Info(reportString);
        }
        
        protected internal void WriteWarn(CommonCmdletBase cmdlet, string text)
        {
            string reportString =
                CmdletSignature(cmdlet) +
                text;
            
            Logger.Warn(reportString);
        }
        
        protected override bool CheckSingleObject(PSCmdletBase cmdlet, object outputObject)
        {
            return WriteObjectMethod010CheckOutputObject(outputObject);
        }
        protected override void BeforeWriteCollection(PSCmdletBase cmdlet, object[] outputObjectCollection) {}
        protected override void BeforeWriteCollection(PSCmdletBase cmdlet, List<object> outputObjectCollection) {}
        protected override void BeforeWriteCollection(PSCmdletBase cmdlet, ArrayList outputObjectCollection) {}
        protected override void BeforeWriteCollection(PSCmdletBase cmdlet, IList outputObjectCollection) {}
        protected override void BeforeWriteCollection(PSCmdletBase cmdlet, IEnumerable outputObjectCollection) {}
        protected override void BeforeWriteCollection(PSCmdletBase cmdlet, ICollection outputObjectCollection) {}
        protected override void BeforeWriteCollection(PSCmdletBase cmdlet, Hashtable outputObjectCollection) {}
        protected override void BeforeWriteSingleObject(PSCmdletBase cmdlet, object outputObject) {}

        protected override void WriteSingleObject(PSCmdletBase cmdlet, object outputObject)
        {
            WriteObjectMethod020Highlight(cmdlet, outputObject);
            
            WriteObjectMethod030RunScriptBlocks(cmdlet, outputObject);
            
            WriteObjectMethod040SetTestResult(cmdlet, outputObject);
            
            WriteObjectMethod045OnSuccessScreenshot(cmdlet, outputObject);
            
            WriteObjectMethod050OnSuccessDelay(cmdlet, outputObject);
            
            WriteObjectMethod060OutputResult(cmdlet, outputObject);
            
            WriteObjectMethod070Report(cmdlet, outputObject);
        }
        
        protected override void AfterWriteSingleObject(PSCmdletBase cmdlet, object outputObject) {}
        protected override void AfterWriteCollection(PSCmdletBase cmdlet, object[] outputObjectCollection) {}
        protected override void AfterWriteCollection(PSCmdletBase cmdlet, List<object> outputObjectCollection) {}
        protected override void AfterWriteCollection(PSCmdletBase cmdlet, ArrayList outputObjectCollection) {}
        protected override void AfterWriteCollection(PSCmdletBase cmdlet, IList outputObjectCollection) {}
        protected override void AfterWriteCollection(PSCmdletBase cmdlet, IEnumerable outputObjectCollection) {}
        protected override void AfterWriteCollection(PSCmdletBase cmdlet, ICollection outputObjectCollection) {}
        protected override void AfterWriteCollection(PSCmdletBase cmdlet, Hashtable outputObjectCollection) {}

        protected bool WriteObjectMethod010CheckOutputObject(object outputObject)
        {
            
            bool result = false || null != outputObject;

            /*
            bool result = false;
            
            if (null != outputObject) {
                result = true;
            }
            */
            return result;
        }

        protected void WriteObjectMethod020Highlight(PSCmdletBase cmdlet, object outputObject)
        {
            // 20131109
            //if (null == (outputObject as AutomationElement)) {
            if (null == (outputObject as IMySuperWrapper)) {
                return;
            }
            
            if (string.Empty != ((HasScriptBlockCmdletBase)cmdlet).Banner) {

                UiaHelper.ShowBanner(((HasScriptBlockCmdletBase)cmdlet).Banner);

            }

            if (!Preferences.Highlight && !((HasScriptBlockCmdletBase) cmdlet).Highlight) return;
            //try{
            // 20131109
            //AutomationElement element = null;
            IMySuperWrapper element = null;

            //if (cmdlet != null && !(cmdlet is WizardCmdletBase)) {
            if (cmdlet == null || cmdlet is WizardCmdletBase) return;
            try {
                
                // 20131109
                //element = outputObject as AutomationElement;
                element = outputObject as IMySuperWrapper;
                if (null != element &&
                //if (element is AutomationElement &&
                    (int)element.Current.ProcessId > 0) {

                        WriteVerbose(this, "current cmdlet: " + GetType().Name);
                        WriteVerbose(this, "highlighting the following element:");
                        WriteVerbose(this, "Name = " + element.Current.Name);
                        WriteVerbose(this, "AutomationId = " + element.Current.AutomationId);
                        WriteVerbose(this, "ControlType = " + element.Current.ControlType.ProgrammaticName);
                        WriteVerbose(this, "X = " + element.Current.BoundingRectangle.X.ToString());
                        WriteVerbose(this, "Y = " + element.Current.BoundingRectangle.Y.ToString());
                        WriteVerbose(this, "Width = " + element.Current.BoundingRectangle.Width.ToString());
                        WriteVerbose(this, "Height = " + element.Current.BoundingRectangle.Height.ToString());
                    }
                /*
                    if (element is AutomationElement &&
                        (int)element.Current.ProcessId > 0) {

                            this.WriteVerbose(this, "current cmdlet: " + this.GetType().Name);
                            this.WriteVerbose(this, "highlighting the following element:");
                            this.WriteVerbose(this, "Name = " + element.Current.Name);
                            this.WriteVerbose(this, "AutomationId = " + element.Current.AutomationId);
                            this.WriteVerbose(this, "ControlType = " + element.Current.ControlType.ProgrammaticName);
                            this.WriteVerbose(this, "X = " + element.Current.BoundingRectangle.X.ToString());
                            this.WriteVerbose(this, "Y = " + element.Current.BoundingRectangle.Y.ToString());
                            this.WriteVerbose(this, "Width = " + element.Current.BoundingRectangle.Width.ToString());
                            this.WriteVerbose(this, "Height = " + element.Current.BoundingRectangle.Height.ToString());
                        }
                    */
            } catch { //(Exception eee) {
                // nothing to do
                // just failed to highlight
            }
            //  // 
            // 20131109
            //if (element != null && element is AutomationElement &&
            if (element == null || !(element is IMySuperWrapper) || (int) element.Current.ProcessId <= 0) return;
            // 20131109
            //this.WriteVerbose(this, "as it is an AutomationElement, it should be highlighted");
            WriteVerbose(this, "as it is an IMySuperWrapper, it should be highlighted");
                        
            // 20121002
            //if (Preferences.Highlight || ((HasScriptBlockCmdletBase)cmdlet).Highlight) {
            try {
                WriteVerbose(this, "run Highlighter");
                if (Preferences.ShowExecutionPlan) {
                    if (Preferences.ShowInfoToolTip) {
                        ExecutionPlan.Enqueue(element, HighlighterGeneration, "name: " + element.Current.Name);
                    } else {
                        ExecutionPlan.Enqueue(element, HighlighterGeneration, string.Empty);
                    }
                    //this.Enqueue(element);
                } else {
//                                if (Preferences.ShowInfoToolTip) {
                    UiaHelper.Highlight(element);
//                                } else {
//                                    UiaHelper.Highlight(element);
//                                }
                }
                WriteVerbose(this, "after running the Highlighter");
            } catch (Exception ee) {
                WriteVerbose(this, "unable to highlight: " + ee.Message);
                WriteVerbose(this, outputObject.ToString());
            }
            //}

            /*
            if (element != null && element is IMySuperWrapper &&
                (int)element.Current.ProcessId > 0) {
                
                // 20131109
                //this.WriteVerbose(this, "as it is an AutomationElement, it should be highlighted");
                this.WriteVerbose(this, "as it is an IMySuperWrapper, it should be highlighted");
                        
                // 20121002
                //if (Preferences.Highlight || ((HasScriptBlockCmdletBase)cmdlet).Highlight) {
                try {
                    this.WriteVerbose(this, "run Highlighter");
                    if (Preferences.ShowExecutionPlan) {
                        if (Preferences.ShowInfoToolTip) {
                            ExecutionPlan.Enqueue(element, CommonCmdletBase.HighlighterGeneration, "name: " + element.Current.Name);
                        } else {
                            ExecutionPlan.Enqueue(element, CommonCmdletBase.HighlighterGeneration, string.Empty);
                        }
                        //this.Enqueue(element);
                    } else {
//                                if (Preferences.ShowInfoToolTip) {
                        UiaHelper.Highlight(element);
//                                } else {
//                                    UiaHelper.Highlight(element);
//                                }
                    }
                    this.WriteVerbose(this, "after running the Highlighter");
                } catch (Exception ee) {
                    this.WriteVerbose(this, "unable to highlight: " + ee.Message);
                    this.WriteVerbose(this, outputObject.ToString());
                }
                //}
            } // if (element != null && element is AutomationElement &&
            */

            /*
            if (element != null && element is AutomationElement &&
                (int)element.Current.ProcessId > 0) {
                        
                    this.WriteVerbose(this, "as it is an AutomationElement, it should be highlighted");
                        
                    // 20121002
                    //if (Preferences.Highlight || ((HasScriptBlockCmdletBase)cmdlet).Highlight) {
                    try {
                        this.WriteVerbose(this, "run Highlighter");
                        if (Preferences.ShowExecutionPlan) {
                            if (Preferences.ShowInfoToolTip) {
                                ExecutionPlan.Enqueue(element, CommonCmdletBase.HighlighterGeneration, "name: " + element.Current.Name);
                            } else {
                                ExecutionPlan.Enqueue(element, CommonCmdletBase.HighlighterGeneration, string.Empty);
                            }
                            //this.Enqueue(element);
                        } else {
//                                if (Preferences.ShowInfoToolTip) {
                            UiaHelper.Highlight(element);
//                                } else {
//                                    UiaHelper.Highlight(element);
//                                }
                        }
                        this.WriteVerbose(this, "after running the Highlighter");
                    } catch (Exception ee) {
                        this.WriteVerbose(this, "unable to highlight: " + ee.Message);
                        this.WriteVerbose(this, outputObject.ToString());
                    }
                    //}
                } // if (element != null && element is AutomationElement &&
            */

            /*
            if (Preferences.Highlight || ((HasScriptBlockCmdletBase)cmdlet).Highlight) {
                //try{
                AutomationElement element = null;

                if (cmdlet != null && !(cmdlet is WizardCmdletBase)) {

                    try {

                        element = outputObject as AutomationElement;
                        if (element is AutomationElement &&
                            (int)element.Current.ProcessId > 0) {

                            this.WriteVerbose(this, "current cmdlet: " + this.GetType().Name);
                            this.WriteVerbose(this, "highlighting the following element:");
                            this.WriteVerbose(this, "Name = " + element.Current.Name);
                            this.WriteVerbose(this, "AutomationId = " + element.Current.AutomationId);
                            this.WriteVerbose(this, "ControlType = " + element.Current.ControlType.ProgrammaticName);
                            this.WriteVerbose(this, "X = " + element.Current.BoundingRectangle.X.ToString());
                            this.WriteVerbose(this, "Y = " + element.Current.BoundingRectangle.Y.ToString());
                            this.WriteVerbose(this, "Width = " + element.Current.BoundingRectangle.Width.ToString());
                            this.WriteVerbose(this, "Height = " + element.Current.BoundingRectangle.Height.ToString());
                        }
                    } catch { //(Exception eee) {
                        // nothing to do
                        // just failed to highlight
                    }
                    //  // 
                    if (element != null && element is AutomationElement &&
                        (int)element.Current.ProcessId > 0) {
                        
                        this.WriteVerbose(this, "as it is an AutomationElement, it should be highlighted");
                        
                        // 20121002
                        //if (Preferences.Highlight || ((HasScriptBlockCmdletBase)cmdlet).Highlight) {
                        try {
                            this.WriteVerbose(this, "run Highlighter");
                            if (Preferences.ShowExecutionPlan) {
                                if (Preferences.ShowInfoToolTip) {
                                    ExecutionPlan.Enqueue(element, CommonCmdletBase.HighlighterGeneration, "name: " + element.Current.Name);
                                } else {
                                    ExecutionPlan.Enqueue(element, CommonCmdletBase.HighlighterGeneration, string.Empty);
                                }
                                //this.Enqueue(element);
                            } else {
//                                if (Preferences.ShowInfoToolTip) {
                                    UiaHelper.Highlight(element);
//                                } else {
//                                    UiaHelper.Highlight(element);
//                                }
                            }
                            this.WriteVerbose(this, "after running the Highlighter");
                        } catch (Exception ee) {
                            this.WriteVerbose(this, "unable to highlight: " + ee.Message);
                            this.WriteVerbose(this, outputObject.ToString());
                        }
                        //}
                    } // if (element != null && element is AutomationElement &&
                } // if (cmdlet != null && !(cmdlet is WizardCmdletBase)) {
            } // if (Preferences.Highlight || ((HasScriptBlockCmdletBase)cmdlet).Highlight) {
            */
        }
        
        protected void WriteObjectMethod030RunScriptBlocks(PSCmdletBase cmdlet, object outputObject)
        {
            WriteVerbose(this, "is going to run scriptblocks");
            if (cmdlet == null) return;
            // run scriptblocks
            if (!(cmdlet is HasScriptBlockCmdletBase)) return;
            WriteVerbose(this, "cmdlet is of the HasScriptBlockCmdletBase type");
            if (outputObject == null) {
                WriteVerbose(this, "run OnError script blocks (null)");
                RunOnErrorScriptBlocks(((HasScriptBlockCmdletBase)cmdlet), null);
            } else if (outputObject is bool && ((bool)outputObject) == false) {
                WriteVerbose(this, "run OnError script blocks (false)");
                RunOnErrorScriptBlocks(((HasScriptBlockCmdletBase)cmdlet), null);
            } else {
                WriteVerbose(this, "run OnSuccess script blocks");
                RunOnSuccessScriptBlocks(((HasScriptBlockCmdletBase)cmdlet), null);
            }

            /*
            if (cmdlet != null) {
                // run scriptblocks
                if (cmdlet is HasScriptBlockCmdletBase) {
                    this.WriteVerbose(this, "cmdlet is of the HasScriptBlockCmdletBase type");
                    if (outputObject == null) {
                        this.WriteVerbose(this, "run OnError script blocks (null)");
                        RunOnErrorScriptBlocks(((HasScriptBlockCmdletBase)cmdlet), null);
                    } else if (outputObject is bool && ((bool)outputObject) == false) {
                        this.WriteVerbose(this, "run OnError script blocks (false)");
                        RunOnErrorScriptBlocks(((HasScriptBlockCmdletBase)cmdlet), null);
                    } else if (outputObject != null) {
                        this.WriteVerbose(this, "run OnSuccess script blocks");
                        RunOnSuccessScriptBlocks(((HasScriptBlockCmdletBase)cmdlet), null);
                    }
                }
            }
            */
        }
        
        protected void WriteObjectMethod040SetTestResult(PSCmdletBase cmdlet, object outputObject)
        {
            if (cmdlet == null) return;
            try {
                CurrentData.LastResult = outputObject;

                string iInfo = string.Empty;
                if (!string.IsNullOrEmpty(((HasScriptBlockCmdletBase)cmdlet).TestResultName)) {
                /*
                if (((HasScriptBlockCmdletBase)cmdlet).TestResultName != null &&
                    ((HasScriptBlockCmdletBase)cmdlet).TestResultName.Length > 0) {
                */

                        TmxHelper.CloseTestResult(((HasScriptBlockCmdletBase)cmdlet).TestResultName,
                            ((HasScriptBlockCmdletBase)cmdlet).TestResultId,
                            ((HasScriptBlockCmdletBase)cmdlet).TestPassed,
                            ((HasScriptBlockCmdletBase)cmdlet).KnownIssue, //false, // isKnownIssue
                            MyInvocation,
                            null, // Error
                            string.Empty,
                            TestResultOrigins.Logical,
                            true);

                    } else {
                        if (!Preferences.EveryCmdletAsTestResult) return;
                        ((HasScriptBlockCmdletBase)cmdlet).TestResultName =
                            GetGeneratedTestResultNameByPosition(
                                MyInvocation.Line,
                                MyInvocation.PipelinePosition);
                        ((HasScriptBlockCmdletBase)cmdlet).TestResultId = string.Empty;
                        ((HasScriptBlockCmdletBase)cmdlet).TestPassed = true;

                        TmxHelper.CloseTestResult(((HasScriptBlockCmdletBase)cmdlet).TestResultName,
                            string.Empty, //((HasScriptBlockCmdletBase)cmdlet).TestResultId, // empty, to be generated
                            ((HasScriptBlockCmdletBase)cmdlet).TestPassed,
                            ((HasScriptBlockCmdletBase)cmdlet).KnownIssue, //false, // isKnownIssue
                            MyInvocation,
                            null, // Error
                            string.Empty,
                            TestResultOrigins.Automatic,
                            false);

                        /*
                        if (Preferences.EveryCmdletAsTestResult) {

                            ((HasScriptBlockCmdletBase)cmdlet).TestResultName =
                                GetGeneratedTestResultNameByPosition(
                                    this.MyInvocation.Line,
                                    this.MyInvocation.PipelinePosition);
                            ((HasScriptBlockCmdletBase)cmdlet).TestResultId = string.Empty;
                            ((HasScriptBlockCmdletBase)cmdlet).TestPassed = true;

                            TMX.TmxHelper.CloseTestResult(((HasScriptBlockCmdletBase)cmdlet).TestResultName,
                                string.Empty, //((HasScriptBlockCmdletBase)cmdlet).TestResultId, // empty, to be generated
                                ((HasScriptBlockCmdletBase)cmdlet).TestPassed,
                                ((HasScriptBlockCmdletBase)cmdlet).KnownIssue, //false, // isKnownIssue
                                this.MyInvocation,
                                null, // Error
                                string.Empty,
                                TMX.TestResultOrigins.Automatic,
                                false);
                        }
                        */
                    }
            }
            catch (Exception eeee) {
                WriteVerbose(this, "for working with test results you need to import the TMX module");
            }

            /*
            if (cmdlet != null) {

                try {
                    CurrentData.LastResult = outputObject;

                    string iInfo = string.Empty;
                    if (((HasScriptBlockCmdletBase)cmdlet).TestResultName != null &&
                        ((HasScriptBlockCmdletBase)cmdlet).TestResultName.Length > 0) {

                        TMX.TmxHelper.CloseTestResult(((HasScriptBlockCmdletBase)cmdlet).TestResultName,
                                                      ((HasScriptBlockCmdletBase)cmdlet).TestResultId,
                                                      ((HasScriptBlockCmdletBase)cmdlet).TestPassed,
                                                      ((HasScriptBlockCmdletBase)cmdlet).KnownIssue, //false, // isKnownIssue
                                                      this.MyInvocation,
                                                      null, // Error
                                                      string.Empty,
                                                      TMX.TestResultOrigins.Logical,
                                                      true);

                    } else {

                        if (Preferences.EveryCmdletAsTestResult) {

                            ((HasScriptBlockCmdletBase)cmdlet).TestResultName =
                                GetGeneratedTestResultNameByPosition(
                                    this.MyInvocation.Line,
                                    this.MyInvocation.PipelinePosition);
                            ((HasScriptBlockCmdletBase)cmdlet).TestResultId = string.Empty;
                            ((HasScriptBlockCmdletBase)cmdlet).TestPassed = true;

                            TMX.TmxHelper.CloseTestResult(((HasScriptBlockCmdletBase)cmdlet).TestResultName,
                                                          string.Empty, //((HasScriptBlockCmdletBase)cmdlet).TestResultId, // empty, to be generated
                                                          ((HasScriptBlockCmdletBase)cmdlet).TestPassed,
                                                          ((HasScriptBlockCmdletBase)cmdlet).KnownIssue, //false, // isKnownIssue
                                                          this.MyInvocation,
                                                          null, // Error
                                                          string.Empty,
                                                          TMX.TestResultOrigins.Automatic,
                                                          false);
                        }
                    }
                }
                catch (Exception eeee) {
                    this.WriteVerbose(this, "for working with test results you need to import the TMX module");
                }
            }
            */
        }

        protected void WriteObjectMethod045OnSuccessScreenshot(PSCmdletBase cmdlet, object outputObject)
        {
            WriteVerbose(this, "WriteObjectMethod045OnSuccessScreenshot UIAutomation");

            if (Preferences.OnSuccessScreenShot) {
                
                //                if (Preferences.HideHighlighterOnScreenShotTaking) {
                //                    UiaHelper.HideHighlighters();
                //                }
                
                UiaHelper.GetScreenshotOfAutomationElement(
                    (cmdlet as HasControlInputCmdletBase),
                    // 20131109
                    //(outputObject as AutomationElement), //(cmdlet as HasControlInputCmdletBase),
                    (outputObject as IMySuperWrapper),
                    CmdletName(cmdlet), //string.Empty,
                    true,
                    0,
                    0,
                    0,
                    0,
                    string.Empty,
                    Preferences.OnSuccessScreenShotFormat);
                
            }
        }
        
        protected void WriteObjectMethod050OnSuccessDelay(PSCmdletBase cmdlet, object outputObject)
        {
            //System.Threading.Thread.Sleep(Preferences.OnSuccessDelay);
            if (cmdlet != null) {
                // remove the Turbo timeout
                if ((cmdlet as HasTimeoutCmdletBase) != null) {
                    
                    WriteVerbose(this, "cmdlet as HasTimeoutCmdletBase");

                    if ((CurrentData.CurrentWindow != null &&
                        CurrentData.LastResult != null) ||
                        // 20131109
                        //(outputObject as AutomationElement) != null) {
                        (outputObject as IMySuperWrapper) != null) {

                        WriteVerbose(this, "(CurrentData.CurrentWindow != null && " +
                                          "CurrentData.LastResult != null) || " +
                                          // 20131109
                                          //"(outputObject as AutomationElement) != null");
                                          "(outputObject as IMySuperWrapper) != null");

                        if (Preferences.StoredDefaultTimeout != 0) {

                            WriteVerbose(this, "Preferences.StoredDefaultTimeout != 0");
                            
                            if (!Preferences.TimeoutSetByCustomer) {

                                WriteVerbose(this, "! Preferences.TimeoutSetByCustomer");
                                
                                Preferences.Timeout = Preferences.StoredDefaultTimeout;

                                Preferences.StoredDefaultTimeout = 0;
                            }
                        }
                    }
                }


            }
            WriteVerbose(this, "sleeping if sleep time is provided");
            Thread.Sleep(Preferences.OnSuccessDelay);
        }
        
        protected void WriteObjectMethod060OutputResult(PSCmdletBase cmdlet, object outputObject)
        {
            // 20131109
            //AutomationElement element = null;
            /*
            IMySuperWrapper element = null;
            */
            WriteVerbose(this, "outputting the result object");
            if (cmdlet == null) return;
            try {
                // 20131109
                //element = outputObject as AutomationElement;
                IMySuperWrapper element = outputObject as IMySuperWrapper;
                WriteVerbose(this, "getting the element again to ensure that it still exists");
                //this.WriteVerbose(this, (element as AutomationElement).ToString());
                if (!(cmdlet is WizardCmdletBase) &&
                    (null != element)) {
                    //(element is AutomationElement)){

                    WriteVerbose(this, "returning the object");
                    WriteObject(outputObject);
                } else if ((cmdlet is WizardCmdletBase)) {
                    WriteVerbose(this, "returning the wizard or step");
                    WriteObject(outputObject);
                // 20131108
                } else { //if (!(outputObject is bool)) {
                    WriteVerbose("returning as is");
                    WriteObject(outputObject);
                } //else {
                //    this.WriteVerbose("returning true");
                //    this.WriteObject(true);
                //}

                /*
                if (!(cmdlet is WizardCmdletBase) &&
                    (element is AutomationElement)){
                        this.WriteVerbose(this, "returning the object");
                        this.WriteObject(outputObject);
                    } else if ((cmdlet is WizardCmdletBase)) {
                        this.WriteVerbose(this, "returning the wizard or step");
                        this.WriteObject(outputObject);
                    } else {
                        this.WriteVerbose("returning true");
                        this.WriteObject(true);
                    }
                */
            } catch { // (Exception eeeee) {
                // test
                // 20131109
                //this.WriteVerbose(this, "failed to issue the result object of AutomationElement type");
                WriteVerbose(this, "failed to issue the result object of IMySuperWrapper type");
                WriteVerbose(this, "returning as is");
                WriteObject(outputObject);
            }

            /*
            if (cmdlet != null) {
                try {
                    element = outputObject as AutomationElement;
                    this.WriteVerbose(this, "getting the element again to ensure that it still exists");
                    this.WriteVerbose(this, (element as AutomationElement).ToString());
                    if (!(cmdlet is WizardCmdletBase) &&
                        (element is AutomationElement)){
                        this.WriteVerbose(this, "returning the object");
                        this.WriteObject(outputObject);
                    } else if ((cmdlet is WizardCmdletBase)) {
                        this.WriteVerbose(this, "returning the wizard or step");
                        this.WriteObject(outputObject);
                    } else {
                        this.WriteVerbose("returning true");
                        this.WriteObject(true);
                    }
                } catch { // (Exception eeeee) {
                    // test
                    this.WriteVerbose(this, "failed to issue the result object of AutomationElement type");
                    this.WriteVerbose(this, "returning as is");
                    this.WriteObject(outputObject);
                }
            }
            */
        }
        
        protected void WriteObjectMethod070Report(PSCmdletBase cmdlet, object outputObject)
        {
            if (!Preferences.AutoLog) return;
            string reportString =
                CmdletSignature(((CommonCmdletBase)cmdlet));
                
            switch (outputObject.GetType().Name) {
                case "AutomationElement":
                case "IMySuperWrapper":
                    try {
                        
                        // 20131109
                        //AutomationElement ae = outputObject as AutomationElement;
                        IMySuperWrapper ae = outputObject as IMySuperWrapper;
                        if (null != ae) {
                                
                            reportString +=
                                "Name: '" +
                                ae.Current.Name +
                                "', AutomationId: '" +
                                ae.Current.AutomationId +
                                "', Class: '" +
                                ae.Current.ClassName +
                                "'";
                                
                            //ValuePattern vPattern = null;
                            object vPattern = null;
                            if (ae.TryGetCurrentPattern(ValuePattern.Pattern, out vPattern)) {
                                    
                                reportString +=
                                    ", Value: '" +
                                    ((ValuePattern)vPattern).Current.Value +
                                    "'";
                            }
                        }
                    }
                    catch {}
                    break;
                case "Wizard":
                    reportString +=
                        "Name: '" +
                        ((Wizard)outputObject).Name +
                        "', Steps count: " +
                        ((Wizard)outputObject).Steps.Count.ToString();
                    break;
                case "WizardStep":
                    reportString +=
                        "Name: '" +
                        ((WizardStep)outputObject).Name + 
                        "'";
                    break;
                case "Hashtable":
                    reportString +=
                        ConvertHashtableToString((Hashtable)outputObject);
                    break;
                case "Hashtable[]":
                    reportString +=
                        ConvertHashtablesArrayToString((Hashtable[])outputObject);
                    break;
                case "Boolean":
                    reportString +=
                        outputObject.ToString();
                    break;
                case "String":
                    reportString += outputObject;
                    break;
                default:
                        
                    try {
                            
                        if (cmdlet is GetControlStateCmdletBase) {
                                
                            Hashtable[] hashtables =
                                ((GetControlStateCmdletBase)cmdlet).SearchCriteria;
                            reportString +=
                                ConvertHashtablesArrayToString(hashtables);
                        }
                        if (cmdlet is WaitUiaWindowCommand) {
                                
                            reportString +=
                                "Name: '" +
                                CurrentData.CurrentWindow.Current.Name +
                                "', AutomationId: '" +
                                CurrentData.CurrentWindow.Current.AutomationId +
                                "', Class: '" +
                                CurrentData.CurrentWindow.Current.ClassName +
                                "'";
                        }
                        // 20131020
                        if (cmdlet is DiscoveryCmdletBase) {
                            reportString += outputObject.ToString();
                        }
                    }
                    catch {
                        reportString +=
                            outputObject.GetType().Name;
                    }
                    break;
            }
                

                
            if (cmdlet != null && reportString != null && reportString != string.Empty) { //try { WriteVerbose(reportString);
                WriteVerbose(reportString);
            }
            WriteLog(LogLevels.Info, reportString);

            /*
            if (Preferences.AutoLog) {
                string reportString =
                    CmdletSignature(((CommonCmdletBase)cmdlet));
                
                switch (outputObject.GetType().Name) {
                    case "AutomationElement":
                        try {
                            
                            AutomationElement ae = outputObject as AutomationElement;
                            if (null != ae) {
                                
                                reportString +=
                                    "Name: '" +
                                    ae.Current.Name +
                                    "', AutomationId: '" +
                                    ae.Current.AutomationId +
                                    "', Class: '" +
                                    ae.Current.ClassName +
                                    "'";
                                
                                //ValuePattern vPattern = null;
                                object vPattern = null;
                                if (ae.TryGetCurrentPattern(ValuePattern.Pattern, out vPattern)) {
                                    
                                    reportString +=
                                        ", Value: '" +
                                        ((ValuePattern)vPattern).Current.Value +
                                        "'";
                                }
                            }
                        }
                        catch {}
                        break;
                    case "Wizard":
                        reportString +=
                            "Name: '" +
                            ((Wizard)outputObject).Name +
                            "', Steps count: " +
                            ((Wizard)outputObject).Steps.Count.ToString();
                        break;
                    case "WizardStep":
                        reportString +=
                            "Name: '" +
                            ((WizardStep)outputObject).Name + 
                            "'";
                        break;
                    case "Hashtable":
                        reportString +=
                            this.ConvertHashtableToString((Hashtable)outputObject);
                        break;
                    case "Hashtable[]":
                        reportString +=
                            this.ConvertHashtablesArrayToString((Hashtable[])outputObject);
                        break;
                    case "Boolean":
                        reportString +=
                            outputObject.ToString();
                        break;
                    case "String":
                        reportString += outputObject;
                        break;
                    default:
                        
                        try {
                            
                            if (cmdlet is GetControlStateCmdletBase) {
                                
                                Hashtable[] hashtables =
                                    ((GetControlStateCmdletBase)cmdlet).SearchCriteria;
                                reportString +=
                                    this.ConvertHashtablesArrayToString(hashtables);
                            }
                            if (cmdlet is Commands.WaitUiaWindowCommand) {
                                
                                reportString +=
                                    "Name: '" +
                                    CurrentData.CurrentWindow.Current.Name +
                                    "', AutomationId: '" +
                                    CurrentData.CurrentWindow.Current.AutomationId +
                                    "', Class: '" +
                                    CurrentData.CurrentWindow.Current.ClassName +
                                    "'";
                            }
                            // 20131020
                            if (cmdlet is DiscoveryCmdletBase) {
                                reportString += outputObject.ToString();
                            }
                        }
                        catch {
                            reportString +=
                                outputObject.GetType().Name;
                        }
                    	break;
                }
                

                
                if (cmdlet != null && reportString != null && reportString != string.Empty) { //try { WriteVerbose(reportString);
                    this.WriteVerbose(reportString);
                }
                this.WriteLog(LogLevels.Info, reportString);
            }
            */
        }
        
        internal static int HighlighterGeneration = 0;
        
        public override void WriteObject(PSCmdletBase cmdlet, object[] outputObjectCollection)
        {
            HighlighterGeneration++;
            base.WriteObject(cmdlet, outputObjectCollection);
        }
        
        public override void WriteObject(PSCmdletBase cmdlet, List<object> outputObjectCollection)
        {
            HighlighterGeneration++;
            base.WriteObject(cmdlet, outputObjectCollection);
        }
        
        public override void WriteObject(PSCmdletBase cmdlet, ArrayList outputObjectCollection)
        {
            HighlighterGeneration++;
            base.WriteObject(cmdlet, outputObjectCollection);
        }
        
        public override void WriteObject(PSCmdletBase cmdlet, ICollection outputObjectCollection)
        {
            HighlighterGeneration++;
            base.WriteObject(cmdlet, outputObjectCollection);
        }
        
        private void writeErrorToTheList(ErrorRecord err)
        {
            CurrentData.Error.Add(err);
            if (CurrentData.Error.Count <= Preferences.MaximumErrorCount) return;
            do{
                CurrentData.Error.RemoveAt(0);
            } while (CurrentData.Error.Count > Preferences.MaximumErrorCount);
            CurrentData.Error.Capacity = Preferences.MaximumErrorCount;

            /*
            if (CurrentData.Error.Count > Preferences.MaximumErrorCount) {
                do{
                    CurrentData.Error.RemoveAt(0);
                } while (CurrentData.Error.Count > Preferences.MaximumErrorCount);
                CurrentData.Error.Capacity = Preferences.MaximumErrorCount;
            }
            */
        }
        
        // 20131113
        protected override void WriteSingleError(PSCmdletBase cmdlet, ErrorRecord errorRecord, bool terminating)
        {
            WriteErrorMethod010RunScriptBlocks(cmdlet);
            
            WriteErrorMethod020SetTestResult(cmdlet, errorRecord);
            
            WriteErrorMethod030ChangeTimeoutSettings(cmdlet, terminating);
            
            WriteErrorMethod040AddErrorToErrorList(cmdlet, errorRecord);
            
            WriteErrorMethod045OnErrorScreenshot(cmdlet);
            
            WriteErrorMethod050OnErrorDelay(cmdlet);
            
            WriteErrorMethod060OutputError(cmdlet, errorRecord, terminating);
            
            WriteErrorMethod070Report(cmdlet);
        }
        
        protected override void WriteErrorMethod010RunScriptBlocks(PSCmdletBase cmdlet)
        {
            if (cmdlet == null) return;
            // run scriptblocks
            if (cmdlet is HasScriptBlockCmdletBase) {

                RunOnErrorScriptBlocks(((HasScriptBlockCmdletBase)cmdlet), null);
            }

            /*
            if (cmdlet != null) {

                // run scriptblocks
                if (cmdlet is HasScriptBlockCmdletBase) {

                    this.RunOnErrorScriptBlocks(((HasScriptBlockCmdletBase)cmdlet), null);
                }
            }
            */
        }

        protected override void WriteErrorMethod020SetTestResult(PSCmdletBase cmdlet, ErrorRecord errorRecord)
        {
            if (cmdlet == null) return;
            // write error to the test results collection
            TmxHelper.AddTestResultErrorDetail(errorRecord);
                
            // write test result label
            try {
                    
                CurrentData.LastResult = null;
                    
                string iInfo = string.Empty;
                if (!string.IsNullOrEmpty(((HasScriptBlockCmdletBase)cmdlet).TestResultName)) {
                /*
                if (((HasScriptBlockCmdletBase)cmdlet).TestResultName != null &&
                    ((HasScriptBlockCmdletBase)cmdlet).TestResultName.Length > 0) {
                */

                        TmxHelper.CloseTestResult(((HasScriptBlockCmdletBase)cmdlet).TestResultName,
                            ((HasScriptBlockCmdletBase)cmdlet).TestResultId,
                            false, // the only result: FAILED //((HasScriptBlockCmdletBase)cmdlet).TestPassed,
                            false, // because of failure //((HasScriptBlockCmdletBase)cmdlet).KnownIssue,
                            MyInvocation,
                            errorRecord,
                            string.Empty,
                            TestResultOrigins.Automatic,
                            false);
                        
                    } else {
                        if (!Preferences.EveryCmdletAsTestResult) return;
                        ((HasScriptBlockCmdletBase)cmdlet).TestResultName =
                            GetGeneratedTestResultNameByPosition(
                                MyInvocation.Line,
                                MyInvocation.PipelinePosition);
                            
                        ((HasScriptBlockCmdletBase)cmdlet).TestResultId = string.Empty;
                        ((HasScriptBlockCmdletBase)cmdlet).TestPassed = false;
                            
                        TmxHelper.CloseTestResult(((HasScriptBlockCmdletBase)cmdlet).TestResultName,
                            string.Empty, //((HasScriptBlockCmdletBase)cmdlet).TestResultId, // empty, to be generated
                            ((HasScriptBlockCmdletBase)cmdlet).TestPassed,
                            false, // isKnownIssue
                            MyInvocation,
                            errorRecord,
                            string.Empty,
                            TestResultOrigins.Automatic,
                            false);

                        /*
                        if (Preferences.EveryCmdletAsTestResult) {
                            
                            ((HasScriptBlockCmdletBase)cmdlet).TestResultName =
                                GetGeneratedTestResultNameByPosition(
                                    this.MyInvocation.Line,
                                    this.MyInvocation.PipelinePosition);
                            
                            ((HasScriptBlockCmdletBase)cmdlet).TestResultId = string.Empty;
                            ((HasScriptBlockCmdletBase)cmdlet).TestPassed = false;
                            
                            TMX.TmxHelper.CloseTestResult(((HasScriptBlockCmdletBase)cmdlet).TestResultName,
                                string.Empty, //((HasScriptBlockCmdletBase)cmdlet).TestResultId, // empty, to be generated
                                ((HasScriptBlockCmdletBase)cmdlet).TestPassed,
                                false, // isKnownIssue
                                this.MyInvocation,
                                errorRecord,
                                string.Empty,
                                TMX.TestResultOrigins.Automatic,
                                false);
                            
                        }
                        */
                    }
            }
            catch {
                WriteVerbose(this, "for working with test results you need to import the TMX module");
            }

            /*
            if (cmdlet != null) {
                
                // write error to the test results collection
                TMX.TmxHelper.AddTestResultErrorDetail(errorRecord);
                
                // write test result label
                try {
                    
                    CurrentData.LastResult = null;
                    
                    string iInfo = string.Empty;
                    if (((HasScriptBlockCmdletBase)cmdlet).TestResultName != null &&
                        ((HasScriptBlockCmdletBase)cmdlet).TestResultName.Length > 0) {
                        
                        TMX.TmxHelper.CloseTestResult(((HasScriptBlockCmdletBase)cmdlet).TestResultName,
                                                      ((HasScriptBlockCmdletBase)cmdlet).TestResultId,
                                                      false, // the only result: FAILED //((HasScriptBlockCmdletBase)cmdlet).TestPassed,
                                                      false, // because of failure //((HasScriptBlockCmdletBase)cmdlet).KnownIssue,
                                                      this.MyInvocation,
                                                      errorRecord,
                                                      string.Empty,
                                                      TMX.TestResultOrigins.Automatic,
                                                      false);
                        
                    } else {
                        
                        if (Preferences.EveryCmdletAsTestResult) {
                            
                            ((HasScriptBlockCmdletBase)cmdlet).TestResultName =
                                GetGeneratedTestResultNameByPosition(
                                    this.MyInvocation.Line,
                                    this.MyInvocation.PipelinePosition);
                            
                            ((HasScriptBlockCmdletBase)cmdlet).TestResultId = string.Empty;
                            ((HasScriptBlockCmdletBase)cmdlet).TestPassed = false;
                            
                            TMX.TmxHelper.CloseTestResult(((HasScriptBlockCmdletBase)cmdlet).TestResultName,
                                                          string.Empty, //((HasScriptBlockCmdletBase)cmdlet).TestResultId, // empty, to be generated
                                                          ((HasScriptBlockCmdletBase)cmdlet).TestPassed,
                                                          false, // isKnownIssue
                                                          this.MyInvocation,
                                                          errorRecord,
                                                          string.Empty,
                                                          TMX.TestResultOrigins.Automatic,
                                                          false);
                            
                        }
                    }
                }
                catch {
                    WriteVerbose(this, "for working with test results you need to import the TMX module");
                }
            }
            */
        }
        
        
        protected override void WriteErrorMethod030ChangeTimeoutSettings(PSCmdletBase cmdlet, bool terminating)
        {
            // set the Turbo timeout
            if ((!(cmdlet is HasTimeoutCmdletBase)) || (cmdlet as HasTimeoutCmdletBase) == null) return;
            if (!terminating ||
                ((null != CurrentData.LastResult || null != CurrentData.CurrentWindow) &&
                 (null != CurrentData.LastResult || !((HasTimeoutCmdletBase) cmdlet).IsCritical))) return;
            if (Preferences.TimeoutSetByCustomer != (true &&
                                                     0 == Preferences.StoredDefaultTimeout)) return;
            int timeoutToStore = Preferences.Timeout;
            Preferences.Timeout = Preferences.AfterFailTurboTimeout;
            Preferences.TimeoutSetByCustomer = false;
            Preferences.StoredDefaultTimeout = timeoutToStore;

            WriteVerbose(this, "Preferences.StoredDefaultTimeout = " + Preferences.StoredDefaultTimeout.ToString());

            /*
                      if (Preferences.TimeoutSetByCustomer = true &&
                                                             0 == Preferences.StoredDefaultTimeout) {
                                                                 int timeoutToStore = Preferences.Timeout;
                                                                 Preferences.Timeout = Preferences.AfterFailTurboTimeout;
                                                                 Preferences.TimeoutSetByCustomer = false;
                                                                 Preferences.StoredDefaultTimeout = timeoutToStore;

                                                                 this.WriteVerbose(this, "Preferences.StoredDefaultTimeout = " + Preferences.StoredDefaultTimeout.ToString());
                                                             }
                        */

            /*
            if ((cmdlet is HasTimeoutCmdletBase) &&
                (cmdlet as HasTimeoutCmdletBase) != null) {
                
                if (terminating && (
                    ( null == CurrentData.LastResult &&  // i.e., no window was caught
                     null == CurrentData.CurrentWindow) ||
                    ( null == CurrentData.LastResult && // i.e., this command was critical
                     ((HasTimeoutCmdletBase)cmdlet).IsCritical))) {

                    if (Preferences.TimeoutSetByCustomer = true &&
                        0 == Preferences.StoredDefaultTimeout) {
                        int timeoutToStore = Preferences.Timeout;
                        Preferences.Timeout = Preferences.AfterFailTurboTimeout;
                        Preferences.TimeoutSetByCustomer = false;
                        Preferences.StoredDefaultTimeout = timeoutToStore;

                        this.WriteVerbose(this, "Preferences.StoredDefaultTimeout = " + Preferences.StoredDefaultTimeout.ToString());
                    }
                }
            }
            */

            //                    // remove the Turbo timeout
            //                    if (cmdlet is HasTimeoutCmdletBase) {
            //                        if (CurrentData.CurrentWindow != null &&
            //                            CurrentData.LastResult != null) {
            //                            if (Preferences.StoredDefaultTimeout != 0) {
            //                                Preferences.Timeout = Preferences.StoredDefaultTimeout;
            //                                Preferences.StoredDefaultTimeout = 0;
            //                            }
            //                        }
            //                    }
        }

        protected override void WriteErrorMethod040AddErrorToErrorList(PSCmdletBase cmdlet, ErrorRecord err)
        {
            // write an error to the Error list
            writeErrorToTheList(err);
        }
        
        protected override void WriteErrorMethod045OnErrorScreenshot(PSCmdletBase cmdlet)
        {
            WriteVerbose(this, "WriteErrorMethod045OnErrorScreenshot UIAutomation");

            if (!Preferences.OnErrorScreenShot) return;
            //UiaHelper.GetScreenshotOfAutomationElement(
            //                UiaHelper.GetScreenshotOfCmdletInput(
            //                    (cmdlet as HasControlInputCmdletBase),
            //                    CmdletName(cmdlet), //string.Empty,
            //                    true,
            //                    0,
            //                    0,
            //                    0,
            //                    0,
            //                    string.Empty,
            //                    UIAutomation.Preferences.OnErrorScreenShotFormat);

            //                if (Preferences.HideHighlighterOnScreenShotTaking) {
            //                    UiaHelper.HideHighlighters();
            //                }
                
            // 20131109
            //AutomationElement elementToTakeScreenShot = null;
            IMySuperWrapper elementToTakeScreenShot = null;
            
            try {
                    
                if (null != CurrentData.CurrentWindow) {
                        
                    cmdlet.WriteVerbose(cmdlet, "taking screenshot of the current window");
                    elementToTakeScreenShot = CurrentData.CurrentWindow;
                } else {
                        
                    cmdlet.WriteVerbose(cmdlet, "taking screenshot of the desktop object");
                    // 20131109
                    //elementToTakeScreenShot = AutomationElement.RootElement;
                    elementToTakeScreenShot = MySuperWrapper.RootElement;
                }
            }
            catch {
                    
                cmdlet.WriteVerbose(cmdlet, "taking screenshot of the desktop object (on fail)");
                // 20131109
                //elementToTakeScreenShot = AutomationElement.RootElement;
                elementToTakeScreenShot = MySuperWrapper.RootElement;
            }
                
            cmdlet.WriteVerbose(cmdlet, "taking screenshot");
            UiaHelper.GetScreenshotOfAutomationElement(
                cmdlet,
                elementToTakeScreenShot,
                CmdletName(cmdlet),
                true,
                0,
                0,
                0,
                0,
                string.Empty,
                Preferences.OnErrorScreenShotFormat);
                
            cmdlet.WriteVerbose(cmdlet, "done");

            /*
            if (UIAutomation.Preferences.OnErrorScreenShot) {
                //UiaHelper.GetScreenshotOfAutomationElement(
                //                UiaHelper.GetScreenshotOfCmdletInput(
                //                    (cmdlet as HasControlInputCmdletBase),
                //                    CmdletName(cmdlet), //string.Empty,
                //                    true,
                //                    0,
                //                    0,
                //                    0,
                //                    0,
                //                    string.Empty,
                //                    UIAutomation.Preferences.OnErrorScreenShotFormat);

                //                if (Preferences.HideHighlighterOnScreenShotTaking) {
                //                    UiaHelper.HideHighlighters();
                //                }
                
                AutomationElement elementToTakeScreenShot = null;
                try {
                    
                    if (null != CurrentData.CurrentWindow) {
                        
                        cmdlet.WriteVerbose(cmdlet, "taking screenshot of the current window");
                        elementToTakeScreenShot = CurrentData.CurrentWindow;
                    } else {
                        
                        cmdlet.WriteVerbose(cmdlet, "taking screenshot of the desktop object");
                        elementToTakeScreenShot = AutomationElement.RootElement;
                    }
                }
                catch {
                    
                    cmdlet.WriteVerbose(cmdlet, "taking screenshot of the desktop object (on fail)");
                    elementToTakeScreenShot = AutomationElement.RootElement;
                }
                
                cmdlet.WriteVerbose(cmdlet, "taking screenshot");
                UiaHelper.GetScreenshotOfAutomationElement(
                    cmdlet,
                    elementToTakeScreenShot,
                    CmdletName(cmdlet),
                    true,
                    0,
                    0,
                    0,
                    0,
                    string.Empty,
                    UIAutomation.Preferences.OnErrorScreenShotFormat);
                
                cmdlet.WriteVerbose(cmdlet, "done");
            }
            */
        }
        
        protected override void WriteErrorMethod050OnErrorDelay(PSCmdletBase cmdlet)
        {
            Thread.Sleep(Preferences.OnErrorDelay);
        }
        
        protected override void WriteErrorMethod060OutputError(PSCmdletBase cmdlet, ErrorRecord err, bool terminating)
        {
            if (terminating) {
                
                WriteLog(LogLevels.Fatal, err);
                
                ThrowTerminatingError(err);
            } else {
                
                WriteLog(LogLevels.Error, err);
                
                WriteError(err);
            }
        }
        
        protected override void WriteErrorMethod070Report(PSCmdletBase cmdlet)
        {
            //WriteVerbose(this, "WriteErrorMethod070Report PSCmdletBase");
        }
        #endregion Write methods
        
        #region sleep and run scripts
        protected internal void SleepAndRunScriptBlocks(HasControlInputCmdletBase cmdlet)
        {
            RunOnSleepScriptBlocks(cmdlet, null);
            Thread.Sleep(Preferences.OnSleepDelay);
        }
        #endregion sleep and run scripts
        
        #region Invoke-UiaScript
        protected internal void RunEventScriptBlocks(HasControlInputCmdletBase cmdlet)
        {
            List<ScriptBlock> blocks =
                new List<ScriptBlock>();
            WriteVerbose(cmdlet,
                              blocks.Count.ToString() +
                              " events to fire");
            if (cmdlet.EventAction != null &&
                cmdlet.EventAction.Length > 0) {
                foreach (ScriptBlock sb in cmdlet.EventAction) {
                    blocks.Add(sb);
                    WriteVerbose(cmdlet,
                                      "the scriptblock: " +
                                      sb.ToString() +
                                      " is ready to be fired");
                }
            }
            
            try {
                runScriptBlocks(blocks, cmdlet, true, null);
            }
            catch (Exception eScriptBlocks) {
                
                cmdlet.WriteError(
                    cmdlet,
                    eScriptBlocks.Message,
                    "ScriptblocksFailed",
                    ErrorCategory.InvalidResult,
                    true);
            }
            // runEventScriptBlocks(blocks, cmdlet); //, true);
        }
        
        protected internal void RunOnSuccessScriptBlocks(HasScriptBlockCmdletBase cmdlet, object[] parameters)
        {
            runTwoScriptBlockCollections(
                Preferences.OnSuccessAction,
                cmdlet.OnSuccessAction,
                cmdlet,
                parameters);
        }
        
        protected internal void RunOnErrorScriptBlocks(HasScriptBlockCmdletBase cmdlet, object[] parameters)
        {
            runTwoScriptBlockCollections(
                Preferences.OnErrorAction,
                cmdlet.OnErrorAction,
                cmdlet,
                parameters);
        }
        
        protected internal void RunOnSleepScriptBlocks(HasControlInputCmdletBase cmdlet, object[] parameters)
        {
            if (cmdlet is HasTimeoutCmdletBase) {
                runTwoScriptBlockCollections(
                    Preferences.OnSleepAction,
                    ((HasTimeoutCmdletBase)cmdlet).OnSleepAction,
                    cmdlet,
                    parameters);
            }
        }
        
        protected internal void RunWizardStartScriptBlocks(WizardCmdletBase cmdlet, Wizard wizard, object[] parameters)
        {

            runTwoScriptBlockCollections(
                null,
                wizard.StartAction,
                cmdlet,
                parameters);

        }
        
        protected internal void RunWizardStopScriptBlocks(WizardCmdletBase cmdlet, Wizard wizard, object[] parameters, bool hereMustBeStopAction)
        {
            
            if (hereMustBeStopAction && (null == wizard.StopAction || 0 == wizard.StopAction.Length)) {
                
                cmdlet.WriteVerbose(cmdlet, "there is no any StopAction scriptblock");
                
                //throw new Exception("There are no StopAction scriptblocks, define at least one");
                cmdlet.WriteError(
                    cmdlet,
                    "There are no StopAction scriptblocks, define at least one",
                    "NoStopActionScriptblocks",
                    ErrorCategory.InvalidArgument,
                    true);
            }
            
            runTwoScriptBlockCollections(
                null,
                wizard.StopAction,
                cmdlet,
                parameters);

        }
        
        protected internal bool RunWizardGetWindowScriptBlocks(WizardCmdletBase cmdlet, Wizard wizard, object[] parameters)
        {
            bool result = false;
            
            // 20130508
            // temporary
            // profiling
            cmdlet.WriteInfo(cmdlet, "running the GetWindowAction scriptblock");
            cmdlet.WriteInfo(cmdlet, "parameters" + parameters);
            
            try {
                runTwoScriptBlockCollections(
                    null,
                    wizard.GetWindowAction,
                    cmdlet,
                    parameters);
                    
                if (null != CurrentData.CurrentWindow) {
                    result = true;
                }
            }
            catch {}
            
            // 20130508
            // temporary
            // profiling
            cmdlet.WriteInfo(cmdlet, "the result of the GetWindowAction scriptblock run is " + result.ToString());
            
            return result;
        }
        
        protected internal void RunWizardStepScriptBlocks(
            WizardCmdletBase cmdlet,
            WizardStep wizardStep,
            WizardStepActions whatToRun,
            object[] parameters)
        {

            switch (whatToRun) {
                case WizardStepActions.Forward:
                    cmdlet.WriteVerbose(
                        cmdlet,
                        "ForwardAction scriptblocks");
    
                    runTwoScriptBlockCollections(
                        wizardStep.Parent.DefaultStepForwardAction,
                        wizardStep.StepForwardAction,
                        cmdlet,
                        parameters);
                    break;
                case WizardStepActions.Backward:
                    cmdlet.WriteVerbose(
                        cmdlet,
                        "BackwardAction scriptblocks");
                    
                    runTwoScriptBlockCollections(
                        wizardStep.Parent.DefaultStepBackwardAction,
                        wizardStep.StepBackwardAction,
                        cmdlet,
                        parameters);
                    break;
                case WizardStepActions.Cancel:
                    cmdlet.WriteVerbose(
                        cmdlet,
                        "CancelAction scriptblocks");
                    
                    runTwoScriptBlockCollections(
                        wizardStep.Parent.DefaultStepCancelAction,
                        wizardStep.StepCancelAction,
                        cmdlet,
                        parameters);
                    break;
//                case WizardStepActions.Stop:
//                    cmdlet.WriteVerbose(
//                        cmdlet,
//                        "StopAction scriptblocks");
//                    
//                    runTwoScriptBlockCollections(
//                        null,
//                        wizardStep.Parent.StopAction,
//                        cmdlet,
//                        parameters);
//                    break;
                default:
                    throw new Exception("Invalid value for WizardStepActions on running scriptblocks");
            }
            
            cmdlet.WriteVerbose(
                cmdlet,
                "Scriptblocks finished");
        }
        
        //protected override void SaveEventInput(
        protected override void SaveEventInput(
            // 20131109
            AutomationElement src,
            //IMySuperWrapper src,
            AutomationEventArgs e,
            string programmaticName,
            bool infoAdded)
        {
            // inform the Wait-UiaEventRaised cmdlet
            try {
                // 20131109
                //CurrentData.LastEventSource = src; //.SourceElement; // as AutomationElement;
                // 20131112
                //CurrentData.LastEventSource = new MySuperWrapper(src);
                CurrentData.LastEventSource = ObjectsFactory.GetMySuperWrapper(src);
                CurrentData.LastEventArgs = e; // as AutomationEventArgs;
                CurrentData.LastEventType = programmaticName;
                CurrentData.LastEventInfoAdded = infoAdded;
            }
            catch {
                //WriteVerbose(this, "failed to register an event in the collection");
            }
        }
        #endregion Invoke-UiaScript
        
        protected internal DateTime StartDate { get; set; }
        // 20131109
        //protected AutomationElement currentWindow { get; set; }
        protected IMySuperWrapper CurrentWindow { get; set; }
        protected ArrayList ResultArrayListOfControls;
        // 20131109
        //protected internal AutomationElement rootElement { get; set; }
        protected internal IMySuperWrapper OddRootElement { get; set; }
        
        /// <summary>
        /// stores the state if there's no way to get it from a cmdlet object
        /// due to complexity of inheritance hierarchy
        /// </summary>
        protected bool caseSensitive { get; set; }
        
        #region Get-UiaControl
        // 20131118
        // object -> Condition
        public AndCondition[] GetControlsConditions(GetControlCollectionCmdletBase cmdlet)
        //public Condition[] getControlsConditions(GetControlCollectionCmdletBase cmdlet)
        {
            // 20131118
            // object -> Condition
            List<AndCondition> conditions =
                new List<AndCondition>();
            //System.Collections.Generic.List<Condition> conditions =
            //    new System.Collections.Generic.List<Condition>();

            if (null != cmdlet.ControlType && 0 < cmdlet.ControlType.Length) {
                foreach (string controlTypeName in cmdlet.ControlType)
                {
                    WriteVerbose(this, "control type: " + controlTypeName);
                    // 20131118
                    // object -> Condition
                    //conditions.Add(GetControlConditions(((GetControlCmdletBase)cmdlet), controlTypeName, cmdlet.CaseSensitive, true)); // as AndCondition);
                    conditions.Add(GetControlConditions(((GetControlCmdletBase)cmdlet), controlTypeName, cmdlet.CaseSensitive, true) as AndCondition);
                }

                /*
                for (int i = 0; i < cmdlet.ControlType.Length; i++) {
                    
                    WriteVerbose(this, "control type: " + cmdlet.ControlType[i]);
                    conditions.Add(getControlConditions(((GetControlCmdletBase)cmdlet), cmdlet.ControlType[i], cmdlet.CaseSensitive, true) as AndCondition);
                }
                */
            } else{
                WriteVerbose(this, "without control type");
                // 20131118
                // object -> Condition
                conditions.Add(GetControlConditions(((GetControlCmdletBase)cmdlet), "", cmdlet.CaseSensitive, true) as AndCondition);
                //conditions.Add(GetControlConditions(((GetControlCmdletBase)cmdlet), "", cmdlet.CaseSensitive, true));
            }
            return conditions.ToArray();
        }
        
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "get")]
        // 20131118
        //public object getControlConditions(GetCmdletBase cmdlet1, string controlType, bool caseSensitive, bool AndVsOr)
        //internal object GetControlConditions(GetCmdletBase cmdlet1, string controlType, bool caseSensitive, bool AndVsOr)
        //internal Condition GetControlConditions(GetCmdletBase cmdlet1, string controlType, bool caseSensitive, bool AndVsOr)
        //public Condition GetControlConditions(GetCmdletBase cmdlet1, string controlType, bool caseSensitive, bool AndVsOr)
        //public AndCondition GetControlConditions(GetCmdletBase cmdlet1, string controlType, bool caseSensitive, bool AndVsOr)
        public object GetControlConditions(GetCmdletBase cmdlet1, string controlType, bool caseSensitive, bool andVsOr)
        {
            ControlType ctrlType = null;
            AndCondition andConditions = null;
            OrCondition orConditions = null;
            PropertyCondition condition = null;
            AndCondition allConditions = null;
            // 20131118
            // object -> Condition
            object conditionsToReturn = null;
            //Condition conditionsToReturn = null;
            //AndCondition conditionsToReturn = null;
            PropertyConditionFlags flags = PropertyConditionFlags.None;
            if (!caseSensitive) {
                flags = PropertyConditionFlags.IgnoreCase;
            }
            
            GetControlCmdletBase cmdlet =
                (GetControlCmdletBase)cmdlet1;
            
            // the TextSearch mode
            if (null != (cmdlet as GetControlCmdletBase) && !string.IsNullOrEmpty(cmdlet.ContainsText) &&
                !andVsOr) {

                cmdlet.Name =
                    (cmdlet as GetControlCmdletBase).AutomationId =
                    (cmdlet as GetControlCmdletBase).Class =
                    (cmdlet as GetControlCmdletBase).Value =
                    (cmdlet as GetControlCmdletBase).ContainsText;

            }

            /*
            if (null != (cmdlet as GetControlCmdletBase) && null != cmdlet.ContainsText &&
                string.Empty != cmdlet.ContainsText &&
                !AndVsOr) {

                cmdlet.Name =
                    (cmdlet as GetControlCmdletBase).AutomationId =
                    (cmdlet as GetControlCmdletBase).Class =
                    (cmdlet as GetControlCmdletBase).Value =
                    (cmdlet as GetControlCmdletBase).ContainsText;

            }
            */

            if (!string.IsNullOrEmpty(controlType)) {
                
                WriteVerbose(this,
                             "getting control with control type = " +
                             controlType);
                ctrlType =
                    UiaHelper.GetControlTypeByTypeName(controlType);
                
                WriteVerbose(cmdlet, "ctrlType = " + ctrlType.ProgrammaticName);
            }

            /*
            if (controlType != null && controlType.Length > 0) {

                WriteVerbose(this,
                             "getting control with control type = " +
                             controlType);
                ctrlType =
                    UiaHelper.GetControlTypeByTypeName(controlType);
                WriteVerbose(cmdlet, "ctrlType = " + ctrlType.ProgrammaticName);
            }
            */
            PropertyCondition ctrlTypeCondition = null,
            classCondition = null, titleCondition = null, autoIdCondition = null;
            PropertyCondition valueCondition = null;
            
            int conditionsCounter = 0;
            if (ctrlType != null) {
                
                ctrlTypeCondition =
                    new PropertyCondition(
                        AutomationElement.ControlTypeProperty,
                        ctrlType); //,
                
                WriteVerbose(cmdlet, "ControlTypeProperty '" +
                             ctrlType.ProgrammaticName + "' is used");
                // 20130128
                //conditionsCounter++;
            }
            // 20120828
            if (!string.IsNullOrEmpty(cmdlet.Class))
                //if (null != cmdlet.Class && cmdlet.Class.Length > 0) {
            {
                
                classCondition =
                    new PropertyCondition(
                        AutomationElement.ClassNameProperty,
                        cmdlet.Class,
                        flags);
                WriteVerbose(cmdlet, "ClassNameProperty '" +
                             cmdlet.Class + "' is used");
                conditionsCounter++;
            }

            /*
            if (cmdlet.Class != null && cmdlet.Class != "")
                //if (null != cmdlet.Class && cmdlet.Class.Length > 0) {
            {

                classCondition =
                    new System.Windows.Automation.PropertyCondition(
                        System.Windows.Automation.AutomationElement.ClassNameProperty,
                        cmdlet.Class,
                        flags);
                WriteVerbose(cmdlet, "ClassNameProperty '" +
                             cmdlet.Class + "' is used");
                conditionsCounter++;
            }
            */
            if (!string.IsNullOrEmpty(cmdlet.AutomationId))
            {
                
                autoIdCondition =
                    new PropertyCondition(
                        AutomationElement.AutomationIdProperty,
                        cmdlet.AutomationId,
                        flags);
                WriteVerbose(cmdlet, "AutomationIdProperty '" +
                             cmdlet.AutomationId + "' is used");
                conditionsCounter++;
            }

            /*
            if (cmdlet.AutomationId != null && cmdlet.AutomationId != "")
            {

                autoIdCondition =
                    new System.Windows.Automation.PropertyCondition(
                        System.Windows.Automation.AutomationElement.AutomationIdProperty,
                        cmdlet.AutomationId,
                        flags);
                WriteVerbose(cmdlet, "AutomationIdProperty '" +
                             cmdlet.AutomationId + "' is used");
                conditionsCounter++;
            }
            */
            if (!string.IsNullOrEmpty(cmdlet.Name)) // allow empty name
            {
                
                titleCondition =
                    new PropertyCondition(
                        AutomationElement.NameProperty,
                        cmdlet.Name,
                        flags);
                WriteVerbose(cmdlet, "NameProperty '" +
                             cmdlet.Name + "' is used");
                conditionsCounter++;
            }

            /*
            if (cmdlet.Name != null && cmdlet.Name != "") // allow empty name
            {

                titleCondition =
                    new System.Windows.Automation.PropertyCondition(
                        System.Windows.Automation.AutomationElement.NameProperty,
                        cmdlet.Name,
                        flags);
                WriteVerbose(cmdlet, "NameProperty '" +
                             cmdlet.Name + "' is used");
                conditionsCounter++;
            }
            */

            if (!string.IsNullOrEmpty(cmdlet.Value))
            {
                
                valueCondition =
                    new PropertyCondition(
                        ValuePattern.ValueProperty,
                        cmdlet.Value,
                        flags);
                WriteVerbose(cmdlet, "ValueProperty '" +
                             cmdlet.Value + "' is used");
                conditionsCounter++;
            }

            /*
            if (cmdlet.Value != null && cmdlet.Value != "")
            {

                valueCondition =
                    new System.Windows.Automation.PropertyCondition(
                        System.Windows.Automation.ValuePattern.ValueProperty,
                        cmdlet.Value,
                        flags);
                WriteVerbose(cmdlet, "ValueProperty '" +
                             cmdlet.Value + "' is used");
                conditionsCounter++;
            }
            */

            // if there is more than one condition excepting ctrlTypeCondition
            if (1 < conditionsCounter)
            {
                
                try {
                    ArrayList l = new ArrayList();
                    if (classCondition != null)l.Add(classCondition);
                    if (titleCondition != null)l.Add(titleCondition);
                    if (autoIdCondition != null)l.Add(autoIdCondition);
                    if (null != valueCondition)l.Add(valueCondition);
                    Type t = typeof(Condition);
                    Condition[] conds =
                        ((Condition[])l.ToArray(t));
                    
                    if (andVsOr) {
                        
                        andConditions =
                            new AndCondition(conds);
                    } else {
                        
                        orConditions =
                            new OrCondition(conds);
                    }
                    
                    if (null != andConditions) {
                        
                        allConditions =
                            new AndCondition(
                                // 20131120
                                // that was experimental
                                ctrlTypeCondition ?? Condition.TrueCondition,
                                //ctrlTypeCondition,
                                andConditions);

                        /*
                        allConditions =
                            new System.Windows.Automation.AndCondition(
                                null == ctrlTypeCondition ? Condition.TrueCondition : ctrlTypeCondition,
                                andConditions);
                        */

                    }
                    if (null != orConditions) {
                        
                        allConditions =
                            new AndCondition(
                                // 20131120
                                // that was experimental
                                ctrlTypeCondition ?? Condition.TrueCondition,
                                //ctrlTypeCondition,
                                orConditions);

                        /*
                        allConditions =
                            new System.Windows.Automation.AndCondition(
                                null == ctrlTypeCondition ? Condition.TrueCondition : ctrlTypeCondition,
                                orConditions);
                        */

                    }

                    WriteVerbose(cmdlet, "used conditions " +
                                 "ClassName = '" + classCondition.Value + "', " +
                                 "ControlType = '" + ctrlTypeCondition.Value + "', " +
                                 "Name = '" + titleCondition.Value + "', " +
                                 "AutomationId = '" + autoIdCondition.Value + "', " +  //"'");
                                 "Value = '" + valueCondition.Value + "'");

                } catch (Exception eConditions) {
                    WriteDebug(cmdlet, "conditions related exception " +
                               eConditions.Message);
                }
                
            } else if (1 == conditionsCounter && null != ctrlTypeCondition) {
                
                if (classCondition != null) { allConditions = new AndCondition(classCondition, ctrlTypeCondition); }
                else if (titleCondition != null) { allConditions = new AndCondition(titleCondition, ctrlTypeCondition); }
                else if (autoIdCondition != null) { allConditions = new AndCondition(autoIdCondition, ctrlTypeCondition); }
                else if (null != valueCondition) { allConditions = new AndCondition(valueCondition, ctrlTypeCondition); }
                WriteVerbose(cmdlet, "conditions: ctrlTypeCondition + a condition");
                
            } else if ((0 == conditionsCounter && null != ctrlTypeCondition) ||
                       (1 == conditionsCounter && null == ctrlTypeCondition)) {
                
                if (classCondition != null) { condition = classCondition; }
                else if (ctrlTypeCondition != null) { condition = ctrlTypeCondition; }
                else if (titleCondition != null) { condition = titleCondition; }
                else if (autoIdCondition != null) { condition = autoIdCondition; }
                else if (null != valueCondition) { condition = valueCondition; }
                WriteVerbose(cmdlet, "condition " +
                             condition.GetType().Name + " '" +
                             condition.Value + "' is used");
            }
            
            else if (0 == conditionsCounter && null == ctrlTypeCondition)
            {
                
                WriteVerbose(cmdlet, "neither ControlType nor Class nor Name are present");

                return (new AndCondition(Condition.TrueCondition,
                                         Condition.TrueCondition));
            }
            try {

                Condition[] tempConditions = null;
                if (null != allConditions) {
                    
                    tempConditions = allConditions.GetConditions();
                    conditionsToReturn = allConditions;

                }

                else if (null != andConditions) {
                    
                    tempConditions = andConditions.GetConditions();

                    conditionsToReturn = andConditions;

                } else if (null != orConditions) {
                    
                    // 20131118/20131119
                    // object -> Condition
                    tempConditions = orConditions.GetConditions();
                    conditionsToReturn = orConditions;

                } else if (condition != null) {
                    
                    WriteVerbose(cmdlet, "conditions (only one): " +
                                 condition.Property.ProgrammaticName +
                                 " = " +
                                 condition.Value.ToString());
                    
                    allConditions =
                        new AndCondition(condition,
                                         // 20131120
                                         // that was experimental
                                         Condition.TrueCondition);
                                         //Condition.FalseCondition);
                                         //condition);
                    conditionsToReturn = allConditions;

                }

                if (null == tempConditions) return conditionsToReturn;
                foreach (Condition tempCondition in tempConditions)
                {
                    WriteVerbose(cmdlet, "condition: " + tempCondition.ToString());
                }

                /*
                if (null != tempConditions) {
                    for (int i = 0; i < tempConditions.Length; i++) {
                        WriteVerbose(cmdlet, "condition: " + tempConditions[i].ToString());
                    }
                }
                */

                return conditionsToReturn;
            } catch {
                WriteVerbose(cmdlet, "conditions or condition are null");
                return conditionsToReturn;
            }
        }
        // 20131118
        // object -> Condition
        protected void DisplayConditions(
            GetControlCmdletBase cmdlet,
            // 20131118
            // object -> Condition
            AndCondition conditions,
            //Condition conditions,
            string description)
        {
            try
            {
                Condition[] conds = conditions.GetConditions();
                foreach (Condition propertyCondition in conds)
                {
                    cmdlet.WriteVerbose(cmdlet, "<<<< displaying conditions '" + description + "' >>>>");
                    cmdlet.WriteVerbose(cmdlet, (propertyCondition as PropertyCondition).Property.ProgrammaticName);
                    cmdlet.WriteVerbose(cmdlet, (propertyCondition as PropertyCondition).Value.ToString());
                    cmdlet.WriteVerbose(cmdlet, (propertyCondition as PropertyCondition).Flags.ToString());
                }
            }
            catch {}
        }
        
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "get")]
        protected internal ArrayList GetControl(GetControlCmdletBase cmdlet)
        {
            try {
                
                ResultArrayListOfControls = new ArrayList();
                
                #region conditions
                // 20131118
                // object -> Condition
                AndCondition conditions = null;
                //System.Windows.Automation.Condition conditions = null;
                // 20131118
                // object -> Condition
                AndCondition conditionsForWildCards = null;
                //System.Windows.Automation.Condition conditionsForWildCards = null;
                // 20131118
                // object -> Condition
                AndCondition conditionsForTextSearch = null;
                //System.Windows.Automation.Condition conditionsForTextSearch = null;
                
                GetControlCmdletBase tempCmdlet =
                    new GetControlCmdletBase {ControlType = cmdlet.ControlType};

                bool notTextSearch = true;
                // 20131122
                //if (!string.IsNullOrEmpty(cmdlet.ContainsText)) {
                if (!string.IsNullOrEmpty(cmdlet.ContainsText) && !cmdlet.Regex) {
                    tempCmdlet.ContainsText = cmdlet.ContainsText;
                    notTextSearch = false;
                    
                    conditionsForTextSearch =
                        // 20131118
                        // object -> Condition
                        // 20131119
                        GetControlConditions(
                        //(AndCondition)this.GetControlConditions(
                            tempCmdlet,
                            tempCmdlet.ControlType,
                            cmdlet.CaseSensitive,
                            //false); // as AndCondition;
                            false) as AndCondition;
                    
                    // display conditions for text search
                    // 20131119
                    WriteVerbose(cmdlet, "these conditions are used for text search:");
                    // 20131118
                    // object -> Condition
                    DisplayConditions(cmdlet, conditionsForTextSearch, "for text search");

                } else {
                    
                    // 20131118
                    // object -> Condition
                    // 20131119
                    //conditions = this.GetControlConditions(cmdlet, cmdlet.ControlType, ((GetControlCmdletBase)cmdlet).CaseSensitive, true); // as AndCondition;
                    conditions = GetControlConditions(cmdlet, cmdlet.ControlType, ((GetControlCmdletBase)cmdlet).CaseSensitive, true) as AndCondition;
                    //conditions = (AndCondition)this.GetControlConditions(cmdlet, cmdlet.ControlType, ((GetControlCmdletBase)cmdlet).CaseSensitive, true); // as AndCondition;
                    // display conditions for a regular search
                    // 20131119
                    WriteVerbose(cmdlet, "these conditions are used for an exact search:");
                    // 20131118
                    // object -> Condition
                    DisplayConditions(cmdlet, conditions, "for exact search");
                    
                    conditionsForWildCards =
                        // 20131118
                        // object -> Condition
                        // 20131119
                        //this.GetControlConditions(tempCmdlet, tempCmdlet.ControlType, ((GetControlCmdletBase)cmdlet).CaseSensitive, true); // as AndCondition;
                        GetControlConditions(tempCmdlet, tempCmdlet.ControlType, ((GetControlCmdletBase)cmdlet).CaseSensitive, true) as AndCondition;
                        //(AndCondition)this.GetControlConditions(tempCmdlet, tempCmdlet.ControlType, ((GetControlCmdletBase)cmdlet).CaseSensitive, true); // as AndCondition;
                    
                    // display conditions for wildcard search
                    // 20131119
                    WriteVerbose(cmdlet, "these conditions are used for wildcard search:");
                    // 20131118
                    // object -> Condition
                    DisplayConditions(cmdlet, conditionsForWildCards, "for wildcard search");

                }
                #endregion conditions
                
                tempCmdlet = null;
                
                IMySuperCollection inputCollection = cmdlet.InputObject.ConvertCmdletInputToCollectionAdapter();
                
                foreach (IMySuperWrapper inputObject in inputCollection) {
                    
                    IMySuperWrapper adapterOfInputObject =
                        ObjectsFactory.GetMySuperWrapper(inputObject.GetSourceElement());

                    int processId = 0;
                    do {
                        
                        #region checking processId
                        // 20131104
                        // refactoring
                        //if (inputObject != null &&
                        if (adapterOfInputObject != null &&
                            //(int)inputObject.Current.ProcessId > 0) {
                            (int)adapterOfInputObject.Current.ProcessId > 0) {
                            WriteVerbose(cmdlet, "CommonCmdletBase: getControl(cmdlet)");
                            WriteVerbose(cmdlet, "cmdlet.InputObject != null");
                            
                            // 20131104
                            // refactoring
                            //processId = inputObject.Current.ProcessId;
                            processId = adapterOfInputObject.Current.ProcessId;

                        }
                        #endregion checking processId
                        
                        // 20130204
                        // don't change the order! (text->exact->wildcard->win32 to win32->text->exact->wildcard)
                        #region text search
                        if (0 == ResultArrayListOfControls.Count) {
                            if (!notTextSearch && !cmdlet.Win32) {
                                
                                // 20131104
                                // refactoring
                                //SearchByTextViaUIA(cmdlet, inputObject, conditionsForTextSearch);
                                SearchByTextViaUia(cmdlet, adapterOfInputObject, conditionsForTextSearch);
                            }
                        }
                        #endregion text search

                        #region text search Win32
                        if (0 == ResultArrayListOfControls.Count) {
                            if (!notTextSearch && cmdlet.Win32) {
                                
                                // 20131104
                                // refactoring
                                //SearchByTextViaWin32(cmdlet, inputObject, cmdlet.ControlType);
                                SearchByTextViaWin32(cmdlet, adapterOfInputObject, cmdlet.ControlType);
                            }
                        }
                        #endregion text search Win32

                        #region exact search
                        // 20131122
                        //if (0 == resultArrayListOfControls.Count && notTextSearch) {
                        if (0 == ResultArrayListOfControls.Count && notTextSearch && !cmdlet.Regex) {
                            if (!Preferences.DisableExactSearch && !cmdlet.Win32 ) {
                                
                                // 20131104
                                // refactoring
                                //SearchByExactConditionsViaUIA(cmdlet, inputObject, conditions);
                                SearchByExactConditionsViaUia(cmdlet, adapterOfInputObject, conditions);
                                
                            }
                        }
                        #endregion exact search

                        #region wildcard search
                        // 20131122
                        //if (0 == resultArrayListOfControls.Count && notTextSearch) {
                        if (0 == ResultArrayListOfControls.Count && notTextSearch && !cmdlet.Regex) {
                            if (!Preferences.DisableWildCardSearch && !cmdlet.Win32) {
                                
                                SearchByWildcardOrRegexViaUia(cmdlet, ref ResultArrayListOfControls, adapterOfInputObject, cmdlet.Name, cmdlet.AutomationId, cmdlet.Class, cmdlet.Value, conditionsForWildCards, true);
                            }
                        }
                        #endregion wildcard search
                        
                        #region Regex search
                        if (0 == ResultArrayListOfControls.Count && notTextSearch && cmdlet.Regex) {
                            if (!Preferences.DisableWildCardSearch && !cmdlet.Win32) {
                                
                                SearchByWildcardOrRegexViaUia(cmdlet, ref ResultArrayListOfControls, adapterOfInputObject, cmdlet.Name, cmdlet.AutomationId, cmdlet.Class, cmdlet.Value, conditionsForWildCards, false);
                            }
                        }
                        #endregion Regex search

                        #region Win32 search
                        // 20131122
                        //if (0 == resultArrayListOfControls.Count && notTextSearch) {
                        if (0 == ResultArrayListOfControls.Count && notTextSearch && !cmdlet.Regex) {
                            
                            if (!Preferences.DisableWin32Search || cmdlet.Win32) {
                                
                                // 20131104
                                // refactoring
                                //SearchByWildcardViaWin32(cmdlet, inputObject);
                                SearchByWildcardViaWin32(cmdlet, adapterOfInputObject);
                                
                            } // if (!Preferences.DisableWin32Search || cmdlet.Win32)
                        } // FindWindowEx
                        #endregion Win32 search

                        if (null != ResultArrayListOfControls && ResultArrayListOfControls.Count > 0) {
                            
                            break;
                        }
                        
                        cmdlet.WriteVerbose(cmdlet, "going to sleep 99999999999");
                        
                        SleepAndRunScriptBlocks(cmdlet);

                        // System.Threading.Thread.Sleep(Preferences.SleepInterval);
                        ////impossible due to inheritance and the absense of scriptblock here
                        // SleepAndRunScriptBlocks(cmdlet);
                        DateTime nowDate = DateTime.Now;
                        
                        try {
                            WriteVerbose(cmdlet, "control type: '" +
                                         cmdlet.ControlType +
                                         "' , name: '" +
                                         cmdlet.Name +
                                         "', automationId: '" +
                                         cmdlet.AutomationId +
                                         "', class: '" +
                                         cmdlet.Class +
                                         "' , value: '" +
                                         cmdlet.Value +
                                         "' , seconds: " +
                                         ((nowDate - StartDate).TotalSeconds).ToString());
                        } catch { //(Exception eWriteVerbose) {
                            //WriteVerbose(this, eWriteVerbose.Message);
                        }
                        
                        if ((nowDate - StartDate).TotalSeconds > cmdlet.Timeout / 1000) {
                            
                            if (null == ResultArrayListOfControls || 0 == ResultArrayListOfControls.Count) {

                                return null;
                            }
                            break;
                        }
                        else{
                            
                            OddRootElement =
                                // 20131109
                                //System.Windows.Automation.AutomationElement.RootElement;
                                MySuperWrapper.RootElement;
                            if (processId > 0) {
                                try {
                                    PropertyCondition pIDcondition =
                                        new PropertyCondition(
                                            AutomationElement.ProcessIdProperty,
                                            processId);
                                    // 20131109
                                    //AutomationElement tempElement =
                                    IMySuperWrapper tempElement =
                                        OddRootElement.FindFirst(TreeScope.Children,
                                                              pIDcondition);
                                    if (tempElement != null &&
                                        (int)tempElement.Current.ProcessId > 0) {
                                        
                                        // 20130608
                                        tempElement = null;
                                        
                                    } else {

                                        // 20120830 (the new style of writing errors)
                                        WriteError(
                                            cmdlet,
                                            "The input control or window has been lost",
                                            "ObjectOrWindowLost",
                                            ErrorCategory.ObjectNotFound,
                                            true);

                                        return null;
                                    }
                                } catch {//"process is gone"
                                    // get new window

                                }
                            } else {
                                WriteVerbose(cmdlet, "failed to get the process Id");
                                
                                WriteError(
                                    cmdlet,
                                    "The input control or window has been lost",
                                    "ObjectOrWindowLost",
                                    ErrorCategory.ObjectNotFound,
                                    true);

                                return null;
                            } //#describe the output
                        }
                        
                        //} // 20120823
                    } while (cmdlet.Wait);
                    
                } // 20120823

                return ResultArrayListOfControls;

            }
            catch (Exception eGetControlException) {
                
                WriteError(
                    cmdlet,
                    "Failed to get the control." +
                    eGetControlException.Message,
                    "UnableToGetControl",
                    ErrorCategory.InvalidResult,
                    true);
                
                return null;
            }

        }

        // 20131104
        // refactoring
        //internal void SearchByWildcardViaWin32(GetControlCmdletBase cmdlet, AutomationElement inputObject)
        internal void SearchByWildcardViaWin32(GetControlCmdletBase cmdlet, IMySuperWrapper inputObject)
        {
            WriteVerbose(cmdlet, "[getting the control] using FindWindowEx");
            ArrayList tempListWin32 = new ArrayList();
            if (!string.IsNullOrEmpty(cmdlet.Name)) {
                WriteVerbose(cmdlet, "collecting controls by name (Win32)");
                tempListWin32.AddRange(UiaHelper.GetControlByName(cmdlet, inputObject, cmdlet.Name));
            }

            /*
            if (null != cmdlet.Name && string.Empty != cmdlet.Name) {
                this.WriteVerbose(cmdlet, "collecting controls by name (Win32)");
                tempListWin32.AddRange(UiaHelper.GetControlByName(cmdlet, inputObject, cmdlet.Name));
            }
            */
            if (!string.IsNullOrEmpty(cmdlet.Value)) {
                WriteVerbose(cmdlet, "collecting controls by value (Win32)");
                tempListWin32.AddRange(UiaHelper.GetControlByName(cmdlet, inputObject, cmdlet.Value));
            }

            /*
            if (null != cmdlet.Value && string.Empty != cmdlet.Value) {
                this.WriteVerbose(cmdlet, "collecting controls by value (Win32)");
                tempListWin32.AddRange(UiaHelper.GetControlByName(cmdlet, inputObject, cmdlet.Value));
            }
            */
            
            // 20131108
//            if (null == cmdlet.SearchCriteria || 0 == cmdlet.SearchCriteria.Length) {
//                
//               resultArrayListOfControls.AddRange(tempListWin32);
//            }
            
            // 20131109
            //foreach (AutomationElement tempElement3 in tempListWin32) {
            foreach (IMySuperWrapper tempElement3 in tempListWin32) {
                
                // 20131108
                /*
                if (string.IsNullOrEmpty(cmdlet.ControlType)) continue;
                if (!tempElement3.Current.ControlType.ProgrammaticName.ToUpper().Contains(cmdlet.ControlType.ToUpper())) continue;
                if (tempElement3.Current.ControlType.ProgrammaticName.ToUpper().Substring(12).Length != cmdlet.ControlType.ToUpper().Length) continue;
                */
                
                if (!string.IsNullOrEmpty(cmdlet.ControlType)) {
                    if (!tempElement3.Current.ControlType.ProgrammaticName.ToUpper().Contains(cmdlet.ControlType.ToUpper()) || 
                        tempElement3.Current.ControlType.ProgrammaticName.ToUpper().Substring(12).Length != cmdlet.ControlType.ToUpper().Length) {
                        continue;
                    }
                }
                
                /*
                if (null != cmdlet.ControlType && 0 < cmdlet.ControlType.Length) {
                    if (!tempElement3.Current.ControlType.ProgrammaticName.ToUpper().Contains(cmdlet.ControlType.ToUpper()) || 
                        !(tempElement3.Current.ControlType.ProgrammaticName.ToUpper().Substring(12).Length == cmdlet.ControlType.ToUpper().Length)) {
                        continue;
                    }
                }
                */
                
               // 20131108
                if (null == cmdlet.SearchCriteria || 0 == cmdlet.SearchCriteria.Length) {
                    ResultArrayListOfControls.Add(tempElement3);
                    cmdlet.WriteVerbose(cmdlet, "Win32Search: element added to the result collection");
                } else {
                    cmdlet.WriteVerbose(cmdlet, "Win32Search: checking search criteria");
                    if (!TestControlWithAllSearchCriteria(cmdlet, cmdlet.SearchCriteria, tempElement3)) continue;
                    cmdlet.WriteVerbose(cmdlet, "Win32Search: the control matches the search criteria");
                    ResultArrayListOfControls.Add(tempElement3);
                    cmdlet.WriteVerbose(cmdlet, "Win32Search: element added to the result collection");

                    /*
                    if (TestControlWithAllSearchCriteria(cmdlet, cmdlet.SearchCriteria, tempElement3)) {
                        cmdlet.WriteVerbose(cmdlet, "Win32Search: the control matches the search criteria");
                        aeCtrl.Add(tempElement3);
                        cmdlet.WriteVerbose(cmdlet, "Win32Search: element added to the result collection");
                    }
                    */
                }

                //if (null == cmdlet.SearchCriteria || 0 == cmdlet.SearchCriteria.Length) {
                //    resultArrayListOfControls.Add(tempElement3);
                //    cmdlet.WriteVerbose(cmdlet, "Win32Search: element added to the result collection");
                //} else {
// 20131108
//                    cmdlet.WriteVerbose(cmdlet, "Win32Search: checking search criteria");
//                    if (!TestControlWithAllSearchCriteria(cmdlet, cmdlet.SearchCriteria, tempElement3)) continue;
//                    cmdlet.WriteVerbose(cmdlet, "Win32Search: the control matches the search criteria");
//                    resultArrayListOfControls.Add(tempElement3);
//                    cmdlet.WriteVerbose(cmdlet, "Win32Search: element added to the result collection");
                //
                //    /*
                //    if (TestControlWithAllSearchCriteria(cmdlet, cmdlet.SearchCriteria, tempElement3)) {
                //        cmdlet.WriteVerbose(cmdlet, "Win32Search: the control matches the search criteria");
                //        aeCtrl.Add(tempElement3);
                //        cmdlet.WriteVerbose(cmdlet, "Win32Search: element added to the result collection");
                //    }
                //    */
                //}
            }
            
            // 20130608
            if (null == tempListWin32) return;
            tempListWin32.Clear();
            tempListWin32 = null;

            /*
            if (null != tempListWin32) {
                tempListWin32.Clear();
                tempListWin32 = null;
            }
            */
        }

        internal void SearchByWildcardOrRegexViaUia(
            GetControlCmdletBase cmdlet, // 20130318 // ??
            ref ArrayList resultCollection,
            IMySuperWrapper inputObject,
            string name,
            string automationId,
            string className,
            string strValue,
            // 20131118
            // object -> Condition
            AndCondition conditionsForWildCards,
            // 20131122
            bool viaWildcardOrRegex)
            //System.Windows.Automation.Condition conditionsForWildCards)
        {
            WriteVerbose((cmdlet as PSCmdletBase), "[getting the control] using WildCard/Regex search");
            try {

                GetControlCollectionCmdletBase cmdlet1 =
                    new GetControlCollectionCmdletBase(
                        cmdlet.InputObject ?? (new MySuperWrapper[]{ (MySuperWrapper)MySuperWrapper.RootElement }),
                        name, //cmdlet.Name,
                        automationId, //cmdlet.AutomationId,
                        className, //cmdlet.Class,
                        strValue,
                        null != cmdlet.ControlType ? (new string[] {cmdlet.ControlType}) : (new string[] {}),
                        caseSensitive);
                
                try {
                    WriteVerbose((cmdlet as PSCmdletBase), "using the GetAutomationElementsViaWildcards_FindAll method");
                    
                    ArrayList tempList =
                        cmdlet1.GetAutomationElementsViaWildcards_FindAll(
                            cmdlet1,
                            inputObject,
                            conditionsForWildCards,
                            cmdlet1.CaseSensitive,
                            false,
                            false,
                            // 20131122
                            viaWildcardOrRegex);

                    cmdlet.WriteVerbose(
                        cmdlet, 
                        "there are " +
                        tempList.Count.ToString() +
                        " elements that match the conditions");
                    
                    if (null == cmdlet.SearchCriteria || 0 == cmdlet.SearchCriteria.Length) {
                        
                        resultCollection.AddRange(tempList);
                    } else {
                        
                        foreach (IMySuperWrapper tempElement2 in tempList) {
                            
                            cmdlet.WriteVerbose(cmdlet, "WildCard/Regex search: checking search criteria");
                            if (!TestControlWithAllSearchCriteria(cmdlet, cmdlet.SearchCriteria, tempElement2))
                                continue;
                            cmdlet.WriteVerbose(cmdlet, "WildCard/Regex search: the control matches the search criteria");
                            resultCollection.Add(tempElement2);
                            cmdlet.WriteVerbose(cmdlet, "WildCard/Regex search: element added to the result collection (SearchCriteria)");
                        }
                    }
                    
//                    foreach (AutomationElement tempElement2 in tempList) {
//
//                        if (null == cmdlet.SearchCriteria || 0 == cmdlet.SearchCriteria.Length) {
//
//                            resultCollection.Add(tempElement2);
//                            cmdlet.WriteVerbose(cmdlet, "WildCardSearch: element added to the result collection (no SearchCriteria)");
//                        } else {
//
//                            cmdlet.WriteVerbose(cmdlet, "WildCardSearch: checking search criteria");
//                            if (!TestControlWithAllSearchCriteria(cmdlet, cmdlet.SearchCriteria, tempElement2))
//                                continue;
//                            cmdlet.WriteVerbose(cmdlet, "WildCardSearch: the control matches the search criteria");
//                            resultCollection.Add(tempElement2);
//                            cmdlet.WriteVerbose(cmdlet, "WildCardSearch: element added to the result collection (SearchCriteria)");
//
//                            /*
//                            if (TestControlWithAllSearchCriteria(cmdlet, cmdlet.SearchCriteria, tempElement2)) {
//
//                                cmdlet.WriteVerbose(cmdlet, "WildCardSearch: the control matches the search criteria");
//                                resultCollection.Add(tempElement2);
//                                cmdlet.WriteVerbose(cmdlet, "WildCardSearch: element added to the result collection (SearchCriteria)");
//                            }
//                            */
//
//                            // cmdlet.WriteVerbose(cmdlet, "WildCardSearch: element added to the result collection (SearchCriteria) (2)");
//                        }
//                        // cmdlet.WriteVerbose(cmdlet, "WildCardSearch: element added to the result collection (SearchCriteria) (3)");
//                    }
                    
                    if (null != tempList) {
                        tempList.Clear();
                        tempList = null;
                    }
                    
                    cmdlet.WriteVerbose(cmdlet, "WildCard/Regex search: element(s) added to the result collection: " + resultCollection.Count.ToString());
                } catch (Exception eUnexpected) {

                    WriteError(
                        this,
                        "The input control or window has been possibly lost." +
                        eUnexpected.Message,
                        "UnexpectedError",
                        ErrorCategory.ObjectNotFound,
                        true);
                }
                
                cmdlet1 = null;
                
            } catch (Exception eWildCardSearch) {

                WriteError(
                    cmdlet,
                    "The input control or window has been possibly lost." +
                    eWildCardSearch.Message,
                    "UnexpectedError",
                    ErrorCategory.ObjectNotFound,
                    true);
            }
        }
        
        internal void SearchByExactConditionsViaUia(
            GetControlCmdletBase cmdlet,
            IMySuperWrapper inputObject,
            // 20131118
            // object -> Condition
            AndCondition conditions)
            //System.Windows.Automation.Condition conditions)
        {
            #region the -First story
            // 20120824
            //aeCtrl =
            // 20120921
            #region -First
            //                                    if (cmdlet.First) {
            //                                        AutomationElement tempFirstElement =
            //                                            inputObject.FindFirst(
            //                                                System.Windows.Automation.TreeScope.Descendants,
            //                                                conditions);
            //                                        if (null != tempFirstElement) {
            //                                            if (null == cmdlet.SearchCriteria || 0 == cmdlet.SearchCriteria.Length) {
            //                                                aeCtrl.Add(tempFirstElement);
            //                                            } else {
            //                                                if (testControlWithAllSearchCriteria(
            //                                                    cmdlet,
            //                                                    cmdlet.SearchCriteria,
            //                                                    tempFirstElement)) {
            //                                                    aeCtrl.Add(tempFirstElement);
            //                                                }
            //                                            }
            //                                        }
            //                                    } else {
            #endregion -First
            // 20120823
            //cmdlet.InputObject.FindFirst(System.Windows.Automation.TreeScope.Descendants,

            // 20120824
            // 20120917
            #region -First
            //                                    }
            #endregion -First
            //else if (UIAutomation.CurrentData.LastResult
            #endregion the -First story
            
            //internal void SearchByExactConditionsViaUIA(System.Windows.Automation.AndCondition conditions, ref bool notTextSearch, ref System.Windows.Automation.AndCondition conditionsForWildCards, ref AutomationElement inputObject, ref int processId, GetControlCmdletBase cmdlet)
            //{

            if (conditions == null) return;
            if (inputObject == null || (int) inputObject.Current.ProcessId <= 0) return;
            // 20131104
            // refactoring
            //AutomationElementCollection tempCollection = inputObject.FindAll(System.Windows.Automation.TreeScope.Descendants, conditions);
            // 20131105
            // refactoring
            //AutomationElementCollection tempCollection = inputObject.FindAll(System.Windows.Automation.TreeScope.Descendants, conditions);
            // 20131119
            //IMySuperCollection tempCollection = inputObject.FindAll(System.Windows.Automation.TreeScope.Descendants, conditions);
            IMySuperCollection tempCollection = inputObject.FindAll(TreeScope.Descendants, conditions);
                
            // 20131109
            //foreach (AutomationElement tempElement in tempCollection) {
            foreach (IMySuperWrapper tempElement in tempCollection) {
                if (null == cmdlet.SearchCriteria || 0 == cmdlet.SearchCriteria.Length) {
                    ResultArrayListOfControls.Add(tempElement);
                    cmdlet.WriteVerbose(cmdlet, "ExactSearch: element added to the result collection");
                } else {
                    cmdlet.WriteVerbose(cmdlet, "ExactSearch: checking search criteria");
                    if (!TestControlWithAllSearchCriteria(cmdlet, cmdlet.SearchCriteria, tempElement)) continue;
                    cmdlet.WriteVerbose(cmdlet, "ExactSearch: the control matches the search criteria");
                    ResultArrayListOfControls.Add(tempElement);
                    cmdlet.WriteVerbose(cmdlet, "ExactSearch: element added to the result collection");
                    /*
                    if (TestControlWithAllSearchCriteria(cmdlet, cmdlet.SearchCriteria, tempElement)) {
                        cmdlet.WriteVerbose(cmdlet, "ExactSearch: the control matches the search criteria");
                        ResultArrayListOfControls.Add(tempElement);
                        cmdlet.WriteVerbose(cmdlet, "ExactSearch: element added to the result collection");
                    }
                    */
                }
            }
                    
            // 20130608
            if (null != tempCollection) {

                tempCollection = null;
            }

            /*
            if (inputObject != null && (int)inputObject.Current.ProcessId > 0) {
                // 20131104
                // refactoring
                //AutomationElementCollection tempCollection = inputObject.FindAll(System.Windows.Automation.TreeScope.Descendants, conditions);
                // 20131105
                // refactoring
                //AutomationElementCollection tempCollection = inputObject.FindAll(System.Windows.Automation.TreeScope.Descendants, conditions);
                IMySuperCollection tempCollection = inputObject.FindAll(System.Windows.Automation.TreeScope.Descendants, conditions);
                
                // 20131109
                //foreach (AutomationElement tempElement in tempCollection) {
                foreach (IMySuperWrapper tempElement in tempCollection) {
                    if (null == cmdlet.SearchCriteria || 0 == cmdlet.SearchCriteria.Length) {
                        resultArrayListOfControls.Add(tempElement);
                        cmdlet.WriteVerbose(cmdlet, "ExactSearch: element added to the result collection");
                    } else {
                        cmdlet.WriteVerbose(cmdlet, "ExactSearch: checking search criteria");
                        if (TestControlWithAllSearchCriteria(cmdlet, cmdlet.SearchCriteria, tempElement)) {
                            cmdlet.WriteVerbose(cmdlet, "ExactSearch: the control matches the search criteria");
                            resultArrayListOfControls.Add(tempElement);
                            cmdlet.WriteVerbose(cmdlet, "ExactSearch: element added to the result collection");
                        }
                    }
                }
                    
                // 20130608
                if (null != tempCollection) {

                    tempCollection = null;
                }
            }
            */

            /*
            if (conditions != null) {
                if (inputObject != null && (int)inputObject.Current.ProcessId > 0) {
                    // 20131104
                    // refactoring
                    //AutomationElementCollection tempCollection = inputObject.FindAll(System.Windows.Automation.TreeScope.Descendants, conditions);
                    AutomationElementCollection tempCollection = inputObject.FindAll(System.Windows.Automation.TreeScope.Descendants, conditions);
                    foreach (AutomationElement tempElement in tempCollection) {
                        if (null == cmdlet.SearchCriteria || 0 == cmdlet.SearchCriteria.Length) {
                            aeCtrl.Add(tempElement);
                            cmdlet.WriteVerbose(cmdlet, "ExactSearch: element added to the result collection");
                        } else {
                            cmdlet.WriteVerbose(cmdlet, "ExactSearch: checking search criteria");
                            if (TestControlWithAllSearchCriteria(cmdlet, cmdlet.SearchCriteria, tempElement)) {
                                cmdlet.WriteVerbose(cmdlet, "ExactSearch: the control matches the search criteria");
                                aeCtrl.Add(tempElement);
                                cmdlet.WriteVerbose(cmdlet, "ExactSearch: element added to the result collection");
                            }
                        }
                    }
                    
                    // 20130608
                    if (null != tempCollection) {

                        tempCollection = null;
                    }
                }
            }
            */
        }

        internal void SearchByTextViaUia(
            GetControlCmdletBase cmdlet,
            // 20131104
            // refactoring
            //AutomationElement inputObject,
            IMySuperWrapper inputObject,
            // 20131118
            // object -> Condition
            AndCondition conditionsForTextSearch)
            //System.Windows.Automation.Condition conditionsForTextSearch)
        {
            WriteVerbose(cmdlet, "Text search");
            // 20131105
            // refactoring
            //AutomationElementCollection textSearchCollection = inputObject.FindAll(TreeScope.Descendants, conditionsForTextSearch);
            // 20131119
            //IMySuperCollection textSearchCollection = inputObject.FindAll(TreeScope.Descendants, conditionsForTextSearch);
            IMySuperCollection textSearchCollection = inputObject.FindAll(TreeScope.Descendants, conditionsForTextSearch);
            if (null != textSearchCollection && 0 < textSearchCollection.Count) {
                WriteVerbose(cmdlet, "There are " + textSearchCollection.Count.ToString() + " elements");
                
                // 20131109
                //foreach (AutomationElement element in textSearchCollection) {
                foreach (IMySuperWrapper element in textSearchCollection) {
                    ResultArrayListOfControls.Add(element);
                }
            }
            // 20130608
            if (null != textSearchCollection) {
                textSearchCollection = null;
            }
        }
        
        internal void SearchByTextViaWin32(
            GetControlCmdletBase cmdlet,
            // 20131104
            // refactoring
            //AutomationElement inputObject,
            IMySuperWrapper inputObject,
            string controlType)
        {

            WriteVerbose(cmdlet, "Text search Win32");
            ArrayList textSearchWin32List =
                UiaHelper.GetControlByName(
                    cmdlet,
                    inputObject,
                    cmdlet.ContainsText);
            
            if (null != textSearchWin32List && 0 < textSearchWin32List.Count) {
                
                WriteVerbose(cmdlet, "There are " + textSearchWin32List.Count.ToString() + " elements");
                
                // 20131109
                //foreach (AutomationElement elementToChoose in textSearchWin32List) {
                foreach (IMySuperWrapper elementToChoose in textSearchWin32List) {
                    
                    if (!string.IsNullOrEmpty(controlType) && 0 < controlType.Length) {

                        if (!elementToChoose.Current.ControlType.ProgrammaticName.ToUpper().Contains(controlType.ToUpper()) || 
                            elementToChoose.Current.ControlType.ProgrammaticName.ToUpper().Substring(12).Length != controlType.ToUpper().Length) {
                            
                            continue;
                        } else {
                            
                            ResultArrayListOfControls.Add(elementToChoose);
                        }
                    } else {
                        
                        ResultArrayListOfControls.Add(elementToChoose);
                    }

                    /*
                    if (null != controlType && string.Empty != controlType && 0 < controlType.Length) {

                        if (!elementToChoose.Current.ControlType.ProgrammaticName.ToUpper().Contains(controlType.ToUpper()) || 
                            !(elementToChoose.Current.ControlType.ProgrammaticName.ToUpper().Substring(12).Length == controlType.ToUpper().Length)) {
                            
                            continue;
                        } else {
                            
                            aeCtrl.Add(elementToChoose);
                        }
                    } else {
                        
                        aeCtrl.Add(elementToChoose);
                    }
                    */
                }
            }

            if (null == textSearchWin32List) return;
            textSearchWin32List.Clear();
            textSearchWin32List = null;

            /*
            if (null != textSearchWin32List) {
                textSearchWin32List.Clear();
                textSearchWin32List = null;
            }
            */
        }
        
        protected bool TestControlByPropertiesFromDictionary(
            Dictionary<string, object> dict,
            // 20131109
            //AutomationElement elementToWorkWith)
            IMySuperWrapper elementToWorkWith)
        {
            bool result = false;
            
            foreach (string key in dict.Keys) {

                WriteVerbose(this, "Key = " + key + "; Value = " + dict[key].ToString());
                string keyValue = dict[key].ToString();
                
                const WildcardOptions options = WildcardOptions.IgnoreCase |
                                                WildcardOptions.Compiled;

                /*
                WildcardOptions options =
                    WildcardOptions.IgnoreCase |
                    WildcardOptions.Compiled;
                */

                switch (key) {
                    case "ACCELERATORKEY":
                        if ( !(new WildcardPattern(
                            keyValue,
                            options).IsMatch(elementToWorkWith.Current.AcceleratorKey))) {
                                WriteVerbose(this, "ACCELERATORKEY failed");
                                return result;
                        }
                        break;
                    case "ACCESSKEY":
                        if ( !(new WildcardPattern(
                            keyValue,
                            options).IsMatch(elementToWorkWith.Current.AccessKey))) {
                                WriteVerbose(this, "ACCESSKEY failed");
                                return result;
                        }
                        break;
                    case "AUTOMATIONID":
                        if ( !(new WildcardPattern(
                            keyValue,
                            options).IsMatch(elementToWorkWith.Current.AutomationId))) {
                                WriteVerbose(this, "AUTOMATIONID failed");
                                return result;
                        }
                        break;
                    case "CLASS":
                    case "CLASSNAME":
                        if ( !(new WildcardPattern(
                            keyValue,
                            options).IsMatch(elementToWorkWith.Current.ClassName))) {
                                WriteVerbose(this, "CLASSNAME failed");
                                return result;
                        }
                        break;
                    case "CONTROLTYPE":
                        if ( !(new WildcardPattern(
                            keyValue,
                            options).IsMatch(elementToWorkWith.Current.ControlType.ProgrammaticName.Substring(12)))) {
                                WriteVerbose(this, "CONTROLTYPE failed");
                                return result;
                        }
                        break;
                    case "FRAMEWORKID":
                        if ( !(new WildcardPattern(
                            keyValue,
                            options).IsMatch(elementToWorkWith.Current.FrameworkId))) {
                                WriteVerbose(this, "FRAMEWORKID failed");
                                return result;
                        }
                        break;
                    case "HASKEYBOARDFOCUS":
                        if ( !(new WildcardPattern(
                            keyValue,
                            options).IsMatch(elementToWorkWith.Current.HasKeyboardFocus.ToString()))) {
                                WriteVerbose(this, "HASKEYBOARDFOCUS failed");
                                return result;
                        }
                        break;
                    case "HELPTEXT":
                        if ( !(new WildcardPattern(
                            keyValue,
                            options).IsMatch(elementToWorkWith.Current.HelpText))) {
                                WriteVerbose(this, "HELPTEXT failed");
                                return result;
                        }
                        break;
                    case "ISCONTENTELEMENT":
                        if ( !(new WildcardPattern(
                            keyValue,
                            options).IsMatch(elementToWorkWith.Current.IsContentElement.ToString()))) {
                                WriteVerbose(this, "ISCONTENTELEMENT failed");
                                return result;
                        }
                        break;
                    case "ISCONTROLELEMENT":
                        if ( !(new WildcardPattern(
                            keyValue,
                            options).IsMatch(elementToWorkWith.Current.IsControlElement.ToString()))) {
                                WriteVerbose(this, "ISCONTROLELEMENT failed");
                                return result;
                        }
                        break;
                    case "ISENABLED":
                        if ( !(new WildcardPattern(
                            keyValue,
                            options).IsMatch(elementToWorkWith.Current.IsEnabled.ToString()))) {
                                WriteVerbose(this, "ISENABLED failed");
                                return result;
                        }
                        break;
                    case "ISKEYBOARDFOCUSABLE":
                        if ( !(new WildcardPattern(
                            keyValue,
                            options).IsMatch(elementToWorkWith.Current.IsKeyboardFocusable.ToString()))) {
                                WriteVerbose(this, "ISKEYBOARDFOCUSABLE failed");
                                return result;
                        }
                        break;
                    case "ISOFFSCREEN":
                        if ( !(new WildcardPattern(
                            keyValue,
                            options).IsMatch(elementToWorkWith.Current.IsOffscreen.ToString()))) {
                                WriteVerbose(this, "ISOFFSCREEN failed");
                                return result;
                        }
                        break;
                    case "ISPASSWORD":
                        if ( !(new WildcardPattern(
                            keyValue,
                            options).IsMatch(elementToWorkWith.Current.IsPassword.ToString()))) {
                                WriteVerbose(this, "ISPASSWORD failed");
                                return result;
                        }
                        break;
                    case "ISREQUIREDFORFORM":
                        if ( !(new WildcardPattern(
                            keyValue,
                            options).IsMatch(elementToWorkWith.Current.IsRequiredForForm.ToString()))) {
                                WriteVerbose(this, "ISREQUIREDFORFORM failed");
                                return result;
                        }
                        break;
                    case "ITEMSTATUS":
                        if ( !(new WildcardPattern(
                            keyValue,
                            options).IsMatch(elementToWorkWith.Current.ItemStatus))) {
                                WriteVerbose(this, "ITEMSTATUS failed");
                                return result;
                        }
                        break;
                    case "ITEMTYPE":
                        if ( !(new WildcardPattern(
                            keyValue,
                            options).IsMatch(elementToWorkWith.Current.ItemType))) {
                                WriteVerbose(this, "ITEMTYPE failed");
                                return result;
                        }
                        break;
                    case "LABELEDBY":
                        if ( !(new WildcardPattern(
                            keyValue,
                            options).IsMatch(elementToWorkWith.Current.LabeledBy.Current.Name))) {
                                WriteVerbose(this, "LABELEDBY failed");
                                return result;
                        }
                        break;
                    case "LOCALIZEDCONTROLTYPE":
                        if ( !(new WildcardPattern(
                            keyValue,
                            options).IsMatch(elementToWorkWith.Current.LocalizedControlType))) {
                                WriteVerbose(this, "LOCALIZEDCONTROLTYPE failed");
                                return result;
                        }
                        break;
                    case "NAME":
                        if ( !(new WildcardPattern(
                            keyValue,
                            options).IsMatch(elementToWorkWith.Current.Name))) {
                                WriteVerbose(this, "NAME failed");
                                return result;
                        }
                        break;
                    case "NATIVEWINDOWHANDLE":
                        if ( !(new WildcardPattern(
                            keyValue,
                            options).IsMatch(elementToWorkWith.Current.NativeWindowHandle.ToString()))) {
                                WriteVerbose(this, "NATIVEWINDOWHANDLE failed");
                                return result;
                        }
                        break;
                    case "ORIENTATION":
                        if ( !(new WildcardPattern(
                            keyValue,
                            options).IsMatch(elementToWorkWith.Current.Orientation.ToString()))) {
                                WriteVerbose(this, "ORIENTATION failed");
                                return result;
                        }
                        break;
                    case "PROCESSID":
                        if ( !(new WildcardPattern(
                            keyValue,
                            options).IsMatch(elementToWorkWith.Current.ProcessId.ToString()))) {
                                WriteVerbose(this, "PROCESSID failed");
                                return result;
                        }
                        break;
                    default:
                        WriteError(
                            this,
                            "Wrong AutomationElement parameter is provided: " + key,
                            "WrongParameter",
                            ErrorCategory.InvalidArgument,
                            true);
                        break;
                }
            }
            
            result = true;
            return result;
        }
        
        protected internal bool TestControlWithAllSearchCriteria(
            GetCmdletBase cmdlet,
            IEnumerable<Hashtable> hashtables,
            //Hashtable[] hashtables,
            // 20131109
            //AutomationElement element)
            IMySuperWrapper element)
        {
            bool result = false;
            
            foreach (Hashtable hashtable in hashtables) {
                
                result =
                    TestControlByPropertiesFromDictionary(
                        ConvertHashtableToDictionary(hashtable),
                        element);
                
                if (result) {
                    
                    if (Preferences.HighlightCheckedControl) {
                        UiaHelper.HighlightCheckedControl(element);
                    }
                    
                    return result;
                }
                
                cmdlet.WriteVerbose(cmdlet, "test of the control has finished");
            }
            
            return result;
        }
        #endregion Get-UiaControl
        
        // 20131118
        // just experimental
//        protected virtual void SaveEventInput(
//            AutomationElement src,
//            AutomationEventArgs e,
//            string programmaticName,
//            bool infoAdded)
//        {
//            
//        }
//        
//        #region Event delegate
//        private void runSBEvent(ScriptBlock sb, 
//                                AutomationElement src,
//                                AutomationEventArgs e)
//        {
//            
//            // inform the Wait-UiaEventRaised cmdlet
//            SaveEventInput(
//                src,
//                e,
//                e.EventId.ProgrammaticName,
//                true);
////            try {
////                CurrentData.LastEventSource = src; // as AutomationElement;
////                CurrentData.LastEventArgs = e; // as AutomationEventArgs;
////                CurrentData.LastEventType = e.EventId.ProgrammaticName;
////                CurrentData.LastEventInfoAdded = true;
////            }
////            catch {
////                //WriteVerbose(this, "failed to register an event in the collection");
////            }
//            
//            // 20120206 Collection<PSObject> psObjects = null;
//            try {
//                System.Management.Automation.Runspaces.Runspace.DefaultRunspace =
//                    RunspaceFactory.CreateRunspace();
//                try {
//                    System.Management.Automation.Runspaces.Runspace.DefaultRunspace.Open();
//                } catch (Exception e1) {
//                    // 20130318
////                    ErrorRecord err = 
////                        new ErrorRecord(e1,
////                                        "ErrorOnOpeningRunspace",
////                                        ErrorCategory.InvalidOperation,
////                                        sb);
////                    err.ErrorDetails = 
////                        new ErrorDetails(
////                            "Unable to run a scriptblock:\r\n" + 
////                            sb.ToString());
////                    WriteError(this, err, false);
//                    
//                    this.WriteError(
//                        this,
//                        "Unable to run a scriptblock:\r\n" + 
//                        sb.ToString() +
//                        "." +
//                        e1.Message,
//                        "ErrorOnOpeningRunspace",
//                        ErrorCategory.InvalidOperation,
//                        // 20130318
//                        //false);
//                        true);
//                }
//                try {
//                    System.Collections.Generic.List<object> inputParams = 
//                        new System.Collections.Generic.List<object>();
//                    inputParams.Add(src);
//                    inputParams.Add(e);
//                    object[] inputParamsArray = inputParams.ToArray();
//                    // psObjects = 
//                        sb.InvokeReturnAsIs(inputParamsArray);
//                        // sb.Invoke(inputParamsArray);
//                    
//                } catch (Exception e2) {
//                    // 20130318
////                    ErrorRecord err = 
////                        new ErrorRecord(e2,
////                                        "ErrorInOpenedRunspace",
////                                        ErrorCategory.InvalidOperation,
////                                        sb);
////                    err.ErrorDetails = 
////                        new ErrorDetails("Unable to run a scriptblock");
////                    WriteError(this, err, true);
//                    
//                    this.WriteError(
//                        this,
//                        "Unable to run a scriptblock." + 
//                        e2.Message,
//                        "ErrorInOpenedRunspace",
//                        ErrorCategory.InvalidOperation,
//                        true);
//                }
//// psObjects =
//// sb.Invoke();
//            } catch (Exception eOuter) {
//                // 20130318
////                ErrorRecord err = 
////                    new ErrorRecord(eOuter,
////                                    "ErrorInInvokingScriptBlock", //"ErrorinCreatingRunspace",
////                                    ErrorCategory.InvalidOperation,
////                                    System.Management.Automation.Runspaces.Runspace.DefaultRunspace);
////                err.ErrorDetails = 
////                    new ErrorDetails("Unable to issue the following command:\r\n" + 
////                                     "System.Management.Automation.Runspaces.Runspace.DefaultRunspace = RunspaceFactory.CreateRunspace();" +
////                                     "\r\nException raised is\r\n" +
////                                     eOuter.Message);
//                
//                this.WriteError(
//                    this,
//                    "Unable to issue the following command:\r\n" + 
//                     "System.Management.Automation.Runspaces.Runspace.DefaultRunspace = RunspaceFactory.CreateRunspace();" +
//                     "\r\nException raised is\r\n" +
//                     eOuter.Message,
//                    "ErrorInInvokingScriptBlock",
//                    ErrorCategory.InvalidOperation,
//                    true);
//            }
//        }
//        #endregion Event delegate
//        
//        #region Action delegate
//        private void runSBAction(ScriptBlock sb, 
//                                 AutomationElement src,
//                                 AutomationEventArgs e)
//        {
//            Collection<PSObject> psObjects = null;
//            try {
//                psObjects =
//                    sb.Invoke();
//// int counter = 0;
//// foreach (PSObject pso in psObjects) {
////  //if pso.
//// counter++;
//// WriteVerbose("result " + counter.ToString() + ":");
//// WriteVerbose(pso.ToString());
////  //WriteObject(pso.TypeNames
//// foreach ( string typeName in pso.TypeNames) {
//// WriteVerbose(typeName);
//// }
//// }
//            } catch (Exception eOuter) {
//                // 20130318
////                ErrorRecord err = 
////                    new ErrorRecord(eOuter,
////                                    "ErrorInInvokingScriptBlock",
////                                    ErrorCategory.InvalidOperation,
////                                    System.Management.Automation.Runspaces.Runspace.DefaultRunspace);
////                err.ErrorDetails = 
////                    new ErrorDetails(
////                        "Unable to issue the following command:\r\n" +
////                        sb.ToString() + 
////                        "\r\nThe exception raised is\r\n" + 
////                        eOuter.Message);
////                                     //"System.Management.Automation.Runspaces.Runspace.DefaultRunspace = RunspaceFactory.CreateRunspace();");
////                WriteError(err);
//                
//                this.WriteError(
//                    this,
//                    "Unable to issue the following command:\r\n" +
//                    sb.ToString() + 
//                    "\r\nThe exception raised is\r\n" + 
//                    eOuter.Message,
//                    "ErrorInInvokingScriptBlock",
//                    ErrorCategory.InvalidOperation,
//                    // 20130318
//                    //false);
//                    true);
//            }
//        }
//        #endregion Action delegate
//        
//        // 20120816
//        public void runScriptBlocks(
//            System.Collections.Generic.List<ScriptBlock> scriptblocks,
//            PSCmdletBase cmdlet,
//            // 20130318
//            //bool eventHandlers)
//            bool eventHandlers,
//            object[] parameters)
//        {
//            
//            try {
//
//                if (scriptblocks != null &&
//                    scriptblocks.Count > 0) {
//                    
//                    cmdlet.WriteVerbose(cmdlet, "there are " + scriptblocks.Count.ToString() + " scriptblock(s) to run");
//                    
//                    foreach (ScriptBlock sb in scriptblocks) {
//
//                        if (sb != null) {
//
//                            try {
//                                if (eventHandlers) {
//
//                                    cmdlet.WriteVerbose(cmdlet, "run event handler");
//                                    
//                                    runScriptBlock runner = new runScriptBlock(runSBEvent);
//
//                                    runner(sb, cmdlet.EventSource, cmdlet.EventArgs);
//
//                                } else {
//                                    
//                                    cmdlet.WriteVerbose(cmdlet, "run action with parameters");
//
//                                    // 20130318
//                                    //runScriptBlock runner = new runScriptBlock(runSBAction);
//                                    //runner(sb, cmdlet.EventSource, cmdlet.EventArgs);
//                                    runScriptBlockWithParameters runnerWithParams = new runScriptBlockWithParameters(runSBActionWithParams);
//                                    
//                                    cmdlet.WriteVerbose(cmdlet, "the scriptblock runner has been created");
//                                    
//                                    // 20130606
//                                    try {
//                                        cmdlet.WriteVerbose(cmdlet, "listing parameters");
//                                        if (null == parameters || 0 == parameters.Length) {
//                                            cmdlet.WriteVerbose(cmdlet, "there are no parameters");
//                                        } else {
//                                            foreach (var singleParam in parameters) {
//                                                cmdlet.WriteVerbose(cmdlet, singleParam);
//                                            }
//                                        }
//                                    }
//                                    catch (Exception eListParameters) {
//                                        cmdlet.WriteVerbose(cmdlet, eListParameters.Message);
//                                    }
//                                    
//                                    runnerWithParams(sb, parameters);
//                                    
//                                    cmdlet.WriteVerbose(cmdlet, "the scriptblock runner has finished");
//                                }
//                            } catch (Exception eInner) {
//
//                                // 20130318
////                                ErrorRecord err = 
////                                    new ErrorRecord(
////                                        eInner,
////                                        "InvokeException",
////                                        ErrorCategory.OperationStopped,
////                                        sb);
////                                err.ErrorDetails = 
////                                    new ErrorDetails("Error in " +
////                                                     sb.ToString());
////                                WriteError(this, err, false);
//                                
////                                this.WriteError(
////                                    this,
////                                    "Error in " +
////                                    sb.ToString() +
////                                    ". " +
////                                    eInner.Message,
////                                    "InvokeException",
////                                    ErrorCategory.OperationStopped,
////                                    // 20130318
////                                    //false);
////                                    true);
//                                    
//                                    // 20130606
//                                    cmdlet.WriteVerbose(cmdlet, eInner.Message);
//                                    //throw;
//                                    throw new Exception("Failed to run scriptblock");
//                            }
//                        }
//                    }
//                }
//            } catch (Exception eOuter) {
//                // 20130318
////                WriteError(this, 
////                           new ErrorRecord(eOuter, "runScriptBlocks", ErrorCategory.InvalidArgument, null),
////                           true);
//                
////                this.WriteError(
////                    this,
////                    eOuter.Message,
////                    "runScriptBlocks",
////                    ErrorCategory.InvalidArgument,
////                    true);
//                    
//                // 20130606
//                cmdlet.WriteVerbose(cmdlet, eOuter.Message);
//                //throw;
//                throw new Exception("Failed to run scriptblocks");
//            }
//        }
//        
//        protected internal void runTwoScriptBlockCollections(
//            ScriptBlock[] scriptblocksSet1,
//            ScriptBlock[] scriptblocksSet2,
//            // 20130318
//            //PSCmdletBase cmdlet)
//            PSCmdletBase cmdlet,
//            object[] parameters)
//        {
//            
//            cmdlet.WriteVerbose(cmdlet, "preparing scriptblocks");
//            
//            System.Collections.Generic.List<ScriptBlock> scriptblocks =
//                new System.Collections.Generic.List<ScriptBlock>();
//
//            try {
//                if (scriptblocksSet1 != null &&
//                    scriptblocksSet1.Length > 0) {
//    
//                    foreach (ScriptBlock sb in scriptblocksSet1) {
//    
//                        scriptblocks.Add(sb);
//                    }
//                }
//    
//                if (scriptblocksSet2 != null &&
//                    scriptblocksSet2.Length > 0) {
//    
//                    foreach (ScriptBlock sb in scriptblocksSet2) {
//    
//                        scriptblocks.Add(sb);
//                    }
//                }
//                
////                if (null == scriptblocks || 0 == scriptblocks.Count) {
////                    
////                    cmdlet.WriteVerbose(cmdlet, "there is no any StopAction scriptblock");
////                    
////                    //throw new Exception("There are no StopAction scriptblocks, define at least one");
////                    cmdlet.WriteError(
////                        cmdlet,
////                        "There are no StopAction scriptblocks, define at least one",
////                        "NoStopActionScriptblocks",
////                        ErrorCategory.InvalidArgument,
////                        true);
////                }
//                
//                cmdlet.WriteVerbose(cmdlet, "scriptblocks were prepared");
//            }
//            catch (Exception eScriptblocksPreparation) {
//                
//                cmdlet.WriteVerbose(cmdlet, "Scriptblocks are not going to be run");
//                
//                cmdlet.WriteVerbose(cmdlet, eScriptblocksPreparation.Message);
//                
//                cmdlet.WriteError(
//                    cmdlet,
//                    eScriptblocksPreparation.Message,
//                    "ScriptblocksNotPrepared",
//                    ErrorCategory.InvalidOperation,
//                    true);
//            }
//
//            // 20130318
//            //runScriptBlocks(scriptblocks, cmdlet, false);
//            // 20130319
//            try {
//                
//                cmdlet.WriteVerbose(cmdlet, "running scriptblocks");
//                
//                // 20130712
//                //runScriptBlocks(scriptblocks, cmdlet, false, parameters);
//                if (null != scriptblocks && 0 < scriptblocks.Count) {
//                    runScriptBlocks(scriptblocks, cmdlet, false, parameters);
//                }
//                
//                cmdlet.WriteVerbose(cmdlet, "Scriptblocks finished successfully");
//            }
//            catch (Exception eScriptBlocks) {
//                
//                cmdlet.WriteVerbose(cmdlet, "Scriptblocks failed");
//                
//                cmdlet.WriteVerbose(cmdlet, eScriptBlocks.Message);
//                
//                cmdlet.WriteError(
//                    cmdlet,
//                    eScriptBlocks.Message,
//                    "ScriptblocksFailed",
//                    ErrorCategory.InvalidResult,
//                    true);
//            }
//        }
    }
    
    // 20131118
    // just experimental
//    #region Action delegate
//    delegate void runScriptBlock(ScriptBlock sb, 
//                                 AutomationElement src, 
//                                 AutomationEventArgs e);
//    #endregion Action delegate
}
