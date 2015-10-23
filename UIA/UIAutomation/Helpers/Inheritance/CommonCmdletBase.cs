/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/2/2011
 * Time: 5:51 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    extern alias UIANET; extern alias UIACOM;// using System.Windows.Automation;
    using System;
    using System.Management.Automation;
    using System.Collections;
    // using System.Collections.ObjectModel;
    using System.Threading;
    // using System.Management.Automation.Runspaces;
    using classic = UIANET::System.Windows.Automation; using viacom = UIACOM::System.Windows.Automation; // using System.Windows.Automation;
    using System.Collections.Generic;
    // using System.Text.RegularExpressions;
    using PSTestLib;
    // using System.Diagnostics.CodeAnalysis;
    using Tmx;
    using Tmx.Interfaces.TestStructure;
    using Commands;
    
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
            AutomationFactory.Init();
            
            // 20140124
//            runTwoScriptBlockCollections(
//                new ScriptBlock[] { Preferences.ModuleEcoSystem },
//                null,
//                this,
//                new object[] {});
        }
        #endregion Constructor
        
        internal static bool ModuleAlreadyLoaded { get; set; }
        internal static int HighlighterGeneration = 0;
        
        protected override void EndProcessing()
        {
            #region close the log
            try {
                // 20140303
                // Global.CloseLogFile();
                // CloseLogFile();
            } catch { }
            #endregion close the log
        }
        
        #region Write methods
        protected override void WriteLog(LogLevels logLevel, string logRecord)
        {
            if (!Preferences.AutoLog) return;
            
            // 20140317
            // turning off the logger
//            switch (logLevel) {
//                case LogLevels.Fatal:
//                    Logger.Fatal(logRecord);
//                    break;
//                case LogLevels.Error:
//                    Logger.Error(logRecord);
//                    break;
//                case LogLevels.Warn:
//                    Logger.Warn(logRecord);
//                    break;
//                case LogLevels.Info:
//                    Logger.Info(logRecord);
//                    break;
//                case LogLevels.Debug:
//                    Logger.Debug(logRecord);
//                    break;
//                case LogLevels.Trace:
//                    Logger.Trace(logRecord);
//                    break;
//            }
        }

        protected void WriteLog(LogLevels logLevel, ErrorRecord errorRecord)
        {
            if (!Preferences.AutoLog) return;
            WriteLog(logLevel, errorRecord.Exception.Message);
            WriteLog(logLevel, "Script: '" + errorRecord.InvocationInfo.ScriptName + "', line: " + errorRecord.InvocationInfo.Line);
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
                obj;
            
            WriteLog(LogLevels.Debug, reportString);
        }
        
        protected internal void WriteInfo(CommonCmdletBase cmdlet, string text)
        {
            if (!string.IsNullOrEmpty(text) && !string.IsNullOrEmpty(text.Trim())) {
                string reportString =
                    CmdletSignature(cmdlet) +
                    text;
                
                // 20140317
                // turning off the logger
                // Logger.Info(reportString);
            } else {
                // 20140317
                // turning off the logger
                // Logger.Info(text);
            }
        }
        
        protected internal void WriteWarn(CommonCmdletBase cmdlet, string text)
        {
            string reportString =
                CmdletSignature(cmdlet) +
                text;
            
            // 20140317
            // turning off the logger
            // Logger.Warn(reportString);
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
            return result;
        }

        protected void WriteObjectMethod020Highlight(PSCmdletBase cmdlet, object outputObject)
        {
            if (null == (outputObject as IUiElement)) {
                return;
            }
            
            if (string.Empty != ((HasScriptBlockCmdletBase)cmdlet).Banner) {

                UiaHelper.ShowBanner(((HasScriptBlockCmdletBase)cmdlet).Banner);

            }

            if (!Preferences.Highlight && !((HasScriptBlockCmdletBase) cmdlet).Highlight) return;
            
            IUiElement element = null;

            if (cmdlet == null || cmdlet is WizardCmdletBase) return;
            try {
                
                element = outputObject as IUiElement;
                if (null != element &&
                    // 20140312
                    // (int)element.Current.ProcessId > 0) {
                    (int)element.GetCurrent().ProcessId > 0) {
                    
                    WriteVerbose(this, "current cmdlet: " + GetType().Name);
                    WriteVerbose(this, "highlighting the following element:");
                    // 20140312
//                    WriteVerbose(this, "Name = " + element.Current.Name);
//                    WriteVerbose(this, "AutomationId = " + element.Current.AutomationId);
//                    WriteVerbose(this, "ControlType = " + element.Current.ControlType.ProgrammaticName);
//                    WriteVerbose(this, "X = " + element.Current.BoundingRectangle.X.ToString());
//                    WriteVerbose(this, "Y = " + element.Current.BoundingRectangle.Y.ToString());
//                    WriteVerbose(this, "Width = " + element.Current.BoundingRectangle.Width.ToString());
//                    WriteVerbose(this, "Height = " + element.Current.BoundingRectangle.Height.ToString());
                }
            } catch { //(Exception eee) {
                // nothing to do
                // just failed to highlight
            }
            // 20140113
            // if (element == null || !(element is IUiElement) || (int) element.Current.ProcessId <= 0) return;
            // 20140312
            // if (element == null || !(element is IUiElement) || null == element.Current || (int) element.Current.ProcessId <= 0) return;
            if (element == null || !(element is IUiElement) || null == element.GetCurrent() || (int) element.GetCurrent().ProcessId <= 0) return;
            
            WriteVerbose(this, "as it is an IUiElement, it should be highlighted");
            
            try {
                WriteVerbose(this, "run Highlighter");
                if (Preferences.ShowExecutionPlan) {
                    if (Preferences.ShowInfoToolTip) {
                        // 20131204
                        // ExecutionPlan.Enqueue(element, HighlighterGeneration, "name: " + element.Current.Name);
                        // 20140312
                        // ExecutionPlan.Enqueue(element, "name: " + element.Current.Name);
                        ExecutionPlan.Enqueue(element, "name: " + element.GetCurrent().Name);
                    } else {
                        // 20131204
                        // ExecutionPlan.Enqueue(element, HighlighterGeneration, string.Empty);
                        ExecutionPlan.Enqueue(element, string.Empty);
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
        }
        
        protected void WriteObjectMethod030RunScriptBlocks(PSCmdletBase cmdlet, object outputObject)
        {
            // 20140113
            try {
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
            }
            catch {}
        }
        
        protected void WriteObjectMethod040SetTestResult(PSCmdletBase cmdlet, object outputObject)
        {
            if (cmdlet == null) return;
            try {
                CurrentData.LastResult = outputObject;

                var iInfo = string.Empty;
                if (!string.IsNullOrEmpty(((HasScriptBlockCmdletBase)cmdlet).TestResultName)) {
                    
                    TmxHelper.CloseTestResult(((HasScriptBlockCmdletBase)cmdlet).TestResultName,
                        ((HasScriptBlockCmdletBase)cmdlet).TestResultId,
                        ((HasScriptBlockCmdletBase)cmdlet).TestPassed,
                        ((HasScriptBlockCmdletBase)cmdlet).KnownIssue, //false, // isKnownIssue
                        // 20160116
                        // MyInvocation,
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
                        // 20160116
                        // MyInvocation,
                        null, // Error
                        string.Empty,
                        TestResultOrigins.Automatic,
                        false);
                }
            }
            catch (Exception) {
                WriteVerbose(this, "for working with test results you need to import the TMX module");
            }
        }

        protected void WriteObjectMethod045OnSuccessScreenshot(PSCmdletBase cmdlet, object outputObject)
        {
            WriteVerbose(this, "WriteObjectMethod045OnSuccessScreenshot UIAutomation");

            if (Preferences.OnSuccessScreenShot) {
                
                UiaHelper.GetScreenshotOfAutomationElement(
                    (cmdlet as HasControlInputCmdletBase),
                    (outputObject as IUiElement),
                    CmdletName(cmdlet),
                    true,
                    new ScreenshotRect(),
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
                        
                        (outputObject as IUiElement) != null) {

                        WriteVerbose(this, "(CurrentData.CurrentWindow != null && " +
                                          "CurrentData.LastResult != null) || " +
                                          "(outputObject as IUiElement) != null");

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
            WriteVerbose(this, "outputting the result object");
            if (cmdlet == null) return;
            try {
                var element = outputObject as IUiElement;
                WriteVerbose(this, "getting the element again to ensure that it still exists");
                if (!(cmdlet is WizardCmdletBase) &&
                    (null != element)) {
                    
                    WriteVerbose(this, "returning the object");
                    WriteObject((IUiElement)outputObject);
                } else if ((cmdlet is WizardCmdletBase)) {
                    WriteVerbose(this, "returning the wizard or step");
                    WriteObject(outputObject);
                } else {
                    WriteVerbose("returning as is");
                    // 20131204
                    HighlighterGeneration++;
                    WriteObject(outputObject);
                }
            } catch { // (Exception eeeee) {
                // test
                // 20131109
                //this.WriteVerbose(this, "failed to issue the result object of AutomationElement type");
                WriteVerbose(this, "failed to issue the result object of IUiElement type");
                WriteVerbose(this, "returning as is");
                // 20131204
                HighlighterGeneration++;
                WriteObject(outputObject);
            }
        }
        
        protected void WriteObjectMethod070Report(PSCmdletBase cmdlet, object outputObject)
        {
            // 20140113
            try {
                
                if (!Preferences.AutoLog) return;
                string reportString =
                    CmdletSignature(((CommonCmdletBase)cmdlet));
                    
                switch (outputObject.GetType().Name) {
                    case "AutomationElement":
                    case "IUiElement":
                        try {
                            
                            var ae = outputObject as IUiElement;
                            if (null != ae) {
                                reportString +=
                                    "Name: '" +
                                    ae.GetCurrent().Name +
                                    "', AutomationId: '" +
                                    ae.GetCurrent().AutomationId +
                                    "', Class: '" +
                                    ae.GetCurrent().ClassName +
                                    "'";
                                
                                object vPattern = null;
                                if (ae.TryGetCurrentPattern(classic.ValuePattern.Pattern, out vPattern)) {
                                        
                                    reportString +=
                                        ", Value: '" +
                                        ((classic.ValuePattern)vPattern).Current.Value +
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
                            ((Wizard)outputObject).Steps.Count;
                        break;
                    case "WizardStep":
                        reportString +=
                            "Name: '" +
                            ((WizardStep)outputObject).Name + 
                            "'";
                        break;
                    case "Hashtable":
                        reportString +=
                            // 20150915
                            // ConvertHashtableToString((Hashtable)outputObject);
                            ((Hashtable) outputObject).ConvertToString();
                        break;
                    case "Hashtable[]":
                        reportString +=
                            // 20150915
                            // ConvertHashtablesArrayToString((Hashtable[])outputObject);
                            ((Hashtable[]) outputObject).ConvertToString();
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
                                    
                                Hashtable[] hashtables = ((GetControlStateCmdletBase)cmdlet).SearchCriteria;
                                reportString +=
                                    // 20150915
                                    // ConvertHashtablesArrayToString(hashtables);
                                    hashtables.ConvertToString();
                            }
                            if (cmdlet is WaitUiaWindowCommand)
                                reportString +=
                                    "Name: '" +
                                    CurrentData.CurrentWindow.GetCurrent().Name +
                                    "', AutomationId: '" +
                                    CurrentData.CurrentWindow.GetCurrent().AutomationId +
                                    "', Class: '" +
                                    CurrentData.CurrentWindow.GetCurrent().ClassName +
                                    "'";
                            // 20131020
                            if (cmdlet is DiscoveryCmdletBase)
                                reportString += outputObject.ToString();
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
            
            }
            catch {}
        }
        
        // 20131204
        // internal static int HighlighterGeneration = 0;
        
        // 20131204
        // ????????
        public void WriteObject(PSCmdletBase cmdlet, List<IUiElement> outputObjectCollection)
        {
            HighlighterGeneration++;
            base.WriteObject(cmdlet, outputObjectCollection);
        }
        
        // 20131204
        // ????????
        public void WriteObject(PSCmdletBase cmdlet, IUiEltCollection outputObjectCollection)
        {
            HighlighterGeneration++;
            base.WriteObject(cmdlet, outputObjectCollection);
        }
        
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
        
        void writeErrorToTheList(ErrorRecord err)
        {
            CurrentData.Error.Add(err);
            if (CurrentData.Error.Count <= Preferences.MaximumErrorCount) return;
            do{
                CurrentData.Error.RemoveAt(0);
            } while (CurrentData.Error.Count > Preferences.MaximumErrorCount);
            CurrentData.Error.Capacity = Preferences.MaximumErrorCount;
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
            var hasScriptBlockCmdletBase = cmdlet as HasScriptBlockCmdletBase;
            if (hasScriptBlockCmdletBase != null) {

                RunOnErrorScriptBlocks(hasScriptBlockCmdletBase, null);
            }
            /*
            if (cmdlet is HasScriptBlockCmdletBase) {

                RunOnErrorScriptBlocks(((HasScriptBlockCmdletBase)cmdlet), null);
            }
            */
        }
        
        protected override void WriteErrorMethod020SetTestResult(PSCmdletBase cmdlet, ErrorRecord errorRecord)
        {
            if (cmdlet == null) return;
            // write error to the test results collection
            // 20160116
            // TmxHelper.AddTestResultErrorDetail(errorRecord);
            TmxHelper.AddTestResultErrorDetail(errorRecord.Exception);
                
            // write test result label
            try {
                    
                CurrentData.LastResult = null;
                    
                string iInfo = string.Empty;
                if (!string.IsNullOrEmpty(((HasScriptBlockCmdletBase)cmdlet).TestResultName)) {
                    
                    TmxHelper.CloseTestResult(((HasScriptBlockCmdletBase)cmdlet).TestResultName,
                        ((HasScriptBlockCmdletBase)cmdlet).TestResultId,
                        false, // the only result: FAILED //((HasScriptBlockCmdletBase)cmdlet).TestPassed,
                        false, // because of failure //((HasScriptBlockCmdletBase)cmdlet).KnownIssue,
                        // 20160116
                        // MyInvocation,
                        // 20160116
                        // errorRecord,
                        errorRecord.Exception,
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
                        // 20160116
                        // MyInvocation,
                        // 20160116
                        // errorRecord,
                        errorRecord.Exception,
                        string.Empty,
                        TestResultOrigins.Automatic,
                        false);
                }
            }
            catch {
                WriteVerbose(this, "for working with test results you need to import the TMX module");
            }
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

            WriteVerbose(this, "Preferences.StoredDefaultTimeout = " + Preferences.StoredDefaultTimeout);
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
            
            IUiElement elementToTakeScreenShot = null;
            
            try {
                    
                if (null != CurrentData.CurrentWindow) {
                        
                    cmdlet.WriteVerbose(cmdlet, "taking screenshot of the current window");
                    elementToTakeScreenShot = CurrentData.CurrentWindow;
                } else {
                        
                    cmdlet.WriteVerbose(cmdlet, "taking screenshot of the desktop object");
                    elementToTakeScreenShot = UiElement.RootElement;
                }
            }
            catch {
                    
                cmdlet.WriteVerbose(cmdlet, "taking screenshot of the desktop object (on fail)");
                elementToTakeScreenShot = UiElement.RootElement;
            }
                
            cmdlet.WriteVerbose(cmdlet, "taking screenshot");
            UiaHelper.GetScreenshotOfAutomationElement(
                cmdlet,
                elementToTakeScreenShot,
                CmdletName(cmdlet),
                true,
                new ScreenshotRect(),
                string.Empty,
                Preferences.OnErrorScreenShotFormat);
                
            cmdlet.WriteVerbose(cmdlet, "done");
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
            var blocks = new List<ScriptBlock>();
            
//            WriteVerbose(cmdlet,
//                              blocks.Count +
//                              " events to fire");
            if (cmdlet.EventAction != null && cmdlet.EventAction.Length > 0) {
                foreach (ScriptBlock sb in cmdlet.EventAction) {
                    blocks.Add(sb);
//                    WriteVerbose(cmdlet,
//                                      "the scriptblock: " +
//                                      sb +
//                                      " is ready to be fired");
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
            
            if (hereMustBeStopAction && (null == wizard.StopAction || 0 == wizard.StopAction.Length))
//                cmdlet.WriteVerbose(cmdlet, "there is no any StopAction scriptblock");
                //throw new Exception("There are no StopAction scriptblocks, define at least one");
                cmdlet.WriteError(
                    cmdlet,
                    "There are no StopAction scriptblocks, define at least one",
                    "NoStopActionScriptblocks",
                    ErrorCategory.InvalidArgument,
                    true);
            
            runTwoScriptBlockCollections(
                null,
                wizard.StopAction,
                cmdlet,
                parameters);

        }
        
        protected internal bool RunWizardGetWindowScriptBlocks(Wizard wizard, object[] parameters)
        {
            bool result = false;
            
            // 20130508
            // temporary
            // profiling
            // 20140207
            WriteInfo(this, "running the GetWindowAction scriptblock");
            WriteInfo(this, "parameters" + parameters);
            
            try {
                runTwoScriptBlockCollections(
                    null,
                    wizard.GetWindowAction,
                    this,
                    parameters);
                    
                result |= null != CurrentData.CurrentWindow;
                /*
                if (null != CurrentData.CurrentWindow) {
                    result = true;
                }
                */
            }
            catch {}
            
            // 20130508
            // temporary
            // profiling
            // 20140207
            WriteInfo(this, "the result of the GetWindowAction scriptblock run is " + result);
            
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
//                    cmdlet.WriteVerbose(
//                        cmdlet,
//                        "ForwardAction scriptblocks");
    
                    runTwoScriptBlockCollections(
                        wizardStep.Parent.DefaultStepForwardAction,
                        wizardStep.StepForwardAction,
                        cmdlet,
                        parameters);
                    break;
                case WizardStepActions.Backward:
//                    cmdlet.WriteVerbose(
//                        cmdlet,
//                        "BackwardAction scriptblocks");
                    
                    runTwoScriptBlockCollections(
                        wizardStep.Parent.DefaultStepBackwardAction,
                        wizardStep.StepBackwardAction,
                        cmdlet,
                        parameters);
                    break;
                case WizardStepActions.Cancel:
//                    cmdlet.WriteVerbose(
//                        cmdlet,
//                        "CancelAction scriptblocks");
                    
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
        
        protected override void SaveEventInput(
            // 20131109
            classic.AutomationElement src,
            //IUiElement src,
            classic.AutomationEventArgs e,
            string programmaticName,
            bool infoAdded)
        {
            // inform the Wait-UiaEventRaised cmdlet
            try {
                // 20131109
                //CurrentData.LastEventSource = src; //.SourceElement; // as AutomationElement;
                // 20131112
                //CurrentData.LastEventSource = new UiElement(src);
                CurrentData.LastEventSource = AutomationFactory.GetUiElement(src);
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
        protected IUiElement CurrentInputElement { get; set; }
        protected internal IUiElement OddRootElement { get; set; }
        
        /// <summary>
        /// stores the state if there's no way to get it from a cmdlet object
        /// due to complexity of inheritance hierarchy
        /// </summary>
        // protected bool caseSensitive { get; set; }
        
    }
}
