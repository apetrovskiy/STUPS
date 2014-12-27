/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/27/2012
 * Time: 8:12 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System.Linq;

namespace SePSX
{
    using System;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Firefox;
    using OpenQA.Selenium.IE;
    using OpenQA.Selenium.Remote;
    using Autofac;
    using Autofac.Builder;
    using Autofac.Features.ResolveAnything;
    using System.Reflection;
    
    /// <summary>
    /// Description of WebDriverModule.
    /// </summary>
    public class WebDriverModule : Autofac.Module
    {
        public WebDriverModule()
        {
        }
        
        internal IContainer container = null;
        
        protected override void Load(ContainerBuilder builder)
        {
            
#region commented
            //kernel = new StandardKernel(new NChromeDriverModule());

            //builder = new ContainerBuilder();

//            ConstructorInfo[] cInfos;
//            foreach (Assembly assm in System.AppDomain.CurrentDomain.GetAssemblies()) {
//                if (assm.FullName.Contains("WebDriver")) {
//                    System.Type chromeDriverType =
//                        assm.GetType();
//                    cInfos =
//                        chromeDriverType.GetConstructors();
//                    break;
//                }
//            }
//            
//            foreach (ConstructorInfo cInfo in cInfos) {
//                ConstructorParameterBinding paramBinding =
//                    new ConstructorParameterBinding(
//                        cInfo,
//                IConstructorSelector constrSelector =
//                    new MostParametersConstructorSelector();
//                //constrSelector.
//            }

//            var builder = new ContainerBuilder();
//            builder.Register((c, p) => new Person(p.Named<string>("name")));
//            
//            using (var container = builder.Build())
//            {
//                var person = container.Resolve<Person>(new NamedParameter("name", "Fred"));    
//            }

//            builder.RegisterType<IWebDriver>().As<ChromeDriver>();
//            builder.Register<IWebDriver>((с, paramPath) => 
//                                         new ChromeDriver(paramPath.Named<string>("chromeDriverDirectory")));
//            builder.Register<IWebDriver>((с, paramOpt) => 
//                                         new ChromeDriver(paramOpt.Named<ChromeOptions>("options")));
            ////            builder.Register<IWebDriver>((IComponentContext с, string paramPath, ChromeOptions paramOpt) => 
            ////                                         new ChromeDriver(
            ////                                             paramPath.Named<string>("chromeDriverDirectory"),
            ////                                             paramOpt.Named<ChromeOptions>("options")));
//            builder.Register<IWebDriver>((с, parameters) => 
//                                         new ChromeDriver(
//                                             parameters[0].Named<string>("chromeDriverDirectory"),
//                                             parameters[1].Named<ChromeOptions>("options")));


//            builder.RegisterType<DoesSomething>()
//                   .As<IDoesSomething>()
//                   .WithParameter("helper", new HelperClass("do", "something"));
//            
//            builder.RegisterType<DoesSomethingElse>()
//                   .As<IDoesSomethingElse()
//                   .WithParameter("helper", new HelperClass("do", "somethingelse"));
#endregion commented

        #region SePSX

            Assembly[] assemblies =
                System.AppDomain.CurrentDomain.GetAssemblies();
            Assembly sepsxAssembly = assemblies.FirstOrDefault(assm => assm.FullName.Contains("SePSX,"));
            /*
            foreach (Assembly assm in assemblies)
            {
                if (assm.FullName.Contains("SePSX,"))
                { // || assm.FullName.Contains("WebDriver")) {
                    sepsxAssembly = assm;
                    break;
                    //builder.RegisterAssemblyTypes(new Assembly[]{ sepsxAssembly });
                }
            }
            */

            try {
                //builder.RegisterAssemblyTypes(new Assembly[]{ sepsxAssembly });
            }
            catch (Exception eRegisterAssembly) {
                //Console.WriteLine("Assembly registration failed");
                //Console.WriteLine(eRegisterAssembly.Message);
            }
        #endregion SePSX

        #region WebDriver
            #region ChromeDriver
                #region ChromeOptions
            //builder.RegisterType(typeof(ChromeOptions)); //builder.RegisterType<ChromeOptions>();
            builder.RegisterType<ChromeOptions>();
                #endregion ChromeOptions
                
                #region ChromeDriverService
                //ChromeDriverService svc = ChromeDriverService.CreateDefaultService(
            //builder.RegisterType<ChromeDriverService>().AsSelf();
            //builder.Register(ChromeDriverService.CreateDefaultService(), (new Parameter[]{ (new Autofac.Builder. Parameter(string)) })).As<ChromeDriverService>();
//            builder.Register(
//                (c, (new Autofac.NamedParameter("driverPath", s))) => c.Resolve<ChromeDriverService.CreateDefaultService(s))
//                    //System.IO.Path.GetDirectoryName(cmdlet.GetType().Assembly.Location)))
//                .As<ChromeDriverService>( new Type[]{ typeof(string) });
            
            
//builder.Register(c => new ChannelFactory<ITrackListing>(new BasicHttpBinding(), 
//    new EndpointAddress("http://localhost/Tracks")))
//  .As<IChannelFactory<ITrackListing>>();
// 
//builder.Register(c => c.Resolve<IChannelFactory<ITrackListing>>().CreateChannel())
//  .As<ITrackListing>()
//  .UseWcfSafeRelease();
                #endregion ChromeDriverService
                
#region commented
//            builder.RegisterType<ChromeDriver>()
//                .As<IWebDriver>().UsingConstructor(new Type[]{} )
//                .Named<IWebDriver>("chrome_bare");
//
//            builder.RegisterType<ChromeDriver>()
//                .As<IWebDriver>().UsingConstructor(new Type[] {
//                                                       typeof(string)
//                                                   })
//                .Named<IWebDriver>("chrome_with_path");
//
//            builder.RegisterType<ChromeDriver>()
//                .As<IWebDriver>().UsingConstructor(new Type[] {
//                                                   typeof(ChromeOptions)
//                                                   })
//                .Named<IWebDriver>("chrome_with_options");
//
//            builder.RegisterType<ChromeDriver>()
//                .As<IWebDriver>().UsingConstructor(new Type[] {
//                                                       typeof(string),
//                                                       typeof(ChromeOptions)
//                                                   })
//                .Named<IWebDriver>("chrome_with_path_and_options");
//
//            builder.RegisterType<ChromeDriver>()
//                .As<IWebDriver>().UsingConstructor(new Type[] {
//                                                       typeof(string),
//                                                       typeof(ChromeOptions),
//                                                       typeof(TimeSpan)
//                                                   })
//                .Named<IWebDriver>("chrome_with_path_and_options_and_timespan");
//
//            builder.RegisterType<ChromeDriver>()
//                .As<IWebDriver>().UsingConstructor(new Type[] {
//                                                       typeof(DriverService),
//                                                       typeof(ChromeOptions),
//                                                       typeof(TimeSpan)
//                                                   })
//                .Named<IWebDriver>("chrome_with_service_and_options_and_timespan");
#endregion commented
            
            builder.RegisterType<ChromeDriver>()
                .As<IWebDriver>().UsingConstructor(new Type[] {
                                                       // 20130131
                                                       // 2.29
                                                       //typeof(DriverService),
                                                       typeof(ChromeDriverService),
                                                       typeof(ChromeOptions),
                                                       typeof(TimeSpan)
                                                   })
                .Named<IWebDriver>("chrome");

            #endregion ChromeDriver
            #region FirefoxDriver
                #region Firefox profile
            builder.RegisterType<OpenQA.Selenium.Firefox.FirefoxProfile>()
                .UsingConstructor(new Type[]{} )
                .Named<OpenQA.Selenium.Firefox.FirefoxProfile>("ff_bare");
            builder.RegisterType<OpenQA.Selenium.Firefox.FirefoxProfile>()
                .UsingConstructor(new Type[] {
                                      typeof(string)
                                  })
                .Named<OpenQA.Selenium.Firefox.FirefoxProfile>("ff_with_path");
            builder.RegisterType<OpenQA.Selenium.Firefox.FirefoxProfile>()
                .UsingConstructor(new Type[] {
                                      typeof(string),
                                      typeof(bool)
                                  })
                .Named<OpenQA.Selenium.Firefox.FirefoxProfile>("ff_with_path_and_bool");
                #endregion Firefox profile
            
            builder.RegisterType<FirefoxDriver>()
                .As<IWebDriver>().UsingConstructor(new Type[]{} )
                .Named<IWebDriver>("ff_bare");
            builder.RegisterType<FirefoxDriver>()
                .As<IWebDriver>().UsingConstructor(new Type[] {
                                                       typeof(FirefoxProfile)
                                                   })
                .Named<IWebDriver>("ff_with_profile");
            builder.RegisterType<FirefoxDriver>()
                .As<IWebDriver>().UsingConstructor(new Type[] {
                                                       typeof(ICapabilities)
                                                   })
                .Named<IWebDriver>("ff_with_capabilities");
            builder.RegisterType<FirefoxDriver>()
                .As<IWebDriver>().UsingConstructor(new Type[] {
                                                       typeof(FirefoxBinary),
                                                       typeof(FirefoxProfile)
                                                   })
                .Named<IWebDriver>("ff_with_binary_and_profile");
            builder.RegisterType<FirefoxDriver>()
                .As<IWebDriver>().UsingConstructor(new Type[] {
                                                       typeof(FirefoxBinary),
                                                       typeof(FirefoxProfile),
                                                       typeof(TimeSpan)
                                                   })
                .Named<IWebDriver>("ff_with_binary_and_profile_and_timeout");
            
//        ff_bare,
//        ff_with_profile,
//        ff_with_capabilities,
//        ff_with_binary_and_profile,
//        ff_with_binary_and_profile_and_timeout
                    
            //bare
            //FirefoxProfile profile
            //ICapabilities capabilities
            //FirefoxBinary binary, FirefoxProfile profile
            //FirefoxBinary binary, FirefoxProfile profile, TimeSpan commandTimeout

            
            #endregion FirefoxDriver
            #region IEDriverServer
                #region InternetExplorerOptions
            builder.RegisterType<InternetExplorerOptions>();
                #endregion InternetExplorerOptions
                
                #region InternetExplorerDriverService
            //builder.RegisterType<InternetExplorerDriverService>().AsSelf();
            //builder.Register(InternetExplorerDriverService.CreateDefaultService((string s) => )).As<InternetExplorerDriverService>();
                #endregion InternetExplorerDriverService
            
#region commented
//            builder.RegisterType<InternetExplorerDriver>()
//                .As<IWebDriver>().UsingConstructor(new Type[]{} )
//                .Named<IWebDriver>("ie_bare");
//
//            builder.RegisterType<InternetExplorerDriver>()
//                .As<IWebDriver>().UsingConstructor(new Type[] {
//                                                       typeof(string)
//                                                   })
//                .Named<IWebDriver>("ie_with_path");
//
//            builder.RegisterType<InternetExplorerDriver>()
//                .As<IWebDriver>().UsingConstructor(new Type[] {
//                                                   typeof(InternetExplorerOptions)
//                                                   })
//                .Named<IWebDriver>("ie_with_options");
//
//            builder.RegisterType<InternetExplorerDriver>()
//                .As<IWebDriver>().UsingConstructor(new Type[] {
//                                                       typeof(string),
//                                                       typeof(InternetExplorerOptions)
//                                                   })
//                .Named<IWebDriver>("ie_with_path_and_options");
//
//            builder.RegisterType<InternetExplorerDriver>()
//                .As<IWebDriver>().UsingConstructor(new Type[] {
//                                                       typeof(string),
//                                                       typeof(InternetExplorerOptions),
//                                                       typeof(TimeSpan)
//                                                   })
//                .Named<IWebDriver>("ie_with_path_and_options_and_timespan");
//
//            builder.RegisterType<InternetExplorerDriver>()
//                .As<IWebDriver>().UsingConstructor(new Type[] {
//                                                       typeof(DriverService),
//                                                       typeof(InternetExplorerOptions),
//                                                       typeof(TimeSpan)
//                                                   })
//                .Named<IWebDriver>("ie_with_service_and_options_and_timespan");
#endregion commented
            
            builder.RegisterType<InternetExplorerDriver>()
                .As<IWebDriver>().UsingConstructor(new Type[] {
                                                       // 20130131
                                                       // 2.29
                                                       //typeof(DriverService),
                                                       typeof(InternetExplorerDriverService),
                                                       typeof(InternetExplorerOptions),
                                                       typeof(TimeSpan)
                                                   })
                .Named<IWebDriver>("ie");
            
//        public InternetExplorerDriver() : this(new InternetExplorerOptions())
//        public InternetExplorerDriver(InternetExplorerOptions options) : this(InternetExplorerDriverService.CreateDefaultService(), options, TimeSpan.FromSeconds(60.0))
//        public InternetExplorerDriver(string internetExplorerDriverServerDirectory) : this(internetExplorerDriverServerDirectory, new InternetExplorerOptions())
//        public InternetExplorerDriver(string internetExplorerDriverServerDirectory, InternetExplorerOptions options) : this(internetExplorerDriverServerDirectory, options, TimeSpan.FromSeconds(60.0))
//        public InternetExplorerDriver(string internetExplorerDriverServerDirectory, InternetExplorerOptions options, TimeSpan commandTimeout) : this(InternetExplorerDriverService.CreateDefaultService(internetExplorerDriverServerDirectory), options, commandTimeout)
//        public InternetExplorerDriver(DriverService service, InternetExplorerOptions options, TimeSpan commandTimeout) : base(new DriverServiceCommandExecutor(service, commandTimeout), options.ToCapabilities())
//
//            
                
            #endregion IEDriverServer
        #endregion WebDriver
        
        #region Decorators
        builder.RegisterType<WebElementDecorator>()
            .As<IWebElement>()
            .UsingConstructor(new Type[] {
                                  //typeof(IWebElement)
                                  typeof(RemoteWebElement)
                              });
        #endregion Decorators
        
            builder.RegisterSource(new AnyConcreteTypeNotAlreadyRegisteredSource());
        
        
        }
    }
}
