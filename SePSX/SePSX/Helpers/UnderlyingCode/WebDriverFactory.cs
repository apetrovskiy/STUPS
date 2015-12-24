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
    using OpenQA.Selenium.Remote;

    using Commands;

    //using Ninject;


    using Autofac;
    using Autofac.Builder;

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
                AutofacModule = new WebDriverModule();
            }
            catch (Exception eLoadingModule) {
                Console.WriteLine("Loading of module failed; " + eLoadingModule.Message);
            }
        }

        private static Module _autofacModule;
        internal static Module AutofacModule
        { 
            get { return _autofacModule; }
            set{ _autofacModule = value; _initFlag = false; }
        }
        
        private static ContainerBuilder _builder;
        internal static IContainer Container;
        private static bool _initFlag = false;
        
        internal static void Init()
        {
            if (!_initFlag) {
                try {

                    _builder = new ContainerBuilder();

                    _builder.RegisterModule(AutofacModule);

                    Container = null;

                    var container = _builder.Build(ContainerBuildOptions.Default);

                    Container = container;

                }
                catch (Exception efgh) {

                    Console.WriteLine(efgh.Message);
                }

                _initFlag = true;
            }
        }

        private static IWebDriver _driver;

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

                        var ffCapabilities = CapabilitiesFactory.GetCapabilities();

                        _driver = new FirefoxDriver(ffCapabilities);


                        SeHelper.GetDriverProcess(Drivers.Firefox, _driver.Title + SeHelper.DriverTitleComplementFirefox.Substring(3));

                        _driver.Manage().Timeouts().SetScriptTimeout(TimeSpan.FromSeconds(60));
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

                        _driver = GetNativeDriver(driverType);

                        SeHelper.GetDriverProcess(Drivers.Safari, _driver.Title + SeHelper.DriverTitleComplementSafari);
                        break;
                    case Drivers.Html:
                        _driver = new RemoteWebDriver(DesiredCapabilities.HtmlUnit());
                        break;
                    default:
                        throw new Exception("Invalid value for Drivers");
                }



                //
                //
                //return (new FirefoxDriver());
                return _driver;
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
                    case Drivers.Html:

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
            var driverDirectoryPath = string.Empty;
            ChromeOptions chromeOptions = null;
            InternetExplorerOptions ieOptions = null;
            var commandTimeout = TimeSpan.FromSeconds(60.0);
            DriverService service = null;
            var listOfParameters =
                new System.Collections.Generic.List<Autofac.Core.Parameter>();

            // determine the type of dirver server
            var driverServerType = DriverServers.None;
            var ieArchitecture = InternetExplorer.X86;
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
                    driverServerType = DriverServers.Chrome;
                    //driverType = Drivers.Chrome;
                    break;
                case Drivers.Firefox:
                    
                    break;
                case Drivers.InternetExplorer:
                    cmdlet.WriteVerbose(cmdlet, "required InternetExplorerDriver");
                    driverServerType = DriverServers.Ie;
                    ieArchitecture = cmdlet.Architecture;
                    //driverType = Drivers.InternetExplorer;
                    break;
                case Drivers.Safari:
                    
                    break;
                case Drivers.Html:
                    
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
                if (DriverServers.Ie == driverServerType && InternetExplorer.X86 == ieArchitecture) {
                    driverDirectoryPath += "\\32\\";
                }
                if (DriverServers.Ie == driverServerType && InternetExplorer.X64 == ieArchitecture) {
                    driverDirectoryPath += "\\64\\";
                }
            } else {

                cmdlet.WriteVerbose(cmdlet, "using the path from the cmdlet parameter");
                driverDirectoryPath = cmdlet.DriverDirectoryPath;
            }
            cmdlet.WriteVerbose(cmdlet, driverDirectoryPath);
            
            // ChromeOptions, InternetExplorerOptions
//            try {
            if (DriverServers.Chrome == driverServerType) {

                if (null == cmdlet.ChromeOptions) {

                    cmdlet.WriteVerbose(cmdlet, "using the default ChromeOptions");
                    
                    chromeOptions = new ChromeOptions();
                } else {

                    cmdlet.WriteVerbose(cmdlet, "using the supplied ChromeOptions");
                    chromeOptions = cmdlet.ChromeOptions;
                }
            }
            if (DriverServers.Ie == driverServerType) {

                if (null == cmdlet.IeOptions) {

                    cmdlet.WriteVerbose(cmdlet, "using the default InternetExplorerOptions");
                    
                    ieOptions = new InternetExplorerOptions();
                    ieOptions.IgnoreZoomLevel = true;
                } else {

                    cmdlet.WriteVerbose(cmdlet, "using the supplied InternetExplorerOptions");
                    ieOptions = cmdlet.IeOptions;
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
                case DriverServers.Chrome:
//Console.WriteLine("driver server 00012c");
                    cmdlet.WriteVerbose(cmdlet, "creating a ChromeDriverService");
//Console.WriteLine("creating chrome driver service");
                    service = ChromeDriverService.CreateDefaultService(driverDirectoryPath);
//Console.WriteLine("the chrome driver service has been created");
                    break;
                case DriverServers.Ie:

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
                case DriverServers.Chrome:
                
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
                        Container.ResolveNamed<IWebDriver>(
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
                case DriverServers.Ie:
                    listOfParameters.Add(new NamedParameter("service", service));
                    listOfParameters.Add(new NamedParameter("options", ieOptions));
                    listOfParameters.Add(new NamedParameter("commandTimeout", commandTimeout));
                    cmdlet.WriteVerbose(cmdlet, "creating the InternetExplorerDriver");
                    driver = 
                        Container.ResolveNamed<IWebDriver>(
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
            var listOfParameters =
                new System.Collections.Generic.List<Autofac.Core.Parameter>();

            var profileDirectory =
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
                            FirefoxProfileConstructorOptions.FfWithPathAndBool.ToString(),
                            listOfParameters);

                } else {

                    profile =
                        Container.ResolveNamed<FirefoxProfile>(
                            FirefoxProfileConstructorOptions.FfWithPath.ToString(),
                            listOfParameters);

                }
            } else {

                profile =
                    Container.ResolveNamed<FirefoxProfile>(
                        FirefoxProfileConstructorOptions.FfBare.ToString());

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
