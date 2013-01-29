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
    using System;
    using System.Management.Automation;
    using System.Collections;
    using System.Collections.ObjectModel;
    using System.Threading;
    using System.Management.Automation.Runspaces;
    using System.Windows.Automation;
    
    using PSTestLib;
    
    
    //using System.IO;
    
    /// <summary>
    /// The CommonCmdletBase class in the top of cmdlet hierarchy.
    /// </summary>
//    [Cmdlet(VerbsCommon.Show, "UIAModuleSettings")]
    public class CommonCmdletBase : PSCmdletBase
    // internal class CommonCmdletBase : PSCmdlet
    {
        #region Constructor
        public CommonCmdletBase()
        {
            //WriteVerbose(this, "constructor");
            
            //this.WriteVerbose(this, Preferences.OnSleepDelay.ToString());
            
            #region creating the log file
            try {
                Global.CreateLogFile();
            } catch { }
            #endregion creating the log file
            CurrentData.LastCmdlet = this.CmdletName(this);
            
            
//            #region Execution Plan
//            this.HighlightersQueue =
//				new Queue();
//			this.HighlightersMaxCount = 20;
//			this.HighlighterNumber = 0;
//			#endregion Execution Plan
        }
        #endregion Constructor
        
        // 20120816
//        #region Properties
//        protected AutomationElement EventSource { get; set; }
//        protected AutomationEventArgs EventArgs { get; set; }
//        #endregion Properties

//        protected override void BeginProcessing()
//        {
//            //WriteVerbose(this, "BeginProcessing()");
//            
//            WriteVerbose(this, Preferences.OnSleepDelay.ToString());
//        }
        
        //protected internal override bool UnitTestMode { get; set; }
        
        protected override void EndProcessing()
        {
            //WriteVerbose(this, "EndProcessing()");
            
            #region close the log
            try {
                Global.CloseLogFile();
            } catch { }
            #endregion close the log
        }
        
        #region Write methods
        //private void WriteLog(string record)
        protected override void WriteLog(string logRecord)
        {
            try {
                //Global.WriteToLogFile(record);
                Global.WriteToLogFile(logRecord);
            } catch (Exception e) {
                WriteVerbose(this, "Unable to write to the log file: " +
                             Preferences.LogPath);
                WriteVerbose(this, e.Message);
            }
        }
        
#region commented
//            #region Cmdlet Signature
//        internal string CmdletName(CommonCmdletBase cmdlet)
//        {
//            string result = String.Empty;
//            if (cmdlet == null) return result;
//            result = 
//                cmdlet.GetType().Name;
//            result = 
//                result.Replace("UIA", "-UIA").Replace("Command", "");
//            return result;
//        }
//            
//        private string CmdletSignature(CommonCmdletBase cmdlet)
//        {
//            string result = this.CmdletName(cmdlet);
//            result += ": ";
//            return result;
//        }
//            #endregion Cmdlet Signature
        
//        protected internal void WriteVerbose(CommonCmdletBase cmdlet, string text)
//        {
//            string reportString = string.Empty;
//            reportString = 
//                CmdletSignature(cmdlet) +  
//                text;
//            if (cmdlet != null) {
//            	try { WriteVerbose(reportString); } 
//            	catch { }
//            } else {
//            	
//WriteVerbose(this, "NULL !!!!!!!!!!!!!!!!!!");
//            	
//            	
//            }
//            //try {WriteVerbose(reportString); } catch {}
//            WriteLog(reportString);
//        }
//        
//        protected internal void WriteVerbose(CommonCmdletBase cmdlet, object obj)
//        {
//            string reportString = string.Empty;
//            reportString =
//                CmdletSignature(cmdlet) +  
//                obj.ToString();
//            if (cmdlet != null) try { WriteVerbose(reportString); } catch { }
//            //try {WriteVerbose(reportString); } catch {}
//            WriteLog(reportString);
//        }
#endregion commented
        
        protected internal void WriteDebug(CommonCmdletBase cmdlet, string text)
        {
            string reportString = 
                CmdletSignature(cmdlet) +  
                text;
            WriteLog(reportString);
        }
        
        protected internal void WriteDebug(CommonCmdletBase cmdlet, object obj)
        {
            string reportString = 
                CmdletSignature(cmdlet) +  
                obj.ToString();
            WriteLog(reportString);
        }
        
#region commented
//        protected internal void WriteObject(CommonCmdletBase cmdlet, object obj)
//        {
//            try{
//                AutomationElement element = null;
//                if (cmdlet != null && !(cmdlet is WizardCmdletBase)) {
//                    try {
//                        element = obj as AutomationElement;
//                        if (element is AutomationElement &&
//                            (int)element.Current.ProcessId > 0) {
//
//                            WriteVerbose(this, "current cmdlet: " + this.GetType().Name);
//                            WriteVerbose(this, "highlighting the following element:");
//                            WriteVerbose(this, "Name = " + element.Current.Name);
//                            WriteVerbose(this, "AutomationId = " + element.Current.AutomationId);
//                            WriteVerbose(this, "ControlType = " + element.Current.ControlType.ProgrammaticName);
//                            WriteVerbose(this, "X = " + element.Current.BoundingRectangle.X.ToString());
//                            WriteVerbose(this, "Y = " + element.Current.BoundingRectangle.Y.ToString());
//                            WriteVerbose(this, "Width = " + element.Current.BoundingRectangle.Width.ToString());
//                            WriteVerbose(this, "Height = " + element.Current.BoundingRectangle.Height.ToString());
//                        }
//                    } catch { //(Exception eee) {
//                        // nothing to do
//                        // just failed to highlight
//                    }
//                //  // 
//                if (element != null && element is AutomationElement &&
//                        (int)element.Current.ProcessId > 0) {
//                        WriteVerbose(this, "as it is an AutomationElement, it should be highlighted");
//                        if (Preferences.Highlight || ((HasScriptBlockCmdletBase)cmdlet).Highlight) {
//                            try {
//                                WriteVerbose(this, "run Highlighter");
//                                UIAHelper.Highlight(element);
//                                WriteVerbose(this, "after running the Highlighter");
//                            } catch (Exception ee) {
//                                WriteVerbose(this, "unable to highlight: " + ee.Message);
//                                WriteVerbose(this, obj.ToString());
//                            }
//                        }
//                    }
//                }
//                
//                WriteVerbose(this, "is going to run scriptblocks");
//                if (cmdlet != null) {
//                    // run scriptblocks
//                    if (cmdlet is HasScriptBlockCmdletBase) {
//                        WriteVerbose(this, "cmdlet is of the HasScriptBlockCmdletBase type");
//                        if (obj == null) {
//                            WriteVerbose(this, "run OnError script blocks (null)");
//                            RunOnErrorScriptBlocks(((HasScriptBlockCmdletBase)cmdlet));
//                        } else if (obj is bool && ((bool)obj) == false) {
//                            WriteVerbose(this, "run OnError script blocks (false)");
//                            RunOnErrorScriptBlocks(((HasScriptBlockCmdletBase)cmdlet));
//                        } else if (obj != null) {
//                            WriteVerbose(this, "run OnSuccess script blocks");
//                            RunOnSuccessScriptBlocks(((HasScriptBlockCmdletBase)cmdlet));
//                        }
//                    }
//                    try {
//                        CurrentData.LastResult = obj;
//                        string iInfo = string.Empty;
//                        if (((HasScriptBlockCmdletBase)cmdlet).TestResultName != null &&
//                            ((HasScriptBlockCmdletBase)cmdlet).TestResultName.Length > 0) {
//
//                            TMX.TMXHelper.CloseTestResult(((HasScriptBlockCmdletBase)cmdlet).TestResultName,
//                                                          ((HasScriptBlockCmdletBase)cmdlet).TestResultId,
//                                                          ((HasScriptBlockCmdletBase)cmdlet).TestPassed,
//                                                          false, // isKnownIssue
//                                                          this.MyInvocation,
//                                                          null, // Error
//                                                          string.Empty,
//                                                          false);
//                        } else {
//                            if (Preferences.EveryCmdletAsTestResult) {
//                                
//                                ((HasScriptBlockCmdletBase)cmdlet).TestResultName = 
//                                    getGeneratedTestResultNameByPosition(
//                                        this.MyInvocation.Line,
//                                        this.MyInvocation.PipelinePosition);
//                                ((HasScriptBlockCmdletBase)cmdlet).TestResultId = string.Empty;
//                                ((HasScriptBlockCmdletBase)cmdlet).TestPassed = true;
//
//                                TMX.TMXHelper.CloseTestResult(((HasScriptBlockCmdletBase)cmdlet).TestResultName,
//                                                              string.Empty, //((HasScriptBlockCmdletBase)cmdlet).TestResultId, // empty, to be generated
//                                                              ((HasScriptBlockCmdletBase)cmdlet).TestPassed,
//                                                              false, // isKnownIssue
//                                                              this.MyInvocation,
//                                                              null, // Error
//                                                              string.Empty,
//                                                              true);
//                            }
//                        }
//                    }
//                    catch (Exception eeee) {
//                        WriteVerbose(this, "for working with test results you need to import the TMX module");
//                    }
//
//
//                    // remove the Turbo timeout
//                    if ((cmdlet as HasTimeoutCmdletBase) != null) {
//                        
//                        if ((CurrentData.CurrentWindow != null &&
//                             CurrentData.LastResult != null) ||
//                             (obj as AutomationElement) != null) {
//                            if (Preferences.StoredDefaultTimeout != 0) {
//                                if (! Preferences.TimeoutSetByCustomer) {
//                                    Preferences.Timeout = Preferences.StoredDefaultTimeout;
//                                    Preferences.StoredDefaultTimeout = 0;
//                                }
//                            }
//                        }
//                    }
//
//
//                }
//                WriteVerbose(this, "sleeping if sleep time is provided");
//                System.Threading.Thread.Sleep(Preferences.OnSuccessDelay);
//                WriteVerbose(this, "outputting the result object");
//                if (cmdlet != null) {
//                    try { 
//                        element = obj as AutomationElement;
//                        WriteVerbose("getting the element again to ensure that it still exists");
//                        WriteVerbose((element as AutomationElement).ToString());
//                        if (!(cmdlet is WizardCmdletBase) &&
//                            (element is AutomationElement)){
//                            WriteVerbose(this, "returning the object");
//                            WriteObject(obj);
//                        } else if ((cmdlet is WizardCmdletBase)) {
//                            WriteVerbose(this, "returning the wizard or step");
//                            WriteObject(obj);
//                        } else {
//                            WriteVerbose("returning true");
//                            WriteObject(true);
//                        }
//                    } catch { // (Exception eeeee) {
//                        // test
//                        WriteVerbose(this, "failed to issue the result object of AutomationElement type");
//                        WriteVerbose(this, "returning as is");
//                        WriteObject(obj);
//                    }
//                }
//                string reportString =
//                    CmdletSignature(cmdlet) +  
//                    obj.ToString();
//                
//                if (cmdlet != null && reportString != null && reportString != string.Empty) { //try { WriteVerbose(reportString);
//                    WriteVerbose(reportString);
//                } 
//                WriteVerbose(this, "writing into the log");
//                WriteLog(reportString);
//                WriteVerbose(this, "the log record has been written");
//            }
//            catch {}
//        }
#endregion commented

        //protected override bool WriteObjectMethod010CheckOutputObject(object outputObject)
        //public override bool WriteObjectMethod010CheckOutputObject(object outputObject)
        protected override sealed bool WriteObjectMethod010CheckOutputObject(object outputObject)
        //private override bool WriteObjectMethod010CheckOutputObject(object outputObject)
        {
            //WriteVerbose("OutputMethod010CheckOutputObject UIAutomation");
            
            bool result = false;
            
            //if ((outputObject as AutomationElement) != null) { // ||
            if (null != outputObject) { // ||
                //(outputObject as wiza
                result = true;
            }
            return result;
        }
        
        //protected override void WriteObjectMethod020Highlight(PSCmdletBase cmdlet, object outputObject)
        //public override void WriteObjectMethod020Highlight(PSCmdletBase cmdlet, object outputObject)
        protected override sealed void WriteObjectMethod020Highlight(PSCmdletBase cmdlet, object outputObject)
        {
            //WriteVerbose("OutputMethod020Highlight UIAutomation");
            
            // 20121002
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
                            	ExecutionPlan.Enqueue(element, CommonCmdletBase.HighlighterGeneration);
                            	//this.Enqueue(element);
                            } else {
                            	UIAHelper.Highlight(element);
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
        }
        
        //protected override void WriteObjectMethod030RunScriptBlocks(PSCmdletBase cmdlet, object outputObject)
        protected override void WriteObjectMethod030RunScriptBlocks(PSCmdletBase cmdlet, object outputObject)
        {
            //WriteVerbose("OutputMethod030RunScriptBlocks UIAutomation");
            
            this.WriteVerbose(this, "is going to run scriptblocks");
            if (cmdlet != null) {
                // run scriptblocks
                if (cmdlet is HasScriptBlockCmdletBase) {
                    this.WriteVerbose(this, "cmdlet is of the HasScriptBlockCmdletBase type");
                    if (outputObject == null) {
                        this.WriteVerbose(this, "run OnError script blocks (null)");
                        RunOnErrorScriptBlocks(((HasScriptBlockCmdletBase)cmdlet));
                    } else if (outputObject is bool && ((bool)outputObject) == false) {
                        this.WriteVerbose(this, "run OnError script blocks (false)");
                        RunOnErrorScriptBlocks(((HasScriptBlockCmdletBase)cmdlet));
                    } else if (outputObject != null) {
                        this.WriteVerbose(this, "run OnSuccess script blocks");
                        RunOnSuccessScriptBlocks(((HasScriptBlockCmdletBase)cmdlet));
                    }
                }
            }
        }
        
        //protected override void WriteObjectMethod040SetTestResult(PSCmdletBase cmdlet, object outputObject)
        protected override void WriteObjectMethod040SetTestResult(PSCmdletBase cmdlet, object outputObject)
        {
            //WriteVerbose("OutputMethod040SetTestResult UIAutomation");

            if (cmdlet != null) {

                try {
                    CurrentData.LastResult = outputObject;

                    string iInfo = string.Empty;
                    if (((HasScriptBlockCmdletBase)cmdlet).TestResultName != null &&
                        ((HasScriptBlockCmdletBase)cmdlet).TestResultName.Length > 0) {

                        TMX.TMXHelper.CloseTestResult(((HasScriptBlockCmdletBase)cmdlet).TestResultName,
                                                      ((HasScriptBlockCmdletBase)cmdlet).TestResultId,
                                                      ((HasScriptBlockCmdletBase)cmdlet).TestPassed,
                                                      ((HasScriptBlockCmdletBase)cmdlet).KnownIssue, //false, // isKnownIssue
                                                      this.MyInvocation,
                                                      null, // Error
                                                      string.Empty,
                                                      false);

                    } else {

                        if (Preferences.EveryCmdletAsTestResult) {

                            ((HasScriptBlockCmdletBase)cmdlet).TestResultName = 
                                GetGeneratedTestResultNameByPosition(
                                    this.MyInvocation.Line,
                                    this.MyInvocation.PipelinePosition);
                            ((HasScriptBlockCmdletBase)cmdlet).TestResultId = string.Empty;
                            ((HasScriptBlockCmdletBase)cmdlet).TestPassed = true;

                            TMX.TMXHelper.CloseTestResult(((HasScriptBlockCmdletBase)cmdlet).TestResultName,
                                                          string.Empty, //((HasScriptBlockCmdletBase)cmdlet).TestResultId, // empty, to be generated
                                                          ((HasScriptBlockCmdletBase)cmdlet).TestPassed,
                                                          ((HasScriptBlockCmdletBase)cmdlet).KnownIssue, //false, // isKnownIssue
                                                          this.MyInvocation,
                                                          null, // Error
                                                          string.Empty,
                                                          true);
                        }
                    }
                }
                catch (Exception eeee) {
                    this.WriteVerbose(this, "for working with test results you need to import the TMX module");
                }
            }
        }
        
        protected override void WriteObjectMethod045OnSuccessScreenshot(PSCmdletBase cmdlet, object outputObject)
        {
            WriteVerbose(this, "WriteObjectMethod045OnSuccessScreenshot UIAutomation");

            if (UIAutomation.Preferences.OnSuccessScreenShot) {
                
//                if (Preferences.HideHighlighterOnScreenShotTaking) {
//                    UIAHelper.HideHighlighters();
//                }
                
                UIAHelper.GetScreenshotOfAutomationElement(
                    (cmdlet as HasControlInputCmdletBase),
                    (outputObject as AutomationElement), //(cmdlet as HasControlInputCmdletBase),
                    CmdletName(cmdlet), //string.Empty,
                    true,
                    0,
                    0,
                    0,
                    0,
                    string.Empty,
                    UIAutomation.Preferences.OnSuccessScreenShotFormat);
                
            }
        }
        
        //protected override void WriteObjectMethod050OnSuccessDelay(PSCmdletBase cmdlet, object outputObject)
        protected override void WriteObjectMethod050OnSuccessDelay(PSCmdletBase cmdlet, object outputObject)
        {
            //WriteVerbose("OutputMethod050OnSuccessDelay UIAutomation");
            
            //System.Threading.Thread.Sleep(Preferences.OnSuccessDelay);
            if (cmdlet != null) {
                // remove the Turbo timeout
                if ((cmdlet as HasTimeoutCmdletBase) != null) {
                    
                    this.WriteVerbose(this, "cmdlet as HasTimeoutCmdletBase");

                    if ((CurrentData.CurrentWindow != null &&
                         CurrentData.LastResult != null) ||
                         (outputObject as AutomationElement) != null) {

                        this.WriteVerbose(this, "(CurrentData.CurrentWindow != null && " + 
                         "CurrentData.LastResult != null) || " +
                         "(outputObject as AutomationElement) != null");

                        if (Preferences.StoredDefaultTimeout != 0) {

                            this.WriteVerbose(this, "Preferences.StoredDefaultTimeout != 0");
                            
                            if (!Preferences.TimeoutSetByCustomer) {

                                this.WriteVerbose(this, "! Preferences.TimeoutSetByCustomer");
                                
                                Preferences.Timeout = Preferences.StoredDefaultTimeout;

                                Preferences.StoredDefaultTimeout = 0;
                            }
                        }
                    }
                }


            }
            WriteVerbose(this, "sleeping if sleep time is provided");
            System.Threading.Thread.Sleep(Preferences.OnSuccessDelay);
        }
        
        //protected override void WriteObjectMethod060OutputResult(PSCmdletBase cmdlet, object outputObject)
        protected override void WriteObjectMethod060OutputResult(PSCmdletBase cmdlet, object outputObject)
        {
            //WriteVerbose("OutputMethod060OutputResult UIAutomation");
            
            AutomationElement element = null;
            this.WriteVerbose(this, "outputting the result object");
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
        }
        
        //protected override void WriteObjectMethod070Report(PSCmdletBase cmdlet, object outputObject)
        protected override void WriteObjectMethod070Report(PSCmdletBase cmdlet, object outputObject)
        {
            //WriteVerbose("OutputMethod070Report UIAutomation");
            
            
            string reportString =
                CmdletSignature(((CommonCmdletBase)cmdlet)) +
                outputObject.ToString();
            
            if (cmdlet != null && reportString != null && reportString != string.Empty) { //try { WriteVerbose(reportString);
                this.WriteVerbose(reportString);
            } 
            this.WriteVerbose(this, "writing into the log");
            this.WriteLog(reportString);
            this.WriteVerbose(this, "the log record has been written");
        }
        
        protected override void WriteObjectMethod080ReportFailure()
        {
            WriteVerbose(" UIAutomation");
        }
        
        
        internal static int HighlighterGeneration = 0;
        
        public override void WriteObject(PSCmdletBase cmdlet, object[] outputObjectCollection)
        {
        	CommonCmdletBase.HighlighterGeneration++;
        	base.WriteObject(cmdlet, outputObjectCollection);
        }
        
        public override void WriteObject(PSCmdletBase cmdlet, System.Collections.Generic.List<object> outputObjectCollection)
        {
        	CommonCmdletBase.HighlighterGeneration++;
        	base.WriteObject(cmdlet, outputObjectCollection);
        }
       
        public override void WriteObject(PSCmdletBase cmdlet, ArrayList outputObjectCollection)
        {
        	CommonCmdletBase.HighlighterGeneration++;
        	base.WriteObject(cmdlet, outputObjectCollection);
        }
        
        public override void WriteObject(PSCmdletBase cmdlet, ICollection outputObjectCollection)
        {
        	CommonCmdletBase.HighlighterGeneration++;
        	base.WriteObject(cmdlet, outputObjectCollection);
        }
        
        
        
        
//        protected internal void WriteObject(CommonCmdletBase cmdlet, object[] obj)
//        {
//            try{
//                if (cmdlet != null) {
//                    // run scriptblocks
//                    if (cmdlet is HasScriptBlockCmdletBase) {
//                        if (obj == null) {
//                            RunOnErrorScriptBlocks(((HasScriptBlockCmdletBase)cmdlet));
//                        } else if (obj != null) {
//                            RunOnSuccessScriptBlocks(((HasScriptBlockCmdletBase)cmdlet));
//                        }
//                    }
//                    try {
//                        CurrentData.LastResult = obj;
//                        string iInfo = string.Empty;
//                        if (((HasScriptBlockCmdletBase)cmdlet).TestResultName != null &&
//                            ((HasScriptBlockCmdletBase)cmdlet).TestResultName.Length > 0) {
//
//                            TMX.TMXHelper.CloseTestResult(((HasScriptBlockCmdletBase)cmdlet).TestResultName,
//                                                          ((HasScriptBlockCmdletBase)cmdlet).TestResultId,
//                                                          ((HasScriptBlockCmdletBase)cmdlet).TestPassed,
//                                                          false, // isKnownIssue
//                                                          this.MyInvocation,
//                                                          null, // Error
//                                                          string.Empty,
//                                                          false);
//                                                          //((HasScriptBlockCmdletBase)cmdlet).TestLog);
//                        } else {
//                            if (Preferences.EveryCmdletAsTestResult) {
//                                ((HasScriptBlockCmdletBase)cmdlet).TestResultName = 
//                                    getGeneratedTestResultNameByPosition(
//                                        this.MyInvocation.Line,
//                                        this.MyInvocation.PipelinePosition);
//                                ((HasScriptBlockCmdletBase)cmdlet).TestResultId = string.Empty;
//                                ((HasScriptBlockCmdletBase)cmdlet).TestPassed = true;
//
//                                TMX.TMXHelper.CloseTestResult(((HasScriptBlockCmdletBase)cmdlet).TestResultName,
//                                                              string.Empty, //((HasScriptBlockCmdletBase)cmdlet).TestResultId, // empty, to be generated
//                                                              ((HasScriptBlockCmdletBase)cmdlet).TestPassed,
//                                                              false, // isKnownIssue
//                                                              this.MyInvocation,
//                                                              null, // Error
//                                                              string.Empty,
//                                                              true);
//                            }
//                        }
//                    }
//                    catch {
//                        WriteVerbose(this, "for working with test results you need to import the TMX module");
//                    }
//                    
//                    // remove the Turbo timeout
//                    if ((cmdlet as HasTimeoutCmdletBase) != null) {
//                        if ((CurrentData.CurrentWindow != null &&
//                             CurrentData.LastResult != null) ||
//                             (obj as AutomationElement[]) != null) {
//                            
//                            if (Preferences.StoredDefaultTimeout != 0) {
//                                if (! Preferences.TimeoutSetByCustomer) {
//                                    Preferences.Timeout = Preferences.StoredDefaultTimeout;
//                                    Preferences.StoredDefaultTimeout = 0;
//                                }
//                            }
//                        }
//                    }
//                    
//                }
//                System.Threading.Thread.Sleep(Preferences.OnSuccessDelay);
//                
//                if (cmdlet != null) {
//                    if (obj != null && obj.Length > 0) {
//                        for (int i = 0; i < obj.Length; i++) {
//                            WriteObject(obj[i]);
//                        }
//                    }
//                }
//                
//                string reportString =
//                    CmdletSignature(cmdlet) +  
//                    obj.ToString();
//                
//                if (cmdlet != null && reportString != null && reportString != string.Empty) {
//                    WriteVerbose(reportString);
//                } 
//                WriteLog(reportString);
//            
//            }
//            catch {}
//        }
        
        private void writeErrorToTheList(ErrorRecord err)
        {
            CurrentData.Error.Add(err);
            if (CurrentData.Error.Count > Preferences.MaximumErrorCount) {
                do{
                    CurrentData.Error.RemoveAt(0);
                } while (CurrentData.Error.Count > Preferences.MaximumErrorCount);
                CurrentData.Error.Capacity = Preferences.MaximumErrorCount;
            }
        }
        
        // 20120816
//        protected void WriteError(CommonCmdletBase cmdlet, ErrorRecord err, bool terminating)
//        {
//            if (cmdlet != null) {
//                // run scriptblocks
//                if (cmdlet is HasScriptBlockCmdletBase) {
//                    RunOnErrorScriptBlocks(((HasScriptBlockCmdletBase)cmdlet));
//                }
//                // write error to the test results collection
//                // CurrentData.TestResults[CurrentData.TestResults.Count - 1].Details.Add(err);
//                //TMX.TestData.AddTestResultDetail(err);
//                TMX.TMXHelper.AddTestResultErrorDetail(err);
//                
//                // write test result label
//                try {
//                    
//                    // 20120328
//                    CurrentData.LastResult = null;
//                    string iInfo = string.Empty;
//                    if (((HasScriptBlockCmdletBase)cmdlet).TestResultName != null &&
//                        ((HasScriptBlockCmdletBase)cmdlet).TestResultName.Length > 0) {
//                        //TMX.TestData.AddTestResult
//                        //string iInfo = string.Empty;
////                        if (((HasScriptBlockCmdletBase)cmdlet).TestLog){
////                            iInfo = TMX.TMXHelper.GetInvocationInfo(this.MyInvocation);
////                        }
//
//                        TMX.TMXHelper.CloseTestResult(((HasScriptBlockCmdletBase)cmdlet).TestResultName,
//                                                      ((HasScriptBlockCmdletBase)cmdlet).TestResultId,
//                                                      ((HasScriptBlockCmdletBase)cmdlet).TestPassed,
//                                                      ((HasScriptBlockCmdletBase)cmdlet).KnownIssue,
//                                                      this.MyInvocation,
//                                                      err,
//                                                      string.Empty, 
//                                                      true);
//                                                      //((HasScriptBlockCmdletBase)cmdlet).TestLog);
//                                                      
//                    } else {
//                        if (Preferences.EveryCmdletAsTestResult) {
//                                ((HasScriptBlockCmdletBase)cmdlet).TestResultName = 
//                                    getGeneratedTestResultNameByPosition(
//                                        this.MyInvocation.Line,
//                                        this.MyInvocation.PipelinePosition);
////                                    this.MyInvocation.Line + 
////                                    ", position: " +
////                                    this.MyInvocation.PipelinePosition.ToString();
//
//                                ((HasScriptBlockCmdletBase)cmdlet).TestResultId = string.Empty;
//                                ((HasScriptBlockCmdletBase)cmdlet).TestPassed = false;
////                                iInfo = TMX.TMXHelper.GetInvocationInfo(this.MyInvocation);
//
//                                TMX.TMXHelper.CloseTestResult(((HasScriptBlockCmdletBase)cmdlet).TestResultName,
//                                                              string.Empty, //((HasScriptBlockCmdletBase)cmdlet).TestResultId, // empty, to be generated
//                                                              ((HasScriptBlockCmdletBase)cmdlet).TestPassed,
//                                                              false, // isKnownIssue
//                                                              this.MyInvocation,
//                                                              err,
////                                                              TMX.TMXHelper.GetScriptLineNumber(this.MyInvocation),
////                                                              TMX.TMXHelper.GetPipelinePosition(this.MyInvocation),
////                                                              iInfo,
//                                                              string.Empty,
//                                                              true);
//                        }
//                    }
//                }
//                catch {
//                    WriteVerbose(this, "for working with test results you need to import the TMX module");
//                }
//                
//                // set the Turbo timeout
//                if ((cmdlet is HasTimeoutCmdletBase) && 
//                    (cmdlet as HasTimeoutCmdletBase) != null) {
//                    if (CurrentData.CurrentWindow == null &&
//                        CurrentData.LastResult == null &&
//                        terminating) {
//                        int timeoutToStore = Preferences.Timeout;
//                        Preferences.Timeout = Preferences.AfterFailTurboTimeout;
//                        Preferences.TimeoutSetByCustomer = false;
//                        Preferences.StoredDefaultTimeout = timeoutToStore;
//                    }
//                }
//                
////                    // remove the Turbo timeout
////                    if (cmdlet is HasTimeoutCmdletBase) {
////                        if (CurrentData.CurrentWindow != null &&
////                            CurrentData.LastResult != null) {
////                            if (Preferences.StoredDefaultTimeout != 0) {
////                                Preferences.Timeout = Preferences.StoredDefaultTimeout;
////                                Preferences.StoredDefaultTimeout = 0;
////                            }
////                        }
////                    }
//                
//                // write an error to the Error list
//                this.writeErrorToTheList(err);
//                System.Threading.Thread.Sleep(Preferences.OnErrorDelay);
//                if (terminating) {
//                    ThrowTerminatingError(err);
//                } else {
//                    WriteError(err);
//                }
//            }
//        }

        protected override void WriteErrorMethod010RunScriptBlocks(PSCmdletBase cmdlet)
        {
            if (cmdlet != null) {
                // run scriptblocks
                if (cmdlet is HasScriptBlockCmdletBase) {
                    this.RunOnErrorScriptBlocks(((HasScriptBlockCmdletBase)cmdlet));
                }
            }
        }
        
        protected override void WriteErrorMethod020SetTestResult(PSCmdletBase cmdlet, ErrorRecord errorRecord)
        {

            if (cmdlet != null) {

                // write error to the test results collection
                // CurrentData.TestResults[CurrentData.TestResults.Count - 1].Details.Add(err);
                //TMX.TestData.AddTestResultDetail(err);
                TMX.TMXHelper.AddTestResultErrorDetail(errorRecord);

                // write test result label
                try {
                    
                    // 20120328
                    CurrentData.LastResult = null;

                    string iInfo = string.Empty;
                    if (((HasScriptBlockCmdletBase)cmdlet).TestResultName != null &&
                        ((HasScriptBlockCmdletBase)cmdlet).TestResultName.Length > 0) {
                        //TMX.TestData.AddTestResult
                        //string iInfo = string.Empty;
//                        if (((HasScriptBlockCmdletBase)cmdlet).TestLog){
//                            iInfo = TMX.TMXHelper.GetInvocationInfo(this.MyInvocation);
//                        }

                        TMX.TMXHelper.CloseTestResult(((HasScriptBlockCmdletBase)cmdlet).TestResultName,
                                                      ((HasScriptBlockCmdletBase)cmdlet).TestResultId,
                                                      false, // the only result: FAILED //((HasScriptBlockCmdletBase)cmdlet).TestPassed,
                                                      false, // because of failure //((HasScriptBlockCmdletBase)cmdlet).KnownIssue,
                                                      this.MyInvocation,
                                                      errorRecord,
                                                      string.Empty, 
                                                      true);
                                                      //((HasScriptBlockCmdletBase)cmdlet).TestLog);

                    } else {

                        if (Preferences.EveryCmdletAsTestResult) {
                                ((HasScriptBlockCmdletBase)cmdlet).TestResultName = 
                                    GetGeneratedTestResultNameByPosition(
                                        this.MyInvocation.Line,
                                        this.MyInvocation.PipelinePosition);
//                                    this.MyInvocation.Line + 
//                                    ", position: " +
//                                    this.MyInvocation.PipelinePosition.ToString();

                                ((HasScriptBlockCmdletBase)cmdlet).TestResultId = string.Empty;
                                ((HasScriptBlockCmdletBase)cmdlet).TestPassed = false;
//                                iInfo = TMX.TMXHelper.GetInvocationInfo(this.MyInvocation);

                                TMX.TMXHelper.CloseTestResult(((HasScriptBlockCmdletBase)cmdlet).TestResultName,
                                                              string.Empty, //((HasScriptBlockCmdletBase)cmdlet).TestResultId, // empty, to be generated
                                                              ((HasScriptBlockCmdletBase)cmdlet).TestPassed,
                                                              false, // isKnownIssue
                                                              this.MyInvocation,
                                                              errorRecord,
//                                                              TMX.TMXHelper.GetScriptLineNumber(this.MyInvocation),
//                                                              TMX.TMXHelper.GetPipelinePosition(this.MyInvocation),
//                                                              iInfo,
                                                              string.Empty,
                                                              true);
                        }
                    }
                }
                catch {
                    WriteVerbose(this, "for working with test results you need to import the TMX module");
                }
            }
        }
        
        
        protected override void WriteErrorMethod030ChangeTimeoutSettings(PSCmdletBase cmdlet, bool terminating)
        {
            // set the Turbo timeout
            if ((cmdlet is HasTimeoutCmdletBase) && 
                (cmdlet as HasTimeoutCmdletBase) != null) {
                
                // 20120830
//                if (CurrentData.CurrentWindow == null &&
//                    CurrentData.LastResult == null &&
//                    terminating) {

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
            this.writeErrorToTheList(err);
        }
        
        protected override void WriteErrorMethod045OnErrorScreenshot(PSCmdletBase cmdlet)
        {
            WriteVerbose(this, "WriteErrorMethod045OnErrorScreenshot UIAutomation");
            
            if (UIAutomation.Preferences.OnErrorScreenShot) {
                //UIAHelper.GetScreenshotOfAutomationElement(
//                UIAHelper.GetScreenshotOfCmdletInput(
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
//                    UIAHelper.HideHighlighters();
//                }
                
                AutomationElement elementToTakeScreenShot = null;
                try {
                    if (null != CurrentData.CurrentWindow) {
                        elementToTakeScreenShot = CurrentData.CurrentWindow;
                    } else {
                        elementToTakeScreenShot = AutomationElement.RootElement;
                    }
                }
                catch {
                    elementToTakeScreenShot = AutomationElement.RootElement;
                }
                UIAHelper.GetScreenshotOfAutomationElement(
                    (cmdlet as HasControlInputCmdletBase),
                    elementToTakeScreenShot,
                    CmdletName(cmdlet),
                    true,
                    0,
                    0,
                    0,
                    0,
                    string.Empty,
                    UIAutomation.Preferences.OnErrorScreenShotFormat);
            }
        }
        
        protected override void WriteErrorMethod050OnErrorDelay(PSCmdletBase cmdlet)
        {
            System.Threading.Thread.Sleep(Preferences.OnErrorDelay);
        }
        
        protected override void WriteErrorMethod060OutputError(PSCmdletBase cmdlet, ErrorRecord err, bool terminating)
        {
            if (terminating) {
                ThrowTerminatingError(err);
            } else {
                WriteError(err);
            }
        }
        
        protected override void WriteErrorMethod070Report(PSCmdletBase cmdlet)
        {
            WriteVerbose(this, "WriteErrorMethod070Report PSCmdletBase");
        }
        
//        private string getGeneratedTestResultNameByPosition(
//            string initialString, 
//            int? position)
//        {
//            string result = string.Empty;
//            
//            if (! initialString.Contains("|")) {
//                result = initialString;
//            } else {
//                try {
//                    string[] results = 
//                        initialString.Split('|');
//                    result = results[(int)(position - 1)].Trim();
//                }
//                catch {
//                    
//                }
//            }
//            
//            return result;
//        }
        #endregion Write methods
        
        #region sleep and run scripts
        // 20120312 0.6.11
        //protected void SleepAndRunScriptBlocks(HasTimeoutCmdletBase cmdlet)
        protected void SleepAndRunScriptBlocks(HasControlInputCmdletBase cmdlet)
        {
            this.RunOnSleepScriptBlocks(cmdlet);
            System.Threading.Thread.Sleep(Preferences.OnSleepDelay);
            // RunScriptBlocks(cmdlet);
        }
        #endregion sleep and run scripts
        
        #region Invoke-UIAScript
        // 20120209 protected void RunEventScriptBlocks(EventCmdletBase cmdlet)
        //protected internal void RunEventScriptBlocks(EventCmdletBase cmdlet)
        protected internal void RunEventScriptBlocks(HasControlInputCmdletBase cmdlet)
        {
            System.Collections.Generic.List<ScriptBlock >  blocks =
                new System.Collections.Generic.List<ScriptBlock > ();
            this.WriteVerbose(cmdlet,
                         blocks.Count.ToString() + 
                         " events to fire");
            if (cmdlet.EventAction != null &&
                cmdlet.EventAction.Length > 0) {
                foreach (ScriptBlock sb in cmdlet.EventAction) {
                    blocks.Add(sb);
                    this.WriteVerbose(cmdlet,
                                 "the scriptblock: " + 
                                 sb.ToString() + 
                                 " is ready to be fired");
                }
            }
            runScriptBlocks(blocks, cmdlet, true);
            // runEventScriptBlocks(blocks, cmdlet); //, true);
        }
        
        // 20120816
        // 20120209 protected void RunOnSuccessScriptBlocks(HasScriptBlockCmdletBase cmdlet)
        protected internal void RunOnSuccessScriptBlocks(HasScriptBlockCmdletBase cmdlet)
        {
            runTwoScriptBlockCollections(
                Preferences.OnSuccessAction,
                cmdlet.OnSuccessAction,
                cmdlet);
        }
        
        // 20120209 protected void RunOnErrorScriptBlocks(HasScriptBlockCmdletBase cmdlet)
        protected internal void RunOnErrorScriptBlocks(HasScriptBlockCmdletBase cmdlet)
        {
            runTwoScriptBlockCollections(
                Preferences.OnErrorAction,
                cmdlet.OnErrorAction,
                cmdlet);
        }
        
        // 20120209 protected void RunOnSleepScriptBlocks(HasTimeoutCmdletBase cmdlet)
        // 20120312 0.6.11
        //protected internal void RunOnSleepScriptBlocks(HasTimeoutCmdletBase cmdlet)
        protected internal void RunOnSleepScriptBlocks(HasControlInputCmdletBase cmdlet)
        {
            if (cmdlet is HasTimeoutCmdletBase) {
                runTwoScriptBlockCollections(
                    Preferences.OnSleepAction,
                    ((HasTimeoutCmdletBase)cmdlet).OnSleepAction,
                    cmdlet);
            }
        }
        
        protected internal void RunWizardScriptBlocks(WizardCmdletBase cmdlet, Wizard wizard)
        {
            runTwoScriptBlockCollections(
                null,
                wizard.StartAction,
                cmdlet);
        }
        
        protected internal void RunWizardStepScriptBlocks(
            WizardCmdletBase cmdlet, 
            WizardStep wizardStep,
            bool forward)
        {
            if (forward) {
                runTwoScriptBlockCollections(
                    null,
                    wizardStep.StepForwardAction,
                    cmdlet);
            } else {
                runTwoScriptBlockCollections(
                    null,
                    wizardStep.StepBackwardAction,
                    cmdlet);
            }
        }
        
        
        // 20120829
        //protected override void SaveEventInput(
        // 20130120
        //protected void SaveEventInput(
        protected override void SaveEventInput(
            AutomationElement src,
            AutomationEventArgs e,
            string programmaticName,
            bool infoAdded)
        {
            // inform the Wait-UIAEventRaised cmdlet
            try {
                CurrentData.LastEventSource = src; // as AutomationElement;
                CurrentData.LastEventArgs = e; // as AutomationEventArgs;
                CurrentData.LastEventType = programmaticName;
                CurrentData.LastEventInfoAdded = infoAdded;
            }
            catch {
                //WriteVerbose(this, "failed to register an event in the collection");
            }
        }
        
        // 20120816
//        private void runTwoScriptBlockCollections(
//            ScriptBlock[] blocks1,
//            ScriptBlock[] blocks2,
//            HasScriptBlockCmdletBase cmdlet)
//        {
//            System.Collections.Generic.List<ScriptBlock> blocks =
//                new System.Collections.Generic.List<ScriptBlock>();
//            if (blocks1 != null &&
//                blocks1.Length > 0) {
//                foreach (ScriptBlock sb in blocks1) {
//                    blocks.Add(sb);
//                }
//            }
//            if (blocks2 != null &&
//                blocks2.Length > 0) {
//                foreach (ScriptBlock sb in blocks2) {
//                    blocks.Add(sb);
//                }
//            }
//            runScriptBlocks(blocks, cmdlet, false);
//        }
//        
//        private void runScriptBlocks(System.Collections.Generic.List<ScriptBlock >  blocks,
//                                     HasScriptBlockCmdletBase cmdlet,
//                                     bool eventHandlers)
//        {
//            try {
//                if (blocks != null &&
//                    blocks.Count > 0) {
//                    // WriteVerbose(this, "runScriptBlocks 1 fired");
//                    foreach (ScriptBlock sb in blocks) {
//                        // WriteVerbose(this, "runScriptBlocks 2 fired");
//                        if (sb != null) {
//                            // WriteVerbose(this, "runScriptBlocks 3 fired");
//                            try {
//                                if (eventHandlers) {
//                                    // WriteVerbose(this, "runScriptBlocks 4 fired");
//                                    // runScriptBlock runner = new runScriptBlock(runSBEvent);
//                                    // runScriptBlock runner = new runScriptBlock(runSBEvent);
//                                    // test
//                                    runScriptBlock runner = new runScriptBlock(runSBEvent);
//                                    // WriteVerbose(this, "runScriptBlocks 5 fired");
//                                    runner(sb, cmdlet.EventSource, cmdlet.EventArgs);
//                                    // WriteVerbose(this, "runScriptBlocks 6 fired");
//                                } else {
//                                    // runScriptBlock runner = new runScriptBlock(runSB);
//                                    runScriptBlock runner = new runScriptBlock(runSBAction);
//                                    runner(sb, cmdlet.EventSource, cmdlet.EventArgs);
//                                }
//                            } catch (Exception eInner) {
//                                ErrorRecord err = 
//                                    new ErrorRecord(
//                                        eInner,
//                                        "InvokeException",
//                                        ErrorCategory.OperationStopped,
//                                        sb);
//                                err.ErrorDetails = 
//                                    new ErrorDetails("Error in " +
//                                                     sb.ToString());
//                                WriteError(this, err, false);
//                            }
//                        }
//                    }
//                }
//            } catch (Exception eOuter) {
//                WriteError(this, 
//                           new ErrorRecord(eOuter, "runScriptBlocks", ErrorCategory.InvalidArgument, null),
//                           true);
//            }
//        }
        #endregion Invoke-UIAScript
        
        //protected internal System.DateTime startDate;
        protected internal System.DateTime startDate { get; set; }
        //protected System.Windows.Automation.AutomationElement _window = null;
        protected AutomationElement _window { get; set; }
        //protected System.Windows.Automation.AutomationElement aeCtrl = null;
        // 20120823
        //protected AutomationElement aeCtrl { get; set; }
        //protected AutomationElementCollection aeCtrl { get; set; }
        protected ArrayList aeCtrl { get; set; }
        //protected internal System.Windows.Automation.AutomationElement rootElement;
        protected internal AutomationElement rootElement { get; set; }
        
        /// <summary>
        /// stores the state if there's no way to get it from a cmdlet object 
        /// due to complexity of inheritance hierarchy
        /// </summary>
        protected bool caseSensitive { get; set; }
        
        #region Get-UIAControl
        public AndCondition[] getControlsConditions(GetControlCollectionCmdletBase cmdlet)
        {
            System.Collections.Generic.List<AndCondition >  conditions = 
                new System.Collections.Generic.List<AndCondition > ();
            // 20130125
            //if (cmdlet.ControlType != null && cmdlet.ControlType.Length > 0) {
            if (null != cmdlet.ControlType && 0 < cmdlet.ControlType.Length) {
                for (int i = 0; i < cmdlet.ControlType.Length; i++) {
                    WriteVerbose(this, "control type: " + cmdlet.ControlType[i]);
                    // 20130127
                    //conditions.Add(getControlConditions(((GetControlCmdletBase)cmdlet), cmdlet.ControlType[i]));
                    // 20130128
                    //conditions.Add(getControlConditions(((GetControlCmdletBase)cmdlet), cmdlet.ControlType[i], cmdlet.CaseSensitive));
                    //conditions.Add(getControlConditions(((GetControlCmdletBase)cmdlet), cmdlet.ControlType[i], cmdlet.CaseSensitive, true));
                    conditions.Add(getControlConditions(((GetControlCmdletBase)cmdlet), cmdlet.ControlType[i], cmdlet.CaseSensitive, true) as AndCondition);
                }
            } else{
                WriteVerbose(this, "without control type");
                // 20130127
                //conditions.Add(getControlConditions(((GetControlCmdletBase)cmdlet), ""));
                // 20130128
                //conditions.Add(getControlConditions(((GetControlCmdletBase)cmdlet), "", cmdlet.CaseSensitive));
                //conditions.Add(getControlConditions(((GetControlCmdletBase)cmdlet), "", cmdlet.CaseSensitive, true));
                conditions.Add(getControlConditions(((GetControlCmdletBase)cmdlet), "", cmdlet.CaseSensitive, true) as AndCondition);
            }
            return conditions.ToArray();
        }
        
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "get")]
        //public AndCondition getControlConditions(GetControlCmdletBase cmdlet, string controlType)
        // 20130127
        //public AndCondition getControlConditions(HasControlInputCmdletBase cmdlet1, string controlType)
        // 20130128
        //public AndCondition getControlConditions(HasControlInputCmdletBase cmdlet1, string controlType, bool caseSensitive, bool AndVsOr)
        public object getControlConditions(HasControlInputCmdletBase cmdlet1, string controlType, bool caseSensitive, bool AndVsOr)
        {
            System.Windows.Automation.ControlType ctrlType = null;
            System.Windows.Automation.AndCondition andConditions = null;
            // 20130128
            System.Windows.Automation.OrCondition orConditions = null;
            System.Windows.Automation.PropertyCondition condition = null;
            // 20130128
            System.Windows.Automation.AndCondition allConditions = null;
            // 20130128
            object conditionsToReturn = null;
            // 20130127
            PropertyConditionFlags flags = PropertyConditionFlags.None;
            if (!caseSensitive) {
                flags = PropertyConditionFlags.IgnoreCase;
            }
            
            GetControlCmdletBase cmdlet = 
                (GetControlCmdletBase)cmdlet1;
            
            // 20130128
            // the TextSearch mode
            if (null != cmdlet.ContainText &&
                string.Empty != cmdlet.ContainText &&
                !AndVsOr) {
                cmdlet.Name =
                    cmdlet.AutomationId =
                    cmdlet.Class =
                    cmdlet.Value =
                    cmdlet.ContainText;
            }
            
            //if (cmdlet.ControlType != null && cmdlet.ControlType.Length > 0) {
            if (controlType != null && controlType.Length > 0) {

                WriteVerbose(this, 
                             "getting control with control type = " + 
                             controlType);
                ctrlType = 
                    UIAHelper.GetControlTypeByTypeName(controlType);
                WriteVerbose(cmdlet, "ctrlType = " + ctrlType.ProgrammaticName);
            }
            System.Windows.Automation.PropertyCondition ctrlTypeCondition = null,
                classCondition = null, titleCondition = null, autoIdCondition = null;
            // 20130127
            System.Windows.Automation.PropertyCondition valueCondition = null;
            
            //WriteVerbose(cmdlet, "ctrlType = " + ctrlType.ProgrammaticName);
            int conditionsCounter = 0;
            if (ctrlType != null) {

                ctrlTypeCondition =
                    new System.Windows.Automation.PropertyCondition(
                                System.Windows.Automation.AutomationElement.ControlTypeProperty,
                                ctrlType); //,
                                // // 20130127
                                // flags);
                WriteVerbose(cmdlet, "ControlTypeProperty '" +
                             ctrlType.ProgrammaticName + "' is used");
                // 20130128
                //conditionsCounter++;
            }
            // 20120828
            if (cmdlet.Class != null && cmdlet.Class != "")
            //if (null != cmdlet.Class && cmdlet.Class.Length > 0) {
            {

                classCondition =
                    new System.Windows.Automation.PropertyCondition(
                                System.Windows.Automation.AutomationElement.ClassNameProperty,
                                cmdlet.Class,
                                // 20130121
                                //PropertyConditionFlags.IgnoreCase);
                                // 20130127
                                flags);
                WriteVerbose(cmdlet, "ClassNameProperty '" + 
                             cmdlet.Class + "' is used");
                conditionsCounter++;
            }
            if (cmdlet.AutomationId != null && cmdlet.AutomationId != "")
            {

                autoIdCondition =
                    new System.Windows.Automation.PropertyCondition(
                                System.Windows.Automation.AutomationElement.AutomationIdProperty,
                                cmdlet.AutomationId,
                                // 20130121
                                //PropertyConditionFlags.IgnoreCase);
                                // 20130127
                                flags);
                WriteVerbose(cmdlet, "AutomationIdProperty '" + 
                             cmdlet.AutomationId + "' is used");
                conditionsCounter++;
            }
            if (cmdlet.Name != null && cmdlet.Name != "") // allow empty name
            {

                titleCondition =
                    new System.Windows.Automation.PropertyCondition(
                                System.Windows.Automation.AutomationElement.NameProperty,
                                cmdlet.Name,
                                // 20130121
                                //PropertyConditionFlags.IgnoreCase);
                                // 20130127
                                flags);
                WriteVerbose(cmdlet, "NameProperty '" + 
                             cmdlet.Name + "' is used");
                conditionsCounter++;
            }
            // 20130127
            if (cmdlet.Value != null && cmdlet.Value != "")
            {

                valueCondition =
                    new System.Windows.Automation.PropertyCondition(
                                System.Windows.Automation.ValuePattern.ValueProperty,
                                cmdlet.Value,
                                // 20130121
                                //PropertyConditionFlags.IgnoreCase);
                                // 20130127
                                flags);
                WriteVerbose(cmdlet, "ValueProperty '" + 
                             cmdlet.Value + "' is used");
                conditionsCounter++;
            }

            // 20130128
            //if (conditionsCounter > 1)
            // if there is more than one condition excepting ctrlTypeCondition
            if (1 < conditionsCounter)
            {

                try {
                    System.Collections.ArrayList l = new System.Collections.ArrayList();
                    if (classCondition != null)l.Add(classCondition);
                    // 20130128
                    //if (ctrlTypeCondition != null)l.Add(ctrlTypeCondition);
                    if (titleCondition != null)l.Add(titleCondition);
                    if (autoIdCondition != null)l.Add(autoIdCondition);
                    // 20130127
                    if (null != valueCondition)l.Add(valueCondition);
                    System.Type t = typeof(System.Windows.Automation.Condition);
                    System.Windows.Automation.Condition[] conds = 
                        ((System.Windows.Automation.Condition[])l.ToArray(t));
                    // 20130128
                    if (AndVsOr) {

                        andConditions =
                            new System.Windows.Automation.AndCondition(conds);
                    } else {

                        orConditions =
                            new System.Windows.Automation.OrCondition(conds);
                    }
                    // 20130128
//                    if (null == ctrlTypeCondition) {
//                        //var ctrlTypeCond =
//                            //new Condi
//                    } else {
//                        //var ctrlTypeCond =
//                    }
                    if (null != andConditions) {

                        allConditions =
                            new System.Windows.Automation.AndCondition(
                                null == ctrlTypeCondition ? Condition.TrueCondition : ctrlTypeCondition,
                                andConditions);

                    }
                    if (null != orConditions) {

                        allConditions =
                            new System.Windows.Automation.AndCondition(
                                null == ctrlTypeCondition ? Condition.TrueCondition : ctrlTypeCondition,
                                orConditions);

                    }
                    //}
                // 20130128
                //conditions =
                //    new System.Windows.Automation.AndCondition(conds);

                WriteVerbose(cmdlet, "used conditions " + 
                             "ClassName = '" + classCondition.Value + "', " + 
                             "ControlType = '" + ctrlTypeCondition.Value + "', " + 
                             "Name = '" + titleCondition.Value + "', " + 
                             "AutomationId = '" + autoIdCondition.Value + "', " +  //"'");
                             // 20130127
                             "Value = '" + valueCondition.Value + "'");

                } catch (Exception eConditions) {
                    WriteDebug(cmdlet, "conditions related exception " +
                                eConditions.Message);
                }
            // 20130128
            //} else if (conditionsCounter == 1)
            //} else if ((1 == conditionsCounter) || (0 == conditionsCounter && null != ctrlTypeCondition))
            // 20130128
            } else if (1 == conditionsCounter && null != ctrlTypeCondition)
            {

                if (classCondition != null) { allConditions = new AndCondition(classCondition, ctrlTypeCondition); }
                else if (titleCondition != null) { allConditions = new AndCondition(titleCondition, ctrlTypeCondition); }
                else if (autoIdCondition != null) { allConditions = new AndCondition(autoIdCondition, ctrlTypeCondition); }
                else if (null != valueCondition) { allConditions = new AndCondition(valueCondition, ctrlTypeCondition); }
                WriteVerbose(cmdlet, "conditions: ctrlTypeCondition + a condition");
                
            // 20130128
            } else if ((0 == conditionsCounter && null != ctrlTypeCondition) ||
                       (1 == conditionsCounter && null == ctrlTypeCondition))
            {

                if (classCondition != null) { condition = classCondition; }
                else if (ctrlTypeCondition != null) { condition = ctrlTypeCondition; }
                else if (titleCondition != null) { condition = titleCondition; }
                else if (autoIdCondition != null) { condition = autoIdCondition; }
                // 20130127
                else if (null != valueCondition) { condition = valueCondition; }
                WriteVerbose(cmdlet, "condition " + 
                             condition.GetType().Name + " '" + 
                             condition.Value + "' is used");
            }
            // 20130128
            //else if (conditionsCounter == 0)
            else if (0 == conditionsCounter && null == ctrlTypeCondition)
            {

                WriteVerbose(cmdlet, "neither ControlType nor Class nor Name are present");
                //WriteObject(null); //# produce the output
                //return null;
                
                ////return conditions;
                ////return Condition.TrueCondition;
                return (new AndCondition(Condition.TrueCondition,
                                         Condition.TrueCondition));
            }
            try {
                // 20130128
                Condition[] tempConditions = null;
                if (null != allConditions) {

                    tempConditions = allConditions.GetConditions();
                    conditionsToReturn = allConditions;

                }
                // 20130128
                //if (andConditions != null) {
                else if (null != andConditions) {

                    // 20130128
                    //Condition[] tempConditions = andConditions.GetConditions();
                    tempConditions = andConditions.GetConditions();
                    // 20130128
                    //for (int i = 0; i < tempConditions.Length; i++) {
                    //    WriteVerbose(cmdlet, "condition: " + tempConditions[i].ToString());
                    //}
                    // 20130128
                    conditionsToReturn = andConditions;

                    //WriteVerbose(cmdlet, "conditions: " +
                    // conditions.GetConditions());
                // 20130128
                } else if (null != orConditions) {

                    tempConditions = orConditions.GetConditions();
                    conditionsToReturn = orConditions;

                } else if (condition != null) {

                    WriteVerbose(cmdlet, "conditions (only one): " +
                                 condition.Property.ProgrammaticName + 
                                 " = " + 
                                 condition.Value.ToString());
                    // 20130128
                    //andConditions = 
                    allConditions =
                        new AndCondition(condition,
                                         Condition.TrueCondition);
                    // 20130128
                    conditionsToReturn = allConditions;

                }
                // 20130128
                if (null != tempConditions) {
                    for (int i = 0; i < tempConditions.Length; i++) {
                        WriteVerbose(cmdlet, "condition: " + tempConditions[i].ToString());
                    }
                }

                // 20130128
                //return andConditions;
                return conditionsToReturn;
            } catch {
                WriteVerbose(cmdlet, "conditions or condition are null");
                //return null;
                // 20130128
                //return andConditions;
                return conditionsToReturn;
            }
        }
        
        protected void displayConditions(
            GetControlCmdletBase cmdlet,
            AndCondition conditions, 
            string description)
        {
            try {
                Condition[] conds = conditions.GetConditions();
                for (int i = 0; i < conds.Length; i++) {
                    cmdlet.WriteVerbose(cmdlet, "<<<< displaying conditions '" + description + "' >>>>");
                    cmdlet.WriteVerbose(cmdlet, (conds[i] as PropertyCondition).Property.ProgrammaticName);
                    cmdlet.WriteVerbose(cmdlet, (conds[i] as PropertyCondition).Value.ToString());
                    cmdlet.WriteVerbose(cmdlet, (conds[i] as PropertyCondition).Flags.ToString());

                }
            }
            catch {}
        }
        
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "get")]
        //protected void getControl(GetControlCmdletBase cmdlet)
        
        // 20120823
        //protected AutomationElementCollection getControl(GetControlCmdletBase cmdlet)
        protected ArrayList getControl(GetControlCmdletBase cmdlet)
        {
            try {
                //aeCtrl = null;
                aeCtrl = new ArrayList();
                System.Windows.Automation.AndCondition conditions = null;
                
                // 20130127
                //conditions = this.getControlConditions(cmdlet, cmdlet.ControlType);
                // 20130128
                //conditions = this.getControlConditions(cmdlet, cmdlet.ControlType, ((GetControlCmdletBase)cmdlet).CaseSensitive);
                //conditions = this.getControlConditions(cmdlet, cmdlet.ControlType, ((GetControlCmdletBase)cmdlet).CaseSensitive, true);
                conditions = this.getControlConditions(cmdlet, cmdlet.ControlType, ((GetControlCmdletBase)cmdlet).CaseSensitive, true) as AndCondition;
                
                // display conditions for a regular search
                this.WriteVerbose(cmdlet, "these conditions are used for an exact search:");
                displayConditions(cmdlet, conditions, "for exact search");


                // additional search conditions if the search works with wildcards
                // only ControlType is here since that
                // Name, AutomationID, ClassName can be wildcarded
                
                // 20120918
//                System.Windows.Automation.ControlType ctrlTypeForWildCards = 
//                    UIAHelper.GetControlTypeByTypeName(cmdlet.ControlType);
                GetControlCmdletBase tempCmdlet = 
                    new GetControlCmdletBase();
                tempCmdlet.ControlType = cmdlet.ControlType;
                // 20130128
                bool notTextSearch = true;
                if (null != cmdlet.ContainText && string.Empty != cmdlet.ContainText) {
                    tempCmdlet.ContainText = cmdlet.ContainText;
                    notTextSearch = false;
                }
                System.Windows.Automation.AndCondition conditionsForWildCards = 
                //conditionsForWildCards =
                    // 20130127
                    //this.getControlConditions(tempCmdlet, tempCmdlet.ControlType);
                    // 20130128
                    //this.getControlConditions(tempCmdlet, tempCmdlet.ControlType, ((GetControlCmdletBase)cmdlet).CaseSensitive);
                    //this.getControlConditions(tempCmdlet, tempCmdlet.ControlType, ((GetControlCmdletBase)cmdlet).CaseSensitive, true);
                    this.getControlConditions(tempCmdlet, tempCmdlet.ControlType, ((GetControlCmdletBase)cmdlet).CaseSensitive, true) as AndCondition;
                
                System.Windows.Automation.AndCondition conditionsForTextSearch =
                    this.getControlConditions(
                        tempCmdlet,
                        tempCmdlet.ControlType,
                        //((GetControlCmdletBase)cmdlet).CaseSensitive,
                        cmdlet.CaseSensitive,
                        false) as AndCondition;
                
                // display conditions for a wildcarded search
                this.WriteVerbose(cmdlet, "these conditions are used for a wildcard search:");
                displayConditions(cmdlet, conditionsForWildCards, "for wildcard search");
                
                // 20120823
                foreach (AutomationElement inputObject in cmdlet.InputObject) {

                int processId = 0;
                do {
                        // 20120823
                        //if (cmdlet.InputObject != null &&
                        if (inputObject != null &&
                            //(int)cmdlet.InputObject.Current.ProcessId > 0) {
                            // 20120823
                            (int)inputObject.Current.ProcessId > 0) {
                            this.WriteVerbose(cmdlet, "CommonCmdletBase: getControl(cmdlet)");
                            this.WriteVerbose(cmdlet, "cmdlet.InputObject != null");
                            //processId = cmdlet.InputObject.Current.ProcessId;
                            // 20120823
//                            try {
                                processId = inputObject.Current.ProcessId;
                                

                        }

#region text search
                        // 20130128
                        if (0 == aeCtrl.Count) {
                            if (null != cmdlet.ContainText && string.Empty != cmdlet.ContainText) {
                                
                                this.WriteVerbose(cmdlet, "Text search");
                                AutomationElementCollection textSearchCollection =
                                    inputObject.FindAll(
                                        TreeScope.Descendants,
                                        conditionsForTextSearch);

                                if (null != textSearchCollection && 0 < textSearchCollection.Count) {
                                    
                                    this.WriteVerbose(cmdlet, "There are " + textSearchCollection.Count.ToString() + " elements");
                                    foreach (AutomationElement element in textSearchCollection) {
                                        aeCtrl.Add(element);
                                    }
                                }
                            }
                        }
#endregion text search

#region exact search

                        // 20130128
                        if (0 == aeCtrl.Count && notTextSearch) {
                            // 20120918
                            //if ((! Preferences.DisableExactSearch && ! cmdlet.Win32) ) { //|| doExactSearch) {
                            if (!Preferences.DisableExactSearch && !cmdlet.Win32 ) { //|| doExactSearch) {
                                
                                if (conditions != null) { // && condition == null) {
                                    
                                    // 20120823
                                    //if (cmdlet.InputObject != null &&
                                    if (inputObject != null &&
                                        
                                        // 20120823
                                        //(int)cmdlet.InputObject.Current.ProcessId > 0) {
                                        (int)inputObject.Current.ProcessId > 0) {
    
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
                                            AutomationElementCollection tempCollection =
                                                // 20120823
                                            	//cmdlet.InputObject.FindFirst(System.Windows.Automation.TreeScope.Descendants,
                                                inputObject.FindAll(
                                                    System.Windows.Automation.TreeScope.Descendants,
                                                    conditions);
    
                                            // 20120824
                                            foreach (AutomationElement tempElement in tempCollection) {
                                                // 20120917
                                                if (null == cmdlet.SearchCriteria || 0 == cmdlet.SearchCriteria.Length) {
                                                    aeCtrl.Add(tempElement);
                                                    cmdlet.WriteVerbose(cmdlet, "ExactSearch: element added to the result collection");
                                                } else {
                                                    cmdlet.WriteVerbose(cmdlet, "ExactSearch: checking search criteria");
                                                    if (testControlWithAllSearchCriteria(
                                                        cmdlet,
                                                        cmdlet.SearchCriteria,
                                                        tempElement)) {
                                                        cmdlet.WriteVerbose(cmdlet, "ExactSearch: the control matches the search criteria");
                                                        aeCtrl.Add(tempElement);
                                                        cmdlet.WriteVerbose(cmdlet, "ExactSearch: element added to the result collection");
                                                    }
                                                }
                                            }
    #region -First
    //                                    }
    #endregion -First
                                    } //else if (UIAutomation.CurrentData.LastResult
                                }
    
                            }
                        }

#endregion exact search

#region wildcard search

                        // 20130128
                        if (0 == aeCtrl.Count && notTextSearch) {
                            try {
                            if (!Preferences.DisableWildCardSearch && !cmdlet.Win32) {
    							this.WriteVerbose(cmdlet, "[getting the control] using WildCard search");

                                // 20120830
                                GetControlCollectionCmdletBase cmdlet1 =
                                    new GetControlCollectionCmdletBase(
                                        cmdlet.InputObject,
                                        cmdlet.Name,
                                        //nameAsterisk,
                                        cmdlet.AutomationId,
                                        cmdlet.Class,
                                        (string[])(new ArrayList()).ToArray(typeof(string)),
                                        this.caseSensitive);

                                // 20120917
                                //ArrayList tempList = new ArrayList();
                                
                                try{
                                // 20120917
                                //aeCtrl = 
                                
                                ArrayList tempList =
                                    cmdlet1.GetAutomationElementsViaWildcards_FindAll(
                                        cmdlet1,
                                        // 20130126
                                        inputObject,
                                        conditionsForWildCards,
                                        cmdlet1.CaseSensitive,
                                        // 20120824
                                        //true, 
                                        false,
                                        false);
                                
                                foreach (AutomationElement tempElement2 in tempList) {

                                    // 20120917
                                    if (null == cmdlet.SearchCriteria || 0 == cmdlet.SearchCriteria.Length) {

                                        // // 20130125
                                        aeCtrl.Add(tempElement2);

                                        // // 20130125
                                        cmdlet.WriteVerbose(cmdlet, "WildCardSearch: element added to the result collection (no SearchCriteria)");

                                    } else {

                                        cmdlet.WriteVerbose(cmdlet, "WildCardSearch: checking search criteria");
                                        if (testControlWithAllSearchCriteria(
                                            cmdlet,
                                            cmdlet.SearchCriteria,
                                            tempElement2)) {

                                            cmdlet.WriteVerbose(cmdlet, "WildCardSearch: the control matches the search criteria");
                                            aeCtrl.Add(tempElement2);
                                            cmdlet.WriteVerbose(cmdlet, "WildCardSearch: element added to the result collection (SearchCriteria)");
                                        }
                                        cmdlet.WriteVerbose(cmdlet, "WildCardSearch: element added to the result collection (SearchCriteria) (2)");
                                    }
                                    cmdlet.WriteVerbose(cmdlet, "WildCardSearch: element added to the result collection (SearchCriteria) (3)");
                                }
                                cmdlet.WriteVerbose(cmdlet, "WildCardSearch: element added to the result collection (SearchCriteria) (4)");
                                
                                } catch (Exception eUnexpected) { 
                                    this.WriteVerbose(this, eUnexpected.Message);
                                    
                                    
                                    string errrorDescription = 
                                        "The input control or window has been possibly lost." + 
                                        eUnexpected.Message;
                                    ErrorRecord errUnexpected =
                                        new ErrorRecord(
                                            new Exception(errrorDescription),
                                            "UnexpectedError",
                                            ErrorCategory.ObjectNotFound,
                                            null);
                                    errUnexpected.ErrorDetails = 
                                        new ErrorDetails(errrorDescription);
        
                                    this.WriteError(this, errUnexpected, true);
                                }
                                
                            } // if (! Preferences.DisableWildCardSearch)
//						} // if (aeCtrl == null && cmdlet.Name.Length > 0) // WildCard
                            }
                            catch (Exception eWildCardSearch) {
//                                string errrorDescription = 
//                                    "The input control or window has been possibly lost." + 
//                                    eWildCardSearch.Message;
//                                ErrorRecord errUnexpected =
//                                    new ErrorRecord(
//                                        new Exception(errrorDescription),
//                                        "UnexpectedError",
//                                        ErrorCategory.ObjectNotFound,
//                                        null);
//                                errUnexpected.ErrorDetails = 
//                                    new ErrorDetails(errrorDescription);
//    
//                                this.WriteError(this, errUnexpected, true);
                                
                                this.WriteError(
                                    cmdlet,
                                    "The input control or window has been possibly lost." + 
                                    eWildCardSearch.Message,
                                    "UnexpectedError",
                                    ErrorCategory.ObjectNotFound,
                                    true);
                            }
                        }
#endregion wildcard search
						
#region Win32 search
                        if (0 == aeCtrl.Count && notTextSearch) { // && cmdlet.Name.Length > 0) { // 20120918
                            
                            // // 20130125
                            if (!Preferences.DisableWin32Search || cmdlet.Win32) {
                            //if ((!Preferences.DisableWin32Search || cmdlet.Win32) && null == cmdlet.Class && null == cmdlet.AutomationId) {
                            //if (!Preferences.DisableWin32Search && cmdlet.Win32) {
                                
                                // using API
                                this.WriteVerbose(cmdlet, "[getting the control] using FindWindowEx");
                                
                                // 20120917
                                //aeCtrl =
                                // 20120917
                                ArrayList tempListWin32 =
                                    UIAHelper.GetControlByName(
                                        cmdlet,
                                        // 20120823
                                        //cmdlet.InputObject,
                                        inputObject,
                                        cmdlet.Name);
                                
                                foreach (AutomationElement tempElement3 in tempListWin32) {

                                    if (null != cmdlet.ControlType &&
                                        0 < cmdlet.ControlType.Length) {
//cmdlet.WriteVerbose(cmdlet, "cmdlet.ControlType.ToUpper() = " + cmdlet.ControlType.ToUpper());
//cmdlet.WriteVerbose(cmdlet, "tempElement3.Current.ControlType.ProgrammaticName.ToUpper() = " + tempElement3.Current.ControlType.ProgrammaticName.ToUpper());
                                        //bool resultControlType = false;
                                        //foreach (string controlTypeName in cmdlet.ControlType) {
//cmdlet.WriteVerbose(cmdlet, "tempElement3.Current.ControlType.ProgrammaticName.ToUpper().Substring(12) = " + tempElement3.Current.ControlType.ProgrammaticName.ToUpper().Substring(12));
//cmdlet.WriteVerbose(cmdlet, "tempElement3.Current.ControlType.ProgrammaticName.ToUpper().Substring(12).Length = " + tempElement3.Current.ControlType.ProgrammaticName.ToUpper().Substring(12).Length.ToString());
//cmdlet.WriteVerbose(cmdlet, "cmdlet.ControlType.ToUpper() = " + cmdlet.ControlType.ToUpper());
//cmdlet.WriteVerbose(cmdlet, "cmdlet.ControlType.ToUpper().Length = " + cmdlet.ControlType.ToUpper().Length.ToString());
                                        if (!tempElement3.Current.ControlType.ProgrammaticName.ToUpper().Contains(cmdlet.ControlType.ToUpper()) ||
                                            !(tempElement3.Current.ControlType.ProgrammaticName.ToUpper().Substring(12).Length == cmdlet.ControlType.ToUpper().Length)) {
//cmdlet.WriteVerbose(cmdlet, "continue");
                                            continue;
                                        }
                                        //}
                                    }
                                    
                                    
                                        // 20120917
                                        if (null == cmdlet.SearchCriteria || 0 == cmdlet.SearchCriteria.Length) {
                                            aeCtrl.Add(tempElement3);
                                            cmdlet.WriteVerbose(cmdlet, "Win32Search: element added to the result collection");
                                        } else {
                                            cmdlet.WriteVerbose(cmdlet, "Win32Search: checking search criteria");
                                            if (testControlWithAllSearchCriteria(
                                                cmdlet,
                                                cmdlet.SearchCriteria,
                                                tempElement3)) {
                                                cmdlet.WriteVerbose(cmdlet, "Win32Search: the control matches the search criteria");
                                                aeCtrl.Add(tempElement3);
                                                cmdlet.WriteVerbose(cmdlet, "Win32Search: element added to the result collection");
                                            }
                                        }
                                    //}
                                }
                                
                            } // if (! Preferences.DisableWin32Search)
                        } // FindWindowEx
#endregion Win32 search


                    // 20120917
                    //cmdlet.WriteVerbose(cmdlet, "checking aeCtrl ^^^^^^^^^^^^^^");
                    
                    if (null != aeCtrl && aeCtrl.Count > 0) {
                        
                        //cmdlet.WriteVerbose(cmdlet, "breaking the cycle 777777777777777");
                        
                        break;
                    }
                       
                    
                    cmdlet.WriteVerbose(cmdlet, "going to sleep 99999999999");
                    
                    SleepAndRunScriptBlocks(cmdlet);

                    // System.Threading.Thread.Sleep(Preferences.SleepInterval);
                    ////impossible due to inheritance and the absense of scriptblock here
                    // SleepAndRunScriptBlocks(cmdlet);
                    System.DateTime nowDate = System.DateTime.Now;
                    
                    try {
                        WriteVerbose(cmdlet, "control type: '" + 
                                     cmdlet.ControlType + 
                                     "' , name: '" +
                                     cmdlet.Name +
                                     "', automationId: '" +
                                     cmdlet.AutomationId + 
                                     "', class: '" +
                                     cmdlet.Class +                                      
                                     // cmdlet.Title +
                                     "' , seconds: " + 
                                     ((nowDate - startDate).TotalSeconds).ToString());
                    } catch { //(Exception eWriteVerbose) {
                        //WriteVerbose(this, eWriteVerbose.Message);
                    }
                    
                        //}
                    // 20120830
                    if ((nowDate - startDate).TotalSeconds > cmdlet.Timeout / 1000) {
                        
                        // 20120827
                        //if (aeCtrl == null) {
                        // 20120829
                        //if (null == aeCtrl) {
                        if (null == aeCtrl || 0 == aeCtrl.Count) {

                            // 20120830
                            return null;
                        }
                        break;
                    }
                    else{
                        
                        rootElement =
                            System.Windows.Automation.AutomationElement.RootElement;
                        if (processId > 0) {
                        try {
                            System.Windows.Automation.PropertyCondition pIDcondition =
                                new System.Windows.Automation.PropertyCondition(
                                    System.Windows.Automation.AutomationElement.ProcessIdProperty,
                                                processId);
                                //_window =
                                //cmdlet.InputObject =
                                AutomationElement tempElement =
                                    rootElement.FindFirst(System.Windows.Automation.TreeScope.Children,
                                                         pIDcondition);
                                if (tempElement != null && 
                                    (int)tempElement.Current.ProcessId > 0) {
                                    // 20120824
                                    //cmdlet.InputObject = tempElement;
                                    // 20120830
                                    //cmdlet.InputObject[0] = tempElement;
                                    //inputObject = tempElement;
                                } else {

                                    // 20120830
//                                    string errrorDescription0 = 
//                                        "The input control or window has been lost";
//                                    ErrorRecord errNull0 =
//                                        new ErrorRecord(
//                                            new Exception(errrorDescription0),
//                                            "",
//                                            ErrorCategory.ObjectNotFound,
//                                            null);
//                                    errNull0.ErrorDetails = 
//                                        new ErrorDetails(errrorDescription0);
//
//                                    this.WriteError(this, errNull0, true);
                                    
                                    this.WriteError(
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
                            this.WriteVerbose(cmdlet, "failed to get the process Id");
                            // 20120830
                            //return null;
                            // 20120830
//                            string errrorDescription = 
//                                "The input control or window has been lost";
//                            ErrorRecord errNull =
//                                new ErrorRecord(
//                                    new Exception(errrorDescription),
//                                    "",
//                                    ErrorCategory.ObjectNotFound,
//                                    null);
//                            errNull.ErrorDetails = 
//                                new ErrorDetails(errrorDescription);
//
//                            this.WriteError(this, errNull, true);
                            
                            this.WriteError(
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

                // 20120824
                //if (aeCtrl != null && (int)aeCtrl.Current.ProcessId > 0)
                // 20120830
                //if (null != aeCtrl && (int)((AutomationElement)aeCtrl[0]).Current.ProcessId > 0) {
                //{
//                if (null != aeCtrl && 0 < aeCtrl.Count) {
//                    WriteVerbose(cmdlet, aeCtrl);
//                }
//
//                
//                // 20120917
//                if (null == aeCtrl) {
//                    cmdlet.WriteVerbose(cmdlet, "aeCtrl == null");
//                }
//                if (0 == aeCtrl.Count) {
//                    cmdlet.WriteVerbose(cmdlet, "aeCtrl.Count == 0");
//                }
                
                return aeCtrl;
#region commented
            }
            catch (Exception eGetControlException) {
//                ErrorRecord err = 
//                    new ErrorRecord(
//                        new Exception("Failed to get the control"),
//                        "UnableToGetControl",
//                        ErrorCategory.InvalidResult,
//                        aeCtrl);
//                err.ErrorDetails = 
//                    new ErrorDetails(eGetControlException.Message);
//                WriteError(this, err, true);
                
                this.WriteError(
                    cmdlet,
                    "Failed to get the control." +
                    eGetControlException.Message,
                    "UnableToGetControl",
                    ErrorCategory.InvalidResult,
                    true);
                
                return null;
            }
            catch {
                this.WriteError(
                    cmdlet,
                    "Failed to get the control.",
                    "UnableToGetControl",
                    ErrorCategory.InvalidResult,
                    true);
                
                return null;
            }
#endregion commented
        }
        
        protected bool testControlByPropertiesFromDictionary(
            System.Collections.Generic.Dictionary<string, string> dict, 
            AutomationElement elementToWorkWith)
        {
            bool result = false;
            
            foreach (string key in dict.Keys) {

                this.WriteVerbose(this, "Key = " + key + "; Value = " + dict[key].ToString());
                
                // 20120917
                //string keyValue = dict[key].ToUpper();
                
                // 20120917
                string keyValue = dict[key];
                //WildcardOptions options;
                //if (caseSensitive) {
                //    options =
                //        WildcardOptions.Compiled;
                //} else {
                WildcardOptions options =
                    WildcardOptions.IgnoreCase |
                    WildcardOptions.Compiled;
                //}
                
                // 20120917
                //switch (key.ToUpper()) {
                switch (key) {
                    case "ACCELERATORKEY":
                        if ( !(new WildcardPattern(
                                keyValue,
                                options).IsMatch(elementToWorkWith.Current.AcceleratorKey))) {
                        //if (elementToWorkWith.Current.AcceleratorKey.ToUpper() != keyValue) {
                            //WriteObject(this, false);
                            this.WriteVerbose(this, "ACCELERATORKEY failed");
                            return result;
                        }
                        break;
                    case "ACCESSKEY":
                        if ( !(new WildcardPattern(
                                keyValue,
                                options).IsMatch(elementToWorkWith.Current.AccessKey))) {
                        //if (elementToWorkWith.Current.AccessKey.ToUpper() != keyValue) {
                            //WriteObject(this, false);
                            this.WriteVerbose(this, "ACCESSKEY failed");
                            return result;
                        }
                        break;
                    case "AUTOMATIONID":
                        if ( !(new WildcardPattern(
                                keyValue,
                                options).IsMatch(elementToWorkWith.Current.AutomationId))) {
                        //if (elementToWorkWith.Current.AutomationId.ToUpper() != keyValue) {
                            //WriteObject(this, false);
                            this.WriteVerbose(this, "AUTOMATIONID failed");
                            return result;
                        }
                        break;
                    case "CLASS":
                    case "CLASSNAME":
                        if ( !(new WildcardPattern(
                                keyValue,
                                options).IsMatch(elementToWorkWith.Current.ClassName))) {
                        //if (elementToWorkWith.Current.ClassName.ToUpper() != keyValue) {
                            //WriteObject(this, false);
                            this.WriteVerbose(this, "CLASSNAME failed");
                            return result;
                        }
                        break;
                    case "CONTROLTYPE":
                        if ( !(new WildcardPattern(
                                keyValue,
                                options).IsMatch(elementToWorkWith.Current.ControlType.ProgrammaticName.Substring(12)))) {
                        //if (elementToWorkWith.Current.ControlType.ProgrammaticName.Substring(12).ToUpper() != keyValue) {
                            //WriteObject(this, false);
                            this.WriteVerbose(this, "CONTROLTYPE failed");
                            return result;
                        }
                        break;
                    case "FRAMEWORKID":
                        if ( !(new WildcardPattern(
                                keyValue,
                                options).IsMatch(elementToWorkWith.Current.FrameworkId))) {
                        //if (elementToWorkWith.Current.FrameworkId.ToUpper() != keyValue) {
                            //WriteObject(this, false);
                            this.WriteVerbose(this, "FRAMEWORKID failed");
                            return result;
                        }
                        break;
                    case "HASKEYBOARDFOCUS":
                        if ( !(new WildcardPattern(
                                keyValue,
                                options).IsMatch(elementToWorkWith.Current.HasKeyboardFocus.ToString()))) {
                        //if (elementToWorkWith.Current.HasKeyboardFocus.ToString().ToUpper() != keyValue) {
                            //WriteObject(this, false);
                            this.WriteVerbose(this, "HASKEYBOARDFOCUS failed");
                            return result;
                        }
                        break;
                    case "HELPTEXT":
                        if ( !(new WildcardPattern(
                                keyValue,
                                options).IsMatch(elementToWorkWith.Current.HelpText))) {
                        //if (elementToWorkWith.Current.HelpText.ToUpper() != keyValue) {
                            //WriteObject(this, false);
                            this.WriteVerbose(this, "HELPTEXT failed");
                            return result;
                        }
                        break;
                    case "ISCONTENTELEMENT":
                        if ( !(new WildcardPattern(
                                keyValue,
                                options).IsMatch(elementToWorkWith.Current.IsContentElement.ToString()))) {
                        //if (elementToWorkWith.Current.IsContentElement.ToString().ToUpper() != keyValue) {
                            //WriteObject(this, false);
                            this.WriteVerbose(this, "ISCONTENTELEMENT failed");
                            return result;
                        }
                        break;
                    case "ISCONTROLELEMENT":
                        if ( !(new WildcardPattern(
                                keyValue,
                                options).IsMatch(elementToWorkWith.Current.IsControlElement.ToString()))) {
                        //if (elementToWorkWith.Current.IsControlElement.ToString().ToUpper() != keyValue) {
                            //WriteObject(this, false);
                            this.WriteVerbose(this, "ISCONTROLELEMENT failed");
                            return result;
                        }
                        break;
                    case "ISENABLED":
                        if ( !(new WildcardPattern(
                                keyValue,
                                options).IsMatch(elementToWorkWith.Current.IsEnabled.ToString()))) {
                        //if (elementToWorkWith.Current.IsEnabled.ToString().ToUpper() != keyValue) {
                            //WriteObject(this, false);
                            this.WriteVerbose(this, "ISENABLED failed");
                            return result;
                        }
                        break;
                    case "ISKEYBOARDFOCUSABLE":
                        if ( !(new WildcardPattern(
                                keyValue,
                                options).IsMatch(elementToWorkWith.Current.IsKeyboardFocusable.ToString()))) {
                        //if (elementToWorkWith.Current.IsKeyboardFocusable.ToString().ToUpper() != keyValue) {
                            //WriteObject(this, false);
                            this.WriteVerbose(this, "ISKEYBOARDFOCUSABLE failed");
                            return result;
                        }
                        break;
                    case "ISOFFSCREEN":
                        if ( !(new WildcardPattern(
                                keyValue,
                                options).IsMatch(elementToWorkWith.Current.IsOffscreen.ToString()))) {
                        //if (elementToWorkWith.Current.IsOffscreen.ToString().ToUpper() != keyValue) {
                            //WriteObject(this, false);
                            this.WriteVerbose(this, "ISOFFSCREEN failed");
                            return result;
                        }
                        break;
                    case "ISPASSWORD":
                        if ( !(new WildcardPattern(
                                keyValue,
                                options).IsMatch(elementToWorkWith.Current.IsPassword.ToString()))) {
                        //if (elementToWorkWith.Current.IsPassword.ToString().ToUpper() != keyValue) {
                            //WriteObject(this, false);
                            this.WriteVerbose(this, "ISPASSWORD failed");
                            return result;
                        }
                        break;
                    case "ISREQUIREDFORFORM":
                        if ( !(new WildcardPattern(
                                keyValue,
                                options).IsMatch(elementToWorkWith.Current.IsRequiredForForm.ToString()))) {
                        //if (elementToWorkWith.Current.IsRequiredForForm.ToString().ToUpper() != keyValue) {
                            //WriteObject(this, false);
                            this.WriteVerbose(this, "ISREQUIREDFORFORM failed");
                            return result;
                        }
                        break;
                    case "ITEMSTATUS":
                        if ( !(new WildcardPattern(
                                keyValue,
                                options).IsMatch(elementToWorkWith.Current.ItemStatus))) {
                        //if (elementToWorkWith.Current.ItemStatus.ToUpper() != keyValue) {
                            //WriteObject(this, false);
                            this.WriteVerbose(this, "ITEMSTATUS failed");
                            return result;
                        }
                        break;
                    case "ITEMTYPE":
                        if ( !(new WildcardPattern(
                                keyValue,
                                options).IsMatch(elementToWorkWith.Current.ItemType))) {
                        //if (elementToWorkWith.Current.ItemType.ToUpper() != keyValue) {
                            //WriteObject(this, false);
                            this.WriteVerbose(this, "ITEMTYPE failed");
                            return result;
                        }
                        break;
                    case "LABELEDBY":
                        if ( !(new WildcardPattern(
                                keyValue,
                                options).IsMatch(elementToWorkWith.Current.LabeledBy.Current.Name))) {
                        //if (elementToWorkWith.Current.LabeledBy.Current.Name.ToUpper() != keyValue) {
                            //WriteObject(this, false);
                            this.WriteVerbose(this, "LABELEDBY failed");
                            return result;
                        }
                        break;
                    case "LOCALIZEDCONTROLTYPE":
                        if ( !(new WildcardPattern(
                                keyValue,
                                options).IsMatch(elementToWorkWith.Current.LocalizedControlType))) {
                        //if (elementToWorkWith.Current.LocalizedControlType.ToUpper() != keyValue) {
                            //WriteObject(this, false);
                            this.WriteVerbose(this, "LOCALIZEDCONTROLTYPE failed");
                            return result;
                        }
                        break;
                    case "NAME":
                        if ( !(new WildcardPattern(
                                keyValue,
                                options).IsMatch(elementToWorkWith.Current.Name))) {
                        //if (elementToWorkWith.Current.Name.ToUpper() != keyValue) {
                            //WriteObject(this, false);
                            this.WriteVerbose(this, "NAME failed");
                            return result;
                        }
                        break;
                    case "NATIVEWINDOWHANDLE":
                        if ( !(new WildcardPattern(
                                keyValue,
                                options).IsMatch(elementToWorkWith.Current.NativeWindowHandle.ToString()))) {
                        //if (elementToWorkWith.Current.NativeWindowHandle.ToString() != keyValue) {
                            //WriteObject(this, false);
                            this.WriteVerbose(this, "NATIVEWINDOWHANDLE failed");
                            return result;
                        }
                        break;
                    case "ORIENTATION":
                        if ( !(new WildcardPattern(
                                keyValue,
                                options).IsMatch(elementToWorkWith.Current.Orientation.ToString()))) {
                        //if (elementToWorkWith.Current.Orientation.ToString().ToUpper() != keyValue) {
                            //WriteObject(this, false);
                            this.WriteVerbose(this, "ORIENTATION failed");
                            return result;
                        }
                        break;
                    case "PROCESSID":
                        if ( !(new WildcardPattern(
                                keyValue,
                                options).IsMatch(elementToWorkWith.Current.ProcessId.ToString()))) {
                        //if (elementToWorkWith.Current.ProcessId.ToString() != keyValue) {
                            //WriteObject(this, false);
                            this.WriteVerbose(this, "PROCESSID failed");
                            return result;
                        }
                        break;
                    default:
//                        ErrorRecord err = 
//                            new ErrorRecord(new Exception("Wrong AutomationElement parameter is provided: " + key),
//                                            "WrongParameter",
//                                            ErrorCategory.InvalidArgument,
//                                            key);
//                        err.ErrorDetails = 
//                            new ErrorDetails(
//                                "Wrong AutomationElement parameter is provided: " + key);
//                        this.WriteError(this, err, true);
//                        //ThrowTerminatingError(err);
                        this.WriteError(
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
        
//        protected System.Collections.Generic.Dictionary<string, string> convertHashtableToDictionary(
//            Hashtable hashtable)
//        {
//            System.Collections.Generic.Dictionary<string, string> dict = 
//                new System.Collections.Generic.Dictionary<string, string>();
//            
//            this.WriteVerbose(this, hashtable.Keys.Count.ToString());
//            
//            foreach (string key1 in hashtable.Keys) {
//                
//                string keyUpper = key1.ToUpper();
//
//                this.WriteVerbose(this, "found key: " + keyUpper);
//                
//                dict.Add(keyUpper, hashtable[key1].ToString());
//                
//                this.WriteVerbose(this, "added to the dictionary: " +
//                                  keyUpper + " = " + dict[keyUpper].ToString());
//            }
//            
//            return dict;
//        }
        
        protected bool testControlWithAllSearchCriteria(
            GetCmdletBase cmdlet,
            Hashtable[] hashtables,
            AutomationElement element)
        {
            bool result = false;
            
            foreach (Hashtable hashtable in hashtables) {
                
                //cmdlet.WriteVerbose(cmdlet, "hashtable: " + hashtable.Keys);
                
                result = 
                    testControlByPropertiesFromDictionary(
                        this.ConvertHashtableToDictionary(hashtable),
                        element);
                
                if (result) {
                    return result;
                }
                
//                if (! result) {
//                    cmdlet.WriteVerbose(cmdlet, "test of the control has failed");
//                    return result;
//                }
                cmdlet.WriteVerbose(cmdlet, "test of the control has passed");
            }
            
            //result = true;
            return result;
        }
        #endregion Get-UIAControl
        
        // 20120816
//        #region Event delegate
//        private void runSBEvent(ScriptBlock sb, 
//                                AutomationElement src,
//                                AutomationEventArgs e)
//        {
//            
//            // inform the Wait-UIAEventRaised cmdlet
//            try {
//                CurrentData.LastEventSource = src; // as AutomationElement;
//                CurrentData.LastEventArgs = e; // as AutomationEventArgs;
//                CurrentData.LastEventType = e.EventId.ProgrammaticName;
//                CurrentData.LastEventInfoAdded = true;
//            }
//            catch {
//                //WriteVerbose(this, "failed to register an event in the collection");
//            }
//            
//            // 20120206 Collection<PSObject >  psObjects = null;
//            try {
//                System.Management.Automation.Runspaces.Runspace.DefaultRunspace =
//                    RunspaceFactory.CreateRunspace();
//                try {
//                    System.Management.Automation.Runspaces.Runspace.DefaultRunspace.Open();
//                } catch (Exception e1) {
//                    ErrorRecord err = 
//                        new ErrorRecord(e1,
//                                        "ErrorOnOpeningRunspace",
//                                        ErrorCategory.InvalidOperation,
//                                        sb);
//                    err.ErrorDetails = 
//                        new ErrorDetails(
//                            "Unable to run a scriptblock:\r\n" + 
//                            sb.ToString());
//                    WriteError(this, err, false);
//                }
//                try {
//                    System.Collections.Generic.List<object >  inputParams = 
//                        new System.Collections.Generic.List<object > ();
//                    inputParams.Add(src);
//                    inputParams.Add(e);
//                    object[] inputParamsArray = inputParams.ToArray();
//                    // psObjects = 
//                        sb.InvokeReturnAsIs(inputParamsArray);
//                        // sb.Invoke(inputParamsArray);
//                    
//                } catch (Exception e2) {
//                    ErrorRecord err = 
//                        new ErrorRecord(e2,
//                                        "ErrorInOpenedRunspace",
//                                        ErrorCategory.InvalidOperation,
//                                        sb);
//                    err.ErrorDetails = 
//                        new ErrorDetails("Unable to run a scriptblock");
//                    WriteError(this, err, true);
//                }
//// psObjects =
//// sb.Invoke();
//            } catch (Exception eOuter) {
//                ErrorRecord err = 
//                    new ErrorRecord(eOuter,
//                                    "ErrorInInvokingScriptBlock", //"ErrorinCreatingRunspace",
//                                    ErrorCategory.InvalidOperation,
//                                    System.Management.Automation.Runspaces.Runspace.DefaultRunspace);
//                err.ErrorDetails = 
//                    new ErrorDetails("Unable to issue the following command:\r\n" + 
//                                     "System.Management.Automation.Runspaces.Runspace.DefaultRunspace = RunspaceFactory.CreateRunspace();" +
//                                     "\r\nException raised is\r\n" +
//                                     eOuter.Message);
//            }
//        }
//        #endregion Event delegate
        
        // 20120816
//        #region Action delegate
//        private void runSBAction(ScriptBlock sb, 
//                                 AutomationElement src,
//                                 AutomationEventArgs e)
//        {
//            Collection<PSObject >  psObjects = null;
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
//                ErrorRecord err = 
//                    new ErrorRecord(eOuter,
//                                    "ErrorInInvokingScriptBlock",
//                                    ErrorCategory.InvalidOperation,
//                                    System.Management.Automation.Runspaces.Runspace.DefaultRunspace);
//                err.ErrorDetails = 
//                    new ErrorDetails(
//                        "Unable to issue the following command:\r\n" +
//                        sb.ToString() + 
//                        "\r\nThe exception raised is\r\n" + 
//                        eOuter.Message);
//                                     //"System.Management.Automation.Runspaces.Runspace.DefaultRunspace = RunspaceFactory.CreateRunspace();");
//                WriteError(err);
//            }
//        }
//        #endregion Action delegate
    
    }
    // 20120816
//    #region Action delegate
//    delegate void runScriptBlock(ScriptBlock sb, 
//                                 AutomationElement src, 
//                                 AutomationEventArgs e);
//    #endregion Action delegate
}
