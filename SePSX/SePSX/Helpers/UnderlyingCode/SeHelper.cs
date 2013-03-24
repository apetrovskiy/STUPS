/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/17/2012
 * Time: 10:12 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSX
{
    #region using
    using System;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Firefox;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.IE;
    
    using OpenQA.Selenium.Safari;
    //using OpenQA.Selenium.Opera;
    using OpenQA.Selenium.Android;
    
    using OpenQA.Selenium.Support;
    using UIAutomation;
    using OpenQA.Selenium.Remote;
    
    using System.Diagnostics;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Collections;
    using System.Drawing;
    
    //
    //
    using System.Windows.Automation;
    //
    //
    
    //using OpenQA.Selenium.Remote;
    
    using PSTestLib;
    using System.Management.Automation;
    
    using OpenQA.Selenium.Interactions;
    using OpenQA.Selenium.Support.PageObjects;
    
    using OpenQA.Selenium.Support.UI;
    
    using System.Windows.Forms;
    
    using System.Management.Automation.Runspaces;
    
    
    using SePSX.Commands;
    
    using Autofac;

    #endregion using
    
    /// <summary>
    /// Description of SeHelper.
    /// </summary>
    public static class SeHelper
    {
        //public SeHelper()
        static SeHelper()
        {
            //            DriverFF = new FirefoxDriver();
            //            DriverChrome = new ChromeDriver();
            //            DriverIE = new InternetExplorerDriver();

            DriverProcesses =
                new System.Collections.Generic.List<Process>();
        }
        
        #region internals
        private static UIAutomation.Highlighter highlighter = null;
        private static UIAutomation.Highlighter highlighterParent = null;
        //private static Highlighter highlighterFirstChild = null;
        
        //private static System.Windows.Automation.AutomationElement element = null;
        //private static OpenQA.Selenium.IWebDriver stWebDriver = null;
        //private static OpenQA.Selenium.IWebElement stWebElement = null;
        
        internal const string ProcessNameChrome = "chrome";
        internal const string ProcessNameFirefox = "firefox";
        internal const string ProcessNameIE = "iexplore";
        internal const string ProcessNameSafari = "safari";
        internal const string ProcessNameOpera = "opera";
        internal const string ProcessNameHTMLDriver = "htmld";
        internal static System.Collections.Generic.List<Process> DriverProcesses { get; set; }
        internal static Process DriverProcess { get; set; }
        
        internal const string DriverTitleComplementChrome = " - Google Chrome";
        internal const string DriverTitleComplementFirefox = " - Mozilla Firefox";
        internal const string DriverTitleComplementInternetExplorer = " - Windows Internet Explorer";
        internal const string DriverTitleComplementSafari = " - safari ???";
        internal const string DriverTitleComplementOpera = " - opera ????";
        
        public const string DriverTitleOnStartChrome = "about:blank";
        public const string DriverTitleOnStartFirefox = " ??? ff ??? ";
        public const string DriverTitleOnStartInternetExplorer = "WebDriver";
        public const string DriverTitleOnStartSafari = " ??? safari ???";
        public const string DriverTitleOnStartOpera = " ???? opera ????";
        
        internal static bool waitForElement = true;
        
        
        // 20120928
        internal const string driverNameFirefox = "FIREFOX";
        internal const string driverNameFirefox2 = "FF";
        internal const string driverNameChrome = "CHROME";
        internal const string driverNameChrome2 = "CH";
        internal const string driverNameInternetExplorer = "INTERNETEXPLORER";
        internal const string driverNameInternetExplorer2 = "IE";
        internal const string driverNameInternetExplorer3 = "INTERNETEXPLORER32";
        internal const string driverNameInternetExplorer4 = "IE32";
        internal const string driverNameInternetExplorer5 = "INTERNETEXPLORER64";
        internal const string driverNameInternetExplorer6 = "IE64";
        internal const string driverNameSafari = "SAFARI";
        internal const string driverNameSafari2 = "SF";
        internal const string driverNameOpera = "OPERA";
        internal const string driverNameOpera2 = "OP";
        internal const string driverNameAndroid = "ANDROID";
        internal const string driverNameAndroid2 = "AN";
        internal const string driverNameHTMLUnit = "HTMLUNIT";
        internal const string driverNameHTMLUnit2 = "HTML";
        
        
        #endregion internals
        
        #region Highlight
        // 20121212
        //private static int[] getWebElementCoordinates(RemoteWebElement element)
        private static int[] getWebElementCoordinates(WebElementDecorator element)
        {

            int[] driverCoordinates = new int[2];

            AutomationElement driverElement =
                System.Windows.Automation.AutomationElement.RootElement.FindFirst(
                    TreeScope.Children,
                    new PropertyCondition(
                        AutomationElement.ProcessIdProperty,
                        CurrentData.CurrentWebDriverPID));

            if (driverElement != null) {

                PropertyCondition internalPaneCondition = null;
                
                switch (SeHelper.DriverProcess.ProcessName) {
                    case SeHelper.ProcessNameChrome:
                    case SeHelper.ProcessNameFirefox:
                    case SeHelper.ProcessNameOpera:
                        internalPaneCondition =
                            new PropertyCondition(
                                AutomationElement.ControlTypeProperty,
                                ControlType.Document);
                        break;
                    case SeHelper.ProcessNameIE:
                        internalPaneCondition =
                            new PropertyCondition(
                                AutomationElement.ControlTypeProperty,
                                ControlType.Pane);
                        break;
                    case SeHelper.ProcessNameSafari:
                        internalPaneCondition =
                            new PropertyCondition(
                                AutomationElement.ControlTypeProperty,
                                ControlType.Pane);
                        break;
                        //                            case SeHelper.ProcessNameOpera:
                        //                                internalPanec =
                        //                                    new PropertyCondition(
                        //                                        AutomationElement.ControlTypeProperty,
                        //                                        ControlType.Pane);
                        //                                break;
                }

                AutomationElement internalPaneElement =
                    driverElement.FindFirst(
                        TreeScope.Descendants,
                        internalPaneCondition);

                driverCoordinates[0] =
                    (int)internalPaneElement.Current.BoundingRectangle.X +
                    ((WebElementDecorator)element).Coordinates.LocationOnScreen.X;
                
                driverCoordinates[1] =
                    (int)internalPaneElement.Current.BoundingRectangle.Y +
                    ((WebElementDecorator)element).Coordinates.LocationOnScreen.Y;
            }
            return driverCoordinates;
        }
        
        public static void Highlight(IWebElement webElement)
        {
            try { if (highlighter != null) { highlighter.Dispose(); } } catch {}
            try { if (highlighterParent != null) { highlighterParent.Dispose(); } } catch {}
            //try { if (highlighterFirstChild != null) { highlighterFirstChild.Dispose(); } } catch {}

            if ((webElement as IWebElement) != null) {
//                RemoteWebElement remoteElement =
//                    webElement as RemoteWebElement;

                // 20121212
                WebElementDecorator decoratedElement =
                    webElement as WebElementDecorator;
                
                WebElementDecorator parentElement;
                
                

                // 20121212
                //if (remoteElement != null) {
                if (null != decoratedElement) {

                    int[] absoluteCoordinates =
                        // 20121212
                        //getWebElementCoordinates(remoteElement);
                        getWebElementCoordinates(decoratedElement);

                    try {
                        highlighter =
                            new UIAutomation.Highlighter(
                                // 20121212
                                //remoteElement.Size.Height,
                                decoratedElement.Size.Height,
                                // 20121212
                                //remoteElement.Size.Width,
                                decoratedElement.Size.Width,
                                absoluteCoordinates[0],
                                absoluteCoordinates[1],
                                0,
                                UIAutomation.Highlighters.Element);
                    }
                    catch {}

                    if (Preferences.HighlightParent) {
//try {
                        try {
                            // 20121212
                            //RemoteWebElement parentElement =
                            //WebElementDecorator parentElement =
                            parentElement =
                                // 20121212
                                //(RemoteWebElement)SeHelper.GetParentWebElement(remoteElement);
                                //(RemoteWebElement)SeHelper.GetParentWebElement(decoratedElement);
                                (WebElementDecorator)SeHelper.GetParentWebElement(decoratedElement);

                            // 20121212
                            //if ((parentElement as RemoteWebElement) != null) {
                            if ((parentElement as WebElementDecorator) != null) {

                                int[] parentAbsoluteCoordinates =
                                    getWebElementCoordinates(parentElement);

                                try {
                                    highlighterParent =
                                        new UIAutomation.Highlighter(
                                            parentElement.Size.Height,
                                            parentElement.Size.Width,
                                            parentAbsoluteCoordinates[0],
                                            parentAbsoluteCoordinates[1],
                                            0,
                                            UIAutomation.Highlighters.Parent);
                                }
                                catch {}

                            }
                        }
                        catch {}
//}
//catch (Exception ePE) {
//    Console.WriteLine(ePE.Message);
//    Console.WriteLine(ePE.GetType().Name);
//}
                    }
                }
            }
        }
        
        private static double getSquare(Process process, string title)
        {
            double result = 0;
            
            //System.Windows.Forms.MessageBox.Show(title);
            
            try {
                AutomationElement element =
                    System.Windows.Automation.AutomationElement.RootElement.FindFirst(
                        TreeScope.Children,
                        new AndCondition(
                            new PropertyCondition(
                                AutomationElement.ProcessIdProperty,
                                process.Id),
                            new PropertyCondition(
                                AutomationElement.NameProperty,
                                title)));
                try {
                    if (element != null) {
                        result =
                            element.Current.BoundingRectangle.Height *
                            element.Current.BoundingRectangle.Width;
                    }
                }
                catch {}
            }
            catch {}
            
            return result;
        }
        #endregion Highlight
        
        #region starting driver
        internal static string GetDriverProcessName(
            SePSX.Drivers driverCode) //,
            //WebDriverFactory factory)
        {
            string processToWatch = string.Empty;
            switch (driverCode) {
                case SePSX.Drivers.Chrome:
                    processToWatch = SeHelper.ProcessNameChrome;
                    break;
                case SePSX.Drivers.Firefox:
                    processToWatch = SeHelper.ProcessNameFirefox;
                    break;
                case SePSX.Drivers.InternetExplorer:
                    processToWatch = SeHelper.ProcessNameIE;
                    break;
                case SePSX.Drivers.HTML:
                    processToWatch = SeHelper.ProcessNameHTMLDriver;
                    break;
                case SePSX.Drivers.Safari:
                    processToWatch = SeHelper.ProcessNameSafari;
                    break;
                    //case SePSX.Drivers.Opera:
                    //    processToWatch = SeHelper.ProcessNameOpera;
                    //    break;
                default:
                    throw new Exception("Invalid value for Drivers");
            }
            
            return processToWatch;
        }
        
        internal static string GetDriverProcessName(
            SePSX.DriverServers driverCode) //,
            //WebDriverFactory factory)
        {
            string processToWatch = string.Empty;
            switch (driverCode) {
                case SePSX.DriverServers.chrome:
                    processToWatch = SeHelper.ProcessNameChrome;
                    break;
                    //                case SePSX.Drivers.Firefox:
                    //                    processToWatch = SeHelper.ProcessNameFirefox;
                    //                    break;
                case SePSX.DriverServers.ie:
                    processToWatch = SeHelper.ProcessNameIE;
                    break;
                    //                case SePSX.Drivers.HTML:
                    //                    processToWatch = SeHelper.ProcessNameHTMLDriver;
                    //                    break;
                    //                case SePSX.Drivers.Safari:
                    //                    processToWatch = SeHelper.ProcessNameSafari;
                    //                    break;
                    //case SePSX.Drivers.Opera:
                    //    processToWatch = SeHelper.ProcessNameOpera;
                    //    break;
                default:
                    throw new Exception("Invalid value for Drivers");
            }
            
            return processToWatch;
        }
        
        internal static void CollectDriverProcesses(Drivers driverCode)
        {
            Process[] processArray =
                //Process.GetProcessesByName(GetDriverProcessName(driverCode, (new WebDriverFactory(new WebDriverModule()))));
                Process.GetProcessesByName(GetDriverProcessName(driverCode));
            foreach (Process process in processArray) {
                DriverProcesses.Add(process);
            }
        }
        
        internal static void CollectDriverProcesses(DriverServers driverCode)
        {
            Process[] processArray =
                //Process.GetProcessesByName(GetDriverProcessName(driverCode, (new WebDriverFactory(new WebDriverModule()))));
                Process.GetProcessesByName(GetDriverProcessName(driverCode));
            foreach (Process process in processArray) {
                DriverProcesses.Add(process);
            }
        }
        
        internal static void GetDriverProcess(Drivers driverCode, string title)
        {
            Process[] processArray =
                //Process.GetProcessesByName(GetDriverProcessName(driverCode, (new WebDriverFactory(new WebDriverModule()))));
                Process.GetProcessesByName(GetDriverProcessName(driverCode));
            System.Collections.Generic.List<Process> newProcesses =
                new System.Collections.Generic.List<Process>();
            foreach (Process process in processArray) {
                if (!DriverProcesses.Contains(process) &&
                    process.MainWindowHandle.ToInt32() > 0) {
                    //SeHelper.DriverProcess = process;
                    //break;
                    newProcesses.Add(process);
                }
            }
            
            if (newProcesses.Count == 1) {
                SeHelper.DriverProcess = newProcesses[0];
            } else {
                //Process theBiggestWindowProcess = null;
                SeHelper.DriverProcess = null;
                double square = 0;
                double currentSquare = 0;
                foreach (Process process in newProcesses) {
                    currentSquare = getSquare(process, title);
                    if (currentSquare > square) {
                        SeHelper.DriverProcess = process;
                        square = currentSquare;
                    }
                }
            }
            
            DriverProcesses.Clear();
        }
        
        internal static void StartWebDriver(
            StartSeWebDriverCommand cmdlet)
        {
            IWebDriver driver = null;

            if (cmdlet.DriverName == null ||
                cmdlet.DriverName == string.Empty ||
                cmdlet.DriverName.Length == 0) {

                cmdlet.WriteError(
                    cmdlet,
                    "You must choose the driver",
                    "NoTypeOfDriver",
                    ErrorCategory.InvalidArgument,
                    true);
            }

            if (0 == cmdlet.Count) {
                cmdlet.Count = 1;
            }

            for (int i = 0; i < cmdlet.Count; i++) {
                cmdlet.WriteVerbose(cmdlet, "clean process collection");
                SeHelper.DriverProcesses.Clear();
                SeHelper.DriverProcess = null;

                #region commented
                //                            System.Management.Automation.InvocationInfo info =
                //                                this.MyInvocation;
                //                            Console.WriteLine("info.PSCommandPath");
                //                            //Console.WriteLine(info.PSCommandPath);
                //                            Console.WriteLine("info.PSScriptRoot");
                //                            //Console.WriteLine(info.PSScriptRoot);
                //                            Console.WriteLine("this.MyInvocation.PSCommandPath");
                //                            Console.WriteLine(this.MyInvocation.ToString()); //.PSCommandPath);
                //                            Console.WriteLine("this.MyInvocation.PSScriptRoot");
                //                            Console.WriteLine(this.MyInvocation);
                //                            WriteObject(this, info);
                //                            //return;
                #endregion commented
                
                cmdlet.WriteVerbose(cmdlet, "creating a driver");
                string errorReport = cmdlet.DriverName;

                try {

                    #region commented
                    //                    switch (cmdlet.DriverName.ToUpper()) {
                    //                        case driverNameFirefox:
                    //                        case driverNameFirefox2:
                    //                            driver = WebDriverFactory.GetDriver(cmdlet, Drivers.Firefox);
                    //                            break;
                    //                        case driverNameChrome:
                    //                        case driverNameChrome2:
                    //                            driver = WebDriverFactory.GetDriverServer(cmdlet);
                    //                            break;
                    //                        case driverNameInternetExplorer:
                    //                        case driverNameInternetExplorer2:
                    //                        case driverNameInternetExplorer3:
                    //                        case driverNameInternetExplorer4:
                    //                            driver = WebDriverFactory.GetDriverServer(cmdlet);
                    //                            break;
                    //                        case driverNameSafari:
                    //                        case driverNameSafari2:
                    //#region commented
                    //////Console.WriteLine("before collecting processes");
                    ////                            SeHelper.CollectDriverProcesses(Drivers.Safari);
                    //////Console.WriteLine("before creating a driver");
                    ////                            driver = new SafariDriver();
                    //////Console.WriteLine("before getting the handle");
                    ////                            SeHelper.GetDriverProcess(
                    ////                                Drivers.Safari,
                    ////                                driver.Title + SeHelper.DriverTitleComplementSafari);
                    //#endregion commented
//
                    //                            driver = WebDriverFactory.GetDriver(cmdlet, Drivers.Safari);
                    //                            //driver = factory.GetDriver(cmdlet, Drivers.Safari);
//
                    //                            break;
                    //                        //case driverNameOpera:
                    //                        //case driverNameOpera2:
                    //                        //    driver = new OperaDriver();
                    //                        //    break;
                    //                        case driverNameAndroid:
                    //                        case driverNameAndroid2:
                    //                            // ?
                    //                            //driver = new AndroidDriver();
                    //                            break;
                    //                        case driverNameHTMLUnit:
                    //                        case driverNameHTMLUnit2:
                    //#region commented
                    ////                            driver =
                    ////                                new RemoteWebDriver(DesiredCapabilities.HtmlUnit());
                    //#endregion commented
//
                    //                            driver = WebDriverFactory.GetDriver(cmdlet, Drivers.HTML);
                    //                            //driver = factory.GetDriver(cmdlet, Drivers.HTML);
//
                    //                            break;
                    //                    }
                    #endregion commented
                    
                    switch (cmdlet.DriverType) {
                        case Drivers.Chrome:
                            driver = WebDriverFactory.GetDriverServer(cmdlet);
                            break;
                        case Drivers.Firefox:
                            driver = WebDriverFactory.GetDriver(cmdlet, Drivers.Firefox);
                            break;
                        case Drivers.InternetExplorer:
                            driver = WebDriverFactory.GetDriverServer(cmdlet);
                            break;
                        case Drivers.Safari:
                            driver = WebDriverFactory.GetDriver(cmdlet, Drivers.Safari);
                            break;
                        case Drivers.HTML:
                            driver = WebDriverFactory.GetDriver(cmdlet, Drivers.HTML);
                            break;
                        default:
                            Console.WriteLine("SeHelper.StartWebDriver");
                            throw new Exception("Invalid value for Drivers");
                    }
                    
                    cmdlet.WriteVerbose(cmdlet, "adding the driver to the collection");
                    string currentInstanceName = string.Empty;
                    try {

                        currentInstanceName =
                            cmdlet.InstanceName[i];

                    } catch {}

                    if (currentInstanceName != null &&
                        currentInstanceName != string.Empty &&
                        currentInstanceName.Length > 0) {

                        cmdlet.WriteVerbose(cmdlet, "the name given is appropriate");
                        addDriverToCollection(cmdlet, currentInstanceName, driver);

                    } else {

                        string driverName = generateDriverName();
                        if (driverName.Length == 0) {
                            //
                        }

                        cmdlet.WriteVerbose(cmdlet, "generating the driver name");
                        addDriverToCollection(cmdlet, driverName, driver);
                    }

                    cmdlet.WriteVerbose(cmdlet, "outputting the driver");
                    cmdlet.WriteObject(cmdlet, driver);

                }
                catch (Exception eWebDriver) {

                    cmdlet.WriteError(
                        cmdlet,
                        "Failed to create the WebDriver: " +
                        cmdlet.DriverName +
                        "\r\n" +
                        eWebDriver.Message,
                        "WebDriverFailed",
                        ErrorCategory.InvalidResult,
                        true);
                }
            }
        }
        
        private static void addDriverToCollection(
            StartDriverCmdletBase cmdlet,
            string driverName,
            IWebDriver driver)
        {
            cmdlet.WriteVerbose(cmdlet, "adding the driver to collection");
            CurrentData.Drivers.Add(driverName, driver);

            try {

                cmdlet.WriteVerbose(cmdlet, "adding the driver's PID to collection");
                CurrentData.DriverPIDs.Add(
                    driverName,
                    SeHelper.DriverProcess.Id);

            }
            catch {}
            try {

                cmdlet.WriteVerbose(cmdlet, "adding the driver's handle to collection");
                CurrentData.DriverHandles.Add(
                    driverName,
                    SeHelper.DriverProcess.MainWindowHandle);

            }
            catch {}
            
            cmdlet.WriteVerbose(cmdlet, "setting CurrentWebDriver");
            CurrentData.CurrentWebDriver = driver;

            try {

                cmdlet.WriteVerbose(cmdlet, "setting CurrentWebDriverPID");
                CurrentData.CurrentWebDriverPID =
                    SeHelper.DriverProcess.Id;

            } catch {

                CurrentData.CurrentWebDriverPID = 0;

            }
            try {

                cmdlet.WriteVerbose(cmdlet, "setting CurrentWebDriverHandle");
                CurrentData.CurrentWebDriverHandle =
                    SeHelper.DriverProcess.MainWindowHandle;

            }
            catch {

                CurrentData.CurrentWebDriverHandle =
                    IntPtr.Zero;

            }
        }
        
        private static string generateDriverName()
        {
            string result = string.Empty;
            
            System.DateTime now =
                System.DateTime.Now;
            result = "driver";
            result += now.Year.ToString();
            result += now.Month.ToString();
            result += now.Day.ToString();
            result += now.Hour.ToString();
            result += now.Minute.ToString();
            result += now.Second.ToString();
            
            return result;
        }
        
        #endregion starting driver
        
        #region Get
        public static void GetWebDriver(PSCmdletBase cmdlet, string[] instanceNames)
        {
            foreach (string instanceName in instanceNames) {
                try {
                    foreach (KeyValuePair<string, IWebDriver> pair in CurrentData.Drivers) {
                        if (pair.Key == instanceName) {
                            cmdlet.WriteObject(cmdlet, CurrentData.Drivers[instanceName]);
                            CurrentData.CurrentWebDriver =
                                CurrentData.Drivers[instanceName];
                        }
                    }
                }
                catch {
                    CurrentData.CurrentWebDriver = null;
                    cmdlet.WriteError(
                        cmdlet,
                        "Unable to get a WebDriver with name '" +
                        instanceName +
                        "'.",
                        "NoSuchWebDriverName",
                        ErrorCategory.InvalidArgument,
                        true);
                }
            }
        }
        
        /// <summary>
        /// Returns the parent IWebElement. This method is used only in the Highlight method.
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        //public static IWebElement GetParentWebElement(IWebElement element)
        internal static IWebElement GetParentWebElement(IWebElement element)
        {
//if (null == element) {
//    Console.WriteLine("GetParentWebElement: null == element");
//} else {
//    Console.WriteLine("GetParentWebElement: null != element");
//}
            IWebElement elementParent = null;
            
            try {
                elementParent =
                    element.FindElement(By.XPath(@".."));
                    //element.FindElement(By.XPath(@"./."));
                    //element.FindElement(By.XPath(@"./.."));
            }
            catch {}
//            catch (Exception eParent) {
//Console.WriteLine(eParent.Message);
//Console.WriteLine(eParent.GetType().Name);
//            }
//Console.WriteLine("GetParentWebElement: before return");
            
            // 20121212
            //return elementParent;
            //return (WebElementDecorator)elementParent;
            return new WebElementDecorator(elementParent as RemoteWebElement);
        }
        
        #endregion Get
        
        #region Actions
        public static bool ClickOnElement(
            PSCmdletBase cmdlet,
            IWebElement[] elements,
            bool clickByWebElementMethod,
            bool clickActionsOnWebElement,
            bool clickActionsDouble,
            bool clickActionsRight,
            bool clickActionsClickAndHold,
            bool clickActionsJustHere)
            //                this,
            //                ((IWebElement)this.InputObject),
            //                this.WebElementMethod,
            //                this.Single,
            //                this.DoubleClick,
            //                this.Right,
            //                this.Hold,
            //                this.Here);
        {
            bool result = false;
            foreach (IWebElement element in elements) {
                try {
                    if (CurrentData.CurrentWebDriver == null) {
                        cmdlet.WriteVerbose(cmdlet, "CurrentData.CurrentWebDriver == null");
                    }
                    Actions builder = new Actions(CurrentData.CurrentWebDriver);
                    IWebElement webElement =
                        element as IWebElement;
                    if (webElement != null) {
                        if (clickByWebElementMethod ||
                            !(clickActionsOnWebElement || clickActionsDouble || clickActionsRight || clickActionsJustHere || clickActionsClickAndHold)) {
                            cmdlet.WriteVerbose(cmdlet, "webElement.Click()");
                            webElement.Click();
                        } else {
                            if (clickActionsRight) {
                                cmdlet.WriteVerbose(cmdlet, "builder.ContextClick(webElement)");
                                builder.ContextClick(webElement).Build().Perform();
                                //this.Single = false;
                            }
                            if (clickActionsDouble) {
                                cmdlet.WriteVerbose(cmdlet, "builder.DoubleClick(webElement)");
                                builder.DoubleClick(webElement).Build().Perform();
                                //this.Single = false;
                            }
                            if (clickActionsClickAndHold) {
                                // 20121029
                                //cmdlet.WriteVerbose(cmdlet, "builder.Click()");
                                cmdlet.WriteVerbose(cmdlet, "builder.ClickAndHold(webElement)");
                                builder.ClickAndHold(webElement).Build().Perform();
                                //this.Single = false;
                            }
                            if (clickActionsJustHere) {
                                // 20121029
                                //cmdlet.WriteVerbose(cmdlet, "builder.ContextClick(webElement)");
                                cmdlet.WriteVerbose(cmdlet, "builder.Click()");
                                builder.Click().Build().Perform();
                                //this.Single = false;
                            }
                            if (clickActionsOnWebElement) {
                                cmdlet.WriteVerbose(cmdlet, "builder.Click(webElement)");
                                builder.Click(webElement).Build().Perform();
                            }
                            //builder.Build().Perform();
                        }
                        cmdlet.WriteObject(cmdlet, webElement);
                        result = true;
                    } else {
                        throw (new Exception("The input is not of IWebElement type"));
                    }
                }
                catch (Exception eFailed) {
                    string errorMessage =
                        "The Click() method has failed";
                    ErrorRecord err =
                        new ErrorRecord(
                            new Exception(errorMessage),
                            "ClickFailed",
                            ErrorCategory.InvalidArgument,
                            element);
                    err.ErrorDetails =
                        new ErrorDetails(errorMessage);
                }
            }
            return result;
        }
        
        public static bool DragAndDropOnElement(PSCmdletBase cmdlet, IWebElement[] sourceElements, IWebElement targetElement)
        {
            bool result = false;
            
            foreach (IWebElement element in sourceElements) {
                
            }
            
            return result;
        }
        
        
        public static bool MoveCursorToElement(PSCmdletBase cmdlet, IWebElement[] elements, int x, int y)
        {
            bool result = false;
            foreach (IWebElement element in elements) {
                try {
                    if (CurrentData.CurrentWebDriver == null) {
                        cmdlet.WriteVerbose(cmdlet, "CurrentData.CurrentWebDriver == null");
                        throw (new Exception("CurrentData.CurrentWebDriver == null"));
                    }
                    //                Actions builder = new Actions(CurrentData.CurrentWebDriver);
                    IWebElement webElement =
                        element as IWebElement;
                    //Actions builder2 = null;
                    //WriteVerbose(this, webElement.TagName);
                    
                    if (webElement != null) {
                        if ((x + y) == 0) {
                            //builder2 =
                            //                        builder.MoveToElement(webElement).Build().Perform(); //.Release(webElement);\
                            cmdlet.WriteVerbose(cmdlet, "Performing move to the element");
                            ((IHasInputDevices)CurrentData.CurrentWebDriver).Mouse.MouseMove(
                                //((RemoteWebElement)webElement).Coordinates);
                                ((ILocatable)webElement).Coordinates);
                        } else {
                            //builder2 =
                            //                        builder.MoveToElement(
                            //                            webElement,
                            //                            this.X,
                            //                            this.Y).Build().Perform(); //.Release(webElement);
                            cmdlet.WriteVerbose(cmdlet, "Performing move to the element, with offsets");
                            ((IHasInputDevices)CurrentData.CurrentWebDriver).Mouse.MouseMove(
                                //((RemoteWebElement)webElement).Coordinates,
                                ((ILocatable)webElement).Coordinates,
                                x,
                                y);
                        }
                        //builder.Perform();
                        //builder2.Perform();
                        //builder.Build().Perform()
                        
                        cmdlet.WriteObject(cmdlet, webElement);
                        result = true;
                    } else {
                        throw (new Exception("The input is not of IWebElement type"));
                    }
                }
                catch (Exception eFailed) {
                    cmdlet.WriteError(
                        cmdlet,
                        "The Click() method has failed." +
                        eFailed.Message,
                        "ClickFailed",
                        ErrorCategory.InvalidArgument,
                        true);
                }
            }
            return result;
        }
        #endregion Actions
        
        #region Convert
        public static List<AutomationElement> ConvertWebDriverOrWebElementToAutomationElement(
            HasWebElementInputCmdletBase cmdlet,
            //IWebDriver[] drivers)
            object[] drivers)
        {
            System.Collections.Generic.List<AutomationElement> resultElements =
                new System.Collections.Generic.List<AutomationElement>();
            
            //foreach (IWebDriver driver in drivers) {
            foreach (object webDriverOrElement in drivers) {
                AutomationElement resultElement = null;
                
                if (null != (webDriverOrElement as IWebDriver)) {
                    
                    resultElement =
                        System.Windows.Automation.AutomationElement.RootElement.FindFirst(
                            TreeScope.Children,
                            new PropertyCondition(
                                AutomationElement.ProcessIdProperty,
                                CurrentData.CurrentWebDriverPID));
                    
                    if (resultElement != null) {
                        cmdlet.WriteObject(cmdlet, resultElement);
                        resultElements.Add(resultElement);
                    } else {
                        cmdlet.WriteError(
                            cmdlet,
                            "Unable to convert the driver to an object of the AutomationElement type",
                            "FailedToConvert",
                            ErrorCategory.InvalidArgument,
                            false); // ??
                    }
                    
                }
                
                if (null != (webDriverOrElement as IWebElement) ) {
                    //
                    int[] absoluteCoordinates =
                        // 20121212
                        //getWebElementCoordinates((webDriverOrElement as RemoteWebElement));
                        getWebElementCoordinates((webDriverOrElement as WebElementDecorator));
                    resultElement =
                        System.Windows.Automation.AutomationElement.FromPoint(
                            new System.Windows.Point(
                                absoluteCoordinates[0],
                                absoluteCoordinates[1]));
                    
                    if (null != resultElement) {
                        if (((RemoteWebElement)webDriverOrElement).Size.Height != resultElement.Current.BoundingRectangle.Height &&
                            ((RemoteWebElement)webDriverOrElement).Size.Width != resultElement.Current.BoundingRectangle.Width) {
                            
                            // nothing to return yet !!!!!!!!
                            cmdlet.WriteError(
                                cmdlet,
                                "Unable to get an AutomationElement that matches the size of the corresponding web element",
                                "FailedToConvert",
                                ErrorCategory.InvalidArgument,
                                false); // ??
                            
                        } else {
                            cmdlet.WriteObject(cmdlet, resultElement);
                            resultElements.Add(resultElement);
                        }
                    } else {
                        cmdlet.WriteError(
                            cmdlet,
                            "Unable to convert the element to an object of the AutomationElement type",
                            "FailedToConvert",
                            ErrorCategory.InvalidArgument,
                            false); // ??
                    }
                    //
                    //
                }
            }
            return resultElements;
        }
        
        //        public static List<AutomationElement> ConvertWebElementToAutomationElement(
        //            HasWebElementInputCmdletBase cmdlet,
        //            IWebElement[] elements)
        //        {
        //            System.Collections.Generic.List<AutomationElement> resultElements =
        //                new System.Collections.Generic.List<AutomationElement>();
//
        //            foreach (IWebElement element in elements) {
//
//
//
//
        //            }
//
        //            return resultElements;
        //        }
        #endregion Convert
        
        #region Driver
        public static bool CloseCurrentBrowserWindow(PSCmdletBase cmdlet, IWebDriver[] drivers)
        {
            bool result = false;
            
            foreach (IWebDriver driver in drivers) {
                
                try {
                    driver.Close();
                    cmdlet.WriteObject(cmdlet, driver);
                }
                catch (Exception eFailed) {
                    cmdlet.WriteError(
                        cmdlet,
                        "The Close() method has failed." +
                        eFailed.Message,
                        "CloseFailed",
                        ErrorCategory.InvalidArgument,
                        true);
                }
            }
            
            return result;
        }
        
        public static bool GetCookies(PSCmdletBase cmdlet, IWebDriver[] drivers)
        {
            bool result = false;
            
            foreach (IWebDriver driver in drivers) {
                
                try {
                    ICookieJar cookie = driver.Manage().Cookies;
                    cmdlet.WriteObject(cmdlet, cookie);
                }
                catch (Exception eFailed) {
                    cmdlet.WriteError(
                        cmdlet,
                        "The Manage()Cookies property has failed." +
                        eFailed.Message,
                        "CookiesFailed",
                        ErrorCategory.InvalidArgument,
                        true);
                }
            }
            
            return result;
        }
        
        public static bool GetWindow(PSCmdletBase cmdlet, IWebDriver[] drivers)
        {
            bool result = false;
            
            foreach (IWebDriver driver in drivers) {
                
                try {
                    IWindow window = driver.Manage().Window;
                    cmdlet.WriteObject(cmdlet, window);
                }
                catch (Exception eFailed) {
                    cmdlet.WriteError(
                        cmdlet,
                        "The Manage().Window property has failed." +
                        eFailed.Message,
                        "WindowFailed",
                        ErrorCategory.InvalidArgument,
                        true);
                }
            }
            
            return result;
        }
        
        public static bool GetNativeWindowHandle(PSCmdletBase cmdlet, IWebDriver[] drivers, bool onlyMain)
        {
            bool result = false;
            
            foreach (IWebDriver driver in drivers) {
                
                try {
                    
                    string driverKey = string.Empty;
                    foreach (KeyValuePair<string, IWebDriver> pair in CurrentData.Drivers) {
                        if (driver == pair.Value) {
                            driverKey = pair.Key;
                            break;
                        }
                    }
                    
                    if (onlyMain) {
                        
                        cmdlet.WriteObject(cmdlet, CurrentData.DriverHandles[driverKey]);
                        
                    } else {

                        int processId =
                            CurrentData.DriverPIDs[driverKey];
                        
                        AutomationElementCollection driverWindows =
                            System.Windows.Automation.AutomationElement.RootElement.FindAll(
                                TreeScope.Children,
                                new PropertyCondition(
                                    AutomationElement.ProcessIdProperty,
                                    processId));
                        
                        if (null != driverWindows) {
                            foreach (AutomationElement wnd in driverWindows) {
                                cmdlet.WriteObject(cmdlet, wnd.Current.NativeWindowHandle);
                            }
                        }
                    }
                }
                catch (Exception eFailed) {
                    cmdlet.WriteError(
                        cmdlet,
                        "The Close() method has failed." +
                        eFailed.Message,
                        "nativeWindowHandleFailed",
                        ErrorCategory.InvalidArgument,
                        true);
                }
            }
            
            return result;
        }
        
        public static bool GetPageSource(PSCmdletBase cmdlet, IWebDriver[] drivers)
        {
            bool result = false;
            
            foreach (IWebDriver driver in drivers) {
                
                try {
                    cmdlet.WriteObject(cmdlet, driver.PageSource);
                }
                catch (Exception eFailed) {
                    cmdlet.WriteError(
                        cmdlet,
                        "The PageSource property has failed." +
                        eFailed.Message,
                        "PageSourceFailed",
                        ErrorCategory.InvalidArgument,
                        true);
                }
            }
            
            return result;
        }
        
        public static bool GetTitle(PSCmdletBase cmdlet, IWebDriver[] drivers)
        {
            bool result = false;
            
            foreach (IWebDriver driver in drivers) {
                
                try {
                    cmdlet.WriteObject(cmdlet, driver.Title);
                }
                catch (Exception eFailed) {
                    cmdlet.WriteError(
                        cmdlet,
                        "The Title property has failed." +
                        eFailed.Message,
                        "TitleFailed",
                        ErrorCategory.InvalidArgument,
                        true);
                }
            }
            
            return result;
        }
        
        public static bool GetUrl(PSCmdletBase cmdlet, IWebDriver[] drivers)
        {
            bool result = false;
            Console.WriteLine("GetUrl 02");
            if (null == drivers) {
                Console.WriteLine("null == drivers");
            } else {
                if (0 == drivers.Length) {
                    Console.WriteLine("0 == drivers.Length");
                } else {
                    Console.WriteLine("valid drivers");
                }
            }
            foreach (IWebDriver driver in drivers) {
                Console.WriteLine("GetUrl 02");
                if (null == driver) {
                    Console.WriteLine("null == driver");
                } else {
                    Console.WriteLine(driver.GetType().Name);
                    Console.WriteLine(driver.Url);
                }
                try {
                    Console.WriteLine("GetUrl 03");
                    cmdlet.WriteObject(cmdlet, driver.Url);
                    Console.WriteLine("GetUrl 04");
                }
                catch (Exception eFailed) {
                    Console.WriteLine("GetUrl 05");
                    cmdlet.WriteError(
                        cmdlet,
                        "The Url property has failed." +
                        eFailed.Message,
                        "UrlFailed",
                        ErrorCategory.InvalidArgument,
                        true);
                }
            }
            Console.WriteLine("GetUrl 06");
            return result;
        }
        
        public static bool SetDriverTimeout(
            PSCmdletBase cmdlet,
            IWebDriver[] drivers,
            DriverTimeoutTypes timeoutType,
            double timeoutValue)
        {
            bool result = false;
            
            foreach (IWebDriver driver in drivers) {
                
                try {
                    
                    switch (timeoutType) {
                        case SePSX.DriverTimeoutTypes.ImplicitlyWait:
                            cmdlet.WriteVerbose(cmdlet, "ImplicitlyWaitTimeout");
                            driver.Manage().Timeouts().ImplicitlyWait(System.TimeSpan.FromMilliseconds(timeoutValue));
                            break;
                        case SePSX.DriverTimeoutTypes.PageLoad:
                            cmdlet.WriteVerbose(cmdlet, "PageLoadTimeout");
                            driver.Manage().Timeouts().SetPageLoadTimeout(System.TimeSpan.FromMilliseconds(timeoutValue));
                            break;
                        case SePSX.DriverTimeoutTypes.Script:
                            cmdlet.WriteVerbose(cmdlet, "ScriptTimeout");
                            driver.Manage().Timeouts().SetScriptTimeout(System.TimeSpan.FromMilliseconds(timeoutValue));
                            break;
                            //default:
                            //    throw new Exception("Invalid value for DriverTimeoutTypes");
                    }
                    cmdlet.WriteObject(cmdlet, driver);
                }
                catch (Exception eFailed) {
                    cmdlet.WriteError(
                        cmdlet,
                        "The Manage().Timeouts() method has failed. " +
                        eFailed.Message,
                        "SetTimeoutFailed",
                        ErrorCategory.InvalidArgument,
                        true);
                }
            }
            
            return result;
        }
        #endregion Driver
        
        #region Element
        
        // 20120903
        public static void GetWebElement(PSCmdletBase cmdlet, object[] elements) // the second parameter?
        {
            // 20120903
            GetCmdletBase cmdletGet = (GetCmdletBase)cmdlet;
            
            ReadOnlyCollection<IWebElement> result =
                new ReadOnlyCollection<IWebElement>(new List<IWebElement>());
            bool firstVsAll = cmdletGet.First;
            cmdletGet.WriteVerbose(cmdletGet, "only the first element? " + firstVsAll.ToString());
//Console.WriteLine("GetWebElement: 00003");
            foreach (object inputObject in cmdletGet.InputObject) {
//Console.WriteLine("GetWebElement: 00004");
//Console.WriteLine("GetWebElement: inputObject = " + inputObject.GetType().Name);
                string errorReport = string.Empty;
                try {
//Console.WriteLine("GetWebElement: 00005");
                    if (cmdletGet.Id != null && cmdletGet.Id != string.Empty && cmdletGet.Id.Length > 0) {
//Console.WriteLine("GetWebElement: 00006 id");
                        errorReport = "Id = \"" + cmdletGet.Id + "\"";
                        result =
                            getWebElement(
                                cmdletGet,
                                inputObject,
                                FindElementParameters.ById,
                                cmdletGet.Id,
                                firstVsAll); //true);
//Console.WriteLine("GetWebElement: 00007 id");
                    } //else
                    
                    if (cmdletGet.ClassName != null && cmdletGet.ClassName != string.Empty && cmdletGet.ClassName.Length > 0) {
//Console.WriteLine("GetWebElement: 00008 cl");
                        errorReport = "ClassName = \"" + cmdletGet.ClassName + "\"";
                        result =
                            getWebElement(
                                cmdletGet,
                                inputObject,
                                FindElementParameters.ByClassName,
                                cmdletGet.ClassName,
                                firstVsAll); //true);
//Console.WriteLine("GetWebElement: 00009 cl");
                    } //else
                    
                    if (cmdletGet.TagName != null && cmdletGet.TagName != string.Empty && cmdletGet.TagName.Length > 0) {
//Console.WriteLine("GetWebElement: 00010 tag");
                        errorReport = "TagName = \"" + cmdletGet.TagName + "\"";
//Console.WriteLine("GetWebElement: 00010-1 tag");
                        result =
                            getWebElement(
                                cmdletGet,
                                inputObject,
                                FindElementParameters.ByTagName,
                                cmdletGet.TagName,
                                firstVsAll); //true);
//Console.WriteLine("GetWebElement: 00011 tag");
                    } //else
                    
                    if (cmdletGet.Name != null && cmdletGet.Name != string.Empty && cmdletGet.Name.Length > 0) {
//Console.WriteLine("GetWebElement: 00012 name");
                        errorReport = "Name = \"" + cmdletGet.Name + "\"";
                        result =
                            getWebElement(
                                cmdletGet,
                                inputObject,
                                FindElementParameters.ByName,
                                cmdletGet.Name,
                                firstVsAll); //true);
//Console.WriteLine("GetWebElement: 00013 name");
                    } //else
                    
                    if (cmdletGet.LinkText != null && cmdletGet.LinkText != string.Empty && cmdletGet.LinkText.Length > 0) {
//Console.WriteLine("GetWebElement: 00014 link");
                        errorReport = "LinkText = \"" + cmdletGet.LinkText + "\"";
                        result =
                            getWebElement(
                                cmdletGet,
                                inputObject,
                                FindElementParameters.ByLinkText,
                                cmdletGet.LinkText,
                                firstVsAll); //true);
//Console.WriteLine("GetWebElement: 00015 link");
                    } //else
                    
                    if (cmdletGet.PartialLinkText != null && cmdletGet.PartialLinkText != string.Empty && cmdletGet.PartialLinkText.Length > 0) {
//Console.WriteLine("GetWebElement: 00016 partlink");
                        errorReport = "PartialLinkText = \"" + cmdletGet.PartialLinkText + "\"";
                        result =
                            getWebElement(
                                cmdletGet,
                                inputObject,
                                FindElementParameters.ByPartialLinkText,
                                cmdletGet.PartialLinkText,
                                firstVsAll); //true);
//Console.WriteLine("GetWebElement: 00017 partlink");
                    } //else
                    
                    if (cmdletGet.CssSelector != null && cmdletGet.CssSelector != string.Empty && cmdletGet.CssSelector.Length > 0) {
//Console.WriteLine("GetWebElement: 00018 css");
                        errorReport = "CSS = \"" + cmdletGet.CssSelector + "\"";
                        result =
                            getWebElement(
                                cmdletGet,
                                inputObject,
                                FindElementParameters.ByCSS,
                                cmdletGet.CssSelector,
                                firstVsAll); //true);
//Console.WriteLine("GetWebElement: 00019 css");
                    } //else
                    
                    if (cmdletGet.XPath != null && cmdletGet.XPath != string.Empty && cmdletGet.XPath.Length > 0) {
//Console.WriteLine("GetWebElement: 00020 xpath");
                        errorReport = "XPath = \"" + cmdletGet.XPath + "\"";
                        result =
                            getWebElement(
                                cmdletGet,
                                inputObject,
                                FindElementParameters.ByXPath,
                                cmdletGet.XPath,
                                firstVsAll); //true);
//Console.WriteLine("GetWebElement: 00021 xpath");
                    }
                    
                    if (cmdletGet.JavaScript != null && cmdletGet.JavaScript != string.Empty && cmdletGet.JavaScript.Length > 0) {
//Console.WriteLine("GetWebElement: 00022 JS");
                        errorReport = "JavaScript = \"" + cmdletGet.JavaScript.Substring(0, 10) + "...\"";
                        result =
                            getWebElement(
                                cmdletGet,
                                inputObject,
                                FindElementParameters.ByJavaScript,
                                cmdletGet.JavaScript,
                                firstVsAll); //true);
//Console.WriteLine("GetWebElement: 00023 JS");
                    }
                    
                    //            	else {
                    //            		errorReport = "All = \"\"";
                    //                    result =
                    //                    	getWebElement(
                    //                            cmdletGet.InputObject,
                    //                            FindElementParameters.All,
                    //                            cmdletGet.XPath,
                    //                            true);
                    //            	}
                    
                    cmdletGet.WriteVerbose(cmdletGet, "returning results");
                    try { cmdletGet.WriteVerbose(cmdletGet, result.Count.ToString()); } catch {}
                    try { cmdletGet.WriteVerbose(cmdletGet, result.ToString()); } catch {}
                    try { cmdletGet.WriteVerbose(cmdletGet, result[0].ToString()); } catch {}
                    if (result.Count > 0) {
//Console.WriteLine("GetWebElement: 00025: result.Count > 0");
                        cmdletGet.WriteVerbose(cmdletGet, "The result is a set of " + result.Count.ToString() + " elements");
                        //WriteObject(cmdletGet, result[0]);
                        //WriteObject(cmdletGet, result);
//if (null == result) {
//    Console.WriteLine("(null == result)");
//} else {
//    Console.WriteLine("(null != result)");
//    Console.WriteLine(result.GetType().Name);
//    Console.WriteLine(result.Count);
//}
                        foreach (var elementOfTheResult in result) {
//Console.WriteLine("GetWebElement: 00026");
//Console.WriteLine("elementOfTheResult.GetType().Name = " + elementOfTheResult.GetType().Name);
//Console.WriteLine("GetWebElement: 00026-2");
//Console.WriteLine(elementOfTheResult.Text);
//if (null == cmdletGet) {
//    Console.WriteLine("null == cmdletGet");
//} else {
//    Console.WriteLine("null != cmdletGet");
//}
//if (null == elementOfTheResult) {
//    Console.WriteLine("null == elementOfTheResult");
//} else {
//    Console.WriteLine("null != elementOfTheResult");
//}
                            cmdletGet.WriteObject(cmdletGet, elementOfTheResult);
//Console.WriteLine("GetWebElement: 00027");
                        }
                    } else {
//Console.WriteLine("GetWebElement: 00028");
                        cmdletGet.WriteVerbose(cmdletGet, "The result is an empty collection");
                        cmdletGet.WriteObject(cmdletGet, (object)null);
//Console.WriteLine("GetWebElement: 00029");
                    }
                }
                catch (Exception eFindByException) {
//Console.WriteLine("GetWebElement: 00030");
                    cmdletGet.WriteError(
                        cmdletGet,
                        "Could not find an element by its " +
                        errorReport +
                        "\r\n" +
                        eFindByException.Message,
                        "FailedToFindElement",
                        ErrorCategory.InvalidArgument,
                        true);
                }
            }
            
            
            //return result;
        }
        
        // 20120903
        private static ReadOnlyCollection<IWebElement> getWebElement(
            GetCmdletBase cmdlet,
            object element,
            SePSX.FindElementParameters parameterId,
            string parameterValue,
            bool oneElement)
        {
            cmdlet.WriteVerbose(cmdlet, "The name of the parameter used is '" + parameterId.ToString() + "'");
            cmdlet.WriteVerbose(cmdlet, "The value of the parameter used equals to '" + parameterValue + "'");

            IWebDriver webDriver = null;
            IWebElement webElement = null;
            // 20120903
            //bool wait = true;
            
            try {
//Console.WriteLine("getWebElement: 00001");
                webDriver =
                    //((PSObject)element).BaseObject as IWebDriver;
                    //((PSObject)element).BaseObject as IWebDriver;
                    element as IWebDriver;
//Console.WriteLine("getWebElement: 00002");
                cmdlet.WriteVerbose(cmdlet, "getWebElement -> checking webDriver");
                if (webDriver == null) {
                    throw (new Exception("The input object is not of IWebDriver type"));
                }
                cmdlet.WriteVerbose(cmdlet, "element -> webDriver");
            }
            catch (Exception eee1) {
                cmdlet.WriteVerbose(cmdlet, "error 1");
                cmdlet.WriteVerbose(cmdlet, eee1.Message);
                
                try {
//Console.WriteLine("getWebElement: 00005");
                    webElement =
                        //((PSObject)element).BaseObject as IWebElement;
                        //((PSObject)element).BaseObject as IWebElement;
                        element as IWebElement;
//Console.WriteLine("getWebElement: 00006");
                    cmdlet.WriteVerbose(cmdlet, "getWebElement -> checking webElement");
                    if (webElement == null) {
                        throw (new Exception("The input object is not of IWebElement type"));
                    }
                    cmdlet.WriteVerbose(cmdlet, "element -> webElement");
                }
                catch (Exception eee2) {
                    cmdlet.WriteVerbose(cmdlet, "error 2");
                    cmdlet.WriteVerbose(cmdlet, eee2.Message);
                }
            }
            
            ReadOnlyCollection<IWebElement> result = null;
            List<IWebElement> listOfResults = new List<IWebElement>();
//Console.WriteLine("getWebElement: 00009");
            string errorReport = string.Empty;
            OpenQA.Selenium.By by = null;
            
            cmdlet.WriteVerbose(cmdlet, "select By");
            switch (parameterId) {
                case FindElementParameters.ByClassName:
                    errorReport = "ClassName";
                    by = By.ClassName(parameterValue);
                    break;
                case FindElementParameters.ByCSS:
                    errorReport = "CSS";
                    by = By.CssSelector(parameterValue);
                    break;
                case FindElementParameters.ById:
                    errorReport = "Id";
                    by = By.Id(parameterValue);
                    break;
                case FindElementParameters.ByLinkText:
                    errorReport = "LinkText";
                    by = By.LinkText(parameterValue);
                    break;
                case FindElementParameters.ByName:
                    errorReport = "Name";
                    by = By.Name(parameterValue);
                    break;
                case FindElementParameters.ByPartialLinkText:
                    errorReport = "PartialLinkText";
                    by = By.PartialLinkText(parameterValue);
                    break;
                case FindElementParameters.ByTagName:
                    errorReport = "TagName";
                    by = By.TagName(parameterValue);
                    break;
                case FindElementParameters.ByXPath:
                    errorReport = "XPath";
                    by = By.XPath(parameterValue);
                    break;
                case FindElementParameters.ByJavaScript:
                    errorReport = "JavaScript";
                    by = null;
                    break;
                    //                case FindElementParameters.All:
                    //                    by = null;
                    //                    break;
            }
//Console.WriteLine("getWebElement: 00012");
            if (parameterId == FindElementParameters.ByJavaScript) {
                errorReport += " = \"" + parameterValue.Substring(0, 10) + "\"";
            } else {
                errorReport += " = \"" + parameterValue + "\"";
            }
            cmdlet.WriteVerbose(cmdlet, "error report: " + errorReport);
            
            
            System.DateTime startTime =
                System.DateTime.Now;
            
            do {
                
                try {
//Console.WriteLine("getWebElement: 00015");
                    if (webDriver != null) {
                        cmdlet.WriteVerbose(cmdlet, "IWebDriver as input");
//Console.WriteLine("getWebElement: 00016");
                        if (oneElement) {
                            cmdlet.WriteVerbose(cmdlet, "one element, IWebDriver as input");
//Console.WriteLine("getWebElement: 00017");
                            if (by != null) {
//Console.WriteLine("getWebElement: 00018");
                                listOfResults.Add((webDriver.FindElement(by)));
                            } else {
//Console.WriteLine("getWebElement: 00019");
                                listOfResults.Add(
                                    ((IWebElement)((IJavaScriptExecutor)webDriver).ExecuteScript(
                                        parameterValue,
                                        (new string[] { string.Empty })
                                       )));
                            }
//Console.WriteLine("getWebElement: 00020");
                            result =
                                new ReadOnlyCollection<IWebElement>(listOfResults);
//Console.WriteLine("getWebElement: 00021");
                        } else {
//Console.WriteLine("getWebElement: 00022");
                            cmdlet.WriteVerbose(cmdlet, "a set of elements, IWebDriver as input");
                            if (by != null) {
//Console.WriteLine("getWebElement: 00023: webDriver.GetType().Name = " + webDriver.GetType().Name);
//Console.WriteLine(webDriver.Url);
//Console.WriteLine("webDriver.Elements.Count = " + webDriver.Elements.Count.ToString());
                                cmdlet.WriteVerbose(cmdlet, "finding a set of elements, with by");
                                result = webDriver.FindElements(by);
//Console.WriteLine("getWebElement: 00024");
//Console.WriteLine("getWebElement: 00024 Count = " + result.Count.ToString());
//Console.WriteLine("getWebElement: 00024 type = " + result[0].GetType().Name);
//try {
//Console.WriteLine("getWebElement: 00024 ((RemoteWebElement)result[0]) = " + ((RemoteWebElement)result[0]));
//var fakeRemoteWebElement =
//    result[0];
//Console.WriteLine("getWebElement: 00024 fakeRemoteWebElement.GetType().Name = " + fakeRemoteWebElement.GetType().Name);
//Console.WriteLine("getWebElement: 00024 ((RemoteWebElement)fakeRemoteWebElement).GetType().Name = " + ((RemoteWebElement)fakeRemoteWebElement).GetType().Name);
//
////Console.WriteLine("getWebElement: 00024 ((RemoteWebElement)fakeRemoteWebElement).Enabled = " + ((RemoteWebElement)fakeRemoteWebElement).Enabled.ToString());
////Console.WriteLine("getWebElement: 00024 ((RemoteWebElement)fakeRemoteWebElement).TagName = " + ((RemoteWebElement)fakeRemoteWebElement).TagName);
////Console.WriteLine("getWebElement: 00024 fakeRemoteWebElement.TagName = " + fakeRemoteWebElement.TagName);
////Console.WriteLine("getWebElement: 00024 ((RemoteWebElement)result[0]).TagName = " + ((RemoteWebElement)result[0]).TagName);
//} catch (Exception e00024) {
//    Console.WriteLine(e00024.Message);
//    Console.WriteLine(e00024.GetType().Name);
//}
                            } else {
//Console.WriteLine("getWebElement: 00025");
                                //listOfResults =
                                cmdlet.WriteVerbose(cmdlet, "finding a set of elements, without by, with JS");
                                var scriptResults =
                                    //(IList<IWebElement>)((IJavaScriptExecutor)webDriver).ExecuteScript(parameterValue);
                                    //(IList<IWebElement>)
                                    ((IJavaScriptExecutor)webDriver).ExecuteScript(
                                        parameterValue,
                                        (new string[] { string.Empty })
                                       );
//Console.WriteLine("getWebElement: 00026");
                                result =
                                    new ReadOnlyCollection<IWebElement>((IList<IWebElement>)scriptResults);
//Console.WriteLine("getWebElement: 00027");
                            }
                        }
                    }
                    
                    if (webElement != null) {
                        cmdlet.WriteVerbose(cmdlet, "IWebElement as input");
                        if (oneElement) {
//Console.WriteLine("getWebElement: 00028");
                            cmdlet.WriteVerbose(cmdlet, "one element, IWebElement as input");
                            if (by != null) {
//Console.WriteLine("getWebElement: 00029");
                                listOfResults.Add((webElement.FindElement(by)));
                            } else {
//Console.WriteLine("getWebElement: 00030");
                                listOfResults.Add(
                                    ((IWebElement)((IJavaScriptExecutor)webElement).ExecuteScript(
                                        parameterValue,
                                        (new string[] { string.Empty })
                                       )));
//Console.WriteLine("getWebElement: 00031");
                            }
                            result =
                                new ReadOnlyCollection<IWebElement>(listOfResults);
//Console.WriteLine("getWebElement: 00032");
                        } else {
//Console.WriteLine("getWebElement: 00033");
                            cmdlet.WriteVerbose(cmdlet, "a set of elements, IWebElement as input");
                            if (by != null) {
//Console.WriteLine("getWebElement: 00034");
                                result = webElement.FindElements(by);
                            } else {
//Console.WriteLine("getWebElement: 00035");
                                //listOfResults =
                                var scriptResults =
                                    //(IList<IWebElement>)((IJavaScriptExecutor)webElement).ExecuteScript(parameterValue);
                                    //(IList<IWebElement>)
                                    ((IJavaScriptExecutor)webElement).ExecuteScript(
                                        parameterValue,
                                        (new string[] { string.Empty })
                                       );
//Console.WriteLine("getWebElement: 00036");
                                result =
                                    new ReadOnlyCollection<IWebElement>((IList<IWebElement>)scriptResults);
//Console.WriteLine("getWebElement: 00037");
                            }
                        }
                    }
                }
                catch {}
                
                //cmdlet.WriteVerbose(cmdlet, "further");
                if (result.Count > 0) {
//Console.WriteLine("getWebElement: 00038");
                    //cmdlet.WriteVerbose(cmdlet, "(result.Count > 0");
                    //cmdlet.Wait = false;
                    //wait = false;
                    waitForElement = false;
                }
                
                cmdlet.WriteVerbose(cmdlet, "startTime = " + startTime.ToString());
                if ((System.DateTime.Now - startTime).TotalSeconds >
                    (cmdlet.Timeout / 1000) &&
                    //cmdlet.Wait) {
                    //wait) {
                    waitForElement) {
//Console.WriteLine("getWebElement: 00039");
                    //cmdlet.Wait = false;
                    cmdlet.WriteVerbose(cmdlet, "Time spent: " + (System.DateTime.Now - startTime).TotalSeconds + " seconds");
                    //cmdlet.WriteVerbose(cmdlet, "(System.DateTime.Now - startTime).TotalSeconds = " + (System.DateTime.Now - startTime).TotalSeconds);
                    //cmdlet.WriteVerbose(cmdlet, "cmdlet.Wait = " + cmdlet.Wait.ToString());
                    //cmdlet.WriteVerbose(cmdlet, "the Timeout = " + (cmdlet.Timeout / 1000).ToString());
                    //cmdlet.WriteVerbose(cmdlet, "the decision: " + ((System.DateTime.Now - startTime).TotalSeconds - (cmdlet.Timeout / 1000)).ToString());
                    
                    cmdlet.WriteError(
                        cmdlet,
                        "The timeout expired for WebElement with " +
                        errorReport,
                        "TimeoutExpired",
                        ErrorCategory.OperationTimeout,
                        true);
                }
//Console.WriteLine("getWebElement: 00040");
                System.Threading.Thread.Sleep(Preferences.OnSleepDelay);
//Console.WriteLine("getWebElement: 00041");
            } while (waitForElement); //(wait); //(cmdlet.Wait);
            
            
            
            
            
//Console.WriteLine("result.Count = " + result.Count.ToString());
//Console.WriteLine("result[0] = " + result[0].GetType().Name);
//try {
//    Console.WriteLine("result[0].Text = " + result[0].Text);
//} catch (Exception eText) {
//    Console.WriteLine(eText.Message);
//    Console.WriteLine(eText.GetType().Name);
//}
            
            
            
            
            
            
            
            
            //return result;
            return GetDecoratedCollection<IWebElement>(result, webElement, @by);
        }

        // 20121212
//        public static ReadOnlyCollection<IWebElement> GetDecoratedCollection(
//            ReadOnlyCollection<IWebElement> inputCollection,
//            IWebElement inputWebElement,
//            OpenQA.Selenium.By @by)
        public static ReadOnlyCollection<IWebElement> GetDecoratedCollection<T>(
            ReadOnlyCollection<IWebElement> inputCollection,
            IWebElement inputWebElement,
            OpenQA.Selenium.By @by)
        {
//Console.WriteLine("GetDecoratedCollection: 00001");
List<IWebElement> resultList;
try{
            int position = 0;
            //List<IWebElement> resultList =
            resultList =
                //WebDriverFactory.Container.Resolve<System.Collections.Generic.List<IWebElement>>();
                new List<IWebElement>();
                //new List<T>();
            //foreach (IWebElement resultWebElement in inputCollection) {
            foreach (RemoteWebElement resultWebElement in inputCollection) {
            //foreach (T resultWebElement in inputCollection) {
//Console.WriteLine("GetDecoratedCollection: 00002");
                ISearchHistory history = WebDriverFactory.Container.Resolve<SearchHistory>();
//Console.WriteLine("GetDecoratedCollection: 00003");
                history.ByType = @by;
//Console.WriteLine("GetDecoratedCollection: 00004");
//if (null == resultWebElement) {
//    Console.WriteLine("null == resultWebElement");
//} else {
//    Console.WriteLine("null != resultWebElement");
//}
//if (null == history) {
//    Console.WriteLine("null == history");
//} else {
//    Console.WriteLine("null != history");
//}
//Console.WriteLine(resultWebElement.GetType().Name);
//try {
//if (null == ((RemoteWebElement)resultWebElement)) {
//    Console.WriteLine("null == ((RemoteWebElement)resultWebElement)");
//} else {
//    Console.WriteLine("null != ((RemoteWebElement)resultWebElement)");
//    //Console.WriteLine(((FakeRemoteWebElement)resultWebElement).TagName);
//}
//} catch (Exception e00000000) {
//    Console.WriteLine(e00000000.Message);
//    Console.WriteLine(e00000000.GetType().Name);
//}
//Console.WriteLine("GetDecoratedCollection: 00005:");
//Console.WriteLine("resultWebElement.GetType().Name = " + resultWebElement.GetType().Name);
//Console.WriteLine("resultWebElement.TagName = " + resultWebElement.TagName);
                //history.ByValue
                history.PositionInResult = position;
                IWebElement decorator =
                    //WebDriverFactory.Container.Resolve<WebElementDecorator>(); //(new NamedParameter("realWebElement", resultWebElement));
                    //new WebElementDecorator((RemoteWebElement)resultWebElement);
                    new WebElementDecorator(resultWebElement);
                
//Console.WriteLine("GetDecoratedCollection: 00006:");
//Console.WriteLine("GetDecoratedCollection: 00006+: " + ((WebElementDecorator)decorator).DecoratedWebElement.ToString());
//Console.WriteLine("GetDecoratedCollection: 00007: tagName = " + ((WebElementDecorator)decorator).TagName);
                
//Console.WriteLine("GetDecoratedCollection: 00005");
                //((WebElementDecorator)decorator).DecoratedElement = 
                //    (RemoteWebElement)inputWebElement;
                
                if (null != inputWebElement) {
                    ((WebElementDecorator)decorator).SearchHistory = ((WebElementDecorator)inputWebElement).SearchHistory;
                }
                
                ((WebElementDecorator)decorator).SearchHistory.Add(history);
                resultList.Add(decorator);
                position++;
            }
            return (new ReadOnlyCollection<IWebElement>(resultList));
            //return (new ReadOnlyCollection<T>(resultList));
            
        }catch(Exception eeeeeeeeeeeeeeeeeeeeee){
    Console.WriteLine(eeeeeeeeeeeeeeeeeeeeee.Message);
    Console.WriteLine(eeeeeeeeeeeeeeeeeeeeee.GetType().Name);
    return (new ReadOnlyCollection<IWebElement>(new List<IWebElement>()));
    //return (new ReadOnlyCollection<T>(new List<T>()));
}
        }
        
        public static bool ClearWebElement(PSCmdletBase cmdlet, IWebElement[] elements)
        {
            bool result = false;
            foreach (IWebElement element in elements) {
                try {
                    (element as IWebElement).Clear();
                    cmdlet.WriteObject(cmdlet, (element as IWebElement));
                    result = true;
                }
                catch (Exception eFailed) {
                    cmdlet.WriteError(
                        cmdlet,
                        "The Clear() method has failed. " +
                        eFailed.Message,
                        "ClearFailed",
                        ErrorCategory.InvalidArgument,
                        true);
                }
            }
            return result;
        }
        
        // finding?
        
        public static bool GetWebElementAttribute(PSCmdletBase cmdlet, IWebElement[] elements, string attributeName)
        {
            bool result = false;
            foreach (IWebElement element in elements) {
                try {
                    cmdlet.WriteObject(cmdlet, (element as IWebElement).GetAttribute(attributeName));
                    result = true;
                }
                catch (Exception eFailed) {
                    cmdlet.WriteError(
                        cmdlet,
                        "The " +
                        attributeName +
                        " attribute is not available. " +
                        eFailed.Message,
                        "AttributeFailed",
                        ErrorCategory.InvalidArgument,
                        true);
                }
            }
            return result;
        }
        
        public static bool GetWebElementCSSValue(PSCmdletBase cmdlet, IWebElement[] elements, string propertyName)
        {
            bool result = false;
            foreach (IWebElement element in elements) {
                try {
                    cmdlet.WriteObject(cmdlet, (element as IWebElement).GetCssValue(propertyName));
                    result = true;
                }
                catch (Exception eFailed) {
                    cmdlet.WriteError(
                        cmdlet,
                        "The '" +
                        propertyName +
                        "' CSS value is not available. " +
                        eFailed.Message,
                        "CSSValueFailed",
                        ErrorCategory.InvalidArgument,
                        true);
                }
            }
            return result;
        }
        
        public static bool GetWebElementIsDisplayed(PSCmdletBase cmdlet, IWebElement[] elements)
        {
            bool result = false;
            foreach (IWebElement element in elements) {
                try {
                    cmdlet.WriteObject(cmdlet, (element as IWebElement).Displayed);
                    result = true;
                }
                catch (Exception eFailed) {
                    cmdlet.WriteError(
                        cmdlet,
                        "The Displayed property is not available. " +
                        eFailed.Message,
                        "DisplayedFailed",
                        ErrorCategory.InvalidArgument,
                        true);
                }
            }
            return result;
        }
        
        public static bool GetWebElementIsEnabled(PSCmdletBase cmdlet, IWebElement[] elements)
        {
            bool result = false;
            foreach (IWebElement element in elements) {
                try {
                    cmdlet.WriteObject(cmdlet, (element as IWebElement).Enabled);
                    result = true;
                }
                catch (Exception eFailed) {
                    cmdlet.WriteError(
                        cmdlet,
                        "The Enabled property is not available. " +
                        eFailed.Message,
                        "EnabledFailed",
                        ErrorCategory.InvalidArgument,
                        true);
                }
            }
            return result;
        }
        
        public static bool GetWebElementLocation(PSCmdletBase cmdlet, IWebElement[] elements)
        {
            bool result = false;
            foreach (IWebElement element in elements) {
                try {
                    cmdlet.WriteObject(cmdlet, (element as IWebElement).Location);
                    result = true;
                }
                catch (Exception eFailed) {
                    cmdlet.WriteError(
                        cmdlet,
                        "The Location property is not available. " +
                        eFailed.Message,
                        "LocationFailed",
                        ErrorCategory.InvalidArgument,
                        true);
                }
            }
            return result;
        }
        
        public static bool GetWebElementIsSelected(PSCmdletBase cmdlet, IWebElement[] elements)
        {
            bool result = false;
            foreach (IWebElement element in elements) {
                try {
                    cmdlet.WriteObject(cmdlet, (element as IWebElement).Selected);
                    result = true;
                }
                catch (Exception eFailed) {
                    cmdlet.WriteError(
                        cmdlet,
                        "The Selected property is not available. " +
                        eFailed.Message,
                        "SelectedFailed",
                        ErrorCategory.InvalidArgument,
                        true);
                }
            }
            return result;
        }
        
        public static bool GetWebElementSize(PSCmdletBase cmdlet, IWebElement[] elements)
        {
            bool result = false;
            foreach (IWebElement element in elements) {
                try {
                    cmdlet.WriteObject(cmdlet, (element as IWebElement).Size);
                    result = true;
                }
                catch (Exception eFailed) {
                    cmdlet.WriteError(
                        cmdlet,
                        "The Size property is not available. " +
                        eFailed.Message,
                        "SizeFailed",
                        ErrorCategory.InvalidArgument,
                        true);
                }
            }
            return result;
        }
        
        public static bool GetWebElementTagName(PSCmdletBase cmdlet, IWebElement[] elements)
        {
            bool result = false;
            foreach (IWebElement element in elements) {
                try {
                    cmdlet.WriteObject(cmdlet, (element as IWebElement).TagName);
                    result = true;
                }
                catch (Exception eFailed) {
                    cmdlet.WriteError(
                        cmdlet,
                        "The TagName property is not available. " +
                        eFailed.Message,
                        "TagNameFailed",
                        ErrorCategory.InvalidArgument,
                        true);
                }
            }
            return result;
        }
        
        public static bool GetWebElementText(PSCmdletBase cmdlet, IWebElement[] elements)
        {
            bool result = false;
            foreach (IWebElement element in elements) {
                try {
                    cmdlet.WriteVerbose(cmdlet, "trying to get the Text");
                    cmdlet.WriteObject(cmdlet, (element as IWebElement).Text);
                    cmdlet.WriteVerbose(cmdlet, "the Text has been gotten");
                    result = true;
                }
                catch (Exception eFailed) {
                    cmdlet.WriteError(
                        cmdlet,
                        "The Text property is not available. " +
                        eFailed.Message,
                        "TextFailed",
                        ErrorCategory.InvalidArgument,
                        true);
                }
            }
            return result;
        }
        
        public static bool SendWebElementKeys(PSCmdletBase cmdlet, IWebElement[] elements, string text)
        {
            bool result = false;
            foreach (IWebElement element in elements) {
                cmdlet.WriteVerbose(cmdlet, "The input element is appropriate");
                try {
                    //Console.WriteLine("element.GetAttribute(\"id\") = " + element.GetAttribute("id"));
                    //Console.WriteLine("(element as IWebElement).GetAttribute(\"id\") = " + (element as IWebElement).GetAttribute("id"));
                    //Console.WriteLine("text = " + text);
                    //try {
                    (element as IWebElement).SendKeys(text);
                    //} catch (Exception e001) {
                    //    Console.WriteLine("e001 = " + e001.Message + "\t" + e001.GetType().Name);
                    //    try {
                    //        element.SendKeys(text);
                    //    }
                    //    catch (Exception e002) {
                    //        Console.WriteLine("e002 = " + e002.Message + "\t" + e002.GetType().Name);
                    //    }
                    //}
                    //Console.WriteLine("the text written = " + element.Text);
                    //Console.WriteLine("aaa0001");
                    cmdlet.WriteVerbose(cmdlet, "The keys have been sent");
                    //Console.WriteLine("aaa0002");
                    cmdlet.WriteObject(cmdlet, (element as IWebElement));
                    //Console.WriteLine("aaa0003");
                    result = true;
                }
                catch (Exception eFailed) {
                    cmdlet.WriteError(
                        cmdlet,
                        "The SendKeys(text) method has failed. " +
                        eFailed.Message,
                        "SendKeysFailed",
                        ErrorCategory.InvalidArgument,
                        true);
                }
            }
            return result;
        }
        
        public static bool SubmitWebElement(PSCmdletBase cmdlet, IWebElement[] elements)
        {
            bool result = false;
            foreach (IWebElement element in elements) {
                try {
                    (element as IWebElement).Submit();
                    cmdlet.WriteObject(cmdlet, (element as IWebElement));
                    result = true;
                }
                catch (Exception eFailed) {
                    cmdlet.WriteError(
                        cmdlet,
                        "The Submit() method has failed. " +
                        eFailed.Message,
                        "SubmitFailed",
                        ErrorCategory.InvalidArgument,
                        true);
                }
            }
            return result;
        }
        #endregion Element
        
        #region JSExecutor
        public static bool ExecuteJavaScript(
            PSCmdletBase cmdlet,
            IWebDriver[] drivers,
            string scriptCode,
            string[] arguments,
            bool output)
        {
            bool result = false;
            foreach (IWebDriver driver in drivers) {
                try {
                    ((IJavaScriptExecutor)driver).ExecuteScript(
                        scriptCode,
                        arguments);
                    
                    if (output) {
                        cmdlet.WriteObject(cmdlet, true);
                    }
                    result = true;
                }
                catch (Exception eFailed) {
                    cmdlet.WriteError(
                        cmdlet,
                        "Failed to run the script: " +
                        scriptCode +
                        " " +
                        eFailed.Message,
                        "JSExecutorFailed",
                        ErrorCategory.InvalidResult,
                        true);
                }
            }
            return result;
        }
        #endregion JSExecutor
        
        #region Navigation
        public static bool NavigateTo(PSCmdletBase cmdlet, IWebDriver[] drivers, string uri)
        {
            bool result = false;
            foreach (IWebDriver driver in drivers) {

                try {
Console.WriteLine("NavigatoTo: 00001");
                    (driver as IWebDriver).Navigate().GoToUrl(uri);
Console.WriteLine("NavigatoTo: 00002");
                    cmdlet.WriteObject(cmdlet, (driver as IWebDriver));
Console.WriteLine("NavigatoTo: 00003");
                    result = true;
                    
                }
                catch (Exception eFailed) {

                    cmdlet.WriteError(
                        cmdlet,
                        "Failed to navigate to '" +
                        uri +
                        "'. " +
                        eFailed.Message,
                        "NavigationFailed",
                        ErrorCategory.InvalidResult,
                        true);
                }
            }
            return result;
        }
        
        public static bool NavigateBack(PSCmdletBase cmdlet, IWebDriver[] drivers)
        {
            bool result = false;
            foreach (IWebDriver driver in drivers) {
                try {
                    (driver as IWebDriver).Navigate().Back();
                    cmdlet.WriteObject(cmdlet, (driver as IWebDriver));
                    result = true;
                }
                catch (Exception eFailed) {
                    cmdlet.WriteError(
                        cmdlet,
                        "Failed to navigate back. " +
                        eFailed.Message,
                        "NavigationBackFailed",
                        ErrorCategory.InvalidResult,
                        true);
                }
            }
            return result;
        }
        
        public static bool NavigateForward(PSCmdletBase cmdlet, IWebDriver[] drivers)
        {
            bool result = false;
            foreach (IWebDriver driver in drivers) {
                try {
                    (driver as IWebDriver).Navigate().Forward();
                    cmdlet.WriteObject(cmdlet, (driver as IWebDriver));
                    result = true;
                }
                catch (Exception eFailed) {
                    cmdlet.WriteError(
                        cmdlet,
                        "Failed to navigate forward. " +
                        eFailed.Message,
                        "NavigationForwardFailed",
                        ErrorCategory.InvalidResult,
                        true);
                }
            }
            return result;
        }
        
        public static bool RefreshPage(PSCmdletBase cmdlet, IWebDriver[] drivers)
        {
            bool result = false;
            foreach (IWebDriver driver in drivers) {
                try {
                    (driver as IWebDriver).Navigate().Refresh();
                    cmdlet.WriteObject(cmdlet, (driver as IWebDriver));
                    result = true;
                }
                catch (Exception eFailed) {
                    cmdlet.WriteError(
                        cmdlet,
                        "Failed to refresh the page. " +
                        eFailed.Message,
                        "RefreshFailed",
                        ErrorCategory.InvalidResult,
                        true);
                }
            }
            return result;
        }
        
        public static bool SwitchToFrame(PSCmdletBase cmdlet, IWebDriver[] drivers, SwitchToFrameWays selector)
        {
            bool result = false;
            
            string errorReport = string.Empty;
            
            foreach (IWebDriver driver in drivers) {
                try {
                    
                    (driver as IWebDriver).SwitchTo().DefaultContent();
                    
                    switch (selector) {
                        case SwitchToFrameWays.FrameElement:
                            errorReport = "FrameElement = " + ((SwitchToFrameCmdletBase)cmdlet).FrameElement.ToString();
                            cmdlet.WriteVerbose(errorReport);
                            cmdlet.WriteObject(cmdlet, (driver as IWebDriver).SwitchTo().Frame(((SwitchToFrameCmdletBase)cmdlet).FrameElement));
                            break;
                        case SwitchToFrameWays.FrameIndex:
                            errorReport = "FrameIndex = " + ((SwitchToFrameCmdletBase)cmdlet).FrameIndex.ToString();
                            cmdlet.WriteVerbose(errorReport);
                            cmdlet.WriteObject(cmdlet, (driver as IWebDriver).SwitchTo().Frame(((SwitchToFrameCmdletBase)cmdlet).FrameIndex));
                            break;
                        case SwitchToFrameWays.FrameName:
                            errorReport = "FrameName = " + ((SwitchToFrameCmdletBase)cmdlet).FrameName;
                            cmdlet.WriteVerbose(errorReport);
                            cmdlet.WriteObject(cmdlet, (driver as IWebDriver).SwitchTo().Frame(((SwitchToFrameCmdletBase)cmdlet).FrameName));
                            break;
                    }
                    //cmdlet.WriteObject(cmdlet, (driver as IWebDriver).SwitchTo().Frame(frameIndex));
                    result = true;
                }
                catch (Exception eFailed) {
                    cmdlet.WriteError(
                        cmdlet,
                        "Failed to switch to the frame '" +
                        errorReport +
                        "'. " +
                        eFailed.Message,
                        "SwitchToFrameFailed",
                        ErrorCategory.InvalidArgument,
                        true);
                }
            }
            return result;
        }
        
        public static bool SwitchToWindow(PSCmdletBase cmdlet, IWebDriver[] drivers, string windowName)
        {
            bool result = false;
            foreach (IWebDriver driver in drivers) {
                try {
                    cmdlet.WriteObject(cmdlet, (driver as IWebDriver).SwitchTo().Window(windowName));
                    result = true;
                }
                catch (Exception eFailed) {
                    cmdlet.WriteError(cmdlet,
                                      "Failed to switch to the window '" +
                                      windowName +
                                      "'. " +
                                      eFailed.Message,
                                      "SwitchToWindowFailed",
                                      ErrorCategory.InvalidResult,
                                      true);
                }
            }
            return result;
        }
        
        public static bool SwitchToActiveElement(PSCmdletBase cmdlet, IWebDriver[] drivers)
        {
            bool result = false;
            foreach (IWebDriver driver in drivers) {
                try {
                    cmdlet.WriteObject(cmdlet, (driver as IWebDriver).SwitchTo().ActiveElement());
                    result = true;
                }
                catch (Exception eFailed) {
                    cmdlet.WriteError(
                        cmdlet,
                        "Failed to switch to the active element. " +
                        eFailed.Message,
                        "SwitchToActiveElementFailed",
                        ErrorCategory.InvalidResult,
                        true);
                }
            }
            return result;
        }
        
        public static bool SwitchToDefaultContent(PSCmdletBase cmdlet, IWebDriver[] drivers)
        {
            bool result = false;
            foreach (IWebDriver driver in drivers) {
                try {
                    cmdlet.WriteObject(cmdlet, (driver as IWebDriver).SwitchTo().DefaultContent());
                    result = true;
                }
                catch (Exception eFailed) {
                    cmdlet.WriteError(
                        cmdlet,
                        "Failed to switch to the default content. " +
                        eFailed.Message,
                        "SwitchToDefaultContentFailed",
                        ErrorCategory.InvalidResult,
                        true);
                }
            }
            return result;
        }
        
        public static bool SwitchToAlert(PSCmdletBase cmdlet, IWebDriver[] drivers)
        {
            bool result = false;
            foreach (IWebDriver driver in drivers) {
                try {
                    cmdlet.WriteObject(cmdlet, (driver as IWebDriver).SwitchTo().Alert());
                    result = true;
                }
                catch (Exception eFailed) {
                    cmdlet.WriteError(
                        cmdlet,
                        "Failed to switch to the alert. " +
                        eFailed.Message,
                        "SwitchToAlertFailed",
                        ErrorCategory.InvalidResult,
                        true);
                }
            }
            return result;
        }
        #endregion Navigation
        
        #region Alert
        public static bool AlertAcceptButtonClick(PSCmdletBase cmdlet, IAlert alert)
        {
            bool result = false;
            
            try {
                (alert as IAlert).Accept();
                cmdlet.WriteObject(cmdlet, true);
                result = true;
            }
            catch (Exception eAlertAccept) {
                cmdlet.WriteError(
                    cmdlet,
                    "Failed to accept the alert. " +
                    eAlertAccept.Message,
                    "AcceptFailed",
                    ErrorCategory.InvalidOperation,
                    true);
            }
            
            return result;
        }
        
        public static bool AlertDismissButtonClick(PSCmdletBase cmdlet, IAlert alert)
        {
            bool result = false;
            
            try {
                (alert as IAlert).Dismiss();
                cmdlet.WriteObject(cmdlet, true);
                result = true;
            }
            catch (Exception eAlertDismiss) {
                cmdlet.WriteError(
                    cmdlet,
                    "Failed to dismiss the alert. " +
                    eAlertDismiss.Message,
                    "DismissFailed",
                    ErrorCategory.InvalidOperation,
                    true);
            }
            
            return result;
        }
        
        public static bool AlertGetText(PSCmdletBase cmdlet, IAlert alert)
        {
            bool result = false;
            
            try {
                cmdlet.WriteObject(cmdlet, (alert as IAlert).Text);
                result = true;
            }
            catch (Exception eAlertText) {
                cmdlet.WriteError(
                    cmdlet,
                    "Failed to get the alert's test. " +
                    eAlertText.Message,
                    "AlertTextFailed",
                    ErrorCategory.InvalidOperation,
                    true);
            }
            
            return result;
        }
        
        public static bool AlertSendKeys(PSCmdletBase cmdlet, IAlert alert, string text)
        {
            bool result = false;
            
            try {
                (alert as IAlert).SendKeys(text);
                cmdlet.WriteObject(cmdlet, true);
                result = true;
            }
            catch (Exception eAlertSendKeys) {
                cmdlet.WriteError(
                    cmdlet,
                    "Failed to send keys to the alert. " +
                    eAlertSendKeys.Message,
                    "AlertSendKeysFailed",
                    ErrorCategory.InvalidOperation,
                    true);
            }
            
            return result;
        }
        #endregion Alert
        
        #region PageObject
        public static bool CreatePageObject(PSCmdletBase cmdlet, IWebDriver[] drivers)
        {
            bool result = false;
            foreach (IWebDriver driver in drivers) {
                try {
                    object page = null;
                    //object newPage =
                    PageFactory.InitElements((driver as IWebDriver), page);
                    //WriteObject(this, newPage);
                    cmdlet.WriteObject(cmdlet, page);
                    result = true;
                }
                catch (Exception eFailed) {
                    cmdlet.WriteError(
                        cmdlet,
                        "Could not return a PageObject object. " +
                        eFailed.Message,
                        "FailedToCreatePageObject",
                        ErrorCategory.InvalidArgument,
                        true);
                }
                
                #region commented
                //            IWebDriver driver = null;
                //            //driver.SwitchTo().
                //            //driver.Navigate().
                //            driver.Manage().Timeouts().SetPageLoadTimeout(System.TimeSpan.MinValue);
                //            driver.Navigate()..Forward();
                #endregion commented
            }
            return result;
        }
        #endregion PageObject
        
        #region Relatives
        public static bool GetElementAncestors(PSCmdletBase cmdlet, IWebElement[] elements)
        {
            bool result = false;
            foreach (IWebElement element in elements) {
                try {
                    IWebElement resultElement =
                        (element as IWebElement).FindElement(By.XPath(@".."));
                    while ((resultElement as IWebElement) != null) {
                        cmdlet.WriteObject(cmdlet, resultElement);
                        try {
                            IWebElement currentChildElement = resultElement;
                            resultElement = null;
                            resultElement =
                                currentChildElement.FindElement(By.XPath(@".."));
                            if (currentChildElement.Location == resultElement.Location &&
                                currentChildElement.TagName == resultElement.TagName &&
                                currentChildElement.Size == resultElement.Size &&
                                currentChildElement.Text == resultElement.Text) {
                                resultElement = null;
                                //return;
                                result = true;
                                return result;
                            }
                        }
                        catch {}
                    }
                    result = true;
                }
                catch (Exception eFailed) {
                    cmdlet.WriteError(
                        cmdlet,
                        "The parent web element is not available. " +
                        eFailed.Message,
                        "FailedToGetElementAncestors",
                        ErrorCategory.InvalidArgument,
                        true);
                }
            }
            return result;
        }
        
        public static bool GetElementParent(PSCmdletBase cmdlet, IWebElement[] elements)
        {
            bool result = false;
            foreach (IWebElement element in elements) {
                try {
                    IWebElement resultElement =
                        (element as IWebElement).FindElement(By.XPath(@".."));
                    cmdlet.WriteObject(cmdlet, resultElement);
                    result = true;
                }
                catch (Exception eFailed) {
                    cmdlet.WriteError(
                        cmdlet,
                        "The parent web element is not available. " +
                        eFailed.Message,
                        "FailedToGetElementParent",
                        ErrorCategory.InvalidArgument,
                        true);
                }
            }
            return result;
        }
        #endregion Relatives
        
        #region Select
        internal static SelectElement GetSelectFromWebElement(
            PSCmdletBase cmdlet,
            IWebElement element)
        {
            SelectElement selectElement = null;
            try {
                selectElement =
                    new SelectElement((element as IWebElement));
            }
            catch (Exception eSelect) {cmdlet.WriteVerbose(cmdlet, eSelect.Message); }
            return selectElement;
        }
        
        public static bool GetSelect(
            PSCmdletBase cmdlet,
            IWebElement[] elements,
            bool firstSelected,
            bool selected,
            bool all)
        {
            bool result = false;
            foreach (IWebElement element in elements) {
                cmdlet.WriteVerbose(cmdlet, "getting the Select object");
                SelectElement select = //null;
                    //try {
                    //    select =
                    //new SelectElement((element as IWebElement));
                    SeHelper.GetSelectFromWebElement(cmdlet, element);
                if (null != select) {
                    cmdlet.WriteVerbose(cmdlet, "the Select object has been gotten");
                } else {
                    return result;
                }
                //}
                //catch (Exception eSelect) {cmdlet.WriteVerbose(cmdlet, eSelect.Message); }
                
                IList<IWebElement> resultList =
                    new List<IWebElement>();
                
                try {
                    if (firstSelected) {
                        cmdlet.WriteVerbose(cmdlet, "getting first selected element");
                        resultList.Add(select.SelectedOption);
                    }
                    
                    if (selected) {
                        cmdlet.WriteVerbose(cmdlet, "getting all selected elements");
                        foreach (IWebElement option in select.AllSelectedOptions) {
                            resultList.Add(option);
                        }
                    }
                    
                    if (all) {
                        cmdlet.WriteVerbose(cmdlet, "getting all elements");
                        foreach (IWebElement oneElement in select.Options) {
                            resultList.Add(oneElement);
                        }
                    }
                    
                    // TODO: WriteObject for collections
                    //WriteObject(this, result);
                    //                foreach (IWebElement resultElement in result) {
                    //                    WriteObject(this, resultElement);
                    //                }
                    cmdlet.WriteObject(cmdlet, resultList);
                    result = true;
                }
                catch (Exception eGetSelection) {
                    cmdlet.WriteError(
                        cmdlet,
                        "Can't get the selection. " +
                        eGetSelection.Message,
                        "GetSelectionFailed",
                        ErrorCategory.InvalidArgument,
                        true);
                }
            }
            return result;
        }
        
        public static bool SetSelect(
            PSCmdletBase cmdlet,
            IWebElement[] elements,
            int[] indices,
            string[] values,
            string[] visibleTexts,
            bool all,
            bool deselect)
        {
            bool result = false;
            foreach (IWebElement element in elements) {
                cmdlet.WriteVerbose(cmdlet, "getting the Select object");
                SelectElement select =
                    //new SelectElement((element as IWebElement));
                    SeHelper.GetSelectFromWebElement(cmdlet, element);
                if (null != select) {
                    cmdlet.WriteVerbose(cmdlet, "the Select object has been gotten");
                } else {
                    return result;
                }
                
                try {
                    if (indices != null) {
                        foreach (int index in indices) {
                            if (deselect) {
                                select.DeselectByIndex(index);
                            } else {
                                select.SelectByIndex(index);
                            }
                        }
                    }
                    
                    if (values != null) {
                        foreach (string valueString in values) {
                            if (deselect) {
                                select.DeselectByValue(valueString);
                            } else {
                                select.SelectByValue(valueString);
                            }
                        }
                    }
                    
                    if (visibleTexts != null) {
                        foreach (string text in visibleTexts) {
                            if (deselect) {
                                select.DeselectByText(text);
                            } else {
                                select.SelectByText(text);
                            }
                        }
                    }
                    
                    if (all) {
                        if (deselect) {
                            select.DeselectAll();
                        } else {
                            for (int i = 0; i < select.Options.Count; i++) {
                                select.SelectByIndex(i);
                            }
                        }
                    }
                    
                    cmdlet.WriteObject(cmdlet, true);
                    return result;
                }
                catch (Exception eSetSelection) {
                    cmdlet.WriteError(
                        cmdlet,
                        "Can't set the selection. " +
                        eSetSelection.Message,
                        "SetSelectionFailed",
                        ErrorCategory.InvalidArgument,
                        true);
                }
            }
            return result;
        }
        #endregion Select
        
        #region Screenshot
        internal static void GetScreenshotOfCmdletInput(
            //HasWebElementInputCmdletBase cmdlet,
            CommonCmdletBase cmdlet,
            string description,
            bool save,
            int Left,
            int Top,
            int Height,
            int Width,
            string path,
            System.Drawing.Imaging.ImageFormat format)
        {
            cmdlet.WriteVerbose(cmdlet, "GetScreenshotOfWebElement: checking the input");
            
            IWebElement[] inputCollection = null;
            
            
            //            try {
            //                cmdlet.WriteVerbose(cmdlet, "trying cmdlet is HasWebElementInputCmdletBase");
            //                var test1 =
            //                    cmdlet is HasWebElementInputCmdletBase;
            //            }
            //            catch (Exception e1) {
            //                cmdlet.WriteVerbose(cmdlet, "test cmdlet is HasWebElementInputCmdletBase failed");
            //                cmdlet.WriteVerbose(cmdlet, e1.Message);
            //            }
//
            //            try {
            //                cmdlet.WriteVerbose(cmdlet, "trying cmdlet is HasWebDriverInputCmdletBase");
            //                var test1 =
            //                    cmdlet is HasWebDriverInputCmdletBase;
            //            }
            //            catch (Exception e2) {
            //                cmdlet.WriteVerbose(cmdlet, "test cmdlet is HasWebDriverInputCmdletBase failed");
            //                cmdlet.WriteVerbose(cmdlet, e2.Message);
            //            }
//
            
            // 20120928
            if (null == (cmdlet as DriverCmdletBase) &&
                null == (cmdlet as HasWebDriverInputCmdletBase) &&
                null == (cmdlet as HasWebElementInputCmdletBase)) {
                
                cmdlet.WriteVerbose(cmdlet, "(cmdlet is of 'other' type");
                
                try {
                    inputCollection =
                        new OpenQA.Selenium.IWebElement [] { CurrentData.CurrentWebDriver.FindElement(By.TagName("html")) };
                    
                    if (null != inputCollection) {
                        cmdlet.WriteVerbose(cmdlet, "inputCollection.Length = " + inputCollection.Length.ToString());
                    }
                }
                catch (Exception eWebDriver) {
                    
                    cmdlet.WriteVerbose(cmdlet, eWebDriver.Message);
                    cmdlet.WriteVerbose(cmdlet, "taking the desktop for screenshot");
                    
                    UIAutomation.UIAHelper.GetScreenshotOfAutomationElement(
                        (new HasControlInputCmdletBase()),
                        AutomationElement.RootElement,
                        cmdlet.CmdletName(cmdlet),
                        true,
                        0,
                        0,
                        0,
                        0,
                        string.Empty,
                        SePSX.Preferences.OnSuccessScreenShotFormat);
                }
                
            } else if (null != (cmdlet as DriverCmdletBase)) {
                
                cmdlet.WriteVerbose(cmdlet, "(null != (cmdlet as DriverCmdletBase))");
                
                //                System.Collections.Generic.List<AutomationElement> browser =
                //                    SeHelper.ConvertWebDriverOrWebElementToAutomationElement(
                //                        (new HasWebElementInputCmdletBase()),
                //                        new object[] { AutomationElement.RootElement });

                cmdlet.WriteVerbose(cmdlet, "taking the desktop for screenshot");
                
                UIAutomation.UIAHelper.GetScreenshotOfAutomationElement(
                    (new HasControlInputCmdletBase()),
                    AutomationElement.RootElement,
                    cmdlet.CmdletName(cmdlet),
                    true,
                    0,
                    0,
                    0,
                    0,
                    string.Empty,
                    SePSX.Preferences.OnSuccessScreenShotFormat);
                
            } else if (null != (cmdlet as HasWebElementInputCmdletBase)) {
                
                cmdlet.WriteVerbose(cmdlet, "(cmdlet is HasWebElementInputCmdletBase)");
                
                // 20120824
                if (null == (cmdlet as HasWebElementInputCmdletBase).InputObject ||
                    0 == (cmdlet as HasWebElementInputCmdletBase).InputObject.Length) {
                    
                    //cmdlet.WriteVerbose(cmdlet, "(null == cmdlet.InputObject || 0 == cmdlet.InputObject.Length)");

                    try {
                        inputCollection =
                            new OpenQA.Selenium.IWebElement [] { CurrentData.CurrentWebDriver.FindElement(By.TagName("html")) };
                        
                        if (null != inputCollection) {
                            cmdlet.WriteVerbose(cmdlet, "inputCollection.Length = " + inputCollection.Length.ToString());
                        }
                    }
                    catch {}
                } else {
                    
                    //cmdlet.WriteVerbose(cmdlet, "! (null == cmdlet.InputObject || 0 == cmdlet.InputObject.Length)");
                    
                    if (null != ((cmdlet as HasWebElementInputCmdletBase).InputObject as IWebElement[])) {
                        
                        cmdlet.WriteVerbose(cmdlet, "(null != (cmdlet.InputObject as IWebElement[]))");
                        
                        inputCollection =
                            (IWebElement[])((cmdlet as HasWebElementInputCmdletBase).InputObject);
                        
                        if (null != inputCollection) {
                            cmdlet.WriteVerbose(cmdlet, "inputCollection.Length = " + inputCollection.Length.ToString());
                        }
                        
                    }
                    //                    if (null != ((cmdlet as HasWebElementInputCmdletBase).InputObject as IWebDriver[])) {
//
                    //                        cmdlet.WriteVerbose(cmdlet, "(null != (cmdlet.InputObject as IWebDriver[]))");
//
                    //                        inputCollection = (cmdlet as HasWebElementInputCmdletBase).InputObject;
//
                    //                        cmdlet.WriteVerbose(cmdlet, "inputCollection = cmdlet.InputObject");
//
                    //                        for (int i = 0; i < (cmdlet as HasWebElementInputCmdletBase).InputObject.Length; i++) {
                    //                            inputCollection[i] =
                    //                                ((IWebDriver)(cmdlet as HasWebElementInputCmdletBase).InputObject[i]).FindElement(By.TagName("html"));
                    //                        }
//
                    //                        if (null != inputCollection) {
                    //                            cmdlet.WriteVerbose(cmdlet, "inputCollection.Length = " + inputCollection.Length.ToString());
                    //                        }
                    //                    }
                }
            } else if (null != (cmdlet is HasWebDriverInputCmdletBase)) {
                
                cmdlet.WriteVerbose(cmdlet, "(cmdlet is HasWebDriverInputCmdletBase)");
                
                try {
                    
                    if (null == (cmdlet as HasWebDriverInputCmdletBase).InputObject ||
                        0 == (cmdlet as HasWebDriverInputCmdletBase).InputObject.Length) {
                        
                        //cmdlet.WriteVerbose(cmdlet, "(null == cmdlet.InputObject || 0 == cmdlet.InputObject.Length)");
                        
                        try {
                            inputCollection =
                                new OpenQA.Selenium.IWebElement [] { CurrentData.CurrentWebDriver.FindElement(By.TagName("html")) };
                            
                            if (null != inputCollection) {
                                cmdlet.WriteVerbose(cmdlet, "inputCollection.Length = " + inputCollection.Length.ToString());
                            }
                        }
                        catch {}
                    } else {
                        
                        //cmdlet.WriteVerbose(cmdlet, "! (null == cmdlet.InputObject || 0 == cmdlet.InputObject.Length)");
                        
                        if (null != ((cmdlet as HasWebDriverInputCmdletBase).InputObject as IWebDriver[])) {
                            
                            cmdlet.WriteVerbose(cmdlet, "(null != (cmdlet.InputObject as IWebElement[]))");
                            
                            //inputCollection =
                            //    (IWebDriver[])((cmdlet as HasWebDriverInputCmdletBase).InputObject);
                            
                            for (int i = 0; i < (cmdlet as HasWebDriverInputCmdletBase).InputObject.Length; i++) {
                                inputCollection[i] =
                                    (cmdlet as HasWebDriverInputCmdletBase).InputObject[i].FindElement(By.TagName("html"));
                            }
                            
                            if (null != inputCollection) {
                                cmdlet.WriteVerbose(cmdlet, "inputCollection.Length = " + inputCollection.Length.ToString());
                            }
                            
                        }
                        //                    if (null != ((cmdlet as HasWebDriverInputCmdletBase).InputObject as IWebDriver[])) {
                        //
                        //                        cmdlet.WriteVerbose(cmdlet, "(null != (cmdlet.InputObject as IWebDriver[]))");
                        //
                        //                        inputCollection = (cmdlet as HasWebDriverInputCmdletBase).InputObject;
                        //
                        //                        cmdlet.WriteVerbose(cmdlet, "inputCollection = cmdlet.InputObject");
                        //
                        //                        for (int i = 0; i < (cmdlet as HasWebDriverInputCmdletBase).InputObject.Length; i++) {
                        //                            inputCollection[i] =
                        //                                ((IWebDriver)(cmdlet as HasWebDriverInputCmdletBase).InputObject[i]).FindElement(By.TagName("html"));
                        //                        }
                        //
                        //                        if (null != inputCollection) {
                        //                            cmdlet.WriteVerbose(cmdlet, "inputCollection.Length = " + inputCollection.Length.ToString());
                        //                        }
                        //                    }
                    }
                    
                }
                catch (Exception e3) {
                    cmdlet.WriteVerbose(cmdlet, "error!!!!");
                    cmdlet.WriteVerbose(cmdlet, e3.Message);
                }
                
            }
            
            cmdlet.WriteVerbose(
                cmdlet,
                "input array consists of " + inputCollection.Length.ToString() + " objects");
            
            // 20120823
            // 20121212
            //foreach (RemoteWebElement inputObject in inputCollection) {
            foreach (WebElementDecorator inputObject in inputCollection) {
                
                cmdlet.WriteVerbose(cmdlet, "calculating the size");
                int absoluteX = 0;
                int absoluteY = 0;
                int absoluteWidth =
                    Screen.PrimaryScreen.Bounds.Width;
                int absoluteHeight =
                    Screen.PrimaryScreen.Bounds.Height;

                if (inputObject == null) {
                    if (Left > 0) { absoluteX = Left; }
                    if (Top > 0) { absoluteY = Top; }
                    if (Height > 0) { absoluteHeight = Height; }
                    if (Width > 0) { absoluteWidth = Width; }
                }
                cmdlet.WriteVerbose(cmdlet, "X = " + absoluteX.ToString());
                cmdlet.WriteVerbose(cmdlet, "Y = " + absoluteY.ToString());
                cmdlet.WriteVerbose(cmdlet, "Height = " + absoluteHeight.ToString());
                cmdlet.WriteVerbose(cmdlet, "Width = " + absoluteWidth.ToString());

                if (inputObject != null) { //&& (int)inputObject.Current.ProcessId > 0) {
                    //absoluteX = (int)inputObject.Current.BoundingRectangle.X + Left;
                    //absoluteX = inputObject.Location.X;
                    //absoluteY = (int)inputObject.Current.BoundingRectangle.Y + Top;
                    //absoluteY = inputObject.Location.Y;
                    
                    int[] absoluteCoordinates =
                        SeHelper.getWebElementCoordinates(inputObject);
                    absoluteX = absoluteCoordinates[0];
                    absoluteY = absoluteCoordinates[1];
                    //absoluteHeight = (int)inputObject.Current.BoundingRectangle.Height + Height;
                    absoluteHeight = inputObject.Size.Height;
                    //absoluteWidth = (int)inputObject.Current.BoundingRectangle.Width + Width;
                    absoluteWidth = inputObject.Size.Width;
                }

                if (Height == 0) {Height = Screen.PrimaryScreen.Bounds.Height; }
                if (Width == 0) {Width = Screen.PrimaryScreen.Bounds.Width; }

                //                if (inputObject != null) { // && (int)inputObject.Current.ProcessId > 0) {
//
                //                    try {
//
                //                        inputObject.SetFocus();
//
                //                    }
                //                    catch {
                //                        // ??
//
                //                    }
                //                }

                UIAutomation.UIAHelper.GetScreenshotOfSquare(
                    cmdlet,
                    description,
                    save,
                    absoluteX,
                    absoluteY,
                    absoluteHeight,
                    absoluteWidth,
                    path,
                    format);

            }
        }
        
        internal static void GetScreenshotOfWebElement(
            CommonCmdletBase cmdlet,
            object element,
            string description,
            bool save,
            int Left,
            int Top,
            int Height,
            int Width,
            string path,
            System.Drawing.Imaging.ImageFormat format)
        {
            
            IWebElement elementToTakeScreenShot = null;
            if (null != (element as IWebElement)) {
                elementToTakeScreenShot = (element as IWebElement);
            } else if (null != (element as IWebDriver)) {
                elementToTakeScreenShot =
                    (element as IWebDriver).FindElement(By.TagName("html"));
            } else {
                // various types
                
            }
            if (null == elementToTakeScreenShot) {
                UIAutomation.UIAHelper.GetScreenshotOfAutomationElement(
                    (new HasControlInputCmdletBase()),
                    AutomationElement.RootElement,
                    cmdlet.CmdletName(cmdlet),
                    true,
                    0,
                    0,
                    0,
                    0,
                    string.Empty,
                    format);
                return;
            }
            
            cmdlet.WriteVerbose(cmdlet, "calculating the size");
            int absoluteX = 0;
            int absoluteY = 0;
            int absoluteWidth =
                Screen.PrimaryScreen.Bounds.Width;
            int absoluteHeight =
                Screen.PrimaryScreen.Bounds.Height;

            if (elementToTakeScreenShot == null) {
                if (Left > 0) { absoluteX = Left; }
                if (Top > 0) { absoluteY = Top; }
                if (Height > 0) { absoluteHeight = Height; }
                if (Width > 0) { absoluteWidth = Width; }
            }
            cmdlet.WriteVerbose(cmdlet, "X = " + absoluteX.ToString());
            cmdlet.WriteVerbose(cmdlet, "Y = " + absoluteY.ToString());
            cmdlet.WriteVerbose(cmdlet, "Height = " + absoluteHeight.ToString());
            cmdlet.WriteVerbose(cmdlet, "Width = " + absoluteWidth.ToString());

            if (elementToTakeScreenShot != null) { //&& (int)elementToTakeScreenShot.Current.ProcessId > 0) {
                //absoluteX = (int)elementToTakeScreenShot.Current.BoundingRectangle.X + Left;
                //absoluteX = elementToTakeScreenShot.Location.X;
                //absoluteY = (int)elementToTakeScreenShot.Current.BoundingRectangle.Y + Top;
                //absoluteY = elementToTakeScreenShot.Location.Y;
                
                int[] absoluteCoordinates =
                    // 20121212
                    //SeHelper.getWebElementCoordinates((OpenQA.Selenium.Remote.RemoteWebElement)elementToTakeScreenShot);
                    SeHelper.getWebElementCoordinates((WebElementDecorator)elementToTakeScreenShot);
                absoluteX = absoluteCoordinates[0];
                absoluteY = absoluteCoordinates[1];
                //absoluteHeight = (int)elementToTakeScreenShot.Current.BoundingRectangle.Height + Height;
                absoluteHeight = elementToTakeScreenShot.Size.Height;
                //absoluteWidth = (int)elementToTakeScreenShot.Current.BoundingRectangle.Width + Width;
                absoluteWidth = elementToTakeScreenShot.Size.Width;
            }

            if (Height == 0) {Height = Screen.PrimaryScreen.Bounds.Height; }
            if (Width == 0) {Width = Screen.PrimaryScreen.Bounds.Width; }

            //                if (elementToTakeScreenShot != null) { // && (int)elementToTakeScreenShot.Current.ProcessId > 0) {
//
            //                    try {
//
            //                        elementToTakeScreenShot.SetFocus();
//
            //                    }
            //                    catch {
            //                        // ??
//
            //                    }
            //                }

            UIAutomation.UIAHelper.GetScreenshotOfSquare(
                cmdlet,
                description,
                save,
                absoluteX,
                absoluteY,
                absoluteHeight,
                absoluteWidth,
                path,
                format);

        }
        #endregion Screenshot
        
        //        private static void SleepAndRunScriptBlocks(TranscriptCmdletBase cmdlet)
        //        {
        //            cmdlet.RunOnTranscriptIntervalScriptBlocks(cmdlet);
        //            System.Threading.Thread.Sleep(Preferences.TranscriptInterval);
        //        }
        
        #region set ForeGround
        public static void SetBrowserInstanceForeground(PSCmdletBase cmdlet)
        {
            if (Preferences.SetBrowserWindowForeground) {
                try {
                    UIAutomation.UIAHelper.GetAutomationElementFromHandle(
                        (new UIAutomation.DiscoveryCmdletBase()),
                        CurrentData.CurrentWebDriverHandle.ToInt32()).SetFocus();
                    
                    bool result =
                        UIAutomation.UIAHelper.SetFocus(
                            CurrentData.CurrentWebDriverHandle);
                    
                    if (!result) {
                        cmdlet.WriteVerbose(cmdlet, "failed to set the window foreground");
                    }
                }
                catch (Exception eSetForeground) {
                    cmdlet.WriteVerbose(cmdlet, "failed to set the window foreground");
                    cmdlet.WriteVerbose(cmdlet, eSetForeground.Message);
                }
            }
        }
        #endregion set ForeGround
        
        public static void GetWebElementViaJS(PSCmdletBase cmdlet, object[] elements, string tagName)
        {
            GetElementByTypeCmdletBase cmdletGet = (GetElementByTypeCmdletBase)cmdlet;
            
            ReadOnlyCollection<IWebElement> result =
                new ReadOnlyCollection<IWebElement>(new List<IWebElement>());
            bool firstVsAll = cmdletGet.First;
            cmdletGet.WriteVerbose(cmdletGet, "only the first element? " + firstVsAll.ToString());

            string script =
                @"function getSeElements(tagName, id, name, className, partialtext) {
                	var elements = document.getElementsByTagName(tagName);
                	var resultCollection = [];
                	for (var i = 0; i < elements.length; i++) {
                		if (null != id && '' != id) {
                			try {
                				if (elements[i].id == id) {
                					resultCollection.push(elements[i]);
                					continue;
                				}
                			} catch (err1) {}
                		}
                		if (null != name && '' != name) {
                			try {
                				if (elements[i].name == name) {
                					resultCollection.push(elements[i]);
                					continue;
                				}
                			} catch (err2) {}
                		}
                		if (null != className && '' != className) {
                			try {
                				if (elements[i].className == className) {
                					resultCollection.push(elements[i]);
                					continue;
                				}
                			} catch (err3) {}
                		}
                		if (null != partialtext && '' != partialtext) {
                			try {
                				if (0 < elements[i].innerHTML.indexOf(partialtext)) {
                					resultCollection.push(elements[i]);
                					continue;
                				}
                			} catch (err4) {}
                		}
                	}
                	return resultCollection;
                }
                return getSeElements(arguments[0], arguments[1], arguments[2], arguments[3], arguments[4]);";
            
            foreach (object inputObject in cmdletGet.InputObject) {
                
                //                SeHelper.ExecuteJavaScript(
                //                    cmdlet,
                //                    (new IWebDriver[]{CurrentData.CurrentWebDriver}),
                //                    script,
                //                    (new string[]{"button"}),
                //                    true);
                
                //do {
                var scriptResults =
                    ((IJavaScriptExecutor)CurrentData.CurrentWebDriver).ExecuteScript(
                        script,
                        (new string[] {
                             cmdletGet.TagName,
                             cmdletGet.Id,
                             cmdletGet.Name,
                             cmdletGet.ClassName,
                             cmdletGet.PartialText
                         })) as IEnumerable;
                
                //cmdlet.WriteObject(cmdlet, scriptResults);
                //} while (
                cmdlet.WriteObject(
                    cmdlet, 
                    SeHelper.GetDecoratedCollection<IWebElement>((ReadOnlyCollection<IWebElement>)scriptResults, null, null));
                
            }
        }
        
        public static void AddFirefoxExtension(CommonCmdletBase cmdlet)
        {
            FirefoxProfile profile =
                ((EditFirefoxProfileCmdletBase)cmdlet).InputObject;
            if (null == profile) {
                cmdlet.WriteError(
                    cmdlet,
                    "The input Firefox profile object is null.",
                    "InputIsNull",
                    ErrorCategory.InvalidArgument,
                    true);
            }
            
            string[] extensionList =
                ((AddSeFirefoxExtensionCommand)cmdlet).ExtensionList;
            
            if (null != extensionList && 0 < extensionList.Length) {
                //profile.AddExtensions(extensionList);
                foreach (string ext in extensionList) {
                    profile.AddExtension(ext);
                }
            }
            
            cmdlet.WriteObject(cmdlet, profile);
        }
        
        public static void GetNewChromeOptions(PSCmdletBase cmdlet)
        {
            ChromeOptions options =
                WebDriverFactory.Container.Resolve<ChromeOptions>();

            cmdlet.WriteObject(cmdlet, options);
        }
        
        public static void SetChromeOptionsBinary(CommonCmdletBase cmdlet)
        {
            ChromeOptions options =
                ((EditChromeOptionsCmdletBase)cmdlet).InputObject;
            
            if (null == options) {
                cmdlet.WriteError(
                    cmdlet,
                    "The input Chrome options object is null.",
                    "InputIsNull",
                    ErrorCategory.InvalidArgument,
                    true);
            }
            
            string pathToBinary =
                ((SetSeChromeBinaryCommand)cmdlet).BinaryPath;
            
            if (null != pathToBinary && string.Empty != pathToBinary) {
                options.BinaryLocation = pathToBinary;
            }
            
            cmdlet.WriteObject(cmdlet, options);
        }
        
        public static void AddChromeArgument(CommonCmdletBase cmdlet)
        {
            ChromeOptions options =
                ((EditChromeOptionsCmdletBase)cmdlet).InputObject;
            if (null == options) {
                cmdlet.WriteError(
                    cmdlet,
                    "The input Chrome options object is null.",
                    "InputIsNull",
                    ErrorCategory.InvalidArgument,
                    true);
            }
            
            string[] argumentList =
                ((AddSeChromeArgumentCommand)cmdlet).ArgumentList;
            
            if (null != argumentList && 0 < argumentList.Length) {
                options.AddArguments(argumentList);
            }
            
            cmdlet.WriteObject(cmdlet, options);
        }
        
        public static void AddChromeExtension(CommonCmdletBase cmdlet)
        {
            ChromeOptions options =
                ((EditChromeOptionsCmdletBase)cmdlet).InputObject;
            if (null == options) {
                cmdlet.WriteError(
                    cmdlet,
                    "The input Chrome options object is null.",
                    "InputIsNull",
                    ErrorCategory.InvalidArgument,
                    true);
            }
            
            string[] extensionList =
                ((AddSeChromeExtensionCommand)cmdlet).ExtensionList;
            
            if (null != extensionList && 0 < extensionList.Length) {
                options.AddExtensions(extensionList);
            }
            
            cmdlet.WriteObject(cmdlet, options);
        }
        
        public static void GetNewIEOptions(CommonCmdletBase cmdlet)
        {
            InternetExplorerOptions options =
                WebDriverFactory.Container.Resolve<InternetExplorerOptions>();

            cmdlet.WriteObject(cmdlet, options);
        }
        
        public static void SetIEOption(CommonCmdletBase cmdlet)
        {
            throw new NotImplementedException();
            

        }
        
        public static void GetNewFirefoxProfile(CommonCmdletBase cmdlet)
        {
            FirefoxProfile profile =
                WebDriverFactory.GetFirefoxProfile(((FirefoxProfileCmdletBase)cmdlet));
            
            //profile.AddExtension
            
            //profile.SetPreference
            
            //profile.SetProxyPreferences
            
            cmdlet.WriteObject(cmdlet, profile);
        }
        
        public static void ConvertFromTable(CommonCmdletBase cmdlet)
        {
            throw new NotImplementedException();
        }
        

    }
}
