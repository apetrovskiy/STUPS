/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/22/2012
 * Time: 11:39 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSX
{
    using System;
    using OpenQA.Selenium;
    //using OpenQA.Selenium.Android;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Firefox;
    using OpenQA.Selenium.IE;
    //using OpenQA.Selenium.PhantomJS;
    using OpenQA.Selenium.Safari;

    using OpenQA.Selenium.Remote;

    using SePSX.Commands;

    //using Ninject;


    using Autofac;
    using Autofac.Builder;
    using Autofac.Core;

    using System.Reflection;
    using Autofac.Core.Activators.Reflection;
    
    using System.Management.Automation;
    
    using System.Linq;

//    using Autofac.Core.Registration;
//    using Autofac.Core.Resolving;


//    using Ninject;
//    using Ninject.Activation;
//    using Ninject.Components;
//    using Ninject.Infrastructure;
//    using Ninject.Injection;


    /// <summary>
    /// Description of WebDriverFactory.
    /// </summary>
    //public static class WebDriverFactory
    public static class WebDriverFactory // : IWebDriverFactory
    {
        //public WebDriverFactory(Autofac.Module module)
        static WebDriverFactory()
        {
            try {
                WebDriverFactory.AutofacModule = new WebDriverModule();
            }
            catch (Exception eLoadingModule) {
                Console.WriteLine("Loading of module failed; " + eLoadingModule.Message);
            }
        }

        private static Autofac.Module autofacModule;
        internal static Autofac.Module AutofacModule
        { 
            get { return autofacModule; }
            set{ autofacModule = value; initFlag = false; }
        }
        
        private static ContainerBuilder builder;
        internal static IContainer Container;
        private static bool initFlag = false;
        
        internal static void Init()
        {
            if (!initFlag) {
                try {

                    builder = new ContainerBuilder();

                    builder.RegisterModule(WebDriverFactory.AutofacModule);

                    WebDriverFactory.Container = null;

                    var container = builder.Build(ContainerBuildOptions.Default);

                    WebDriverFactory.Container = container;

                }
                catch (Exception efgh) {

                    Console.WriteLine(efgh.Message);
                }

                initFlag = true;
            }
        }

        private static IWebDriver driver;

        public static IWebDriver GetDriver(StartDriverCmdletBase cmdlet, Drivers driverType)
        {

            try {

                // enumerate driver processes before creating new one
                SeHelper.CollectDriverProcesses(driverType);

                switch (driverType) {
//                    case Drivers.Chrome:
//                        //SeHelper.CollectDriverProcesses(Drivers.Chrome);
////                    ChromeOptions optCh = 
////                        new ChromeOptions();
//
//                        ChromeOptions optCh = //OptionsFactory.GetChromeOptions();
//                        // resolve ChromeOptions
//                        WebDriverFactory.Container.Resolve<ChromeOptions>();
//
//                        // 20121003
//                        //driver = new ChromeDriver(optCh);
//
//                        // 20121003
//                        OpenQA.Selenium.Chrome.ChromeDriverService chromeService = OpenQA.Selenium.Chrome.ChromeDriverService.CreateDefaultService();
//                        //cmdlet.WriteObject(cmdlet, chromeService.ServiceUrl);
//                        //cmdlet.WriteObject(cmdlet, chromeService);
//                        //chromeService.Start();
//
//                        driver = new ChromeDriver(chromeService, optCh, TimeSpan.FromSeconds(60));
//
//                        SeHelper.GetDriverProcess(Drivers.Chrome, driver.Title + SeHelper.DriverTitleComplementChrome);
//                        break;
                    case Drivers.Firefox:
                        //SeHelper.CollectDriverProcesses(Drivers.Firefox);

                        // 20121003
                        //FirefoxProfile ffProfile = new FirefoxProfile();
                        //ffProfile.AcceptUntrustedCertificates = true;
                        //ffProfile.EnableNativeEvents = true;
                        ////driver = new FirefoxDriver();
                        //driver = new FirefoxDriver(ffProfile);


                        // 20121003
//                            ICapabilities ffCapabilities =
//                                new OpenQA.Selenium.Support.Events.WebElementEventArgs
//                    ICapabilities ffCapabilities =
//                        new DesiredCapabilities();

                        ICapabilities ffCapabilities = CapabilitiesFactory.GetCapabilities();

                        driver = new FirefoxDriver(ffCapabilities);


                        SeHelper.GetDriverProcess(Drivers.Firefox, driver.Title + SeHelper.DriverTitleComplementFirefox.Substring(3));

                        driver.Manage().Timeouts().SetScriptTimeout(System.TimeSpan.FromSeconds(60));
                        break;
//                    case Drivers.InternetExplorer:
//                        //OpenQA.Selenium.IE.InternetExplorerOptions optIE =
//                        //    new InternetExplorerOptions();
//                        //optIE.
////                    InternetExplorerOptions optIE =
////                        new InternetExplorerOptions();
//
//                        //InternetExplorerOptions optIE = OptionsFactory.GetIEOptions();
//                        InternetExplorerOptions optIE =
//                          WebDriverFactory.Container.Resolve<InternetExplorerOptions>();
//
//                        optIE.EnableNativeEvents = true;
//                        optIE.IgnoreZoomLevel = true;
//                        optIE.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
//
//
//                        //SeHelper.CollectDriverProcesses(Drivers.InternetExplorer);
//
//                        //string ieSubFolder = string.Empty;
//                        // 20120901
//                        //System.Reflection.Assembly[] assms = 
//                        //    System.AppDomain.CurrentDomain.GetAssemblies();
//                        //foreach (System.Reflection.Assembly assm in assms) {
//                        //    if (assm.FullName.Contains("SePSX")) {
//                        //        ieSubFolder = 
//                        //            assm.Location.Substring(0, assm.Location.LastIndexOf('\\'));
//                        //        break;
//                        //    }
//                        //}
//
//                        string ieSubFolder = System.IO.Path.GetDirectoryName(cmdlet.GetType().Assembly.Location);
//
//                        if (cmdlet.Architecture == InternetExplorer.x86) {
//                            ieSubFolder += "\\32\\";
//                        }
//                        if (cmdlet.Architecture == InternetExplorer.x64) {
//                            ieSubFolder += "\\64\\";
//                        }
//
//
//                        //driver = new InternetExplorerDriver(
//
//                        // 20121003
//                        OpenQA.Selenium.DriverService ieService = OpenQA.Selenium.IE.InternetExplorerDriverService.CreateDefaultService(ieSubFolder);
//
//                        ieService.Start();
//
//
//                        driver = new InternetExplorerDriver(ieService, optIE, TimeSpan.FromSeconds(10));
//
//                        // 20121003
//                        //driver = new InternetExplorerDriver(ieSubFolder, optIE);
//
//                        SeHelper.GetDriverProcess(Drivers.InternetExplorer, driver.Title + SeHelper.DriverTitleComplementInternetExplorer);
//                        break;
                    case Drivers.Safari:
                        //SeHelper.CollectDriverProcesses(Drivers.Safari);

                        //driver = new SafariDriver();
                        //driver = WebDriverFactory.GetNativeDriver(driverType);

                        driver = GetNativeDriver(driverType);

                        SeHelper.GetDriverProcess(Drivers.Safari, driver.Title + SeHelper.DriverTitleComplementSafari);
                        break;
                    case Drivers.HTML:
                        driver = new RemoteWebDriver(DesiredCapabilities.HtmlUnit());
                        break;
                    default:
                        throw new Exception("Invalid value for Drivers");
                }



                //
                //
                //return (new FirefoxDriver());
                return driver;
                //
                //

            } catch (Exception ee) {
                Console.WriteLine(ee.Message);
                return null;
            }
        }

        private static IWebDriver _nativeDriver;

        internal static IWebDriver NativeDriver {
            get { return _nativeDriver; }
            set { _nativeDriver = value; }
        }

        internal static IWebDriver GetNativeDriver(Drivers driverType)
        {
            try {
//            //[Inject]
//            [Ninject.Inject]
//            IWebDriver driver = null;

//            [InjectAttribute]
                IWebDriver nativeDriver = null;

                switch (driverType) {
                    case Drivers.Chrome:

                        break;
                    case Drivers.Firefox:

                        break;
                    case Drivers.InternetExplorer:

                        break;
                    case Drivers.Safari:

                        nativeDriver = NativeDriver;
                        //new SafariDriver();

                        break;
                    case Drivers.HTML:

                        break;
                    default:
                        throw new Exception("Invalid value for Drivers");
                }

                //return driver;
                //return NativeDriver;
                return nativeDriver;
            } catch (Exception ee) {
                Console.WriteLine(ee.Message);
                return null;
            }
        }

        public static IWebDriver GetDriverServer(StartSeWebDriverCommand cmdlet)
        {
            IWebDriver driver = null;
            string driverDirectoryPath = string.Empty;
            ChromeOptions chromeOptions = null;
            InternetExplorerOptions ieOptions = null;
            TimeSpan commandTimeout = TimeSpan.FromSeconds(60.0);
            DriverService service = null;
            System.Collections.Generic.List<Autofac.Core.Parameter> listOfParameters =
                new System.Collections.Generic.List<Autofac.Core.Parameter>();

            // determine the type of dirver server
            DriverServers driverServerType = DriverServers.none;
            InternetExplorer ieArchitecture = InternetExplorer.x86;
//            Drivers driverType = Drivers.HTML;
//            if (true == cmdlet.CH) {
//                cmdlet.WriteVerbose(cmdlet, "required ChromeDriver");
//                driverServerType = DriverServers.chrome;
//                driverType = Drivers.Chrome;
//            }
//            if (true == cmdlet.IE) {
//                cmdlet.WriteVerbose(cmdlet, "required InternetExplorerDriver");
//                driverServerType = DriverServers.ie;
//                ieArchitecture = cmdlet.Architecture;
//                driverType = Drivers.InternetExplorer;
//            }
            
            switch (cmdlet.DriverType) {
                case Drivers.Chrome:
                    cmdlet.WriteVerbose(cmdlet, "required ChromeDriver");
                    driverServerType = DriverServers.chrome;
                    //driverType = Drivers.Chrome;
                    break;
                case Drivers.Firefox:
                    
                    break;
                case Drivers.InternetExplorer:
                    cmdlet.WriteVerbose(cmdlet, "required InternetExplorerDriver");
                    driverServerType = DriverServers.ie;
                    ieArchitecture = cmdlet.Architecture;
                    //driverType = Drivers.InternetExplorer;
                    break;
                case Drivers.Safari:
                    
                    break;
                case Drivers.HTML:
                    
                    break;
                default:
                    throw new Exception("Invalid value for Drivers");
            }

            // collect processes before running the server
            cmdlet.WriteVerbose(cmdlet, "collect processes");

            SeHelper.CollectDriverProcesses(cmdlet.DriverType);

            // driverDirectoryPath
            if (string.IsNullOrEmpty(cmdlet.DriverDirectoryPath)) {

                cmdlet.WriteVerbose(cmdlet, "using the default driver directory path");
                driverDirectoryPath =
                    System.IO.Path.GetDirectoryName(cmdlet.GetType().Assembly.Location);
                if (DriverServers.ie == driverServerType && InternetExplorer.x86 == ieArchitecture) {
                    driverDirectoryPath += "\\32\\";
                }
                if (DriverServers.ie == driverServerType && InternetExplorer.x64 == ieArchitecture) {
                    driverDirectoryPath += "\\64\\";
                }
            } else {

                cmdlet.WriteVerbose(cmdlet, "using the path from the cmdlet parameter");
                driverDirectoryPath = cmdlet.DriverDirectoryPath;
            }
            cmdlet.WriteVerbose(cmdlet, driverDirectoryPath);
            
            // ChromeOptions, InternetExplorerOptions
//            try {
            if (DriverServers.chrome == driverServerType) {

                if (null == cmdlet.ChromeOptions) {

                    cmdlet.WriteVerbose(cmdlet, "using the default ChromeOptions");
                    
                    chromeOptions = new ChromeOptions();
                } else {

                    cmdlet.WriteVerbose(cmdlet, "using the supplied ChromeOptions");
                    chromeOptions = cmdlet.ChromeOptions;
                }
            }
            if (DriverServers.ie == driverServerType) {

                if (null == cmdlet.IEOptions) {

                    cmdlet.WriteVerbose(cmdlet, "using the default InternetExplorerOptions");
                    
                    ieOptions = new InternetExplorerOptions();
                    ieOptions.IgnoreZoomLevel = true;
                } else {

                    cmdlet.WriteVerbose(cmdlet, "using the supplied InternetExplorerOptions");
                    ieOptions = cmdlet.IEOptions;
                }
            }
            
            // commandTimeout
            if (null != cmdlet.Timeout && 0 != cmdlet.Timeout && Preferences.Timeout != cmdlet.Timeout) { // ??

                cmdlet.WriteVerbose(cmdlet, "setting the commandTimeout");
                commandTimeout = TimeSpan.FromMilliseconds(cmdlet.Timeout);
                cmdlet.WriteVerbose(cmdlet, "commandTimeout = " + commandTimeout.ToString());
            }
            
            // creating the driver server service
            cmdlet.WriteVerbose(cmdlet, "creating a DriverService");
//            try {
            //Autofac.NamedParameter driverDirectoryParameter =
            //    new NamedParameter("driverPath", driverDirectoryPath);
            switch (driverServerType) {
//                case DriverServers.none:
//                    
//                    break;
                case DriverServers.chrome:
//Console.WriteLine("driver server 00012c");
                    cmdlet.WriteVerbose(cmdlet, "creating a ChromeDriverService");
//Console.WriteLine("creating chrome driver service");
                    service = ChromeDriverService.CreateDefaultService(driverDirectoryPath);
//Console.WriteLine("the chrome driver service has been created");
                    break;
                case DriverServers.ie:

                    cmdlet.WriteVerbose(cmdlet, "creating a InternetExplorerDriverService");
                    
                    service = InternetExplorerDriverService.CreateDefaultService(driverDirectoryPath);

                    break;
                default:
                    throw new Exception("Invalid value for DriverServers");
            }
            
            switch (driverServerType) {
//                case DriverServers.none:
//                    
//                    break;
                case DriverServers.chrome:
                
                    listOfParameters.Add(new NamedParameter("service", service));
                    listOfParameters.Add(new NamedParameter("options", chromeOptions));
                    listOfParameters.Add(new NamedParameter("commandTimeout", commandTimeout));
                    
                    cmdlet.WriteVerbose(cmdlet, "creating the ChromeDriver");
                    try {
//ChromeDriverService service1 = ChromeDriverService.CreateDefaultService();
//DriverService service2 = ChromeDriverService.CreateDefaultService();
//Console.WriteLine("driverServerType.ToString() = " + driverServerType.ToString());
//Console.WriteLine(listOfParameters.Count.ToString());
//Console.WriteLine("creating driver");
                    driver = 
                        WebDriverFactory.Container.ResolveNamed<IWebDriver>(
                            driverServerType.ToString(),
                            listOfParameters);
//Console.WriteLine("driver has been created");
                    }
                    catch (Exception eChDrv) {
                        Console.WriteLine(eChDrv.Message);
                        Console.WriteLine(eChDrv.StackTrace);
                    }
                    
                    //
//                    ChromeDriver drv = new ChromeDriver();
//                    ChromeDriver drv = new ChromeDriver("opt");
//                    ChromeDriver drv = new ChromeDriver("dir");
//                    ChromeDriver drv = new ChromeDriver("dir", "opt");
//                    ChromeDriver drv = new ChromeDriver("dir", "opt", "timeout");
//                    ChromeDriver drv = new ChromeDriver("svc", "opt");
//                    ChromeDriver drv = new ChromeDriver("svc", "opt", "timeout");
                    //
                    
                    break;
                case DriverServers.ie:
                    listOfParameters.Add(new NamedParameter("service", service));
                    listOfParameters.Add(new NamedParameter("options", ieOptions));
                    listOfParameters.Add(new NamedParameter("commandTimeout", commandTimeout));
                    cmdlet.WriteVerbose(cmdlet, "creating the InternetExplorerDriver");
                    driver = 
                        WebDriverFactory.Container.ResolveNamed<IWebDriver>(
                            driverServerType.ToString(),
                            listOfParameters.ToArray());
                    break;
                default:

                    throw new Exception("Invalid value for DriverServers");
            }
            
            // getting the process of the driver server running
            cmdlet.WriteVerbose(cmdlet, "findng out the process of the driver created");
            //switch (driverType) {
            switch (cmdlet.DriverType) {
                case Drivers.Chrome:
                    //SeHelper.GetDriverProcess(Drivers.Chrome, driver.Title + SeHelper.DriverTitleComplementChrome);
                    //SeHelper.GetDriverProcess(driverType, driver.Title + SeHelper.DriverTitleComplementChrome);
                    SeHelper.GetDriverProcess(cmdlet.DriverType, driver.Title + SeHelper.DriverTitleComplementChrome);
                    break;
//                case Drivers.Firefox:
//                    
//                    break;
                case Drivers.InternetExplorer:
                    //SeHelper.GetDriverProcess(Drivers.InternetExplorer, driver.Title + SeHelper.DriverTitleComplementInternetExplorer);
                    //SeHelper.GetDriverProcess(driverType, driver.Title + SeHelper.DriverTitleComplementInternetExplorer);
                    SeHelper.GetDriverProcess(cmdlet.DriverType, driver.Title + SeHelper.DriverTitleComplementInternetExplorer);
                    break;
//                case Drivers.Safari:
//                    
//                    break;
//                case Drivers.HTML:
//                    
//                    break;
//                default:
//                    throw new Exception("Invalid value for Drivers");
            }
            
            // return driver
            return driver;
            
        }

        public static FirefoxProfile GetFirefoxProfile(FirefoxProfileCmdletBase cmdlet)
        {
            FirefoxProfile profile = null;
            System.Collections.Generic.List<Autofac.Core.Parameter> listOfParameters =
                new System.Collections.Generic.List<Autofac.Core.Parameter>();

            string profileDirectory =
                ((NewSeFirefoxProfileCommand)cmdlet).ProfileDirectoryPath;
            bool deleteSourceOnClean =
                ((NewSeFirefoxProfileCommand)cmdlet).DeleteSource;

            if (!string.IsNullOrEmpty(profileDirectory)) {

                listOfParameters.Add(
                    new NamedParameter(
                        "profileDirectory",
                        profileDirectory));

                if (deleteSourceOnClean) {

                    listOfParameters.Add(
                        new NamedParameter(
                            "deleteSourceOnClean",
                            deleteSourceOnClean));

                    profile =
                        Container.ResolveNamed<FirefoxProfile>(
                            FirefoxProfileConstructorOptions.ff_with_path_and_bool.ToString(),
                            listOfParameters);

                } else {

                    profile =
                        Container.ResolveNamed<FirefoxProfile>(
                            FirefoxProfileConstructorOptions.ff_with_path.ToString(),
                            listOfParameters);

                }
            } else {

                profile =
                    Container.ResolveNamed<FirefoxProfile>(
                        FirefoxProfileConstructorOptions.ff_bare.ToString());

            }

            return profile;
        }
        
        public static IWebDriver GetFirefoxDriver(StartSeDriverServerCommand cmdlet)
        {
            //
            //
            return (new FirefoxDriver());
            //
            //
        }
    }
}
