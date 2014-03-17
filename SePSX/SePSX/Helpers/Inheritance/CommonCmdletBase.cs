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
    
    using System.Collections;
    using System.Collections.ObjectModel;
    using System.Windows.Automation;
    using UIAutomation;
    
    /// <summary>
    /// Description of CommonCmdletBase.
    /// </summary>
    public class CommonCmdletBase : PSCmdletBase//, ICommonCmdletBase
    {
        public CommonCmdletBase()
        {
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
        
        // 20130430
        //protected override void WriteLog(string logRecord)
        protected override void WriteLog(LogLevels logLevel, string logRecord)
        {
            if (Preferences.AutoLog) {
                
                // 20140317
                // turning off the logger
//                switch (logLevel) {
//                    case LogLevels.Fatal:
//                        TMX.Logger.Fatal(logRecord);
//                        break;
//                    case LogLevels.Error:
//                        TMX.Logger.Error(logRecord);
//                        break;
//                    case LogLevels.Warn:
//                        TMX.Logger.Warn(logRecord);
//                        break;
//                    case LogLevels.Info:
//                        TMX.Logger.Info(logRecord);
//                        break;
//                    case LogLevels.Debug:
//                        TMX.Logger.Debug(logRecord);
//                        break;
//                    case LogLevels.Trace:
//                        TMX.Logger.Trace(logRecord);
//                        break;
//                }
            }
            
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
        
        protected void WriteLog(LogLevels logLevel, System.Management.Automation.ErrorRecord errorRecord)
        {
            if (Preferences.AutoLog) {
                
                this.WriteLog(logLevel, errorRecord.Exception.Message);
                this.WriteLog(logLevel, "Script: '" + errorRecord.InvocationInfo.ScriptName + "', line: " + errorRecord.InvocationInfo.Line.ToString());
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
        
        public virtual void WriteObject(PSCmdletBase cmdlet, ReadOnlyCollection<IWebElement> outputObjectCollection)
        {
            for (int i = 0; i < outputObjectCollection.Count; i++) {
                WriteObject(cmdlet, outputObjectCollection[i]);
            }
        }
        
        protected override bool CheckSingleObject(PSCmdletBase cmdlet, object outputObject) { return WriteObjectMethod010CheckOutputObject(cmdlet, outputObject); }
        protected override void BeforeWriteCollection(PSCmdletBase cmdlet, object[] outputObjectCollection) {}
        protected override void BeforeWriteCollection(PSCmdletBase cmdlet, System.Collections.Generic.List<object> outputObjectCollection) {}
        protected override void BeforeWriteCollection(PSCmdletBase cmdlet, ArrayList outputObjectCollection) {}
        protected override void BeforeWriteCollection(PSCmdletBase cmdlet, IList outputObjectCollection) {}
        protected override void BeforeWriteCollection(PSCmdletBase cmdlet, IEnumerable outputObjectCollection) {}
        protected override void BeforeWriteCollection(PSCmdletBase cmdlet, ICollection outputObjectCollection) {}
        protected override void BeforeWriteCollection(PSCmdletBase cmdlet, Hashtable outputObjectCollection) {}
        protected override void BeforeWriteSingleObject(PSCmdletBase cmdlet, object outputObject) {}

        protected override void WriteSingleObject(PSCmdletBase cmdlet, object outputObject)
        {
Console.WriteLine("WriteSingleObject 00001");
            WriteObjectMethod020Highlight(cmdlet, outputObject);
Console.WriteLine("WriteSingleObject 00002");
            WriteObjectMethod030RunScriptBlocks(cmdlet, outputObject);
Console.WriteLine("WriteSingleObject 00003");
            WriteObjectMethod040SetTestResult(cmdlet, outputObject);
Console.WriteLine("WriteSingleObject 00004");
            WriteObjectMethod045OnSuccessScreenshot(cmdlet, outputObject);
Console.WriteLine("WriteSingleObject 00005");
            WriteObjectMethod050OnSuccessDelay(cmdlet, outputObject);
Console.WriteLine("WriteSingleObject 00006");
            WriteObjectMethod060OutputResult(cmdlet, outputObject);
Console.WriteLine("WriteSingleObject 00007");
            WriteObjectMethod070Report(cmdlet, outputObject);
Console.WriteLine("WriteSingleObject 00008");
            WriteObjectMethod080ReportFailure(cmdlet, outputObject);
        }
        
        protected override void AfterWriteSingleObject(PSCmdletBase cmdlet, object outputObject) {}
        protected override void AfterWriteCollection(PSCmdletBase cmdlet, object[] outputObjectCollection) {}
        protected override void AfterWriteCollection(PSCmdletBase cmdlet, System.Collections.Generic.List<object> outputObjectCollection) {}
        protected override void AfterWriteCollection(PSCmdletBase cmdlet, ArrayList outputObjectCollection) {}
        protected override void AfterWriteCollection(PSCmdletBase cmdlet, IList outputObjectCollection) {}
        protected override void AfterWriteCollection(PSCmdletBase cmdlet, IEnumerable outputObjectCollection) {}
        protected override void AfterWriteCollection(PSCmdletBase cmdlet, ICollection outputObjectCollection) {}
        protected override void AfterWriteCollection(PSCmdletBase cmdlet, Hashtable outputObjectCollection) {}
        
        // 20130204
        //protected override bool WriteObjectMethod010CheckOutputObject(object outputObject)
        protected bool WriteObjectMethod010CheckOutputObject(PSCmdletBase cmdlet, object outputObject)
        {
            bool result = false || outputObject != null;

            return result;
        }
        
        // 20130204
        //protected override void WriteObjectMethod020Highlight(PSCmdletBase cmdlet, object outputObject)
        protected void WriteObjectMethod020Highlight(PSCmdletBase cmdlet, object outputObject)
        {
            this.WriteVerbose(this, "IWebDriver or IWebElement");
//Console.WriteLine("WriteObjectMethod020Highlight 00001");
            if (Preferences.Highlight && outputObject is IWebElement) {
//Console.WriteLine("WriteObjectMethod020Highlight 00002");
                this.WriteVerbose(this, "Highlighting");
//Console.WriteLine("WriteObjectMethod020Highlight 00003");
                this.WriteVerbose(this, outputObject.GetType().Name);
//Console.WriteLine("WriteObjectMethod020Highlight 00004");
                this.WriteVerbose(this, ((IWebElement)outputObject).GetType().Name);
//Console.WriteLine("WriteObjectMethod020Highlight 00005");
                SeHelper.Highlight((IWebElement)outputObject);
//Console.WriteLine("WriteObjectMethod020Highlight 00006");
            }
        }
        
        // 20130204
        //protected override void WriteObjectMethod030RunScriptBlocks(PSCmdletBase cmdlet, object outputObject)
        protected void WriteObjectMethod030RunScriptBlocks(PSCmdletBase cmdlet, object outputObject)
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
                        // 20130318
                        //RunOnErrorScriptBlocks(cmdlet);
                        RunOnErrorScriptBlocks(cmdlet, null);
                    } else if (outputObject is bool && ((bool)outputObject) == false) {
                        this.WriteVerbose(this, "run OnError script blocks (false)");
                        //RunOnErrorScriptBlocks(((HasScriptBlockCmdletBase)cmdlet));
                        // 20130318
                        //RunOnErrorScriptBlocks(cmdlet);
                        RunOnErrorScriptBlocks(cmdlet, null);
                    } else if (outputObject != null) {
                        this.WriteVerbose(this, "run OnSuccess script blocks");
                        //RunOnSuccessScriptBlocks(((HasScriptBlockCmdletBase)cmdlet));
                        // 20130318
                        //RunOnSuccessScriptBlocks(cmdlet);
                        RunOnSuccessScriptBlocks(cmdlet, null);
                    }
                }
            }
        }
        
        // 20130204
        //protected override void WriteObjectMethod040SetTestResult(PSCmdletBase cmdlet, object outputObject)
        protected void WriteObjectMethod040SetTestResult(PSCmdletBase cmdlet, object outputObject)
        {
            if (cmdlet != null) {
                try {
                    CurrentData.LastResult = outputObject;
                    string iInfo = string.Empty;
                    //if (((HasScriptBlockCmdletBase)cmdlet).TestResultName != null &&
                    if (cmdlet.TestResultName != null &&
                        //((HasScriptBlockCmdletBase)cmdlet).TestResultName.Length > 0) {
                        cmdlet.TestResultName.Length > 0) {

                        //TMX.TmxHelper.CloseTestResult(((HasScriptBlockCmdletBase)cmdlet).TestResultName,
                        TMX.TmxHelper.CloseTestResult(cmdlet.TestResultName,
                                                      //((HasScriptBlockCmdletBase)cmdlet).TestResultId,
                                                      cmdlet.TestResultId,
                                                      //((HasScriptBlockCmdletBase)cmdlet).TestPassed,
                                                      cmdlet.TestPassed,
                                                      false, // isKnownIssue
                                                      this.MyInvocation,
                                                      null, // Error
                                                      string.Empty,
                                                      // 20130322
                                                      //false);
                                                      // 20130626
                                                      //false,
                                                      TMX.TestResultOrigins.Logical,
                                                      true);
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

                            //TMX.TmxHelper.CloseTestResult(((HasScriptBlockCmdletBase)cmdlet).TestResultName,
                            TMX.TmxHelper.CloseTestResult(cmdlet.TestResultName,
                                                          string.Empty, //((HasScriptBlockCmdletBase)cmdlet).TestResultId, // empty, to be generated
                                                          //((HasScriptBlockCmdletBase)cmdlet).TestPassed,
                                                          cmdlet.TestPassed,
                                                          false, // isKnownIssue
                                                          this.MyInvocation,
                                                          null, // Error
                                                          string.Empty,
                                                          // 20130322
                                                          //true);
                                                          // 20130626
                                                          //true,
                                                          TMX.TestResultOrigins.Automatic,
                                                          false);
                        }
                    }
                }
                catch (Exception eeee) {
                    this.WriteVerbose(this, "for working with test results you need to import the TMX module");
                }
            }
        }
        
        // 20130204
        //protected override void WriteObjectMethod045OnSuccessScreenshot(PSCmdletBase cmdlet, object outputObject)
        protected void WriteObjectMethod045OnSuccessScreenshot(PSCmdletBase cmdlet, object outputObject)
        {
            //this.WriteVerbose(this, "WriteObjectMethod045OnSuccessScreenshot SePSX");
            
            if (SePSX.Preferences.OnSuccessScreenShot) {
                //UIAutomation.UiaHelper.GetScreenshotOfSquare(
                SeHelper.GetScreenshotOfWebElement(
                    //(cmdlet as HasWebElementInputCmdletBase),
                    (cmdlet as CommonCmdletBase),
                    outputObject,
                    CmdletName(cmdlet), //string.Empty,
                    true,
                    // 20140111
                    // 0,
                    // 0,
                    // 0,
                    // 0,
                    new ScreenshotRect(),
                    string.Empty,
                    SePSX.Preferences.OnSuccessScreenShotFormat);
            }
        }
        
        //protected override void WriteObjectMethod050OnSuccessDelay(PSCmdletBase cmdlet, object outputObject)
        // 20130204
        //protected override void WriteObjectMethod050OnSuccessDelay(PSCmdletBase cmdlet, object outputObject)
        protected void WriteObjectMethod050OnSuccessDelay(PSCmdletBase cmdlet, object outputObject)
        {
            
            this.WriteVerbose(this, "sleeping if sleep time is provided");
            this.WriteVerbose(this, (Preferences.OnSuccessDelay / 1000).ToString() + " seconds");
            System.Threading.Thread.Sleep(Preferences.OnSuccessDelay);
        }
        
        // 20130204
        //protected override void WriteObjectMethod060OutputResult(PSCmdletBase cmdlet, object outputObject)
        protected void WriteObjectMethod060OutputResult(PSCmdletBase cmdlet, object outputObject)
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
        
        // 20130204
        //protected override void WriteObjectMethod070Report(PSCmdletBase cmdlet, object outputObject)
        protected void WriteObjectMethod070Report(PSCmdletBase cmdlet, object outputObject)
        {
            
            if (Preferences.AutoLog) {
                
                string reportString =
                    CmdletSignature(((CommonCmdletBase)cmdlet)) +
                    outputObject.ToString();
                
                if (cmdlet != null && reportString != null && reportString != string.Empty) { //try { WriteVerbose(this, reportString);
                    this.WriteVerbose(this, reportString);
                } 
                //this.WriteVerbose(this, "writing into the log");
                // 20130430
                //WriteLog(reportString);
                //WriteLog(
                this.WriteLog(LogLevels.Info, reportString);
                //this.WriteVerbose(this, "the log record has been written");
            
            }
        }
        
        // 20131114
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
                TMX.TmxHelper.AddTestResultErrorDetail(errorRecord);
                
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
//                            iInfo = TMX.TmxHelper.GetInvocationInfo(this.MyInvocation);
//                        }

                        //TMX.TmxHelper.CloseTestResult(((HasScriptBlockCmdletBase)cmdlet).TestResultName,
                        TMX.TmxHelper.CloseTestResult(cmdlet.TestResultName,
                                                      //((HasScriptBlockCmdletBase)cmdlet).TestResultId,
                                                      cmdlet.TestResultId,
                                                      //((HasScriptBlockCmdletBase)cmdlet).TestPassed,
                                                      cmdlet.TestPassed,
                                                      //((HasScriptBlockCmdletBase)cmdlet).KnownIssue,
                                                      cmdlet.KnownIssue,
                                                      this.MyInvocation,
                                                      errorRecord,
                                                      string.Empty,
                                                      // 20130322
                                                      //true);
                                                      // 20130626
                                                      //true,
                                                      TMX.TestResultOrigins.Automatic,
                                                      false);
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
//                                iInfo = TMX.TmxHelper.GetInvocationInfo(this.MyInvocation);

                                //TMX.TmxHelper.CloseTestResult(((HasScriptBlockCmdletBase)cmdlet).TestResultName,
                                TMX.TmxHelper.CloseTestResult(cmdlet.TestResultName,
                                                              string.Empty, //((HasScriptBlockCmdletBase)cmdlet).TestResultId, // empty, to be generated
                                                              //((HasScriptBlockCmdletBase)cmdlet).TestPassed,
                                                              cmdlet.TestPassed,
                                                              false, // isKnownIssue
                                                              this.MyInvocation,
                                                              errorRecord,
//                                                              TMX.TmxHelper.GetScriptLineNumber(this.MyInvocation),
//                                                              TMX.TmxHelper.GetPipelinePosition(this.MyInvocation),
//                                                              iInfo,
                                                              string.Empty,
                                                              // 20130322
                                                              //true);
                                                              // 20130626
                                                              //true,
                                                              TMX.TestResultOrigins.Automatic,
                                                              false);
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
                //UIAutomation.UiaHelper.GetScreenshotOfSquare(
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
                
                UIAutomation.UiaHelper.GetScreenshotOfAutomationElement(
                    (new HasControlInputCmdletBase()),
                    // 20131109
                    //AutomationElement.RootElement,
                    UiElement.RootElement,
                    CmdletName(cmdlet),
                    true,
                    // 20140111
                    // 0,
                    // 0,
                    // 0,
                    // 0,
                    new ScreenshotRect(),
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
                //this.WriteVerbose(this, "terminating error !!!");
                
                // 20130430
                WriteLog(LogLevels.Fatal, errorRecord);
                
                ThrowTerminatingError(errorRecord);
            } else {
                //this.WriteVerbose(this, "regular error !!!");
                
                // 20130430
                WriteLog(LogLevels.Error, errorRecord);
                
                WriteError(errorRecord);
            }
        }
        
        protected override void WriteErrorMethod070Report(PSCmdletBase cmdlet)
        {
            //this.WriteVerbose(this, "WriteErrorMethod070Report PSePSX");
        }
        
        // 20130204
        //protected override void WriteObjectMethod080ReportFailure()
        protected void WriteObjectMethod080ReportFailure(PSCmdletBase cmdlet, object outputObject)
        {
            //this.WriteVerbose(this, "WriteErrorMethod070Report PSePSX");
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
        // 20130318
        //protected internal void RunOnSuccessScriptBlocks(PSCmdletBase cmdlet)
        protected internal void RunOnSuccessScriptBlocks(PSCmdletBase cmdlet, object[] parameters)
        {
            runTwoScriptBlockCollections(
                Preferences.OnSuccessAction,
                cmdlet.OnSuccessAction,
                // 20130318
                //cmdlet);
                cmdlet,
                parameters);
        }
        
        // 20120209 protected void RunOnErrorScriptBlocks(HasScriptBlockCmdletBase cmdlet)
        //protected internal void RunOnErrorScriptBlocks(HasScriptBlockCmdletBase cmdlet)
        // 20130318
        //protected internal void RunOnErrorScriptBlocks(PSCmdletBase cmdlet)
        protected internal void RunOnErrorScriptBlocks(PSCmdletBase cmdlet, object[] parameters)
        {
            runTwoScriptBlockCollections(
                Preferences.OnErrorAction,
                cmdlet.OnErrorAction,
                // 20130318
                //cmdlet);
                cmdlet,
                parameters);
        }
        
        // 20120209 protected void RunOnSleepScriptBlocks(HasTimeoutCmdletBase cmdlet)
        // 20120312 0.6.11
        //protected internal void RunOnSleepScriptBlocks(HasTimeoutCmdletBase cmdlet)
        //protected internal void RunOnSleepScriptBlocks(HasControlInputCmdletBase cmdlet)
        // 20130318
        //protected internal void RunOnSleepScriptBlocks(PSCmdletBase cmdlet)
        protected internal void RunOnSleepScriptBlocks(PSCmdletBase cmdlet, object[] parameters)
        {
            //if (cmdlet is HasTimeoutCmdletBase) {
            if (cmdlet is PSCmdletBase) {
                runTwoScriptBlockCollections(
                    Preferences.OnSleepAction,
                    //((HasTimeoutCmdletBase)cmdlet).OnSleepAction,
                    ((PSCmdletBase)cmdlet).OnSleepAction,
                    // 20130318
                    //cmdlet);
                    cmdlet,
                    parameters);
            }
        }
        
        // 20130318
        //protected internal void RunOnTranscriptIntervalScriptBlocks(PSCmdletBase cmdlet)
        protected internal void RunOnTranscriptIntervalScriptBlocks(PSCmdletBase cmdlet, object[] parameters)
        {
            //if (cmdlet is HasTimeoutCmdletBase) {
            if (cmdlet is PSCmdletBase) {
                runTwoScriptBlockCollections(
                    Preferences.OnTranscriptIntervalAction,
                    //((HasTimeoutCmdletBase)cmdlet).OnSleepAction,
                    null, //((PSCmdletBase)cmdlet).OnSleepAction,
                    // 20130318
                    //cmdlet);
                    cmdlet,
                    parameters);
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
                            //UiaHelper.GetTimedFileName() +
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
