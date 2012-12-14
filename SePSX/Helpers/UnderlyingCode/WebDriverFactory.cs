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
//Console.WriteLine("!!!! <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< constructor >>>>>>>>>>>>>>>>>>>>>>>>>>>>> !!!!");
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
//Console.WriteLine("!!!! <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< Init() >>>>>>>>>>>>>>>>>>>>>>>>>>>>> !!!!");
		    if (!initFlag) {
    		    try {
//Console.WriteLine("init 001");
                    builder = new ContainerBuilder();
//Console.WriteLine("init 002");
//if (null == WebDriverFactory.AutofacModule) {
//    Console.WriteLine("null == WebDriverFactory.autofacModule");
//} else {
//    Console.WriteLine("null != WebDriverFactory.autofacModule");
//}
                    builder.RegisterModule(WebDriverFactory.AutofacModule);
//Console.WriteLine("init 003");
                    WebDriverFactory.Container = null;
//Console.WriteLine("init 004");
//if (null == ContainerBuildOptions.Default) {
//    Console.WriteLine("null == ContainerBuildOptions.Default");
//} else {
//    Console.WriteLine("null != ContainerBuildOptions.Default");
//}
//if (null == builder) {
//    Console.WriteLine("null == builder");
//} else {
//    Console.WriteLine("null != builder");
//}
                    //WebDriverFactory.Container = builder.Build(ContainerBuildOptions.Default); //(ContainerBuildOptions.None);
                    var container = builder.Build(ContainerBuildOptions.Default); //(ContainerBuildOptions.None);
//Console.WriteLine("init 005");
                    WebDriverFactory.Container = container;
//Console.WriteLine("init 005-2");
    		    }
    		    catch (Exception efgh) {
//Console.WriteLine("init 006");
    		        Console.WriteLine(efgh.Message);
    		    }
//Console.WriteLine("init 007");
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
//					case Drivers.Chrome:
//						//SeHelper.CollectDriverProcesses(Drivers.Chrome);
////                    ChromeOptions optCh = 
////                        new ChromeOptions();
//
//						ChromeOptions optCh = //OptionsFactory.GetChromeOptions();
//						// resolve ChromeOptions
//                        WebDriverFactory.Container.Resolve<ChromeOptions>();
//
//						// 20121003
//						//driver = new ChromeDriver(optCh);
//
//						// 20121003
//						OpenQA.Selenium.Chrome.ChromeDriverService chromeService = OpenQA.Selenium.Chrome.ChromeDriverService.CreateDefaultService();
//						//cmdlet.WriteObject(cmdlet, chromeService.ServiceUrl);
//						//cmdlet.WriteObject(cmdlet, chromeService);
//						//chromeService.Start();
//
//						driver = new ChromeDriver(chromeService, optCh, TimeSpan.FromSeconds(60));
//
//						SeHelper.GetDriverProcess(Drivers.Chrome, driver.Title + SeHelper.DriverTitleComplementChrome);
//						break;
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
//					case Drivers.InternetExplorer:
//						//OpenQA.Selenium.IE.InternetExplorerOptions optIE =
//						//	new InternetExplorerOptions();
//						//optIE.
////                    InternetExplorerOptions optIE =
////                        new InternetExplorerOptions();
//
//						//InternetExplorerOptions optIE = OptionsFactory.GetIEOptions();
//						InternetExplorerOptions optIE =
//						  WebDriverFactory.Container.Resolve<InternetExplorerOptions>();
//
//						optIE.EnableNativeEvents = true;
//						optIE.IgnoreZoomLevel = true;
//						optIE.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
//
//
//						//SeHelper.CollectDriverProcesses(Drivers.InternetExplorer);
//
//						//string ieSubFolder = string.Empty;
//						// 20120901
//						//System.Reflection.Assembly[] assms = 
//						//    System.AppDomain.CurrentDomain.GetAssemblies();
//						//foreach (System.Reflection.Assembly assm in assms) {
//						//    if (assm.FullName.Contains("SePSX")) {
//						//        ieSubFolder = 
//						//            assm.Location.Substring(0, assm.Location.LastIndexOf('\\'));
//						//        break;
//						//    }
//						//}
//
//						string ieSubFolder = System.IO.Path.GetDirectoryName(cmdlet.GetType().Assembly.Location);
//
//						if (cmdlet.Architecture == InternetExplorer.x86) {
//							ieSubFolder += "\\32\\";
//						}
//						if (cmdlet.Architecture == InternetExplorer.x64) {
//							ieSubFolder += "\\64\\";
//						}
//
////Console.WriteLine(ieSubFolder);
//
//						//driver = new InternetExplorerDriver(
//
//						// 20121003
//						OpenQA.Selenium.DriverService ieService = OpenQA.Selenium.IE.InternetExplorerDriverService.CreateDefaultService(ieSubFolder);
////Console.WriteLine(ieSubFolder + "IEDriverServer.exe");
//
//						ieService.Start();
//
////Console.WriteLine(ieService.ServiceUrl);
////Console.WriteLine(ieService.IsRunning.ToString());
//
//						driver = new InternetExplorerDriver(ieService, optIE, TimeSpan.FromSeconds(10));
//
////Console.WriteLine("started");
//						// 20121003
//						//driver = new InternetExplorerDriver(ieSubFolder, optIE);
//
//						SeHelper.GetDriverProcess(Drivers.InternetExplorer, driver.Title + SeHelper.DriverTitleComplementInternetExplorer);
//						break;
					case Drivers.Safari:
//Console.WriteLine("before collecting processes");
						//SeHelper.CollectDriverProcesses(Drivers.Safari);
//Console.WriteLine("before creating a driver");
						//driver = new SafariDriver();
						//driver = WebDriverFactory.GetNativeDriver(driverType);

						driver = GetNativeDriver(driverType);

//Console.WriteLine("before getting the handle");
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



#region commented
//		static internal void Init()
//		{
//			//kernel = new StandardKernel(new NChromeDriverModule());
//
//			builder = new ContainerBuilder();
//
////		    ConstructorInfo[] cInfos;
////		    foreach (Assembly assm in System.AppDomain.CurrentDomain.GetAssemblies()) {
////		        if (assm.FullName.Contains("WebDriver")) {
////		            System.Type chromeDriverType =
////		                assm.GetType();
////		            cInfos =
////		                chromeDriverType.GetConstructors();
////		            break;
////		        }
////		    }
////		    
////		    foreach (ConstructorInfo cInfo in cInfos) {
////		        ConstructorParameterBinding paramBinding =
////		            new ConstructorParameterBinding(
////		                cInfo,
////		        IConstructorSelector constrSelector =
////		            new MostParametersConstructorSelector();
////		        //constrSelector.
////		    }
//
////		    var builder = new ContainerBuilder();
////            builder.Register((c, p) => new Person(p.Named<string>("name")));
////            
////            using (var container = builder.Build())
////            {
////                var person = container.Resolve<Person>(new NamedParameter("name", "Fred"));    
////            }
//
////		    builder.RegisterType<IWebDriver>().As<ChromeDriver>();
////		    builder.Register<IWebDriver>((с, paramPath) => 
////		                                 new ChromeDriver(paramPath.Named<string>("chromeDriverDirectory")));
////		    builder.Register<IWebDriver>((с, paramOpt) => 
////		                                 new ChromeDriver(paramOpt.Named<ChromeOptions>("options")));
//			////		    builder.Register<IWebDriver>((IComponentContext с, string paramPath, ChromeOptions paramOpt) => 
//			////		                                 new ChromeDriver(
//			////		                                     paramPath.Named<string>("chromeDriverDirectory"),
//			////		                                     paramOpt.Named<ChromeOptions>("options")));
////		    builder.Register<IWebDriver>((с, parameters) => 
////		                                 new ChromeDriver(
////		                                     parameters[0].Named<string>("chromeDriverDirectory"),
////		                                     parameters[1].Named<ChromeOptions>("options")));
//
//
////            builder.RegisterType<DoesSomething>()
////                   .As<IDoesSomething>()
////                   .WithParameter("helper", new HelperClass("do", "something"));
////            
////            builder.RegisterType<DoesSomethingElse>()
////                   .As<IDoesSomethingElse()
////                   .WithParameter("helper", new HelperClass("do", "somethingelse"));
//
//			builder.RegisterType<ChromeDriver>()
//			    .As<IWebDriver>()
//			    .Named<IWebDriver>("bare");
//
//			builder.RegisterType<ChromeDriver>()
//			    .As<IWebDriver>().UsingConstructor(new Type[] {
//			                                           typeof(string)
//			                                       })
//			    .Named<IWebDriver>("with_path");
//
//			builder.RegisterType<ChromeDriver>()
//			    .As<IWebDriver>().UsingConstructor(new Type[] {
//			                                       typeof(ChromeOptions)
//			                                       })
//			    .Named<IWebDriver>("with_options");
//
//			builder.RegisterType<ChromeDriver>()
//			    .As<IWebDriver>().UsingConstructor(new Type[] {
//			                                           typeof(string),
//			                                           typeof(ChromeOptions)
//			                                       })
//			    .Named<IWebDriver>("with_path_and_options");
//
//			builder.RegisterType<ChromeDriver>()
//			    .As<IWebDriver>().UsingConstructor(new Type[] {
//			                                           typeof(string),
//			                                           typeof(ChromeOptions),
//			                                           typeof(TimeSpan)
//			                                       })
//			    .Named<IWebDriver>("with_path_and_options_and_timespan");
//
//			builder.RegisterType<ChromeDriver>()
//			    .As<IWebDriver>().UsingConstructor(new Type[] {
//			                                           typeof(DriverService),
//			                                           typeof(ChromeOptions),
//			                                           typeof(TimeSpan)
//			                                       })
//			    .Named<IWebDriver>("with_service_and_options_and_timespan");
//
//			container = builder.Build(ContainerBuildOptions.None);
//
//		}
		
//		
//		static internal void InitUnitTest()
//		{
//			//kernel = new StandardKernel(new NChromeDriverModule());
//
//			builder = new ContainerBuilder();
//
//			builder.RegisterType<FakeWebDriver>()
//			    .As<IWebDriver>()
//			    .Named<IWebDriver>("bare");
//
//			builder.RegisterType<FakeWebDriver>()
//			    .As<IWebDriver>().UsingConstructor(new Type[] {
//			                                           typeof(string)
//			                                       })
//			    .Named<IWebDriver>("with_path");
//
//			builder.RegisterType<FakeWebDriver>()
//			    .As<IWebDriver>().UsingConstructor(new Type[] {
//			                                       typeof(ChromeOptions)
//			                                       })
//			    .Named<IWebDriver>("with_options");
//
//			builder.RegisterType<FakeWebDriver>()
//			    .As<IWebDriver>().UsingConstructor(new Type[] {
//			                                           typeof(string),
//			                                           typeof(ChromeOptions)
//			                                       })
//			    .Named<IWebDriver>("with_path_and_options");
//
//			builder.RegisterType<FakeWebDriver>()
//			    .As<IWebDriver>().UsingConstructor(new Type[] {
//			                                           typeof(string),
//			                                           typeof(ChromeOptions),
//			                                           typeof(TimeSpan)
//			                                       })
//			    .Named<IWebDriver>("with_path_and_options_and_timespan");
//
//			builder.RegisterType<FakeWebDriver>()
//			    .As<IWebDriver>().UsingConstructor(new Type[] {
//			                                           typeof(DriverService),
//			                                           typeof(ChromeOptions),
//			                                           typeof(TimeSpan)
//			                                       })
//			    .Named<IWebDriver>("with_service_and_options_and_timespan");
//
//			container = builder.Build(ContainerBuildOptions.None);
//
//		}
#endregion commented

#region commented
//        internal static IWebDriver GetDriverServerWithParameters(
//            System.Collections.Generic.List<Autofac.Core.Parameter> listOfParameters,
//            ChromeDriverConstructorOptions constructorOptions)
//        {
//            IWebDriver chromeDriver =
//                Container.ResolveNamed<IWebDriver>(
//                    constructorOptions.ToString(),
//                    listOfParameters);
//            return chromeDriver;
//        }
//        
//        internal static IWebDriver GetDriverServerWithParameters(
//            System.Collections.Generic.List<Autofac.Core.Parameter> listOfParameters,
//            IEDriverConstructorOptions constructorOptions)
//        {
//            IWebDriver ieDriver =
//                Container.ResolveNamed<IWebDriver>(
//                    constructorOptions.ToString(),
//                    listOfParameters);
//            return ieDriver;
//        }
#endregion commented

#region commented
//        internal static IWebDriver GetDriverServerWithParameters(
//            System.Collections.Generic.List<Autofac.Core.Parameter> listOfParameters,
//            DriverServerConstructorOptions constructorOptions,
//            DriverServers driverServerType)
//        {
//    
//#region commented
////if (null == listOfParameters) {
////    Console.WriteLine("null == listOfParameters");
////} else {
////    Console.WriteLine("null != listOfParameters");
////}
////if (0 == listOfParameters.Count) {
////    Console.WriteLine("0 == listOfParameters.Count");
////} else {
////    Console.WriteLine("0 != listOfParameters.Count");
////}
////if (null == constructorOptions) {
////    Console.WriteLine("null == constructorOptions");
////} else {
////    Console.WriteLine("null != constructorOptions");
////}
////if (null == Container) {
////    Console.WriteLine("null == Container");
////} else {
////    Console.WriteLine("null != Container");
////}
//#endregion commented
//
//            string prefix = string.Empty;
//            switch (driverServerType) {
//                case SePSX.DriverServers.none:
//                    //
//                    break;
//                case SePSX.DriverServers.chrome:
//                    prefix = "chrome_";
//                    break;
//                case SePSX.DriverServers.ie:
//                    prefix = "ie_";
//                    break;
//                default:
//                    throw new Exception("Invalid value for DriverServers");
//            }
//            IWebDriver driverServer =
//                Container.ResolveNamed<IWebDriver>(
//                    prefix +
//                    constructorOptions.ToString(),
//                    listOfParameters);
//            return driverServer;
////    				driverServer =
////    				    Container.ResolveNamed<IWebDriver>(
////    				        ChromeDriverConstructorOptions.chrome_with_service_and_options_and_timespan.ToString(),
////    				        listOfParameters);
//        }
#endregion commented

        public static IWebDriver GetDriverServer(StartSeWebDriverCommand cmdlet)
        {
//Console.WriteLine("driver server 00001");
            IWebDriver driver = null;
            string driverDirectoryPath = string.Empty;
            ChromeOptions chromeOptions = null;
            InternetExplorerOptions ieOptions = null;
            TimeSpan commandTimeout = TimeSpan.FromSeconds(60.0);
            DriverService service = null;
            System.Collections.Generic.List<Autofac.Core.Parameter> listOfParameters =
			    new System.Collections.Generic.List<Autofac.Core.Parameter>();
//Console.WriteLine("driver server 00002");
            // determine the type of dirver server
            DriverServers driverServerType = DriverServers.none;
            InternetExplorer ieArchitecture = InternetExplorer.x86;
//            Drivers driverType = Drivers.HTML;
//            if (true == cmdlet.CH) {
////Console.WriteLine("driver server 00003c");
//                cmdlet.WriteVerbose(cmdlet, "required ChromeDriver");
//                driverServerType = DriverServers.chrome;
//                driverType = Drivers.Chrome;
//            }
//            if (true == cmdlet.IE) {
////Console.WriteLine("driver server 00003i");
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
            
//Console.WriteLine("driver server 00004");
            // collect processes before running the server
            cmdlet.WriteVerbose(cmdlet, "collect processes");
            //SeHelper.CollectDriverProcesses(driverType);
            SeHelper.CollectDriverProcesses(cmdlet.DriverType);
//Console.WriteLine("driver server 00005");
            // driverDirectoryPath
            if (null == cmdlet.DriverDirectoryPath || string.Empty == cmdlet.DriverDirectoryPath) {
//Console.WriteLine("driver server 00006");
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
//Console.WriteLine("driver server 00007");
                cmdlet.WriteVerbose(cmdlet, "using the path from the cmdlet parameter");
                driverDirectoryPath = cmdlet.DriverDirectoryPath;
            }
            cmdlet.WriteVerbose(cmdlet, driverDirectoryPath);
            
            // ChromeOptions, InternetExplorerOptions
//            try {
            if (DriverServers.chrome == driverServerType) {
//Console.WriteLine("driver server 00008c");
                if (null == cmdlet.ChromeOptions) {
//Console.WriteLine("driver server 00009c");
                    cmdlet.WriteVerbose(cmdlet, "using the default ChromeOptions");
                    
#region commented
//                    if (WebDriverFactory.Container.IsRegistered<ChromeOptions>()) {
//                        cmdlet.WriteVerbose(cmdlet, "creating the default ChromeOptions");
//                        chromeOptions = WebDriverFactory.Container.Resolve<ChromeOptions>();
//                    }
#endregion commented

                    chromeOptions = new ChromeOptions();
                } else {
//Console.WriteLine("driver server 00010c");
                    cmdlet.WriteVerbose(cmdlet, "using the supplied ChromeOptions");
                    chromeOptions = cmdlet.ChromeOptions;
                }
            }
            if (DriverServers.ie == driverServerType) {
//Console.WriteLine("driver server 00008i");
                if (null == cmdlet.IEOptions) {
//Console.WriteLine("driver server 00009i");
                    cmdlet.WriteVerbose(cmdlet, "using the default InternetExplorerOptions");
                    
#region commented
//                    if (WebDriverFactory.Container.IsRegistered<InternetExplorerOptions>()) {
//                        cmdlet.WriteVerbose(cmdlet, "creating the default InternetExplorerOptions");
//                        ieOptions = WebDriverFactory.Container.Resolve<InternetExplorerOptions>();
//                    }
#endregion commented

                    ieOptions = new InternetExplorerOptions();
                    ieOptions.IgnoreZoomLevel = true;
                } else {
//Console.WriteLine("driver server 00010i");
                    cmdlet.WriteVerbose(cmdlet, "using the supplied InternetExplorerOptions");
                    ieOptions = cmdlet.IEOptions;
                }
            }
            
#region commented
//            }
//            catch (Exception efgh) {
//                Console.WriteLine(efgh.Message);
//                Console.WriteLine(efgh.GetType().Name);
//            }
#endregion commented
            
            // commandTimeout
            if (null != cmdlet.Timeout && 0 != cmdlet.Timeout && Preferences.Timeout != cmdlet.Timeout) { // ??
//Console.WriteLine("driver server 00011");
//Console.WriteLine("<<<<<<<<<<<<<<<<<<timeout>>>>>>>>>>>>>>>>>>");
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
                    
#region commented
//Console.WriteLine("00001");
//Console.WriteLine(driverDirectoryPath);
//Console.WriteLine("00002");
                    //service = Container.Resolve<ChromeDriverService>(driverDirectoryParameter);
                    //try {
#endregion commented
                    
                    service = ChromeDriverService.CreateDefaultService(driverDirectoryPath);
                    
#region commented
                    //}
                    //catch (Exception eChromeDriverService) {
                    //    Console.WriteLine(eChromeDriverService.Message);
                    //    Console.WriteLine(eChromeDriverService.GetType().Name);
                    //}
#endregion commented
                    
//Console.WriteLine("driver server 00013c");

#region commented
                    //service =
                    //    WebDriverFactory.Container.Resolve<ChromeDriverService>();
                    
//Console.WriteLine("service done!");
#endregion commented

                    break;
                case DriverServers.ie:
//Console.WriteLine("driver server 00012i");
                    cmdlet.WriteVerbose(cmdlet, "creating a InternetExplorerDriverService");
                    
#region commented
                    //service = Container.Resolve<InternetExplorerDriverService>(driverDirectoryParameter);
                    //try {
#endregion commented
                    
                    service = InternetExplorerDriverService.CreateDefaultService(driverDirectoryPath);
                    
#region commented
                    //}
                    //catch (Exception eIEDriverService) {
                    //    Console.WriteLine(eIEDriverService.Message);
                    //    Console.WriteLine(eIEDriverService.GetType().Name);
                    //}
#endregion commented
                        
//Console.WriteLine("driver server 00013i");
//Console.WriteLine("service done!");
                    break;
                default:
Console.WriteLine("01 " + driverServerType.ToString());
                    throw new Exception("Invalid value for DriverServers");
            }
            
#region commented
//            }
//            catch (Exception efgh) {
//                Console.WriteLine(efgh.Message);
//                Console.WriteLine(efgh.GetType().Name);
//            }
            
            //IComponentContext context = Autofac.PropertyWiringFlags.
            
            // creating parameters list and creating the driver
//            try {
//Console.WriteLine("<<<<<<<<<<< driver: >>>>>>>>>>>>>>");
//Console.WriteLine(driverServerType.ToString());
#endregion commented

            switch (driverServerType) {
//                case DriverServers.none:
//                    
//                    break;
                case DriverServers.chrome:
                
#region commented
//if (null == service) {
//    Console.WriteLine("null == service");
//} else {
//    Console.WriteLine("null != service");
//}
//if (null == chromeOptions) {
//    Console.WriteLine("null == chromeOptions");
//} else {
//    Console.WriteLine("null != chromeOptions");
//}
//if (null == commandTimeout) {
//    Console.WriteLine("null == commandTimeout");
//} else {
//    Console.WriteLine("null != commandTimeout");
//}
#endregion commented

                    listOfParameters.Add(new NamedParameter("service", service));
                    listOfParameters.Add(new NamedParameter("options", chromeOptions));
                    listOfParameters.Add(new NamedParameter("commandTimeout", commandTimeout));
                    
#region commented
//if (null == listOfParameters) {
//    Console.WriteLine("null == listOfParameters");
//} else {
//    Console.WriteLine("null != listOfParameters");
//}
#endregion commented

                    cmdlet.WriteVerbose(cmdlet, "creating the ChromeDriver");
                    
#region commented
//Console.WriteLine(DriverServers.chrome.ToString());
//Console.WriteLine(listOfParameters.Count.ToString());
//if (null == Container) {
//    Console.WriteLine("null == Container");
//} else {
//    Console.WriteLine("null != Container");
//}
#endregion commented

                    driver = 
                        WebDriverFactory.Container.ResolveNamed<IWebDriver>(
                            //DriverServers.chrome.ToString(),
                            //"chrome",
                            driverServerType.ToString(),
                            listOfParameters);
//Console.WriteLine("done!");
                    break;
                case DriverServers.ie:
                    listOfParameters.Add(new NamedParameter("service", service));
                    listOfParameters.Add(new NamedParameter("options", ieOptions));
                    listOfParameters.Add(new NamedParameter("commandTimeout", commandTimeout));
                    cmdlet.WriteVerbose(cmdlet, "creating the InternetExplorerDriver");
                    driver = 
                        WebDriverFactory.Container.ResolveNamed<IWebDriver>(
                            //DriverServers.ie.ToString(),
                            driverServerType.ToString(),
                            listOfParameters.ToArray());
                    break;
                default:
Console.WriteLine("02 " + driverServerType.ToString());
                    throw new Exception("Invalid value for DriverServers");
            }
            
#region commented
//            }
//            catch (Exception eCreatingDriver) {
//                Console.WriteLine(eCreatingDriver.Message);
//                Console.WriteLine(eCreatingDriver.InnerException);
//                Console.WriteLine(eCreatingDriver.Source);
//                Console.WriteLine(eCreatingDriver.GetType().Name);
//            }
#endregion commented
            
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

#region commented
//        //public static IWebDriver GetDriverServer(StartSeDriverServerCommand cmdlet)
//        public static IWebDriver GetDriverServer(StartSeWebDriverCommand cmdlet)
//		{
//            
//			// working with the cmdlet parameters
////Console.WriteLine("000001");
//            DriverServers driverServerType = DriverServers.none;
//            switch (cmdlet.DriverName.ToUpper()) {
//                case SeHelper.driverNameChrome:
//                case SeHelper.driverNameChrome2:
//                    driverServerType = DriverServers.chrome;
//                    break;
//                case SeHelper.driverNameInternetExplorer:
//                case SeHelper.driverNameInternetExplorer2:
//                case SeHelper.driverNameInternetExplorer3:
//                case SeHelper.driverNameInternetExplorer4:
//                    driverServerType = DriverServers.ie;
//                    break;
//                default:
//                    
//                	break;
//            }
//            
//            SeHelper.CollectDriverProcesses(driverServerType);
//            
//			IWebDriver driverServer = null;
//			System.Collections.Generic.List<Autofac.Core.Parameter> listOfParameters =
//			    new System.Collections.Generic.List<Autofac.Core.Parameter>();
//
//			ChromeOptions chromeOptions = null;
//			InternetExplorerOptions ieOptions = null;
//			//ChromeDriverService service = null;
//			DriverService service = null;
//			string driverDirectoryPath = string.Empty;
//			TimeSpan timeSpan = System.TimeSpan.MinValue;
//			bool zeroTimeSpan = false;
////Console.WriteLine("000003");
//			if (cmdlet.AsService) {
////Console.WriteLine("000004");
//				if (null == cmdlet.DriverDirectoryPath ||
//			        string.Empty == cmdlet.DriverDirectoryPath ||
//			        !System.IO.Directory.Exists(cmdlet.DriverDirectoryPath)) {
////Console.WriteLine("000005");
//                    cmdlet.WriteVerbose(cmdlet, "DriverServer with service and no path");
//					//service = ChromeDriverService.CreateDefaultService();
////Console.WriteLine("000005____0000");
//					switch (driverServerType) {
//					    case SePSX.DriverServers.chrome:
////Console.WriteLine("000005____0001-1");
//					        service = ChromeDriverService.CreateDefaultService();
////Console.WriteLine("000005____0001-2");
//					        break;
//					    case SePSX.DriverServers.ie:
////Console.WriteLine("000005____0002-1");
//                            string ieSubFolder = System.IO.Path.GetDirectoryName(cmdlet.GetType().Assembly.Location);
//
//    						if (cmdlet.Architecture == InternetExplorer.x86) {
//    							ieSubFolder += "\\32\\";
//    						}
//    						if (cmdlet.Architecture == InternetExplorer.x64) {
//    							ieSubFolder += "\\64\\";
//    						}
//					        service = InternetExplorerDriverService.CreateDefaultService(ieSubFolder);
////Console.WriteLine("000005____0002-2");
//					        break;
//					    default:
////Console.WriteLine("000005____0003-1");
//					        throw new Exception("Invalid value for DriverServers");
//					}
////Console.WriteLine("000005____0004-1");
//				} else {
////Console.WriteLine("000006");
//                    cmdlet.WriteVerbose(cmdlet, "DriverServer with service and path");
//					//service = ChromeDriverService.CreateDefaultService(cmdlet.DriverDirectoryPath);
//					switch (driverServerType) {
//					    case SePSX.DriverServers.chrome:
//					        service = ChromeDriverService.CreateDefaultService(cmdlet.DriverDirectoryPath);
//					        break;
//					    case SePSX.DriverServers.ie:
//					        service = InternetExplorerDriverService.CreateDefaultService(cmdlet.DriverDirectoryPath);
//					        break;
//					    default:
//					        throw new Exception("Invalid value for DriverServers");
//					}
//				}
////Console.WriteLine("000007");
//				if (null == cmdlet.ChromeOptions) {
////Console.WriteLine("000008");
//					// resolve ChromeOptions
//					cmdlet.WriteVerbose(cmdlet, "ChromeDriver: producing options");
//					chromeOptions = 
//                        WebDriverFactory.Container.Resolve<ChromeOptions>();
//					if (null != chromeOptions) {
//					   cmdlet.WriteVerbose(cmdlet, "ChromeDriver: options produced");
//					} else {
//					    cmdlet.WriteVerbose(cmdlet, "ChromeDriver: options == null");
//					}
//				}
//				if (null == cmdlet.IEOptions) {
////Console.WriteLine("000008");
//					// resolve ChromeOptions
//					cmdlet.WriteVerbose(cmdlet, "InternetExplorerDriver: producing options");
//					ieOptions = 
//                        WebDriverFactory.Container.Resolve<InternetExplorerOptions>();
//					if (null != chromeOptions) {
//					   cmdlet.WriteVerbose(cmdlet, "InternetExplorerDriver: options produced");
//					} else {
//					    cmdlet.WriteVerbose(cmdlet, "InternetExplorerDriver: options == null");
//					}
//				}
//			}
////Console.WriteLine("000020");
//			switch (driverServerType) {
//			    case SePSX.DriverServers.chrome:
//        			if (null != cmdlet.ChromeOptions) {
////Console.WriteLine("000030");
//                        cmdlet.WriteVerbose(cmdlet, "ChromeDriver: options from the cmdlet parameter");
//        				chromeOptions = cmdlet.ChromeOptions;
//        				cmdlet.WriteVerbose(cmdlet, "ChromeDriver: options done");
//        
//        			}
//			        break;
//			    case SePSX.DriverServers.ie:
//        			if (null != cmdlet.IEOptions) {
////Console.WriteLine("000030");
//                        cmdlet.WriteVerbose(cmdlet, "InternetExplorerDriver: options from the cmdlet parameter");
//        				ieOptions = cmdlet.IEOptions;
//        				cmdlet.WriteVerbose(cmdlet, "InternetExplorerDriver: options done");
//        
//        			}
//			        break;
//			    default:
//			        throw new Exception("Invalid value for DriverServers");
//			}
//
////Console.WriteLine("000040");
//			if (null != cmdlet.DriverDirectoryPath) {
////Console.WriteLine("000050");
//				driverDirectoryPath = cmdlet.DriverDirectoryPath;
//			}
//
//			if (null != cmdlet.Timeout && 0 != cmdlet.Timeout) {
////Console.WriteLine("000060");
//			    cmdlet.WriteVerbose(cmdlet, "DriverServer: timeSpan from the comdlet parameter");
//				timeSpan = System.TimeSpan.FromMilliseconds(cmdlet.Timeout);
//			} else {
////Console.WriteLine("000070");
//			    cmdlet.WriteVerbose(cmdlet, "DriverServer: timeSpan from 60 seconds");
//				timeSpan = System.TimeSpan.FromSeconds(60);
//				zeroTimeSpan = true;
//
//			}
//
//			if (null != service) {
////Console.WriteLine("000080");
//				//IWebDriver chromeDriver = new ChromeDriver(DriverService "service", ChromeOptions "options", TimeSpan commandTimeout);
//				cmdlet.WriteVerbose(cmdlet, "IWebDriver chromeDriver = new ChromeDriver(DriverService \"service\", ChromeOptions \"options\", TimeSpan \"commandTimeout\");");
//                cmdlet.WriteVerbose(cmdlet, "DriverServer: service is not null");
//				listOfParameters.Add(new NamedParameter("service", service));
//				switch (driverServerType) {
//				    case SePSX.DriverServers.chrome:
//                        if (null == chromeOptions) {
////Console.WriteLine("000090");
//                            cmdlet.WriteVerbose(cmdlet, "ChromeDriver: options is null");
//                        } else {
////Console.WriteLine("000100");
//                            cmdlet.WriteVerbose(cmdlet, "ChromeDriver: options is not null");
//                        }
//        				listOfParameters.Add(new NamedParameter("options", chromeOptions));
//				        break;
//				    case SePSX.DriverServers.ie:
//                        if (null == ieOptions) {
////Console.WriteLine("000090");
//                            cmdlet.WriteVerbose(cmdlet, "InternetExplorerDriver: options is null");
//                        } else {
////Console.WriteLine("000100");
//                            cmdlet.WriteVerbose(cmdlet, "InternetExplorerDriver: options is not null");
//                        }
//        				listOfParameters.Add(new NamedParameter("options", ieOptions));
//				        break;
//				    default:
//				        throw new Exception("Invalid value for DriverServers");
//				}
//
//                if (null == timeSpan) {
////Console.WriteLine("000110");
//                    cmdlet.WriteVerbose(cmdlet, "DriverServer: timeSpan is null");
//                } else {
////Console.WriteLine("000120");
//                    cmdlet.WriteVerbose(cmdlet, "DriverServer: timeSpan is not null");
//                }
//				listOfParameters.Add(new NamedParameter("commandTimeout", timeSpan));
//
//                try {
////Console.WriteLine("000130");
//                    driverServer =
//			           GetDriverServerWithParameters(
//                            listOfParameters,
//                            DriverServerConstructorOptions.with_service_and_options_and_timespan,
//                            driverServerType);
////Console.WriteLine("000131");
////    				driverServer =
////    				    Container.ResolveNamed<IWebDriver>(
////    				        ChromeDriverConstructorOptions.chrome_with_service_and_options_and_timespan.ToString(),
////    				        listOfParameters);
//                }
//                catch (Exception eServiceOptionsTimeSpan) {
////Console.WriteLine("000132");
//                        cmdlet.WriteError(
//						    cmdlet,
//						    "Failed to create DriverServer with service, options and timeSpan. " + 
//						    eServiceOptionsTimeSpan.Message,
//						    "FailedWithService,Options,TimeSpan",
//						    ErrorCategory.InvalidOperation,
//						    true);
//                }
////Console.WriteLine("000133");
//                cmdlet.WriteVerbose(cmdlet, "DriverServer: driver with serivce is done");
////Console.WriteLine("000134");
//				return driverServer;
//
//			} else if (null != chromeOptions) {
////Console.WriteLine("000140");
//                cmdlet.WriteVerbose(cmdlet, "DriverServer: options is not null");
//				if (string.Empty == driverDirectoryPath) {
////Console.WriteLine("000150");
//                    cmdlet.WriteVerbose(cmdlet, "DriverServer: there's no directory path");
//					//IWebDriver chromeDriver = new ChromeDriver(ChromeOptions "options");
//					cmdlet.WriteVerbose(cmdlet, "IWebDriver chromeDriver = new ChromeDriver(ChromeOptions \"options\");");
//					listOfParameters.Add(new NamedParameter("options", chromeOptions));
//					try {
////Console.WriteLine("000160");
////						driverServer =
////						    Container.ResolveNamed<IWebDriver>(
////						        ChromeDriverConstructorOptions.chrome_with_options.ToString(),
////						        listOfParameters);
//						driverServer =
//						    GetDriverServerWithParameters(
//						        listOfParameters,
//						        DriverServerConstructorOptions.with_options,
//						        driverServerType);
//					} catch (Exception eOptionsOnly) {
//                        cmdlet.WriteError(
//						    cmdlet,
//						    "Failed to create DriverServer with options only. " + 
//						    eOptionsOnly.Message,
//						    "FailedWithOptionsOnly",
//						    ErrorCategory.InvalidOperation,
//						    true);
//					}
//                    cmdlet.WriteVerbose(cmdlet, "DriverServer with options only is done");
//					return driverServer;
//
//				} else {
////Console.WriteLine("000170");
//					listOfParameters.Add(new NamedParameter("chromeDriverDirectory", driverDirectoryPath));
//					listOfParameters.Add(new NamedParameter("options", chromeOptions));
//
//					if (zeroTimeSpan) {
////Console.WriteLine("000180");
//                        cmdlet.WriteVerbose(cmdlet, "DriverServer: with path and options");
//						//IWebDriver chromeDriver = new ChromeDriver(string "chromeDriverDirectory", ChromeOptions "options");
//						cmdlet.WriteVerbose(cmdlet, "IWebDriver chromeDriver = new ChromeDriver(string \"chromeDriverDirectory\", ChromeOptions \"options\");");
//						try {
////Console.WriteLine("000190");
////    						driverServer =
////    						    Container.ResolveNamed<IWebDriver>(
////    						        ChromeDriverConstructorOptions.chrome_with_path_and_options.ToString(),
////    						        listOfParameters);
//    						driverServer =
//    						    GetDriverServerWithParameters(
//    						        listOfParameters,
//    						        DriverServerConstructorOptions.with_path_and_options,
//    						        driverServerType);
//						}
//						catch (Exception ePathOptions) {
//						    cmdlet.WriteError(
//						        cmdlet,
//						        "Failed to create DriverServer with path and options. " +
//						        ePathOptions.Message,
//						        "FailedWithPathOptions",
//						        ErrorCategory.InvalidOperation,
//						        true);
//						}
//                        cmdlet.WriteVerbose(cmdlet, "DriverServer with path and options is done");
//						return driverServer;
//
//					} else {
////Console.WriteLine("000200");
//                        cmdlet.WriteVerbose(cmdlet, "DriverServer: with path, options and timeSpan");
//						//IWebDriver chromeDriver = new ChromeDriver(string "chromeDriverDirectory", ChromeOptions "options", TimeSpan commandTimeout);
//						cmdlet.WriteVerbose(cmdlet, "IWebDriver chromeDriver = new ChromeDriver(string \"chromeDriverDirectory\", ChromeOptions \"options\", TimeSpan \"commandTimeout\");");
//						listOfParameters.Add(new NamedParameter("commandTimeout", timeSpan));
//						try {
////Console.WriteLine("000210");
////    						driverServer =
////    						    Container.ResolveNamed<IWebDriver>(
////    						        ChromeDriverConstructorOptions.chrome_with_path_and_options_and_timespan.ToString(),
////    						        listOfParameters);
//    						driverServer =
//    						    GetDriverServerWithParameters(
//    						        listOfParameters,
//    						        DriverServerConstructorOptions.with_path_and_options_and_timespan,
//    						        driverServerType);
//						}
//						catch (Exception ePathOptionsTimeSpan) {
//						    cmdlet.WriteError(
//						        cmdlet,
//						        "Failed to create DriverServer with path, options and timeSpan. " +
//						        ePathOptionsTimeSpan.Message,
//						        "FailedWithPathOptionsTiemSpan",
//						        ErrorCategory.InvalidOperation,
//						        true);
//						}
//                        cmdlet.WriteVerbose(cmdlet, "DriverServer with path, options and timeSpan is done");
//						return driverServer;
//
//					}
//
//				}
//
//
//			} else if (string.Empty != driverDirectoryPath) {
////Console.WriteLine("000220");
//                cmdlet.WriteVerbose(cmdlet, "DriverServer with path only");
//				//IWebDriver chromeDriver = new ChromeDriver(string "chromeDriverDirectory");
//				cmdlet.WriteVerbose(cmdlet, "IWebDriver chromeDriver = new ChromeDriver(string \"chromeDriverDirectory\");");
//				listOfParameters.Add(new NamedParameter("chromeDriverDirectory", driverDirectoryPath));
//
//				try {
////Console.WriteLine("000230");
////					driverServer =
////					    Container.ResolveNamed<IWebDriver>(
////					        ChromeDriverConstructorOptions.chrome_with_path.ToString(),
////					        listOfParameters);
//					driverServer =
//					    GetDriverServerWithParameters(
//					        listOfParameters,
//					        DriverServerConstructorOptions.with_path,
//					        driverServerType);
//
//				} catch (Exception ePathOnly) {
//
//					cmdlet.WriteError(
//					    cmdlet,
//					    "Failed to create DriverServer with path only. " + 
//					    ePathOnly.Message,
//					    "FailedWithPathOnly",
//					    ErrorCategory.InvalidOperation,
//					    true);
//				}
//                cmdlet.WriteVerbose(cmdlet, "DriverServer with path only is done");
//				return driverServer;
//
//			} else {
////Console.WriteLine("000240");
//			    cmdlet.WriteVerbose(cmdlet, "DriverServer as bare");
//				//IWebDriver chromeDriver = new ChromeDriver();
//				cmdlet.WriteVerbose(cmdlet, "IWebDriver ***Driver = new ***Driver();");
//
//                try {
////Console.WriteLine("000250");
////    				driverServer =
////    				    Container.ResolveNamed<IWebDriver>(
////    				        ChromeDriverConstructorOptions.chrome_bare.ToString());
//    				driverServer =
//    				    GetDriverServerWithParameters(
//    				        listOfParameters,
//    				        DriverServerConstructorOptions.bare,
//    				        driverServerType);
//                }
//                catch (Exception eBare) {
//                    cmdlet.WriteError(
//                        cmdlet,
//                        "Failed to create bare DriverServer. " + 
//                        eBare.Message,
//                        "FailedBare",
//                        ErrorCategory.InvalidOperation,
//                        true);
//                }
//                cmdlet.WriteVerbose(cmdlet, "DriverServer bare is done");
//				return driverServer;
//
//			}
//			
//			
//            if (DriverServers.chrome == driverServerType) {
//                SeHelper.GetDriverProcess(Drivers.Chrome, driver.Title + SeHelper.DriverTitleComplementChrome);
//            }
//            if (DriverServers.ie == driverServerType) {
//                SeHelper.GetDriverProcess(Drivers.InternetExplorer, driver.Title + SeHelper.DriverTitleComplementInternetExplorer);
//            }
//		}
#endregion commented
        
#region commented
//        public static IWebDriver GetIEDriver(StartSeDriverServerCommand cmdlet)
//		{
//			// working with the cmdlet parameters
//
//			IWebDriver ieDriver = null;
//			System.Collections.Generic.List<Autofac.Core.Parameter> listOfParameters =
//			    new System.Collections.Generic.List<Autofac.Core.Parameter>();
//
//			InternetExplorerOptions options = null;
//			InternetExplorerDriverService service = null;
//			string driverDirectoryPath = string.Empty;
//			TimeSpan timeSpan = System.TimeSpan.MinValue;
//			bool zeroTimeSpan = false;
//			
//			if (cmdlet.AsService) {
//				if (null == cmdlet.DriverDirectoryPath ||
//			        string.Empty == cmdlet.DriverDirectoryPath ||
//			        !System.IO.Directory.Exists(cmdlet.DriverDirectoryPath)) {
//
//                    try {
//                        cmdlet.WriteVerbose(cmdlet, "InternetExplorerDriver with service and no path");
//                        service = InternetExplorerDriverService.CreateDefaultService();
//                    } catch (Exception eServiceNoPath) {
//
//                        cmdlet.WriteError(
//                            cmdlet,
//                            "Failed to create InternetExplorer service. " +
//                            eServiceNoPath.Message,
//                            "FailedService",
//                            ErrorCategory.InvalidOperation,
//                            true);
//                    }
//                    cmdlet.WriteVerbose(cmdlet, "InternetExplorerDriver service with no path is done");
//				} else {
//                    
//			        cmdlet.WriteVerbose(cmdlet, "InternetExplorerDriver service with path");
//					service = InternetExplorerDriverService.CreateDefaultService(cmdlet.DriverDirectoryPath);
//				}
//
//				if (null == cmdlet.IEOptions) {
//
//			        cmdlet.WriteVerbose(cmdlet, "InternetExplorerDriver: creating options");
//					options = 
//					    WebDriverFactory.Container.Resolve<InternetExplorerOptions>();
//					cmdlet.WriteVerbose(cmdlet, "InternetExplorerDriver: options are done");
//				}
//			}
//
//			if (null != cmdlet.IEOptions) {
//Console.WriteLine("ie doing options from the parameter");
//				options = cmdlet.IEOptions;
//Console.WriteLine("ie options done 2");
//			}
//
//			if (null != cmdlet.DriverDirectoryPath) {
//
//				driverDirectoryPath = cmdlet.DriverDirectoryPath;
//			}
//
//			if (null != cmdlet.Timeout && 0 != cmdlet.Timeout) {
//
//				timeSpan = System.TimeSpan.FromMilliseconds(cmdlet.Timeout);
//			} else {
//
//				timeSpan = System.TimeSpan.FromSeconds(60);
//				//timeSpan = System.TimeSpan.MinValue;
//				zeroTimeSpan = true;
//
//			}
//
//			if (null != service) {
//
//				//IWebDriver ieDriver = new ChromeDriver(DriverService "service", InternetExplorerOptions "options", TimeSpan commandTimeout);
//				cmdlet.WriteVerbose(cmdlet, "IWebDriver ieDriver = new InternetExplorerDriver(DriverService \"service\", InternetExplorerOptions \"options\", TimeSpan \"commandTimeout\");");
//				listOfParameters.Add(new NamedParameter("service", service));
//				listOfParameters.Add(new NamedParameter("options", options));
//				listOfParameters.Add(new NamedParameter("commandTimeout", timeSpan));
//Console.WriteLine("ie service");
//				ieDriver =
//				    Container.ResolveNamed<IWebDriver>(
//				        IEDriverConstructorOptions.ie_with_service_and_options_and_timespan.ToString(),
//				        listOfParameters);
//Console.WriteLine("ie service returned");
//				return ieDriver;
//
//			} else if (null != options) {
//Console.WriteLine("ie options?");
//				if (string.Empty == driverDirectoryPath) {
//Console.WriteLine("ie options");
//					//IWebDriver ieDriver = new ChromeDriver(InternetExplorerOptions "options");
//					cmdlet.WriteVerbose(cmdlet, "IWebDriver ieDriver = new InternetExplorerDriver(InternetExplorerOptions \"options\");");
//					listOfParameters.Add(new NamedParameter("options", options));
//					try {
//
//						ieDriver =
//						    Container.ResolveNamed<IWebDriver>(
//						        IEDriverConstructorOptions.ie_with_options.ToString(),
//						        listOfParameters);
//					} catch (Exception e2) {
//						Console.WriteLine(e2.Message);
//					}
//Console.WriteLine("ie options returned");
//					return ieDriver;
//
//				} else {
//
//					listOfParameters.Add(new NamedParameter("internetExplorerDriverServerDirectory", driverDirectoryPath));
//					listOfParameters.Add(new NamedParameter("options", options));
//
//					//if (System.TimeSpan.MinValue == timeSpan) {
//					if (zeroTimeSpan) {
//Console.WriteLine("ie path, options");
//						//IWebDriver ieDriver = new ChromeDriver(string "internetExplorerDriverServerDirectory", InternetExplorerOptions "options");
//						cmdlet.WriteVerbose(cmdlet, "IWebDriver ieDriver = new InternetExplorerDriver(string \"internetExplorerDriverServerDirectory\", InternetExplorerOptions \"options\");");
//						ieDriver =
//						    Container.ResolveNamed<IWebDriver>(
//						        IEDriverConstructorOptions.ie_with_path_and_options.ToString(),
//						        listOfParameters);
//Console.WriteLine("ie path, options returned");
//						return ieDriver;
//
//					} else {
//Console.WriteLine("ie path, options, timeSpan");
//						//IWebDriver ieDriver = new ChromeDriver(string "internetExplorerDriverServerDirectory", InternetExplorerOptions "options", TimeSpan commandTimeout);
//						cmdlet.WriteVerbose(cmdlet, "IWebDriver ieDriver = new InternetExplorerDriver(string \"internetExplorerDriverServerDirectory\", InternetExplorerOptions \"options\", TimeSpan \"commandTimeout\");");
//						listOfParameters.Add(new NamedParameter("commandTimeout", timeSpan));
//						ieDriver =
//						    Container.ResolveNamed<IWebDriver>(
//						        IEDriverConstructorOptions.ie_with_path_and_options_and_timespan.ToString(),
//						        listOfParameters);
//Console.WriteLine("ie path, options, timeSpan returned");
//						return ieDriver;
//
//					}
//
//				}
//
//
//			} else if (string.Empty != driverDirectoryPath) {
//Console.WriteLine("ie path");
//				//IWebDriver ieDriver = new ChromeDriver(string "internetExplorerDriverServerDirectory");
//				cmdlet.WriteVerbose(cmdlet, "IWebDriver ieDriver = new InternetExplorerDriver(string \"internetExplorerDriverServerDirectory\");");
//				listOfParameters.Add(new NamedParameter("internetExplorerDriverServerDirectory", driverDirectoryPath));
//
//				try {
//
//					ieDriver =
//					    Container.ResolveNamed<IWebDriver>(
//					        IEDriverConstructorOptions.ie_with_path.ToString(),
//					        listOfParameters);
//
//				} catch (Exception eeeeee) {
//
//					Console.WriteLine(eeeeee.Message);
//				}
//Console.WriteLine("ie path returned");
//				return ieDriver;
//
//			} else {
//
//				//IWebDriver ieDriver = new InternetExplorerDriver();
//				cmdlet.WriteVerbose(cmdlet, "IWebDriver ieDriver = new InternetExplorerDriver();");
//Console.WriteLine("ie bare");
//				ieDriver =
//				    Container.ResolveNamed<IWebDriver>(
//				        IEDriverConstructorOptions.ie_bare.ToString());
//Console.WriteLine("ie bare returned");
//				return ieDriver;
//
//			}
//		}
#endregion commented

        public static FirefoxProfile GetFirefoxProfile(FirefoxProfileCmdletBase cmdlet)
        {
            FirefoxProfile profile = null;
            System.Collections.Generic.List<Autofac.Core.Parameter> listOfParameters =
			    new System.Collections.Generic.List<Autofac.Core.Parameter>();

			string profileDirectory =
                ((NewSeFirefoxProfileCommand)cmdlet).ProfileDirectoryPath;
			bool deleteSourceOnClean =
                ((NewSeFirefoxProfileCommand)cmdlet).DeleteSource;
Console.WriteLine("000000000000-00000000000003");
            if (null != profileDirectory && string.Empty != profileDirectory) {
Console.WriteLine("000000000000-00000000000004");
			    listOfParameters.Add(
			        new NamedParameter(
			            "profileDirectory",
			            profileDirectory));
Console.WriteLine("000000000000-00000000000005");
                if (deleteSourceOnClean) {
Console.WriteLine("000000000000-00000000000006");
                    listOfParameters.Add(
			            new NamedParameter(
			                "deleteSourceOnClean",
			                deleteSourceOnClean));
Console.WriteLine("000000000000-00000000000007");
                    profile =
                        Container.ResolveNamed<FirefoxProfile>(
                            FirefoxProfileConstructorOptions.ff_with_path_and_bool.ToString(),
                            listOfParameters);
Console.WriteLine("000000000000-00000000000008");
                } else {
Console.WriteLine("000000000000-00000000000009");
                    profile =
                        Container.ResolveNamed<FirefoxProfile>(
                            FirefoxProfileConstructorOptions.ff_with_path.ToString(),
                            listOfParameters);
Console.WriteLine("000000000000-00000000000010");
                }
            } else {
Console.WriteLine("000000000000-00000000000011");
                profile =
                    Container.ResolveNamed<FirefoxProfile>(
                        FirefoxProfileConstructorOptions.ff_bare.ToString());
Console.WriteLine("000000000000-00000000000012");
            }
Console.WriteLine("000000000000-00000000000013");
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
