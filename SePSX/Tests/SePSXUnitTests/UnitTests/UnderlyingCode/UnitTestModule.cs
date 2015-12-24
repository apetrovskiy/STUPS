///*
// * Created by SharpDevelop.
// * User: Alexander Petrovskiy
// * Date: 12/4/2012
// * Time: 3:56 PM
// * 
// * To change this template use Tools | Options | Coding | Edit Standard Headers.
// */
//using System;
//
//namespace SePSXUnitTests
//{
//    using System;
//    using OpenQA.Selenium;
//    using OpenQA.Selenium.Chrome;
//    using OpenQA.Selenium.Firefox;
//    using OpenQA.Selenium.IE;
//    using Autofac;
//    using Autofac.Builder;
//    using System.Reflection;
//    
//    /// <summary>
//    /// Description of UnitTestModule.
//    /// </summary>
//    public class UnitTestModule : Autofac.Module
//    {
//        public UnitTestModule()
//        {
//        }
//        
//        internal IContainer container = null;
//        
//        protected override void Load(ContainerBuilder builder)
//        {
//            
//            Assembly sepsxAssembly = null;
//            Assembly[] assemblies =
//                System.AppDomain.CurrentDomain.GetAssemblies();
//            foreach (Assembly assm in assemblies) {
////Console.WriteLine(assm.FullName);
//                if (assm.FullName.Contains("SePSX,")) {
//                    sepsxAssembly = assm;
//                    break;
//                }
//            }
//            
//            try {
//                //builder.RegisterAssemblyModules(new Assembly[]{ sepsxAssembly });
//                //Console.WriteLine(sepsxAssembly.FullName);
//                builder.RegisterAssemblyTypes(new Assembly[]{ sepsxAssembly });
//            }
//            catch (Exception eRegisterAssembly) {
//                Console.WriteLine("Assembly registration failed");
//                Console.WriteLine(eRegisterAssembly.Message);
//            }
//                
////                .RegisterType<ChromeDriver>()
////                .As<IWebDriver>().UsingConstructor(new Type[]{} )
////                .Named<IWebDriver>("chrome_bare");
//            
//        }
//    }
//}
