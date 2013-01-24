/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/18/2012
 * Time: 8:12 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSX
{
    using System;
    using System.Management.Automation;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Firefox;
    using OpenQA.Selenium.IE;
    using OpenQA.Selenium.Remote;
    
    using PSTestLib;
    
    using System.IO;
    
    using System.Collections.ObjectModel;
    using System.Windows.Automation;
    using UIAutomation;
    
    /// <summary>
    /// Description of CommonCmdletBase.
    /// </summary>
    public class CommonCmdletBase : PSCmdletBase//, ICommonCmdletBase
    {
        
#region commented
//        public CommonCmdletBase()
//        {
//            if (null == UnitTestOutput) {
//                UnitTestOutput =
//                    new System.Collections.Generic.List<object>();
//            }
//            
//            
//            // ??
//            if (!this.UnitTest) {
//Console.WriteLine("the standard module");
//                WebDriverFactory.AutofacModule = new WebDriverModule();
//                WebDriverFactory.Init();
//                //CurrentData.Init();
//            }
//            
//            CurrentData.Init();
//        }
#endregion commented
        
        public CommonCmdletBase()
        {
//            if (null == UnitTestOutput) {
//                UnitTestOutput =
//                    new System.Collections.Generic.List<object>();
//            }
            
            // ??
            if (!UnitTestMode && !ModuleAlreadyLoaded) {

                WebDriverFactory.AutofacModule = new WebDriverModule();

                WebDriverFactory.Init();

                ModuleAlreadyLoaded = true;
            }
            
            CurrentData.Init();
        }
        
//        internal static new bool UnitTestMode { get; set; }
        internal static bool ModuleAlreadyLoaded { get; set; }
//        internal static System.Collections.Generic.List<object> UnitTestOutput { get; set; }
        
        private const string exceptionMessageNull = 
            "The pipeline input is null";
        private const string exceptionMessageWrongTypeWebDriver = 
            "The pipeline input is not of IWebDriver type";
        private const string exceptionMessageWrongTypeWebElement = 
            "The pipeline input is not of IWebElement type";
        private const string exceptionMessageWrongTypeWebDriverOrWebElement = 
            "The pipeline input is null or not of IWebDriver or IWebElement type";
        
        protected override void WriteLog(string logRecord)
        {
            try {
                //Global.WriteToLogFile(record);
                //WriteToLogFile(record);
                WriteToLogFile(logRecord);
            } catch (Exception e) {
                this.WriteVerbose(this, "Unable to write to the log file: " +
                             Preferences.LogPath);
                this.WriteVerbose(this, e.Message);
            }
        }
        
        protected void checkInputWebDriver(bool strict)
        {
            if (null == ((HasWebDriverInputCmdletBase)this).InputObject) {
                this.WriteError(
                    this,
                    exceptionMessageNull,
                    "WrongInput",
                    ErrorCategory.InvalidArgument,
                    true);
            } else {
                if (strict) {
                    if (!(((HasWebDriverInputCmdletBase)this).InputObject is IWebDriver[])) {
                        this.WriteError(
                            this,
                            exceptionMessageWrongTypeWebDriver,
                            "WrongInput",
                            ErrorCategory.InvalidArgument,
                            true);
                    }
                }
                this.WriteVerbose(this, "The pipeline input is good");
            }
        }
        
#region commented
//        protected void checkInputWebElement(bool strict)
//        {
//            WriteVerbose(this, "Check input as for HasWebElementInputCmdletBase");
//            testInputObject((this as HasWebElementInputCmdletBase), strict);
//            WriteVerbose(this, "Check input as for WebElementCmdletBase");
//            testInputObject((this as WebElementCmdletBase), strict);
//        }
        
//        private void testInputObject(CommonCmdletBase cmdlet, bool strict)
//        {
//            if (cmdlet == null) {
//                WriteVerbose(this, "the cmdlet was not of expected type");
//                return;
//            }
//            
//            ErrorRecord errNull = null;
//            ErrorRecord errWrongType = null;
//            try {
//                if (((HasWebElementInputCmdletBase)cmdlet) != null &&
//                    ((HasWebElementInputCmdletBase)cmdlet).InputObject == null) {
//                    errNull = 
//                        new ErrorRecord(
//                            new Exception(exceptionMessageNull),
//                            "WrongInput",
//                            ErrorCategory.InvalidArgument,
//                            ((HasWebElementInputCmdletBase)this).InputObject);
//                    errNull.ErrorDetails = 
//                        new ErrorDetails(exceptionMessageNull);
//                    //ThrowTerminatingError(errNull);
//                    WriteError(this, errNull, true);
//                } else {
//                    if (strict) {
//                        if (((HasWebElementInputCmdletBase)cmdlet) != null &&
//                             ! (((PSObject)((HasWebElementInputCmdletBase)this).InputObject).BaseObject is IWebElement)) {
//                            errWrongType = 
//                                new ErrorRecord(
//                                    new Exception(exceptionMessageWrongTypeWebElement),
//                                    "WrongInput",
//                                    ErrorCategory.InvalidArgument,
//                                    ((HasWebElementInputCmdletBase)this).InputObject);
//                            errWrongType.ErrorDetails = 
//                                new ErrorDetails(exceptionMessageWrongTypeWebElement);
//                            //ThrowTerminatingError(errWrongType);
//                            WriteError(this, errWrongType, true);
//                        }
//                    }
//                    WriteVerbose(this, "The pipeline input is good");
//                }
//            }
//            catch {}
//            try {
//                if (((WebElementCmdletBase)cmdlet) != null &&
//                    ((WebElementCmdletBase)cmdlet).InputObject == null) {
//                    errNull = 
//                        new ErrorRecord(
//                            new Exception(exceptionMessageNull),
//                            "WrongInput",
//                            ErrorCategory.InvalidArgument,
//                            ((WebElementCmdletBase)this).InputObject);
//                    errNull.ErrorDetails = 
//                        new ErrorDetails(exceptionMessageNull);
//                    //ThrowTerminatingError(errNull);
//                    WriteError(this, errNull, true);
//                } else {
//                    if (strict) {
//                        if (((WebElementCmdletBase)cmdlet) != null &&
//                             ! (((PSObject)((WebElementCmdletBase)this).InputObject).BaseObject is IWebElement)) {
//                            errWrongType = 
//                                new ErrorRecord(
//                                    new Exception(exceptionMessageWrongTypeWebElement),
//                                    "WrongInput",
//                                    ErrorCategory.InvalidArgument,
//                                    ((WebElementCmdletBase)this).InputObject);
//                            errWrongType.ErrorDetails = 
//                                new ErrorDetails(exceptionMessageWrongTypeWebElement);
//                            //ThrowTerminatingError(errWrongType);
//                            WriteError(this, errWrongType, true);
//                        }
//                    }
//                    WriteVerbose(this, "The pipeline input is good");
//                }
//            }
//            catch {}
//        }
#endregion commented
        
        protected void checkInputWebDriverOrWebElement()
        {
            IWebDriver[] driver = null;
            System.Collections.Generic.List<IWebDriver> driverList = 
                new System.Collections.Generic.List<IWebDriver>();
            IWebElement[] element = null;
            System.Collections.Generic.List<IWebElement> elementList = 
                new System.Collections.Generic.List<IWebElement>();
            //foreach(object inputObject in ((HasWebElementInputCmdletBase)this).InputObject) {
                try {
                    this.WriteVerbose(this, "Checking whether the input is of WebDriver type");
                    var driverTest = 
                        ((HasWebElementInputCmdletBase)this).InputObject as IWebDriver[];
                    if (null != driverTest) {
                        this.WriteVerbose(this, "input is IWebDriver");
                        driver = (IWebDriver[])driverTest;
                    } else {
                        this.WriteVerbose(this, "input is PSObject");
//                        driver = 
//                            ((PSObject[])((HasWebElementInputCmdletBase)this).InputObject).BaseObject as IWebDriver[];
                        for (int i = 0; i < ((HasWebElementInputCmdletBase)this).InputObject.Length; i++) {
                            //driver[i] = 
                            var rawInputItemDriver = 
                                ((HasWebElementInputCmdletBase)this).InputObject[i];
                            if (rawInputItemDriver is IWebDriver) {
                                driverList.Add((rawInputItemDriver as IWebDriver));
                            } else {
                                driverList.Add((((PSObject)rawInputItemDriver).BaseObject as IWebDriver));
                            }
//                            driverList.Add(
//                                ((PSObject)((HasWebElementInputCmdletBase)this).InputObject[i]).BaseObject as IWebDriver
//                               );
                        }
                    }
                    //if (driver == null) {
                    if (driverList.Count == 0) {
                        throw (new Exception("The input object is not of IWebDriver type"));
                    }
                    //driver =
                    //    //((PSObject)((HasWebElementInputCmdletBase)this).InputObject).BaseObject as IWebDriver;
                    //    ((HasWebElementInputCmdletBase)this).InputObject as IWebDriver;
                    this.WriteVerbose(this, "The pipeline input is of WebDriver type");
                    //if (driver != null) {
                    if (driverList.Count > 0) {
                        this.WriteVerbose(this, "set InputObject");
                        //((HasWebElementInputCmdletBase)this).InputObject[0] = driver;
                        for (int i = 0; i < driverList.Count; i++) {
                            ((HasWebElementInputCmdletBase)this).InputObject[i] =
                                driverList[i];
                        }
                    }
                    //((HasWebElementInputCmdletBase)this).InputObject =
                    //    ((HasWebElementInputCmdletBase)this).InputObject as IWebDriver;
                 }
                catch (Exception eNotWebDriver) {
                    this.WriteVerbose(this, "The pipeline input is not of WebDriver type");
                    this.WriteVerbose(this, eNotWebDriver.Message);
                    try {
                        this.WriteVerbose(this, "Checking whether the input is of WebElement type");
                        var elementTest = 
                            ((HasWebElementInputCmdletBase)this).InputObject as IWebElement[];
                        if (elementTest != null) {
                            this.WriteVerbose(this, "input is IWebElement");
                            element = elementTest;
                        } else {
                            this.WriteVerbose(this, "input is PSObject");
//                            element =
//                                ((PSObject[])((HasWebElementInputCmdletBase)this).InputObject).BaseObject as IWebElement[];
                            for (int i = 0; i < ((HasWebElementInputCmdletBase)this).InputObject.Length; i++) {
                                //element[i] = 
//                                elementList.Add(
//                                    ((PSObject)((HasWebElementInputCmdletBase)this).InputObject[i]).BaseObject as IWebElement);
                                var rawInputItemElement = 
                                    ((HasWebElementInputCmdletBase)this).InputObject[i];
                                if (rawInputItemElement is IWebElement) {
                                    elementList.Add((rawInputItemElement as IWebElement));
                                } else {
                                    elementList.Add((((PSObject)rawInputItemElement).BaseObject as IWebElement));
                                }
                            }
                        }
                        //if (element == null) {
                        if (0 == elementList.Count) {
                            throw (new Exception("The input object is not of IWebElement type"));
                        }
                        //element = 
                        //    //((PSObject)((HasWebElementInputCmdletBase)this).InputObject).BaseObject as IWebElement;
                        //    ((HasWebElementInputCmdletBase)this).InputObject as IWebElement;
                        this.WriteVerbose(this, "The pipeline input is of WebElement type");
                        //if (element != null) {
                        if (elementList.Count > 0) {
                            this.WriteVerbose(this, "set InputObject");
                            //((HasWebElementInputCmdletBase)this).InputObject = element;
                            for (int i = 0; i < elementList.Count; i++) {
                                ((HasWebElementInputCmdletBase)this).InputObject[i] =
                                    elementList[i];
                            }
                        }
                        //((HasWebElementInputCmdletBase)this).InputObject = 
                        //    ((HasWebElementInputCmdletBase)this).InputObject as IWebElement;
                    }
                    catch (Exception eNotWebElement) {
                        this.WriteVerbose(this, "The pipeline input is not of WebElement type");
                        this.WriteVerbose(this, eNotWebElement.Message);
                        this.WriteError(
                            this,
                            exceptionMessageWrongTypeWebDriverOrWebElement,
                            "WrongInput",
                            ErrorCategory.InvalidArgument,
                            true);
                    }
                }
            //}
        }
        
        protected void checkInputWebElementOnly(IWebElement[] input)
        {
            try {
                if (!(input is IWebElement[])) {
                    throw (new Exception("The pipeline input is not of WebElement type"));
                }
            }
            catch (Exception eNotWebElement) {
                this.WriteVerbose(this, "The pipeline input is not of WebElement type");
                this.WriteVerbose(this, eNotWebElement.Message);
                this.WriteError(
                    this,
                    exceptionMessageWrongTypeWebDriverOrWebElement,
                    "WrongInput",
                    ErrorCategory.InvalidArgument,
                    true);
            }
        }
        
        protected void checkInputWebElementOnly(object[] input)
            //HasWebElementInputCmdletBase cmdlet)
        {
            //IWebDriver driver = null;
            IWebElement[] element = null; // = new IWebElement[]; //null;
            System.Collections.Generic.List<IWebElement> elementList = 
                new System.Collections.Generic.List<IWebElement>();
            
#region commented
//            try {
//                WriteVerbose(this, "Checking whether the input is of WebDriver type");
//                var driverTest = 
//                    ((HasWebElementInputCmdletBase)this).InputObject as IWebDriver;
//                if (driverTest != null) {
//                    WriteVerbose(this, "driver is IWebDriver");
//                    driver = driverTest;
//                } else {
//                    WriteVerbose(this, "driver is PSObject");
//                    driver = 
//                        ((PSObject)((HasWebElementInputCmdletBase)this).InputObject).BaseObject as IWebDriver;
//                }
//                if (driver == null) {
//                    throw(new Exception("The input object is not of IWebDriver type"));
//                }
//                //driver =
//                //    //((PSObject)((HasWebElementInputCmdletBase)this).InputObject).BaseObject as IWebDriver;
//                //    ((HasWebElementInputCmdletBase)this).InputObject as IWebDriver;
//                WriteVerbose(this, "The pipeline input is of WebDriver type");
//                if (driver != null) {
//                    WriteVerbose(this, "set InputObject");
//                    ((HasWebElementInputCmdletBase)this).InputObject = driver;
//                }
//                //((HasWebElementInputCmdletBase)this).InputObject =
//                //    ((HasWebElementInputCmdletBase)this).InputObject as IWebDriver;
//             }
//            catch (Exception eNotWebDriver) {
//                WriteVerbose(this, "The pipeline input is not of WebDriver type");
//                WriteVerbose(this, eNotWebDriver.Message);
#endregion commented

                try {
                    this.WriteVerbose(this, "Checking whether the input is of WebElement type");
                    var elementTest = 
                        //((HasWebElementInputCmdletBase)this).InputObject as IWebElement;
                        //input as IWebElement[];
                        ((HasWebElementInputCmdletBase)this).InputObject as IWebElement[];
                    if (null != elementTest) {
                        this.WriteVerbose(this, "input is IWebElement");
                        element = elementTest;
                    } else {
                        this.WriteVerbose(this, "input is PSObject");
                        
#region commented
//                        element =
//                            //((PSObject)((HasWebElementInputCmdletBase)this).InputObject).BaseObject as IWebElement;
//                            (((PSObject[])input).BaseObject) as IWebElement[];
                        //foreach(object inputObject in input) {
//                        for (int i = 0; i < input.Length; i++) {
//                            element[i] = ((PSObject)input[i]).BaseObject as IWebElement;
//                        }
#endregion commented
                        
                        for (int i = 0; i < ((HasWebElementInputCmdletBase)this).InputObject.Length; i++) {
                            //element[i] = 
//                                elementList.Add(
//                                    ((PSObject)((HasWebElementInputCmdletBase)this).InputObject[i]).BaseObject as IWebElement);
                            var rawInputItemElement = 
                                ((HasWebElementInputCmdletBase)this).InputObject[i];
                            if (rawInputItemElement is IWebElement) {
                                elementList.Add((rawInputItemElement as IWebElement));
                            } else {
                                elementList.Add((((PSObject)rawInputItemElement).BaseObject as IWebElement));
                            }
                        }
                        
                    }
                    //if (element == null) {
                    if (0 == elementList.Count) {
                        throw (new Exception("The input object is not of IWebElement type"));
                    }
                    //element = 
                    //    //((PSObject)((HasWebElementInputCmdletBase)this).InputObject).BaseObject as IWebElement;
                    //    ((HasWebElementInputCmdletBase)this).InputObject as IWebElement;
                    this.WriteVerbose(this, "The pipeline input is of WebElement type");
                    //if (element != null) {
                    if (elementList.Count > 0) {
                        this.WriteVerbose(this, "set InputObject");
                        //((HasWebElementInputCmdletBase)this).InputObject = element;
                        //cmdlet.InputObject = element;
                        for (int i = 0; i < elementList.Count; i++) {
                            ((HasWebElementInputCmdletBase)this).InputObject[i] =
                                (IWebElement)elementList[i];
                        }
                    }
                    //((HasWebElementInputCmdletBase)this).InputObject = 
                    //    ((HasWebElementInputCmdletBase)this).InputObject as IWebElement;
                }
                catch (Exception eNotWebElement) {
                    this.WriteVerbose(this, "The pipeline input is not of WebElement type");
                    this.WriteVerbose(this, eNotWebElement.Message);
                    this.WriteError(
                        this,
                        exceptionMessageWrongTypeWebDriverOrWebElement,
                        "WrongInput",
                        ErrorCategory.InvalidArgument,
                        true);
                }
//            }
        }

        
        protected void checkInputAlert(bool strict)
        {
            if (null == ((AlertCmdletBase)this).InputObject) {

                this.WriteError(
                    this,
                    "The alert is null.",
                    "WrongInput",
                    ErrorCategory.InvalidArgument,
                    true);
            } else {
                if (strict) {
                    if (!(((AlertCmdletBase)this).InputObject is IAlert)) {

                        this.WriteError(
                            this,
                            "The alert is null.",
                            "WrongInput",
                            ErrorCategory.InvalidArgument,
                            true);
                    }
                }
                this.WriteVerbose(this, "The pipeline input is good");
            }
        }
        
        protected void checkInputFirefoxProfile(bool strict)
        {
            if (null == ((EditFirefoxProfileCmdletBase)this).InputObject) {

                this.WriteError(
                    this,
                    "The input Firefox profile object is null.",
                    "WrongInput",
                    ErrorCategory.InvalidArgument,
                    true);
            } else {
                if (strict) {
                    if (!(((EditFirefoxProfileCmdletBase)this).InputObject is FirefoxProfile)) {

                        this.WriteError(
                            this,
                            "The input Firefox profile object is null.",
                            "WrongInput",
                            ErrorCategory.InvalidArgument,
                            true);
                    }
                }
                this.WriteVerbose(this, "The pipeline input is good");
            }
        }
        
        protected void checkInputChromeOptions(bool strict)
        {
            if (null == ((EditChromeOptionsCmdletBase)this).InputObject) {

                this.WriteError(
                    this,
                    "The input Chrome options object is null.",
                    "WrongInput",
                    ErrorCategory.InvalidArgument,
                    true);
            } else {
                if (strict) {
                    if (!(((EditChromeOptionsCmdletBase)this).InputObject is ChromeOptions)) {

                        this.WriteError(
                            this,
                            "The input Chrome options object is null.",
                            "WrongInput",
                            ErrorCategory.InvalidArgument,
                            true);
                    }
                }
                this.WriteVerbose(this, "The pipeline input is good");
            }
        }
        
        protected void checkInputInternetExplorerOptions(bool strict)
        {
            if (null == ((EditIEOptionsCmdletBase)this).InputObject) {

                this.WriteError(
                    this,
                    "The input Internet Explorer options object is null.",
                    "WrongInput",
                    ErrorCategory.InvalidArgument,
                    true);
            } else {
                if (strict) {
                    if (!(((EditIEOptionsCmdletBase)this).InputObject is InternetExplorerOptions)) {

                        this.WriteError(
                            this,
                            "The input Internet Explorer options object is null.",
                            "WrongInput",
                            ErrorCategory.InvalidArgument,
                            true);
                    }
                }
                this.WriteVerbose(this, "The pipeline input is good");
            }
        }
        
#region commented
//        protected internal void WriteObject(CommonCmdletBase cmdlet, object obj)
//        {
//            try{
//                // Global.
//                // UIAHelper.Highlight(obj);
////                AutomationElement element = null;
////                if (cmdlet != null && !(cmdlet is WizardCmdletBase)) {
////                    //AutomationElement element = null;
////                //  //  //if (cmdlet != null && !(cmdlet is WizardCmdletBase)) {
////                    try {
////                        //AutomationElement elt = obj as AutomationElement;
////                        element = obj as AutomationElement;
////                        if (element is AutomationElement &&
////                            (int)element.Current.ProcessId > 0) {
////                            // 20120222
////                            WriteVerbose(this, "current cmdlet: " + this.GetType().Name);
////                            // 
////                            WriteVerbose(this, "highlighting the following element:");
////                            WriteVerbose(this, "Name = " + element.Current.Name);
////                            WriteVerbose(this, "AutomationId = " + element.Current.AutomationId);
////                            WriteVerbose(this, "ControlType = " + element.Current.ControlType.ProgrammaticName);
////                            WriteVerbose(this, "X = " + element.Current.BoundingRectangle.X.ToString());
////                            WriteVerbose(this, "Y = " + element.Current.BoundingRectangle.Y.ToString());
////                            WriteVerbose(this, "Width = " + element.Current.BoundingRectangle.Width.ToString());
////                            WriteVerbose(this, "Height = " + element.Current.BoundingRectangle.Height.ToString());
////                        }
////                    } catch { //(Exception eee) {
////                        // nothing to do
////                        // just failed to highlight
////                    }
////                //  // 
////                if (element != null && element is AutomationElement &&
////                        (int)element.Current.ProcessId > 0) {
////                        WriteVerbose(this, "as it is an AutomationElement, it should be highlighted");
////                        if (Preferences.Highlight || ((HasScriptBlockCmdletBase)cmdlet).Highlight) {
////                            //WriteVerbose(this, "run Highlighter");
////                            try {
////                                //AutomationElement element = 
////                                //element =
////                                // obj as AutomationElement;
////                                WriteVerbose(this, "run Highlighter");
////                                UIAHelper.Highlight(element); //, Highlighters.Element);
////                                WriteVerbose(this, "after running the Highlighter");
////                            } catch (Exception ee) {
////                                WriteVerbose(this, "unable to highlight: " + ee.Message);
////                                WriteVerbose(this, obj.ToString());
////                            }
////            // try { UIAHelper.Highlight(obj); } catch (Exception ee) {
////            // WriteVerbose(this, "unable to highlight: " + ee.Message);
////            // }
////                        }
////                    }
////                }
//                
////                WriteVerbose(this, "is going to run scriptblocks");
////                if (cmdlet != null) {
////                    // run scriptblocks
////                    if (cmdlet is HasScriptBlockCmdletBase) {
////                        // if (obj == null || (obj is bool && ((bool)obj) == false)) {
////                        WriteVerbose(this, "cmdlet is of the HasScriptBlockCmdletBase type");
////                        if (obj == null) {
////                            WriteVerbose(this, "run OnError script blocks (null)");
////                            RunOnErrorScriptBlocks(((HasScriptBlockCmdletBase)cmdlet));
////                        } else if (obj is bool && ((bool)obj) == false) {
////                            WriteVerbose(this, "run OnError script blocks (false)");
////                            RunOnErrorScriptBlocks(((HasScriptBlockCmdletBase)cmdlet));
////                        } else if (obj != null) {
////                            WriteVerbose(this, "run OnSuccess script blocks");
////                            RunOnSuccessScriptBlocks(((HasScriptBlockCmdletBase)cmdlet));
////                        }
////                    }
////                    try {
////                        CurrentData.LastResult = obj;
////                        string iInfo = string.Empty;
////                        if (((HasScriptBlockCmdletBase)cmdlet).TestResultName != null &&
////                            ((HasScriptBlockCmdletBase)cmdlet).TestResultName.Length > 0) {
////
////                            //string iInfo = string.Empty;
//////                            if (((HasScriptBlockCmdletBase)cmdlet).TestLog){
//////                                iInfo = TMX.TMXHelper.GetInvocationInfo(this.MyInvocation);
//////                            }
////                            TMX.TMXHelper.CloseTestResult(((HasScriptBlockCmdletBase)cmdlet).TestResultName,
////                                                          ((HasScriptBlockCmdletBase)cmdlet).TestResultId,
////                                                          ((HasScriptBlockCmdletBase)cmdlet).TestPassed,
////                                                          false, // isKnownIssue
////                                                          this.MyInvocation,
////                                                          null, // Error
////                                                          string.Empty,
////                                                          false);
////                                                          //((HasScriptBlockCmdletBase)cmdlet).TestLog);
////                        } else {
////                            if (Preferences.EveryCmdletAsTestResult) {
////                                
////                                
////                                
////                                ((HasScriptBlockCmdletBase)cmdlet).TestResultName = 
////                                    getGeneratedTestResultNameByPosition(
////                                        this.MyInvocation.Line,
////                                        this.MyInvocation.PipelinePosition);
//////                                    this.MyInvocation.Line + 
//////                                    ", position: " +
//////                                    this.MyInvocation.PipelinePosition.ToString();
////                                ((HasScriptBlockCmdletBase)cmdlet).TestResultId = string.Empty;
////                                ((HasScriptBlockCmdletBase)cmdlet).TestPassed = true;
//////                                iInfo = TMX.TMXHelper.GetInvocationInfo(this.MyInvocation);
////
////                                TMX.TMXHelper.CloseTestResult(((HasScriptBlockCmdletBase)cmdlet).TestResultName,
////                                                              string.Empty, //((HasScriptBlockCmdletBase)cmdlet).TestResultId, // empty, to be generated
////                                                              ((HasScriptBlockCmdletBase)cmdlet).TestPassed,
////                                                              false, // isKnownIssue
////                                                              this.MyInvocation,
////                                                              null, // Error
////                                                              string.Empty,
////                                                              true);
////                            }
////                        }
////                    }
////                    catch (Exception eeee) {
//////WriteVerbose(this, eeee.Message);
////                        WriteVerbose(this, "for working with test results you need to import the TMX module");
////                    }
////
////
////                    // remove the Turbo timeout
////                    if ((cmdlet as HasTimeoutCmdletBase) != null) {
////                        
////                        // 20120706
////                        if ((CurrentData.CurrentWindow != null &&
////                             CurrentData.LastResult != null) ||
////                             (obj as AutomationElement) != null) {
////                            if (Preferences.StoredDefaultTimeout != 0) {
////                                if (! Preferences.TimeoutSetByCustomer) {
////                                    Preferences.Timeout = Preferences.StoredDefaultTimeout;
////                                    Preferences.StoredDefaultTimeout = 0;
////                                }
////                            }
////                        }
////                    }
////
////
////                }
////                WriteVerbose(this, "sleeping if sleep time is provided");
////                System.Threading.Thread.Sleep(Preferences.OnSuccessDelay);
////                //if (cmdlet != null && !(cmdlet is WizardCmdletBase)) try { WriteObject(obj);
////                WriteVerbose(this, "outputting the result object");
////                if (cmdlet != null) {
////                    try { 
////                        element = obj as AutomationElement;
////                        WriteVerbose(this, "getting the element again to ensure that it still exists");
////                        WriteVerbose(this, (element as AutomationElement).ToString());
////                        if (!(cmdlet is WizardCmdletBase) &&
////                            (element is AutomationElement)){
////                            WriteVerbose(this, "returning the object");
////                            WriteObject(obj);
////                        } else if ((cmdlet is WizardCmdletBase)) {
////                            WriteVerbose(this, "returning the wizard or step");
////                            WriteObject(obj);
////                        } else {
////                            WriteVerbose(this, "returning true");
////                            WriteObject(true);
////                        }
////                    } catch { // (Exception eeeee) {
////                        // test
////                        WriteVerbose(this, "failed to issue the result object of AutomationElement type");
////                        WriteVerbose(this, "returning as is");
////                        WriteObject(obj);
////                    }
////                }
//
//
//#region new 20120722
////                WriteVerbose(this, "outputting the result object");
////WriteVerbose(this, "before");
//                if (cmdlet != null) {
////WriteVerbose(this, cmdlet.GetType().Name);
////WriteVerbose(this, "in");
//                    try { 
////                        element = obj as AutomationElement;
////                        WriteVerbose(this, "getting the element again to ensure that it still exists");
////                        WriteVerbose(this, (element as AutomationElement).ToString());
////                        if (!(cmdlet is WizardCmdletBase) &&
////                            (element is AutomationElement)){
//////                            WriteVerbose(this, "returning the object");
////                            WriteObject(obj);
////                        } else if ((cmdlet is WizardCmdletBase)) {
//////                            WriteVerbose(this, "returning the wizard or step");
////                            WriteObject(obj);
////                        } else {
//////                            WriteVerbose(this, "returning true");
////                            WriteObject(true);
////                        }
////WriteVerbose(this, "in 2");
////                        if (cmdlet is HasWebDriverInputCmdletBase ||
////                            cmdlet is WebElementCmdletBase ||
////                            cmdlet is DriverCmdletBase) {
////WriteVerbose(this, "in 3 ?");
//                            //SeHelper.
//                            if (obj is IWebDriver ||
//                                obj is IWebElement) {
//                                
//WriteVerbose(this, "IWebDriver or IWebElement");
//
//                                if (Preferences.Highlight && obj is IWebElement) {
////WriteVerbose(this, "IWebDriver or IWebElement");
//WriteVerbose(this, "Highlighting");
//WriteVerbose(this, obj.GetType().Name);
//WriteVerbose(this, ((IWebElement)obj).GetType().Name);
//
//                                    SeHelper.Highlight((IWebElement)obj);
//                                }
//
//                                WriteObject(obj);
//                            } else {
//WriteVerbose(this, "anything else");
//                                WriteObject(obj);
//                            }
//                            
//                            
//                            
////                        }
//                        
//                    } catch (Exception eeeee) {
//                        // test
////                        WriteVerbose(this, "failed to issue the result object of AutomationElement type");
////                        WriteVerbose(this, "returning as is");
//WriteVerbose(this, eeeee.Message);
//WriteVerbose(this, "returning as is");
//                        WriteObject(obj);
//                    }
//                }
//#endregion new 20120722
//
//
//
////                string reportString =
////                    CmdletSignature(cmdlet) +  
////                    obj.ToString();
////                
////                // 20120206 try { WriteVerbose(this, reportString); } catch { }
////                if (cmdlet != null && reportString != null && reportString != string.Empty) { //try { WriteVerbose(this, reportString);
////                    WriteVerbose(this, reportString);
////                
////                //} catch { }
////                } 
////                //catch (Exception eeeeee) {
////                //}
////                WriteVerbose(this, "writing into the log");
////                WriteLog(reportString);
////                WriteVerbose(this, "the log record has been written");
//            }
//            catch {}
//        }
#endregion commented
        
        public virtual void WriteObject(PSCmdletBase cmdlet, ReadOnlyCollection<IWebElement> outputObjectCollection)
        {
            for (int i = 0; i < outputObjectCollection.Count; i++) {
                WriteObject(cmdlet, outputObjectCollection[i]);
            }
        }
        
        protected override bool WriteObjectMethod010CheckOutputObject(object outputObject)
        {
            bool result = false;
                
            if (outputObject != null) {
                result = true;
            }
            return result;
        }
        
        protected override void WriteObjectMethod020Highlight(PSCmdletBase cmdlet, object outputObject)
        {
            this.WriteVerbose(this, "IWebDriver or IWebElement");
//Console.WriteLine("highlight 0000001");
            if (Preferences.Highlight && outputObject is IWebElement) {
//Console.WriteLine("highlight 0000002");
                this.WriteVerbose(this, "Highlighting");
//Console.WriteLine("WriteObjectMethod020Highlight: 00001");
                this.WriteVerbose(this, outputObject.GetType().Name);
//Console.WriteLine("highlight 0000003");
//Console.WriteLine("WriteObjectMethod020Highlight: 00002");
//Console.WriteLine("outputObject = " + outputObject.GetType().Name);
//Console.WriteLine("outputObject as RemoteWebElement = " + (outputObject as RemoteWebElement));
//Console.WriteLine("outputObject as WebElementDecorator = " + (outputObject as WebElementDecorator));
//try {
//    Console.WriteLine("Coordinates of RemoteWebElement: " + (outputObject as RemoteWebElement).Coordinates.ToString());
//}
//catch (Exception eRWE) {
//    Console.WriteLine(eRWE.Message);
//    Console.WriteLine(eRWE.GetType().Name);
//}
//try {
//    Console.WriteLine("Coordinates of WebElementDecorator: " + (outputObject as WebElementDecorator).Coordinates.ToString());
//}
//catch (Exception eWED) {
//    Console.WriteLine(eWED.Message);
//    Console.WriteLine(eWED.GetType().Name);
//}
                this.WriteVerbose(this, ((IWebElement)outputObject).GetType().Name);
//Console.WriteLine("highlight 0000004");
Console.WriteLine("WriteObjectMethod020Highlight: 00003");
                SeHelper.Highlight((IWebElement)outputObject);
//Console.WriteLine("highlight 0000005");
//Console.WriteLine("WriteObjectMethod020Highlight: 00004");
            }
        }
        
        protected override void WriteObjectMethod030RunScriptBlocks(PSCmdletBase cmdlet, object outputObject)
        {
            this.WriteVerbose(this, "is going to run scriptblocks");
            if (cmdlet != null) {
                // run scriptblocks
                //if (cmdlet is HasScriptBlockCmdletBase) {
                if (cmdlet is PSCmdletBase) {
                    this.WriteVerbose(this, "cmdlet is of the HasScriptBlockCmdletBase type");
                    if (outputObject == null) {
                        this.WriteVerbose(this, "run OnError script blocks (null)");
                        //RunOnErrorScriptBlocks(((HasScriptBlockCmdletBase)cmdlet));
                        RunOnErrorScriptBlocks(cmdlet);
                    } else if (outputObject is bool && ((bool)outputObject) == false) {
                        this.WriteVerbose(this, "run OnError script blocks (false)");
                        //RunOnErrorScriptBlocks(((HasScriptBlockCmdletBase)cmdlet));
                        RunOnErrorScriptBlocks(cmdlet);
                    } else if (outputObject != null) {
                        this.WriteVerbose(this, "run OnSuccess script blocks");
                        //RunOnSuccessScriptBlocks(((HasScriptBlockCmdletBase)cmdlet));
                        RunOnSuccessScriptBlocks(cmdlet);
                    }
                }
            }
        }
        
        protected override void WriteObjectMethod040SetTestResult(PSCmdletBase cmdlet, object outputObject)
        {
            if (cmdlet != null) {
                try {
                    CurrentData.LastResult = outputObject;
                    string iInfo = string.Empty;
                    //if (((HasScriptBlockCmdletBase)cmdlet).TestResultName != null &&
                    if (cmdlet.TestResultName != null &&
                        //((HasScriptBlockCmdletBase)cmdlet).TestResultName.Length > 0) {
                        cmdlet.TestResultName.Length > 0) {

                        //TMX.TMXHelper.CloseTestResult(((HasScriptBlockCmdletBase)cmdlet).TestResultName,
                        TMX.TMXHelper.CloseTestResult(cmdlet.TestResultName,
                                                      //((HasScriptBlockCmdletBase)cmdlet).TestResultId,
                                                      cmdlet.TestResultId,
                                                      //((HasScriptBlockCmdletBase)cmdlet).TestPassed,
                                                      cmdlet.TestPassed,
                                                      false, // isKnownIssue
                                                      this.MyInvocation,
                                                      null, // Error
                                                      string.Empty,
                                                      false);
                    } else {
                        if (Preferences.EveryCmdletAsTestResult) {
                            
                            //((HasScriptBlockCmdletBase)cmdlet).TestResultName = 
                            cmdlet.TestResultName = 
                                GetGeneratedTestResultNameByPosition(
                                    this.MyInvocation.Line,
                                    this.MyInvocation.PipelinePosition);
                            //((HasScriptBlockCmdletBase)cmdlet).TestResultId = string.Empty;
                            cmdlet.TestResultId = string.Empty;
                            //((HasScriptBlockCmdletBase)cmdlet).TestPassed = true;
                            cmdlet.TestPassed = true;

                            //TMX.TMXHelper.CloseTestResult(((HasScriptBlockCmdletBase)cmdlet).TestResultName,
                            TMX.TMXHelper.CloseTestResult(cmdlet.TestResultName,
                                                          string.Empty, //((HasScriptBlockCmdletBase)cmdlet).TestResultId, // empty, to be generated
                                                          //((HasScriptBlockCmdletBase)cmdlet).TestPassed,
                                                          cmdlet.TestPassed,
                                                          false, // isKnownIssue
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
            this.WriteVerbose(this, "WriteObjectMethod045OnSuccessScreenshot SePSX");
            
            if (SePSX.Preferences.OnSuccessScreenShot) {
                //UIAutomation.UIAHelper.GetScreenshotOfSquare(
                SeHelper.GetScreenshotOfWebElement(
                    //(cmdlet as HasWebElementInputCmdletBase),
                    (cmdlet as CommonCmdletBase),
                    outputObject,
                    CmdletName(cmdlet), //string.Empty,
                    true,
                    0,
                    0,
                    0,
                    0,
                    string.Empty,
                    SePSX.Preferences.OnSuccessScreenShotFormat);
            }
        }
        
        //protected override void WriteObjectMethod050OnSuccessDelay(PSCmdletBase cmdlet, object outputObject)
        protected override void WriteObjectMethod050OnSuccessDelay(PSCmdletBase cmdlet, object outputObject)
        {
            
#region commented            
//            if (cmdlet != null) {
//                // remove the Turbo timeout
//                if ((cmdlet as HasTimeoutCmdletBase) != null) {
//                    
//                    if ((CurrentData.CurrentWindow != null &&
//                         CurrentData.LastResult != null) ||
//                         (outputObject as AutomationElement) != null) {
//                        if (Preferences.StoredDefaultTimeout != 0) {
//                            if (! Preferences.TimeoutSetByCustomer) {
//                                Preferences.Timeout = Preferences.StoredDefaultTimeout;
//                                Preferences.StoredDefaultTimeout = 0;
//                            }
//                        }
//                    }
//                }
//
//
//            }
#endregion commented            

            this.WriteVerbose(this, "sleeping if sleep time is provided");
            this.WriteVerbose(this, (Preferences.OnSuccessDelay / 1000).ToString() + " seconds");
            System.Threading.Thread.Sleep(Preferences.OnSuccessDelay);
        }
        
        protected override void WriteObjectMethod060OutputResult(PSCmdletBase cmdlet, object outputObject)
        {
            try {

//                //if (UnitTestMode) {
//                if (PSCmdletBase.UnitTestMode) {
//    
//                    if (null == UnitTestOutput) {
//
//                        UnitTestOutput =
//                           new System.Collections.Generic.List<object>();
//                    }
//                    UnitTestOutput.Add(outputObject);
//                } else {
                    base.WriteObject(outputObject);
//                }
            }
            catch {}
        }
        
        protected override void WriteObjectMethod070Report(PSCmdletBase cmdlet, object outputObject)
        {
            string reportString =
                CmdletSignature(((CommonCmdletBase)cmdlet)) +
                outputObject.ToString();
            
            if (cmdlet != null && reportString != null && reportString != string.Empty) { //try { WriteVerbose(this, reportString);
                this.WriteVerbose(this, reportString);
            } 
            this.WriteVerbose(this, "writing into the log");
            WriteLog(reportString);
            this.WriteVerbose(this, "the log record has been written");
        }
        
        protected override void WriteErrorMethod010RunScriptBlocks(PSCmdletBase cmdlet) //, object outputObject)
        {
            WriteVerbose(this, "WriteErrorMethod010RunScriptBlocks SePSX");
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
                    //if (((HasScriptBlockCmdletBase)cmdlet).TestResultName != null &&
                    if (cmdlet.TestResultName != null &&
                        //((HasScriptBlockCmdletBase)cmdlet).TestResultName.Length > 0) {
                        cmdlet.TestResultName.Length > 0) {
                        //TMX.TestData.AddTestResult
                        //string iInfo = string.Empty;
//                        if (((HasScriptBlockCmdletBase)cmdlet).TestLog){
//                            iInfo = TMX.TMXHelper.GetInvocationInfo(this.MyInvocation);
//                        }

                        //TMX.TMXHelper.CloseTestResult(((HasScriptBlockCmdletBase)cmdlet).TestResultName,
                        TMX.TMXHelper.CloseTestResult(cmdlet.TestResultName,
                                                      //((HasScriptBlockCmdletBase)cmdlet).TestResultId,
                                                      cmdlet.TestResultId,
                                                      //((HasScriptBlockCmdletBase)cmdlet).TestPassed,
                                                      cmdlet.TestPassed,
                                                      //((HasScriptBlockCmdletBase)cmdlet).KnownIssue,
                                                      cmdlet.KnownIssue,
                                                      this.MyInvocation,
                                                      errorRecord,
                                                      string.Empty, 
                                                      true);
                                                      //((HasScriptBlockCmdletBase)cmdlet).TestLog);
                                                      
                    } else {
                        if (Preferences.EveryCmdletAsTestResult) {
                                //((HasScriptBlockCmdletBase)cmdlet).TestResultName = 
                                cmdlet.TestResultName = 
                                    GetGeneratedTestResultNameByPosition(
                                        this.MyInvocation.Line,
                                        this.MyInvocation.PipelinePosition);
//                                    this.MyInvocation.Line + 
//                                    ", position: " +
//                                    this.MyInvocation.PipelinePosition.ToString();

                                //((HasScriptBlockCmdletBase)cmdlet).TestResultId = string.Empty;
                                cmdlet.TestResultId = string.Empty;
                                //((HasScriptBlockCmdletBase)cmdlet).TestPassed = false;
                                cmdlet.TestPassed = false;
//                                iInfo = TMX.TMXHelper.GetInvocationInfo(this.MyInvocation);

                                //TMX.TMXHelper.CloseTestResult(((HasScriptBlockCmdletBase)cmdlet).TestResultName,
                                TMX.TMXHelper.CloseTestResult(cmdlet.TestResultName,
                                                              string.Empty, //((HasScriptBlockCmdletBase)cmdlet).TestResultId, // empty, to be generated
                                                              //((HasScriptBlockCmdletBase)cmdlet).TestPassed,
                                                              cmdlet.TestPassed,
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
                    this.WriteVerbose(this, "for working with test results you need to import the TMX module");
                }
            }
        }
        
        protected override void WriteErrorMethod030ChangeTimeoutSettings(PSCmdletBase cmdlet, bool terminating)
        {
            this.WriteVerbose(this, "WriteErrorMethod030ChangeTimeoutSettings SePSX");
        }
        
        protected override void WriteErrorMethod040AddErrorToErrorList(PSCmdletBase cmdlet, ErrorRecord errorRecord)
        {
            //WriteVerbose(this, "WriteErrorMethod040AddErrorToErrorList SePSX");
            
            // write an error to the Error list
            this.writeErrorToTheList(errorRecord);
        }
        
        protected override void WriteErrorMethod045OnErrorScreenshot(PSCmdletBase cmdlet)
        {
            this.WriteVerbose(this, "WriteErrorMethod045OnErrorScreenshot SePSX");
            
            if (SePSX.Preferences.OnErrorScreenShot) {
                //UIAutomation.UIAHelper.GetScreenshotOfSquare(
//                SeHelper.GetScreenshotOfWebElement(
//                    //(cmdlet as HasWebElementInputCmdletBase),
//                    (cmdlet as CommonCmdletBase),
//                    CmdletName(cmdlet), //string.Empty,
//                    true,
//                    0,
//                    0,
//                    0,
//                    0,
//                    string.Empty,
//                    SePSX.Preferences.OnErrorScreenShotFormat);
                
                UIAutomation.UIAHelper.GetScreenshotOfAutomationElement(
                    (new HasControlInputCmdletBase()),
                    AutomationElement.RootElement,
                    CmdletName(cmdlet),
                    true,
                    0,
                    0,
                    0,
                    0,
                    string.Empty,
                    SePSX.Preferences.OnErrorScreenShotFormat);
                
            }
        }
        
        protected override void WriteErrorMethod050OnErrorDelay(PSCmdletBase cmdlet)
        {
            System.Threading.Thread.Sleep(Preferences.OnErrorDelay);
        }
        
        protected override void WriteErrorMethod060OutputError(PSCmdletBase cmdlet, ErrorRecord errorRecord, bool terminating)
        {
            if (terminating) {
                this.WriteVerbose(this, "terminating error !!!");
                ThrowTerminatingError(errorRecord);
            } else {
                this.WriteVerbose(this, "regular error !!!");
                WriteError(errorRecord);
            }
        }
        
        protected override void WriteErrorMethod070Report(PSCmdletBase cmdlet)
        {
            this.WriteVerbose(this, "WriteErrorMethod070Report PSePSX");
        }
        
        protected override void WriteObjectMethod080ReportFailure()
        {
            this.WriteVerbose(this, "WriteErrorMethod070Report PSePSX");
        }
        
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
        
#region commented
//        private void WriteLog(string record)
//        {
//            try {
//                //Global.WriteToLogFile(record);
//                WriteToLogFile(record);
//            } catch (Exception e) {
//                this.WriteVerbose(this, "Unable to write to the log file: " +
//                             Preferences.LogPath);
//                this.WriteVerbose(this, e.Message);
//            }
//        }
#endregion commented
        
        // 20120816
        // 20120209 protected void RunOnSuccessScriptBlocks(HasScriptBlockCmdletBase cmdlet)
        //protected internal void RunOnSuccessScriptBlocks(HasScriptBlockCmdletBase cmdlet)
        protected internal void RunOnSuccessScriptBlocks(PSCmdletBase cmdlet)
        {
            runTwoScriptBlockCollections(
                Preferences.OnSuccessAction,
                cmdlet.OnSuccessAction,
                cmdlet);
        }
        
        // 20120209 protected void RunOnErrorScriptBlocks(HasScriptBlockCmdletBase cmdlet)
        //protected internal void RunOnErrorScriptBlocks(HasScriptBlockCmdletBase cmdlet)
        protected internal void RunOnErrorScriptBlocks(PSCmdletBase cmdlet)
        {
            runTwoScriptBlockCollections(
                Preferences.OnErrorAction,
                cmdlet.OnErrorAction,
                cmdlet);
        }
        
        // 20120209 protected void RunOnSleepScriptBlocks(HasTimeoutCmdletBase cmdlet)
        // 20120312 0.6.11
        //protected internal void RunOnSleepScriptBlocks(HasTimeoutCmdletBase cmdlet)
        //protected internal void RunOnSleepScriptBlocks(HasControlInputCmdletBase cmdlet)
        protected internal void RunOnSleepScriptBlocks(PSCmdletBase cmdlet)
        {
            //if (cmdlet is HasTimeoutCmdletBase) {
            if (cmdlet is PSCmdletBase) {
                runTwoScriptBlockCollections(
                    Preferences.OnSleepAction,
                    //((HasTimeoutCmdletBase)cmdlet).OnSleepAction,
                    ((PSCmdletBase)cmdlet).OnSleepAction,
                    cmdlet);
            }
        }
        
        
        protected internal void RunOnTranscriptIntervalScriptBlocks(PSCmdletBase cmdlet)
        {
            //if (cmdlet is HasTimeoutCmdletBase) {
            if (cmdlet is PSCmdletBase) {
                runTwoScriptBlockCollections(
                    Preferences.OnTranscriptIntervalAction,
                    //((HasTimeoutCmdletBase)cmdlet).OnSleepAction,
                    null, //((PSCmdletBase)cmdlet).OnSleepAction,
                    cmdlet);
            }
        }
        
#region commented        
//        // temporary
//        public void WriteVerbose(this, PSCmdletBase cmdlet, string text)
//        {
//            WriteVerbose(this, text);
//        }
#endregion commented
        
        #region Log
        private static System.IO.StreamWriter LogStream { get; set; }
        private static System.IO.Stream Stream { get; set; }
        
        internal static void CreateLogFile()
        {
            if (Preferences.Log) {
                try {
                    Stream = 
                        System.IO.File.Open(
                            Preferences.LogPath,
                            FileMode.OpenOrCreate | FileMode.Append,
                            FileAccess.Write,
                            FileShare.Write);
                    LogStream = 
                        new StreamWriter(Stream);
                } catch {
                    Preferences.LogPath = 
                        "'" +
                        System.Environment.GetEnvironmentVariable(
                            "TEMP",
                            EnvironmentVariableTarget.User) + 
                            @"\UIAutomation_" +
                            //UIAHelper.GetTimedFileName() +
                            PSTestHelper.GetTimedFileName() +
                            ".log" +
                            "'";
                    try {
                        Stream =
                            System.IO.File.Open(
                                Preferences.LogPath,
                                FileMode.OpenOrCreate | FileMode.Append,
                                FileAccess.Write,
                                FileShare.Write);
                        LogStream = 
                            new StreamWriter(Stream);
                    } 
                    catch {
                        Preferences.Log = false;
                    }
                }
            }
        }
        
        internal static void CloseLogFile()
        {
            if (Preferences.Log) {
                if (LogStream != null) {
                    try {
                        LogStream.Flush();
                        LogStream.Close();
                    } 
                    catch { }
                    LogStream = null;
                }
            }
        }
        
        internal static void WriteToLogFile(string record)
        {
            if (Preferences.Log) {
                if (System.IO.File.Exists(Preferences.LogPath)) {
                    if (LogStream == null) {
                        Stream = 
                            System.IO.File.Open(
                                Preferences.LogPath,
                                FileMode.OpenOrCreate | FileMode.Append,
                                FileAccess.Write,
                                FileShare.Write);
                        LogStream = 
                            new StreamWriter(Stream);
                    }
                    string dateAndTime = 
                        System.DateTime.Now.ToShortDateString() + 
                        " " +
                        System.DateTime.Now.ToShortTimeString();
                    LogStream.WriteLine(dateAndTime + "\t" + record);
                    //  //  // LogStream.Flush();
                    //  // 
                }
            }
        }
        #endregion Log
    }
}
