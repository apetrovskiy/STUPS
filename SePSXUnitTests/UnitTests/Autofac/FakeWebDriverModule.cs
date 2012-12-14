/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/27/2012
 * Time: 8:16 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXUnitTests
{
    using System;
    using Autofac;
    using Autofac.Builder;
    using Autofac.Features.ResolveAnything;
    using SePSX;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Firefox;
    using OpenQA.Selenium.IE;
    using System.Reflection;
    
    using System.Drawing;
    
    /// <summary>
    /// Description of FakeWebDriverModule.
    /// </summary>
    public class FakeWebDriverModule : Autofac.Module
    {
        public FakeWebDriverModule()
        {
        }
        
        protected override void Load(ContainerBuilder builder)
        {
        #region SePSX
            Assembly sepsxAssembly = null;
            Assembly[] assemblies =
                System.AppDomain.CurrentDomain.GetAssemblies();
            foreach (Assembly assm in assemblies) {
                if (assm.FullName.Contains("SePSX,")) { // || assm.FullName.Contains("WebDriver")) {
                    sepsxAssembly = assm;
                    break;
                    //builder.RegisterAssemblyTypes(new Assembly[]{ sepsxAssembly });
                }
            }
            
            try {
                builder.RegisterAssemblyTypes(new Assembly[]{ sepsxAssembly });
            }
            catch (Exception eRegisterAssembly) {
                //Console.WriteLine("Assembly registration failed");
                //Console.WriteLine(eRegisterAssembly.Message);
            }
        #endregion SePSX
            
        #region WebDriver
            #region ChromeDriver
                #region ChromeOptions
            //builder.RegisterType(typeof(ChromeOptions)); // .RegisterType<ChromeOptions>(); // temporarily ??
            builder.RegisterType<ChromeOptions>();
//            try {
//            builder.RegisterType<ChromeOptions>().As<FakeChromeOptions>();
//            } catch (Exception eChromeOptions) {
//                Console.WriteLine(eChromeOptions.Message);
//                Console.WriteLine(eChromeOptions.GetType().Name);
//            }
                #endregion ChromeOptions
            
//			builder.RegisterType<FakeChromeDriver>()
//			    .As<IWebDriver>().UsingConstructor(new Type[]{} )
//			    .Named<IWebDriver>("chrome_bare");
//
//			builder.RegisterType<FakeChromeDriver>()
//			    .As<IWebDriver>().UsingConstructor(new Type[] {
//			                                           typeof(string)
//			                                       })
//			    .Named<IWebDriver>("chrome_with_path");
//
//			builder.RegisterType<FakeChromeDriver>()
//			    .As<IWebDriver>().UsingConstructor(new Type[] {
//			                                       typeof(ChromeOptions)
//			                                       })
//			    .Named<IWebDriver>("chrome_with_options");
//
//			builder.RegisterType<FakeChromeDriver>()
//			    .As<IWebDriver>().UsingConstructor(new Type[] {
//			                                           typeof(string),
//			                                           typeof(ChromeOptions)
//			                                       })
//			    .Named<IWebDriver>("chrome_with_path_and_options");
//
//			builder.RegisterType<FakeChromeDriver>()
//			    .As<IWebDriver>().UsingConstructor(new Type[] {
//			                                           typeof(string),
//			                                           typeof(ChromeOptions),
//			                                           typeof(TimeSpan)
//			                                       })
//			    .Named<IWebDriver>("chrome_with_path_and_options_and_timespan");
//
//			builder.RegisterType<FakeChromeDriver>()
//			    .As<IWebDriver>().UsingConstructor(new Type[] {
//			                                           typeof(DriverService),
//			                                           typeof(ChromeOptions),
//			                                           typeof(TimeSpan)
//			                                       })
//			    .Named<IWebDriver>("chrome_with_service_and_options_and_timespan");
			

			builder.RegisterType<FakeChromeDriver>()
			    .As<IWebDriver>().UsingConstructor(new Type[] {
			                                           typeof(DriverService),
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
                
            #endregion FirefoxDriver
            #region IEDriverServer
                #region InternetExplorerOptions
            builder.RegisterType<InternetExplorerOptions>();
                #endregion InternetExplorerOptions
            
//			builder.RegisterType<FakeIEDriver>()
//			    .As<IWebDriver>().UsingConstructor(new Type[]{} )
//			    .Named<IWebDriver>("ie_bare");
//
//			builder.RegisterType<FakeIEDriver>()
//			    .As<IWebDriver>().UsingConstructor(new Type[] {
//			                                           typeof(string)
//			                                       })
//			    .Named<IWebDriver>("ie_with_path");
//
//			builder.RegisterType<FakeIEDriver>()
//			    .As<IWebDriver>().UsingConstructor(new Type[] {
//			                                       typeof(InternetExplorerOptions)
//			                                       })
//			    .Named<IWebDriver>("ie_with_options");
//
//			builder.RegisterType<FakeIEDriver>()
//			    .As<IWebDriver>().UsingConstructor(new Type[] {
//			                                           typeof(string),
//			                                           typeof(InternetExplorerOptions)
//			                                       })
//			    .Named<IWebDriver>("ie_with_path_and_options");
//
//			builder.RegisterType<FakeIEDriver>()
//			    .As<IWebDriver>().UsingConstructor(new Type[] {
//			                                           typeof(string),
//			                                           typeof(InternetExplorerOptions),
//			                                           typeof(TimeSpan)
//			                                       })
//			    .Named<IWebDriver>("ie_with_path_and_options_and_timespan");
//
//			builder.RegisterType<FakeIEDriver>()
//			    .As<IWebDriver>().UsingConstructor(new Type[] {
//			                                           typeof(DriverService),
//			                                           typeof(InternetExplorerOptions),
//			                                           typeof(TimeSpan)
//			                                       })
//			    .Named<IWebDriver>("ie_with_service_and_options_and_timespan");
			
			builder.RegisterType<FakeIEDriver>()
			    .As<IWebDriver>().UsingConstructor(new Type[] {
			                                           typeof(DriverService),
			                                           typeof(InternetExplorerOptions),
			                                           typeof(TimeSpan)
			                                       })
			    .Named<IWebDriver>("ie");
                
            #endregion IEDriverServer
        #endregion WebDriver
        
        #region Decorators
        try{
//System.Windows.Forms.MessageBox.Show("beginning");
        builder.RegisterType<FakeWebElementDecorator>()
            .As<WebElementDecorator>()
            .UsingConstructor(new Type[] {
                                  //typeof(IWebDriver)
                                  typeof(FakeWebElement)
                              })
            .Keyed<IWebElement>(Constructors.FakeWebElement_As_Decorator);
//System.Windows.Forms.MessageBox.Show("decorator");
        builder.RegisterType<FakeWebElement>()
            .As<IWebElement>()
            .UsingConstructor(new Type[] {
                                  //typeof(IWebDriver)
                                  typeof(FakeWebElement)
                              })
            .Keyed<IWebElement>(Constructors.FakeWebElement_IWebDriver);
//System.Windows.Forms.MessageBox.Show("good IWebDriver");
        builder.RegisterType<FakeWebElement>()
            .As<IWebElement>()
            .UsingConstructor(new Type[] {})
            .Keyed<IWebElement>(Constructors.FakeWebElement_NoParameters);
//System.Windows.Forms.MessageBox.Show("good no param");
        builder.RegisterType<FakeWebElement>()
            .As<IWebElement>()
            .UsingConstructor(new Type[] {
                                  typeof(string),
                                  typeof(string)
                              })
            .Keyed<IWebElement>(Constructors.FakeWebElement_TagName_Text);
//System.Windows.Forms.MessageBox.Show("good two strings");
        builder.RegisterType<FakeWebElement>()
            .As<IWebElement>()
            .UsingConstructor(new Type[] {
                                  typeof(string),
                                  typeof(string),
                                  typeof(bool),
                                  typeof(bool),
                                  typeof(bool)
                              })
            .Keyed<IWebElement>(Constructors.FakeWebElement_TagName_Text_Displayed_Enabled_Selected);
//System.Windows.Forms.MessageBox.Show("good two strings and three booleans");
        builder.RegisterType<FakeWebElement>()
            .As<IWebElement>()
            .UsingConstructor(new Type[] {
                                  typeof(string),
                                  typeof(string),
                                  typeof(Point),
                                  typeof(Size)
                              })
            .Keyed<IWebElement>(Constructors.FakeWebElement_TagName_Text_Location_Size);
//System.Windows.Forms.MessageBox.Show("good two strings and point and size");
        } catch (Exception eeeee222222) {
            Console.WriteLine(eeeee222222.Message);
            Console.WriteLine(eeeee222222.GetType().Name);
            System.Windows.Forms.MessageBox.Show(eeeee222222.Message);
        }
//			builder.RegisterType<FakeChromeDriver>()
//			    .As<IWebDriver>().UsingConstructor(new Type[]{} )
//			    .Named<IWebDriver>("chrome_bare");
        #endregion Decorators
        
            builder.RegisterSource(new AnyConcreteTypeNotAlreadyRegisteredSource());
        }
    }
}
